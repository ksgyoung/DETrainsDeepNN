using DETrainingDeepNN.Models;
using DETrainingDeepNN.Strategies.NeuronActivation.Interfaces;
using Moq;
using NUnit.Framework;
using DETrainingDeepNN.Algorithms;
using System.Collections.Generic;
using DETrainingDeepNN.Mappers;
using System.Linq;

namespace Test_DETrainingDeepNN.Strategies.ConvolutionStrategies
{
	[TestFixture]
    public class ConvolutionTest
    {
        [Test]
        public void GivenAnImageSubsectionAndThreeFilters_WhenConvolutionOccurs_ItShouldReturinAListOfFeatureMaps()
        {
            Mock<IFeatureMapNeuronActivationStrategy> mock = new Mock<IFeatureMapNeuronActivationStrategy>();
            mock.SetupSequence(x => x.Activate(It.IsAny<ImageInput>(), It.IsAny<double[]>()))
										.Returns(new double[4] { 0.2, 1.3, 0.8, 3.1 })
                                        .Returns(new double[4] { 0.8, 5.2, 1.1, 1.1 })
                                        .Returns(new double[4] { 0.1, 1.1, 0.5, 0.4 });

            ImageInput input = new ImageInput(new TwoDimensionalMapper());

            input.SetNumericRepresentation(new double[4, 4]);

            List<double[]> filters = new List<double[]>() { new double[2], new double[2], new double[2] };

            Convolution convolution = new Convolution(mock.Object);
            List<double[]> result = convolution.Convolve(input, filters);

            List<double[]> expectation = new List<double[]>();
            expectation.Add(new double[4] { 0.2, 1.3, 0.8, 3.1 });
            expectation.Add(new double[4] { 0.8, 5.2, 1.1, 1.1 });
            expectation.Add(new double[4] { 0.1, 1.1, 0.5, 0.4 });

            Assert.IsTrue(expectation[0].SequenceEqual(result[0]));
            Assert.IsTrue(expectation[1].SequenceEqual(result[1]));
            Assert.IsTrue(expectation[2].SequenceEqual(result[2]));
        }


    }
}
