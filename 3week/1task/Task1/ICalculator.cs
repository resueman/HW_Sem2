namespace Task1
{
    public interface ICalculator
    {
        /// <summary>
        /// Calculate the value of expression
        /// </summary>
        /// <param name="expression">Expression in postfix form</param>
        /// <returns>Expression value</returns>
        int Calculation(string expression);
    }
}
