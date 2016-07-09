using System;
using DETrainingDeepNN.Mappers;
using Moq;
using DETrainingDeepNN.Models;
using System.Linq;
using NUnit.Framework;

namespace Test_DETrainingDeepNN.Models
{
    [TestFixture]
    public class ImageInputTest
    {
        [Test]
        public void GivenAnIImageInputIsInitialised_WhenThePositionIsRetrieved_ItShouldUseTheMapperToReturnAnArrayRepresentation()
        {
            Mock<ITwoDimensionalMapper> mapperMock = new Mock<ITwoDimensionalMapper>();

            ImageInput imageInput = new ImageInput(mapperMock.Object);

            double[] result = imageInput.GetNumericRepresentation();

            mapperMock.Verify(c => c.GetArrayRepresentation(It.IsAny<double[,]>()), Times.Exactly(1));
        }

        [Test]
        public void GivenAnIImageInput_WhenTheImageInputNumericRepresentationIsSet_ItShouldReturnTheSetDataWhenRetrieved()
        {
            ImageInput imageInput = new ImageInput(new TwoDimensionalMapper());

            double[,] numericRepresentation = new double[2, 2];
            numericRepresentation[0, 0] = 1;
            numericRepresentation[0, 1] = 2;
            numericRepresentation[1, 0] = 3;
            numericRepresentation[1, 1] = 4;

            imageInput.SetNumericRepresentation(numericRepresentation);

            double[] result = imageInput.GetNumericRepresentation();
            double[] expected = { 1, 2, 3, 4 };

            Assert.IsTrue(result.SequenceEqual(expected));
        }
        
    }
}
