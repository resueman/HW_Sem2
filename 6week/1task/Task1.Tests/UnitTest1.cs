using NUnit.Framework;
using System.Collections.Generic;
using Task1;

namespace Tests
{
    public class Tests
    {
        public bool IsOperator(char symbol)
            => symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';

        List<char> listOfChars;
        List<int> listOfNumbers;

        List<string> Slogans = new List<string> { "Freedom", "Equality", "Brotherhood",
            "Cuba - yes", "Yankee - no", "Proletarians of all countries", "Unite",
            "Wir", "Sind", "Das", "Volk" };

        [Test]
        public void Initialization()
        {
            listOfNumbers = new List<int>
            {
                1,
                3,
                7,
                -2,
                0,
                15,
                1000000,
                -43000000
            };

            listOfChars = new List<char>()
            {
                'a',
                'b',
                'c',
                'f',
                'm',
                'n',
                'o',
                'k',
                'y',
                'z'
            };

        }

        [Test]
        public void MapForStringType()
        {
            List<string> result = new List<string> { "Freedom!", "Equality!", "Brotherhood!",
            "Cuba - yes!", "Yankee - no!", "Proletarians of all countries!", "Unite!",
            "Wir!", "Sind!", "Das!", "Volk!" };
            Slogans = Functions.Map(Slogans, word => word + "!");
            for (int i = 0; i < Slogans.Count; ++i)
            {
                Assert.AreEqual(result[i], Slogans[i]);
            }

        }

        [Test]
        public void MapForIntType()
        {
            List<int> result = new List<int> { 2, 6, 14, -4, 0, 30, 2000000, -86000000 };
            listOfNumbers = Functions.Map(listOfNumbers, x => x * 2);
            for (int i = 0; i < listOfNumbers.Count; ++i)
            {
                Assert.AreEqual(listOfNumbers[i], result[i]);
            }
        }

        [Test]
        public void TestMethod()
        {

        }
    }
}
