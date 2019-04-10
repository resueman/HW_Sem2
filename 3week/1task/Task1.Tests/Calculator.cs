using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.Tests
{
    [TestClass]
    public class Calculator
    {
        private StackList<int> stackList;
        private StackArray<int> stackArray;
        private Task1.Calculator calculatorList;
        private Task1.Calculator calculatorArray;

        [TestInitialize]
        public void Initialization()
        {
            stackList = new StackList<int>();
            stackArray = new StackArray<int>();
            calculatorList = new Task1.Calculator(stackList);
            calculatorArray = new Task1.Calculator(stackArray);
        }

        [TestMethod]
        public void OneSubtractionOfPositive()
        {
            Assert.AreEqual(21, calculatorList.Calculation("39 18 -"));
            Assert.AreEqual(21, calculatorArray.Calculation("39 18 -"));
        }

        [TestMethod]
        public void OneSubtractionOfNegativeWhereFirstLessThanSecond()
        {
            Assert.AreEqual(-54, calculatorList.Calculation("-99 -45 -"));
            Assert.AreEqual(-54, calculatorArray.Calculation("-99 -45 -"));
        }

        [TestMethod]
        public void OneSubtractionOfNegativeWhereSecondLessThanFirst()
        {
            Assert.AreEqual(36, calculatorList.Calculation("-9 -45 -"));
            Assert.AreEqual(36, calculatorArray.Calculation("-9 -45 -"));
        }

        [TestMethod]
        public void ManySubtractionsOfPositive()
        {
            Assert.AreEqual(-39, calculatorList.Calculation("7 49 25 - - 14 - 13 8 3 - - -"));
            Assert.AreEqual(-39, calculatorArray.Calculation("7 49 25 - - 14 - 13 8 3 - - -"));
        }

        [TestMethod]
        public void ManySubtractionsOfNegative()
        {
            Assert.AreEqual(-21, calculatorList.Calculation("-48 -9 - -1 - -10 - -7 -"));
            Assert.AreEqual(-21, calculatorArray.Calculation("-48 -9 - -1 - -10 - -7 -"));
        }

        [TestMethod]
        public void ManySubtractionsOfPositiveAndNegative()
        {
            Assert.AreEqual(-164, calculatorList.Calculation("-9 8 -23 10 8 -20 -15 10 20 37 -100 - - - - - - - - - -"));
            Assert.AreEqual(-164, calculatorArray.Calculation("-9 8 -23 10 8 -20 -15 10 20 37 -100 - - - - - - - - - -"));
        }

        [TestMethod]
        public void SubtractNegativeFromZeroAndViseVersa()
        {
            Assert.AreEqual(13, calculatorList.Calculation("0 -13 -"));
            Assert.AreEqual(13, calculatorArray.Calculation("0 -13 -"));

            Assert.AreEqual(-8, calculatorList.Calculation("-8 0 -"));
            Assert.AreEqual(-8, calculatorArray.Calculation("-8 0 -"));
        }

        [TestMethod]
        public void SubtractPositiveFromZeroAndViseVersa()
        {
            Assert.AreEqual(-18, calculatorList.Calculation("0 18 -"));
            Assert.AreEqual(-18, calculatorArray.Calculation("0 18 -"));

            Assert.AreEqual(22, calculatorList.Calculation("22 0 -"));
            Assert.AreEqual(22, calculatorArray.Calculation("22 0 -"));
        }

        [TestMethod]
        public void SubtractZeroFromZero()
        {
            Assert.AreEqual(0, calculatorList.Calculation("0 0 -"));
            Assert.AreEqual(0, calculatorArray.Calculation("0 0 -"));
        }

        [TestMethod]
        public void BigNumbersSubtraction()
        {
            Assert.AreEqual(-101000000, calculatorList.Calculation("-1000001 99999999 -"));
            Assert.AreEqual(-101000000, calculatorArray.Calculation("-1000001 99999999 -"));
        }

        [TestMethod]
        public void OneAdditionOfPositive()
        {
            Assert.AreEqual(20, calculatorList.Calculation("11 9 +"));
            Assert.AreEqual(20, calculatorArray.Calculation("11 9 +"));
        }

        [TestMethod]
        public void OneAdditionOfNegative()
        {
            Assert.AreEqual(-17, calculatorList.Calculation("-9 -8 +"));
            Assert.AreEqual(-17, calculatorArray.Calculation("-9 -8 +"));
        }

        [TestMethod]
        public void OneAdditionOfPositiveAndNegativeWhereAbsOfPositiveLess()
        {
            Assert.AreEqual(-11, calculatorList.Calculation("-19 8 +"));
            Assert.AreEqual(-11, calculatorArray.Calculation("-19 8 +"));
        }

        public void OneAdditionOfPositiveAndNegativeWhereAbsOfNegativeLess()
        {
            Assert.AreEqual(9, calculatorList.Calculation("-9 18 +"));
            Assert.AreEqual(9, calculatorArray.Calculation("-9 18 +"));
        }

        [TestMethod]
        public void ManyAdditionOperationsOfPositiveAndNegative()
        {
            Assert.AreEqual(13, calculatorList.Calculation("18 -23 56 -22 33 -55 99 -24 -36 -52 19 + + + + + + + + + +"));
            Assert.AreEqual(13, calculatorArray.Calculation("18 -23 56 -22 33 -55 99 -24 -36 -52 19 + + + + + + + + + +"));
        }

        [TestMethod]
        public void AdditionOfNegativeNumbers()
        {
            Assert.AreEqual(-155, calculatorList.Calculation("-56 -99 +"));
            Assert.AreEqual(-155, calculatorArray.Calculation("-56 -99 +"));
        }

        [TestMethod]
        public void MultiplyTwoPositive()
        {
            Assert.AreEqual(56, calculatorList.Calculation("7 8 *"));
            Assert.AreEqual(56, calculatorArray.Calculation("7 8 *"));
        }

        [TestMethod]
        public void MiltiplyTwoNegative()
        {
            Assert.AreEqual(99, calculatorList.Calculation("-9 -11 *"));
            Assert.AreEqual(99, calculatorArray.Calculation("-9 -11 *"));
        }

        [TestMethod]
        public void MultiplyPositiveAndNegative()
        {
            Assert.AreEqual(-27, calculatorList.Calculation("-3 9 *"));
            Assert.AreEqual(-27, calculatorArray.Calculation("9 -3 *"));
        }

        [TestMethod]
        public void MultiplyOnZero()
        {
            Assert.AreEqual(0, calculatorList.Calculation("9 0 *"));
            Assert.AreEqual(0, calculatorArray.Calculation("-9 0 *"));
        }

        [TestMethod]
        public void MultiplyBigNumbers()
        {
            Assert.AreEqual(673612875, calculatorList.Calculation("76765 8775 *"));
            Assert.AreEqual(673612875, calculatorArray.Calculation("76765 8775 *"));
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
