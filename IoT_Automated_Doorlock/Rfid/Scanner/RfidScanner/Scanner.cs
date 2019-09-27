using Rfid.Persistence.Domain.Collections;
using Rfid.Persistence.UnitOfWorks;
using RfidScanner.Helpers;
using Swan.Logging;
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

        public Scanner(IUnitOfWork unitOfWork, DoorService doorService)
        {
            _unitOfWork = unitOfWork;
            _doorService = doorService;
        }

        public Task Initialize()
        {
            Console.Clear();
            return Run();
        }

        private async Task Run()
        {
            "Idle".Info();

            var device = new RFIDControllerMfrc522(Pi.Spi.Channel0, 500000, Pi.Gpio[22]);

/*            IGpioPin[] leds =
                            {
                                Pi.Gpio[BcmPin.Gpio18],
                                Pi.Gpio[BcmPin.Gpio12]
                            };
*/

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
                        "Door unlocked!".Info();
                        //ControlLed.TurnOfLeds(leds);
                        ControlLed.BlinkLed(Pi.Gpio[BcmPin.Gpio12], 3000);

                        await _unitOfWork.Logs.AddAsync(new Log
                        {
                            AttemptType = AttemptType.Success,
                            Message = "Door has been successfully unlocked."
                        }).ConfigureAwait(false);
                        // Wait until button is pressed to continue
                    }
                    else
                    {
                        // Card without access
                        "Access denied!".Info();
                        //ControlLed.TurnOfLeds(leds);
                        ControlLed.BlinkLed(Pi.Gpio[BcmPin.Gpio18], 3000);
                        await _unitOfWork.Logs.AddAsync(new Log
                        {
                            AttemptType = AttemptType.Fail,
                            Message = "Card does not have permission to unlock door!"
                        }).ConfigureAwait(false);
                        // Continue allow reading
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
            }
        }
    }
}
