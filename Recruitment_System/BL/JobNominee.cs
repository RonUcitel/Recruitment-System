using Recruitment_System.DAL;
using System.Collections;
using System.Data;
using System.Reflection;
using System.IO;
using System;

namespace Recruitment_System.BL
{
    public class JobNominee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Job_Nominee"/> class.
        /// </summary>
        public JobNominee()
        {
            m_DBId = 0;
            Job = Job.Empty;
            Nominee = Nominee.Empty;
        }
        public JobNominee(DataRow jobNominee_prop)
        {
            m_DBId = (int)jobNominee_prop["ID"];
            Job = new Job(jobNominee_prop.GetParentRow("JobNominee_Job"));
            Nominee = new Nominee(jobNominee_prop.GetParentRow("JobNominee_Nominee"));
        }

        #region Private containers

        private int m_DBId;

        private Job m_Job;

        private Nominee m_Nominee;
        #endregion


        #region Public Properties
        public int DBId { get => m_DBId; set => m_DBId = value; }

        public Job Job { get => m_Job; set => m_Job = value; }

        public Nominee Nominee { get => m_Nominee; set => m_Nominee = value; }

        public static Nominee Empty = new Nominee();
        #endregion


        #region Public methods

        /// <summary>
        /// Inserts the nominee's information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public bool Insert()
        {
            /*if (Job_Nominee_Dal.Insert(m_Job.Id, m_Nominee.DBId))
            {
                NomineeArr nomineeArr = new NomineeArr();
                nomineeArr.Fill();

                return true;
            }*/

            return false;
        }

        public bool Update()
        {
            /*if (Nominee_Dal.Update(m_DBId, m_FirstName, m_LastName, m_Id, m_Email, m_BirthYear, m_CellAreaCode, m_CellPhoneNumber, m_City.Id, m_JobType.Id, m_Match, m_Professionalism, m_GeneralAssessment))
            {
                NomineeArr nomineeArr = new NomineeArr();
                nomineeArr.Fill();

                LogEntry logEntry = new LogEntry(DateTime.Now, "המועמד " + m_FirstName + " " + m_LastName + " עודכן בהצלחה", nomineeArr.MaxNomineeDBId());

                logEntry.Insert();
                return true;
            }*/
            return false;
        }


        public bool Delete()
        {
            return false;/*Nominee_Dal.Delete(m_DBId);*/
        }


        public override bool Equals(object obj)
        {
            //returns if the Nominee's properties are identicle to the object's ( if it is a Nominee object) properties. 
            if (obj is Nominee)
            {
                bool output = true;
                foreach (PropertyInfo item in typeof(Nominee).GetProperties())
                {
                    if (true)
                    {
                        output &= item.GetValue(this) == item.GetValue(obj);
                    }

                }
                return output;
            }

            return base.Equals(obj);
        }

        public void Clear()
        {
            //sets each property of the nominee to it's "empty" state.
            foreach (PropertyInfo item in this.GetType().GetProperties())
            {
                if (item.PropertyType == typeof(string))
                {
                    try
                    {
                        item.SetValue(this, "");
                    }
                    catch
                    {

                    }

                }
                else if (item.PropertyType == typeof(int))
                {
                    if (item.Name == "Match" || item.Name == "Professionalism" || item.Name == "GeneralAssessment")
                    {
                        try
                        {
                            item.SetValue(this, 1);
                        }
                        catch
                        {

                        }

                    }
                    else
                    {
                        try
                        {
                            item.SetValue(this, 0);
                        }
                        catch
                        {

                        }
                    }
                }
                else if (item.PropertyType == typeof(City))
                {
                    try
                    {
                        item.SetValue(this, City.Empty);
                    }
                    catch
                    {

                    }

                }
                else if (item.PropertyType == typeof(Job))
                {
                    try
                    {
                        item.SetValue(this, Job.Empty);
                    }
                    catch
                    {

                    }

                }
            }
        }

        public bool isEmpty()
        {
            //checks if the nominee's properties matches the Empty Nominee's properties.
            //AKA it finds out if the nominee is an empty nominee.
            bool output = true;
            foreach (PropertyInfo item in typeof(Nominee).GetProperties())
            {
                if (true)
                {
                    output &= item.GetValue(this) == item.GetValue(Empty);
                }

            }
            return output;
        }
        #endregion
    }
}
