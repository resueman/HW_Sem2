using NUnit.Framework;
using Task1;

namespace Tests
{
    /// <summary>
    /// Tests calculator
    /// </summary>
    public class CalculatorTests
    {
        private Tree tree;

        [Test]
        [TestCase(9, "( - 9 0 )")]
        [TestCase(-9, "( - 0 9 )")]
        [TestCase(0, "( + 0 0 )")]
        [TestCase(0, "( + 9 -9 )")]
        [TestCase(-99, "( + -101 2 )")]
        [TestCase(34, "( * -2 -17 )")]
        [TestCase(18, "( * 2 9 )")]
        [TestCase(-44, "( * -11 4 )")]
        [TestCase(-33, "( * 11 -3 )")]
        [TestCase(4, "( / 8 2 )")]
        [TestCase(7, "( / -21 -3 )")]
        [TestCase(-8, "( / -64 8 )")]
        [TestCase(4, "( * ( + 1 1 ) 2 )")]
        [TestCase(-230, "( + ( * 7 ( - 2 ( * 3 ( + 5 7 ) ) ) ) 8 )")]
        [TestCase(99, "( * ( * ( + 2 9 ) ( - 6 3 ) ) ( + 1 2 ) )")]
        [TestCase(-883, "( - 1 ( * ( + 5 ( * 3 7 ) ) ( - ( * ( + 2 3 ) 7 ) 1 ) ) )")]
        [TestCase(24, "( - ( + 5 ( * ( + 7 3 ) 2 ) ) 1 )")]
        [TestCase(-218, "( - 5 ( - ( * ( + 6 13 ) ( - 2 ( + -9 -6 ) ) ) 100 ) )")]
        public void CorrectExpressionCalculation(int expectedResult, string line)
        {
            tree = new Tree(line);
            Assert.AreEqual(expectedResult, tree.CalculateTree());
        }

        [Test]
        [TestCase("( / 9 0 )")]
        [TestCase("( + 7 ( / ( + 8 9 ) ( - 9 9 ) ) )")]
        [TestCase("( / 9 ( + -1 1 ) )")]
        public void DivivsionByZero(string line)
        {
            tree = new Tree(line);
            Assert.Throws<DivisionByZeroException>(() => { tree.CalculateTree(); });
        }

        [Test]
        [TestCase("+ 9 9")]
        [TestCase("")]
        [TestCase("( / 9 ( + -1 1 ) ")]
        [TestCase("( _ 9 8)")]
        [TestCase("( 5 4 )")]
        [TestCase("( 7 + 9 )")]
        [TestCase("( 8 9 / )")]
        [TestCase("(+ 7 ( ( + 8 9 ) ( - 9 9 ) ) )")]
        [TestCase("(+ 7 ( / ( + 8 9 - 9 9 ) ) )")]
        public void IncorrectInput(string line)
        {
            Assert.Throws<IncorrectInputException>(() => { tree = new Tree(line); });
        }
    }
}