using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class ExpressionBuilder
    {
        public ExpressionBuilder()
        {
            expression = new Expression();
        }

        public string CurrentNumber { get; private set; } = "";
        public string CurrentTextBox { get; private set; }
        public string ExpressionTextBox { get; private set; }

        private readonly Expression expression;

        private class Expression : List<string>
        {
            public bool ContainComma { get; set; } = false;
            public int NumberOfLeftBrackets { get; set; } = 0;
            public int NumberOfRightBrackets { get; set; } = 0;
        }

        private bool IsPossibleToAddDigit()
            => expression.Count == 0 || expression.Count != 0 && expression.Last() != ")";

        public void AddDigit(int digit)
        {
            if (!IsPossibleToAddDigit())
            {
                CurrentTextBox = "Error";
                return;
            }
            if (CurrentNumber == "" || CurrentTextBox == "Error")
            {
                CurrentTextBox = "";
            }
            CurrentNumber += digit.ToString(); 
            CurrentTextBox = CurrentNumber;
        }

        private bool IsPossibleToAddOperator()
            => CurrentNumber != "" || expression.Count != 0 && expression.Last() == ")";

        public void AddOperator(string operatorValue)
        {
            if (!IsPossibleToAddOperator())
            {
                CurrentTextBox = "Error";
                return;
            }
            expression.Add(CurrentNumber);
            expression.Add(operatorValue);
            CurrentTextBox = "";
            ExpressionTextBox += CurrentNumber + operatorValue;
            CurrentNumber = "";
        }               

        private bool IsPossibleToAddLeftBracket()
            => expression.Count == 0 && CurrentNumber == ""
            || expression.Count != 0 && (Validator.IsOperator(expression.Last()) || expression.Last() == "(");

        public void AddLeftBracket()
        {
            if (!IsPossibleToAddLeftBracket())
            {
                CurrentTextBox = "Error";
                return;
            }
            ++expression.NumberOfLeftBrackets;
            AddBracket("(");
        }

        private bool IsPossibleToAddRightBracket()
            => expression.NumberOfRightBrackets < expression.NumberOfLeftBrackets && (CurrentNumber != ""
            && CurrentNumber[CurrentNumber.Length - 1] != ','
            || expression.Count != 0 && expression.Last() == ")");

        public void AddRightBracket()
        {
            if (!IsPossibleToAddRightBracket())
            {
                CurrentTextBox = "Error";
                return;
            }
            ++expression.NumberOfRightBrackets;
            expression.Add(CurrentNumber);
            AddBracket(")");
        }

        private void AddBracket(string bracket)
        {
            expression.Add(bracket);
            CurrentTextBox = bracket;
            ExpressionTextBox += CurrentNumber + bracket;
            CurrentNumber = "";
        }

        public void ChangeSign()
        {
            if (CurrentNumber != "")
            {
                int number = int.Parse(CurrentNumber);
                number *= -1;
                CurrentNumber = number.ToString();
                CurrentTextBox = CurrentNumber;
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
                    expression.Insert(expression.Count - 1, ")");
                }
            }
            ExpressionTextBox = "";
            foreach(var unit in expression)
            {
                ExpressionTextBox += unit;
            }
        }

        public void DeleteLastDigit()
        {
            if (CurrentNumber == "")
            {
                return;
            }
            CurrentTextBox = CurrentTextBox.Substring(0, CurrentTextBox.Length - 1);
            CurrentNumber = CurrentNumber.Substring(0, CurrentNumber.Length - 1);
        }            

        public void ClearEntry()
        {
            CurrentNumber = "";
            CurrentTextBox = "";
        }

        public void Clear()
        {
            expression.Clear();
            CurrentNumber = "";
            CurrentTextBox = "";
            ExpressionTextBox = "";
        }

        private bool IsPossibleToAddComma() => IsPossibleToAddDigit() && CurrentNumber == ""
            || CurrentNumber != "" && !expression.ContainComma;

        public void AddComma()
        {
            if (!IsPossibleToAddComma())
            {
                CurrentTextBox = "Error";
                return;
            }
            if (CurrentNumber == "")
            {
                CurrentNumber = "0,";
                CurrentTextBox = "0,";
                return;
            }
            CurrentNumber += ",";
            CurrentTextBox += ",";
        }
    }
}
