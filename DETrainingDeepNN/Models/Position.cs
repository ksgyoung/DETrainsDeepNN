using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETrainingDeepNN.Models
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        private int stride;

        public Position(int x, int y, int stride)
        {
            this.X = x;
            this.Y = y;
            this.stride = stride;
        }
        
        public void SlideForward()
        {
            this.X += this.stride;
        }

        public void SlideBack()
        {
            this.X -= this.stride;
        }

        public void SlideDown()
        {
            this.Y += this.stride;
        }

        public void SlideUp()
        {
            this.Y -= this.stride;
        }
    }
}
