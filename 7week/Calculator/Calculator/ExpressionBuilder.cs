using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Calculator
{
    class ExpressionBuilder : INotifyPropertyChanged
    {
        private bool containComma = false;
        private int numberOfLeftBrackets = 0;
        private int numberOfRightBrackets = 0;

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

        public void AddOperator(string operatorValue)
        {
            if (char.IsDigit(LastOfCurrent) || LastOfExpression == ')' || LastOfCurrent == ',')
            {
                AddCurrentNumber();
                Expression += operatorValue;
                return;
            }
            if (operatorValue == "-" && CurrentNumber == "")
            {
                CurrentNumber = "-";
            }
        }

        public void AddDigit(int digit)
        {
            if (LastOfExpression != ')')
            {
                CurrentNumber += digit.ToString();
            }
        }

        private bool IsPossibleToAddOpeningBracket()
            => Expression.Length == 0 && CurrentNumber == "" || LastOfExpression == '('
            || Validator.IsOperator(LastOfExpression.ToString()); 

        public void AddOpeningBracket()
        {
            if (IsPossibleToAddOpeningBracket())
            {
                ++numberOfLeftBrackets;
                Expression += '(';
            }
        }

        private bool IsPossibleToAddClosingBracket()
            => numberOfRightBrackets < numberOfLeftBrackets && (CurrentNumber != "" || LastOfExpression == ')');

        public void AddClosingBracket()
        {
            if (IsPossibleToAddClosingBracket())
            {
                ++numberOfRightBrackets;
                AddCurrentNumber();
                Expression += ')';
            }
        }

        public void ChangeSign()
        {
            if (CurrentNumber != "")
            {
                CurrentNumber = (-1 * int.Parse(CurrentNumber)).ToString();
            }
        }

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

        public void ClearEntry() => ClearCurrentNumber();

        public void Clear()
        {
            Expression = "";
            ClearCurrentNumber();
        }

        public void AddComma()
        {
            if (LastOfExpression != ')' && !containComma)
            {
                containComma = true;
                if (CurrentNumber == "")
                {
                    CurrentNumber = "0,";
                    return;
                }
                CurrentNumber += ",";
            }
        }

        public void AddRoot()
        {
            if (CurrentNumber != "")
            {
                CurrentNumber = Math.Sqrt(double.Parse(CurrentNumber)).ToString();
                AddCurrentNumber();
            }
        }

        private bool IsPossibleToGetResult()
        {
            while (numberOfLeftBrackets - numberOfRightBrackets > 0)
            {
                Expression += ')';
                ++numberOfRightBrackets;
            }
            return char.IsDigit(LastOfExpression) || LastOfExpression == ')';
        }

        public void GetResult()
        {
            AddCurrentNumber();
            if (IsPossibleToGetResult())
            {
                CurrentNumber = PostfixCalculator.CalculateResult(InfixToPostfixConverter.Convert(Expression)).ToString();
                Expression = "";
            }
        }
    }
}
