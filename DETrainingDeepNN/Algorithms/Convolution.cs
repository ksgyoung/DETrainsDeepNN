using DETrainingDeepNN.Algorithms.interfaces;
using DETrainingDeepNN.Models;
using DETrainingDeepNN.Strategies.NeuronActivation;
using DETrainingDeepNN.Strategies.NeuronActivation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Algorithms
{
    public class Convolution : IConvolution
    {
        private IFeatureMapNeuronActivationStrategy neuronActivationStrategy;

        public Convolution(IFeatureMapNeuronActivationStrategy neuronActivationStrategy)
        {
            this.neuronActivationStrategy = neuronActivationStrategy;
        }

        public List<double[]> Convolve(ImageInput imageSubsection, List<double[]> filters)
        {
            List<double[]> featureMaps = new List<double[]>();

            foreach(double[] filter in filters)
            {
                featureMaps.Add(neuronActivationStrategy.Activate(imageSubsection, filter));
            }

            return featureMaps;
        }
    }
}
