using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Strategies.Selection.Exceptions
{
    public class NoValidIndividualsException : Exception
    {
        public NoValidIndividualsException()
        : base("No valid individual to select from was passed")
        {
        }
    }
}
