using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Strategies.Crossover.Interfaces
{
    public interface ICrossoverStrategy
    {
        Individual Cross(Individual individual1, Individual individual2);
    }
}
