using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DETrainingDeepNN;
using DETrainingDeepNN.ConfigurationSettings;
using Moq;
using System.Collections.Generic;
using System.Linq;
using DETrainingDeepNN.Mappers;

namespace Test_DETrainingDeepNN.Mappers
{
    [TestClass]
    public class LayeredFilterGroupMapperTest
    {
        [TestMethod]
        public void GivenAnIndividual_WhenTheIndividualIsMappedToAnIndividualGroup_ItShouldReturnAnIndividualGroupWithVectorsSplitBetweenLayers()
        {
            Mock<IConfiguration> configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x.GetValue("LayerConfiguration")).Returns("[ 2, 3 ]");
            configuration.Setup(x => x.GetValue("FilterWidth")).Returns("2");
            configuration.Setup(x => x.GetValue("FilterHeight")).Returns("2");

            LayeredFilterGroupMapper mapper = new LayeredFilterGroupMapper(configuration.Object);

            Individual individual = new Individual(null, configuration.Object, 20)
            {
                Position = new double[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0,
                                          11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0, 19.0, 20.0 }
            };

            List<List<double[]>> individualGroup = mapper.MapToIndividualGroup(individual, new int[] { 2, 3 });

            Assert.IsTrue(individualGroup[0][0].SequenceEqual(new double[] { 1.0, 2.0, 3.0, 4.0 }));
            Assert.IsTrue(individualGroup[0][1].SequenceEqual(new double[] { 5.0, 6.0, 7.0, 8.0 }));
            Assert.IsTrue(individualGroup[1][0].SequenceEqual(new double[] { 9.0, 10.0, 11.0, 12.0 }));
            Assert.IsTrue(individualGroup[1][1].SequenceEqual(new double[] { 13.0, 14.0, 15.0, 16.0 }));
            Assert.IsTrue(individualGroup[1][2].SequenceEqual(new double[] { 17.0, 18.0, 19.0, 20.0 }));
        }
        
    }
}
