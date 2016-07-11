using DETrainingDeepNN.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Models
{
    public class ImageInput
    {
        private ITwoDimensionalMapper mapper;
        private double[,] Matrix;
        public int TotalRows { get; set; }
        public int TotalColumns { get; set; }

        public ImageInput(ITwoDimensionalMapper mapper) {
            this.mapper = mapper;
        }

        public double[] GetNumericRepresentation()
        {
            return this.mapper.GetArrayRepresentation(Matrix);
        }

        public void SetNumericRepresentation(double[,] numericRepresentation)
        {
            Matrix = numericRepresentation;
            TotalRows = numericRepresentation.GetLength(1);
            TotalColumns = numericRepresentation.GetLength(0);
        }
        
    }
}
