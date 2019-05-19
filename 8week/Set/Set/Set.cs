using System;
using System.Collections;
using System.Collections.Generic;

namespace Set
{
    public class Set<T> : ISet<T> where T : IComparable<T>
    {
        public int Count { get; private set; }

        private Node root;

        public class Node
        {
            public T Key { get; private set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(T value)
            {
                Key = value;
            }
        }

        private IEnumerator<T> Traversal(Node node)
        {
            if (node.Left != null)
            {
                Traversal(node.Left);
            }
            yield return node.Key;
            if (node.Right != null)
            {
                Traversal(node.Right);
            }
            Console.WriteLine(node.Key);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Traversal(root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool IsReadOnly => false;

        private Node GetNodeByKey(Node node, T key)
        {
            if (key.CompareTo(node.Key) > 0)
            {
                if (node.Right == null)
                {
                    return null;
                }
                GetNodeByKey(node.Right, key);
            }
            else if (key.CompareTo(node.Key) < 0)
            {
                if (node.Left == null)
                {
                    return null;
                }
                GetNodeByKey(node.Left, key);
            }
            return node;
        }

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
                DoAdd(node.Right, key);
            }
        }

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

        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        private void DoRemove(Node node, T key)
        {
            
        }

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
            DoRemove(root, key);
            --Count;
            return true;
        }

        public void Clear()
        {
            root = null;
            Count = 0;
        }

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

        public void ExceptWith(IEnumerable<T> other)
        {
            foreach (var key in other)
            {
                Remove(key);
            }
        }

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

        public void UnionWith(IEnumerable<T> other)
        {
            foreach (var key in other)
            {
                Add(key);
            }
        }

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

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (SizeOfIntersection(other) == 3)
            {
                return true;
            }
            return false;
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            if (SizeOfIntersection(other) == 1)
            {
                return true;
            }
            return false;
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (SizeOfIntersection(other) == 4)
            {
                return true;
            }
            return false;
        }

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
