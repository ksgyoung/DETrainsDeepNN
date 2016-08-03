using DETrainingDeepNN;
using DETrainingDeepNN.ConfigurationSettings;
using DETrainingDeepNN.Calculators.Interfaces;
using DETrainingDeepNN.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_DETrainingDeepNN.Models
{
    [TestFixture]
    public class LayeredFilterGroupTest
    {
        [Test]
        public void GivenALayerFilterGroup_WhenTheLayerConfigurationIsRetrieved_ItShouldReturnAnArrayOfIntegersRepresentingTheString()
        {
            Mock<IConfiguration> configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x.GetValue(It.IsAny<string>())).Returns("[ 1, 3, 2 ]");

            Mock<ILayeredFilterGroupMapper> mapper = new Mock<ILayeredFilterGroupMapper>();
            mapper.Setup(x => x.MapToIndividualGroup(It.IsAny<Individual>(), It.IsAny<int[]>()));

            Individual individual = new Individual(null, configuration.Object, 20)
            {
                Position = new double[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0,
                                          11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0, 19.0, 20.0 }
            };

            LayeredFilterGroup group = new LayeredFilterGroup(configuration.Object, mapper.Object);

            int[] result = group.GetLayerConfiguration();

            Assert.IsTrue(result.SequenceEqual(new int[] { 1, 3, 2 }));
        }

        [Test]
        public void GivenALayerFilterGroup_WhenTheFiltersAreSet_ItShouldCallTheLayeredFilterMapper()
        {
            Mock<IConfiguration> configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x.GetValue(It.IsAny<string>())).Returns("[ 1, 3, 2 ]");

            Mock<ILayeredFilterGroupMapper> mapper = new Mock<ILayeredFilterGroupMapper>();
            mapper.Setup(x => x.MapToIndividualGroup(It.IsAny<Individual>(), It.IsAny<int[]>()));

            Individual individual = new Individual(null, configuration.Object, 20)
            {
                Position = new double[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0,
                                          11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0, 19.0, 20.0 }
            };

            LayeredFilterGroup group = new LayeredFilterGroup(configuration.Object, mapper.Object);

            group.SetFilters(individual);

            mapper.Verify(c => c.MapToIndividualGroup(It.IsAny<Individual>(), It.IsAny<int[]>()), Times.Once);
        }

        [Test]
        public void GivenALayerFilterGroup_WhenTheFiltersAreSet_ItShouldSetTheFilterVariableToTheMappedLayeredGroup()
        {
            List<List<double[]>> expected = new List<List<double[]>>();
            expected.Add(new List<double[]>() { new double[] { 1.1, 2.2 }, new double[] { 1.4, 1.2 } });

            Mock<IConfiguration> configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x.GetValue(It.IsAny<string>())).Returns("[ 1, 3, 2 ]");

            Mock<ILayeredFilterGroupMapper> mapper = new Mock<ILayeredFilterGroupMapper>();
            mapper.Setup(x => x.MapToIndividualGroup(It.IsAny<Individual>(), It.IsAny<int[]>())).Returns(expected);

            Individual individual = new Individual(null, configuration.Object, 20)
            {
                Position = new double[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0,
                                          11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0, 19.0, 20.0 }
            };

            LayeredFilterGroup group = new LayeredFilterGroup(configuration.Object, mapper.Object);

            group.SetFilters(individual);

            Assert.AreEqual(expected, group.Filters);
        }
    }
}
