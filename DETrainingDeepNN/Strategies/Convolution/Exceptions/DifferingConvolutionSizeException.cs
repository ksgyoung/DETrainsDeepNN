using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Strategies.Exceptions
{
    class DifferingConvolutionSizeException : Exception
    {
        public DifferingConvolutionSizeException()
        : base("The image subsection and filter size vary. Make sure that a subsection of the same size of the filter is selected")
        {
        }
    }
}
