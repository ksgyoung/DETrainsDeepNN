using DETrainingDeepNN.Algorithms;
using DETrainingDeepNN.Algorithms.Interfaces;
using DETrainingDeepNN.Strategies.Crossover;
using DETrainingDeepNN.Strategies.Crossover.Interfaces;
using DETrainingDeepNN.Strategies.Mutation;
using DETrainingDeepNN.Strategies.Mutation.Interfaces;
using DETrainingDeepNN.Strategies.Selection.Interfaces;
using DETrainingDeepNN.Strategies.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DETrainingDeepNN.Strategies.FitnessEvaluation.Interfaces;
using DETrainingDeepNN.Strategies.FitnessEvaluation;

namespace DETrainingDeepNN
{
    class Program
    {
        static void Main(string[] args)
        {
            IMutationStrategy trialVectorMutationStrategy = new TrialIndividualMutationStrategy();
            ICrossoverStrategy crossoverStrategy = new BinomialCrossoverStrategy();
            ISelectionStrategy generationSelectionStrategy = new MinimisationElitistSelectionStrategy();
            ISelectionStrategy differenceVectorSelectionStrategy = new RandomSelectionStrategy();
            IFitnessEvaluationStrategy fitnessEvaluationStrategy = new RastriginFitnessEvaluationStrategy();

            DifferentialEvolution differentialEvolution = new DifferentialEvolution(
                trialVectorMutationStrategy, 
                crossoverStrategy, 
                generationSelectionStrategy, 
                differenceVectorSelectionStrategy, 
                fitnessEvaluationStrategy
                );

            differentialEvolution.Run();

            var population = differentialEvolution.population;
        }
    }
}
