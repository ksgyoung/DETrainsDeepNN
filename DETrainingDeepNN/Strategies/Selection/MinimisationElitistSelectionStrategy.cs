using DETrainingDeepNN.Strategies.Selection.Exceptions;
using DETrainingDeepNN.Strategies.Selection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Strategies.Selection
{
    public class MinimisationElitistSelectionStrategy : IMinimisationElitistSelectionStrategy
    {
        public Individual Select(List<Individual> individuals)
        {
            if(individuals.Count == 0)
            {
                throw new NoValidIndividualsException();
            }

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
