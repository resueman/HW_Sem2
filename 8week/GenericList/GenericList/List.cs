using System;
using System.Collections.Generic;
using System.Collections;

namespace GenericList
{
    /// <summary>
    /// Structure to store and work with data
    /// </summary>
    /// <typeparam name="T">Type of stored data</typeparam>
    public class List<T> : IList<T>
    {
        private Node head;

        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }

            public Node(T value)
            {
                Value = value;
            }

            public Node() { }
        }

        /// <summary>
        /// Gets the number of elements contained in the List<T>
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the ICollection<T> is read-only
        /// </summary>
        public bool IsReadOnly { get; private set; }

        /// <summary>
        /// Returns an enumerator that iterates through the List<T>
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<T> GetEnumerator() => new ListEnumerator(head);

        /// <summary>
        /// Returns an enumerator that iterates through the List<T>
        /// </summary>
        /// <returns>Enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => new ListEnumerator(head);

        /// <summary>
        /// List enumerator implemntation
        /// </summary>
        private class ListEnumerator : IEnumerator<T>
        {
            private readonly Node head;
            private Node current = new Node();

            public ListEnumerator(Node head)
            {
                this.head = head;
                current.Next = head;
            }

            /// <summary>
            /// Returns next node
            /// </summary>
            /// <returns> false if next node is null; otherwise true</returns>
            public bool MoveNext()
            {
                current = current.Next;
                return current != null;
            }

            /// <summary>
            /// Set enumerator to initial position(before head)
            /// </summary>
            public void Reset() => current.Next = head;

            /// <summary>
            /// Returns value of current node
            /// </summary>
            public T Current => current.Value;

            object IEnumerator.Current => current;

            /// <summary>
            /// Disposes node
            /// </summary>
            public void Dispose()
            {
                //throw new NotSupportedException("Method wasn't implemented");
            }
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by a specified predicate
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Returns the zero-based index of the first occurrence within the List<T> or a portion of it. 
        /// Returns -1 if an item that matches the conditions is not found</returns>
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
                if (!IsCorrectPosition(index + 1))
                {
                    throw new IncorrectPositionException("Can't set item value, because index is incorrect");
                }
                GetPreviousNodeByPosition(index).Value = value;
            }
        }

        /// <summary>
        /// Determines whether an element is in the List<T>
        /// </summary>
        /// <param name="value">The object to locate in the List<T></param>
        /// <returns>True if item is found in the List<T>; otherwise, fals</returns>
        public bool Contains(T value)
        {
            var current = head;
            for (int i = 0; i < Count; ++i)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        private Node GetPreviousNodeByPosition(int position)
        {
            Node current = head;
            for (int i = 0; i < position - 1; ++i)
            {
                current = current.Next;
            }
            return current;
        }

        private bool IsCorrectPosition(int position)
            => !(position >= Count || position < 0);

        /// <summary>
        /// Removes the element at the specified index of the List<T>
        /// </summary>
        /// <param name="position">The zero-based index of the element to remove</param>
        public void RemoveAt(int position)
        {
            if (!IsCorrectPosition(position))
            {
                throw new IncorrectPositionException("Incorrect position");
            }
            if (position == 0)
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
        
        /// <summary>
        /// Delete value from a list
        /// </summary>
        /// <param name="value">Value to delete</param>
        /// <returns>Returns false, if value doesn't exist, otherwise returns true</returns>
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

        /// <summary>
        /// Returns the zero-based index of the first occurrence of a value in the List<T>
        /// </summary>
        /// <param name="key">The object to locate in the List<T></param>
        /// <returns>The zero-based index of the first occurrence of item within the range of elements 
        /// in the List<T> that extends from index to the last element, if found; otherwise, -1</returns>
        public int IndexOf(T key)
        {
            var current = head;
            for (int i = 0; i < Count; ++i)
            {
                if (key.Equals(current.Value))
                {
                    return i;
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

        /// <summary>
        /// Inserts an element into the List<T> at the specified index
        /// </summary>
        /// <param name="position">The zero-based index at which item should be inserted</param>
        /// <param name="value">The object to insert</param>
        public void Insert(int position, T value)
        {
            if (position > Count || position < 0)
            {
                throw new IncorrectPositionException("Incorrect position");
            }
            var newNode = new Node(value);
            if (position == 0)
            {
                InsertToHead(newNode);
            }
            else
            {
                InsertNotToHead(newNode, position);
            }
            ++Count;
        }

        /// <summary>
        /// Adds an object to the end of the List<T>.
        /// </summary>
        /// <param name="value">Value of added element</param>
        public void Add(T value)
        {
            if (Count == 0)
            {
                head = new Node(value);
                ++Count;
                return;
            }
            var current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node(value);
            ++Count;
        }

        /// <summary>
        /// Removes all elements from the List<T>
        /// </summary>
        public void Clear()
        {
            head = null;
            Count = 0;
        }

        /// <summary>
        /// Copies the List<T> or a portion of it to an array
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List<T>.
        /// The Array must have zero-based indexing</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins</param>
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
