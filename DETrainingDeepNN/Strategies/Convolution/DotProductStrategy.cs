using DETrainingDeepNN.Strategies.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Strategies.Convolution
{
    public class DotProductStrategy : IDotProductStrategy
    {
        public double Convolute(double[] imageSection, Individual filter)
        {
            if(filter.Position.Length != imageSection.Length)
            {
                throw new DifferingConvolutionSizeException();
            }

            double dotProduct = 0;
            for( int i = 0; i < imageSection.Length; i++)
            {
                dotProduct += imageSection[i] * filter.Position[i];
            }

            return dotProduct;
        }
    }
}
