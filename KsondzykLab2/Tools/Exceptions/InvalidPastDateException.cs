using System;
using System.Collections.Generic;
using System.Text;

namespace KsondzykLab2.Tools.Exceptions
{
    class InvalidPastDateException : ArgumentException
    {
        internal InvalidPastDateException(string message) : base(message)
        {

        }
    }
}
