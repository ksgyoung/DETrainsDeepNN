using System;
using DETrainingDeepNN;
using System.Collections.Generic;
using DETrainingDeepNN.Strategies.Mutation;
using NUnit.Framework;

namespace Test_DETrainingDeepNN.Strategies.Mutation
{
    [TestFixture]
    public class TriaIndividualGeneratorTest
    {
        [Test]
        public void GivenThreeIndividuals_WhenTheTrialIndividualIsGenerated_ItShouldReturnTheTargetIndividualAddedToTheScaledDifferenceOfTheOtherIndividuals()
        {
            Individual target = new Individual(null)
            {
                Position = new double[]{ 1.0, 2.0, 3.0}
            };

            Individual individual1 = new Individual(null)
            {
                Position = new double[] { 9.0, 11.0, 11.0 }
            };

            Individual individual2 = new Individual(null)
            {
                Position = new double[] { 6.0, 7.0, 8.0 }
            };
            
            TrialIndividualMutationStrategy generator = new TrialIndividualMutationStrategy();
            Individual result = generator.GetTrialVector(target, new List<Individual>() { individual1, individual2 });

            Assert.AreEqual(result.Position[0], 2.5);
            Assert.AreEqual(result.Position[1], 4.0);
            Assert.AreEqual(result.Position[2], 4.5);
        }

        [Test]
        public void GivenAnIndividual_WhenTheIndividualIsScaled_ItShouldReturnAnIndividualWithEachDimensionScaled()
        {
            Individual individual = new Individual(null)
            {
                Position = new double[] { 1.0, 2.0, 4.0 }
            };
            
            TrialIndividualMutationStrategy generator = new TrialIndividualMutationStrategy();
            Individual result = generator.Scale(individual, 0.5);

            Assert.AreEqual(result.Position[0], 0.5);
            Assert.AreEqual(result.Position[1], 1.0);
            Assert.AreEqual(result.Position[2], 2.0);
        }

        [Test]
        public void GivenListOfIndividuals_WhenTheDifference_ItShouldReturnAnIndividualWithEachDimensionBeingTheDifferenceBetweenTheSameDimensionInAllTheIndividualsInTheList()
        {
            Individual individual = new Individual(null)
            {
                Position = new double[] { 1.0, 2.0, 4.0 }
            };

            Individual individual2 = new Individual(null)
            {
                Position = new double[] { 3.0, 3.0, 3.0 }
            };

            Individual individual3 = new Individual(null)
            {
                Position = new double[] { 4.0, 5.0, 6.0 }
            };

            TrialIndividualMutationStrategy generator = new TrialIndividualMutationStrategy();
            Individual result = generator.GetDifference(new List<Individual>() {
                individual, individual2, individual3
            });

            Assert.AreEqual(result.Position[0], -6);
            Assert.AreEqual(result.Position[1], -6);
            Assert.AreEqual(result.Position[2], -5);
        }
    }
}
