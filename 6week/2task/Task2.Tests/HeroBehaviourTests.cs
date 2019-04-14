using NUnit.Framework;
using System.IO;
using Task2;
using System;

namespace Tests
{
    public class HeroBehaviourTests
    {
        private EventLoop eventLoop;
        Hero hero;

        [SetUp]
        public void Initialization()
        {
            eventLoop = new EventLoop();
            eventLoop.Run("TestMap1.txt");
            hero = new Hero(Map.HeroStartPointLeft, Map.HeroStartPointTop);
        }

        [Test]
        public void RecognizeDownBorder()
        {
            for (int i = 0; i < 5; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.DownArrow);
            }
            Assert.AreEqual(Hero.LeftPosition, 2);
            Assert.AreEqual(Hero.TopPosition, 1);
        }

        [Test]
        public void RecognizeRightBorder()
        {
            eventLoop.Run("TestMap1.txt");
            eventLoop.ProcessKey(ConsoleKey.DownArrow);
            for (int i = 0; i < 10; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.RightArrow);
            }
            Assert.AreEqual(Hero.LeftPosition, 9);
            Assert.AreEqual(Hero.TopPosition, 2);
        }

        [Test]
        public void RecognizeTopBorder()
        {
            for (int i = 0; i < 10; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.UpArrow);
            }
            Assert.AreEqual(Hero.LeftPosition, 2);
            Assert.AreEqual(Hero.TopPosition, 1);
        }

        [Test]
        public void RecognizeLeftBorder()
        {
            for (int i = 0; i < 11; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.RightArrow);
            }
            eventLoop.ProcessKey(ConsoleKey.UpArrow);
            for (int i = 0; i < 10; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.LeftArrow);
            }
            Assert.AreEqual(Hero.LeftPosition, 13);
            Assert.AreEqual(Hero.TopPosition, 0);
        }
    }
}