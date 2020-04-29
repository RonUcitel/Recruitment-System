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
        public event EventHandler<ScoreChangedEventArgs> ScoreChanged;
        public Scorer()
        {
            InitializeComponent();
            m_CanEdit = true;

            panel.Dock = DockStyle.Fill;
            panel.AutoScroll = true;
            panel.AutoSize = false;

            tableLayoutPanel.Dock = DockStyle.Top;
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel.AutoScroll = false;
        }

        public Scorer(bool canEdit = true)
        {
            InitializeComponent();
            m_CanEdit = canEdit;

            panel.Dock = DockStyle.Fill;
            panel.AutoScroll = true;
            panel.AutoSize = false;

            tableLayoutPanel.Dock = DockStyle.Top;
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel.AutoScroll = false;
        }

        private bool m_CanEdit;

        public bool CanEdit
        {
            get => m_CanEdit;

            set
            {
                SetEdit(value);
                m_CanEdit = value;
            }
        }


        public void AddScorerRow(InterviewCriterion interviewCriterion)
        {
            ScorerRow scorerRow = new ScorerRow(CanEdit);
            scorerRow.Text = interviewCriterion.Criterion.Name;
            scorerRow.Score = interviewCriterion.Score;
            scorerRow.Width = tableLayoutPanel.Width - 2;
            scorerRow.Location = new Point(0, 0);
            scorerRow.Tag = interviewCriterion;
            scorerRow.ScoreChanged += ScorerRow_ScoreChanged;

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
            labelPosition.BackColor = Color.LightGreen;


            tableLayoutPanel.Controls.Add(labelPosition);
            tableLayoutPanel.SetRow(labelPosition, tableLayoutPanel.RowCount);
        }


        public void SetDataSource(InterviewCriterionArr interviewCriterionArr)
        {
            Clear();
            if (interviewCriterionArr != null)
            {
                interviewCriterionArr.SortByPositions();
                Position last = Position.Empty;
                InterviewCriterion interviewCriterion;
                for (int i = 0; i < interviewCriterionArr.Count; i++)
                {
                    interviewCriterion = interviewCriterionArr[i] as InterviewCriterion;

                    if (last != interviewCriterion.Interview.Position)
                    {
                        last = interviewCriterion.Interview.Position;
                        AddLabel(last.Name);
                    }

                    AddScorerRow(interviewCriterion);
                }
            }
        }


        public void SetDataSource(Interview interview)
        {
            Clear();
            InterviewCriterionArr interviewCriterionArr = new InterviewCriterionArr();
            interviewCriterionArr.Fill();
            interviewCriterionArr = interviewCriterionArr.Filter(interview);
            if (interviewCriterionArr != null)
            {
                interviewCriterionArr.SortByPositions();
                InterviewCriterion interviewCriterion;
                for (int i = 0; i < interviewCriterionArr.Count; i++)
                {
                    interviewCriterion = interviewCriterionArr[i] as InterviewCriterion;
                    AddScorerRow(interviewCriterion);
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


        public void SetEdit(bool canEdit)
        {
            if (m_CanEdit != canEdit)
            {
                m_CanEdit = canEdit;
            }

            foreach (Control item in tableLayoutPanel.Controls)
            {
                if (item is ScorerRow)
                {
                    (item as ScorerRow).SetEdit(canEdit);
                }
            }
        }


        private void ScorerRow_ScoreChanged(object sender, ScoreChangedEventArgs e)
        {
            OnScoreChanged(e);
        }

        protected virtual void OnScoreChanged(ScoreChangedEventArgs e)
        {
            EventHandler<ScoreChangedEventArgs> handler = ScoreChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }


    }
}
