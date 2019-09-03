using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Calculator.Tests
{
    /// <summary>
    /// Tests  whether the value of the expression matches
    /// the result calculated by the postfix calculator
    /// </summary>
    class PostfixCalculatorTests
    {
        private static List<string> Initialization(string currentExpression)
        {
            var regularExpression = new Regex(@"\-\d+(\,)?\d*|\d+(\,)?\d*|[-+*/()]");
            var matches = regularExpression.Matches(currentExpression);
            var expression = new List<string>();
            foreach (Match match in matches)
            {
                expression.Add(match.Value);
            }
            return expression;
        }

        private static bool CompareDouble(double first, double second)
            => Math.Abs(first - second) < 0.0000001;

        [Test]
        [TestCase("5 8 + 91 * 26 6 8 - 3 * 5 46 19 4 * + * - / - ", 1183.04220779220)]
        [TestCase("-7 -8 - -9 -15 * -8 / + ", -15.875)]
        [TestCase("9 -7 -10 - * -27 -3 -9 * / + ", 26)]
        [TestCase("0,0000007 768,97 + -89,654 - ", 858.6240007)]
        [TestCase("5 6 7 - 8 3 * + 77 * - ", -1766)]
        [TestCase("9 8 - -7 * ", -7)]
        [TestCase("809 432123 * 657 * ", 229678992099)]
        [TestCase("-0,00000 8 + ", 8)]
        [TestCase("-7 9 7 6 + 9 * 5 - 4 * 6 + * 7 * 5 - 6 / 7 + 8 * - -9 - 1 + ", -38182.3333333333)]
        [TestCase("0,695478376 1,75849488 - ", -1.063016504)]
        [TestCase("0,695478376 1,75849488 * ", 1.22299516334671)]
        [TestCase("8", 8)]
        [TestCase("1 2 + 3 + 4 + 5 + 6 + ", 21)]
        [TestCase("598 6 -97 8 9 -93 - 4 * - 6 - 2 * - - - ", 1307)]
        [TestCase("85 -8,84 * -48,83 * 95 690 59 4 4 9,8 874 958 - / 9 * + 4 - * - 48,84 + * * + 738091 / ", 10.0000038776)]
        [TestCase("8 -7 -98 88 - -19 - -9 -86 / + -7 + -9 * - - -400 / ", -3.95014534884)]
        [TestCase("-9 -9 -87 + - -8 -9 - - ", 86)]
        public void CalculateCorrectExpressionTest(string currentExpression, double expected)
        {
            var expression = Initialization(currentExpression);
            var result = PostfixCalculator.Calculate(expression);
            Assert.IsTrue(CompareDouble(expected, result));
        }

        [Test]
        [TestCase("7 0 / ")]
        [TestCase("8 9 + 9 9 - /")]
        [TestCase("97 000,000 /")]
        [TestCase("8 0,0 /")]
        public void DivisionByZeroTest(string currentExpression)
        {
            var expression = Initialization(currentExpression);
            Assert.Throws<DivideByZeroException>(() => PostfixCalculator.Calculate(expression));
        }

        [Test]
        [TestCase("7 + 90 ")]
        [TestCase("8 9 9 + 9 9 + /")]
        [TestCase("0 9 7 + + +")]
        public void NotAPostfixFormTest(string currentExpression)
        {
            var expression = Initialization(currentExpression);
            Assert.Throws<ArgumentException>(() => PostfixCalculator.Calculate(expression));
        }
    }
}
