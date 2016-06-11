﻿using DETrainingDeepNN.Strategies.Mutation.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Strategies.Mutation
{
    public class TrialIndividualMutationStrategy : ITrialIndividualMutationStrategy
    {
        public Individual GetTrialVector(Individual target, Individual first, Individual second)
        {
            double scale = Double.Parse(ConfigurationManager.AppSettings["MutationScale"]);
            Individual differenceIndividual = first - second;

            return target + this.Scale(differenceIndividual, scale);
        }

        internal Individual Scale(Individual individual, double scale)
        {
            return new Individual(null)
            {
                Position = individual.Position.Select((x, i) => x * scale).ToArray()
            };
        }
        
    }
}