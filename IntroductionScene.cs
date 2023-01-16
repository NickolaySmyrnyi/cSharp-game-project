using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ulearn_project
{
    public partial class IntroductionScene : Form
    {
        HelperModel helperModel = new HelperModel(Properties.Resources.ThomasShelby);
        Panel helperView = new Panel();
        CoefficientDesk desk = new CoefficientDesk();
        Label helperText = new Label();

        public IntroductionScene(MenuForm parent)
        {
            SetDefaultTextView();
            SetDefaultTextControls();

            SetDefaultHelperView();
            AddControlsToHelper();

            SetDefaultDeskView();

            SetDefaultIntroductionSceneView();
            SetDefaultIntroductionSceneControls();
            AddControlsToScene();

            helperModel.OutputText(helperModel.Texts[0]);
        }

        private void SetDefaultTextView()
        {
            helperText.Size = new Size(400, 150);
            helperText.Location = new Point(0, 350);
            helperText.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void SetDefaultTextControls()
        {
            helperModel.TextChanged += () => helperText.Text = helperModel.CurrentText;
        }

        private void SetDefaultHelperView()
        {
            SetDefaultHelperAppearance();
            SetDefaultHelperGeometry();
        }

        private void SetDefaultHelperAppearance()
        {
            helperView.BackgroundImage = helperModel.Picture;
        }

        private void SetDefaultHelperGeometry()
        {
            helperView.Size = new Size(400, 500);
            helperView.Location = new Point(800, 500);
        }

        private void AddControlsToHelper()
        {
            helperView.Controls.Add(helperText);
        }

        private void SetDefaultDeskView()
        {
            SetDefaultDeskAppearance();
            SetDefaultDeskGeometry();
        }

        private void SetDefaultDeskAppearance()
        {
            desk.BackgroundImage = Properties.Resources.woodenDesk;
        }

        private void SetDefaultDeskGeometry()
        {
            desk.Location = new Point(50, 200);
            desk.Size = new Size(700, 500);
        }

        private void SetDefaultIntroductionSceneView()
        {
            SetDefaultIntroductionSceneAppearance();
            SetDefaultIntroductionSceneGeometry();
        }

        private void SetDefaultIntroductionSceneAppearance()
        {
            BackgroundImage = Properties.Resources.Stadium;
        }

        private void SetDefaultIntroductionSceneGeometry()
        {
            Size = new Size(1200, 1000);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            CenterToScreen();
        }

        private void AddControlsToScene()
        {
            Controls.Add(helperView);
            Controls.Add(desk);
        }

        private void SetDefaultIntroductionSceneControls()
        {
            Closing += (sender, args) =>
            {
                Application.Exit();
            };
            KeyDown += (sender, args) =>
            {
                if (args.KeyCode == Keys.Enter)
                {
                    MakeHelperOutputText();
                }
            };
        }

        private void MakeHelperOutputText()
        {
            foreach (var text in helperModel.Texts)
            {
                if (text.IsOutputable)
                    helperModel.OutputText(text);
            }
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
