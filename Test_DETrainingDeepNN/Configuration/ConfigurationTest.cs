using DETrainingDeepNN.ConfigurationSettings;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_DETrainingDeepNN.ConfigurationSettings
{
    [TestFixture]
    public class ConfigurationTest
    {
        [Test]
        public void GivenAKeyForAnInteger_WhenAValueIsRetrieved_ItShouldReturnTheValueInTheConfigurationFileForTheGivenKey()
        {
            Configuration configuration = new Configuration();

            Assert.AreEqual("10", configuration.GetValue("Dimensions"));
        }

        [Test]
        public void GivenAKeyForADouble_WhenAValueIsRetrieved_ItShouldReturnTheValueInTheConfigurationFileForTheGivenKey()
        {
            Configuration configuration = new Configuration();

            Assert.AreEqual("0.5", configuration.GetValue("MutationScale"));
        }
    }
}

