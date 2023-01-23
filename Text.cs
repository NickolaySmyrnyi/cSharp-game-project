using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Ulearn_project
{
    class Text
    {
        public bool IsOutputable { get; set; } = false;
        public string TextLine { get; }
        public Timer Timer { get; set; }

        public Text(string textLine)
        {
            TextLine = textLine;
            Timer = new Timer();
        }
    }
}
