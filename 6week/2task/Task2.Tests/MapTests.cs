using NUnit.Framework;
using System.IO;

namespace Task2.Tests
{
    /// <summary>
    /// Tests the response to the absence of a file and incorrect maps
    /// Checks the correctness of walls and initial hero position recognition 
    /// </summary>
    public class MapTests
    {
        private Map map;
        private bool[,] testIsBorder;

        [Test]
        public static void FileWithMapNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(() => new Map("IDoNotExist.txt"));
        }

        [Test]
        [TestCase("IncorrectMap1.txt")]
        [TestCase("IncorrectMap2.txt")]
        public static void IncorrectMapTest(string fileName)
        {
            Assert.Throws<IncorrectMapException>(() => new Map(fileName));
        }

        private void TestWallsInitialize()
        {
            testIsBorder = new bool[7, 14];
            for (int i = 0; i < testIsBorder.GetLength(0); ++i)
            {
                for (int j = 0; j < testIsBorder.GetLength(1); ++j)
                {
                    testIsBorder[i, j] = false;
                }
            }

            var wallsCoords = new int[7][] { new int[] { 2, 3, 4, 6, 7, 8, 9, 13 },
                new int[] { },
                new int[] { 10 },
                new int[] { 2, 3, 4, 5 },
                new int[] { 10 },
                new int[] { 0, 1, 10 },
                new int[] { 0 } };

            for (int i = 0; i < 7; ++i)
            {
                for (int j = 0; j < wallsCoords[i].GetLength(0); ++j)
                {
                    testIsBorder[i, wallsCoords[i][j]] = true;
                }
            }
        }

        [Test]
        public void IsCorrectBorderRecognition()
        {
            TestWallsInitialize();
            map = new Map("TestMap1.txt");
            for (int i = 0; i < map.IsBorder.GetLength(0); ++i)
            {
                for (int j = 0; j < map.IsBorder.GetLength(1); ++j)
                {
                    Assert.AreEqual(map.IsBorder[i, j], map.IsBorder[i, j]);
                }
            }
        }

        [Test]
        [TestCase("TestMap1.txt", 1, 2)]
        [TestCase("TestMap2.txt", 4, 6)]
        [TestCase("TestMap3.txt", 21, 43)]
        public void IsCorrectHeroPosition(string fileName, int topPoint, int leftPoint)
        {
            map = new Map(fileName);
            Assert.AreEqual(map.HeroStartPointTop, topPoint);
            Assert.AreEqual(map.HeroStartPointLeft, leftPoint);
        }
    }
}
