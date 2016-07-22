using DETrainingDeepNN.Mappers;
using DETrainingDeepNN.Models;
using DETrainingDeepNN.Strategies.Convolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

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
        
        public double[] Activate(ImageInput input, double[] filter, int filterWidth)
        {
            int stride = Int32.Parse(ConfigurationManager.AppSettings["Stride"]);
            Position position = new Position(0, 0, stride);
            int finalIndex = input.TotalColumns * input.TotalRows;

            List<Double> featureMap = new List<double>();
            int filterHeight = filter.Length / filterWidth;
            int totalFeatureSections = (input.TotalRows - 1) * (input.TotalColumns - 1);

            while (featureMap.Count() < totalFeatureSections)
            {
                double[] slide = this.GetSlide(input, filterWidth, filterHeight, position);
                featureMap.Add(this.ConvolveSubSection(slide, filter));
            }

            return featureMap.ToArray();
        }

        internal double ConvolveSubSection(double[] inputSubsection, double[] filter)
        {
            return this.ConvolutionStrategy.Convolute(inputSubsection, filter);
        }
        
        internal double[] GetSlide(ImageInput input, int filterWidth, int filterHeight, Position position)
        {
            position.SlideForward();

            int initialIndex = this.GetIndex(input.TotalColumns, filterWidth, position);
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
        
        private int GetIndex(int inputWidth, int filterWidth, Position position)
        {
            if (position.X + filterWidth > inputWidth) {
                position.X = 0;
                position.Y = position.Y + 1;
            }

            return indexCalculator.GetIndex(inputWidth, position.X, position.Y);
        }
    }
}
