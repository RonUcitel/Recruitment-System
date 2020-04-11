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
    public class InterviewerArr : ArrayList
    {
        public void Fill()
        {
            this.Clear();
            DataTable dataTable = Interviewer_Dal.GetDataTable();


            DataRow dataRow;
            Interviewer interviewer;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                interviewer = new Interviewer(dataRow);
                if (interviewer.DBId != 0)
                    Add(interviewer);
            }
        }

        public InterviewerArr Filter(string firstName, string lastName, string id, Credentials credentials, bool admin, int dBId = 0)
        {
            InterviewerArr interviewerArr = new InterviewerArr();

            Interviewer interviewer;

            for (int i = 0; i < this.Count; i++)
            {
                interviewer = (this[i] as Interviewer);
                if ((firstName == "" || interviewer.FirstName.StartsWith(firstName)) &&
                    (lastName == "" || interviewer.LastName.StartsWith(lastName)) &&
                    (id == "" || interviewer.Id.StartsWith(id)) &&
                    (credentials == Credentials.Empty || interviewer.Credentials == credentials) &&
                    (admin == interviewer.Admin) &&
                    (dBId == 0 || interviewer.DBId == dBId))
                {
                    interviewerArr.Add(interviewer);
                }
            }

            return interviewerArr;
        }

        public InterviewerArr Filter(string firstName, string lastName, string id, Credentials credentials, int dBId = 0)
        {
            InterviewerArr interviewerArr = new InterviewerArr();

            Interviewer interviewer;

            for (int i = 0; i < this.Count; i++)
            {
                interviewer = (this[i] as Interviewer);
                if ((firstName == "" || interviewer.FirstName.StartsWith(firstName)) &&
                    (lastName == "" || interviewer.LastName.StartsWith(lastName)) &&
                    (id == "" || interviewer.Id.StartsWith(id)) &&
                    (dBId == 0 || interviewer.DBId == dBId) &&
                    (credentials == Credentials.Empty || interviewer.Credentials == credentials))
                {
                    interviewerArr.Add(interviewer);
                }
            }

            return interviewerArr;
        }


        public bool IsContains(string fullName)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Interviewer).ToString() == fullName)
                    return true;
            }
            return false;
        }


        public bool IsContains(int interviewerDBId)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Interviewer).DBId == interviewerDBId)
                    return true;
            }
            return false;
        }


        public void Remove(string fullName)
        {
            Interviewer inter = GetInterviewerByName(fullName);
            if (inter != Interviewer.Empty && inter != null)
            {
                base.Remove(inter);
            }
        }

        public void Remove(int dBId)
        {
            Interviewer inter = GetInterviewerByDBId(dBId);
            if (inter != Interviewer.Empty && inter != null)
            {
                base.Remove(inter);
            }
        }

        public Interviewer GetInterviewerWithMaxDBId()
        {
            Interviewer maxInterviewer = new Interviewer();

            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Interviewer).DBId > maxInterviewer.DBId)
                {
                    maxInterviewer = (this[i] as Interviewer);
                }
            }
            return maxInterviewer;
        }

        public Interviewer GetInterviewerByDBId(int dBId)
        {
            if (dBId == 0)
            {
                return Interviewer.Empty;
            }


            Interviewer check;

            for (int i = 0; i < this.Count; i++)
            {
                check = this[i] as Interviewer;
                if (check.DBId == dBId)
                {
                    return check;
                }
            }
            return Interviewer.Empty;
        }

        public Interviewer GetInterviewerByName(string fullName)
        {
            if (fullName == " ")
            {
                return Interviewer.Empty;
            }


            Interviewer check;

            for (int i = 0; i < this.Count; i++)
            {
                check = this[i] as Interviewer;
                if (check.ToString() == fullName)
                {
                    return check;
                }
            }
            return Interviewer.Empty;
        }


        public Interviewer GetInterviewerByCredentials(Credentials credentials)
        {
            if (credentials == Credentials.Empty)
            {
                return Interviewer.Empty;
            }


            Interviewer check;

            for (int i = 0; i < this.Count; i++)
            {
                check = this[i] as Interviewer;
                if (check.Credentials == credentials)
                {
                    return check;
                }
            }
            return Interviewer.Empty;
        }
    }
}
