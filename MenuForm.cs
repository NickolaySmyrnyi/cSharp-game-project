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
        Button startButton = new Button();
        IntroductionScene introductionScene;

        public MenuForm()
        {
            SetDefaultMenuFormView();

            SetDefaultStartButtonView();
            SetDefaultStartButtonControls();
        }

        private void SetDefaultMenuFormView()
        {
            SetDefaultMenuFormGeometry();
            SetDefaultMenuFormAppearance();
        }

        private void SetDefaultMenuFormAppearance()
        {
            BackgroundImage = Properties.Resources.Background;
        }

        private void SetDefaultMenuFormGeometry()
        {
            Size = new Size(1200, 1000);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            CenterToScreen();
        }

        private void SetDefaultStartButtonView()
        {
            SetDefaultStartButtonGeometry();
            SetDefaultStartButtonText();
            SetDefaultStartButtonAppearance();
        }

        private void SetDefaultStartButtonText()
        {
            startButton.Font = new Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Point);
            startButton.UseCompatibleTextRendering = true;
            startButton.Text = "Start Game";
        }

        private void SetDefaultStartButtonGeometry()
        {
            startButton.Size = new Size(400, 200);
            startButton.Location = new Point(400, 400);
        }

        private void SetDefaultStartButtonAppearance()
        {
            startButton.BackColor = Color.Transparent;
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            startButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            startButton.FlatAppearance.BorderSize = 0;
        }

        private void SetDefaultStartButtonControls()
        {
            startButton.MouseEnter += (sender, args) =>
            {
                startButton.ForeColor = Color.White;
            };
            startButton.MouseLeave += (sender, args) =>
            {
                startButton.ForeColor = Color.Black;
            };
            startButton.MouseClick += (sender, args) =>
            {
                ShowIntroductionScene();
            };
            Controls.Add(startButton);
        }

        private void ShowIntroductionScene()
        {
            Hide();
            introductionScene = new IntroductionScene(this);
            introductionScene.Show();
        }
    }
}
