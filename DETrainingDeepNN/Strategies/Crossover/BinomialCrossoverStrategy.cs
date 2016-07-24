using DETrainingDeepNN.ConfigurationSettings;
using DETrainingDeepNN.RandomGenerators;
using DETrainingDeepNN.Strategies.Crossover.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Strategies.Crossover
{
    public class BinomialCrossoverStrategy : IBinomialCrossoverStrategy
    {
        private double probability;
        private RandomGenerator random;
        private IConfiguration configuration;

        public BinomialCrossoverStrategy(IConfiguration configuration)
        {
            this.probability = Double.Parse(configuration.GetValue("CrossoverProbability"));
            this.random = RandomGenerator.GetInstance();
            this.configuration = configuration;
        }
        
        public BinomialCrossoverStrategy(IConfiguration configuration, double probability)
        {
            this.probability = probability;
            this.random = RandomGenerator.GetInstance();
            this.configuration = configuration;
        }

        public Individual Cross(Individual individual1, Individual individual2)
        {
            int length = individual1.Position.Length;

            double[] newPosition = new double[length];
            
            for (int index = 0; index < length; index++)
            {
                double test = random.NextDouble();
                newPosition[index] = test > probability 
                    ? individual1.Position[index] 
                    : individual2.Position[index];
            }

            return new Individual(individual1.FitnessEvaluationStrategy, configuration)
            {
                Position = newPosition
            };
        }
        
    }
}
