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
            SetDefaultStartButtonView();
            SetDefaultStartButtonControls();

            SetDefaultMenuFormView();
            AddControlsToForm();
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
        }

        private void ShowIntroductionScene()
        {
            Hide();
            introductionScene = new IntroductionScene(this);
            introductionScene.Show();
        }

        private void SetDefaultMenuFormView()
        {
            SetDefaultMenuFormGeometry();
            SetDefaultMenuFormAppearance();
        }

        private void SetDefaultMenuFormGeometry()
        {
            Size = new Size(1200, 1000);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            CenterToScreen();
        }

        private void SetDefaultMenuFormAppearance()
        {
            BackgroundImage = Properties.Resources.Background;
        }

        private void AddControlsToForm()
        {
            Controls.Add(startButton);
        }

        //enables double buffering for all controls in the form
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleparam = base.CreateParams;
                handleparam.ExStyle |= 0x02000000;
                return handleparam;
            }
        }
    }
}
