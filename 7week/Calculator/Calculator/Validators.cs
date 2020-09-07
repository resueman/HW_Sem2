namespace Calculator
{
    /// <summary>
    /// Class containing symbol validators 
    /// to determine their belonging to a particular group of characters
    /// </summary>
    public static class Validators
    {
        /// <summary>
        /// Срeck if a symbol is an addition, subtract, multiplication or division operator
        /// </summary>
        /// <param name="symbol">Symbol to validate</param>
        /// <returns>True, if symbol is operator; otherwise, false</returns>
        public static bool IsOperator(string symbol)
            => symbol == "+" || symbol == "-" || symbol == "*" || symbol == "/";
    }
}
