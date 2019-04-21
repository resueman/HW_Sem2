namespace Task1
{
    /// <summary>
    /// Tree node methods
    /// </summary>
    abstract class Node
    {
        /// <summary>
        /// Prints node value
        /// </summary>
        public abstract void Print();

        /// <summary>
        /// Returns value of subtree for operator - nodes 
        /// or node value - for operand - nodes
        /// </summary>
        /// <returns>Value of subtree for operator - nodes 
        /// or node value - for operand - nodes</returns>
        public abstract int Calculate();
    }
}
