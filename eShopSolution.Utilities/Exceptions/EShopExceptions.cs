using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Utilities.Exceptions
{
    public class EShopExceptions: Exception
    {
        public EShopExceptions()
        {

        }

        public EShopExceptions(string message): base(message)
        {

        }

        public EShopExceptions(string message, Exception inner): base(message, inner)
        {
        }
    }
}
