using System;

namespace RfidApi.Core.Exceptions
{

    public class CpuTempNotAvailableException : Exception
    {

        public CpuTempNotAvailableException()
        {
        }

        public CpuTempNotAvailableException(string message) : base(message)
        {
        }

        public CpuTempNotAvailableException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
