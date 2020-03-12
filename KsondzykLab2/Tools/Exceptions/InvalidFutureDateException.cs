using System;

namespace KsondzykLab2.Tools
{
    class InvalidFutureDateException : ArgumentException
    {
        internal InvalidFutureDateException(string message) : base(message)
        {

        }
    }
}
