using System;
using System.Collections.Generic;
using System.Collections;

namespace Task1
{
    /// <summary>
    /// Structure to store and work with data
    /// </summary>
    /// <typeparam name="T">Type of stored data</typeparam>
    public partial class List<T> : IList<T>
    {
        private Node head;
        public int Count { get; private set; }

        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }

            public Node(T value)
            {
                Value = value;
            }
        } 
        
        public IEnumerator<T> GetEnumerator() => new ListEnumerator(head);

        IEnumerator IEnumerable.GetEnumerator() => new ListEnumerator(head);

        public T this[int index]
        {
            get
            {
                if (!IsCorrectPosition(index))
                {
                    throw new IncorrectPositionException("Can't get value of item, because index is incorrect");
                }
                return GetPreviousNodeByPosition(index + 1).Value;
            }
            set
            {
                if (!IsCorrectPosition(index))
                {
                    throw new IncorrectPositionException("Can't set item value, because index is incorrect");
                }
                GetPreviousNodeByPosition(index + 1).Value = value;
            }
        }

        public bool IsReadOnly => false;

        public bool Contains(T value)
        {
            var current = head;
            for (int i = 0; i < Count; ++i)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        private Node GetPreviousNodeByPosition(int position)
        {
            Node current = head;
            for (int i = 0; i < position - 2; ++i)
            {
                current = current.Next;
            }
            return current;
        }

        private bool IsCorrectPosition(int position)
            => !(position > Count || position < 1);

        public void RemoveAt(int position)
        {
            if (!IsCorrectPosition(position))
            {
                throw new IncorrectPositionException("Incorrect position");
            }
            if (position == 1)
            {
                head = head.Next;
            }
            else
            {
                var previousNode = GetPreviousNodeByPosition(position);
                previousNode.Next = previousNode.Next.Next;
            }
            --Count;
        }

        public bool Remove(T value)
        {
            int deletedPosition = IndexOf(value);
            if (deletedPosition == -1)
            {
                return false;
            }
            RemoveAt(deletedPosition);
            return true;
        }

        public int IndexOf(T key)
        {
            var current = head;
            for (int i = 0; i < Count; ++i)
            {
                if (key.Equals(current.Value))
                {
                    return i + 1;
                }
                current = current.Next;
            }
            return -1;
        }

        private void InsertToHead(Node newNode)
        {
            newNode.Next = head;
            head = newNode;
        }

        private void InsertNotToHead(Node newNode, int position)
        {
            var previous = GetPreviousNodeByPosition(position);
            newNode.Next = previous.Next;
            previous.Next = newNode;
        }

        public void Insert(int position, T value)
        {
            if (position > Count + 1 && position != 0 || position < 1)
            {
                throw new IncorrectPositionException("Incorrect position");
            }
            var newNode = new Node(value);
            if (position == 1)
            {
                InsertToHead(newNode);
            }
            else
            {
                InsertNotToHead(newNode, position);
            }
            ++Count;
        }

        public void Add(T value)
        {
            var current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node(value);
            ++Count;
        }

        public void Clear()
        {
            head = null;
            Count = 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
            {
                throw new IndexOutOfRangeException("Array index must be positive");
            }

            if (array.Length < Count + arrayIndex)
            {
                throw new ArgumentException("Too short array");
            }

            for (int i = 0; i < Count; ++i)
            {
                array[i + arrayIndex] = this[i];
            }
        }
    }
}
