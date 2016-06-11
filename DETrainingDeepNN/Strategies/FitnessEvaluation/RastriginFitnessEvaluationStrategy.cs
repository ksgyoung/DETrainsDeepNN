using DETrainingDeepNN.Strategies.FitnessEvaluation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Strategies.FitnessEvaluation
{
    public class RastriginFitnessEvaluationStrategy : IRastriginFitnessEvaluationStrategy
    {
        public double GetFitnessForIndividual(Individual individual)
        {
            int dimensions = individual.Position.Length;
            double[] positions = individual.Position;

            return 10 * dimensions + positions.Sum(x => Math.Pow(x, 2) - 10 * Math.Cos(2 * Math.PI * x));
        }
    }
}
