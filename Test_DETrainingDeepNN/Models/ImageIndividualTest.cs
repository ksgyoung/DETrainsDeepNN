using DETrainingDeepNN;
using DETrainingDeepNN.ConfigurationSettings;
using DETrainingDeepNN.Calculators;
using DETrainingDeepNN.Models;
using Moq;
using NUnit.Framework;
using System;

namespace Test_DETrainingDeepNN.Models
{
    [TestFixture]
    public class ImageIndividualTest
    {
        [Test]
        public void GivenAnIImageIndividual_WhenInitialised_ItInheritFromAnIndividual()
        {
            ImageIndividual imageIndividual = new ImageIndividual(null, null, new Configuration());
            Assert.That(imageIndividual, Is.InstanceOf(typeof(Individual)));
        }

        [Test]
        public void GivenAnIImageIndividual_WhenGettingTwoDimensionalRepresentation_ItShouldCallTheMapper()
        {
            Mock<ITwoDimensionalMapper> mock = new Mock<ITwoDimensionalMapper>();
            mock.Setup(x => x.GetTwoDimensionalRepresentation(It.IsAny<double[]>(), It.IsAny<int>()));

            ImageIndividual imageIndividual = new ImageIndividual(mock.Object, null, new Configuration());
            imageIndividual.GetTwoDimenionalRepresentation();

            mock.Verify(c => c.GetTwoDimensionalRepresentation(It.IsAny<double[]>(), It.IsAny<int>()), 
                Times.Exactly(1));
        }
    }
}
