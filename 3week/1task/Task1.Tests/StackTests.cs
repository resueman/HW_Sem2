using NUnit.Framework;

namespace Task1.Tests
{
    public class StackArrayTests
    {
        StackArray<int> stack;

        [SetUp]
        public void Initialization()
        {
            stack = new StackArray<int>();
        }

        [Test]
        public void PopFromEmptyStack()
        {
            Assert.Throws<StackIsEmptyException>(() => { stack.Pop(); });
        }

        [Test]
        public void PopTestWithTwoElemets()
        {
            stack.Push(666);
            stack.Push(-666);
            Assert.AreEqual(-666, stack.Pop());
            Assert.AreEqual(666, stack.Pop());
        }

        [Test]
        public void PushAndPopTestsWithManyElements()
        {
            for (int i = -1000000; i < 1000001; ++i)
            {
                stack.Push(i);
            }
            for (int i = 1000000; i > -1000001; --i)
            {
                Assert.AreEqual(i, stack.Pop());
            }
        }

        [Test]
        public void GetTopOfEmptyStack()
        {
            Assert.Throws<StackIsEmptyException>(() => { stack.Top(); });
        }

        [Test]
        public void GetTopOfNotEmptyStack()
        {
            stack.Push(100);
            stack.Push(222);
            Assert.AreEqual(222, stack.Top());
        }

        [Test]
        public void CheckThatTopDoesNotPop()
        {
            stack.Push(111);
            stack.Push(222);
            stack.Push(333);
            Assert.AreEqual(333, stack.Top());
            stack.Pop();
            Assert.AreEqual(222, stack.Top());
        }

        [Test]
        public void CheckIsEmptyMethodStack()
        {
            Assert.IsTrue(stack.IsEmpty());
            stack.Push(666);
            Assert.IsFalse(stack.IsEmpty());
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty());
        }
    }
}
