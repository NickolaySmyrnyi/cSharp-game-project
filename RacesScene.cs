using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

namespace Ulearn_project
{
    class RacesScene : Form
    {
        PrivateFontCollection pfc = new PrivateFontCollection();
        Button startRacesButton = new Button();
        PictureBox grass1 = new PictureBox();
        PictureBox grass2 = new PictureBox();
        List<PictureBox> horses = new List<PictureBox>();
        Pen pen = new Pen(Color.White, 5);
        public RacesScene()
        {
            pfc.AddFontFile("Fonts/lunchds.ttf");

            InitializeHorses();
            SetHorsesDefaultView();

            SetStartRacesButtonDefaultView();

            SetGrassDefaultView();

            SetRacesSceneDefaultView();
            SetRacesSceneDefaultControls();
            AddControlsToScene();
        }

        private void InitializeHorses()
        {
            for (int i = 0, n = DeskModel.Horses.Count; i < n; ++i)
                horses.Add(new PictureBox());
        }

        private void SetHorsesDefaultView()
        {
            for (int i = 0, n = horses.Count; i < n; ++i)
            {
                horses[i].Image = Image.FromFile("Images/horse.png");
                horses[i].Size = new Size(64, 64);
                horses[i].Location = new Point(0, 218 + i * 100);
            }
        }

        private void SetStartRacesButtonDefaultView()
        {
            startRacesButton.Size = new Size(200, 70);
            startRacesButton.Location = new Point(500, 865);
            startRacesButton.Text = "Start Races!";
            startRacesButton.BackColor = Color.AliceBlue;
            startRacesButton.Font = new Font(pfc.Families[0], 10, GraphicsUnit.Point);
        }

        private void SetGrassDefaultView()
        {
            grass1.Image = Image.FromFile("Images/grass.jpg");
            grass2.Image = Image.FromFile("Images/grass.jpg");
            grass1.Size = new Size(1200, 200);
            grass2.Size = new Size(1200, 200);
            grass1.Location = new Point(0, 0);
            grass2.Location = new Point(0, 800);
        }

        private void SetRacesSceneDefaultView()
        {
            BackColor = Color.OrangeRed;
            Size = new Size(1200, 1000);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            CenterToScreen();
        }

        private void SetRacesSceneDefaultControls()
        {
            Closing += (sender, args) => Application.Exit();
            Paint += (sender, args) => DrawRunningTracks(args.Graphics);
        }

        private void DrawRunningTracks(Graphics gr)
        {
            for (int y = 200; y <= 700; y += 100)
            {
                gr.FillRectangle(Brushes.White, new Rectangle(1000, y, 50, 50));
                gr.FillRectangle(Brushes.Black, new Rectangle(1050, y, 50, 50));
                gr.FillRectangle(Brushes.Black, new Rectangle(1000, y + 50, 50, 50));
                gr.FillRectangle(Brushes.White, new Rectangle(1050, y + 50, 50, 50));
            }
            for (int y = 300; y <= 700; y += 100)
                gr.DrawLine(pen, new Point(0, y), new Point(1200, y));
        }

        private void AddControlsToScene()
        {
            Controls.Add(startRacesButton);
            Controls.Add(grass1);
            Controls.Add(grass2);
            for (int i = 0, n = horses.Count; i < n; ++i)
            {
                Controls.Add(horses[i]);
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
