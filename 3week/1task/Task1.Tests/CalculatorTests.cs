using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        private StackList<int> stackList;
        private StackArray<int> stackArray;
        private Calculator calculatorList;
        private Calculator calculatorArray;

        [TestInitialize]
        public void Initialization()
        {
            stackList = new StackList<int>();
            stackArray = new StackArray<int>();
            calculatorList = new Calculator(stackList);
            calculatorArray = new Calculator(stackArray);
        }

        [DataRow(-8, "-8 0 -")]
        [DataRow(21, "39 18 -")]
        [DataRow(-54, "-99 -45 -")]
        [DataRow(36, "-9 -45 -")]
        [DataRow(-39, "7 49 25 - - 14 - 13 8 3 - - -")]
        [DataRow(-21, "-48 -9 - -1 - -10 - -7 -")]
        [DataRow(-164, "-9 8 -23 10 8 -20 -15 10 20 37 -100 - - - - - - - - - -")]
        [DataRow(13, "0 -13 -")]
        [DataRow(-18, "0 18 -")]
        [DataRow(22, "22 0 -")]
        [DataRow(0, "0 0 -")]
        [DataRow(-101000000, "-1000001 99999999 -")]
        [DataRow(20, "11 9 +")]
        [DataRow(-17, "-9 -8 +")]
        [DataRow(-11, "-19 8 +")]
        [DataRow(9, "-9 18 +")]
        [DataRow(13, "18 -23 56 -22 33 -55 99 -24 -36 -52 19 + + + + + + + + + +")]
        [DataRow(-155, "-56 -99 +")]
        [DataRow(56, "7 8 *")]
        [DataRow(99, "-9 -11 *")]
        [DataRow(-27, "-3 9 *")]
        [DataRow(0, "9 0 *")]
        [DataRow(673612875, "76765 8775 *")]

        [DataTestMethod]
        public void TestCalculator(int result, string input)
        {
            Assert.AreEqual(result, calculatorList.Calculation(input));
            Assert.AreEqual(result, calculatorArray.Calculation(input));
        }

        [ExpectedException(typeof(DivisionByZeroException))]
        public void DevideByZeroStackArrayTest1()
        {
            calculatorArray.Calculation("8 9 + 0 /");
        }

        [ExpectedException(typeof(DivisionByZeroException))]
        public void DevideByZeroStackArrayTest2()
        {
            calculatorArray.Calculation("5 7 + 2 * 3 + 7 3 2 * 1 + - /");
        }

        [ExpectedException(typeof(DivisionByZeroException))]
        public void DevideByZeroStackListTest1()
        {
            calculatorList.Calculation("8 9 + 0 /");
        }

        [ExpectedException(typeof(DivisionByZeroException))]
        public void DevideByZeroStackListTest2()
        {
            calculatorList.Calculation("5 7 + 2 * 3 + 7 3 2 * 1 + - /");
        }

        [ExpectedException(typeof(NotPostfixFormException))]
        public void IncorrectExpressionStackIsNotEmptyAfterCalculation()
        {
            calculatorList.Calculation("9 8 9 +");
        }

        [ExpectedException(typeof(NotPostfixFormException))]
        public void IncorrectExpressionMismatchedOperandsAndOperators()
        {
            calculatorList.Calculation("8 + 9");
        }

        [ExpectedException(typeof(NotPostfixFormException))]
        public void IncorrectSymbolInExpression()
        {
            calculatorList.Calculation("9 o 8 +");
        }
    }
}
