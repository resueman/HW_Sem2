using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PriorityQueue
{
    [TestClass]
    public class PriorityQueueTests
    {
        private PriorityQueue<string> queue;
        private PriorityQueue<string> emptyQueue;

        [TestInitialize]
        public void Initialization()
        {
            queue = new PriorityQueue<string>();
            emptyQueue = new PriorityQueue<string>();
            queue.Enqueue("O", 78);//
            queue.Enqueue("L", 80);//
            queue.Enqueue("E", 99);//
            queue.Enqueue("!", 4);//
            queue.Enqueue("R", 44);//
            queue.Enqueue("H", 100);//
            queue.Enqueue("W", 60);//
            queue.Enqueue("L", 94);//
            queue.Enqueue("O", 57);//
            queue.Enqueue("L", 23);//
            queue.Enqueue("D", 5);//
        }

        [TestMethod]
        public void CheckEnqueue()
        {
            Assert.AreEqual("H E L L O W O R L D ! ", queue.GetStringOfQueueElements());
        }

        [TestMethod]
        public void AddToHead()
        {
            queue.Enqueue(" ", 2);
            Assert.AreEqual("  H E L L O W O R L D ! ", queue.GetStringOfQueueElements());
        }

        [TestMethod]
        public void AddToTail()
        {
            queue.Enqueue("!", 1000);
            Assert.AreEqual("H E L L O W O R L D ! ! ", queue.GetStringOfQueueElements());
        }

        [TestMethod]
        public void CheckOneDequeue()
        {
            queue.Dequeue();
            Assert.AreEqual("E L L O W O R L D ! ", queue.GetStringOfQueueElements());
        }

        [TestMethod]
        public void CheckThreeDequeue()
        {
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            Assert.AreEqual("L O W O R L D ! ", queue.GetStringOfQueueElements());
        }

        [TestMethod]
        [ExpectedException(typeof(DequeueFromEmptyQueueException))]
        public void DequeueFromEmptyQueue()
        {
            emptyQueue.Dequeue();
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectPriorityException))]
        public void EnqueueIncorrectPrioritet()
        {
            queue.Enqueue("jhjfkj", -1);
        }
    }
}
