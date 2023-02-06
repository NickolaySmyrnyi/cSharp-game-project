using System;
using System.Collections.Generic;
using System.Text;

namespace Ulearn_project
{
    class Horse
    {
        public string Name { get; set; }
        public double Coefficient { get; set; }

        public Horse(string name)
        {
            Name = name;
            Coefficient = 1;
        }
    }
}
