namespace Task1
{
    /// <summary>
    /// Tree node methods
    /// </summary>
    interface INode
    {
        /// <summary>
        /// Prints node value
        /// </summary>
        void Print();

        /// <summary>
        /// Returns value of subtree for operator - nodes 
        /// or node value - for operand - nodes
        /// </summary>
        /// <returns>Value of subtree for operator - nodes 
        /// or node value - for operand - nodes</returns>
        int Calculate();
    }
}
