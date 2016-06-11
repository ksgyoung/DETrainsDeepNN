using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DETrainingDeepNN.Strategies.FitnessEvaluation.Interfaces;

namespace DETrainingDeepNN
{
    public class Individual
    {
        public double Fitness { get; set; }
        public double[] Position { get; set; }
        public IFitnessEvaluationStrategy FitnessEvaluationStrategy;

        public Individual(IFitnessEvaluationStrategy fitnessEvaluationStrategy, int dimensions = 0)
        {
            Fitness = 0;
            this.InitialisePosition(dimensions);
            this.FitnessEvaluationStrategy = fitnessEvaluationStrategy;
        }

        private void InitialisePosition(int dimensions)
        {
            dimensions = dimensions != 0 ? dimensions : GetDefaultDimensions();
            Random random = new Random();

            Position = new double[dimensions];

            for(int i = 0; i < dimensions; i++)
            {
                Position[i] = random.NextDouble() * 80;
            }
        }

        private int GetDefaultDimensions()
        {
            return Int32.Parse(ConfigurationManager.AppSettings["Dimensions"]);
        }

        internal void EvaluateFitness()
        {
            this.Fitness = this.FitnessEvaluationStrategy.GetFitnessForIndividual(this);
        }
        
        public static Individual operator +(Individual individual1, Individual individual2)
        {
            return new Individual(individual1.FitnessEvaluationStrategy)
            {
                Position = individual1.Position.Zip(individual2.Position, (x, y) => x + y).ToArray()
            };
        }

        public static Individual operator -(Individual individual1, Individual individual2)
        {
            return new Individual(individual1.FitnessEvaluationStrategy)
            {
                Position = individual1.Position.Zip(individual2.Position, (x, y) => x - y).ToArray()
            };
        }



    }
}
