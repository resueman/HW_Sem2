using System;

namespace Task1
{
    /// <summary>
    /// Tree implementation
    /// Class contains method for tree building, printing and evaluating tree
    /// </summary>
    public class Tree
    {
        private static INode Root { get; set; }

        public Tree(string expression)
        {
            string[] input;
            char[] splitChar = { ' ' };
            input = expression.Split(splitChar);
            int index = 0;
            Root = CreateNode(input, ref index);
        }

        private static INode CreateNode(string[] input, ref int index)
        {
            if (input[index] == "(")
            {
                var newNode = new Operator(input[index + 1]);
                index += 2;

                newNode.Left = CreateNode(input, ref index);
                ++index;
                newNode.Right = CreateNode(input, ref index);
                ++index;
                if (input[index] != ")")
                {
                    throw new IncorrectInputException("No closing bracket");
                }
                return newNode;
            }
            if (int.TryParse(input[index], out int result))
            {
                var newNode = new Operand(result);
                return newNode;
            }
            if (input[index] == ")")
            {
                ++index;
                return CreateNode(input, ref index);
            }
            throw new IncorrectInputException("Incorrect symbol");
        }

        public void PrintTree()
        {
            if (Root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            DoPrint();
        }

        public int CalculateTree()
        {
            return Root.Calculate();
        }

        private static void DoPrint()
        {
            Root.Print();
            Console.WriteLine();
        }        
    }
}
