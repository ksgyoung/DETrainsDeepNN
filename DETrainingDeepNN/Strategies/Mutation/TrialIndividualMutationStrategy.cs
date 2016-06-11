using DETrainingDeepNN.Strategies.Mutation.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Strategies.Mutation
{
    public class TrialIndividualMutationStrategy : ITrialIndividualMutationStrategy
    {
        public Individual GetTrialVector(Individual target, List<Individual> differenceIndividuals)
        {
            double scale = Double.Parse(ConfigurationManager.AppSettings["MutationScale"]);
            Individual differenceIndividual = this.GetDifference(differenceIndividuals);

            return target + this.Scale(differenceIndividual, scale);
        }

        internal Individual Scale(Individual individual, double scale)
        {
            return new Individual(null)
            {
                Position = individual.Position.Select((x, i) => x * scale).ToArray()
            };
        }

        internal Individual GetDifference(List<Individual> individuals)
        {
            Individual difference = individuals[0];

            for(int index = 1; index < individuals.Count; index ++)
            {
                difference -= individuals[index];
            }

            return difference;
        }


    }
}
