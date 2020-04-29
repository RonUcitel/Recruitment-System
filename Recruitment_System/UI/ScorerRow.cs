using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Recruitment_System.BL;

namespace Recruitment_System.UI
{
    public partial class ScorerRow : UserControl
    {
        public event EventHandler<ScoreChangedEventArgs> ScoreChanged;
        public ScorerRow(bool isEdit)
        {
            InitializeComponent();
            numericUpDown1.Enabled = isEdit;
        }

        public ScorerRow(string text, int score, int width)
        {
            InitializeComponent();
            this.Width = width;

            Text = text;

            Score = score;

            label1.Left = Width - label1.Width - 1;
        }

        public ScorerRow(int width)
        {
            InitializeComponent();
            this.Width = width;

            label1.Left = Width - label1.Width - 1;
        }

        public ScorerRow(string text, int score)
        {
            InitializeComponent();

            Text = text;

            Score = score;

            label1.Left = Width - label1.Width - 1;
        }

        public override string Text
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
                label1.Left = Width - label1.Width - 1;
            }
        }

        public int Score
        {
            get
            {
                return (int)numericUpDown1.Value;
            }
            set
            {
                if (value == -1 || (1 <= value && value <= 10))
                {
                    numericUpDown1.Value = value;
                }
            }
        }

        private int oldValue = 0;

        private void ScorerRow_SizeChanged(object sender, EventArgs e)
        {
            this.Height = numericUpDown1.Height + 2;
            label1.Left = Width - label1.Width - 1;
        }


        public void SetEdit(bool canEdit)
        {
            numericUpDown1.Enabled = canEdit;
        }


        protected virtual void OnScoreChanged(ScoreChangedEventArgs e)
        {
            EventHandler<ScoreChangedEventArgs> handler = ScoreChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }


        private void ScorerRow_Enter(object sender, EventArgs e)
        {
            oldValue = (int)numericUpDown1.Value;
        }

        private void ScorerRow_Leave(object sender, EventArgs e)
        {
            int value = (int)numericUpDown1.Value;
            if (value != oldValue)
            {
                ScoreChangedEventArgs args = new ScoreChangedEventArgs();
                args.Score = (int)numericUpDown1.Value;

                InterviewCriterion interviewCriterion = Tag as InterviewCriterion;
                interviewCriterion.DateTime = DateTime.Now;
                args.InterviewCriterion = interviewCriterion;
                OnScoreChanged(args);
            }
        }
    }

    public class ScoreChangedEventArgs : EventArgs
    {
        public int Score { get; set; }
        public InterviewCriterion InterviewCriterion { get; set; }
    }
}
