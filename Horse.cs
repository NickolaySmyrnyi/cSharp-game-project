using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Ulearn_project
{
    class Horse
    {
        public string Name { get; set; }
        public double Coefficient { get; set; }

        public int DistanceRan { get; set; } 
        public int RunningCoefficient { get; set; }
        public bool CanRun { get; set; }

        public Horse(string name)
        {
            Name = name;
            Coefficient = 1.0;
            DistanceRan = 0;
            RunningCoefficient = 100;
            CanRun = true;
        }
    }
}
