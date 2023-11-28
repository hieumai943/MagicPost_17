using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPostUtilities.Exceptions
{
    public class EShopException : Exception
    {
        public EShopException() {
        }
        public EShopException(string message) : base(message)
        {

        }
        public EShopException(string message, Exception innerException) : base(message, innerException) { 
        }
    }
}
