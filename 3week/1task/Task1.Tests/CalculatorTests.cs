using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture(typeof(StackArray<int>))]
    [TestFixture(typeof(StackList<int>))]
    public class CalculatorTests<TStack> where TStack : IStack<int>, new()
    {
        private Calculator calculator;

        [SetUp]
        public void Initialization()
        {
            calculator = new Calculator(new TStack());
        }

        [TestCase(-8, "-8 0 -")]
        [TestCase(21, "39 18 -")]
        [TestCase(-54, "-99 -45 -")]
        [TestCase(36, "-9 -45 -")]
        [TestCase(-39, "7 49 25 - - 14 - 13 8 3 - - -")]
        [TestCase(-21, "-48 -9 - -1 - -10 - -7 -")]
        [TestCase(-164, "-9 8 -23 10 8 -20 -15 10 20 37 -100 - - - - - - - - - -")]
        [TestCase(13, "0 -13 -")]
        [TestCase(-18, "0 18 -")]
        [TestCase(22, "22 0 -")]
        [TestCase(0, "0 0 -")]
        [TestCase(-101000000, "-1000001 99999999 -")]
        [TestCase(20, "11 9 +")]
        [TestCase(-17, "-9 -8 +")]
        [TestCase(-11, "-19 8 +")]
        [TestCase(9, "-9 18 +")]
        [TestCase(13, "18 -23 56 -22 33 -55 99 -24 -36 -52 19 + + + + + + + + + +")]
        [TestCase(-155, "-56 -99 +")]
        [TestCase(56, "7 8 *")]
        [TestCase(99, "-9 -11 *")]
        [TestCase(-27, "-3 9 *")]
        [TestCase(0, "9 0 *")]
        [TestCase(673612875, "76765 8775 *")]

        [Test]
        public void TestCalculator(int result, string input)
        {
            Assert.AreEqual(result, calculator.Calculation(input));
        }

        [TestCase("8 9 + 0 /")]
        [TestCase("5 7 + 2 * 3 + 7 3 2 * 1 + - /")]
        [Test]
        public void DevideByZero(string input)
        {
            Assert.Throws<DivisionByZeroException>(() => { calculator.Calculation(input); });
        }

        [TestCase("9 8 9 +")]
        [TestCase("8 + 9")]
        [TestCase("9 o 8 +")]
        [TestCase("  ")]
        [Test]
        public void IncorrectExpression(string input)
        {
            Assert.Throws<NotPostfixFormException>(() => { calculator.Calculation(input); });
        }
    }
}
