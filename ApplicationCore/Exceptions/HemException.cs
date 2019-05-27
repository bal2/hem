using System;

namespace HADU.hem.ApplicationCore.Exceptions
{
    public class HemException : Exception
    {
        public int HttpStatus { get; }

        public HemException(int httpStatus, string message) : base(message)
        {
            HttpStatus = httpStatus;
        }

    }
}