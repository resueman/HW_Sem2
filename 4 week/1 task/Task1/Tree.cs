using System;

namespace Task1
{
    class Tree
    {
        private static Node Root { get; set; }

        public Tree(string expression)
        {
            string[] input;
            char[] splitChar = { ' ' };
            input = expression.Split(splitChar);
            int index = 0;
            Root = CreateNode(input, ref index);
        }

        public static Node CreateNode(string[] input, ref int index)
        {
            if (input[index] == "(")
            {
                Operator newNode = new Operator(input[index + 1]);
                index += 2;

                newNode.Left = CreateNode(input, ref index);
                ++index;
                newNode.Right = CreateNode(input, ref index);
                ++index;
                return newNode;
            }
            if (int.TryParse(input[index], out int result))
            {
                var newNode = new Operand()
                {
                    Data = result
                };
                return newNode;
            }
            if (input[index] == ")")
            {
                ++index;
                return CreateNode(input, ref index);
            }
            throw new IncorrectInputException("Incorrect symbol");
        }

        private bool IsEmpty()
            => Root == null;

        public void PrintTree()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            DoPrint(Root);
        }

        public int CalculateTree()
        {
            return Root.Calculate();
        }

        private void DoPrint(Node node)
        {
            Root.Print();
            Console.WriteLine();
        }        
    }
}
