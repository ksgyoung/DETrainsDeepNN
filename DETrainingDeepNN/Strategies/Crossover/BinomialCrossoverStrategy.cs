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

        public BinomialCrossoverStrategy()
        {
            this.probability = Double.Parse(ConfigurationManager.AppSettings["CrossoverProbability"]);
            this.random = RandomGenerator.GetInstance();
        }
        
        public BinomialCrossoverStrategy(double probability)
        {
            this.probability = probability;
            this.random = RandomGenerator.GetInstance();
        }

        public Individual Cross(Individual individual1, Individual individual2)
        {
            int length = individual1.Position.Length;

            double[] newPosition = new double[length];
            
            for (int index = 0; index < length; index++)
            {
                newPosition[index] = random.NextDouble() > probability 
                    ? individual1.Position[index] 
                    : individual2.Position[index];
            }

            return new Individual(individual1.FitnessEvaluationStrategy)
            {
                Position = newPosition
            };
        }
        
    }
}
