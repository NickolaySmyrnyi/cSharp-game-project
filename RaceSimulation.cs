using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Ulearn_project
{
    class RaceSimulation
    {
        Timer timer = new Timer();
        Random rand = new Random();
        public Queue<Horse> Champions { get; private set; } = new Queue<Horse>();
        public Horse Champion { get; private set; } = null;
        public RaceSimulation()
        {
            timer.Interval = 100;
            timer.Tick += (sender, args) => MakeMove();
        }
        private void MakeMove()
        {
            foreach (var horse in DeskModel.Horses)
            {
                if (horse.CanRun)
                    horse.DistanceRan += rand.Next(0, horse.RunningCoefficient);
            }
            if (DeskModel.Horses.Max((x) => x.DistanceRan) >= 1100)
            {
                foreach (var horse in DeskModel.Horses.OrderBy((x) => x.DistanceRan))
                {
                    if (Champion == null && horse.DistanceRan == DeskModel.Horses.Max((x) => x.DistanceRan))
                        Champion = horse;
                    if (horse.DistanceRan >= 1100 && horse.CanRun)
                    {
                        horse.CanRun = false;
                        Champions.Enqueue(horse);
                        horse.DistanceRan = 1100;
                    }
                }
            }
            DistanceRanChanged();
            if (DeskModel.Horses.Min((x) => x.DistanceRan) >= 1100)
                StopSimulation();
        }
        public void StartSimulation()
        {
            timer.Start();
        }

        private void StopSimulation()
        {
            timer.Stop();
            foreach(var horse in DeskModel.Horses)
                horse.DistanceRan = 0;
            EndOfSimulation();
        }

        public event Action DistanceRanChanged;
        public event Action EndOfSimulation;
    }
}
