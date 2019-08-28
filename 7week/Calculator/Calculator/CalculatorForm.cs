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
            currentTextBox.DataBindings.Add("Text", expressionBuilder, "CurrentNumber");
            expressionTextBox.DataBindings.Add("Text", expressionBuilder, "StringExpression");
        }

        private readonly ExpressionBuilder expressionBuilder;

        private void DigitButtonClick(object sender, EventArgs e)
            => expressionBuilder.AddDigit(int.Parse((sender as Button).Text));

        private void OperatorButtonClick(object sender, EventArgs e)
            => expressionBuilder.AddOperator((sender as Button).Text);

        private void CommaButtonClick(object sender, EventArgs e)
            => expressionBuilder.AddComma();

        private void SquareRootButtonClick(object sender, EventArgs e)
            => expressionBuilder.AddRoot();

        private void GetResultButtonClick(object sender, EventArgs e)
            => expressionBuilder.GetResult();

        private void ChangeSignButtonClick(object sender, EventArgs e)
            => expressionBuilder.ChangeSign();

        private void DeleteLastDigitButtonClick(object sender, EventArgs e)
            => expressionBuilder.DeleteLastDigit();

        private void ClearButtonClick(object sender, EventArgs e)
            => expressionBuilder.Clear();

        private void ClearEntryButtonClick(object sender, EventArgs e)
            => expressionBuilder.ClearEntry();

        private void LeftBracketbuttonClick(object sender, EventArgs e)
            => expressionBuilder.AddOpeningBracket();

        private void RightBracketbuttonClick(object sender, EventArgs e)
            => expressionBuilder.AddClosingBracket();
    }
}
