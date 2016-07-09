using System;
using DETrainingDeepNN.Strategies.Pooling;
using NUnit.Framework;

namespace Test_DETrainingDeepNN.Strategies.Pooling
{
    [TestFixture]
    public class MaxPoolingTest
    {
        [Test]
        public void GivenAnArrayOfValues_WhenMaxPoolingIsApplied_ItShouldReturnTheLargestOfTheNumbers()
        {
            double[] dataToPool = { 1.0, 6.0, 3.0, 4.0 };

            MaxPoolingStrategy poolingStrategy = new MaxPoolingStrategy();

            Assert.AreEqual(6.0, poolingStrategy.GetPooledResult(dataToPool));
        }

        [Test]
        public void GivenAnArrayOfTheSameValue_WhenMaxPoolingIsApplied_ItShouldReturnTheValue()
        {
            double[] dataToPool = { 1.0, 1.0, 1.0, 1.0 };

            MaxPoolingStrategy poolingStrategy = new MaxPoolingStrategy();

            Assert.AreEqual(1.0, poolingStrategy.GetPooledResult(dataToPool));
        }
    }
}
