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
        private IndexCalculator indexCalculator;

        public FeatureMapNeuronActivationStrategy(IConvolutionStrategy convolutionStrategy)
        {
            this.ConvolutionStrategy = convolutionStrategy;
            indexCalculator = new IndexCalculator();
        }

        //TODO get slide and convolve - to build Feature map

        internal double ConvolveSubSection(ImageInput inputSubsection, double[] filter)
        {
            return this.ConvolutionStrategy.Convolute(inputSubsection.GetNumericRepresentation(), filter);
        }
        
        internal double[] GetSlide(ImageInput input, int filterWidth, int filterHeight, Position position)
        {
            position.SlideForward();

            int initialIndex = indexCalculator.GetIndex(filterWidth, position.X, position.Y);
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
