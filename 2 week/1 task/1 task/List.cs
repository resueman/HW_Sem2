using System;

namespace Task1
{
    class List
    {
        //private int length { get; set; } = 0;
        //private Node head { get; set; } = null;

        private int length = 0;
        private Node head = null;

        private class Node
        {
            public int Value { get; set; } = 0;
            public Node Next { get; set; } = null;
            
            internal Node(int value)//iternal?
            {
                this.Value = value;
            }
        }

        public bool IsEmpty()
        => length == 0;

        public int GetLengthOfList()
        {
            return length;
        }

        Node GetPreviousNodeByPosition(int position)//////whether to merge ?
        {
            Node current = head;
            for (int i = 0; i < position - 2; ++i)
            {
                current = current.Next;
            }
            return current;
        }

        Node GetNodeByPosition(int position)///////whether to merge ?
        {
            Node current = head;
            for (int i = 0; i < position - 1; ++i)
            {
                current = current.Next;
            }
            return current;
        }

        void InsertToHead(Node newNode)
        {
            newNode.Next = head;
            head = newNode;
        }

        void Insert(Node newNode, int position)
        {
            var previous = GetPreviousNodeByPosition(position);
            newNode.Next = previous.Next;
            previous.Next = newNode;
        }

        public void AddNode(int position, int value)
        {
            if (!IsCorrectPosition(position))
            {
                return;
            }
            //is empty//////////////////////////
            Node newNode = new Node(value);
            if (position == 1)
            {
                InsertToHead(newNode);
            }
            else
            {
                Insert(newNode, position);
            }
            ++length;
        }

        void DeleteHead()
        {

        }

        void DeleteMiddle(int position)////////////////////////
        {

        }

        void DeleteLast()
        {

        }

        public void DeleteNode(int position)
        {
            if (!IsCorrectPosition(position))
            {
                return;
            }
            ////////////is empty/////////////
            if (position == 1)
            {
                DeleteHead();
            }
            else if (position == length)
            {
                DeleteLast();
            }
            else
            {
                DeleteMiddle(position);
            }
            --length;
        }

        private bool IsCorrectPosition(int position)
        {
            if (position > length || position < 1)
            {
                Console.WriteLine("Incorrect position");
                return false;
            }
            return true;
        }

        public int GetValue(int position)///////////change getset
        {
            if (!IsCorrectPosition(position))
            {
                return -666;
            }
            return GetNodeByPosition(position).Value;
        }

        public void SetValue(int position, int value)////////////change getset
        {
            if (!IsCorrectPosition(position))
            {
                return;
            }
            GetNodeByPosition(position).Value = value;
        }       
    }
}
