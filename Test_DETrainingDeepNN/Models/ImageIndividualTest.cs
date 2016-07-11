using DETrainingDeepNN;
using DETrainingDeepNN.Mappers;
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
            ImageIndividual imageIndividual = new ImageIndividual(null, null);
            Assert.That(imageIndividual, Is.InstanceOf(typeof(Individual)));
        }

        [Test]
        public void GivenAnIImageIndividual_WhenGettingTwoDimensionalRepresentation_ItShouldCallTheMapper()
        {
            Mock<ITwoDimensionalMapper> mock = new Mock<ITwoDimensionalMapper>();
            mock.Setup(x => x.GetTwoDimensionalRepresentation(It.IsAny<double[]>(), It.IsAny<int>()));

            ImageIndividual imageIndividual = new ImageIndividual(mock.Object, null);
            imageIndividual.GetTwoDimenionalRepresentation();

            mock.Verify(c => c.GetTwoDimensionalRepresentation(It.IsAny<double[]>(), It.IsAny<int>()), 
                Times.Exactly(1));
        }
    }
}
