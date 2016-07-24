using DETrainingDeepNN.Mappers;
using DETrainingDeepNN.Models;
using DETrainingDeepNN.Strategies.ConvolutionStrategies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DETrainingDeepNN.Strategies.NeuronActivation.Interfaces;
using DETrainingDeepNN.ConfigurationSettings;

namespace DETrainingDeepNN.Strategies.NeuronActivation
{
    public class FeatureMapNeuronActivationStrategy : IFeatureMapNeuronActivationStrategy
    {
        private IConvolutionStrategy ConvolutionStrategy;
        private IndexCalculator indexCalculator;
        private IConfiguration configuration;

        public FeatureMapNeuronActivationStrategy(IConvolutionStrategy convolutionStrategy, 
                                                  IConfiguration configuration)
        {
            this.ConvolutionStrategy = convolutionStrategy;
            indexCalculator = new IndexCalculator();
            this.configuration = configuration;
        }
        
        public double[] Activate(ImageInput input, double[] filter)
        {
            int stride = Int32.Parse(configuration.GetValue("Stride"));
            Position position = new Position(0, 0, stride);
            int finalIndex = input.TotalColumns * input.TotalRows;
            int filterWidth = Int32.Parse(configuration.GetValue("FilterWidth"));

            List<Double> featureMap = new List<double>();
            int filterHeight = filter.Length / filterWidth;
            int totalFeatureSections = (input.TotalRows - 1) * (input.TotalColumns - 1);

            while (featureMap.Count() < totalFeatureSections)
            {
                double[] slide = this.GetSlide(input, position);
                featureMap.Add(this.ConvolveSubSection(slide, filter));
            }

            return featureMap.ToArray();
        }

        internal double ConvolveSubSection(double[] inputSubsection, double[] filter)
        {
            return this.ConvolutionStrategy.Calculate(inputSubsection, filter);
        }
        
        internal double[] GetSlide(ImageInput input, Position position)
        {
            position.SlideForward();

            int filterWidth = Int32.Parse(configuration.GetValue("FilterWidth"));
            int filterHeight = Int32.Parse(configuration.GetValue("FilterHeight"));

            int initialIndex = this.GetIndex(input.TotalColumns, position);
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
        
        private int GetIndex(int inputWidth, Position position)
        {
            int filterWidth = Int32.Parse(configuration.GetValue("FilterWidth"));

            if (position.X + filterWidth > inputWidth) {
                position.X = 0;
                position.Y = position.Y + 1;
            }

            return indexCalculator.GetIndex(inputWidth, position.X, position.Y);
        }
    }
}
