using System;
using System.Text;

namespace PriorityQueue
{
    public class PriorityQueue<T>
    {
        private Element head;
        private Element tail;

        private class Element
        {
            public T Value { get; set; }
            public int Priority { get; set; }
            public Element Next { get; set; }

            public Element(T value, int priority, Element next)
            {
                Value = value;
                Priority = priority;
                Next = next;
            }
        }

        /// <summary>
        /// Add element to queue according to priority
        /// The more value of priority th higher it
        /// </summary>
        /// <param name="value">Value of enqueued element</param>
        /// <param name="priority">Priority of added element</param>
        public void Enqueue(T value, int priority)
        {
            if (priority < 0)
            {
                throw new IncorrectPriorityException("Priority should be a positive number");
            }
            if (head == null)
            {
                var newNode = new Element(value, priority, null);
                head = newNode;
                tail = newNode;
                return;
            }
            Element newElement;
            if (priority > head.Priority)
            {
                newElement = new Element(value, priority, head);
                head = newElement;
                return;
            }
            if (priority <= tail.Priority)
            {
                tail.Next = new Element(value, priority, null);
                tail = tail.Next;
                return;
            }
            var current = head;
            while (priority <= current.Priority && current.Next != tail)
            {
                current = current.Next;
            }
            newElement = new Element(value, priority, current.Next);
            current.Next = newElement;
        }

        /// <summary>
        /// Delete the value with the highest priority
        /// </summary>
        /// <returns>Returns value of deleted element</returns>
        public T Dequeue()
        {
            if (head == null)
            {
                throw new DequeueFromEmptyQueueException("Can't deque, queue is empty");
            }
            T deletedValue = head.Value;
            head.Value = default;
            if (head == tail)
            {
                tail.Value = default;
            }
            head = head.Next;
            return deletedValue;
        }

        public string GetStringOfQueueElements()
        {
            var stringBuilder = new StringBuilder();
            var current = head;
            while (current.Next != null)
            {
                stringBuilder.Append(current.Value + " ");
                current = current.Next;
            }
            return stringBuilder.ToString();
        }
    }
}
