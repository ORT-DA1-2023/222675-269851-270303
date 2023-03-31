using System;

namespace App
{
    public class BackEndException : Exception
    {
        public BackEndException(string message) : base(message)
        {

        }
    }
}