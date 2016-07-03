using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DETrainingDeepNN.Strategies.Pooling;

namespace Test_DETrainingDeepNN.Strategies.Pooling
{
    [TestClass]
    public class MaxPoolingTest
    {
        [TestMethod]
        public void GivenAnArrayOfValues_WhenMaxPoolingIsApplied_ItShouldReturnTheLargestOfTheNumbers()
        {
            double[] dataToPool = { 1.0, 6.0, 3.0, 4.0 };

            MaxPoolingStrategy poolingStrategy = new MaxPoolingStrategy();

            Assert.AreEqual(6.0, poolingStrategy.GetPooledResult(dataToPool));
        }

        [TestMethod]
        public void GivenAnArrayOfTheSameValue_WhenMaxPoolingIsApplied_ItShouldReturnTheValue()
        {
            double[] dataToPool = { 1.0, 1.0, 1.0, 1.0 };

            MaxPoolingStrategy poolingStrategy = new MaxPoolingStrategy();

            Assert.AreEqual(1.0, poolingStrategy.GetPooledResult(dataToPool));
        }
    }
}
