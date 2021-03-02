using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.Utilities.Exceptions
{
    public class ESaleException : Exception
    {
        public ESaleException()
        {
        }

        public ESaleException(string message)
            : base(message)
        {
        }

        public ESaleException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
