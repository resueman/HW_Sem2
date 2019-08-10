using NUnit.Framework;
using Task2;
using System;

/// <summary>
/// Tests hero behavior, its reaction on walls and borders of area possible to play on
/// </summary>
namespace Tests
{
    public class HeroBehaviourTests
    {
        private EventLoop eventLoop;
        private Game game;

        private void Subscribe()
        {
            eventLoop.LeftHandler += game.OnLeft;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.TopHandler += game.OnTop;
            eventLoop.DownHandler += game.OnDown;
        }

        [SetUp]
        public void Initialization()
        {
            game = new Game("TestMap1.txt");
            eventLoop = new EventLoop();
            Subscribe();
        }

        [Test]
        public void RecognizeDownBorder()
        {
            for (int i = 0; i < 5; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.DownArrow);
            }
            Assert.AreEqual(2, game.hero.LeftPosition);
            Assert.AreEqual(2, game.hero.TopPosition);
        }

        [Test]
        public void RecognizeRightBorder()
        {
            eventLoop.ProcessKey(ConsoleKey.DownArrow);
            for (int i = 0; i < 10; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.RightArrow);
            }
            Assert.AreEqual(9, game.hero.LeftPosition);
            Assert.AreEqual(2, game.hero.TopPosition);
        }

        [Test]
        public void RecognizeTopBorder()
        {
            for (int i = 0; i < 10; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.UpArrow);
            }
            Assert.AreEqual(2, game.hero.LeftPosition);
            Assert.AreEqual(1, game.hero.TopPosition);
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
            Assert.AreEqual(14, game.hero.LeftPosition);
            Assert.AreEqual(0, game.hero.TopPosition);
        }

        [Test]
        public void GoBeyondTheLeftConsoleBorder()
        {
            for (int i = 0; i < 10; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.LeftArrow);
            }
            Assert.AreEqual(0, game.hero.LeftPosition);
            Assert.AreEqual(1, game.hero.TopPosition);
        }

        [Test]
        public void GoBeyondTheTopConsoleBorder()
        {
            eventLoop.ProcessKey(ConsoleKey.LeftArrow);
            for (int i = 0; i < 10; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.UpArrow);
            }
            Assert.AreEqual(1, game.hero.LeftPosition);
            Assert.AreEqual(0, game.hero.TopPosition);
        }

        [Test]
        public void GoBeyondTheRightConsoleBorder()
        {
            for (int i = 0; i < 10 + Map.IsBorder.GetLength(0) + Map.resizeMapIndex; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.RightArrow);
            }
            Assert.AreEqual(Map.IsBorder.GetLength(0) + Map.resizeMapIndex - 1, game.hero.LeftPosition);
            Assert.AreEqual(1, game.hero.TopPosition);
        }

        [Test]
        public void GoBeyondTheDownConsoleBorder()
        {
            for (int i = 0; i < 4; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.RightArrow);
            }
            for (int i = 0; i < 10 + Map.IsBorder.GetLength(1); ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.DownArrow);
            }
            Assert.AreEqual(6, game.hero.LeftPosition);
            Assert.AreEqual(Map.resizeMapIndex - 1, game.hero.TopPosition);
        }

        [Test]
        public void IsPossibleToNavigateAnEmptyMap()
        {
            game = new Game("EmptyMap.txt");
            Subscribe();
            for (int i = 0; i < Map.resizeMapIndex; ++i)
            {
                eventLoop.ProcessKey(ConsoleKey.RightArrow);
                eventLoop.ProcessKey(ConsoleKey.DownArrow);
            }
            Assert.AreEqual(Map.resizeMapIndex - 1, game.hero.TopPosition);
            Assert.AreEqual(Map.resizeMapIndex - 1, game.hero.LeftPosition);
        }
    }
}