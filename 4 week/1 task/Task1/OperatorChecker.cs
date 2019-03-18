namespace Task1
{
    class OperatorChecker
    {
        public static bool IsOperator(string symbol)
            => symbol == "+" || symbol == "-" || symbol == "*" || symbol == "/";
    }
}
