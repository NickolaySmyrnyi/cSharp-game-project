using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Ulearn_project
{
    class HelperModel
    {
        public Image Picture { get; }
        public string CurrentText { get; private set; }
        public List<Text> Texts { get; private set; } = new List<Text>();
        private int cursor = 0;
        private int numberOfText = 0;

        public HelperModel(Image image)
        {
            Picture = image;
            CurrentText = "";
            InitializeTexts();
            Texts[0].IsOutputable = true;
        }

        private void InitializeTexts()
        {
            Texts.Add(new Text("Hi, my name is Thomas Shelby"));
            Texts.Add(new Text("Races are coming to our town"));
            Texts.Add(new Text("And you are going to help me with making money"));
        }

        public void OutputText(Text text)
        {
            text.Timer.Interval = 50;
            text.Timer.Tick += (sender, args) =>
            {
                Change(text);
            };
            text.Timer.Start();
        }

        private void Change(Text text)
        {
            try
            {
                ChangeCurrentText(text);
            }
            catch (Exception)
            {
                StopOutput(text);
            }
        }

        private void ChangeCurrentText(Text text)
        {
            CurrentText += text.TextLine[cursor];
            ++cursor;
            TextChanged();
        }

        private void StopOutput(Text text)
        {
            try
            {
                Texts[numberOfText + 1].IsOutputable = true;
                StopTextOutput(text);
            }
            catch (Exception)
            {
                StopTextOutput(text);
            }
        }

        private void StopTextOutput(Text text)
        {
            text.Timer.Stop();
            text.IsOutputable = false;
            cursor = 0;
            CurrentText = "";
            ++numberOfText;
        }

        public event Action TextChanged;
    }
}
