using DETrainingDeepNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Strategies.NeuronActivation.Interfaces
{
    public interface IFeatureMapNeuronActivationStrategy
    {
        double[] Activate(ImageInput input, double[] filter);
    }
}
