using NUnit.Framework;

namespace Task2.Tests
{
    class HeroBehaviourTests
    {
        private Hero hero;

        [SetUp]
        public void Initialization()
        {
            hero = new Hero(0, 0);
        }

        [Test]
        public void MoveLeftTest()
        {
            for (int i = 0; i < 100; ++i)
            {
                hero.ChangeHeroCoordinates(-1, 0);
            }
            Assert.AreEqual(-100, hero.LeftPosition);
            Assert.AreEqual(0, hero.TopPosition);
        }

        [Test]
        public void MoveRightTest()
        {
            for (int i = 0; i < 100; ++i)
            {
                hero.ChangeHeroCoordinates(1, 0);
            }
            Assert.AreEqual(100, hero.LeftPosition);
            Assert.AreEqual(0, hero.TopPosition);
        }

        [Test]
        public void MoveUpTest()
        {
            for (int i = 0; i < 100; ++i)
            {
                hero.ChangeHeroCoordinates(0, -1);
            }
            Assert.AreEqual(0, hero.LeftPosition);
            Assert.AreEqual(-100, hero.TopPosition);
        }

        [Test]
        public void MoveDownTest()
        {
            for (int i = 0; i < 100; ++i)
            {
                hero.ChangeHeroCoordinates(0, 1);
            }
            Assert.AreEqual(0, hero.LeftPosition);
            Assert.AreEqual(100, hero.TopPosition);
        }
    }
}
