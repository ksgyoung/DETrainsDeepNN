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
using DETrainingDeepNN.ConfigurationSettings;

namespace DETrainingDeepNN
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new Configuration();
            IMutationStrategy trialVectorMutationStrategy = new TrialIndividualMutationStrategy(configuration);
            ICrossoverStrategy crossoverStrategy = new BinomialCrossoverStrategy(configuration);
            ISelectionStrategy generationSelectionStrategy = new MinimisationElitistSelectionStrategy();
            ISelectionStrategy differenceVectorSelectionStrategy = new RandomSelectionStrategy();
            IFitnessEvaluationStrategy fitnessEvaluationStrategy = new RastriginFitnessEvaluationStrategy();

            DifferentialEvolution differentialEvolution = new DifferentialEvolution(
                trialVectorMutationStrategy, 
                crossoverStrategy, 
                generationSelectionStrategy, 
                differenceVectorSelectionStrategy, 
                fitnessEvaluationStrategy,
                configuration
                );

            differentialEvolution.Run();
            
            var population = differentialEvolution.population;

            foreach(Individual individual in population)
            {
                foreach (double dimension in individual.Position)
                {
                    Console.Write(Math.Round(dimension) + ", ");
                }

                Console.WriteLine();
            }

            Console.Read();

        }
    }
}
