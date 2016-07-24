using System;
using System.Text;
using System.Collections.Generic;
using DETrainingDeepNN;
using DETrainingDeepNN.Strategies.Crossover;
using System.Linq;
using Moq;
using DETrainingDeepNN.RandomGenerators;
using NUnit.Framework;
using DETrainingDeepNN.ConfigurationSettings;

namespace Test_DETrainingDeepNN.Strategies.Crossover
{
    [TestFixture]
    public class BinomialCrossoverTest
    {
        private void MockRandom()
        {
            Mock<Random> mock = new Mock<Random>();
            mock.SetupSequence(x => x.NextDouble()).Returns(0.3)
                                                   .Returns(0.7)
                                                   .Returns(0.8);

            RandomGenerator.GetInstance().SetRandom(mock.Object);
        }

        [Test]
        public void GivenAnTwoIndividuals_WhenTheyAreCombined_ItShouldReturnAnIndividualDifferentFromTheInputs()
        {

            Individual individual1 = new Individual(null, new Configuration())
            {
                Position = new double[] { 1.0, 2.0, 3.0 }
            };

            Individual individual2 = new Individual(null, new Configuration())
            {
                Position = new double[] { 9.0, 11.0, 11.0 }
            };

            MockRandom();

            BinomialCrossoverStrategy crossoverStrategy = new BinomialCrossoverStrategy(new Configuration());

            Individual result = crossoverStrategy.Cross(individual1, individual2);

            Assert.IsFalse(individual1.Position.SequenceEqual(result.Position));
            Assert.IsFalse(individual2.Position.SequenceEqual(result.Position));
        }
        
        [Test]
        public void GivenAnTwoIndividuals_WhenTheyAreCombined_ItShouldReturnAnIndividualWithPartsFromEachIndividual()
        {

            Individual individual1 = new Individual(null, new Configuration())
            {
                Position = new double[] { 1.0, 2.0, 3.0 }
            };

            Individual individual2 = new Individual(null, new Configuration())
            {
                Position = new double[] { 9.0, 11.0, 11.0 }
            };

            MockRandom();

            BinomialCrossoverStrategy crossoverStrategy = new BinomialCrossoverStrategy(new Configuration());

            Individual result = crossoverStrategy.Cross(individual1, individual2);

            int totalFromIndividual1 = 0;
            int totalFromIndividual2 = 0;

            for (int i = 0; i < individual1.Position.Length; i++)
            {
                if(result.Position[i] == individual1.Position[i])
                {
                    totalFromIndividual1++;
                } else
                {
                    totalFromIndividual2++;
                }
            }

            Assert.IsTrue(totalFromIndividual1 > 0);
            Assert.IsTrue(totalFromIndividual2 > 0);
        }

        [Test]
        public void GivenAprobabilityOfZero_WhenIndividualsAreCrossed_ItShouldReturnAnIndividualWithThePositionOfIndividualOne()
        {

            Individual individual1 = new Individual(null, new Configuration())
            {
                Position = new double[] { 1.0, 2.0, 3.0 }
            };

            Individual individual2 = new Individual(null, new Configuration())
            {
                Position = new double[] { 9.0, 11.0, 11.0 }
            };

            MockRandom();

            BinomialCrossoverStrategy crossoverStrategy = new BinomialCrossoverStrategy(new Configuration(), 0.0);

            Individual result = crossoverStrategy.Cross(individual1, individual2);

            Assert.IsTrue(individual1.Position.SequenceEqual(result.Position));
        }

        [Test]
        public void GivenAprobabilityOfOne_WhenIndividualsAreCrossed_ItShouldReturnAnIndividualWithThePositionOfIndividualOne()
        {

            Individual individual1 = new Individual(null, new Configuration())
            {
                Position = new double[] { 1.0, 2.0, 3.0 }
            };

            Individual individual2 = new Individual(null, new Configuration())
            {
                Position = new double[] { 9.0, 11.0, 11.0 }
            };

            MockRandom();

            BinomialCrossoverStrategy crossoverStrategy = new BinomialCrossoverStrategy(new Configuration(), 1.0);

            Individual result = crossoverStrategy.Cross(individual1, individual2);

            Assert.IsTrue(individual2.Position.SequenceEqual(result.Position));
        }

    }
}
