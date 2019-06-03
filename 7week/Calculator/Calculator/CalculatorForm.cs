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

        private void DigitButtonClick(object sender, EventArgs e)
        {
            textBox.Text += (sender as Button).Text;
        }

        private void CommaButtonClick(object sender, EventArgs e)
        {
            textBox.Text += ",";
        }

        private void OperatorButtonClick(object sender, EventArgs e)
        {
            textBox.Text += (sender as Button).Text;
        }

        private void BracketButtonClick(object sender, EventArgs e)
        {
            textBox.Text += (sender as Button).Text;
        }
    }
}
