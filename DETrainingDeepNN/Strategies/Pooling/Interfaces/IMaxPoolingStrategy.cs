using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Strategies.Pooling
{
    public interface IMaxPoolingStrategy
    {
        double GetPooledResult(double[] poolingInput);
    }
}
