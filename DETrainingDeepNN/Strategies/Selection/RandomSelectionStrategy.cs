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
        Random random;

        public RandomSelectionStrategy(Random random)
        {
            this.random = random;
        }

        public Individual Select(List<Individual> individuals)
        {
            int index = random.Next(individuals.Count);

            return individuals[index];
        }
    }
}
