using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DETrainingDeepNN.Strategies.Selection;
using System.Collections.Generic;
using DETrainingDeepNN;
using Moq;
using DETrainingDeepNN.Strategies.Selection.Exceptions;

namespace Test_DETrainingDeepNN.Strategies.Selection
{
    [TestClass]
    public class RandomSelectionStrategyTest
    {
        [TestMethod]
        public void GivenFourIndividuals_WhenTheIndividualIsSelectedUsingTheRandomSelectionStrategy_ItShouldReturnAARandomIndividual()
        {
            Individual individual1 = new Individual(null)
            {
                Fitness = 2.5555
            };

            Individual individual2 = new Individual(null)
            {
                Fitness = 1.234
            };

            Individual individual3 = new Individual(null)
            {
                Fitness = 1.234
            };

            Individual individual4 = new Individual(null)
            {
                Fitness = 1.234
            };

            Mock<Random> mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>())).Returns(2);
            Random mockedRandom = mock.Object;

            RandomSelectionStrategy selectionStrategy = new RandomSelectionStrategy(mockedRandom);

            Individual result = selectionStrategy.Select(new List<Individual>
            {
                individual1, individual2, individual3, individual4
            });

            Assert.AreEqual(individual3, result);
        }

        [TestMethod]
        public void GivenFourIndividuals_WhenTheRandomIndexIsThatOfTheLastIndividual_ItShouldReturnTheLastIndividual()
        {
            Individual individual1 = new Individual(null)
            {
                Fitness = 2.5555
            };

            Individual individual2 = new Individual(null)
            {
                Fitness = 1.234
            };

            Individual individual3 = new Individual(null)
            {
                Fitness = 1.234
            };

            Individual individual4 = new Individual(null)
            {
                Fitness = 1.234
            };

            Mock<Random> mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>())).Returns(3);
            Random mockedRandom = mock.Object;

            RandomSelectionStrategy selectionStrategy = new RandomSelectionStrategy(mockedRandom);

            Individual result = selectionStrategy.Select(new List<Individual>
            {
                individual1, individual2, individual3, individual4
            });

            Assert.AreEqual(individual4, result);
        }

        [TestMethod]
        public void GivenFourIndividuals_WhenTheRandomIndexIsThatOfTheFirstIndividual_ItShouldReturnTheFirstIndividual()
        {
            Individual individual1 = new Individual(null)
            {
                Fitness = 2.5555
            };

            Individual individual2 = new Individual(null)
            {
                Fitness = 1.234
            };

            Individual individual3 = new Individual(null)
            {
                Fitness = 1.234
            };

            Individual individual4 = new Individual(null)
            {
                Fitness = 1.234
            };

            Mock<Random> mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>())).Returns(0);
            Random mockedRandom = mock.Object;

            RandomSelectionStrategy selectionStrategy = new RandomSelectionStrategy(mockedRandom);

            Individual result = selectionStrategy.Select(new List<Individual>
            {
                individual1, individual2, individual3, individual4
            });

            Assert.AreEqual(individual1, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NoValidIndividualsException))]
        public void GivenNoIndividuals_WhenTheRandomSelectionStrategyIsUsed_ItShouldReturnNull()
        {
            Mock<Random> mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>())).Returns(0);
            Random mockedRandom = mock.Object;

            RandomSelectionStrategy selectionStrategy = new RandomSelectionStrategy(mockedRandom);

            Individual result = selectionStrategy.Select(new List<Individual>());
        }
    }
}
