using System;

namespace IBMAuthApi.Api.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException()
            : base("El usuario no existe.")
        {

        }
    }
}
