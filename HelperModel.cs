using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Ulearn_project
{
    class HelperModel
    {
        public string CurrentText { get; private set; }
        public List<Text> Texts { get; private set; } = new List<Text>();
        public bool CanBeContinued { get; private set; } = true;
        private int cursor = 0;
        private int numberOfText = 0;

        public HelperModel()
        {
            CurrentText = "";
            InitializeTexts();
            Texts[0].IsOutputable = true;
        }

        private void InitializeTexts()
        {
            Texts.Add(new Text("Hi, my name is Thomas Shelby"));
            Texts.Add(new Text("Races are coming to our town"));
            Texts.Add(new Text("And you are going to help me with making money"));
            Texts.Add(new Text("First of all, let me give you some knowledges about our bloody business"));
            Texts.Add(new Text("We make bets... And to make them you need to input the coefficients"));
            Texts.Add(new Text("Firstly, do it and press \"CONFIRM\""));
            Texts.Add(new Text("Nice choice, let's see what will happen"));
        }

        public void MakeHelperOutputText()
        {
            if (!CanBeContinued)
                return;
            foreach (var text in Texts)
            {
                if (text.IsOutputable)
                    OutputText(text);
            }
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
            CheckForPossibleOutputChanges();
            PrepareForNextOutput(text);
        }
        private void PrepareForNextOutput(Text text)
        {
            text.Timer.Stop();
            text.IsOutputable = false;
            cursor = 0;
            CurrentText = "";
            ++numberOfText;
        }

        private void CheckForPossibleOutputChanges()
        {
            switch (numberOfText)
            {
                //after the 5 line, helper suggests to interact with desk
                case 5:
                    CanBeContinued = false;
                    FirstInteraction();
                    break;
                default:
                    CurrentText += "\n\nPRESS ENTER";
                    TextChanged();
                    break;
            }
        }

        public void EndFirstInteraction()
        {
            CanBeContinued = true;
            MakeHelperOutputText();
        }

        public event Action FirstInteraction;
        public event Action TextChanged;
    }
}
