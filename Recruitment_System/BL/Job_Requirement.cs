using Recruitment_System.DAL;
using System.Collections;
using System.Data;

namespace Recruitment_System.BL
{
    public class Job_Requirement
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Job_Requirement"/> class.
        /// </summary>
        public Job_Requirement()
        {
            m_Id = 0;
            m_Requirement = "";
        }
        public Job_Requirement(DataRow job_Requirement_prop)
        {
            m_Id = (int)job_Requirement_prop["ID"];
            m_Requirement = job_Requirement_prop["Requirement"].ToString();

        }

        private Job_Requirement(bool unused)
        {
            m_Id = -1;
            m_Requirement = "+";
        }

        #endregion


        #region Private containers

        private int m_Id;
        private string m_Requirement;

        #endregion


        #region Public variables
        public int Id { get => m_Id; set => m_Id = value; }
        public string Requirement { get => m_Requirement; set => m_Requirement = value; }

        public static Job_Requirement Empty = new Job_Requirement();
        public static Job_Requirement AddingFormButton = new Job_Requirement(true);

        #endregion


        #region Public methods

        /// <summary>
        /// Inserts the Job_Requirement's information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public bool Insert()
        {
            return Job_Requirement_Dal.Insert(m_Requirement);
        }

        public bool Update()
        {
            return Job_Requirement_Dal.Update(m_Id, m_Requirement);
        }


        public bool Delete()
        {
            return Job_Requirement_Dal.Delete(m_Id);
        }


        public override string ToString()
        {
            return m_Requirement;
        }

        #endregion
    }
}
