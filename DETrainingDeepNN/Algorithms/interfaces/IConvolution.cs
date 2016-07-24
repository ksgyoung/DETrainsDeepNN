using DETrainingDeepNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Algorithms.interfaces
{
    interface IConvolution
    {
        List<double[]> Convolve(ImageInput imageSubsection, List<double[]> filters);
    }
}
