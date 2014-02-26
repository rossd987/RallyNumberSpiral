/******************
 * Ross Dougherty
 * 2014-02-25
 * ***************/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RallyNumberSpiral.Tests
{
    [TestClass]
    public class NumberSpiralTests
    {
        [TestMethod]
        public void Exeption_InvalidNumber()
        {
            string size = "abc";
            string message = "";
            try
            {
                NumberSpiral spiral = NumberSpiral.CreateNumberSpiral(size);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Please enter a valid positive integer value.",
                message);
        }

        [TestMethod]
        public void Exeption_NegativeNumber()
        {
            string size = "-12";
            string message = "";
            try
            {
                NumberSpiral spiral = NumberSpiral.CreateNumberSpiral(size);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Please enter a positive integer.",
                message);
        }

        [TestMethod]
        public void Exeption_HugeNumber()
        {
            string size = ((long)int.MaxValue + 1).ToString();
            string message = "";
            try
            {
                NumberSpiral spiral = NumberSpiral.CreateNumberSpiral(size);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Please enter a valid positive integer value.",
                message);
        }

        [TestMethod]
        public void Zero()
        {
            string size = "0";
            NumberSpiral spiral = NumberSpiral.CreateNumberSpiral(size);
            Assert.AreEqual("0", spiral.ToString());
        }

        [TestMethod]
        public void One()
        {
            string size = "1";
            NumberSpiral spiral = NumberSpiral.CreateNumberSpiral(size);
            Assert.AreEqual(@"0 1", spiral.ToString());
        }

        [TestMethod]
        public void Two()
        {
            string size = "2";
            NumberSpiral spiral = NumberSpiral.CreateNumberSpiral(size);
            Assert.AreEqual(
@"0 1
  2", spiral.ToString());
        }

        [TestMethod]
        public void TwentyFour()
        {
            string size = "24";
            NumberSpiral spiral = NumberSpiral.CreateNumberSpiral(size);
            Assert.AreEqual(
@"20 21 22 23 24
19  6  7  8  9
18  5  0  1 10
17  4  3  2 11
16 15 14 13 12", spiral.ToString());
        }

        [TestMethod]
        public void TwentyFive()
        {
            string size = "25";
            NumberSpiral spiral = NumberSpiral.CreateNumberSpiral(size);
            Assert.AreEqual(
@"20 21 22 23 24 25
19  6  7  8  9
18  5  0  1 10
17  4  3  2 11
16 15 14 13 12", spiral.ToString());
        }

        [TestMethod]
        public void ThirtyThree()
        {
            string size = "33";
            NumberSpiral spiral = NumberSpiral.CreateNumberSpiral(size);
            Assert.AreEqual(
@"20 21 22 23 24 25
19  6  7  8  9 26
18  5  0  1 10 27
17  4  3  2 11 28
16 15 14 13 12 29
      33 32 31 30", spiral.ToString());
        }
    }
}
