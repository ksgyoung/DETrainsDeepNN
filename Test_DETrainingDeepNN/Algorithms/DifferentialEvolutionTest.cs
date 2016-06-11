using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DETrainingDeepNN.Algorithms;
using DETrainingDeepNN;
using System.Collections.Generic;

namespace Test_DETrainingDeepNN.Algorithms
{
    [TestClass]
    public class DifferentialEvolutionTest
    {
        [TestMethod]
        public void GivenADifferentialEvolutionAlgorithm_WhenThePopulationIsInitialisedWithAPopulationSizeOfTen_ItShouldReturnAPopulationOfTenIndividuals()
        {
            DifferentialEvolution differentialEvolution = new DifferentialEvolution(null, null, null);

            List<Individual> population = differentialEvolution.InitialisePopulation(10);

            Assert.AreEqual(10, population.Count);
        }
    }
}
