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

        public int Count { get; private set; }

        public bool IsReadOnly { get; private set; }

        public IEnumerator<T> GetEnumerator() => Traversal();

        IEnumerator IEnumerable.GetEnumerator() => Traversal();

        private IEnumerator<T> Traversal()
        {
            var queue = new Queue<T>();
            InOrderTraversal(root, queue);
            for (int i = 0; i < Count; ++i)
            {
                yield return queue.Dequeue();
            }
        }

        private void InOrderTraversal(Node node, Queue<T> queue)
        {
            if (node == null)
            {
                return;
            }
            if (node.Left != null)
            {
                InOrderTraversal(node.Left, queue);
            }
            queue.Enqueue(node.Key);
            if (node.Right != null)
            {
                InOrderTraversal(node.Right, queue);
            }
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
        void ICollection<T>.Add(T item) => Add(item);

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
        /// Removes the specified element from a Set<T> object.
        /// </summary>
        /// <param name="key">The element to remove</param>
        /// <returns>true if the element is successfully found and removed;
        /// false if item is not found in the Set<T> object</returns>
        public bool Remove(T key)
        {
            if (!Contains(key))
            {
                return false;
            }
            DoRemove(ref root, key, ref root, true);
            --Count;
            return true;
        }

        private void DoRemove(ref Node node, T key, ref Node parent, bool left)
        {
            if (key.CompareTo(node.Key) > 0)
            {
                var rightChild = node.Right;
                DoRemove(ref rightChild, key, ref node, false);
            }
            else if (key.CompareTo(node.Key) < 0)
            {
                var leftChild = node.Left;
                DoRemove(ref leftChild, key, ref node, true);
            }
            else
            {
                if (node.Left == null && node.Right == null)
                {
                    if (Count == 0)
                    {
                        node = null;
                        return;
                    }
                    if (left)
                    {
                        parent.Left = null;
                        return;
                    }
                    parent.Right = null;
                }
                else if (node.Left == null && node.Right != null)
                {
                    if (left)
                    {
                        parent.Left = node.Right;
                    }
                    else
                    {
                        parent.Right = node.Right;
                    }
                }
                else if (node.Left != null && node.Right == null)
                {
                    if (left)
                    {
                        parent.Left = node.Left;
                    }
                    else
                    {
                        parent.Right = node.Left;
                    }
                }
                else
                {
                    node.Key = FindLeftSubTreeMaximum(node);
                    var leftChild = node.Left;
                    DoRemove(ref leftChild, node.Key, ref node, true);
                }
            }
        }

        private static T FindLeftSubTreeMaximum(Node node)
        {
            var temp = node.Left;
            while (temp.Right != null)
            {
                temp = temp.Right;
            }
            return temp.Key;
        }

        /// <summary>
        /// Removes all elements from a Set<T> object
        /// </summary>
        public void Clear()
        {
            root = null;
            Count = 0;
        }

        private bool CheckOther(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Specified collection reference not set to an instance of an object");
            }
            return this != other;
        }

        /// <summary>
        /// Determines whether the current Set<T> object and a specified collection share common elements
        /// </summary>
        /// <param name="other">The collection to compare to the current Set<T> object</param>
        /// <returns>true if the Set<T> object and other share at least one common element; otherwise, false</returns>
        public bool Overlaps(IEnumerable<T> other)
        {
            if (!CheckOther(other))
            {
                return true;
            }

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
            if (!CheckOther(other))
            {
                return;
            }

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
        /// Removes all elements in the specified collection from the current set
        /// </summary>
        /// <param name="other">The collection of items to remove from the current set</param>
        public void ExceptWith(IEnumerable<T> other)
        {
            if (!CheckOther(other))
            {
                Clear();
                return;
            }

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
            if (!CheckOther(other))
            {
                Clear();
                return;
            }

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
            if (CheckOther(other))
            {
                foreach (var key in other)
                {
                    Add(key);
                }
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
        /// Determines whether a Set<T> object is a subset of the specified collection
        /// </summary>
        /// <param name="other">The collection to compare to the current Set<T> object</param>
        /// <returns>true if the Set<T> object is a subset of other; otherwise, false.</returns>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (CheckOther(other))
            {
                var otherSet = new Set<T>();
                foreach (var key in other)
                {
                    otherSet.Add(key);
                }
                foreach (var key in this)
                {
                    if (!otherSet.Contains(key))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Determines whether a Set<T> object is a superset of the specified collection
        /// </summary>
        /// <param name="other">The collection to compare to the current Set<T> object</param>
        /// <returns>true if the Set<T> object is a superset of other; otherwise, false</returns>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (CheckOther(other))
            {
                foreach (var key in other)
                {
                    if (!Contains(key))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Determines whether a Set<T> object 
        /// is a proper subset of the specified collection
        /// </summary>
        /// <param name="other">The collection to compare to the current</param>
        /// <returns>true if the Set<T> object is a proper subset of other; otherwise, false</returns>
        public bool IsProperSubsetOf(IEnumerable<T> other) 
            => IsSubsetOf(other) && !SetEquals(other);

        /// <summary>
        /// Determines whether a Set<T> object is a proper superset of the specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current Set<T> object</param>
        /// <returns>true if the Set<T> object is a proper superset of other; 
        /// otherwise, false.</returns>
        public bool IsProperSupersetOf(IEnumerable<T> other) 
            => IsSupersetOf(other) && !SetEquals(other);

        /// <summary>
        /// Determines whether a Set<T> object and the specified collection contain the same elements
        /// </summary>
        /// <param name="other">The collection to compare to the current Set<T> object</param>
        /// <returns>true if the Set<T> object is equal to other; otherwise, false</returns>
        public bool SetEquals(IEnumerable<T> other) 
            => IsSubsetOf(other) && IsSupersetOf(other);
    }
}
