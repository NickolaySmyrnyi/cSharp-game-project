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
        HelperView helperView = new HelperView();
        HelperModel helperModel = new HelperModel();
        DeskView deskView = new DeskView();

        public IntroductionScene(MenuForm parent)
        {
            SetHelperDefaultView();

            SetDeskDefaultView();

            SetIntroductionSceneDefaultView();
            SetIntroductionSceneDefaultControls();
            AddControlsToScene();

            helperModel.OutputText(helperModel.Texts[0]);
        }

        private void SetHelperDefaultView()
        {
            helperView.Location = new Point(800, 500);
        }

        private void SetDeskDefaultView()
        {
            deskView.Location = new Point(50, 200);
        }

        private void SetIntroductionSceneDefaultView()
        {
            SetIntroductionSceneDefaultAppearance();
            SetIntroductionSceneDefaultGeometry();
        }

        private void SetIntroductionSceneDefaultAppearance()
        {
            BackgroundImage = Properties.Resources.Stadium;
        }

        private void SetIntroductionSceneDefaultGeometry()
        {
            Size = new Size(1200, 1000);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            CenterToScreen();
        }

        private void AddControlsToScene()
        {
            Controls.Add(helperView);
            Controls.Add(deskView);
        }

        private void SetIntroductionSceneDefaultControls()
        {
            Closing += (sender, args) => Application.Exit();
            KeyDown += (sender, args) =>
            {
                if (args.KeyCode == Keys.Enter)
                {
                    helperModel.MakeHelperOutputText();
                }
            };
            helperModel.FirstInteraction += () => deskView.PrepareForFirstInteraction();
            helperModel.TextChanged += () => helperView.SetTextToHelper(helperModel.CurrentText);
            deskView.FirstInteractionEnded += () => helperModel.EndFirstInteraction();
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
