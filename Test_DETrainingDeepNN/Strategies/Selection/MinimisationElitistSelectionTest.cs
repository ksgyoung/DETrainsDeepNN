using System;
using System.Text;
using System.Collections.Generic;
using DETrainingDeepNN.Strategies.Selection;
using DETrainingDeepNN;
using Moq;
using DETrainingDeepNN.Strategies.Selection.Exceptions;
using NUnit.Framework;
using DETrainingDeepNN.ConfigurationSettings;

namespace Test_DETrainingDeepNN.Strategies.Selection
{
    [TestFixture]
    public class MinimisationElitistSelectionTest
    {
        [Test]
        public void GivenTwoIndividualsWithDifferingFitnesses_WhenTheMinimisationElitistSelectionIsUsed_ItShouldReturnTheIndividualWithTheLowerFitness()
        {
            Individual individual1 = new Individual(null, new Configuration())
            {
                Fitness = 2.5555
            };

            Individual individual2 = new Individual(null, new Configuration())
            {
                Fitness = 1.234
            };
            
            MinimisationElitistSelectionStrategy selection = new MinimisationElitistSelectionStrategy();
            Individual result = selection.Select(new List<Individual>
            {
                individual1, individual2
            });

            Assert.AreEqual(individual2, result);
        }

        [Test]
        public void GivenThreeIndividualsWithDifferingFitnesses_WhenTheMinimisationElitistSelectionIsUsed_ItShouldReturnTheIndividualWithTheLowerFitness()
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
                Fitness = 1.444
            };

            MinimisationElitistSelectionStrategy selection = new MinimisationElitistSelectionStrategy();
            Individual result = selection.Select(new List<Individual>
            {
                individual1, individual2, individual3
            });

            Assert.AreEqual(individual2, result);
        }

        [Test]
        public void GivenTwoIndividualsWithTheSameFitnesses_WhenTheMinimisationElitistSelectionIsUsed_ItShouldReturnTheFirtsOfTheTwoIndividuals()
        {
            Individual individual1 = new Individual(null, new Configuration())
            {
                Fitness = 1.234
            };

            Individual individual2 = new Individual(null, new Configuration())
            {
                Fitness = 1.234
            };
            
            MinimisationElitistSelectionStrategy selection = new MinimisationElitistSelectionStrategy();
            Individual result = selection.Select(new List<Individual>
            {
                individual1, individual2
            });

            Assert.AreEqual(individual1, result);
        }

        [Test]
        public void GivenNoIndividuals_WhenTheRandomSelectionStrategyIsUsed_ItShouldReturnNull()
        {
            MinimisationElitistSelectionStrategy selectionStrategy = new MinimisationElitistSelectionStrategy();
            
            Assert.That(() => selectionStrategy.Select(new List<Individual>()),
                Throws.TypeOf<NoValidIndividualsException>());
        }
    }
}
