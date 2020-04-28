using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Recruitment_System.BL;

namespace Recruitment_System.UI
{
    public partial class Interview_Form : Form
    {
        public Interview_Form(Interview interview)
        {
            InitializeComponent();
            Text = "ציונים עבור " + interview.Nominee.ToString();

            InterviewCriterionArr interviewCriterionArr = new InterviewCriterionArr();
            interviewCriterionArr.Fill();
            interviewCriterionArr = interviewCriterionArr.Filter(interview.Interviewer, interview.Nominee, Criterion.Empty, 0, DateTime.MinValue, DateTime.MaxValue);

            interviewCriterionArr = FillData(interviewCriterionArr, interview);

            scorer1.SetDataSource(interviewCriterionArr);
        }


        private InterviewCriterionArr FillData(InterviewCriterionArr interviewCriterionArr, Interview interview)
        {
            //
            PositionNomineeArr positionNomineeArr = new PositionNomineeArr();
            positionNomineeArr.Fill();
            positionNomineeArr = positionNomineeArr.Filter(interview.Nominee, Position.Empty);

            PositionArr positionArr = positionNomineeArr.ToPositionArr();
            //

            CriterionArr criterionArr = new CriterionArr();

            Position position;
            Criterion criterion;
            InterviewCriterion interviewCriterion;
            for (int i = 0; i < positionArr.Count; i++)
            {
                position = positionArr[i] as Position;

                criterionArr.Fill();
                criterionArr = criterionArr.Filter(position.PositionType, "");

                for (int j = 0; j < criterionArr.Count; j++)
                {
                    criterion = criterionArr[j] as Criterion;

                    if (!interviewCriterionArr.DoesContainData(interview, criterion))
                    {
                        interviewCriterion = new InterviewCriterion();
                        interviewCriterion.Interview = interview;
                        interviewCriterion.Criterion = criterion;
                        interviewCriterion.DateTime = DateTime.Now;

                        interviewCriterionArr.Add(interviewCriterion);
                    }
                }
            }
            return interviewCriterionArr;
        }

        public InterviewCriterionArr FormToInterviewCriterionArr()
        {
            return scorer1.GetData();
        }
    }
}
