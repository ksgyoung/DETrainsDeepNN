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
    }
}
