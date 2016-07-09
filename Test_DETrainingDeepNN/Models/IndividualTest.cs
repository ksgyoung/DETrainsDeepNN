using System;
using DETrainingDeepNN;
using System.Linq;
using Moq;
using DETrainingDeepNN.Strategies.FitnessEvaluation.Interfaces;
using NUnit.Framework;

namespace Test_DETrainingDeepNN
{
    [TestFixture]
    public class IndividualTest
    {
        [Test]
        public void GivenAnIndividualIsInitialised_WhenTheFitnessIsRetrieved_ItShouldBeZero()
        {
            Individual individual = new Individual(null, 10);
            Assert.AreEqual(individual.Fitness, 0);
        }

        [Test]
        public void GivenAnIndividualIsInitialised_WhenThePositionIsRetrieved_ItShouldNotAllConsistOfZeros()
        {
            Individual individual = new Individual(null, 10);
            
            double sumOfPositions = individual.Position.Sum();

            Assert.AreNotEqual(sumOfPositions, 0.0);
        }

        [Test]
        public void GivenTwoIndividuals_WhenTheyAreAddedUsingThePlusOperator_ItShouldResultInANewIndividualWithTheSumOfEachDimension()
        {
            Individual individual1 = new Individual(null)
            {
                Position = new double[] { 1.0, 2.0, 3.0 }
            };

            Individual individual2 = new Individual(null)
            {
                Position = new double[] { 4.0, 5.0, 6.0 }
            };

            Individual result = individual1 + individual2;

            Assert.AreEqual(result.Position[0], 5.0);
            Assert.AreEqual(result.Position[1], 7.0);
            Assert.AreEqual(result.Position[2], 9.0);
        }

        [Test]
        public void GivenTwoIndividuals_WhenTheyAreSubstracterUsingTheMinusOperator_ItShouldResultInANewIndividualWithTheDifferenceOfEachDimension()
        {
            Individual individual1 = new Individual(null)
            {
                Position = new double[] { 4.0, 2.0, 6.0 }
            };

            Individual individual2 = new Individual(null)
            {
                Position = new double[] { 1.0, 2.0, 4.0 }
            };
            
            Individual result = individual1 - individual2;

            Assert.AreEqual(result.Position[0], 3.0);
            Assert.AreEqual(result.Position[1], 0.0);
            Assert.AreEqual(result.Position[2], 2.0);
        }

        [Test]
        public void GivenAnIndividualIsInitialised_WhenTheFitnessIsEvaluated_ItShouldReturnTheValueCalculatedByTheFitnessEvaluationStrategy()
        {
            Mock<IFitnessEvaluationStrategy> mock = new Mock<IFitnessEvaluationStrategy>();
            mock.Setup(x => x.GetFitnessForIndividual(It.IsAny<Individual>())).Returns(27);

            IFitnessEvaluationStrategy fitnessEvaluation = mock.Object;

            Individual individual = new Individual(fitnessEvaluation)
            {
                Position = new double[] { 1.0, 2.0, 3.0 }
            };

            individual.EvaluateFitness();

            Assert.AreEqual(27, individual.Fitness);
        }
    }
}
