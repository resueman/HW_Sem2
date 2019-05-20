using System;
using System.Collections;
using System.Collections.Generic;

namespace Set
{
    /// <summary>
    /// Contains a non-repeating collection of items as a binary tree
    /// </summary>
    /// <typeparam name="T">Type of elements contained in Set</typeparam>
    public class Set<T> : ISet<T> where T : IComparable<T>
    {
        public int Count { get; private set; }

        public bool IsReadOnly { get; private set; }

        private Node root;

        private class Node
        {
            public T Key { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(T value)
            {
                Key = value;
            }
        }

        private void AscendingOrder(Node node, Queue<T> queue)
        { 
            if (node == null)
            {
                return;
            }
            if (node.Left != null)
            {
                AscendingOrder(node.Left, queue);
            }
            queue.Enqueue(node.Key);
            if (node.Right != null)
            {
                AscendingOrder(node.Right, queue);
            }
        } 

        private IEnumerator<T> Traversal()
        {
            var queue = new Queue<T>();
            AscendingOrder(root, queue);
            for (int i = 0; i < Count; ++i)
            {
                yield return queue.Dequeue();
            }
        }

        public IEnumerator<T> GetEnumerator() => Traversal();

        IEnumerator IEnumerable.GetEnumerator() => Traversal();

        private Node GetNodeByKey(Node node, T key)
        {
            if (key.CompareTo(node.Key) > 0)
            {
                if (node.Right == null)
                {
                    return null;
                }
                return GetNodeByKey(node.Right, key);
            }
            else if (key.CompareTo(node.Key) < 0)
            {
                if (node.Left == null)
                {
                    return null;
                }
                return GetNodeByKey(node.Left, key);
            }
            return node;
        }

        /// <summary>
        /// Determines whether a Set<T> object contains the specified element
        /// </summary>
        /// <param name="key">The element to locate in the Set<T> object</param>
        /// <returns>true if the Set<T> object contains the specified element; otherwise, false</returns>
        public bool Contains(T key)
        {
            if (Count == 0)
            {
                return false;
            }
            return GetNodeByKey(root, key) != null;
        }

        private void DoAdd(Node node, T key)
        {
            if (key.CompareTo(node.Key) > 0)
            {
                if (node.Right == null)
                {
                    node.Right = new Node(key);
                    return;
                }
                DoAdd(node.Right, key);
            }
            if (key.CompareTo(node.Key) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node(key);
                    return;
                }
                DoAdd(node.Left, key);
            }
        }

        /// <summary>
        /// Adds the specified element to a set
        /// </summary>
        /// <param name="key">The element to add to the set</param>
        /// <returns>true if the element is added to the hSet<T> object; false if the element is already present</returns>
        public bool Add(T key)
        {
            if (Count == 0)
            {
                root = new Node(key);
                ++Count;
                return true;
            }
            if (Contains(key))
            {
                return false;
            }
            DoAdd(root, key);
            ++Count;
            return true;
        }

        /// <summary>
        /// Adds the specified element to a set
        /// </summary>
        /// <param name="key">The element to add to the set</param>
        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        private T FindLeftSubTreeMaximum(Node node)
        {
            var temp = node;
            temp = temp.Left;
            while (temp.Right != null)
            {
                temp = temp.Right;
            }
            return temp.Key;
        }

        private void FindToRemove(ref Node node, T key)
        {
            if (key.CompareTo(node.Key) > 0)
            {
                var rightChild = node.Right;
                FindToRemove(ref rightChild, key);
            }
            else if (key.CompareTo(node.Key) < 0)
            {
                var leftChild = node.Left;
                FindToRemove(ref leftChild, key);
            }
            else
            {
                if (node.Left == null && node.Right == null)
                {
                    node = null;
                }
                else if (node.Left == null && node.Right != null)
                {
                    node = node.Right;
                }
                else if (node.Left != null && node.Right == null)
                {
                    node = node.Left;
                }
                else
                {
                    node.Key = FindLeftSubTreeMaximum(node);
                    var leftChild = node.Left;
                    FindToRemove(ref leftChild, node.Key);
                }
            }
        }

        /// <summary>
        /// Removes the specified element from a Set<T> object.
        /// </summary>
        /// <param name="key">The element to remove</param>
        /// <returns>true if the element is successfully found and removed;
        /// false if item is not found in the Set<T> object</returns>
        public bool Remove(T key)
        {
            if (Count == 0)
            {
                return false;
            }
            if (!Contains(key))
            {
                return false;
            }
            FindToRemove(ref root, key);
            --Count;
            return true;
        }

        /// <summary>
        /// Removes all elements from a Set<T> object
        /// </summary>
        public void Clear()
        {
            root = null;
            Count = 0;
        }

