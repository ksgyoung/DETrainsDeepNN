using System;
using DETrainingDeepNN.Strategies.FitnessEvaluation;
using DETrainingDeepNN;
using NUnit.Framework;

namespace Test_DETrainingDeepNN.Strategies.FitnessEvaluation
{
    [TestFixture]
    public class RastriginFitnessEvaluationStrategyTest
    {
        [Test]
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
