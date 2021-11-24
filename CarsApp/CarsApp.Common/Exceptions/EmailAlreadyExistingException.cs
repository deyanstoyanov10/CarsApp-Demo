namespace CarsApp.Common.Exceptions
{
    using System;

    public class EmailAlreadyExistingException : Exception
    {
        public EmailAlreadyExistingException(string message)
            : base(message) {}
    }
}
