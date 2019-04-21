using System;

namespace Task1
{
    /// <summary>
    /// Methods to work with node - operators
    /// </summary>
    class Operator : Node
    {
        private string data;
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Operator(string data)
        {
            if (!IsOperator(data))
            {
                throw new IncorrectInputException("Unexpected symbol");
            }
            this.data = data;
        }

        private static bool IsOperator(string symbol)
            => symbol == "+" || symbol == "-" || symbol == "*" || symbol == "/";

        public override int Calculate()
            => Calculation.PerformingOperation(data, Left, Right);

        public override void Print()
        {
            Console.Write("( ");
            Left.Print();
            Console.Write(data + " ");
            Right.Print();
            Console.Write(") ");
        }             
    }
}
