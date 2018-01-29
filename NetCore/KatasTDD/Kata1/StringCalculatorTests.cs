using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KatasTDD.Kata1
{
    /// <summary>
    /// http://osherove.com/tdd-kata-1/
    /// </summary>
    [TestClass]
    public class StringCalculatorTests
    {
        [TestInitialize]
        public void Init()
        {

        }

        [TestMethod]
        public void EmptyStringShouldBeZero()
        {
            var stringCalculator = new StringCalculator();
            var res = stringCalculator.Add("");

            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void WhiteSpaceShouldBeZero()
        {
            var stringCalculator = new StringCalculator();
            var res = stringCalculator.Add(" ");

            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void OneShouldBeOne()
        {
            var stringCalculator = new StringCalculator();
            var res = stringCalculator.Add("1");

            Assert.AreEqual(res, 1);
        }

        [TestMethod]
        public void NumberCommaNumberShouldBeSum()
        {
            var stringCalculator = new StringCalculator();
            var res = stringCalculator.Add("1,2");

            Assert.AreEqual(res, 3);
        }

        [TestMethod]
        public void SpacesShouldBeIgnored()
        {
            var stringCalculator = new StringCalculator();
            var res = stringCalculator.Add("  1");

            Assert.AreEqual(res, 1);
        }

        [TestMethod]
        public void NewLineShouldSeparateNumbers()
        {
            var stringCalculator = new StringCalculator();
            var res = stringCalculator.Add("\n 1 \n  2 , 3");

            Assert.AreEqual(res, 6);

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FailOnNonNumericCharacter()
        {
            var stringCalculator = new StringCalculator();
            var res = stringCalculator.Add("1\n $%& 2 , 3");
        }

    }

}
