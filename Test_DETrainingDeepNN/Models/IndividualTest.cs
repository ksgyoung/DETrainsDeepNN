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

        [TestMethod]
        public void GivenTwoIndividuals_WhenTheyAreAddedUsingThePlusOperator_ItShouldResultInANewIndividualWithTheSumOfEachDimension()
        {
            Individual individual1 = new Individual
            {
                Position = new double[] { 1.0, 2.0, 3.0 }
            };

            Individual individual2 = new Individual
            {
                Position = new double[] { 4.0, 5.0, 6.0 }
            };

            Individual result = individual1 + individual2;

            Assert.AreEqual(result.Position[0], 5.0);
            Assert.AreEqual(result.Position[1], 7.0);
            Assert.AreEqual(result.Position[2], 9.0);
        }

        [TestMethod]
        public void GivenTwoIndividuals_WhenTheyAreSubstracterUsingTheMinusOperator_ItShouldResultInANewIndividualWithTheDifferenceOfEachDimension()
        {
            Individual individual1 = new Individual
            {
                Position = new double[] { 4.0, 2.0, 6.0 }
            };

            Individual individual2 = new Individual
            {
                Position = new double[] { 1.0, 2.0, 4.0 }
            };
            
            Individual result = individual1 - individual2;

            Assert.AreEqual(result.Position[0], 3.0);
            Assert.AreEqual(result.Position[1], 0.0);
            Assert.AreEqual(result.Position[2], 2.0);
        }
    }
}
