using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DETrainingDeepNN.Strategies.Selection.Exceptions;
using DETrainingDeepNN.Strategies.Exceptions;

namespace Test_DETrainingDeepNN.Strategies.Convolution.Exceptions
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
