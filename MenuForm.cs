using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ulearn_project
{
    public partial class MenuForm : Form
    {
        Button startButton;
        public MenuForm()
        {
            BackgroundImage = Properties.Resources.Background;

            Size = new Size(1200, 1000);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            addStartButton();
        }

        private void addStartButton()
        {
            startButton = new Button();
            startButton.Text = "Start Game";
            startButton.Size = new Size(400, 200);
            startButton.Location = new Point(400, 400);
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.BackColor = Color.Transparent;
            startButton.UseCompatibleTextRendering = true;
            startButton.Font = new Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Point);
            startButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            startButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            startButton.FlatAppearance.BorderSize = 0;
            startButton.MouseEnter += (sender, args) =>
            {
                startButton.ForeColor = Color.White;
            };
            startButton.MouseLeave += (sender, args) =>
            {
                startButton.ForeColor = Color.Black;
            };
            Controls.Add(startButton);
        }
    }
}
