using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Strategies.Mutation.Interfaces
{
    public interface IMutationStrategy
    {
        Individual GetTrialVector(Individual targetIndividual, List<Individual> differenceIndividuals);
    }
}
