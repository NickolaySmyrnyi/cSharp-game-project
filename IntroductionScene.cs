using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace Ulearn_project
{
    public partial class IntroductionScene : Form
    {
        HelperView helperView = new HelperView();
        HelperModel helperModel = new HelperModel();
        Label moneyView = new Label();
        DeskView deskView = new DeskView();
        PrivateFontCollection pfc = new PrivateFontCollection();

        public IntroductionScene()
        {
            pfc.AddFontFile("Fonts/lunchds.ttf");

            SetHelperDefaultView();
            SetHelperDefaultControls();

            SetDeskDefaultView();
            SetDeskDefaultControls();

            SetMoneyDefaultView();

            SetIntroductionSceneDefaultView();
            SetIntroductionSceneDefaultControls();
            AddControlsToScene();

            helperModel.OutputText(helperModel.Texts[0]);
        }

        private void SetHelperDefaultView()
        {
            helperView.Location = new Point(800, 400);
        }

        private void SetHelperDefaultControls()
        {
            helperModel.FirstInteraction += () => deskView.PrepareForFirstInteraction();
            helperModel.TextChanged += () => helperView.SetTextToHelper(helperModel.CurrentText);
            helperModel.StartCustomerScene += () => StartCustomerScene();
        }

        private void SetDeskDefaultView()
        {
            deskView.Location = new Point(50, 200);
        }

        private void SetDeskDefaultControls()
        {
            deskView.FirstInteractionEnded += () => helperModel.EndFirstInteraction();
        }

        private void SetMoneyDefaultView()
        {
            moneyView.BackColor = Color.Transparent;
            moneyView.ForeColor = Color.Gold;
            moneyView.Text = "Money: " + MoneyModel.Money.ToString();
            moneyView.Font = new Font(pfc.Families[0], 30, GraphicsUnit.Point);
            moneyView.Size = new Size(400, 70);
            moneyView.Location = new Point(800, 20);
        }

        private void SetIntroductionSceneDefaultView()
        {
            BackgroundImage = Image.FromFile("Images/Stadium.jpg");
            Size = new Size(1200, 1000);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            CenterToScreen();
        }

        private void AddControlsToScene()
        {
            Controls.Add(moneyView);
            Controls.Add(helperView);
            Controls.Add(deskView);
        }

        private void SetIntroductionSceneDefaultControls()
        {
            Closing += (sender, args) => Application.Exit();
            KeyDown += (sender, args) =>
            {
                if (args.KeyCode == Keys.Enter && helperModel.CanPressEnter)
                {
                    helperModel.MakeHelperOutputText();
                }
            };
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

        public event Action StartCustomerScene;
    }
}
