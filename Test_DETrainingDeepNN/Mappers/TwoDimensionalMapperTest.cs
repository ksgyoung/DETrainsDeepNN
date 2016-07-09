using DETrainingDeepNN.Mappers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_DETrainingDeepNN.Strategies.Mappers
{
    [TestFixture]
    public class TwoDimensionalMapperTest
    {
        [Test]
        public void GivenAMatrix_WhenTheArrayRepresentationIsRetrieved_ItShouldReturnTheFlattenedMatrix()
        {
            double[,] matrix = new double[4,4];
            matrix[0, 0] = 0;
            matrix[0, 1] = 1;
            matrix[0, 2] = 2;
            matrix[0, 3] = 3;
            matrix[1, 0] = 4;
            matrix[1, 1] = 5;
            matrix[1, 2] = 6;
            matrix[1, 3] = 7;
            matrix[2, 0] = 8;
            matrix[2, 1] = 9;
            matrix[2, 2] = 10;
            matrix[2, 3] = 11;
            matrix[3, 0] = 12;
            matrix[3, 1] = 13;
            matrix[3, 2] = 14;
            matrix[3, 3] = 15;

            double[] arrayRepresentation = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            TwoDimensionalMapper mapper = new TwoDimensionalMapper();
            double[] result = mapper.GetArrayRepresentation(matrix);

            Assert.IsTrue(Enumerable.SequenceEqual(result, arrayRepresentation));
        }

        [Test]
        public void GivenAnArray_WhenTheTwoDomensionalRepresentationIsRetrieved_ItShouldReturnTheTwoDimensioalArrayCorrectlyMapped()
        {
            double[,] matrix = new double[4, 4];
            matrix[0, 0] = 0;
            matrix[0, 1] = 1;
            matrix[0, 2] = 2;
            matrix[0, 3] = 3;
            matrix[1, 0] = 4;
            matrix[1, 1] = 5;
            matrix[1, 2] = 6;
            matrix[1, 3] = 7;
            matrix[2, 0] = 8;
            matrix[2, 1] = 9;
            matrix[2, 2] = 10;
            matrix[2, 3] = 11;
            matrix[3, 0] = 12;
            matrix[3, 1] = 13;
            matrix[3, 2] = 14;
            matrix[3, 3] = 15;

            double[] arrayRepresentation = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            TwoDimensionalMapper mapper = new TwoDimensionalMapper();
            double[,] result = mapper.GetTwoDimensionalRepresentation(arrayRepresentation, 4);

            int totalMatches = 0;
            for (int h = 0; h < 4; h++)
            {
                for (int w = 0; w < 4; w++)
                {
                    if(result[h,w] == matrix[h,w])
                    {
                        totalMatches++;
                    }
                }
            }

            Assert.AreEqual(16, totalMatches);
        }
    }
}
