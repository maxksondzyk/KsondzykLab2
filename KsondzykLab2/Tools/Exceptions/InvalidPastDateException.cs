using System;
using System.Collections.Generic;
using System.Text;

namespace KsondzykLab2.Tools.Exceptions
{
    internal class InvalidPastDateException : ArgumentException
    {
        internal InvalidPastDateException(string message) : base(message)
        {

        }
    }
}
