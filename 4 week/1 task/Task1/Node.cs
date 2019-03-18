using System;

namespace Task1
{
    abstract class Node
    {
        public abstract void Print();
        public abstract int Calculate();
    }

    class Operand : Node
    {
        internal int Data { get; set; }

        public override void Print()
        {
            Console.Write(Data + " ");
        }

        public override int Calculate()
            => Data;
    }

    class Operator : Node
    {
        internal string data;
        internal Node Left { get; set; } = null;
        internal Node Right { get; set; } = null;

        public Operator(string data)
        {
            if(!OperatorChecker.IsOperator(data))
            {
                throw new IncorrectInputException("Unexpected symbol");
            }
            this.data = data;
        }

        public override int Calculate()
            => Calculation.PerformingOperation(data, Left, Right);

        public override void Print()
        {
            Console.Write("( " + data + " ");
            Left.Print();
            Right.Print();
            Console.Write(") ");
        }             
    }
}
