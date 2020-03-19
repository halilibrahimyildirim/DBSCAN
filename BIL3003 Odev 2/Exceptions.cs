using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIL3003_Odev_2
{
    class FileNameException : Exception
    {
        public FileNameException(string message) : base(message) { }
    }
    class NotIntException:Exception
    {
        public NotIntException(string message) : base(message) { }
    }
    class InvalidNumberException:Exception
    {
        public InvalidNumberException(string message) : base(message) { }
    }
}
