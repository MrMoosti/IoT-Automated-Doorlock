using System;
namespace IoT.Program
{
    public class Mfrc522Exception : Exception
    {
        public Mfrc522Exception(string message)
            : base(message)
        {

        }
    }
}
