using Recruitment_System.DAL;
using System.Collections;
using System.Data;

namespace Recruitment_System.BL
{
    public class Job
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Job"/> class.
        /// </summary>
        public Job()
        {
            m_Id = -1;
            m_Name = "";
        }
        public Job(DataRow job_prop)
        {
            m_Id = (int)job_prop["ID"];
            m_Name = job_prop["Name"].ToString();

        }

        #endregion


        #region Private containers

        private int m_Id;
        private string m_Name;

        #endregion


        #region Public variables
        public int Id { get => m_Id; set => m_Id = value; }
        public string Name { get => m_Name; set => m_Name = value; }

        public static Job Empty = new Job();

        #endregion


        #region Public methods

        /// <summary>
        /// Inserts the job's information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public bool Insert()
        {
            JobArr ca = new JobArr();
            ca.Fill();
            ca = ca.Filter("+");

            if (Job_Dal.Update((ca[0] as Job).Id, m_Name))
            {
                return Job_Dal.Insert("+");
            }
            return false;
        }

        public bool Update()
        {
            return Job_Dal.Update(m_Id, m_Name);
        }


        public bool Delete()
        {
            return Job_Dal.Delete(m_Id);
        }


        public override string ToString()
        {
            return m_Name;
        }

        #endregion
    }
}
