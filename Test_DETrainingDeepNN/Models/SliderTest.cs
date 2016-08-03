using DETrainingDeepNN.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_DETrainingDeepNN.Models
{
    [TestFixture]
    public class SliderTest
    {
        [Test]
        public void GivenAnPositionAtTheRightMostEndOfTheInputAndOverlap_WhenThePositionIsSlidForwardByOne_ItShouldMakeTheXCoordinateZeroAndAddOneToY()
        {
            Position position = new Position(3, 0, 1);
            Slider slider = new Slider(position, 2, 2, 4, true);

            slider.Slide();

            Assert.AreEqual(position.X, 0);
            Assert.AreEqual(position.Y, 1);
        }

        [Test]
        public void GivenAnPositionAtTheRightMostEndOfTheInputAndNoOverlap_WhenThePositionIsSlidForwardByOne_ItShouldMakeTheXCoordinateZeroAndAddHeightToY()
        {
            Position position = new Position(3, 0, 1);
            Slider slider = new Slider(position, 2, 2, 4, false);

            slider.Slide();

            Assert.AreEqual(position.X, 0);
            Assert.AreEqual(position.Y, 2);
        }
    }
}
