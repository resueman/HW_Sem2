using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class InputChecker
    {
        private bool IsOperator(char symbol) => symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';

        private bool IsDigit(char symbol) => symbol > '0' && symbol < '9';

        public bool CanDigitBeAdded(string expression)
        {
            var length = expression.Length;

            if (length == 0)
            {
                return true;
            }

            if (expression[length - 1] == ')')
            {
                return false;
            }

            if (expression[length - 1] == 0)
            {
                if (length == 1)
                {
                    return false;
                }
                if (IsDigit(expression[length - 2]) || expression[length - 2] == ',')
                {
                    return true;
                }
                return false;
            }

            return true;
        }

        public bool CanCommaBeAdded(string expression)
        {
            var length = expression.Length;

        }

        public bool CanBracketBeAdded(string expression)
        {
            var length = expression.Length;

        }

        public bool CanOperatorBeAdded(string expression, bool IsMinus)
        {
            var length = expression.Length;

            if (length == 0)
            {
                return IsMinus;
            }

            var last = expression[length - 1];
            if (last == ',' || last == '(' || IsOperator(last))
            {
                return false;
            }

            return true;
        }
    }
}
