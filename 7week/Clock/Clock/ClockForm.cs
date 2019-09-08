using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Clock
{
    public partial class ClockForm : Form
    {
        public ClockForm()
        {
            InitializeComponent();
        }

        private void ClockFormLoad(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToString("dd.MM.yyyy", CultureInfo.CreateSpecificCulture("en-US"));
            timeLabel.Text = DateTime.Now.ToString("T");
        }
    }
}
