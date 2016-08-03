using System;
using DETrainingDeepNN.Calculators;
using Moq;
using DETrainingDeepNN.Models;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using DETrainingDeepNN.ConfigurationSettings;

namespace Test_DETrainingDeepNN.Models
{
    [TestFixture]
    public class ImageInputTest
    {
        [Test]
        public void GivenAnIImageInputIsInitialised_WhenThePositionIsRetrieved_ItShouldUseTheMapperToReturnAnArrayRepresentation()
        {
            Mock<ITwoDimensionalMapper> mapperMock = new Mock<ITwoDimensionalMapper>();

            ImageInput imageInput = new ImageInput(mapperMock.Object, new Configuration());

            double[] result = imageInput.GetNumericRepresentation();

            mapperMock.Verify(c => c.GetArrayRepresentation(It.IsAny<double[,]>()), Times.Exactly(1));
        }

        [Test]
        public void GivenAnIImageInput_WhenTheImageInputNumericRepresentationIsSet_ItShouldReturnTheSetDataWhenRetrieved()
        {
            ImageInput imageInput = new ImageInput(new TwoDimensionalMapper(), new Configuration());

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

        [Test]
        public void GivenAnIImageInput_WhenTheImageInputNumericRepresentationIsSet_ItShouldSetTheTotalRows()
        {
            ImageInput imageInput = new ImageInput(new TwoDimensionalMapper(), new Configuration());

            double[,] numericRepresentation = new double[2, 2];
            numericRepresentation[0, 0] = 1;
            numericRepresentation[0, 1] = 2;
            numericRepresentation[1, 0] = 3;
            numericRepresentation[1, 1] = 4;

            imageInput.SetNumericRepresentation(numericRepresentation);
            
            Assert.AreEqual(2, imageInput.TotalRows);
        }

        [Test]
        public void GivenAnIImageInput_WhenTheImageInputNumericRepresentationIsSet_ItShouldSetTheTotalColumns()
        {
            ImageInput imageInput = new ImageInput(new TwoDimensionalMapper(), new Configuration());

            double[,] numericRepresentation = new double[3, 2];
            numericRepresentation[0, 0] = 1;
            numericRepresentation[0, 1] = 2;
            numericRepresentation[1, 0] = 3;
            numericRepresentation[1, 1] = 4;
            numericRepresentation[2, 0] = 5;
            numericRepresentation[2, 1] = 6;

            imageInput.SetNumericRepresentation(numericRepresentation);

            Assert.AreEqual(3, imageInput.TotalColumns);
        }

        [Test]
        public void GivenAnIImageInput_WhenTheImageInputIsSplit_ItShouldReturnAListOfSmallerImageInputs()
        {
            Mock<IConfiguration> config = new Mock<IConfiguration>();
            config.Setup(x => x.GetValue(It.IsAny<string>())).Returns("2");

            ImageInput imageInput = new ImageInput(new TwoDimensionalMapper(), config.Object);

            double[,] matrix = new double[4, 4];
            matrix[0, 0] = 0;
            matrix[0, 1] = 1;
            matrix[0, 2] = 2;
            matrix[0, 3] = 3;
            matrix[1, 0] = 4;
            matrix[1, 1] = 5;
            matrix[1, 2] = 6;
            matrix[1, 3] = 7;
            matrix[2, 0] = 8;
            matrix[2, 1] = 9;
            matrix[2, 2] = 10;
            matrix[2, 3] = 11;
            matrix[3, 0] = 12;
            matrix[3, 1] = 13;
            matrix[3, 2] = 14;
            matrix[3, 3] = 15;

            imageInput.SetNumericRepresentation(matrix);

            List<double[]> result = imageInput.GetSplitSubsections();

            Assert.IsTrue(result[0].SequenceEqual(new double[] { 0, 1, 4, 5 }));
            Assert.IsTrue(result[1].SequenceEqual(new double[] { 2, 3, 6, 7}));
            Assert.IsTrue(result[2].SequenceEqual(new double[] { 8, 9, 12, 13 }));
            Assert.IsTrue(result[3].SequenceEqual(new double[] { 10, 11, 14, 15 }));
        }
    }
}
