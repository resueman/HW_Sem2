using System;
using NUnit.Framework;

namespace Calculator.Tests
{
    class ExpressionBuilderTests
    {
        ExpressionBuilder expressionBuilder;

        [SetUp]
        public void Initialization()
        {
            expressionBuilder = new ExpressionBuilder();
        }

        private void Add(char symbol)
        {
            if (char.IsDigit(symbol))
            {
                expressionBuilder.AddDigit(symbol);
                return;
            }
            if (Validators.IsOperator(symbol.ToString()))
            {
                expressionBuilder.AddOperator(symbol);
                return;
            }
            switch (symbol)
            {
                case '(':
                    expressionBuilder.AddOpeningBracket();
                    break;
                case ')':
                    expressionBuilder.AddClosingBracket();
                    break;
                case ',':
                    expressionBuilder.AddComma();
                    break;
                case 'D':
                    expressionBuilder.DeleteLastDigit();
                    break;
                default:
                    throw new ArgumentException("Unexpected symbol in tests!");
            }
        }

        private void Compare(string expression, string expected)
        {
            foreach (var symbol in expression)
            {
                Add(symbol);
            }
            Assert.AreEqual(expected, expressionBuilder.Expression);
        }

        [Test]
        [TestCase("/99/", "99/")]
        [TestCase("--8*-----9+++", "-8*-9+")]
        [TestCase("0+++8889++++++", "0+8889+")]
        [TestCase("-----867-------98-", "-867--98-")]
        [TestCase("/////867///////98/", "867/98/")]
        [TestCase("****867*******98*", "867*98*")]
        [TestCase("++++867+++++98+", "867+98+")]
        [TestCase("*8**576****9/////78/*+-87*+-/6+", "8*576*9/78/-87*-6+")]
        [TestCase("+-94++*23,/7/9+-12----10/-8*", "-94+23/7/9+-12--10/-8*")]
        [TestCase("(+", "(")]
        [TestCase("(+-90*", "(-90*")]
        [TestCase("7879+(8797***9)+++", "7879+(8797*9)+")]
        [TestCase("354*98-(-------68----87-", "354*98-(-68--87-")]
        [TestCase("(((((989-9)/*-9)-98)+-46)/8------9)*45-99+", "(((((989-9)/-9)-98)+-46)/8--9)*45-99+")]
        public void AddOperatorTest(string expression, string expected)
            => Compare(expression, expected);

        [Test]
        [TestCase("848", "")]
        [TestCase("848+", "848+")]
        [TestCase("972,8+", "972,8+")]
        [TestCase("972,8", "")]
        [TestCase(",4", "")]
        [TestCase(",4-", "0,4-")]
        [TestCase("3456+", "3456+")]
        [TestCase("-", "")]
        [TestCase("-653", "")]
        [TestCase("-653+", "-653+")]
        [TestCase("784,,,,,98,765+", "784,98765+")]
        [TestCase("934,,,,,,,,+", "934+")]
        [TestCase("934,(,),+,4,---75,,,,,3,,,,,2,,3+", "934+0,4--75,323+")]
        [TestCase("093,00/", "093,00/")]
        [TestCase("000000*", "0*")]
        [TestCase("-000000*", "-0*")]
        [TestCase("6543,,,,,,+", "6543+")]
        [TestCase(",,,,,8-", "0,8-")]
        [TestCase("-,9-", "-0,9-")]
        [TestCase(",+", "0+")]
        [TestCase("(,5+", "(0,5+")]
        [TestCase("(-,33442,/432-", "(-0,33442/432-")]
        [TestCase("(4-5),26,56,343,,,+", "(4-5)+")]
        [TestCase("(5-5,5)984759)(7483", "(5-5,5)")]
        [TestCase("((5-10)984759+)7483-3,)9876,02", "((5-10)+7483-3)")]
        [TestCase("(983-2872,,,)", "(983-2872)")]
        public void AddNumberTest(string expression, string expected)
            => Compare(expression, expected);

