using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recruitment_System.DAL;

namespace Recruitment_System.BL
{
    public class InterviewArr : ArrayList
    {
        public void Fill()
        {
            this.Clear();
            DataTable dataTable = Interview_Dal.GetDataTable();


            DataRow dataRow;
            Interview interview;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                interview = new Interview(dataRow);
                if (interview.Id != 0)
                    Add(interview);
            }
        }


        public InterviewArr Filter(int nomineeDBId)
        {
            InterviewArr interviewArr = new InterviewArr();

            Interview interview;

            for (int i = 0; i < this.Count; i++)
            {
                interview = (this[i] as Interview);
                if (interview.Nominee.DBId == nomineeDBId || nomineeDBId == 0)
                {
                    interviewArr.Add(interview);
                }
            }

            return interviewArr;
        }

        public InterviewArr Filter(Interviewer interviewer, Interviewer co_Interviewer, Nominee nominee, Position position, DateTime from, DateTime to, int id = 0)
        {
            InterviewArr interviewArr = new InterviewArr();

            Interview interview;

            for (int i = 0; i < this.Count; i++)
            {
                interview = (this[i] as Interview);
                if ((interviewer == Interviewer.Empty || interview.Interviewer == interviewer) &&
                    (co_Interviewer == Interviewer.Empty || interview.Co_Interviewer == co_Interviewer) &&
                    (nominee == Nominee.Empty || interview.Nominee == nominee) &&
                    (position == Position.Empty || interview.Position == position) &&
                    (from <= interview.Date && interview.Date <= to) &&
                    (id == 0 || interview.Id == id))
                {
                    interviewArr.Add(interview);
                }
            }

            return interviewArr;
        }


        public InterviewArr Filter(PositionType positionType)
        {
            InterviewArr interviewArr = new InterviewArr();

            Interview interview;

            for (int i = 0; i < this.Count; i++)
            {
                interview = (this[i] as Interview);
                if (positionType == PositionType.Empty || interview.Position.PositionType == positionType)
                {
                    interviewArr.Add(interview);
                }
            }

            return interviewArr;
        }

        public bool IsContains(int interviewId)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Interview).Id == interviewId)
                    return true;
            }
            return false;
        }


        public void Remove(int id)
        {
            Interview inter = GetInterviewById(id);
            if (inter != Interview.Empty && inter != null)
            {
                base.Remove(inter);
            }
        }

        public Interview GetInterviewWithMaxId()
        {
            Interview maxInterview = new Interview();

            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Interview).Id > maxInterview.Id)
                {
                    maxInterview = (this[i] as Interview);
                }
            }
            return maxInterview;
        }

        public Interview GetInterviewById(int id)
        {
            if (id == 0)
            {
                return Interview.Empty;
            }


            Interview check;

            for (int i = 0; i < this.Count; i++)
            {
                check = this[i] as Interview;
                if (check.Id == id)
                {
                    return check;
                }
            }
            return Interview.Empty;
        }
    }
}
