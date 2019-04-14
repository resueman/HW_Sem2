using NUnit.Framework;
using System.IO;
using Task2;

namespace Tests
{
    public class MapTests
    {
        private bool[,] TestIsBorder;

        [Test]
        public void FileWithMapNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(() => Map.CreateMap("IAmNotExist.txt"));
        }

        [Test]
        [TestCase("IncorrectMap1.txt")]
        [TestCase("IncorrectMap2.txt")]
        public void IncorrectMapTest(string fileName)
        {
            Assert.Throws<IncorrectMapException>(() => Map.CreateMap(fileName));
        }

        private void TestWallsInitialize()
        {
            TestIsBorder = new bool[7, 14];
            for (int i = 0; i < TestIsBorder.GetLength(0); ++i)
            {
                for (int j = 0; j < TestIsBorder.GetLength(1); ++j)
                {
                    TestIsBorder[i, j] = false;
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
                    TestIsBorder[i, wallsCoords[i][j]] = true;
                }
            }
        }

        [Test]
        public void IsCorrectBorderRecognition()
        {
            TestWallsInitialize();
            Map.CreateMap("TestMap1.txt");
            for (int i = 0; i < TestIsBorder.GetLength(0); ++i)
            {
                for(int j = 0; j < TestIsBorder.GetLength(1); ++j)
                {
                    Assert.AreEqual(TestIsBorder[i, j], Map.IsBorder[i, j]);
                }
            }
        }

        [Test]
        [TestCase("TestMap1.txt", 1, 2)]
        [TestCase("TestMap2.txt", 4, 6)]
        [TestCase("TestMap3.txt", 21, 43)]
        public void IsCorrectHeroPosition(string fileName, int topPoint, int leftPoint)
        {
            Map.CreateMap(fileName);
            Assert.AreEqual(Map.HeroStartPointTop, topPoint);
            Assert.AreEqual(Map.HeroStartPointLeft, leftPoint);
        }
    }
}