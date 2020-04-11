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
    public partial class Scorer : UserControl
    {
        public Scorer()
        {
            InitializeComponent();

            panel.Dock = DockStyle.Fill;
            panel.AutoScroll = true;
            panel.AutoSize = false;

            tableLayoutPanel.Dock = DockStyle.Top;
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel.AutoScroll = false;
        }

        public void AddScorerRow(NomineeScoreType nomineeScoreType)
        {
            ScorerRow scorerRow = new ScorerRow();
            scorerRow.Text = nomineeScoreType.ScoreType.Name;
            scorerRow.Score = nomineeScoreType.Score;
            scorerRow.Width = tableLayoutPanel.Width - 2;
            scorerRow.Location = new Point(0, 0);
            scorerRow.Tag = nomineeScoreType;

            tableLayoutPanel.Controls.Add(scorerRow);
            tableLayoutPanel.SetRow(scorerRow, tableLayoutPanel.RowCount);
        }

        public void AddLabel(string position)
        {
            Label labelPosition = new Label();
            labelPosition.AutoSize = true;
            labelPosition.Location = new Point(0, 0);
            labelPosition.RightToLeft = RightToLeft.Yes;
            labelPosition.TabIndex = 0;
            labelPosition.Text = position;


            tableLayoutPanel.Controls.Add(labelPosition);
            tableLayoutPanel.SetRow(labelPosition, tableLayoutPanel.RowCount);
        }


        public void SetDataSource(NomineeScoreTypeArr nomineeScoreTypeArr)
        {
            Clear();
            if (nomineeScoreTypeArr != null)
            {
                nomineeScoreTypeArr.SortByPositions();
                Position last = Position.Empty;
                NomineeScoreType nomineeScoreType;
                for (int i = 0; i < nomineeScoreTypeArr.Count; i++)
                {
                    nomineeScoreType = nomineeScoreTypeArr[i] as NomineeScoreType;

                    if (last != nomineeScoreType.ScoreType.Position)
                    {
                        last = nomineeScoreType.ScoreType.Position;
                        AddLabel(last.Name);
                    }

                    AddScorerRow(nomineeScoreType);
                }
            }
        }

        public NomineeScoreTypeArr GetData()
        {
            NomineeScoreTypeArr output = new NomineeScoreTypeArr();
            ScorerRow scorerRow;
            NomineeScoreType nomineeScoreType;
            foreach (Control item in tableLayoutPanel.Controls)
            {
                if (item is ScorerRow)
                {
                    scorerRow = item as ScorerRow;
                    nomineeScoreType = scorerRow.Tag as NomineeScoreType;
                    if (nomineeScoreType.Score != scorerRow.Score)
                    {
                        nomineeScoreType.Score = scorerRow.Score;
                        nomineeScoreType.DateTime = DateTime.Now;
                    }

                    output.Add(nomineeScoreType);
                }
            }

            return output;
        }
        public void Clear()
        {
            for (int i = 0; i < tableLayoutPanel.Controls.Count; i++)
            {
                tableLayoutPanel.Controls[i].Dispose();
            }
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.RowCount = 0;
        }
    }
}
