using DETrainingDeepNN.RandomGenerators;
using DETrainingDeepNN.Strategies.Selection.Exceptions;
using DETrainingDeepNN.Strategies.Selection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Strategies.Selection
{
    public class RandomSelectionStrategy : IRandomSelectionStrategy
    {
        RandomGenerator random;

        public RandomSelectionStrategy()
        {
            this.random = RandomGenerator.GetInstance();
        }

        public Individual Select(List<Individual> individuals)
        {
            if (individuals.Count > 0)
            {
                int index = random.NextInt(0, individuals.Count);

                return individuals[index];
            }

            throw new NoValidIndividualsException();
        }
    }
}
