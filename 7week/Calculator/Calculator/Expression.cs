using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Expression : List<string>
    {
        public bool ContainComma { get; private set; } = false;
        public string CurrentNumber { get; private set; } = ""; // invariant, is "" if not a number entered
        private int numberOfLeftBrackets = 0;
        private int numberOfRightBrackets = 0;

        private bool IsPossibleToAddDigit()
            => Count == 0 || Count != 0 && this.Last() != ")";

        public bool AddDigit(int digit)
        {
            if (!IsPossibleToAddDigit())
            {
                return false;
            }
            CurrentNumber += digit.ToString();
            return true;
        }

        private bool IsPossibleToAddOperator()
            => CurrentNumber != "" || Count != 0 && this.Last() == ")";

        public bool AddOperator(string operatorValue)
        {
            if (!IsPossibleToAddOperator())
            {
                return false;
            }
            Add(CurrentNumber);
            Add(operatorValue);
            CurrentNumber = "";
            return true;
        }               

        private bool IsPossibleToAddLeftBracket()
            => Count == 0 && CurrentNumber == ""
            || Count != 0 && (Validator.IsOperator(this.Last()) || this.Last() == "(");

        public bool AddLeftBracket()
        {
            if (!IsPossibleToAddLeftBracket())
            {
                return false;
            }
            ++numberOfLeftBrackets;
            AddBracket("(");
            return true;
        }

        private bool IsPossibleToAddRightBracket()
            => numberOfRightBrackets < numberOfLeftBrackets && (CurrentNumber != ""
            && CurrentNumber[CurrentNumber.Length - 1] != ','
            || Count != 0 && this.Last() == ")");

        public bool AddRightBracket()
        {
            if (!IsPossibleToAddRightBracket())
            {
                return false;
            }
            ++numberOfRightBrackets;
            AddBracket(")");
            return true;
        }

        private void AddBracket(string bracket)
        {
            Add(bracket);
            CurrentNumber = "";
        }

        public void ChangeCurrentNumberSign()
        {
            int number = int.Parse(CurrentNumber);
            number *= -1;
            CurrentNumber = number.ToString();
        }

        public void ChangeSign()
        {
            Insert(0, "-");
            Insert(1, "(");
            Insert(Count - 1, ")");
        }

        public void DeleteLastDigit() 
            => CurrentNumber = CurrentNumber.Substring(0, CurrentNumber.Length - 1);

        public override string ToString()
        {
            string expression = "";
            foreach (var unit in this)
            {
                expression += unit;
            }
            return expression;
        }

        public new void Clear()
        {
            CurrentNumber = "";
            base.Clear();
        }

        public void ClearEntry()
        {
            CurrentNumber = "";
        }
    }
}
