using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Ulearn_project
{
    class CoefficientDesk : Panel
    {
        List<TextBox> coefficientBoxes = new List<TextBox>();

        public CoefficientDesk()
        {
            InitializeCoefficientBoxes(6);
            SetCoefficientBoxesDefaultView();

            AddControlsToDesk();
        }

        private void InitializeCoefficientBoxes(int quantity)
        {
            for (int i = 0; i < quantity; ++i)
                coefficientBoxes.Add(new TextBox());
        }

        private void SetCoefficientBoxesDefaultView()
        {
            for (int i = 0, n = coefficientBoxes.Count; i < n; ++i)
            {
                coefficientBoxes[i].Text = "1.0";
                coefficientBoxes[i].Location = new Point(200, 15 + 75 * i);
                coefficientBoxes[i].Size = new Size(50, 50);
            }
        }

        private void AddControlsToDesk()
        {
            for (int i = 0, n = coefficientBoxes.Count; i < n; ++i)
                Controls.Add(coefficientBoxes[i]);
        }
    }
}
