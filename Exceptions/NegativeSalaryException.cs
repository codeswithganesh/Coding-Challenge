using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Exceptions
{
    internal class NegativeSalaryException:Exception
    {
        public NegativeSalaryException(string message) : base(message)
        {
        }
    }
}
