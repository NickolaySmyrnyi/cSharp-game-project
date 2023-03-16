using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ulearn_project
{
    public partial class MenuForm : Form
    {
        Button startButton = new Button();
        IntroductionScene introductionScene = new IntroductionScene();
        CustomerScene customerScene = new CustomerScene();
        RacesScene racesScene = new RacesScene();
        PrivateFontCollection pfc = new PrivateFontCollection();

        public MenuForm()
        {
            pfc.AddFontFile("Fonts/lunchds.ttf");

            SetStartButtonDefaultView();
            SetStartButtonDefaultControls();

            SetMenuFormDefaultView();
            SetMenuFormDefaultControls();
            AddControlsToForm();
        }

        private void SetStartButtonDefaultView()
        {
            SetStartButtonDefaultGeometry();
            SetStartButtonDefaultText();
            SetStartButtonDefaultAppearance();
        }

        private void SetStartButtonDefaultGeometry()
        {
            startButton.Size = new Size(400, 200);
            startButton.Location = new Point(400, 400);
        }

        private void SetStartButtonDefaultText()
        {
            startButton.Font = new Font(pfc.Families[0], 30, FontStyle.Bold, GraphicsUnit.Point);
            startButton.UseCompatibleTextRendering = true;
            startButton.Text = "Start Game";
        }

        private void SetStartButtonDefaultAppearance()
        {
            startButton.BackColor = Color.Transparent;
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            startButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            startButton.FlatAppearance.BorderSize = 0;
        }

        private void SetStartButtonDefaultControls()
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
                Hide();
                ShowIntroductionScene();
            };
        }

        private void ShowIntroductionScene()
        {
            introductionScene.Show();
            Hide();
        }

        private void SetMenuFormDefaultView()
        {
            SetMenuFormDefaultGeometry();
            SetMenuFormDefaultAppearance();
        }

        private void SetMenuFormDefaultGeometry()
        {
            Size = new Size(1200, 1000);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            CenterToScreen();
        }

        private void SetMenuFormDefaultAppearance()
        {
            BackgroundImage = Image.FromFile("Images/Background.jpg");
        }

        private void SetMenuFormDefaultControls()
        {
            introductionScene.StartCustomerScene += () =>
            {
                customerScene.Show();
                introductionScene.Hide();
            };
            customerScene.StartRacesScene += () =>
            {
                racesScene.Show();
                customerScene.Hide();
            };
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
