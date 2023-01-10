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
        Helper helperModel = new Helper(Properties.Resources.ThomasShelby);
        PictureBox helperView = new PictureBox();
        Label helperText = new Label();

        public IntroductionScene(MenuForm parent)
        {
            SetDefaultIntroductionSceneView();
            SetDefaultIntroductionSceneControls();

            SetDefaultHelperView();
            SetDefaultHelperControls();

            SetDefaultTextView();
            SetDefaultTextControls();
            SetTextVisualization();

            helperModel.OutputText(helperModel.Texts[0]);
        }

        private void SetDefaultIntroductionSceneView()
        {
            SetDefaultIntroductionSceneGeometry();
            SetDefaultIntroductionSceneAppearance();
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

        private void SetDefaultIntroductionSceneControls()
        {
            Closing += (sender, args) =>
            {
                Application.Exit();
            };
            KeyDown += (sender, args) =>
            {
                foreach (var text in helperModel.Texts)
                {
                    if (text.IsOutputable)
                        helperModel.OutputText(text);
                }
            };
        }

        private void SetDefaultHelperView()
        {
            SetDefaultHelperGeometry();
            SetDefaultHelperAppearance();
        }

        private void SetDefaultHelperAppearance()
        {
            helperView.Image = helperModel.Picture;
        }

        private void SetDefaultHelperGeometry()
        {
            helperView.Size = new Size(400, 500);
            helperView.Location = new Point(800, 500);
        }
        private void SetDefaultHelperControls()
        {
            Controls.Add(helperView);
        }

        private void SetDefaultTextView()
        {
            helperText.Size = new Size(400, 150);
            helperText.Location = new Point(0, 350);
            helperText.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void SetDefaultTextControls()
        {
            helperView.Controls.Add(helperText);
        }

        private void SetTextVisualization()
        {
            helperModel.TextChanged += () => helperText.Text = helperModel.CurrentText;
        }
    }
}
