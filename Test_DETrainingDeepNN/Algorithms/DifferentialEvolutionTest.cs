using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DETrainingDeepNN.Algorithms;
using DETrainingDeepNN;
using System.Collections.Generic;
using Moq;
using DETrainingDeepNN.Strategies.Selection.Interfaces;
using DETrainingDeepNN.Strategies.FitnessEvaluation.Interfaces;

namespace Test_DETrainingDeepNN.Algorithms
{
    [TestClass]
    public class DifferentialEvolutionTest
    {
        public Mock ISelection { get; private set; }

        [TestMethod]
        public void GivenADifferentialEvolutionAlgorithm_WhenThePopulationIsInitialisedWithAPopulationSizeOfTen_ItShouldReturnAPopulationOfTenIndividuals()
        {
            DifferentialEvolution differentialEvolution = new DifferentialEvolution(null, null, null, null);

            List<Individual> population = differentialEvolution.InitialisePopulation(10);

            Assert.AreEqual(10, population.Count);
        }

        [TestMethod]
        public void GivenAPopulationOfThreeAndAnInvalidIndividual_WhenTheGettingTheDifferenceIndividual_ItShouldCallTheSelectionStrategyWithAPopulationExcludingTheInvalidIndividual()
        {
            Individual individual1 = new Individual(null)
            {
                Position = new double[] { 1.0, 2.0, 3.0 }
            };

            Individual individual2 = new Individual(null)
            {
                Position = new double[] { 2.0, 3.0, 4.0 }
            };

            Individual individual3 = new Individual(null)
            {
                Position = new double[] { 5.0, 6.0, 7.0 }
            };

            List<Individual> population = new List<Individual>
            {
                individual1, individual2, individual3
            };

            List<Individual> invalidIndividuals = new List<Individual>
            {
                individual2
            };

            List<Individual> resultingPopulation = new List<Individual>();

            Mock<ISelectionStrategy> mock = new Mock<ISelectionStrategy>();
            mock.Setup(c => c.Select(It.IsAny<List<Individual>>()))
            .Callback((List<Individual> validPopulation) => resultingPopulation = validPopulation);

            DifferentialEvolution differentialEvolution = new DifferentialEvolution(null, null, null, mock.Object);
            
            differentialEvolution.SelectDifferenceIndividual(population, invalidIndividuals);

            Assert.AreEqual(2, resultingPopulation.Count);
            Assert.IsFalse(resultingPopulation.Contains(individual2));
            Assert.IsTrue(resultingPopulation.Contains(individual1));
            Assert.IsTrue(resultingPopulation.Contains(individual3));
        }

        [TestMethod]
        public void GivenAPopulationOfThree_WhenANewPopulationIsRetrieved_ItShouldCallTheEvaluateMethodThreeTimes()
        {
            Mock<IFitnessEvaluationStrategy> mock = new Mock<IFitnessEvaluationStrategy>();
            IFitnessEvaluationStrategy fitnessEvaluationStrategy = mock.Object;
            
            DifferentialEvolution differentialEvolution = new DifferentialEvolution(null, null, null, null);
            differentialEvolution.population = new List<Individual>
            {
                new Individual(fitnessEvaluationStrategy),
                new Individual(fitnessEvaluationStrategy),
                new Individual(fitnessEvaluationStrategy)
            };

            differentialEvolution.GetNewPopulation();

            mock.Verify(c => c.GetFitnessForIndividual(It.IsAny<Individual>()), Times.Exactly(3));
        }

        [TestMethod]
        public void GivenAPopulationOfOne_WhenANewPopulationIsRetrieved_ItShouldCallTheEvaluateMethodWithTheIndividualAsAParameter()
        {
            Mock<IFitnessEvaluationStrategy> mock = new Mock<IFitnessEvaluationStrategy>();
            IFitnessEvaluationStrategy fitnessEvaluationStrategy = mock.Object;

            Individual individual = new Individual(fitnessEvaluationStrategy);

            DifferentialEvolution differentialEvolution = new DifferentialEvolution(null, null, null, null);
            differentialEvolution.population = new List<Individual>
            {
                individual
            };

            differentialEvolution.GetNewPopulation();

            mock.Verify(c => c.GetFitnessForIndividual(It.Is<Individual>(p => p == individual)));
        }

    }
}
