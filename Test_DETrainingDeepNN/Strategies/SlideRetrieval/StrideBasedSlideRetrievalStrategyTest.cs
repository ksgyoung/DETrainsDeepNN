using DETrainingDeepNN.ConfigurationSettings;
using DETrainingDeepNN.Calculators;
using DETrainingDeepNN.Models;
using DETrainingDeepNN.Strategies.ConvolutionStrategies;
using DETrainingDeepNN.Strategies.NeuronActivation;
using DETrainingDeepNN.Strategies.SlideRetrieval;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_DETrainingDeepNN.Strategies.Sliding
{
    [TestFixture]
    class StrideBasedSlideRetrievalStrategyTest
    {
       
        [Test]
        public void GivenAFourByFourInputAndATwoByTwoFilter_WhenTheFilterIsSlid_ItShouldReturnAMappedRepresentationOfTheNextSection()
        {
            StrideBasedSlideRetrievalStrategy strategy = new StrideBasedSlideRetrievalStrategy();

            Position position = new Position(0, 0, 1);
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

            ImageInput input = new ImageInput(new TwoDimensionalMapper(), new Configuration());
            input.SetNumericRepresentation(matrix);

            Slider slider = new Slider(position, 2, 2, 4, true);

            double[] slide = strategy.GetSlide(input, slider);
            double[] expected = { 0, 1, 4, 5 };

            Assert.IsTrue(Enumerable.SequenceEqual(expected, slide));
        }

        [Test]
        public void GivenAFourByFourInputAndAThreeByThreeFilter_WhenTheFilterIsSlid_ItShouldReturnAMappedRepresentationOfTheNextSection()
        {
            Mock<IConfiguration> configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x.GetValue(It.IsAny<String>())).Returns("3");

            StrideBasedSlideRetrievalStrategy strategy = new StrideBasedSlideRetrievalStrategy();

            Position position = new Position(0, 0, 1);

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

            ImageInput input = new ImageInput(new TwoDimensionalMapper(), new Configuration());
            input.SetNumericRepresentation(matrix);
            Slider slider = new Slider(position, 3, 3, 4, true);

            double[] slide = strategy.GetSlide(input, slider);

            double[] expected = { 0, 1, 2, 4, 5, 6, 8, 9, 10 };

            Assert.IsTrue(Enumerable.SequenceEqual(expected, slide));
        }

        [Test]
        public void GivenAThreeByThreeInputAndATwoByTwoFilter_WhenTheFilterIsSlid_ItShouldReturnAMappedRepresentationOfTheNextSection()
        {
            StrideBasedSlideRetrievalStrategy strategy = new StrideBasedSlideRetrievalStrategy();

            Position position = new Position(0, 0, 1);

            double[,] matrix = new double[4, 4];
            matrix[0, 0] = 0;
            matrix[0, 1] = 1;
            matrix[0, 2] = 2;
            matrix[1, 0] = 3;
            matrix[1, 1] = 4;
            matrix[1, 2] = 5;
            matrix[2, 0] = 6;
            matrix[2, 1] = 7;
            matrix[2, 2] = 8;

            ImageInput input = new ImageInput(new TwoDimensionalMapper(), new Configuration());
            input.SetNumericRepresentation(matrix);

            Slider slider = new Slider(position, 2, 2, 4, true);

            double[] slide = strategy.GetSlide(input, slider);
            double[] expected = { 0, 1, 3, 4 };

            Assert.IsTrue(Enumerable.SequenceEqual(expected, slide));
        }

        [Test]
        public void GivenAFourByFourInputAndATwoByTwoFilter_WhenTheFilterIsSlidFromTheEnd_ItShouldReturnARepresentationOfTheLeftestSectionOneLevelDown()
        {
            StrideBasedSlideRetrievalStrategy strategy = new StrideBasedSlideRetrievalStrategy();

            Position position = new Position(2, 0, 1);

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

            ImageInput input = new ImageInput(new TwoDimensionalMapper(), new Configuration());
            input.SetNumericRepresentation(matrix);

            Slider slider = new Slider(position, 2, 2, 4, true);

            double[] slide = strategy.GetSlide(input, slider);
            double[] expected = { 2, 3, 6, 7 };

            Assert.IsTrue(Enumerable.SequenceEqual(expected, slide));
        }
    }
}
