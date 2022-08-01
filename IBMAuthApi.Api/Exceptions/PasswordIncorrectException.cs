using System;

namespace IBMAuthApi.Api.Exceptions
{
    public class PasswordIncorrectException : Exception
    {
        public PasswordIncorrectException()
            : base("La contrasenia es incorrecta.")
        {

        }
    }
}
