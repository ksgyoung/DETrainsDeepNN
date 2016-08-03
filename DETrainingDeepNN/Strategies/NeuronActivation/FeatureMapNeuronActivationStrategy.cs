using DETrainingDeepNN.Models;
using DETrainingDeepNN.Strategies.ConvolutionStrategies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using DETrainingDeepNN.Strategies.NeuronActivation.Interfaces;
using DETrainingDeepNN.ConfigurationSettings;
using DETrainingDeepNN.Calculators;
using DETrainingDeepNN.Strategies.SlideRetrieval;

namespace DETrainingDeepNN.Strategies.NeuronActivation
{
    public class FeatureMapNeuronActivationStrategy : IFeatureMapNeuronActivationStrategy
    {
        private IConvolutionStrategy convolutionStrategy;
        private StrideBasedSlideRetrievalStrategy slidingStrategy;
        private IConfiguration configuration;

        public FeatureMapNeuronActivationStrategy(IConvolutionStrategy convolutionStrategy, 
                                                  IConfiguration configuration)
        {
            this.convolutionStrategy = convolutionStrategy;
            this.configuration = configuration;
            this.slidingStrategy = new StrideBasedSlideRetrievalStrategy();
        }
        
        public double[] Activate(ImageInput input, double[] filter)
        {
            int stride = Int32.Parse(configuration.GetValue("Stride"));
            int finalIndex = input.TotalColumns * input.TotalRows;
            int filterWidth = Int32.Parse(configuration.GetValue("FilterWidth"));
            int filterHeight = Int32.Parse(configuration.GetValue("FilterHeight"));


            Position position = new Position(0, 0, stride);          
            Slider slider = new Slider(position, filterWidth, filterHeight, input.TotalColumns, true);

            List<Double> featureMap = new List<double>();
            int totalFeatureSections = (input.TotalRows - 1) * (input.TotalColumns - 1);

            while (featureMap.Count() < totalFeatureSections)
            {
                slider.Slide();
                double[] slide = this.slidingStrategy.GetSlide(input, slider);
                featureMap.Add(this.ConvolveSubSection(slide, filter));
            }

            return featureMap.ToArray();
        }

        internal double ConvolveSubSection(double[] inputSubsection, double[] filter)
        {
            return this.convolutionStrategy.Calculate(inputSubsection, filter);
        }
        
    }
}
