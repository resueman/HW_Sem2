using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1
{
    [TestClass]
    public class Tests
    {
        public bool IsOperator(char symbol)
            => symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';

        List<char> listOfChars;

        List<string> Slogans = new List<string> { "Freedom", "Equality", "Brotherhood",
            "Cuba - yes", "Yankee - no", "Proletarians of all countries", "Unite",
            "Wir", "Sind", "Das", "Volk" };

        List<int> listOfNumbers;

        [TestInitialize]
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
            
        }

        [TestMethod]
        public void MapForStringType()
        {
            List<string> result = new List<string> { "Freedom!", "Equality!", "Brotherhood!",
            "Cuba - yes!", "Yankee - no!", "Proletarians of all countries!", "Unite!",
            "Wir!", "Sind!", "Das!", "Volk!" };
            Slogans = Functions.Map(Slogans, word => word + "!");
            for(int i = 0; i < Slogans.Count; ++i)
            {
                Assert.AreEqual(result[i], Slogans[i]);
            }

        }

        [TestMethod]
        public void MapForIntType()
        {
            List<int> result = new List<int> { 2, 6, 14, -4, 0, 30, 2000000, -86000000 };
            listOfNumbers = Functions.Map(listOfNumbers, x => x * 2);
            for (int i = 0; i < listOfNumbers.Count; ++i)
            {
                Assert.AreEqual(listOfNumbers[i], result[i]);
            }
        }

        [TestMethod]
        public void TestMethod()
        {

        }
    }
}
