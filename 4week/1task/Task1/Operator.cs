using System;

namespace Task1
{
    /// <summary>
    /// Methods to work with node - operators
    /// </summary>
    class Operator : INode
    {
        private readonly string data;
        public INode Left { get; set; }
        public INode Right { get; set; }

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

        public int Calculate()
        {
            if (data == "/" && Right.Calculate() == 0)
            {
                throw new DivideByZeroException("Devide by zero");
            }
            switch (data)
            {
                case "+":
                    return Left.Calculate() + Right.Calculate();
                case "-":
                    return Left.Calculate() - Right.Calculate();
                case "*":
                    return Left.Calculate() * Right.Calculate();
                case "/":
                    return Left.Calculate() / Right.Calculate();
                default:
                    throw new IncorrectInputException("Unexpected symbol");
            }
        }

        public void Print()
        {
            Console.Write("( ");
            Left.Print();
            Console.Write(data + " ");
            Right.Print();
            Console.Write(") ");
        }             
    }
}
