using DETrainingDeepNN.Calculators;
using NUnit.Framework;
using System;

namespace Test_DETrainingDeepNN.Mappers
{
    [TestFixture]
    public class IndexCalculatorTest
    {
        [Test]
        public void GivenAWidthOfFour_WhenTheIndexIsRetrieved_ItShouldReturnTheIndexOfTheArray()
        {
            TwoDimensionalIndexCalculator indexCalculator = new TwoDimensionalIndexCalculator();

            Assert.AreEqual(5, indexCalculator.GetIndex(4, 1, 1));
        }

        [Test]
        public void GivenAWidthOfFive_WhenTheIndexIsRetrieved_ItShouldReturnTheIndexOfTheArray()
        {
            TwoDimensionalIndexCalculator indexCalculator = new TwoDimensionalIndexCalculator();

            Assert.AreEqual(6, indexCalculator.GetIndex(5, 1, 1));
        }

        [Test]
        public void GivenAWidthOfSix_WhenTheIndexIsRetrieved_ItShouldReturnTheIndexOfTheArray()
        {
            TwoDimensionalIndexCalculator indexCalculator = new TwoDimensionalIndexCalculator();

            Assert.AreEqual(11, indexCalculator.GetIndex(6, 5, 1));
        }

    }
}
