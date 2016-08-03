using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Calculators
{
    public class TwoDimensionalMapper : ITwoDimensionalMapper
    {
        private TwoDimensionalIndexCalculator indexCalculator;

        public TwoDimensionalMapper()
        {
            indexCalculator = new TwoDimensionalIndexCalculator();
        }

        public double[] GetArrayRepresentation(double[,] matrix)
        {
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);

            double[] arrayRepresentation = new double[width * height];

            for (int h = 0; h < width; h++)
            {
                for (int w = 0; w < height; w++)
                {
                    int index = indexCalculator.GetIndex(width, w, h);
                    arrayRepresentation[index] = matrix[h, w];
                }
            }

            return arrayRepresentation;
        }

        public double[,] GetTwoDimensionalRepresentation(double[] arrayRepresentation, int width)
        {
            int height = arrayRepresentation.Length / width;

            double[,] matrix = new double[height, width];
            
            for (int h = 0; h < width; h++)
            {
                for (int w = 0; w < height; w++)
                {
                    int index = indexCalculator.GetIndex(width, w, h);
                    matrix[h, w] = arrayRepresentation[index];
                }

            }

            return matrix;
        }
        
    }
}
