using DETrainingDeepNN.ConfigurationSettings;
using DETrainingDeepNN.Calculators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Models
{
    public class LayeredFilterGroup
    {
        private IConfiguration configuration;
        private ILayeredFilterGroupMapper mapper;

        private List<List<double[]>> filters;
        public List<List<double[]>> Filters
        {
            get
            {
                return this.filters;
            }
        }

        public LayeredFilterGroup(IConfiguration configuration, ILayeredFilterGroupMapper mapper)
        {
            this.configuration = configuration;
            this.mapper = mapper;
        }

        public void SetFilters(Individual individual)
        {
            this.filters = this.mapper.MapToIndividualGroup(individual, null);
        }

        internal int[] GetLayerConfiguration()
        {
            string layerConfiguration = configuration.GetValue("LayerConfiguration");
            int indexOfOpeningBrachet = 1;
            int indexOfClosingBracket = layerConfiguration.Length - 2;

            return layerConfiguration.Substring(indexOfOpeningBrachet, indexOfClosingBracket)
                                     .Split(',')
                                     .Select(x => Int32.Parse(x)).ToArray();
        }
    }
}
