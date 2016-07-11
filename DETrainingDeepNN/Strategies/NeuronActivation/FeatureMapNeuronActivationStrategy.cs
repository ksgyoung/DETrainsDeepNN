using DETrainingDeepNN.Mappers;
using DETrainingDeepNN.Models;
using DETrainingDeepNN.Strategies.Convolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Strategies.NeuronActivation
{
    public class FeatureMapNeuronActivationStrategy
    {
        private IConvolutionStrategy ConvolutionStrategy;

        public FeatureMapNeuronActivationStrategy(IConvolutionStrategy convolutionStrategy)
        {
            this.ConvolutionStrategy = convolutionStrategy;
        }

        internal double ConvolveSubSection(ImageInput inputSubsection, double[] filter)
        {
            return this.ConvolutionStrategy.Convolute(inputSubsection.GetNumericRepresentation(), filter);
        }

        private int GetIndex(int width, int xlocation, int yLocation)
        {
            return (width * yLocation) + xlocation;
        }

        internal double[] GetSlide(ImageInput input, int filterWidth, int filterHeight, Position position)
        {
            position.SlideForward();

            int initialIndex = GetIndex(filterWidth, position.X, position.Y);
            int skipCount = initialIndex;
            int filterDimensions = filterWidth * filterHeight;
            int maximumIndex = filterDimensions + initialIndex + filterHeight;

            double[] newSlide = new double[0];

            while(skipCount < maximumIndex)
            {
                newSlide = newSlide.Concat(input.GetNumericRepresentation()
                                   .Select(i => i)
                                   .Skip(skipCount)
                                   .Take(filterWidth))
                                   .ToArray();
                skipCount += input.TotalColumns;
            }

            return newSlide;
        }
    }
}
