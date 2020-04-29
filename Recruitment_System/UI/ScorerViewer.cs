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


        public void AddNominee(InterviewCriterionArr interviewCriterionArr, Nominee nominee)
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

            scorer.SetDataSource(interviewCriterionArr);

            groupBox.Controls.Add(scorer);

            tableLayoutPanel.Controls.Add(groupBox);
            tableLayoutPanel.SetRow(groupBox, tableLayoutPanel.RowCount);
        }


        public void SetDataSource(InterviewCriterionArr interviewCriterionArr, Interviewer interviewer)
        {
            Clear();
            if (interviewCriterionArr != null && interviewer != null)
            {

                //interviewCriterionArr.SortByPositions();

                InterviewCriterionArr filter;
                NomineeArr nomineeArr = interviewCriterionArr.ToNomineeArr();
                for (int i = 0; i < nomineeArr.Count; i++)
                {
                    filter = interviewCriterionArr.Filter(interviewer, nomineeArr[i] as Nominee, Position.Empty, DateTimePicker.MinimumDateTime, DateTimePicker.MaximumDateTime);

                    filter.SortByPositions();
                    AddNominee(filter, nomineeArr[i] as Nominee);
                }
            }
        }


        public InterviewCriterionArr GetData()
        {
            InterviewCriterionArr output = new InterviewCriterionArr();
            ScorerRow scorerRow;
            InterviewCriterion interviewCriterion;
            foreach (Control item in tableLayoutPanel.Controls)
            {
                if (item is ScorerRow)
                {
                    scorerRow = item as ScorerRow;
                    interviewCriterion = scorerRow.Tag as InterviewCriterion;
                    if (interviewCriterion.Score != scorerRow.Score)
                    {
                        interviewCriterion.Score = scorerRow.Score;
                        interviewCriterion.DateTime = DateTime.Now;
                    }

                    output.Add(interviewCriterion);
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
