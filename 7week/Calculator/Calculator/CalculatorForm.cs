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
            expression = new Expression();
        }

        private readonly Expression expression;

        private bool IsPossibleToAddComma()
            => expression.Count != 0 && expression.Last() != ")" && expression.CurrentNumber == "" 
            || expression.CurrentNumber != "" && !expression.ContainComma;
        
        private void CommaButtonClick(object sender, EventArgs e)
        {

        }

        private void SquareRootButtonClick(object sender, EventArgs e)
        {

        }

        private void GetResultButtonClick(object sender, EventArgs e)
        {
            
        }

        private void ChangeSignButtonClick(object sender, EventArgs e)
        {
            if (expression.CurrentNumber != "")
            {
                expression.ChangeCurrentNumberSign();
                currentTextBox.Text = expression.CurrentNumber;
                return;
            }
            if (expression.Count != 0)
            {
                expression.ChangeSign();
                expressionTextBox.Text = expression.ToString();
            }
        }

        private void DeleteLastDigitButtonClick(object sender, EventArgs e)
        {
            if (expression.CurrentNumber == "")
            {
                return;
            }
            currentTextBox.Text = currentTextBox.Text.Substring(0, currentTextBox.Text.Length - 1);
            expression.DeleteLastDigit();
        }

        private void ClearButtonClick(object sender, EventArgs e)
        {
            expression.Clear();
            expressionTextBox.Text = "";
            currentTextBox.Text = "";
        }

        private void ClearEntryButtonClick(object sender, EventArgs e)
        {
            expression.ClearEntry();
            currentTextBox.Text = "";
        }

        private void AddDigit(int digit)
        {
            if (expression.CurrentNumber == "" || currentTextBox.Text == "Error")
            {
                currentTextBox.Text = "";
            }
            if (!expression.AddDigit(digit))
            {
                currentTextBox.Text = "Error";
                return;
            }
            currentTextBox.Text += digit.ToString();
        }

        private void AddOperator(string operation)
        {
            var number = expression.CurrentNumber;
            if (!expression.AddOperator(operation))
            {
                currentTextBox.Text = "Error";
                return;
            }
            currentTextBox.Text = operation;
            expressionTextBox.Text += number + operation;
        }

        private void AddLeftBracket()
        {
            if (!expression.AddLeftBracket())
            {
                currentTextBox.Text = "Error";
                return;
            }
            currentTextBox.Text = "(";
            expressionTextBox.Text += expression.CurrentNumber + "(";
        }

        private void AddRightBracket()
        {
            var number = expression.CurrentNumber;
            if (!expression.AddRightBracket())
            {
                currentTextBox.Text = "Error";
                return;
            }
            currentTextBox.Text = ")";
            expressionTextBox.Text += number + ")";
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
    }
}
