using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recruitment_System.DAL;
using System.Windows.Forms;

namespace Recruitment_System.BL
{
    public class Interview

    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Interview"/> class.
        /// </summary>
        public Interview()
        {
            m_Id = 0;
            m_Interviewer = Interviewer.Empty;
            m_Co_Interviewer = Interviewer.Empty;

            m_Nominee = Nominee.Empty;
            m_Position = Position.Empty;
            m_Date = DateTimePicker.MinimumDateTime;
        }
        public Interview(DataRow interviewer_prop)
        {
            m_Id = (int)interviewer_prop["ID"];
            m_Interviewer = new Interviewer(interviewer_prop.GetParentRow("InterviewInterviewer"));
            m_Co_Interviewer = new Interviewer(interviewer_prop.GetParentRow("InterviewCo_Interviewer"));
            m_Nominee = new Nominee(interviewer_prop.GetParentRow("InterviewNominee"));
            m_Position = new Position(interviewer_prop.GetParentRow("InterviewPosition"));
            m_Date = (DateTime)interviewer_prop["Date"];
        }

        #endregion


        #region Private containers

        private int m_Id;
        private Interviewer m_Interviewer;
        private Interviewer m_Co_Interviewer;
        private Nominee m_Nominee;
        private Position m_Position;
        private DateTime m_Date;
        #endregion


        #region Public variables
        public int Id { get => m_Id; set => m_Id = value; }
        public Interviewer Interviewer { get => m_Interviewer; set => m_Interviewer = value; }
        public Interviewer Co_Interviewer { get => m_Co_Interviewer; set => m_Co_Interviewer = value; }
        public Nominee Nominee { get => m_Nominee; set => m_Nominee = value; }
        public Position Position { get => m_Position; set => m_Position = value; }
        public DateTime Date { get => m_Date; set => m_Date = value; }

        public static Interview Empty = new Interview();

        #endregion


        #region Public methods

        /// <summary>
        /// Inserts the interviewer's information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public bool Insert()
        {
            return Interview_Dal.Insert(m_Interviewer.DBId, m_Co_Interviewer.DBId, m_Nominee.DBId, m_Position.Id, m_Date);
        }

        public bool Update()
        {
            return Interview_Dal.Update(m_Id, m_Interviewer.DBId, m_Co_Interviewer.DBId, m_Nominee.DBId, m_Position.Id, m_Date);
        }

        public bool Delete()
        {
            InterviewCriterionArr interviewCriterionArr = new InterviewCriterionArr();
            interviewCriterionArr.Fill();
            interviewCriterionArr = interviewCriterionArr.Filter(this);
            if (interviewCriterionArr.DeleteArr())
            {
                return Interviewer_Dal.Delete(m_Id);
            }
            return false;
        }


        public override string ToString()
        {
            return m_Nominee.FullName + " - " + m_Position.Name + "(" + m_Date.ToString("dd-MM-yyy") + ")";
        }


        public static bool operator ==(Interview left, Interview right)
        {
            if ((object)right == null)
            {
                return (object)left == null;
            }
            else if ((object)left == null)
            {
                return false;
            }


            return (left.m_Id == right.m_Id) &&
                    (left.m_Interviewer.DBId == right.m_Interviewer.DBId) &&
                    (left.m_Position.Id == right.m_Position.Id) &&
                    (left.m_Nominee.DBId == right.m_Nominee.DBId);
        }


        public static bool operator !=(Interview left, Interview right)
        {
            if ((object)right == null)
            {
                return (object)left != null;
            }
            else if ((object)left == null)
            {
                return true;
            }


            return (left.m_Id != right.m_Id) ||
                    (left.m_Interviewer.DBId != right.m_Interviewer.DBId) ||
                    (left.m_Position.Id != right.m_Position.Id) ||
                    (left.m_Nominee.DBId != right.m_Nominee.DBId);
        }

        #endregion
    }
}
