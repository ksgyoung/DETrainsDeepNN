using DETrainingDeepNN.ConfigurationSettings;
using DETrainingDeepNN.Calculators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Calculators
{
    public class LayeredFilterGroupMapper : ILayeredFilterGroupMapper
    {
        private IConfiguration configuration;

        public LayeredFilterGroupMapper(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        public List<List<double[]>> MapToIndividualGroup(Individual individual, int[] layerConfiguration)
        {
            int filterSize = Int32.Parse(configuration.GetValue("FilterWidth"))
                           * Int32.Parse(configuration.GetValue("FilterHeight"));

            List<List<double[]>> layers = new List<List<double[]>>();

            int skipCount = 0;
            foreach(int layerSize in layerConfiguration)
            {
                int individualSubsection = filterSize * layerSize;

                List<double[]> layer = individual.Position
                    .Skip(skipCount)
                    .Take(individualSubsection)
                    .Select((item, index) => new { index, item })
                    .GroupBy(x => x.index / filterSize)
                    .Select(group => group.Select(y => y.item).ToArray())
                    .ToList();

                layers.Add(layer);
                skipCount = skipCount != 0 ? skipCount * individualSubsection : individualSubsection;
            }

            return layers;
        }
    }
}
