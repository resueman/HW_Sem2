using NUnit.Framework;
using Task2;
using System;

namespace Tests
{
    public class HeroBehaviourTests
    {
        private EventLoop eventLoop;

        [SetUp]
        public void Initialization()
        {
            eventLoop = new EventLoop();
            Map.CreateMap("TestMap1.txt");
            _ = new Hero(Map.HeroStartPointLeft, Map.HeroStartPointTop);
        }

        [Test]
        public void RecognizeDownBorder()
        {
            for (int i = 0; i < 5; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.DownArrow);
            }
            Assert.AreEqual(2, Hero.LeftPosition);
            Assert.AreEqual(2, Hero.TopPosition);
        }

        [Test]
        public void RecognizeRightBorder()
        {
            eventLoop.ProcessKey(ConsoleKey.DownArrow);
            for (int i = 0; i < 10; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.RightArrow);
            }
            Assert.AreEqual(9, Hero.LeftPosition);
            Assert.AreEqual(2, Hero.TopPosition);
        }

        [Test]
        public void RecognizeTopBorder()
        {
            for (int i = 0; i < 10; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.UpArrow);
            }
            Assert.AreEqual(2, Hero.LeftPosition);
            Assert.AreEqual(1, Hero.TopPosition);
        }

        [Test]
        public void RecognizeLeftBorder()
        {
            for (int i = 0; i < 12; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.RightArrow);
            }
            eventLoop.ProcessKey(ConsoleKey.UpArrow);
            for (int i = 0; i < 10; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.LeftArrow);
            }
            Assert.AreEqual(14, Hero.LeftPosition);
            Assert.AreEqual(0, Hero.TopPosition);
        }

        [Test]
        public void GoBeyondTheLeftConsoleBorder()
        {
            for (int i = 0; i < 10; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.LeftArrow);
            }
            Assert.AreEqual(0, Hero.LeftPosition);
            Assert.AreEqual(1, Hero.TopPosition);
        }

        [Test]
        public void GoBeyondTheTopConsoleBorder()
        {
            eventLoop.ProcessKey(ConsoleKey.LeftArrow);
            for (int i = 0; i < 10; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.UpArrow);
            }
            Assert.AreEqual(1, Hero.LeftPosition);
            Assert.AreEqual(0, Hero.TopPosition);
        }

        [Test]
        public void GoBeyondTheRightConsoleBorder()
        {
            for (int i = 0; i < Map.IsBorder.GetLength(0) + Map.resizeMapIndex; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.RightArrow);
            }
            Assert.AreEqual(Map.IsBorder.GetLength(0) + Map.resizeMapIndex - 1, Hero.LeftPosition);
            Assert.AreEqual(1, Hero.TopPosition);
        }

        [Test]
        public void GoBeyondTheDownConsoleBorder()
        {
            for (int i = 0; i < 4; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.RightArrow);
            }
            for (int i = 0; i < 100; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.DownArrow);
            }
            Assert.AreEqual(6, Hero.LeftPosition);
            Assert.AreEqual(Map.resizeMapIndex - 1, Hero.TopPosition);
        }
    }
}