using System;
using DETrainingDeepNN.Strategies.Selection.Exceptions;
using DETrainingDeepNN.Strategies.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_DETrainingDeepNN.Strategies.ConvolutionStrategies.Exceptions
{
    [TestClass]
    public class DifferingConvolutionSizeExceptionTest
    {
        [TestMethod]
        [ExpectedException(typeof(DifferingConvolutionSizeException), "The image subsection and filter size vary. Make sure that a subsection of the same size of the filter is selected")]
        public void GivenACustomException_WhenTheDifferingConvolutionSizeExceptionIsThrown_ItShouldReturnACorrspondingMessage()
        {
            throw new DifferingConvolutionSizeException();
        }
    }
}
