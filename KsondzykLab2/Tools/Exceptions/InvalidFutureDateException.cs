using System;

namespace KsondzykLab2.Tools
{
    internal class InvalidFutureDateException : ArgumentException
    {
        internal InvalidFutureDateException(string message) : base(message)
        {

        }
    }
}
