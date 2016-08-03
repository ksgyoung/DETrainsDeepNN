using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Calculators
{
    public class TwoDimensionalIndexCalculator
    {
        public int GetIndex(int width, int xlocation, int yLocation)
        {
            return (width * yLocation) + xlocation;
        }
    }
}
