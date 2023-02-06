using System;
using System.Collections.Generic;
using System.Text;

namespace Ulearn_project
{
    class DeskModel
    {
        public List<Horse> Horses { get; set; } = new List<Horse>();

        public DeskModel()
        {
            InitializeHorses();
        }

        private void InitializeHorses()
        {
            Horses.Add(new Horse("Black Death"));
            Horses.Add(new Horse("Little Princess"));
            Horses.Add(new Horse("Baby"));
            Horses.Add(new Horse("Fast River"));
            Horses.Add(new Horse("Julio"));
            Horses.Add(new Horse("New Era"));
        }
    }
}
