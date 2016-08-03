using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Calculators
{
    public interface ITwoDimensionalMapper
    {
        double[] GetArrayRepresentation(double[,] matrix);

        double[,] GetTwoDimensionalRepresentation(double[] arrayRepresentation, int width);
    }
}
