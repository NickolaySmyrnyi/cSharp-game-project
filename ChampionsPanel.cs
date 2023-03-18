using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

namespace Ulearn_project
{
    class ChampionsPanel : Panel
    {
        List<Label> champions = new List<Label>();
        PrivateFontCollection pfc = new PrivateFontCollection();
        Button nextButton = new Button();

        public ChampionsPanel()
        {
            pfc.AddFontFile("Fonts/lunchds.ttf");

            Hide();

            InitializeChampions();
            SetChampionsDefaultView();

            SetNextButtonDefultView();

            SetChampionsPanelDefaultView();
            SetChampionsPanelDefaultControls();
            AddControlsToPanel();
        }

        private void InitializeChampions()
        {
            for (int i = 0; i < DeskModel.Horses.Count; ++i)
                champions.Add(new Label());
        }

        private void SetChampionsDefaultView()
        {
            for (int i = 0, n = champions.Count; i < n; ++i)
            {
                champions[i].Size = new Size(300, 30);
                champions[i].Location = new Point(50, 15 + 75 * i);
                champions[i].BackColor = Color.Transparent;
                champions[i].Font = new Font(pfc.Families[0], 15, GraphicsUnit.Point);
            }
        }

        private void SetNextButtonDefultView()
        {
            nextButton.Size = new Size(200, 70);
            nextButton.Location = new Point(100, 440);
            nextButton.Font = new Font(pfc.Families[0], 15, GraphicsUnit.Point);
            nextButton.BackColor = Color.Transparent;
            nextButton.Text = "NEXT";
        }

        private void SetChampionsPanelDefaultView()
        {
            Size = new Size(400, 520);
            BackgroundImage = Image.FromFile("Images/woodenDesk.jpg");
        }

        private void SetChampionsPanelDefaultControls()
        {
            Paint += (sender, args) => PaintFrame(args.Graphics);
            nextButton.Click += (sender, args) =>
            {
                NextPanel();
                Hide();
            };
        }

        private void PaintFrame(Graphics gr)
        {
            ControlPaint.DrawBorder(gr, ClientRectangle,
            Color.Black, 10, ButtonBorderStyle.Solid,
            Color.Black, 10, ButtonBorderStyle.Solid,
            Color.Black, 10, ButtonBorderStyle.Solid,
            Color.Black, 10, ButtonBorderStyle.Solid);
        }

        private void AddControlsToPanel()
        {
            Controls.Add(nextButton);
            foreach (var champion in champions)
                Controls.Add(champion);
        }

        public void ShowChampions(RaceSimulation simulation)
        {
            for (int i = 0, n = champions.Count; i < n; ++i)
                champions[i].Text = (i + 1).ToString() + ". " + simulation.Champions.Dequeue().Name;
            Show();
        }

        public event Action NextPanel;
    }
}
