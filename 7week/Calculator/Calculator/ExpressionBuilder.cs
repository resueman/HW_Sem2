using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Calculator
{
    /// <summary>
    /// Builds arithmetic expression by adding numbers and operators to it
    /// </summary>
    public class ExpressionBuilder : INotifyPropertyChanged
    {
        public ExpressionBuilder() { }

        public ExpressionBuilder(string expression)
        {
            Expression = expression;
        }

        private bool containComma;
        private int numberOfOpeningBrackets;
        private int numberOfClosingBrackets;

        private string currentNumber = "";
        private string expression = "";

        public string CurrentNumber
        {
            get => currentNumber;

            private set
            {
                currentNumber = value;
                NotifyPropertyChanged();
            }
        } 

        public string Expression
        {
            get => expression;

            private set
            {
                expression = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private char LastOfExpression => expression.Length == 0 ? ' ' : Expression.Last();

        private char LastOfCurrent => CurrentNumber.Length == 0 ? ' ' : CurrentNumber.Last();

        private void AddCurrentNumber()
        {
            if (CurrentNumber == "-")
            {
                CurrentNumber = "0";
            }
            if (LastOfCurrent == ',')
            {
                CurrentNumber = CurrentNumber.Substring(0, CurrentNumber.Length - 1);
            }
            Expression += CurrentNumber;
            ClearCurrentNumber();
        }

        private void ClearCurrentNumber()
        {
            CurrentNumber = "";
            containComma = false;
        }

        private bool IsPossibleToAddOperator()
            => char.IsDigit(LastOfCurrent) || LastOfExpression == ')' || LastOfCurrent == ',';

        /// <summary>
        /// Add multiplication, division, subtraction or addition operator to expresson
        /// </summary>
        /// <param name="operatorValue">Value of operator</param>
        public void AddOperator(char operatorValue)
        {
            if (IsPossibleToAddOperator())
            {
                AddCurrentNumber();
                Expression += operatorValue;
                return;
            }
            if (operatorValue == '-' && CurrentNumber == "")
            {
                CurrentNumber = "-";
            }
        }

        /// <summary>
        /// Add digit to entered number
        /// </summary>
        /// <param name="digit">Digit to add</param>
        public void AddDigit(char digit)
        {
            if (LastOfExpression != ')')
            {
                if (!((CurrentNumber == "0" || CurrentNumber == "-0") && digit == '0'))
                {
                    CurrentNumber += digit.ToString();
                }
            }
        }

        private bool IsPossibleToAddOpeningBracket()
            => CurrentNumber == "" && (Expression.Length == 0 || LastOfExpression == '('
            || Validators.IsOperator(LastOfExpression.ToString())); 

        /// <summary>
        /// Add opening bracket to expresson
        /// </summary>
        public void AddOpeningBracket()
        {
            if (IsPossibleToAddOpeningBracket())
            {
                ++numberOfOpeningBrackets;
                Expression += '(';
            }
        }

        private bool IsPossibleToAddClosingBracket()
            => numberOfClosingBrackets < numberOfOpeningBrackets && (CurrentNumber != "" || LastOfExpression == ')');

        /// <summary>
        /// Add closing bracket to expresson 
        /// </summary>
        public void AddClosingBracket()
        {
            if (IsPossibleToAddClosingBracket())
            {
                ++numberOfClosingBrackets;
                AddCurrentNumber();
                Expression += ')';
            }
        }

        /// <summary>
        /// Change sign of entered number
        /// </summary>
        public void ChangeSign()
        {
            if (CurrentNumber != "")
            {
                CurrentNumber = (-1 * int.Parse(CurrentNumber)).ToString();
            }
        }

        /// <summary>
        /// Delete last digit of entered number
        /// </summary>
        public void DeleteLastDigit()
        {
            if (CurrentNumber != "")
            {
                if (LastOfCurrent == ',')
                {
                    containComma = false;
                }
                CurrentNumber = CurrentNumber.Substring(0, CurrentNumber.Length - 1);
            }
        }

        /// <summary>
        /// Сlear entry field of entered number
        /// </summary>
        public void ClearEntry() => ClearCurrentNumber();

        /// <summary>
        /// Clear entry fields of expression and entered number
        /// </summary>
        public void Clear()
        {
            Expression = "";
            ClearCurrentNumber();
        }

        /// <summary>
        /// Add comma to entered number
        /// </summary>
        public void AddComma()
        {
            if (LastOfExpression != ')' && !containComma)
            {
                containComma = true;
                if (CurrentNumber == "" || CurrentNumber == "-")
                {
                    CurrentNumber += "0,";
                    return;
                }
                CurrentNumber += ",";
            }
        }

        /// <summary>
        /// Extract the square root of the entered number
        /// </summary>
        public void AddSquareRoot()
        {
            if (CurrentNumber != "" && double.Parse(CurrentNumber) >= 0)
            {
                CurrentNumber = Math.Sqrt(double.Parse(CurrentNumber)).ToString();
            }
        }

        /// <summary>
        /// Complete expression by adding
        /// </summary>
        /// <returns>True, if expression completed and its value can be calculated;
        /// False, if expession can't be completed without user and as result calculated</returns>
        public bool Complete()
        {
            if (numberOfOpeningBrackets != numberOfClosingBrackets && IsPossibleToAddClosingBracket())
            {
                AddCurrentNumber();
                while (numberOfOpeningBrackets - numberOfClosingBrackets > 0)
                {
                    Expression += ')';
                    ++numberOfClosingBrackets;
                }
            }
            else
            {
                AddCurrentNumber();
            }
            return char.IsDigit(LastOfExpression) || LastOfExpression == ')';
        }

        /// <summary>
        /// Write value of expression to the entered number field
        /// </summary>
        /// <param name="result"></param>
        public void AssignCurrentNumberToResult(double result)
            => CurrentNumber = result.ToString();        
    }
}
