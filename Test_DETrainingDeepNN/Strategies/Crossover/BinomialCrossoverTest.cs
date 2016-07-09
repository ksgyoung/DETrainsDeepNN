using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DETrainingDeepNN;
using DETrainingDeepNN.Strategies.Crossover;
using System.Linq;

namespace Test_DETrainingDeepNN.Strategies.Crossover
{
    [TestClass]
    public class BinomialCrossoverTest
    {
        //TODO also seems intermittent
        [TestMethod]
        public void GivenAnTwoIndividuals_WhenTheyAreCombined_ItShouldReturnAnIndividualDifferentFromTheInputs()
        {

            Individual individual1 = new Individual(null)
            {
                Position = new double[] { 1.0, 2.0, 3.0 }
            };

            Individual individual2 = new Individual(null)
            {
                Position = new double[] { 9.0, 11.0, 11.0 }
            };

            BinomialCrossoverStrategy crossoverStrategy = new BinomialCrossoverStrategy();

            Individual result = crossoverStrategy.Cross(individual1, individual2);

            Assert.IsFalse(individual1.Position.SequenceEqual(result.Position));
            Assert.IsFalse(individual2.Position.SequenceEqual(result.Position));
        }

        //TODO check out, intermittent test - something not mocked out properly
        [TestMethod]
        public void GivenAnTwoIndividuals_WhenTheyAreCombined_ItShouldReturnAnIndividualWithPartsFromEachIndividual()
        {

            Individual individual1 = new Individual(null)
            {
                Position = new double[] { 1.0, 2.0, 3.0 }
            };

            Individual individual2 = new Individual(null)
            {
                Position = new double[] { 9.0, 11.0, 11.0 }
            };

            BinomialCrossoverStrategy crossoverStrategy = new BinomialCrossoverStrategy();

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

        [TestMethod]
        public void GivenAprobabilityOfZero_WhenIndividualsAreCrossed_ItShouldReturnAnIndividualWithThePositionOfIndividualOne()
        {

            Individual individual1 = new Individual(null)
            {
                Position = new double[] { 1.0, 2.0, 3.0 }
            };

            Individual individual2 = new Individual(null)
            {
                Position = new double[] { 9.0, 11.0, 11.0 }
            };

            BinomialCrossoverStrategy crossoverStrategy = new BinomialCrossoverStrategy(0.0);

            Individual result = crossoverStrategy.Cross(individual1, individual2);

            Assert.IsTrue(individual1.Position.SequenceEqual(result.Position));
        }

        [TestMethod]
        public void GivenAprobabilityOfOne_WhenIndividualsAreCrossed_ItShouldReturnAnIndividualWithThePositionOfIndividualOne()
        {

            Individual individual1 = new Individual(null)
            {
                Position = new double[] { 1.0, 2.0, 3.0 }
            };

            Individual individual2 = new Individual(null)
            {
                Position = new double[] { 9.0, 11.0, 11.0 }
            };

            BinomialCrossoverStrategy crossoverStrategy = new BinomialCrossoverStrategy(1.0);

            Individual result = crossoverStrategy.Cross(individual1, individual2);

            Assert.IsTrue(individual2.Position.SequenceEqual(result.Position));
        }

    }
}
