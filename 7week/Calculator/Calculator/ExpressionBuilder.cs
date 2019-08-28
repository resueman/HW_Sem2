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
        public ExpressionBuilder()
        {
            expression = new Expression();
        }

        private string stringExpression = "";
        private string currentNumber = "";
        private bool containComma = false;
        private readonly Expression expression;

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

        private class Expression : List<string>
        {
            public int NumberOfLeftBrackets { get; set; } = 0;
            public int NumberOfRightBrackets { get; set; } = 0;

            public double Calculate()
                => PostfixCalculator.CalculateResult(InfixToPostfixConverter.Convert(this));
        }

        private void ClearCurrentNumber()
        {
            CurrentNumber = "";
            containComma = false;
        }

        public void AddDigit(int digit)
        {
            if (IsPossibleToAddDigit())
            {
                CurrentNumber += digit.ToString();
            } 
        }
        
        private void AddMinus()
        {
            if (CurrentNumber != "" || expression.Count != 0 && expression.Last() == ")")
            {
                DoAddOperator("-");
                return;
            }
            if (expression.Count != 0)
            {
                if (expression.Last() == "-" || expression.Last() == "+" || expression.Last() == ",")
                {
                    return;
                }
                if (expression.Last() == "*" || expression.Last() == "/")
                {
                    expression.Add("(");
                    StringExpression += "(";
                    ++expression.NumberOfLeftBrackets;
                }
            }
            CurrentNumber = "-";
        }

        private bool IsPossibleToAddOperator()
            => CurrentNumber != "" || expression.Count != 0 && expression.Last() == ")" && expression.Last() != ",";

        private bool IsPossibleToAddDigit()
            => expression.Count == 0 || expression.Last() != ")" || expression.Last() == ")" && CurrentNumber == "-";

        private bool IsPossibleToAddRightBracket()
            => expression.NumberOfRightBrackets < expression.NumberOfLeftBrackets &&
            (CurrentNumber != "" && CurrentNumber[CurrentNumber.Length - 1] != ',' || expression.Last() == ")");

        private bool IsPossibleToAddLeftBracket()
            => expression.Count == 0 && CurrentNumber == "" || Validator.IsOperator(expression.Last()) || expression.Last() == "(";

        private bool IsPossibleToAddComma() => expression.Count == 0 || !containComma && expression.Last() != ")";

        private void DoAddOperator(string operatorValue)
        {
            expression.Add(CurrentNumber);
            expression.Add(operatorValue);
            StringExpression += CurrentNumber + operatorValue;
            ClearCurrentNumber();
        }

        public void AddOperator(string operatorValue)
        {
            if (operatorValue == "-")
            {
                AddMinus();
                return;
            }
            if (IsPossibleToAddOperator())
            {
                DoAddOperator(operatorValue);
            }
        }               

        public void AddLeftBracket()
        {
            if (IsPossibleToAddLeftBracket())
            {
                ++expression.NumberOfLeftBrackets;
                AddBracket("(");
            }
        }

        public void AddRightBracket()
        {
            if (IsPossibleToAddRightBracket())
            {
                ++expression.NumberOfRightBrackets;
                expression.Add(CurrentNumber);
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
                return;
            }
            if (expression.Count != 0)
            {
                if (expression.First() == "-" && expression.ElementAt(1) == "(" && expression.Last() == ")")
                {
                    expression.RemoveAt(0);
                    expression.RemoveAt(0);
                    expression.RemoveAt(expression.Count - 1);
                }
                else
                {
                    expression.Insert(0, "-");
                    expression.Insert(1, "(");
                    ++expression.NumberOfLeftBrackets;
                    expression.Insert(expression.Count - 1, ")");
                    ++expression.NumberOfRightBrackets;
                }
            }
            StringExpression = "";
            foreach(var unit in expression)
            {
                StringExpression += unit;
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
            if (IsPossibleToAddComma())
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
            while (expression.NumberOfLeftBrackets > expression.NumberOfRightBrackets)
            {
                expression.Add(")");
                ++expression.NumberOfRightBrackets;
            }
            var last = expression.Last();
            return !(Validator.IsOperator(last) || last == "(" || last == ",");
        }

        public void GetResult()
        {
            expression.Add(CurrentNumber);
            if (IsPossibleToGetResult())
            {
                CurrentNumber = expression.Calculate().ToString();
                StringExpression = "";
            }
        }
    }
}
