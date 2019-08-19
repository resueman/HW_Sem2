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
            expressionBuilder = new ExpressionBuilder();
        }

        private readonly ExpressionBuilder expressionBuilder;

        private void UpdateTextBoxes()
        {
            currentTextBox.Text = expressionBuilder.CurrentTextBox;
            expressionTextBox.Text = expressionBuilder.ExpressionTextBox;
        }
        
        private void CommaButtonClick(object sender, EventArgs e)
        {
            expressionBuilder.AddComma();
            UpdateTextBoxes();
        }

        private void SquareRootButtonClick(object sender, EventArgs e)
        {

        }

        private void GetResultButtonClick(object sender, EventArgs e)
        {
         
        }

        private void ChangeSignButtonClick(object sender, EventArgs e)
        {
            expressionBuilder.ChangeSign();
            UpdateTextBoxes();
        }

        private void DeleteLastDigitButtonClick(object sender, EventArgs e)
        {
            expressionBuilder.DeleteLastDigit();
            UpdateTextBoxes();
        }

        private void ClearButtonClick(object sender, EventArgs e)
        {
            expressionBuilder.Clear();
            UpdateTextBoxes();
        }

        private void ClearEntryButtonClick(object sender, EventArgs e)
        {
            expressionBuilder.ClearEntry();
            UpdateTextBoxes();
        }

        private void DigitButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            expressionBuilder.AddDigit(int.Parse(button.Text));
            UpdateTextBoxes();
        }

        private void OperatorButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            expressionBuilder.AddOperator(button.Text);
            UpdateTextBoxes();
        }

        private void LeftBracketbuttonClick(object sender, EventArgs e)
        {
            expressionBuilder.AddLeftBracket();
            UpdateTextBoxes();
        }

        private void RightBracketbuttonClick(object sender, EventArgs e)
        {
            expressionBuilder.AddRightBracket();
            UpdateTextBoxes();
        }
    }
}
