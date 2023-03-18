using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Drawing;

namespace Ulearn_project
{
    class MoneyPanel : Panel
    {
        PrivateFontCollection pfc = new PrivateFontCollection();

        Label income = new Label();
        Label costs = new Label();
        Label regularExpenses = new Label();
        Label total = new Label();
        Button nextPeriodButton = new Button();
        Pen pen = new Pen(Color.White, 5);
        public MoneyPanel()
        {
            pfc.AddFontFile("Fonts/lunchds.ttf");

            Hide();

            SetIncomeDefaultView();
            SetCostsDefaultView();
            SetRegularExpensesDefaultView();
            SetTotalDefaultView();

            SetNextPeriodButtonDefoultView();

            SetMoneyPanelDefaultView();
            SetMoneyPanelDefaultControls();
            AddControlsToPanel();
        }

        private void SetNextPeriodButtonDefoultView()
        {
            nextPeriodButton.Size = new Size(300, 60);
            nextPeriodButton.Location = new Point(50, 450);
            nextPeriodButton.Font = new Font(pfc.Families[0], 10, GraphicsUnit.Point);
            nextPeriodButton.BackColor = Color.Transparent;
            nextPeriodButton.Text = "NEXT PERIOD";
        }

        private void SetIncomeDefaultView()
        {
            income.Location = new Point(10, 165);
            income.ForeColor = Color.Green;
            income.BackColor = Color.Transparent;
            income.Size = new Size(380, 50);
            income.Font = new Font(pfc.Families[0], 13, GraphicsUnit.Point);
        }

        private void SetCostsDefaultView()
        {
            costs.Location = new Point(10, 240);
            costs.ForeColor = Color.Red;
            costs.BackColor = Color.Transparent;
            costs.Size = new Size(380, 50);
            costs.Font = new Font(pfc.Families[0], 13, GraphicsUnit.Point);
        }

        private void SetRegularExpensesDefaultView()
        {
            regularExpenses.Location = new Point(10, 315);
            regularExpenses.ForeColor = Color.Red;
            regularExpenses.BackColor = Color.Transparent;
            regularExpenses.Size = new Size(380, 50);
            regularExpenses.Font = new Font(pfc.Families[0], 13, GraphicsUnit.Point);
        }

        private void SetTotalDefaultView()
        {
            total.Location = new Point(10, 390);
            total.ForeColor = Color.White;
            total.BackColor = Color.Transparent;
            total.Size = new Size(380, 50);
            total.Font = new Font(pfc.Families[0], 13, GraphicsUnit.Point);
        }

        private void SetMoneyPanelDefaultView()
        {
            Size = new Size(400, 520);
            BackgroundImage = Image.FromFile("Images/woodenDesk.jpg");
        }

        private void SetMoneyPanelDefaultControls()
        {
            Paint += (sender, args) => PaintFrame(args.Graphics);
        }

        private void PaintFrame(Graphics gr)
        {
            ControlPaint.DrawBorder(gr, ClientRectangle,
            Color.Black, 10, ButtonBorderStyle.Solid,
            Color.Black, 10, ButtonBorderStyle.Solid,
            Color.Black, 10, ButtonBorderStyle.Solid,
            Color.Black, 10, ButtonBorderStyle.Solid);
            gr.DrawLine(pen, 15, 380, 385, 370);
        }

        private void AddControlsToPanel()
        {
            Controls.Add(income);
            Controls.Add(costs);
            Controls.Add(regularExpenses);
            Controls.Add(total);
            Controls.Add(nextPeriodButton);
        }

        public void ShowMoney(RaceSimulation simulation)
        {
            income.Text = "INCOME:            +" + MoneyModel.Income;
            costs.Text = "COSTS:             -" + simulation.Champion.CalculateCosts();
            regularExpenses.Text = "REGULAR EXPENSES:  -" + MoneyModel.fixedExpenses;
            total.Text = "TOTAL:             " + (MoneyModel.Income - simulation.Champion.CalculateCosts() - MoneyModel.fixedExpenses);
            MoneyModel.AddMoney(-simulation.Champion.CalculateCosts() - MoneyModel.fixedExpenses);
            Show();
        }
    }
}
