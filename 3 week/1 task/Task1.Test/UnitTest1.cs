using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.Test
{
    [TestClass]
    public class UnitTest1
    {
        private StackList<int> stack;

        [TestInitialize]
        public void Initialize()
        {
            stack = new StackList<int>();
        }

        [TestMethod]
        public void PopFromEmptyStack()
        {
            stack.Pop();
        }
    }
}
