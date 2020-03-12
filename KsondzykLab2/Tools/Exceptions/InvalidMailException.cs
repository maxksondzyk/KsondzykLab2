using System;
using System.Collections.Generic;
using System.Text;

namespace KsondzykLab2.Tools.Exceptions
{
    class InvalidMailException : ArgumentException
    {
        internal InvalidMailException(string message) : base(message)
        {

        }
    }
}
