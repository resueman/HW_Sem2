using System;

namespace Task1
{
    /// <summary>
    /// Methods to work with node - operands
    /// </summary>
    class Operand : Node
    {
        private int data;

        public Operand(int data)
        {
            this.data = data;
        }

        public override void Print()
        {
            Console.Write(data + " ");
        }

        public override int Calculate()
            => data;
    }
}
