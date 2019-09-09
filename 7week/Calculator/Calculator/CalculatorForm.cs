using System;
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
            expressionTextBox.DataBindings.Add("Text", expressionBuilder, "Expression");
            currentTextBox.TextAlign = HorizontalAlignment.Right;
            expressionTextBox.TextAlign = HorizontalAlignment.Right;
        }

        private readonly ExpressionBuilder expressionBuilder;

        private void CurrentTextBoxTextChanged(object sender, EventArgs e)
        {
            if (expressionBuilder.Expression == "")
            {
                currentTextBox.SelectionStart = 0;
            }
            else
            {
                currentTextBox.SelectionStart = currentTextBox.Text.Length;
            }
            currentTextBox.ScrollToCaret();
        }

        private void ExpressionTextBoxTextChanged(object sender, EventArgs e)
        {
            expressionTextBox.SelectionStart = expressionTextBox.Text.Length;
            expressionTextBox.ScrollToCaret();
        }

        private void DigitButtonClick(object sender, EventArgs e)
            => expressionBuilder.AddDigit(char.Parse((sender as Button).Text));

        private void OperatorButtonClick(object sender, EventArgs e)
            => expressionBuilder.AddOperator(char.Parse((sender as Button).Text));

        private void CommaButtonClick(object sender, EventArgs e)
            => expressionBuilder.AddComma();

        private void SquareRootButtonClick(object sender, EventArgs e)
            => expressionBuilder.AddSquareRoot();

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

        private void GetResultButtonClick(object sender, EventArgs e)
            => GetResult();

        public void GetResult()
        {
            try
            {
                if (expressionBuilder.Complete())
                {
                    var postfixExpression = InfixToPostfixConverter.Convert(expressionBuilder.Expression);
                    var result = PostfixCalculator.Calculate(postfixExpression);
                    expressionBuilder.Clear();
                    expressionBuilder.AssignCurrentNumberToResult(result);
                }
            }
            catch (DivideByZeroException)
            {
                expressionBuilder.Clear();
                currentTextBox.Text = "Division by zero!";
            }
        }
    }
}
