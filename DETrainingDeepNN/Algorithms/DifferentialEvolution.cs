using DETrainingDeepNN.Algorithms.Interfaces;
using DETrainingDeepNN.Strategies.Crossover.Interfaces;
using DETrainingDeepNN.Strategies.FitnessEvaluation.Interfaces;
using DETrainingDeepNN.Strategies.Mutation.Interfaces;
using DETrainingDeepNN.Strategies.Selection.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace DETrainingDeepNN.Algorithms
{
    public class DifferentialEvolution : IDifferentialEvolution
    {
        private IMutationStrategy mutationStrategy;
        private ICrossoverStrategy crossoverStrategy;
        private ISelectionStrategy generationSelectionStrategy;
        private ISelectionStrategy differenceIndividualSelectionStrategy;
        private IFitnessEvaluationStrategy fitnessEvaluationStrategy;

        internal List<Individual> population;

        public DifferentialEvolution(IMutationStrategy mutationStrategy, 
                                     ICrossoverStrategy crossoverStrategy, 
                                     ISelectionStrategy generationSelectionStrategy,
                                     ISelectionStrategy differenceIndividualSelectionStrategy,
                                     IFitnessEvaluationStrategy fitnessEvaluationStrategy
                                     )
        {
            this.mutationStrategy = mutationStrategy;
            this.crossoverStrategy = crossoverStrategy;
            this.generationSelectionStrategy = generationSelectionStrategy;
            this.differenceIndividualSelectionStrategy = differenceIndividualSelectionStrategy;
            this.fitnessEvaluationStrategy = fitnessEvaluationStrategy;
        }

        public void Run()
        {
            int populationSize = Int32.Parse(ConfigurationManager.AppSettings["PopulationSize"]);
            int iterations = Int32.Parse(ConfigurationManager.AppSettings["Iterations"]);

            this.population = this.InitialisePopulation(populationSize);
            for(int iteration = 0; iteration < iterations; iteration++)
            {
                this.population = this.GetNewPopulation();
            }
        }

        internal List<Individual> InitialisePopulation(int populationSize)
        {
            List<Individual> population = new List<Individual>();

            for(int index = 0; index < populationSize; index++)
            {
                population.Add(new Individual(this.fitnessEvaluationStrategy));
            }

            return population;
        }

        internal List<Individual> GetNewPopulation()
        {
            List<Individual> newPopulation = new List<Individual>();

            foreach(Individual individual in population)
            {
                individual.EvaluateFitness();

                List<Individual> invalidIndividuals = new List<Individual>();

                Individual target = this.SelectDifferenceIndividual(population, invalidIndividuals);
                invalidIndividuals.Add(target);
                Individual differenceIndividual1 = this.SelectDifferenceIndividual(population, invalidIndividuals);
                invalidIndividuals.Add(differenceIndividual1);
                Individual differenceIndividual2 = this.SelectDifferenceIndividual(population, invalidIndividuals);

                Individual trialIndividual = mutationStrategy.GetTrialVector(target, new List<Individual>() { differenceIndividual1, differenceIndividual2 });
                Individual child = crossoverStrategy.Cross(individual, trialIndividual);

                child.EvaluateFitness();

                newPopulation.Add(generationSelectionStrategy.Select(new List<Individual> { individual, child }));
            }
            
            return newPopulation;
        }

        internal Individual SelectDifferenceIndividual(List<Individual> population, List<Individual> invalidIndividuals)
        {
            List<Individual> validPopulation = population.Where(x => !invalidIndividuals.Contains(x)).ToList();

            return differenceIndividualSelectionStrategy.Select(validPopulation);
        }
    }
}
