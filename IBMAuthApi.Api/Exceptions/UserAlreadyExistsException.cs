using System;

namespace IBMAuthApi.Api.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException()
            : base("El usuario a crear ya existe.")
        {

        }
    }
}
