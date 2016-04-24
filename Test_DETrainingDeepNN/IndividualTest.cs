using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DETrainingDeepNN;
using System.Linq;

namespace Test_DETrainingDeepNN
{
    [TestClass]
    public class IndividualTest
    {
        [TestMethod]
        public void GivenAnIndividualIsInitialised_WhenTheFitnessIsRetrieved_ItShouldBeZero()
        {
            Individual individual = new Individual(10);
            Assert.AreEqual(individual.Fitness, 0);
        }

        [TestMethod]
        public void GivenAnIndividualIsInitialised_WhenThePositionIsRetrieved_ItShouldNotAllCOnsistOfZeros()
        {
            Individual individual = new Individual(10);
            
            double sumOfPositions = individual.Position.Sum();

            Assert.AreNotEqual(sumOfPositions, 0.0);
        }
    }
}
