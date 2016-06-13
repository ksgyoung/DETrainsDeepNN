using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DETrainingDeepNN.RandomGenerators;

namespace Test_DETrainingDeepNN.Strategies.RandomGenerators
{
    [TestClass]
    public class RandomGeneratorTest
    {
        [TestMethod]
        public void GivenARandomGenerator_WhenAnInstanceIsRetrievedTheFirstTime_ItShouldNotBeNull()
        {
            RandomGenerator instance = RandomGenerator.GetInstance();

            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void GivenARandomGenerator_WhenAnInstanceIsRetrievedTheSecondTime_ItShouldReturnTheSameInstanceAsTheFirstTime()
        {
            RandomGenerator instance = RandomGenerator.GetInstance();
            RandomGenerator secondInstance = RandomGenerator.GetInstance();

            Assert.AreEqual(instance, secondInstance);
        }

        [TestMethod]
        public void GivenARandomGenerator_WhenANextDoubleIsRequestedWithoutParameters_ItShouldReturnADoubleBetweenZeroAndOne()
        {
            RandomGenerator.GetInstance().SetRandom(new Random());
            double random = RandomGenerator.GetInstance().NextDouble();

            Assert.IsTrue(random > 0 && random < 1);
        }

        [TestMethod]
        public void GivenARandomGenerator_WhenANextDoubleIsRequestedWithoutParameters_ItShouldReturnADoubleBetweenTheGivenRange()
        {
            RandomGenerator.GetInstance().SetRandom(new Random());
            double random = RandomGenerator.GetInstance().NextDouble(2, 3);

            Assert.IsTrue(random > 2 && random < 3);
        }

        [TestMethod]
        public void GivenARandomGenerator_WhenANextIntIsRequestedWithoutParameters_ItShouldReturnAnIntBetweenZeroAndTwo()
        {
            RandomGenerator.GetInstance().SetRandom(new Random());
            double random = RandomGenerator.GetInstance().NextInt();

            Assert.IsTrue(random >= 0 && random <= 2);
        }

        [TestMethod]
        public void GivenARandomGenerator_WhenANextIntIsRequestedWithoutParameters_ItShouldReturnAnIntBetweenTheGivenRange()
        {
            RandomGenerator.GetInstance().SetRandom(new Random());
            double random = RandomGenerator.GetInstance().NextDouble(5, 8);

            Assert.IsTrue(random >= 5 && random <= 8);
        }
    }
}
