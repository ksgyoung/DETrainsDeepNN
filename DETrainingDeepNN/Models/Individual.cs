using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DETrainingDeepNN
{
    public class Individual
    {
        public double Fitness { get; set; }
        public double[] Position { get; set; }

        public Individual(int dimensions = 0)
        {
            Fitness = 0;
            this.InitialisePosition(dimensions);
        }

        private void InitialisePosition(int dimensions)
        {
            dimensions = dimensions != 0 ? dimensions : GetDefaultDimensions();
            Random random = new Random();

            Position = new double[dimensions];

            for(int i = 0; i < dimensions; i++)
            {
                Position[i] = random.NextDouble();
            }
        }

        private int GetDefaultDimensions()
        {
            return Int32.Parse(ConfigurationManager.AppSettings["Dimensions"]);
        }

        public static Individual operator +(Individual individual1, Individual individual2)
        {
            return new Individual {
                Position = individual1.Position.Zip(individual2.Position, (x, y) => x + y).ToArray()
            };
        }

        public static Individual operator -(Individual individual1, Individual individual2)
        {
            return new Individual
            {
                Position = individual1.Position.Zip(individual2.Position, (x, y) => x - y).ToArray()
            };
        }

    }
}
