using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Strategies.Convolution.Interfaces
{
    public interface IConvolutionStrategy
    {
        double Convolute(double[] imageSection, double[] filter);
    }
}
