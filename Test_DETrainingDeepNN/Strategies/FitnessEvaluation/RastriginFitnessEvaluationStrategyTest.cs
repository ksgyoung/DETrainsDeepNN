using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DETrainingDeepNN.Strategies.FitnessEvaluation;
using DETrainingDeepNN;

namespace Test_DETrainingDeepNN.Strategies.FitnessEvaluation
{
    [TestClass]
    public class RastriginFitnessEvaluationStrategyTest
    {
        [TestMethod]
        public void GivenAnIndividual_WhenTheFitnessIsCalculatedUsingTheRastriginFunction_ItShouldReturnTheExpectedValue()
        {
            RastriginFitnessEvaluationStrategy rastriginCalculator = new RastriginFitnessEvaluationStrategy();

            Individual individual = new Individual(null)
            {
                Position = new double[] { 1.0, 2.0, 3.0 }
            };

            double value = rastriginCalculator.GetFitnessForIndividual(individual);

            Assert.AreEqual(14, value);
        }
    }
}
