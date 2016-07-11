using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DETrainingDeepNN.Strategies.FitnessEvaluation.Interfaces;
using DETrainingDeepNN.Mappers;

namespace DETrainingDeepNN.Models
{
    public class ImageIndividual : Individual
    {
        public int TotalRows { get; set; }
        private ITwoDimensionalMapper mapper { get; set; }

        public ImageIndividual(ITwoDimensionalMapper mapper, 
                               IFitnessEvaluationStrategy fitnessEvaluationStrategy, 
                               int dimensions = 0) 
            : base(fitnessEvaluationStrategy, dimensions)
        {
            this.mapper = mapper;
        }

        public double[,] GetTwoDimenionalRepresentation()
        {
            return mapper.GetTwoDimensionalRepresentation(this.Position, this.TotalRows);
        }
        
    }
}
