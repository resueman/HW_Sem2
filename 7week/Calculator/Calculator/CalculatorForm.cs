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
    public partial class CalculatorForm : System.Windows.Forms.Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void ZeroButtonClick(object sender, EventArgs e) => textBox.Text += 0;        
        private void OneButtonClick(object sender, EventArgs e) => textBox.Text += 1;
        private void TwoButtonClick(object sender, EventArgs e) => textBox.Text += 2;
        private void ThreeButtonClick(object sender, EventArgs e) => textBox.Text += 3;
        private void FourButtonClick(object sender, EventArgs e) => textBox.Text += 4;
        private void FiveButtonClick(object sender, EventArgs e) => textBox.Text += 5;
        private void SixButtonClick(object sender, EventArgs e) => textBox.Text += 6;
        private void SevenButtonClick(object sender, EventArgs e) => textBox.Text += 7;
        private void EightButtonClick(object sender, EventArgs e) => textBox.Text += 8;
        private void NineButtonClick(object sender, EventArgs e) => textBox.Text += 9;

        private void CommaButtonClick(object sender, EventArgs e)
        {
            textBox.Text += ",";
        }

        private void DivisionButtonClick(object sender, EventArgs e)
        {
            textBox.Text += "÷";
        }

        private void MultiplicationButtonClick(object sender, EventArgs e)
        {
            textBox.Text += "*";

        }

        private void SubtructionButtonClick(object sender, EventArgs e)
        {
            textBox.Text += "-";
        }

        private void AdditionButtonClick(object sender, EventArgs e)
        {
            textBox.Text += "+";
        }

        private void RightBracketClick(object sender, EventArgs e)
        {
            textBox.Text += ")";
        }

        private void LeftBracketClick(object sender, EventArgs e)
        {
            textBox.Text += "(";
        }
    }
}
