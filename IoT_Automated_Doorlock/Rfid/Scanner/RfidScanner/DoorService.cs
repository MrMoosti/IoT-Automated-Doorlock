using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Rfid.Persistence.Domain.Collections;
using Rfid.Persistence.Domain.Enums;
using Rfid.Persistence.UnitOfWorks;
using RfidScanner.Helper;
using Swan;
using Swan.Logging;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Peripherals;
using Unosquare.WiringPi;

namespace RfidScanner
{

    public class DoorService
    {

        private readonly IUnitOfWork _unitOfWork;


        public DoorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task Initialize()
        {
            Console.Clear();
            var exit = false;
            var mainOption = Terminal.ReadPrompt("Do you want to Test?",
                                                 new Dictionary<ConsoleKey, string>
                                                 {
                                                     {ConsoleKey.Y, "Yes"},
                                                     {ConsoleKey.N, "No"},
                                                 }, "Esc to exit this menu");

            do
            {
                switch (mainOption.Key)
                {
                    case ConsoleKey.Y:
                        //await checkDoor().ConfigureAwait(false);
                        await DoorInput().ConfigureAwait(false)
;                        return;
                    case ConsoleKey.N:
                        return;
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                }
            } while (!exit);

        }

        public async Task DoorInput() {
            var button = Pi.Gpio[Unosquare.RaspberryIO.Abstractions.BcmPin.Gpio11];
            "Testing button".Info();
                button.PinMode = Unosquare.RaspberryIO.Abstractions.GpioPinDriveMode.Input;

            while(true) {
                Console.WriteLine(button.Read());
                System.Threading.Thread.Sleep(1000);
            }
            ContinueHelper.AskToContinue();
        }


        private async Task checkDoor()
        {
            var device = new RFIDControllerMfrc522(Pi.Spi.Channel0, 500000, Pi.Gpio[22]);
            "Place the card on the sensor".Info();

            var redLed = Pi.Gpio[Unosquare.RaspberryIO.Abstractions.BcmPin.Gpio18];
            var greenLed = Pi.Gpio[Unosquare.RaspberryIO.Abstractions.BcmPin.Gpio12];

            redLed.PinMode = Unosquare.RaspberryIO.Abstractions.GpioPinDriveMode.Output;
            greenLed.PinMode = Unosquare.RaspberryIO.Abstractions.GpioPinDriveMode.Output;

            greenLed.Write(true);
            redLed.Write(true);

            while (true)
            {
                // If a card is found
                if (device.DetectCard() != RFIDControllerMfrc522.Status.AllOk) continue;

                // Get the UID of the card
                var uidResponse = device.ReadCardUniqueId();

                // If we have the UID, continue
                if (uidResponse.Status != RFIDControllerMfrc522.Status.AllOk) continue;

                var cardUid = uidResponse.Data;

                // Select the scanned tag
                device.SelectCardUniqueId(cardUid);

                // Writing data to sector 1 blocks
                // Authenticate sector
                if (device.AuthenticateCard1A(RFIDControllerMfrc522.DefaultAuthKey, cardUid, 19) == RFIDControllerMfrc522.Status.AllOk)
                {
                    var data = device.CardReadData(16);
                    var text = Encoding.ASCII.GetString(data.Data);

                    byte[] secretPass = Encoding.ASCII.GetBytes("HelloHelloHellos");

                    text.Info();

                    if (data.Data.SequenceEqual(secretPass))
                    {
                        "Access granted!".Info();
                        greenLed.Write(false);
                        System.Threading.Thread.Sleep(3000);
                    }
                    else
                    {
                        "Access denied!".Info();
                        redLed.Write(false);
                        System.Threading.Thread.Sleep(3000);
                    }

                    greenLed.Write(true);
                    redLed.Write(true);

                    /* await _unitOfWork.Logs.AddAsync(new Log
                     {
                         Uid = cardUid,
                         AttemptType = AttemptType.Success,
                         Message = $"User with Uid {cardUid} has granted access."
                     }).ConfigureAwait(false);*/
                    /*"Created and saved new log".Info();*/
                }
                device.ClearCardSelection();
                break;
            }
            ContinueHelper.AskToContinue();
        }
    }
}