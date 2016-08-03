using DETrainingDeepNN.ConfigurationSettings;
using DETrainingDeepNN.Calculators;
using DETrainingDeepNN.Strategies.SlideRetrieval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Models
{
    public class ImageInput
    {
        private ITwoDimensionalMapper mapper;
        private double[,] Matrix;
        public int TotalRows { get; set; }
        public int TotalColumns { get; set; }
        private IConfiguration configuration;
        private StrideBasedSlideRetrievalStrategy slideStrategy;

        public ImageInput(ITwoDimensionalMapper mapper, IConfiguration configuration) {
            this.mapper = mapper;
            this.configuration = configuration;
            this.slideStrategy = new StrideBasedSlideRetrievalStrategy();
        }
        
        public double[] GetNumericRepresentation()
        {
            return this.mapper.GetArrayRepresentation(Matrix);
        }

        public void SetNumericRepresentation(double[,] numericRepresentation)
        {
            Matrix = numericRepresentation;
            TotalRows = numericRepresentation.GetLength(1);
            TotalColumns = numericRepresentation.GetLength(0);
        }

        public List<double[]> GetSplitSubsections()
        {
            int subsectionWidth = Int32.Parse(configuration.GetValue("SubsectionWidth"));
            int subsectionHeight = Int32.Parse(configuration.GetValue("SubsectionHeight"));

            Position position = new Position(0, 0, subsectionWidth);
            Slider slider = new Slider(position, subsectionWidth, subsectionHeight, this.TotalColumns, false);

            List<double[]> subsections = new List<double[]>();
            
            while (hasSections(position, subsectionWidth, subsectionHeight))
            {
                subsections.Add(slideStrategy.GetSlide(this, slider));
                slider.Slide();
            }
            
            return subsections;
        }

        private bool hasSections(Position position, int subsectionWidth, int subsectionHeight)
        {
            return position.X + subsectionWidth <= this.TotalColumns 
                   && position.Y + subsectionHeight <= this.TotalRows;
        }
    }
}
