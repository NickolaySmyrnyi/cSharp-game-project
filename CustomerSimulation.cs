using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace Ulearn_project
{
    class CustomerSimulation
    {
        public List<int> MoneyOnBets { get; private set; } = new List<int>(6) { 0, 0, 0, 0, 0, 0 };
        Random random = new Random();
        Timer timer = new Timer();
        public int NumberOfPeople { get; private set; } = 0;
        public int YearsToRaces { get; private set; } = 10;

        public CustomerSimulation()
        {
            timer.Tick += (sender, args) => SimulateOneDay();
            timer.Interval = 500;
        }

        private void SimulateOneDay()
        {
            if (YearsToRaces == 0)
            {
                timer.Stop();
                return;
            }
            for(int i = 0, n = DeskModel.Horses.Count; i < n; ++i)
            {
                var numberOfParticipants = random.Next(0, GetParticipantDistribution(DeskModel.Horses[i]));
                NumberOfPeople += numberOfParticipants;
                for (int j = 0; j < numberOfParticipants; ++j)
                {
                    var amountOfMoney = random.Next(1, GetMoneyDistribution(DeskModel.Horses[i]));
                    MoneyOnBets[i] += amountOfMoney;
                }
            }
            --YearsToRaces;
            DayPassed();
        }

        public void StartSimulation()
        {
            timer.Start();
        }

        private int GetParticipantDistribution(Horse horse)
        {
            if (horse.Coefficient <= 1)
                return 0;
            if (horse.Coefficient <= 1.2)
                return 5;
            if (horse.Coefficient <= 1.5)
                return 10;
            if (horse.Coefficient <= 2.0)
                return 12;
            return 9;
        }

        private int GetMoneyDistribution(Horse horse)
        {
            if (horse.Coefficient <= 1.2)
                return 25;
            if (horse.Coefficient <= 1.5)
                return 16;
            if (horse.Coefficient <= 2.0)
                return 11;
            return 8;
        }

        public event Action DayPassed;
    }
}
