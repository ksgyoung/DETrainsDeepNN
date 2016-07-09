using System;
using System.Text;
using System.Collections.Generic;
using DETrainingDeepNN;
using DETrainingDeepNN.Strategies.Crossover;
using System.Linq;
using DETrainingDeepNN.Strategies.Convolution;
using DETrainingDeepNN.Models;
using DETrainingDeepNN.Mappers;
using Moq;
using DETrainingDeepNN.Strategies.Exceptions;
using NUnit.Framework;

namespace Test_DETrainingDeepNN.Strategies.Crossover
{
    [TestFixture]
    public class DotProductTest
    {
        [Test]
        public void GivenAnIndividualAndASubsectionOfAnImageInput_WhenTheTwoAreConvolutedAndHaveTwoDimensions_ItShouldReturnTheDotProduct()
        {
            double[] position = new double[] { 6.0, 2.0 };

            double[] subSection = { 1, 5 };

            DotProductStrategy convolutionStrategy = new DotProductStrategy();

            double result = convolutionStrategy.Convolute(subSection, position);

            Assert.AreEqual(16, result);
        }

        [Test]
        public void GivenAnIndividualAndASubsectionOfAnImageInput_WhenTheTwoAreConvolutedAndHaveThreeDimensions_ItShouldReturnTheDotProduct()
        {
            double[] position = new double[] { 6.0, 2.0, 3.0 };

            double[] subSection = { 1, 5, 7 };

            DotProductStrategy convolutionStrategy = new DotProductStrategy();

            double result = convolutionStrategy.Convolute(subSection, position);

            Assert.AreEqual(37, result);
        }

        [Test]
        public void GivenAnIndividualAndASubsectionOfAnImageInput_WhenTheTwoAreConvolutedAndTheIndividualIsBigger_ItShouldThrowAnDifferingConvolutionSizeExceptionError()
        {
            double[] position = new double[] { 6.0, 2.0, 3.0 };

            double[] subSection = { 1, 5 };

            DotProductStrategy convolutionStrategy = new DotProductStrategy();
            
            Assert.That(() => convolutionStrategy.Convolute(subSection, position),
                Throws.TypeOf<DifferingConvolutionSizeException>());
        }

        [Test]
        public void GivenAnIndividualAndASubsectionOfAnImageInput_WhenTheTwoAreConvolutedAndTheSubsectionIsBigger_ItShouldThrowAnDifferingConvolutionSizeExceptionError()
        {
            double[] position = new double[] { 6.0, 2.0 };

            double[] subSection = { 1, 5, 3 };

            DotProductStrategy convolutionStrategy = new DotProductStrategy();

            Assert.That(() => convolutionStrategy.Convolute(subSection, position),
                Throws.TypeOf<DifferingConvolutionSizeException>());
        }
    }
}
