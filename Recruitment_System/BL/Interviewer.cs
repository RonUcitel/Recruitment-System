using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recruitment_System.DAL;

namespace Recruitment_System.BL
{
    public class Interviewer

    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Interviewer"/> class.
        /// </summary>
        public Interviewer()
        {
            m_DBId = 0;
            m_FirstName = "";
            m_LastName = "";
            m_Id = "";
            m_Credentials = Credentials.Empty;
            m_Admin = false;
        }
        public Interviewer(DataRow interviewer_prop)
        {
            m_DBId = (int)interviewer_prop["ID"];
            m_FirstName = interviewer_prop["FirstName"].ToString();
            m_LastName = interviewer_prop["LastName"].ToString();
            m_Id = interviewer_prop["Id_Num"].ToString();
            m_Credentials = new Credentials(interviewer_prop.GetParentRow("InterviewerCredentials"));
            m_Admin = (bool)interviewer_prop["Hidden"];

        }

        #endregion


        #region Private containers

        private int m_DBId;
        private string m_FirstName;
        private string m_LastName;
        private string m_Id;
        private Credentials m_Credentials;
        private bool m_Admin;

        #endregion


        #region Public variables
        public int DBId { get => m_DBId; set => m_DBId = value; }
        public string FirstName { get => m_FirstName; set => m_FirstName = value; }
        public string LastName { get => m_LastName; set => m_LastName = value; }
        internal Credentials Credentials { get => m_Credentials; set => m_Credentials = value; }
        public bool Admin { get => m_Admin; set => m_Admin = value; }
        public string Id { get => m_Id; set => m_Id = value; }

        public static Interviewer Empty = new Interviewer();

        #endregion


        #region Public methods

        /// <summary>
        /// Inserts the interviewer's information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public bool Insert()
        {
            return Interviewer_Dal.Insert(m_FirstName, m_LastName, m_Id, m_Credentials.Id);
        }

        public bool Update()
        {
            return Interviewer_Dal.Update(m_DBId, m_FirstName, m_LastName, m_Id, m_Credentials.Id);
        }


        public bool ChangeAdmin(bool isAdmin)
        {
            return Interviewer_Dal.ChangeAdmin(m_DBId, isAdmin);
        }


        public bool Delete()
        {
            return Interviewer_Dal.Delete(m_DBId);
        }


        public override string ToString()
        {
            return m_FirstName + " " + m_LastName;
        }


        public static bool operator ==(Interviewer left, Interviewer right)
        {
            if ((object)right == null)
            {
                return (object)left == null;
            }
            else if ((object)left == null)
            {
                return false;
            }


            return ((left.FirstName == right.FirstName) &&
                    (left.LastName == right.LastName) &&
                    (left.Id == right.Id) &&
                    (left.Credentials.Id == right.Credentials.Id));
        }


        public static bool operator !=(Interviewer left, Interviewer right)
        {
            if ((object)right == null)
            {
                return (object)left != null;
            }
            else if ((object)left == null)
            {
                return true;
            }


            return ((left.FirstName != right.FirstName) ||
                    (left.LastName != right.LastName) ||
                    (left.Id != right.Id) ||
                    (left.Credentials.Id != right.Credentials.Id));
        }

        #endregion
    }
}
