using System;
using DETrainingDeepNN.Strategies.Selection;
using System.Collections.Generic;
using DETrainingDeepNN;
using Moq;
using DETrainingDeepNN.Strategies.Selection.Exceptions;
using DETrainingDeepNN.RandomGenerators;
using NUnit.Framework;
using DETrainingDeepNN.ConfigurationSettings;

namespace Test_DETrainingDeepNN.Strategies.Selection
{
    [TestFixture]
    public class RandomSelectionStrategyTest
    {
        [Test]
        public void GivenFourIndividuals_WhenTheIndividualIsSelectedUsingTheRandomSelectionStrategy_ItShouldReturnAARandomIndividual()
        {
            Individual individual1 = new Individual(null, new Configuration())
            {
                Fitness = 2.5555
            };

            Individual individual2 = new Individual(null, new Configuration())
            {
                Fitness = 1.234
            };

            Individual individual3 = new Individual(null, new Configuration())
            {
                Fitness = 1.234
            };

            Individual individual4 = new Individual(null, new Configuration())
            {
                Fitness = 1.234
            };

            Mock<Random> mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(2);
            Random mockedRandom = mock.Object;

            RandomGenerator.GetInstance().SetRandom(mockedRandom);

            RandomSelectionStrategy selectionStrategy = new RandomSelectionStrategy();

            Individual result = selectionStrategy.Select(new List<Individual>
            {
                individual1, individual2, individual3, individual4
            });

            Assert.AreEqual(individual3, result);
        }

        [Test]
        public void GivenFourIndividuals_WhenTheRandomIndexIsThatOfTheLastIndividual_ItShouldReturnTheLastIndividual()
        {
            Individual individual1 = new Individual(null, new Configuration())
            {
                Fitness = 2.5555
            };

            Individual individual2 = new Individual(null, new Configuration())
            {
                Fitness = 1.234
            };

            Individual individual3 = new Individual(null, new Configuration())
            {
                Fitness = 1.234
            };

            Individual individual4 = new Individual(null, new Configuration())
            {
                Fitness = 1.234
            };

            Mock<Random> mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(3);
            Random mockedRandom = mock.Object;

            RandomGenerator.GetInstance().SetRandom(mockedRandom);

            RandomSelectionStrategy selectionStrategy = new RandomSelectionStrategy();

            Individual result = selectionStrategy.Select(new List<Individual>
            {
                individual1, individual2, individual3, individual4
            });

            Assert.AreEqual(individual4, result);
        }

        [Test]
        public void GivenFourIndividuals_WhenTheRandomIndexIsThatOfTheFirstIndividual_ItShouldReturnTheFirstIndividual()
        {
            Individual individual1 = new Individual(null, new Configuration())
            {
                Fitness = 2.5555
            };

            Individual individual2 = new Individual(null, new Configuration())
            {
                Fitness = 1.234
            };

            Individual individual3 = new Individual(null, new Configuration())
            {
                Fitness = 1.234
            };

            Individual individual4 = new Individual(null, new Configuration())
            {
                Fitness = 1.234
            };

            Mock<Random> mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>())).Returns(0);
            Random mockedRandom = mock.Object;

            RandomGenerator.GetInstance().SetRandom(mockedRandom);

            RandomSelectionStrategy selectionStrategy = new RandomSelectionStrategy();

            Individual result = selectionStrategy.Select(new List<Individual>
            {
                individual1, individual2, individual3, individual4
            });

            Assert.AreEqual(individual1, result);
        }

        [Test]
        public void GivenNoIndividuals_WhenTheRandomSelectionStrategyIsUsed_ItShouldReturnNull()
        {
            Mock<Random> mock = new Mock<Random>();
            mock.Setup(x => x.Next(It.IsAny<int>())).Returns(0);
            Random mockedRandom = mock.Object;

            RandomGenerator.GetInstance().SetRandom(mockedRandom);

            RandomSelectionStrategy selectionStrategy = new RandomSelectionStrategy();
            
            Assert.That(() => selectionStrategy.Select(new List<Individual>()),
                Throws.TypeOf<NoValidIndividualsException>());
        }
    }
}
