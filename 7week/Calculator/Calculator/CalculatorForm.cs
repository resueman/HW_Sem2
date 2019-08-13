using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
            expression = new List<string>();
            //currentTextBox.Text = "0";
            currentNumber = "";
        }

        List<string> expression;/// currentTextBox.Text
        string currentNumber;// expressionTextBox.Text

        private bool IsNumberEntered()
            => currentTextBox.Text.Length != 0 && char.IsDigit(currentTextBox.Text.Last())
               || currentTextBox.Text.Last() == ',';
                          
        private bool IsPossibleToAddDigit()
        {
            if (expression.Count == 0)
            {
                return true;
            }
            if (expression.Last() == ")")
            {
                currentTextBox.Text = "Ошибка"; //, после " + "'" + expression.Last() + "'" + " требуется знак операции";
                return false;
            }
            return true;
        }

        private void AddDigit(int digit)
        {
            if (!IsPossibleToAddDigit())
            {
                currentTextBox.Text = "Ошибка";
                return;
            }
            if (IsOperator(currentTextBox.Text) || currentTextBox.Text == "Ошибка")
            {
                currentTextBox.Text = "";
            }
            currentNumber += digit.ToString();
            currentTextBox.Text += digit.ToString();
        }

        private bool IsPossibleToAddOperator()
        {
            if (currentTextBox.Text.Length != 0 && char.IsDigit(currentTextBox.Text.Last()))
            {
                return true;
            }
            if (expression.Count == 0 || expression.Last() == "(" || expression.Last() == ",")
            {
                return false;
            }
            return true;
        }

        private void AddOperator(string operatorValue)
        {
            if (!IsPossibleToAddOperator())
            {
                currentTextBox.Text = "Ошибка";
                return;
            }
            currentTextBox.Text = operatorValue;
            expressionTextBox.Text += currentNumber + operatorValue;
            expression.Add(currentNumber);
            expression.Add(operatorValue);
            currentNumber = "";
        }

        private void AddLeftBracket(string bracket)
        {
            if (!IsPossibleToAddLeftBracket())
            {
                currentTextBox.Text = "Ошибка";
                return;
            }
            AddBracket("(");
        }

        private void AddRightBracket(string bracket)
        {
            if (!IsPossibleToAddRightBracket())
            {
                currentTextBox.Text = "Ошибка";
                return;
            }
            AddBracket(")");
        }

        private void AddBracket(string bracket)
        {
            currentTextBox.Text = bracket;
            expressionTextBox.Text += currentNumber + bracket;
            expression.Add(bracket);
            currentNumber = "";
        }

        private bool IsPossibleToAddLeftBracket()
        {
            return false;
        }

        private bool IsPossibleToAddRightBracket()
        {
            return false;
        }

        private bool IsPossibleToAddComma()
        {
            return false;
        }

        private void SquareRootButtonClick(object sender, EventArgs e)
        {
            if (currentNumber == "(" || currentNumber == ")" || currentNumber == "")
            {
                throw new ArgumentException("");
            }
            if (IsOperator(currentNumber))
            {

            }
            currentNumber = Math.Sqrt(double.Parse(currentNumber)).ToString();
        }

        private void DeleteLastDigitButtonClick(object sender, EventArgs e)
        {
            if (!IsNumberEntered())
            {
                return;
            }
            currentTextBox.Text = currentTextBox.Text.Substring(0, currentTextBox.Text.Length - 1);
            currentNumber = currentNumber.Substring(0, currentNumber.Length - 1);
        }

        private void CommaButtonClick(object sender, EventArgs e)
        {

        }

        private void GetResultButtonClick(object sender, EventArgs e)
        {

        }

        private void ChangeSignButtonClick(object sender, EventArgs e)
        {

        }

        private void ClearButtonClick(object sender, EventArgs e)
        {
            expression.Clear();
            currentNumber = "";
            expressionTextBox.Text = "";
            currentTextBox.Text = "";
        }

        private void ClearEntryButtonClick(object sender, EventArgs e)
        {
            if (IsNumberEntered())
            {
                currentNumber = "";
            }
            currentTextBox.Text = "";
        }

        private void ZeroButtonClick(object sender, EventArgs e) => AddDigit(0);
        private void OneButtonClick(object sender, EventArgs e) => AddDigit(1);
        private void TwoButtonClick(object sender, EventArgs e) => AddDigit(2);
        private void ThreeButtonClick(object sender, EventArgs e) => AddDigit(3);
        private void FourButtonClick(object sender, EventArgs e) => AddDigit(4);
        private void FiveButtonClick(object sender, EventArgs e) => AddDigit(5);
        private void SixButtonClick(object sender, EventArgs e) => AddDigit(6);
        private void SevenButtonClick(object sender, EventArgs e) => AddDigit(7);
        private void EightButtonClick(object sender, EventArgs e) => AddDigit(8);
        private void NineButtonClick(object sender, EventArgs e) => AddDigit(9);
        private void PlusButtonClick(object sender, EventArgs e) => AddOperator("+");
        private void MinusButtonClick(object sender, EventArgs e) => AddOperator("-");
        private void MultiplyButtonClick(object sender, EventArgs e) => AddOperator("*");
        private void DevideButtonClick(object sender, EventArgs e) => AddOperator("/");
        private void LeftBracketbuttonClick(object sender, EventArgs e) => AddLeftBracket();
        private void RightBracketbuttonClick(object sender, EventArgs e) => AddRightBracket();
        private bool IsOperator(string symbol)
            => symbol == "+" || symbol == "-" || symbol == "*" || symbol == "/";
    }
}
