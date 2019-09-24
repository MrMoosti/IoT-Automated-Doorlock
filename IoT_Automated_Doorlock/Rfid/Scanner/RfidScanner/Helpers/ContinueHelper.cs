using System;
using System.Threading.Tasks;
using Swan;

namespace RfidScanner.Helper
{

    public static class ContinueHelper
    {

        /// <summary>
        /// Aks to continue.
        /// </summary>
        public static void AskToContinue()
        {
            Terminal.WriteLine("Press Esc key to continue . . .");

            while (true)
            {
                var input = Console.ReadKey(true).Key;
                if (input != ConsoleKey.Escape) continue;
                return;
            }
        }
    }
}