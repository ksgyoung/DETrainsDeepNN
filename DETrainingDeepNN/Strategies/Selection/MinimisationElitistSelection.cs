using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Strategies.Selection
{
    public class MinimisationElitistSelection
    {
        public Individual Select(List<Individual> individuals)
        {
            Individual mostFitIndividual = individuals[0];

            foreach (Individual indivividual in individuals)
            {
                if (indivividual.Fitness < mostFitIndividual.Fitness)
                {
                    mostFitIndividual = indivividual;
                }
            }
            
            return mostFitIndividual;
        }
    }
}
