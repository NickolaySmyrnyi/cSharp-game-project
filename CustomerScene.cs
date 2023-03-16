using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using ScottPlot;

namespace Ulearn_project
{
    public partial class CustomerScene : Form
    {
        PrivateFontCollection pfc = new PrivateFontCollection();

        CustomerSimulation simulation = new CustomerSimulation();

        Button simulationButton = new Button();
        Button toRacesButton = new Button();
        Label numberOfParticipants = new Label();
        Label dayCounter = new Label();
        List<Label> horseNames = new List<Label>();
        List<Label> axisLabels = new List<Label>();
        List<Label> moneyForHorses = new List<Label>();

        List<Rectangle> moneyBars = new List<Rectangle>();
        Pen pen = new Pen(Color.White, 4);

        public CustomerScene()
        {
            pfc.AddFontFile("Fonts/lunchds.ttf");

            InitializeMoneyBars();

            InitializeMoneyForHorses();
            SetMoneyForHorsesDefaultView();

            InitializeAxisLabels();
            SetAxisLabelsDefaultView();

            InitializeHorseNames();
            SetHorseNamesDefaultView();

            SetDayCounterDefaultView();

            SetNumberOfParticipantsDefaultView();

            SetSimulationButtonDefaultView();
            SetSimulationButtonDefaultControls();

            SetToRacesButtonDefaultView();
            SetToRacesButtonDefaultControls();

            SetCustomerSceneDefaultView();
            SetCustomerSceneDefaultControls();
            AddControlsToCustomerScene();
        }

        private void InitializeMoneyBars()
        {
            for (int i = 0, n = DeskModel.Horses.Count; i < n; ++i)
                moneyBars.Add(new Rectangle(new Point(175 + 150 * i, 750), new Size(100, 0)));
        }

        private void InitializeMoneyForHorses()
        {
            for (int i = 0, n = DeskModel.Horses.Count; i < n; ++i)
                moneyForHorses.Add(new Label());
        }

