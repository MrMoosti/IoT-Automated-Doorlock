using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Swan;
using Swan.Logging;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Peripherals;

namespace RfidScanner
{

    public class RfidMenu
    {

        private const string ExitMessage = "Press Esc key to continue . . .";

        private static readonly Dictionary<ConsoleKey, string> RfidOptions = new Dictionary<ConsoleKey, string>
        {
            { ConsoleKey.D, "Detect Card" },
            { ConsoleKey.W, "Write Card" },
            { ConsoleKey.R, "Read Card" },
            { ConsoleKey.S, "Read Card Sectors" }
        };


        public void Show()
        {
            var exit = false;

            do
            {
                Console.Clear();
                var mainOption = Terminal.ReadPrompt("Rfid menu", RfidOptions, "Esc to exit this menu");

                switch (mainOption.Key)
                {
                    case ConsoleKey.D:
                        CardDetected();
                        break;
                    case ConsoleKey.W:
                        WriteCard();
                        break;
                    case ConsoleKey.R:
                        ReadCard();
                        break;
                    case ConsoleKey.S:
                        ReadAllCardSectors();
                        break;
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                }
            }
            while (!exit);
        }


        private void CardDetected()
        {
            Console.Clear();
            "Testing RFID".Info();
            var device = new RFIDControllerMfrc522(Pi.Spi.Channel0, 500000, Pi.Gpio[22]);

            while (true)
            {
                // If a card is found
                if (device.DetectCard() != RFIDControllerMfrc522.Status.AllOk) continue;
                "Card detected".Info();

                // Get the UID of the card
                var uidResponse = device.ReadCardUniqueId();

                // If we have the UID, continue
                if (uidResponse.Status != RFIDControllerMfrc522.Status.AllOk) continue;

                var cardUid = uidResponse.Data;

                // Print UID
                $"Card UID: {string.Join(", ", cardUid)}".Info();

                Terminal.WriteLine(ExitMessage);

                while (true)
                {
                    var input = Console.ReadKey(true).Key;
                    if (input != ConsoleKey.Escape) continue;

                    break;
                }

                break;
            }
        }

        private void WriteCard()
        {
            Console.Clear();
            "Testing RFID".Info();

            var device = new RFIDControllerMfrc522(Pi.Spi.Channel0, 500000, Pi.Gpio[22]);
            var userInput = Terminal.ReadLine("Insert a message to be written in the card (16 characters only)").Truncate(16);
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
                    userInput = (userInput + new string(' ', 16)).Truncate(16);
                    device.CardWriteData(16, Encoding.ASCII.GetBytes(userInput));
                }

                device.ClearCardSelection();
                "Data has been written".Info();

                Terminal.WriteLine(ExitMessage);

                while (true)
                {
                    var input = Console.ReadKey(true).Key;
                    if (input != ConsoleKey.Escape) continue;

                    break;
                }

                break;
            }
        }

        private void ReadCard()
        {
            Console.Clear();
            "Testing RFID".Info();
            var device = new RFIDControllerMfrc522(Pi.Spi.Channel0, 500000, Pi.Gpio[22]);

            while (true)
            {
                // If a card is found
                if (device.DetectCard() != RFIDControllerMfrc522.Status.AllOk) continue;

                // Get the UID of the card
                var uidResponse = device.ReadCardUniqueId();

                // If we have the UID, continue
                if (uidResponse.Status != RFIDControllerMfrc522.Status.AllOk) continue;

                var cardUid = uidResponse.Data;

                // Print UID
                $"Card UID: {string.Join(", ", cardUid)}".Info();

                // Select the scanned tag
                device.SelectCardUniqueId(cardUid);

                // Authenticate sector
                if (device.AuthenticateCard1A(RFIDControllerMfrc522.DefaultAuthKey, cardUid, 19) == RFIDControllerMfrc522.Status.AllOk)
                {
                    var data = device.CardReadData(16);
                    var text = Encoding.ASCII.GetString(data.Data);

                    $" Message read: {text}".Info();
                }
                else
                {
                    "Authentication error".Error();
                }

                device.ClearCardSelection();
                Terminal.WriteLine(ExitMessage);

                while (true)
                {
                    var input = Console.ReadKey(true).Key;
                    if (input != ConsoleKey.Escape) continue;

                    break;
                }

                break;
            }
        }

        private void ReadAllCardSectors()
        {
            Console.Clear();

            "Testing RFID".Info();
            var device = new RFIDControllerMfrc522();

            while (true)
            {
                // If a card is found
                if (device.DetectCard() != RFIDControllerMfrc522.Status.AllOk) continue;

                // Get the UID of the card
                var uidResponse = device.ReadCardUniqueId();

                // If we have the UID, continue
                if (uidResponse.Status != RFIDControllerMfrc522.Status.AllOk) continue;

                var cardUid = uidResponse.Data;

                // Print UID
                $"Card UID: {string.Join(", ", cardUid)}".Info();

                // Select the scanned tag
                device.SelectCardUniqueId(cardUid);

                // Reading data
                var continueReading = true;
                for (var s = 0; s < 16 && continueReading; s++)
                {
                    // Authenticate sector
                    if (device.AuthenticateCard1A(RFIDControllerMfrc522.DefaultAuthKey, cardUid, (byte)((4 * s) + 3)) == RFIDControllerMfrc522.Status.AllOk)
                    {
                        $"Sector {s}".Info();
                        for (var b = 0; b < 3; b++)
                        {
                            var data = device.CardReadData((byte)((4 * s) + b));
                            if (data.Status != RFIDControllerMfrc522.Status.AllOk)
                            {
                                continueReading = false;
                                break;
                            }

                            $"  Block {b} ({data.Data.Length} bytes): {string.Join(" ", data.Data.Select(x => x.ToString("X2")))}".Info();
                        }
                    }
                    else
                    {
                        $"Authentication error, sector {s}".Error();
                    }
                }

                device.ClearCardSelection();

                Terminal.WriteLine(ExitMessage);

                while (true)
                {
                    var input = Console.ReadKey(true).Key;
                    if (input != ConsoleKey.Escape) continue;

                    break;
                }

                break;
            }
        }
    }
}