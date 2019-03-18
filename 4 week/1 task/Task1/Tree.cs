using System;

namespace Task1
{
    class Tree<T> : ITree<T>
    {
        Node<T> Root { get; set; }

        public bool IsEmpty()
            => Root == null;

        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            DoPrint(Root);
        }

        private void DoPrint(Node<T> node)
        {            
            node.PrintNode(); // interaction depending on operator or operand (correctnes ???)
            Console.WriteLine(" ");

            Node<T> left = node.GetLeft();
            if (left != null)
            {
                DoPrint(left);
            }

            Node<T> right = node.GetRight();
            if (right != null)
            {
                DoPrint(right);
                Console.WriteLine(") ");
            }
        }

        public int Calculate()
        {
            return 1;
        }
        
    }
}
