using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Ulearn_project
{
    class HelperView : Panel
    {
        Label helperText = new Label();

        public HelperView()
        {
            SetTextDefaultView();

            SetHelperDefaultView();
            AddControlsToHelper();
        }

        private void SetTextDefaultView()
        {
            helperText.Size = new Size(400, 150);
            helperText.Location = new Point(0, 350);
            helperText.TextAlign = ContentAlignment.TopCenter;
        }

        private void SetHelperDefaultView()
        {
            BackgroundImage = Properties.Resources.ThomasShelby;
            Size = new Size(400, 500);
        }

        private void AddControlsToHelper()
        {
            Controls.Add(helperText);
        }

        public void SetTextToHelper(string text)
        {
            helperText.Text = text;
        }
    }
}
