using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recruitment_System.UI
{
    public partial class ScorerRow : UserControl
    {
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

        private void ScorerRow_SizeChanged(object sender, EventArgs e)
        {
            this.Height = numericUpDown1.Height + 2;
            label1.Left = Width - label1.Width - 1;
        }


        public void SetEdit(bool canEdit)
        {
            numericUpDown1.Enabled = canEdit;
        }
    }
}
