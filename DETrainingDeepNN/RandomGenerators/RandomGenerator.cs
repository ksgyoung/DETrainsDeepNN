using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.RandomGenerators
{
    public class RandomGenerator
    {
        private static RandomGenerator instance;
        public static Random random = new Random();
                
        public static RandomGenerator GetInstance()
        {
            if(instance == null)
            {
                instance = new RandomGenerator();
            }

            return instance;
        }

        public double NextDouble(double minimum = 0, double maximum = 1)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        public int NextInt(int minimum = 0, int maximum = 2)
        {
            return random.Next(minimum, maximum);
        }

        public Random GetRandom()
        {
            return random;
        }

        public void SetRandom(Random newRandom)
        {
            random = newRandom;
        }
    }
}
