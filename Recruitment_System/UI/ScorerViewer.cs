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
    public partial class ScorerViewer : UserControl
    {
        public ScorerViewer()
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


        public void AddNominee(InterviewCriterionArr nomineeScoreTypeArr, Nominee nominee)
        {
            GroupBox groupBox = new GroupBox();
            groupBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox.Location = new Point(0, 0);
            groupBox.RightToLeft = RightToLeft.Yes;
            groupBox.Size = new Size(tableLayoutPanel.Width - 2, 500);
            groupBox.TabStop = false;
            groupBox.Text = nominee.ToString();

            Scorer scorer = new Scorer(false);
            scorer.Location = new Point(0, 40);
            scorer.RightToLeft = RightToLeft.Yes;
            scorer.Size = groupBox.ClientSize;
            /*scorer.Width -= 2;*/
            scorer.Dock = DockStyle.Fill;

            scorer.SetDataSource(nomineeScoreTypeArr);

            groupBox.Controls.Add(scorer);

            tableLayoutPanel.Controls.Add(groupBox);
            tableLayoutPanel.SetRow(groupBox, tableLayoutPanel.RowCount);
        }


        public void SetDataSource(InterviewCriterionArr nomineeScoreTypeArr, Interviewer interviewer)
        {
            Clear();
            if (nomineeScoreTypeArr != null && interviewer != null)
            {

                //nomineeScoreTypeArr.SortByPositions();

                InterviewCriterionArr filter;
                NomineeArr nomineeArr = nomineeScoreTypeArr.ToNomineeArr();
                for (int i = 0; i < nomineeArr.Count; i++)
                {
                    filter = nomineeScoreTypeArr.Filter(interviewer, nomineeArr[i] as Nominee, PositionType.Empty, DateTime.MinValue, DateTime.MaxValue);

                    filter.SortByPositions();
                    AddNominee(filter, nomineeArr[i] as Nominee);
                }
            }
        }


        public InterviewCriterionArr GetData()
        {
            InterviewCriterionArr output = new InterviewCriterionArr();
            ScorerRow scorerRow;
            InterviewCriterion nomineeScoreType;
            foreach (Control item in tableLayoutPanel.Controls)
            {
                if (item is ScorerRow)
                {
                    scorerRow = item as ScorerRow;
                    nomineeScoreType = scorerRow.Tag as InterviewCriterion;
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