        /// <summary>
        /// Determines whether the current Set<T> object and a specified collection share common elements
        /// </summary>
        /// <param name="other">The collection to compare to the current Set<T> object</param>
        /// <returns>true if the Set<T> object and other share at least one common element; otherwise, false</returns>
        public bool Overlaps(IEnumerable<T> other)
        {
            foreach (var key in other)
            {
                if (Contains(key))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Modifies the current Set<T> object to contain only elements
        /// that are present in that object and in the specified collection
        /// </summary>
        /// <param name="other">The collection to compare to the current</param>
        public void IntersectWith(IEnumerable<T> other)
        {
            var intersection = new List<T>();
            foreach (var key in other)
            {
                if (Contains(key))
                {
                    intersection.Add(key);
                }
            }
            Clear();
            foreach (var key in intersection)
            {
                Add(key);
            }
        }

        /// <summary>
        /// Removes all elements in the specified collection from the current 
        /// </summary>
        /// <param name="other">The collection of items to remove from the current set</param>
        public void ExceptWith(IEnumerable<T> other)
        {
            foreach (var key in other)
            {
                Remove(key);
            }
        }

        /// <summary>
        /// Modifies the current Set<T> object to contain only elements that are present 
        /// either in that object or in the specified collection, but not both
        /// </summary>
        /// <param name="other">The collection to compare to the current Set<T> object</param>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            var intersection = new List<T>();
            foreach (var key in other)
            {
                if (Contains(key))
                {
                    intersection.Add(key);
                }
            }
            UnionWith(other);
            foreach (var key in intersection)
            {
                Remove(key);
            }
        }

        /// <summary>
        /// Modifies the current Set<T> object to contain all elements 
        /// that are present in itself, the specified collection, or both.
        /// </summary>
        /// <param name="other">The collection to compare to the current Set<T> object</param>
        public void UnionWith(IEnumerable<T> other)
        {
            foreach (var key in other)
            {
                Add(key);
            }
        }

        /// <summary>
        /// Determines whether a Set<T> object and the specified collection contain the same elements
        /// </summary>
        /// <param name="other">The collection to compare to the current Set<T> object</param>
        /// <returns>true if the Set<T> object is equal to other; otherwise, false</returns>
        public bool SetEquals(IEnumerable<T> other)
        {
            var otherSize = 0;
            foreach (var key in other)
            {
                if (!Contains(key))
                {
                    return false;
                }
                ++otherSize;
            }
            if (otherSize != Count)
            {
                return false;
            }
            return true;
        }

        private void DoCopyTo(Node node, T[] array, ref int index)
        {
            if (node.Left != null)
            {
                DoCopyTo(node.Left, array, ref index);
            }
            array[index] = node.Key;
            ++index;
            if (node.Right != null)
            {
                DoCopyTo(node.Right, array, ref index);
            }
        }

        /// <summary>
        /// Copies the elements of a Set<T> object to an array, starting at the specified array index
        /// </summary>
        /// <param name="array">The one-dimensional array that is the destination of the elements copied 
        /// from the Set<T> object. The array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Rank > 1)
            {
                throw new ArgumentOutOfRangeException("Array must be one-dimensional");
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Index must be a positive number");
            }
            if (arrayIndex + Count > array.Length)
            {
                throw new IndexOutOfRangeException("Array is too short");
            }
            DoCopyTo(root, array, ref arrayIndex);
        }

        private int SizeOfIntersection(IEnumerable<T> other)
        {
            var setOfOther = new Set<T>();
            int sizeIntersection = 0;
            foreach (var key in other)
            {
                setOfOther.Add(key);
                if (Contains(key))
                {
                    ++sizeIntersection;
                }
            }     
            if (sizeIntersection == setOfOther.Count && sizeIntersection <= Count)
            {
                if (sizeIntersection < Count)
                {
                    return 2; //is proper superset
                }
                return 4; //is Superset
            }
            if (sizeIntersection == Count && sizeIntersection >= setOfOther.Count)
            {
                if (sizeIntersection > setOfOther.Count)
                {
                    return 1; // is proper subset
                }
                return 3; // is subset
            }
            return -1; // clear intersection
        }

        /// <summary>
        /// Determines whether a Set<T> object is a subset of the specified collection
        /// </summary>
        /// <param name="other">The collection to compare to the current Set<T> object</param>
        /// <returns>true if the Set<T> object is a subset of other; otherwise, false.</returns>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (SizeOfIntersection(other) == 3)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether a Set<T> object 
        /// is a proper subset of the specified collection
        /// </summary>
        /// <param name="other">The collection to compare to the current</param>
        /// <returns>true if the Set<T> object is a proper subset of other; otherwise, false</returns>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            if (SizeOfIntersection(other) == 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether a Set<T> object is a superset of the specified collection
        /// </summary>
        /// <param name="other">The collection to compare to the current Set<T> object</param>
        /// <returns>true if the Set<T> object is a superset of other; otherwise, false</returns>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (SizeOfIntersection(other) == 4)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether a Set<T> object is a proper superset of the specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current Set<T> object</param>
        /// <returns>true if the Set<T> object is a proper superset of other; 
        /// otherwise, false.</returns>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            if (SizeOfIntersection(other) == 2)
            {
                return true;
            }
            return false;
        }
    }
}
