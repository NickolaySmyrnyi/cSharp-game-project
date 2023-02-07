using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

namespace Ulearn_project
{
    class DeskView : Panel
    {
        DeskModel deskModel = new DeskModel();
        List<TextBox> coefficientBoxes = new List<TextBox>();
        List<Label> horseNames = new List<Label>();
        Button confirmButton = new Button();
        PrivateFontCollection pfc = new PrivateFontCollection();

        public DeskView()
        {
            pfc.AddFontFile("Fonts/lunchds.ttf");

            InitializeHorseNames();
            SetHorseNamesDefaultView();

            InitializeCoefficientBoxes();
            SetCoefficientBoxesDefaultView();

            SetConfirmButtonDefaultView();
            SetButtonDefaultControls();

            SetDeskDefaultView();
            AddControlsToDesk();
        }

        private void InitializeHorseNames()
        {
            for (int i = 0, n = deskModel.Horses.Count; i < n; ++i)
                horseNames.Add(new Label());
        }

        private void SetHorseNamesDefaultView()
        {
            for (int i = 0, n = horseNames.Count; i < n; ++i)
            {
                horseNames[i].Font = new Font(pfc.Families[0], 15, GraphicsUnit.Point);
                horseNames[i].Text = deskModel.Horses[i].Name;
                horseNames[i].Location = new Point(25, 15 + 75 * i);
                horseNames[i].Size = new Size(300, 30);
                horseNames[i].BackColor = Color.Transparent;
            }
        }

        private void InitializeCoefficientBoxes()
        {
            for (int i = 0, n = deskModel.Horses.Count; i < n; ++i)
                coefficientBoxes.Add(new TextBox());
        }

        private void SetCoefficientBoxesDefaultView()
        {
            for (int i = 0, n = coefficientBoxes.Count; i < n; ++i)
            {
                coefficientBoxes[i].Font = new Font(pfc.Families[0], 10, GraphicsUnit.Point);
                coefficientBoxes[i].Text = deskModel.Horses[i].Coefficient.ToString();
                coefficientBoxes[i].Location = new Point(350, 15 + 75 * i);
                coefficientBoxes[i].Size = new Size(50, 50);
                coefficientBoxes[i].TabStop = false;
                coefficientBoxes[i].Enabled = false;
            }
        }

        private void SetConfirmButtonDefaultView()
        {
            confirmButton.Font = new Font(pfc.Families[0], 10, GraphicsUnit.Point);
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
            BackgroundImage = Image.FromFile("Images/woodenDesk.jpg");
            Size = new Size(700, 520);
        }

        private void AddControlsToDesk()
        {
            Controls.Add(confirmButton);
            for (int i = 0, n = coefficientBoxes.Count; i < n; ++i)
            {
                Controls.Add(coefficientBoxes[i]);
                Controls.Add(horseNames[i]);
            }
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