        private void SetMoneyForHorsesDefaultView()
        {
            for (int i = 0, n = moneyForHorses.Count; i < n; ++i)
            {
                moneyForHorses[i].Text = "0";
                moneyForHorses[i].Size = new Size(100, 50);
                moneyForHorses[i].Location = new Point(175 + 150 * i, 700);
                moneyForHorses[i].Font = new Font(pfc.Families[0], 20, FontStyle.Bold, GraphicsUnit.Point);
                moneyForHorses[i].BackColor = Color.Transparent;
                moneyForHorses[i].ForeColor = Color.Gold;
                moneyForHorses[i].TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void InitializeAxisLabels()
        {
            for (int i = 0; i < 10; ++i)
                axisLabels.Add(new Label());
        }

        private void SetAxisLabelsDefaultView()
        {
            for (int i = 0, n = axisLabels.Count; i < n; ++i)
            {
                axisLabels[i].Text = (50 + 50 * i).ToString();
                axisLabels[i].Size = new Size(50, 50);
                axisLabels[i].Location = new Point(70, 675 - i * 50);
                axisLabels[i].Font = new Font(pfc.Families[0], 10, GraphicsUnit.Point);
                axisLabels[i].BackColor = Color.Transparent;
                axisLabels[i].ForeColor = Color.White;
                axisLabels[i].TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void InitializeHorseNames()
        {
            for (int i = 0, n = DeskModel.Horses.Count; i < n; ++i)
                horseNames.Add(new Label());
        }

        private void SetHorseNamesDefaultView()
        {
            for (int i = 0, n = horseNames.Count; i < n; ++i)
            {
                horseNames[i].Text = DeskModel.Horses[i].Name;
                horseNames[i].Size = new Size(150, 70);
                horseNames[i].Location = new Point(150 + 150 * i, 750);
                horseNames[i].Font = new Font(pfc.Families[0], 10, GraphicsUnit.Point);
                horseNames[i].BackColor = Color.Transparent;
                horseNames[i].ForeColor = Color.White;
                horseNames[i].TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void SetDayCounterDefaultView()
        {
            dayCounter.Size = new Size(300, 70);
            dayCounter.Location = new Point(50, 50);
            dayCounter.Text = "days to races: " + simulation.YearsToRaces.ToString();
            dayCounter.Font = new Font(pfc.Families[0], 10, GraphicsUnit.Point);
            dayCounter.BackColor = Color.Transparent;
            dayCounter.ForeColor = Color.White;
        }

        private void SetNumberOfParticipantsDefaultView()
        {
            numberOfParticipants.Size = new Size(200, 70);
            numberOfParticipants.Location = new Point(900, 50);
            numberOfParticipants.Text = "Customers: " + simulation.NumberOfPeople.ToString();
            numberOfParticipants.Font = new Font(pfc.Families[0], 10, GraphicsUnit.Point);
            numberOfParticipants.BackColor = Color.Transparent;
            numberOfParticipants.ForeColor = Color.White;
        }

        private void SetSimulationButtonDefaultView()
        {
            simulationButton.Size = new Size(200, 70);
            simulationButton.Location = new Point(500, 850);
            simulationButton.Text = "Start Betting Season!";
            simulationButton.Font = new Font(pfc.Families[0], 10, GraphicsUnit.Point);
        }

        private void SetSimulationButtonDefaultControls()
        {
            simulationButton.Click += (sender, args) =>
            {
                simulationButton.Enabled = false;
                simulation.StartSimulation();
            };
        }

        private void SetToRacesButtonDefaultView()
        {
            toRacesButton.Size = new Size(200, 70);
            toRacesButton.Location = new Point(900, 850);
            toRacesButton.Text = "To Races";
            toRacesButton.Font = new Font(pfc.Families[0], 10, GraphicsUnit.Point);
            toRacesButton.Hide();
        }

        private void SetToRacesButtonDefaultControls()
        {
            toRacesButton.Click += (sender, args) => StartRacesScene();
        }

        private void SetCustomerSceneDefaultView()
        {
            BackgroundImage = Image.FromFile("Images/books.jpg");

            Size = new Size(1200, 1000);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            CenterToScreen();
        }

        private void SetCustomerSceneDefaultControls()
        {
            Closing += (sender, args) => Application.Exit();
            Paint += (sender, args) => RedrawBars(args.Graphics);
            simulation.DayPassed += () => AddCostToBars();
        }

        private void RedrawBars(Graphics gr)
        {
            DrawAxes(gr);
            for (int i = 0, n = moneyBars.Count; i < n; ++i)
                gr.FillRectangle(Brushes.MintCream, moneyBars[i]);
        }

        private void DrawAxes(Graphics gr)
        {
            gr.DrawLine(pen, new Point(125, 750), new Point(125, 200));
            gr.DrawLine(pen, new Point(125, 750), new Point(1075, 750));
            gr.DrawLine(pen, new Point(125, 200), new Point(115, 210));
            gr.DrawLine(pen, new Point(125, 200), new Point(135, 210));
            for (int i = 0; 250 + 50 * i <= 700; ++i)
                gr.DrawLine(pen, new Point(120, 250 + i * 50), new Point(130, 250 + i * 50));
        }

        private void AddCostToBars()
        {
            if (simulation.YearsToRaces == 0)
                toRacesButton.Show();
            for (int i = 0, n = moneyBars.Count; i < n; ++i)
            {
                var deltaY = simulation.MoneyOnBets[i] - (750 - moneyBars[i].Y);
                moneyBars[i] = new Rectangle(new Point(moneyBars[i].X, moneyBars[i].Y - deltaY),
                                             new Size(moneyBars[i].Width, moneyBars[i].Height + deltaY));
                moneyForHorses[i].Text = simulation.MoneyOnBets[i].ToString();
                moneyForHorses[i].Location = new Point(moneyForHorses[i].Location.X, moneyBars[i].Y - 50);
            }
            dayCounter.Text = "days to races: " + simulation.YearsToRaces.ToString();
            numberOfParticipants.Text = "Customers: " + simulation.NumberOfPeople.ToString();
            Invalidate();
        }

        private void AddControlsToCustomerScene()
        {
            Controls.Add(simulationButton);
            Controls.Add(toRacesButton);
            Controls.Add(numberOfParticipants);
            Controls.Add(dayCounter);
            foreach (var name in horseNames)
                Controls.Add(name);
            foreach (var label in axisLabels)
                Controls.Add(label);
            foreach (var money in moneyForHorses)
                Controls.Add(money);
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

        public event Action StartRacesScene;
    }
}
