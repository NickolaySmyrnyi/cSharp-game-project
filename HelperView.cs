using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

namespace Ulearn_project
{
    class HelperView : Panel
    {
        Label helperText = new Label();
        PrivateFontCollection pfc = new PrivateFontCollection();
        public HelperView()
        {
            pfc.AddFontFile("Fonts/lunchds.ttf");
            SetTextDefaultView();

            SetHelperDefaultView();
            AddControlsToHelper();
        }

        private void SetTextDefaultView()
        {
            helperText.Font = new Font(pfc.Families[0], 10, GraphicsUnit.Point);
            helperText.Size = new Size(400, 150);
            helperText.Location = new Point(0, 350);
            helperText.TextAlign = ContentAlignment.TopCenter;
        }

        private void SetHelperDefaultView()
        {
            BackgroundImage = Image.FromFile("Images/ThomasShelby.jpg");
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
