using DETrainingDeepNN.Calculators;
using DETrainingDeepNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Strategies.SlideRetrieval
{
    public class StrideBasedSlideRetrievalStrategy
    {
        private TwoDimensionalIndexCalculator indexCalculator;

        public StrideBasedSlideRetrievalStrategy()
        {
            indexCalculator = new TwoDimensionalIndexCalculator();
        }

        public double[] GetSlide(ImageInput input, Slider slider)
        {
            int initialIndex = indexCalculator.GetIndex(input.TotalColumns, slider.Position.X, slider.Position.Y);
            int skipCount = initialIndex;
            int filterDimensions = slider.SliderWidth * slider.SliderHeight;
            int maximumIndex = filterDimensions + initialIndex + slider.SliderHeight;

            double[] newSlide = new double[0];

            while (skipCount < maximumIndex)
            {
                newSlide = newSlide.Concat(input.GetNumericRepresentation()
                                   .Select(i => i)
                                   .Skip(skipCount)
                                   .Take(slider.SliderWidth))
                                   .ToArray();
                skipCount += input.TotalColumns;
            }

            return newSlide;
        }
    }
}
