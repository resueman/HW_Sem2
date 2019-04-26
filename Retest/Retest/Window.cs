using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retest
{
    /// <summary>
    /// Class which realizes what happens in case of mouse movement and pressing on button
    /// </summary>
    public partial class Window : System.Windows.Forms.Form
    {
        public Window()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            int x = button.Location.X;
            int y = button.Location.Y;

            var random = new Random();
            int direction = random.Next(1, 4);
            switch (direction)
            {
                case 1:
                    button.Location = new Point(x - 2 * button.Width, y + 2 * button.Height);
                    break;
                case 2:
                    button.Location = new Point(x + 2 * button.Width, y - 2 * button.Height);
                    break;
                case 3:
                    button.Location = new Point(x + 2 * button.Width, y + 2 * button.Height);
                    break;
                case 4:
                    button.Location = new Point(x - 2 * button.Width, y - 2 * button.Height);
                    break;
            }
            if (button.Left < button.Width || button.Left + button.Width > ClientSize.Width - button.Width)
            {
                button.Left = ClientSize.Width / 2;
            }
            if (button.Top < button.Height || button.Top + button.Height > ClientSize.Height - button.Height)
            {
                button.Top = ClientSize.Height / 2;
            }
        }
    }
}
