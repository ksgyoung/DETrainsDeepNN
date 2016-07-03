using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Strategies.Pooling
{
    public class MaxPoolingStrategy : IMaxPoolingStrategy
    {
        public double GetPooledResult(double[] poolingInput)
        {
            return poolingInput.Max();
        }
    }
}
