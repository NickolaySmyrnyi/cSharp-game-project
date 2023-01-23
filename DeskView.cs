using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Ulearn_project
{
    class DeskView : Panel
    {
        List<TextBox> coefficientBoxes = new List<TextBox>();
        Button confirmButton = new Button();

        public DeskView()
        {
            InitializeCoefficientBoxes(6);
            SetCoefficientBoxesDefaultView();

            SetConfirmButtonDefaultView();
            SetButtonDefaultControls();

            SetDeskDefaultView();
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
                coefficientBoxes[i].TabStop = false;
                coefficientBoxes[i].Enabled = false;
            }
        }

        private void SetConfirmButtonDefaultView()
        {
            confirmButton.Location = new Point(250, 445);
            confirmButton.Size = new Size(200, 70);
            confirmButton.Text = "CONFIRM";
            confirmButton.TextAlign = ContentAlignment.MiddleCenter;
            confirmButton.Enabled = false;
        }

        private void SetButtonDefaultControls()
        {
            confirmButton.MouseClick += (e, args) => FirstInteractionEnded();
        }

        private void SetDeskDefaultView()
        {
            BackgroundImage = Properties.Resources.woodenDesk;
            Size = new Size(700, 520);
        }

        private void AddControlsToDesk()
        {
            Controls.Add(confirmButton);
            for (int i = 0, n = coefficientBoxes.Count; i < n; ++i)
                Controls.Add(coefficientBoxes[i]);
        }

        public void PrepareForFirstInteraction()
        {
            for (int i = 0, n = coefficientBoxes.Count; i < n; ++i)
                coefficientBoxes[i].Enabled = true;
            confirmButton.Enabled = true;
        }



        public event Action FirstInteractionEnded;
    }
}