        [Test]
        [TestCase("(((((()))))))", "((((((")]
        [TestCase("))))-8-", "-8-")]
        [TestCase("-9)", "")]
        [TestCase("-9)*", "-9*")]
        [TestCase("-984+4555-)(484-", "-984+4555-(484-")]
        [TestCase("((5-7)-8)+9)", "((5-7)-8)+")]
        [TestCase("((5-7)-8)+9)*", "((5-7)-8)+9*")]
        [TestCase(",(-", "0-")]
        [TestCase(",)-", "0-")]
        [TestCase("4*545(6867+984)+", "4*5456867+984+")]
        [TestCase("()()(6-7)(((+(((65,))))))", "(((6-7)+(((65)))))")]
        [TestCase("837*))))(((((", "837*(((((")]
        [TestCase("-(,84(+++((67-77)", "-0,84+((67-77)")]
        [TestCase(",,,,,(4-4),,9484,59985*-3-", "0,4-4,948459985*-3-")]
        public void AddBracketsTest(string expression, string expected)
            => Compare(expression, expected);

        [TestCase("987,9DD90,88-", "98790,88-")]
        [TestCase("87DDDDDDDD11-", "11-")]
        [TestCase("76+87DDDDDD98+", "76+98+")]
        [TestCase("(87,9DDD+", "(8+")]
        [TestCase("(7-9)DDDD,9-", "(7-9)-")]
        [TestCase("989,D,D8000,D1,7-", "98980001,7-")]
        [TestCase("(8-9)DDD", "(8-9)")]
        [TestCase("((((8DDDDD", "((((")]
        [TestCase("(876DDDDDDD", "(")]
        [TestCase("(8687+DDDD", "(8687+")]
        [TestCase("(667-98)DDDD", "(667-98)")]
        public void DeleteLastTests(string expression, string expected)
            => Compare(expression, expected);

        [TestCase("")]
        [TestCase("879+")]
        [TestCase("9879+9878")]
        [TestCase("87689,9877")]
        [TestCase("(987-68)")]
        [TestCase("(((((((78,7-97)-790)78988879*867))")]
        [TestCase("((((")]
        [TestCase("345678")]
        public void ClearTests(string expression)
        {
            foreach (var symbol in expression)
            {
                Add(symbol);
            }
            expressionBuilder.Clear();
            Assert.AreEqual(expressionBuilder.Expression, "");
            Assert.AreEqual(expressionBuilder.CurrentNumber, "");
        }

        [Test]
        [TestCase("879+", "879+")]
        [TestCase("9879+9878", "9879+")]
        [TestCase("87689,9877", "")]
        [TestCase("(987-68)", "(987-68)")]
        [TestCase("9+98,83+,", "9+98,83+")]
        [TestCase(",", "")]
        public void ClearEntryTests(string expression, string expected)
            => Compare(expression, expected);

        [Test]
        public void ChangeSignTests()
        {
            string expression = "89+82-83787";
            foreach (var symbol in expression)
            {
                Add(symbol);
            }
            expressionBuilder.ChangeSign();
            expressionBuilder.Complete();
            Assert.AreEqual("89+82--83787", expressionBuilder.Expression);
        }

        [Test]
        [TestCase("(5*983+", "(5*983+", false)]
        [TestCase("((((((837+89)", "((((((837+89))))))", true)]
        [TestCase("(937-83)+(38+83", "(937-83)+(38+83)", true)]
        [TestCase("0,03", "0,03", true)]
        [TestCase("8+", "8+", false)]
        [TestCase("7+(", "7+(", false)]
        [TestCase("782,", "782", true)]
        [TestCase("-7", "-7", true)]
        public void CompleteExpressionTests(string expression, string expected, bool isComleted)
        {
            foreach (var symbol in expression)
            {
                Add(symbol);
            }
            Assert.AreEqual(isComleted, expressionBuilder.Complete());
            Assert.AreEqual(expected, expressionBuilder.Expression);
        }

        [Test]
        [TestCase("4+9", "4+3")]
        [TestCase("9*9*", "9*9*")]
        [TestCase("98-(", "98-(")]
        [TestCase("98+(73-8)", "98+(73-8)")]
        [TestCase("-4", "-4")]
        public void AddSquareRootTests(string expression, string expected)
        {
            foreach (var symbol in expression)
            {
                Add(symbol);
            }
            expressionBuilder.AddSquareRoot();
            expressionBuilder.Complete();
            Assert.AreEqual(expected, expressionBuilder.Expression);
        }
    }
}
