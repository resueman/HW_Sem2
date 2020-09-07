using System;

namespace Task1
{
    /// <summary>
    /// Methods to work with node - operands
    /// </summary>
    class Operand : INode
    {
        private readonly int data;

        public Operand(int data)
        {
            this.data = data;
        }

        public void Print()
        {
            Console.Write(data + " ");
        }

        public int Calculate()
            => data;
    }
}
