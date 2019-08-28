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
        private string stringExpression = "";
        private string currentNumber = "";
        private bool containComma = false;
        private int numberOfLeftBrackets = 0;
        private int numberOfRightBrackets = 0;
        private readonly List<string> expression = new List<string>();

        public string CurrentNumber
        {
            get => currentNumber;

            private set
            {
                currentNumber = value;
                NotifyPropertyChanged();
            }
        } 

        public string StringExpression
        {
            get => stringExpression;

            private set
            {
                stringExpression = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ClearCurrentNumber()
        {
            CurrentNumber = "";
            containComma = false;
        }

        private bool IsPossibleToAddOperator()
            => CurrentNumber != "" || expression.Count != 0 && expression.Last() == ")" && expression.Last() != ",";

        public void AddOperator(string operatorValue)
        {
            if (IsPossibleToAddOperator())
            {
                expression.Add(CurrentNumber);
                expression.Add(operatorValue);
                StringExpression += CurrentNumber + operatorValue;
                ClearCurrentNumber();
                return;
            }
            if (operatorValue == "-" && currentNumber.Length == 0)
            {
                CurrentNumber = "-";
            }
        }

        private bool IsPossibleToAddDigit()
            => expression.Count == 0 || expression.Last() != ")" || expression.Last() == ")" && CurrentNumber == "-";

        public void AddDigit(int digit)
        {
            if (IsPossibleToAddDigit())
            {
                CurrentNumber += digit.ToString();
            }
        }

        private bool IsPossibleToAddOpeningBracket()
            => expression.Count == 0 && CurrentNumber == "" || Validator.IsOperator(expression.Last()) || expression.Last() == "(";

        public void AddOpeningBracket()
        {
            if (IsPossibleToAddOpeningBracket())
            {
                ++numberOfLeftBrackets;
                AddBracket("(");
            }
        }

        private bool IsPossibleToAddClosingBracket()
            => numberOfRightBrackets < numberOfLeftBrackets &&
            (CurrentNumber != "" && CurrentNumber[CurrentNumber.Length - 1] != ',' || expression.Last() == ")");

        public void AddClosingBracket()
        {
            if (IsPossibleToAddClosingBracket())
            {
                expression.Add(CurrentNumber);
                ++numberOfRightBrackets;
                AddBracket(")");
            }
        }

        private void AddBracket(string bracket)
        {
            expression.Add(bracket);
            StringExpression += CurrentNumber + bracket;
            ClearCurrentNumber();
        }

        public void ChangeSign()
        {
            if (CurrentNumber != "")
            {
                int number = int.Parse(CurrentNumber);
                number *= -1;
                CurrentNumber = number.ToString();
            }
        }

        public void DeleteLastDigit()
        {
            if (CurrentNumber != "")
            {
                if (CurrentNumber[CurrentNumber.Length - 1] == ',')
                {
                    containComma = false;
                }
                CurrentNumber = CurrentNumber.Substring(0, CurrentNumber.Length - 1);
            }
        }            

        public void ClearEntry() => ClearCurrentNumber();

        public void Clear()
        {
            expression.Clear();
            StringExpression = "";
            ClearCurrentNumber();
        }

        public void AddComma()
        {
            containComma = true;
            if (expression.Count == 0 || !containComma && expression.Last() != ")")
            {
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
                StringExpression += CurrentNumber;
                expression.Add(CurrentNumber);
                CurrentNumber = "";
            }
        }

        private bool IsPossibleToGetResult()
        {
            while (numberOfLeftBrackets - numberOfRightBrackets > 0)
            {
                expression.Add(")");
                ++numberOfRightBrackets;
            }
            var last = expression.Last();
            return !(Validator.IsOperator(last) || last == "(" || last == ",");
        }

        public void GetResult()
        {
            expression.Add(CurrentNumber);
            if (IsPossibleToGetResult())
            {
                CurrentNumber = PostfixCalculator.CalculateResult(InfixToPostfixConverter.Convert(expression)).ToString();
                StringExpression = "";
            }
        }
    }
}
