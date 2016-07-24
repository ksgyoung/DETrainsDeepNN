using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DETrainingDeepNN.Strategies.FitnessEvaluation.Interfaces;
using DETrainingDeepNN.RandomGenerators;
using DETrainingDeepNN.ConfigurationSettings;

namespace DETrainingDeepNN
{
    public class Individual
    {
        public double Fitness { get; set; }
        public double[] Position { get; set; }
        public IFitnessEvaluationStrategy FitnessEvaluationStrategy;
        private IConfiguration configuration;
        private static IConfiguration staticConfiguration;

        public Individual(IFitnessEvaluationStrategy fitnessEvaluationStrategy,
                          IConfiguration configuration,
                          int dimensions = 0)
        {
            Fitness = 0;
            this.configuration = configuration;
            this.InitialisePosition(dimensions);
            this.FitnessEvaluationStrategy = fitnessEvaluationStrategy;
            Individual.staticConfiguration = configuration;
        }

        private void InitialisePosition(int dimensions)
        {
            dimensions = dimensions != 0 ? dimensions : GetDefaultDimensions();

            Position = new double[dimensions];

            for(int i = 0; i < dimensions; i++)
            {
                Position[i] = RandomGenerator.GetInstance().NextDouble();
            }
        }

        private int GetDefaultDimensions()
        {
            return Int32.Parse(this.configuration.GetValue("Dimensions"));
        }

        internal void EvaluateFitness()
        {
            this.Fitness = this.FitnessEvaluationStrategy.GetFitnessForIndividual(this);
        }
        
        public static Individual operator +(Individual individual1, Individual individual2)
        {
            return new Individual(individual1.FitnessEvaluationStrategy, Individual.staticConfiguration)
            {
                Position = individual1.Position.Zip(individual2.Position, (x, y) => x + y).ToArray()
            };
        }

        public static Individual operator -(Individual individual1, Individual individual2)
        {
            return new Individual(individual1.FitnessEvaluationStrategy, Individual.staticConfiguration)
            {
                Position = individual1.Position.Zip(individual2.Position, (x, y) => x - y).ToArray()
            };
        }



    }
}
