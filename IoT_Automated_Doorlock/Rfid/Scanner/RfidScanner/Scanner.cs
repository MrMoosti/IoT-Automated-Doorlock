using Rfid.Persistence.Domain.Collections;
using Rfid.Persistence.UnitOfWorks;
using RfidScanner.Helpers;
using Swan.Logging;
using RfidScanner.Services;
using System;
using System.Text;
using System.Threading.Tasks;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.RaspberryIO.Peripherals;
using Rfid.Persistence.Domain.Enums;

namespace RfidScanner
{

    public class Scanner
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DoorService _doorService;

        private bool _access;
        private bool _readAgain;

        public Scanner(IUnitOfWork unitOfWork, DoorService doorService)
        {
            _unitOfWork = unitOfWork;
            _doorService = doorService;

            var button = new Button(Pi.Gpio[BcmPin.Gpio17], GpioPinResistorPullMode.PullUp);

            button.Pressed += (s, e) => ContinueReading();

        }

        public Task Initialize()
        {
            Console.Clear();
            return Run();
        }

        private void ContinueReading()
        {
            if(_access)
            {
                "Door has been closed".Info();
                _access = false;
                _readAgain = true;
            }
        }

        private async Task Run()
        {
            "Idle".Info();

            var device = new RFIDControllerMfrc522(Pi.Spi.Channel0, 500000, Pi.Gpio[22]);

            while (true)
            {
                // If a card is found
                if (device.DetectCard() != RFIDControllerMfrc522.Status.AllOk) continue;

                // Get the UID of the card
                var uidResponse = device.ReadCardUniqueId();

                // If we have the Uid continue
                if (uidResponse.Status != RFIDControllerMfrc522.Status.AllOk) continue;

                var uid = uidResponse.Data;
                device.SelectCardUniqueId(uid);

                // Authentication
                if (device.AuthenticateCard1A(RFIDControllerMfrc522.DefaultAuthKey, uid, 19) == RFIDControllerMfrc522.Status.AllOk)
                {
                    var data = device.CardReadData(16);
                    var secretText = Encoding.ASCII.GetString(data.Data);

                    if (secretText == "HelloHelloHellos")
                    {
                        // Card with access
                        "Access granted!".Info();
                        ControlLed.BlinkLed(Pi.Gpio[BcmPin.Gpio22], -1);

                        await _unitOfWork.Logs.AddAsync(new Log
                        {
                            Uid = uid,
                            AttemptType = AttemptType.Success,
                            Message = "Door has been successfully unlocked."
                        }).ConfigureAwait(false);

                        await _doorService.UpdateDoorStateAsync(DoorStatus.Open).ConfigureAwait(false);

                        _access = true;
                        //Wait until button is pressed.
                        while(!_readAgain)
                        {
                            await Task.Delay(500).ConfigureAwait(false);
                        }
                        _readAgain = false;

                        ControlLed.BlinkLed(Pi.Gpio[BcmPin.Gpio22], 0);

                        await _doorService.UpdateDoorStateAsync(DoorStatus.Closed).ConfigureAwait(false);

                    }
                    else
                    {
                        // Card without access
                        "Access denied!".Info();
                        ControlLed.BlinkLed(Pi.Gpio[BcmPin.Gpio18], 3000);
                        await _unitOfWork.Logs.AddAsync(new Log
                        {
                            AttemptType = AttemptType.Fail,
                            Message = "Card does not have permission to unlock door!"
                        }).ConfigureAwait(false);

                    }

                }
                else
                {
                    // Unknown Card
                    ControlLed.BlinkLed(Pi.Gpio[BcmPin.Gpio18], 3000);
                    await _unitOfWork.Logs.AddAsync(new Log
                    {
                        AttemptType = AttemptType.UnkownUid,
                        Message = "Authentication error, can't read card!"
                    }).ConfigureAwait(false);
                }

                device.ClearCardSelection();
                await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
            }
        }
    }
}
