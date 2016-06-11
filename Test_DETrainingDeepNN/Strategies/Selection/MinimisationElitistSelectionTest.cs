using System;
using System.Text;
using System.Collections.Generic;
using DETrainingDeepNN.Strategies.Selection;
using DETrainingDeepNN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_DETrainingDeepNN.Strategies.Selection
{
    [TestClass]
    public class MinimisationElitistSelectionTest
    {
        [TestMethod]
        public void GivenTwoIndividualsWithDifferingFitnesses_WhenTheMinimisationElitistSelectionIsUsed_ItShouldReturnTheIndividualWithTheLowerFitness()
        {
            Individual individual1 = new Individual(null)
            {
                Fitness = 2.5555
            };

            Individual individual2 = new Individual(null)
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

        [TestMethod]
        public void GivenThreeIndividualsWithDifferingFitnesses_WhenTheMinimisationElitistSelectionIsUsed_ItShouldReturnTheIndividualWithTheLowerFitness()
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
                Fitness = 1.444
            };

            MinimisationElitistSelectionStrategy selection = new MinimisationElitistSelectionStrategy();
            Individual result = selection.Select(new List<Individual>
            {
                individual1, individual2, individual3
            });

            Assert.AreEqual(individual2, result);
        }

        [TestMethod]
        public void GivenTwoIndividualsWithTheSameFitnesses_WhenTheMinimisationElitistSelectionIsUsed_ItShouldReturnTheFirtsOfTheTwoIndividuals()
        {
            Individual individual1 = new Individual(null)
            {
                Fitness = 1.234
            };

            Individual individual2 = new Individual(null)
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
    }
}
