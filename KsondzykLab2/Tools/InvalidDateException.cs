using System;

namespace KsondzykLab2.Tools
{
    class InvalidDateException : ArgumentException
    {
        internal InvalidDateException(string message) : base(message)
        {

        }
    }
}
