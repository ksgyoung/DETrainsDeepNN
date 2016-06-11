using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DETrainingDeepNN.Strategies.Selection.Exceptions;

namespace Test_DETrainingDeepNN.Strategies.Selection.Exceptions
{
    [TestClass]
    public class NoValidIndividualsExceptionTest
    {
        [TestMethod]
        [ExpectedException(typeof(NoValidIndividualsException), "No valid individual to select from was passed")]
        public void GivenACustomException_WhenTheNoValidIndividualsExceptionIsThrown_ItShouldReturnACorrspondingMessage()
        {
            throw new NoValidIndividualsException();
        }
    }
}
