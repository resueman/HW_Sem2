using NUnit.Framework;

namespace Calculator.Tests
{
    public class InfixToPostfixConverterTests
    {
        [Test]
        [TestCase("(5+8)*91-26/((6-8)*3-5*(46+19*4))", "5 8 + 91 * 26 6 8 - 3 * 5 46 19 4 * + * - / - ")]
        [TestCase("-7--8+-9*-15/-8", "-7 -8 - -9 -15 * -8 / + ")]
        [TestCase("9*(-7--10)+-27/(-3*-9)", "9 -7 -10 - * -27 -3 -9 * / + ")]
        [TestCase("0,0000007+768,97--89,654", "0,0000007 768,97 + -89,654 - ")]
        [TestCase("5-(6-7+8*3)*77", "5 6 7 - 8 3 * + 77 * - ")]
        [TestCase("(9-8)*7", "9 8 - 7 * ")]
        [TestCase("(809*432123)*657", "809 432123 * 657 * ")]
        [TestCase("-0,00000 + 8", "-0,00000 8 + ")]
        [TestCase("-7-((9*(((7+6)*9-5)*4+6)*7-5)/6+7)*8--9+1",
            "-7 9 7 6 + 9 * 5 - 4 * 6 + * 7 * 5 - 6 / 7 + 8 * - -9 - 1 + ")]
        [TestCase("0,695478376-1,75849488", "0,695478376 1,75849488 - ")]
        [TestCase("0,695478376*1,75849488", "0,695478376 1,75849488 * ")]
        [TestCase("((((8))))", "8 ")]
        [TestCase("1+2+3+4+5+6", "1 2 + 3 + 4 + 5 + 6 + ")]
        [TestCase("598-(6-(-97-(8-(9--93)*4-6)*2))", "598 6 -97 8 9 -93 - 4 * - 6 - 2 * - - - ")]
        public void CorrectConversionTest(string infixExpression, string expected)
        {
            var postfixList = InfixToPostfixConverter.Convert(infixExpression);
            string postfixExpression = "";
            foreach (var unit in postfixList)
            {
                postfixExpression += unit + " ";
            }
            Assert.AreEqual(expected, postfixExpression);
        }
    }
}