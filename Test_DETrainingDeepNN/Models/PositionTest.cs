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
    public class PositionTest
    {
       
        [Test]
        public void GivenAnPositionIsInitialised_WhenTheXCoordinateIsRetrieved_ItShouldReturnTheValuePassed()
        {
            Position position = new Position(2, 3, 0);

            Assert.AreEqual(position.X, 2);
        }

        [Test]
        public void GivenAnPositionIsInitialised_WhenTheYCoordinateIsRetrieved_ItShouldReturnTheValuePassed()
        {
            Position position = new Position(2, 3, 0);

            Assert.AreEqual(position.Y, 3);
        }

        [Test]
        public void GivenAnPosition_WhenThePositionIsSlidForwardByOne_ItShouldAddOneToTheXcoordinate()
        {
            Position position = new Position(2, 3, 1);

            position.SlideForward();

            Assert.AreEqual(position.X, 3);
        }

        [Test]
        public void GivenAnPosition_WhenThePositionIsSlidForwardByTwo_ItShouldAddTwoToTheXcoordinate()
        {
            Position position = new Position(2, 3, 2);

            position.SlideForward();

            Assert.AreEqual(position.X, 4);
        }

        [Test]
        public void GivenAnPosition_WhenThePositionIsSlidBackByOne_ItShouldRemoveOneFromTheXcoordinate()
        {
            Position position = new Position(2, 3, 1);

            position.SlideBack();

            Assert.AreEqual(position.X, 1);
        }

        [Test]
        public void GivenAnPosition_WhenThePositionIsSlidBackByTwo_ItShouldRemoveTwoFromTheXcoordinate()
        {
            Position position = new Position(2, 3, 2);

            position.SlideBack();

            Assert.AreEqual(position.X, 0);
        }

        [Test]
        public void GivenAnPosition_WhenThePositionIsSlidUpByOne_ItShouldRemoveOneFromTheYcoordinate()
        {
            Position position = new Position(2, 3, 1);

            position.SlideUp();

            Assert.AreEqual(position.Y, 2);
        }

        [Test]
        public void GivenAnPosition_WhenThePositionIsSlidUpByTwo_ItShouldRemovTwoFromTheYcoordinate()
        {
            Position position = new Position(2, 3, 2);

            position.SlideUp();

            Assert.AreEqual(position.Y, 1);
        }

        [Test]
        public void GivenAnPosition_WhenThePositionIsSlidUpDownByOne_ItShouldAddOneToTheYcoordinate()
        {
            Position position = new Position(2, 3, 1);

            position.SlideDown();

            Assert.AreEqual(position.Y, 4);
        }

        [Test]
        public void GivenAnPosition_WhenThePositionIsSlidUpDownByTwo_ItShouldAddTwoToTheYcoordinate()
        {
            Position position = new Position(2, 3, 2);

            position.SlideDown();

            Assert.AreEqual(position.Y, 5);
        }
    }
}
