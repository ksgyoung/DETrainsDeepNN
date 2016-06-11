using DETrainingDeepNN.Strategies.Crossover.Interfaces;
using DETrainingDeepNN.Strategies.Mutation.Interfaces;
using DETrainingDeepNN.Strategies.Selection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Algorithms
{
    public class DifferentialEvolution
    {
        private IMutationStrategy mutationStrategy;
        private ICrossoverStrategy crossoverStrategy;
        private ISelectionStrategy generationSelectionStrategy;
        private ISelectionStrategy differenceIndividualSelectionStrategy;
        internal List<Individual> population;

        public DifferentialEvolution(IMutationStrategy mutationStrategy, 
                                     ICrossoverStrategy crossoverStrategy, 
                                     ISelectionStrategy generationSelectionStrategy,
                                     ISelectionStrategy differenceIndividualSelectionStrategy
                                     )
        {
            this.mutationStrategy = mutationStrategy;
            this.crossoverStrategy = crossoverStrategy;
            this.generationSelectionStrategy = generationSelectionStrategy;
            this.differenceIndividualSelectionStrategy = differenceIndividualSelectionStrategy;
        }

        public void Run()
        {
            //initialise
            //for each iteration
            //run iteration
        }

        internal List<Individual> InitialisePopulation(int populationSize)
        {
            List<Individual> population = new List<Individual>();

            for(int index = 0; index < populationSize; index++)
            {
                population.Add(new Individual(null));
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

                Individual trialIndividual = mutationStrategy.GetTrialVector(target, differenceIndividual1, differenceIndividual2);
                Individual child = crossoverStrategy.Cross(individual, trialIndividual);

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
