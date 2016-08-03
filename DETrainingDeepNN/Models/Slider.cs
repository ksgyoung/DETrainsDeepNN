using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Models
{
    public class Slider
    {
        public Position Position { get; set; }
        public int SliderWidth { get; set; }
        public int SliderHeight { get; set; }
        private int totalWidth;
        private bool overlap;

        public Slider(Position position, int sliderWidth, int sliderHeight, int totalWidth, bool overlap)
        {
            this.Position = position;
            this.SliderWidth = sliderWidth;
            this.SliderHeight = sliderHeight;
            this.totalWidth = totalWidth;
            this.overlap = overlap;
        }

        public void Slide()
        {
            Position.SlideForward();
            this.AdjustPosition();
        }

        private void AdjustPosition()
        {
            if (Position.X + SliderWidth > totalWidth)
            {
                int yDistance = overlap ? 1 : SliderHeight;
                Position.X = 0;
                Position.Y = Position.Y + yDistance;
            }
        }
    }
}
