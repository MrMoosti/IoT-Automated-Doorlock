using System;
using System.Collections.Generic;
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

namespace RfidScanner
{

    public class UserService
    {

        private readonly IUnitOfWork _unitOfWork;


        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task Initialize()
        {
            Console.Clear();
            var exit = false;
            var mainOption = Terminal.ReadPrompt("Do you want to create a new user?",
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
                        await NewUser().ConfigureAwait(false);
                        return;
                    case ConsoleKey.N:
                        return;
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                }
            } while (!exit);

        }


        private async Task NewUser()
        {
            var device = new RFIDControllerMfrc522(Pi.Spi.Channel0, 500000, Pi.Gpio[22]);
            "Place the card on the sensor".Info();

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

                    await _unitOfWork.Logs.AddAsync(new Log
                    {
                        Uid = cardUid,
                        AttemptType = AttemptType.Success,
                        Message = $"User with Uid {cardUid} has granted access."
                    }).ConfigureAwait(false);
                    "Created and saved new log".Info();
                }
                device.ClearCardSelection();
                break;
            }
            ContinueHelper.AskToContinue();
        }
    }
}