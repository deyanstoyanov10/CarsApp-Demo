namespace CarsApp.Common.Exceptions
{
    using System;

    public class UsernameAlreadyExistingException : Exception
    {
        public UsernameAlreadyExistingException(string message)
            : base(message) { }
    }
}
