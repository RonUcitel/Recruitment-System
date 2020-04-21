using Recruitment_System.DAL;
using System.Collections;
using System.Data;
using System.Reflection;
using System.IO;
using System;

namespace Recruitment_System.BL
{
    public class Nominee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Nominee"/> class.
        /// </summary>
        public Nominee()
        {
            Clear();
            //m_DBId = 0;
            //m_FirstName = "";
            //m_LastName = "";
            //m_Id = "";
            //m_CellAreaCode = "";
            //m_CellPhoneNumber = "";
            //m_City = City.Empty;
            //m_PositionType = Position.Empty;
            //m_Match = 0;
            //m_Professionalism = 0;
            //m_GeneralAssessment = 0;
        }
        public Nominee(DataRow nominee_prop)
        {
            m_DBId = (int)nominee_prop["ID"];
            m_Disabled = (bool)nominee_prop["Disabled"];
            m_FirstName = nominee_prop["FirstName"].ToString().Replace("$", "'");
            m_LastName = nominee_prop["LastName"].ToString().Replace("$", "'");
            m_Id = nominee_prop["ID_Num"].ToString();
            Email = nominee_prop["Email"].ToString();
            m_BirthYear = (int)nominee_prop["BirthYear"];
            m_CellAreaCode = nominee_prop["CellAreaCode"].ToString();
            m_CellPhoneNumber = nominee_prop["CellPhoneNumber"].ToString();
            m_City = new City(nominee_prop.GetParentRow("NomineeCity"));
            m_Male = (bool)nominee_prop["Male"];
        }

        #region Private containers

        private int m_DBId;

        private bool m_Disabled;

        private string m_FirstName;

        private string m_LastName;

        private string m_Id;

        private string m_Email;

        private int m_BirthYear;

        private string m_CellAreaCode;

        private string m_CellPhoneNumber;

        private City m_City;

        private bool m_Male;
        #endregion


        #region Public Properties
        public int DBId { get => m_DBId; set => m_DBId = value; }
        public string FirstName { get => m_FirstName; set => m_FirstName = value; }
        public string LastName { get => m_LastName; set => m_LastName = value; }
        public string Id { get => m_Id; set => m_Id = value; }
        public string CellAreaCode { get => m_CellAreaCode; set => m_CellAreaCode = value; }
        public string CellPhone { get => m_CellPhoneNumber; set => m_CellPhoneNumber = value; }
        public City City { get => m_City; set => m_City = value; }
        public string FullName { get => m_FirstName + " " + m_LastName; }

        public bool HaveCV { get => File.Exists(""); }

        public string CV { get => (HaveCV) ? @"\CVS\" + m_Id + @"\" + m_Id + ".pdf" : ""; }
        public int BirthYear { get => m_BirthYear; set => m_BirthYear = value; }
        public string Email { get => m_Email; set => m_Email = value; }
        public bool Disabled { get => m_Disabled; set => m_Disabled = value; }
        public bool Male { get => m_Male; set => m_Male = value; }

        public static readonly Nominee Empty = new Nominee();
        #endregion


        #region Public methods

        /// <summary>
        /// Inserts the nominee's information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public bool Insert()
        {
            if (Nominee_Dal.Insert(m_FirstName, m_LastName, m_Id, m_Email, m_BirthYear, m_CellAreaCode, m_CellPhoneNumber, m_City.Id, m_Male))
            {
                NomineeArr nomineeArr = new NomineeArr();
                nomineeArr.FillEnabled();

                LogEntry logEntry = new LogEntry(DateTime.Now, "המועמד " + m_FirstName + " " + m_LastName + " נוסף בהצלחה", nomineeArr.MaxNomineeDBId());

                logEntry.Insert();
                return true;
            }

            return false;
        }

        public bool Update()
        {
            if (Nominee_Dal.Update(m_DBId, m_FirstName, m_LastName, m_Id, m_Email, m_BirthYear, m_CellAreaCode, m_CellPhoneNumber, m_City.Id, m_Male))
            {
                NomineeArr nomineeArr = new NomineeArr();
                nomineeArr.FillEnabled();

                LogEntry logEntry = new LogEntry(DateTime.Now, "המועמד " + m_FirstName + " " + m_LastName + " עודכן בהצלחה", nomineeArr.MaxNomineeDBId());

                logEntry.Insert();
                return true;
            }
            return false;
        }


        public bool Delete()
        {
            LogEntryArr logEntryArr = new LogEntryArr();
            logEntryArr.Fill();
            logEntryArr = logEntryArr.Filter(this.DBId, DateTime.MinValue, "");

            if (logEntryArr.DeleteArr())
            {
                InterviewCriterionArr nomineeScoreTypeArr = new InterviewCriterionArr();
                PositionNomineeArr positionNomineeArr = new PositionNomineeArr();
                if (this.Disabled)
                {
                    nomineeScoreTypeArr.FillDisabled();
                    positionNomineeArr.FillDisabled();
                }
                else
                {
                    nomineeScoreTypeArr.FillEnabled();
                    positionNomineeArr.FillEnabled();
                }

                nomineeScoreTypeArr = nomineeScoreTypeArr.Filter(Interviewer.Empty, this, PositionType.Empty, DateTime.MinValue, DateTime.MaxValue);

                if (nomineeScoreTypeArr.DeleteArr())
                {

                    positionNomineeArr = positionNomineeArr.Filter(this, Position.Empty);
                    if (positionNomineeArr.DeleteArr())
                    {
                        return Nominee_Dal.Delete(m_DBId);
                    }
                }
            }
            return false;
        }


        public bool Disable()
        {
            if (Nominee_Dal.ChangeDisabled(m_DBId, true))
            {
                LogEntry logEntry = new LogEntry(DateTime.Now, "המועמד " + m_FirstName + " " + m_LastName + " נהפך ללא זמין", this);

                logEntry.Insert();
                return true;
            }
            return false;
        }


        public bool Enable()
        {
            if (Nominee_Dal.ChangeDisabled(m_DBId, false))
            {
                LogEntry logEntry = new LogEntry(DateTime.Now, "המועמד " + m_FirstName + " " + m_LastName + " נהפך לזמין", this);

                logEntry.Insert();
                return true;
            }
            return false;
        }


        public override string ToString()
        {
            return m_LastName + " " + m_FirstName;
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
                    try
                    {
                        item.SetValue(this, 0);
                    }
                    catch
                    {

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
                else if (item.PropertyType == typeof(bool))
                {
                    try
                    {
                        item.SetValue(this, false);
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

        public static bool operator ==(Nominee left, Nominee right)
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
                    (left.Email == right.Email) &&
                    (left.BirthYear == right.BirthYear) &&
                    (left.CellPhone == right.CellPhone) &&
                    (left.City == right.City));
        }


        public static bool operator !=(Nominee left, Nominee right)
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
                    (left.Email != right.Email) ||
                    (left.BirthYear != right.BirthYear) ||
                    (left.CellPhone != right.CellPhone) ||
                    (left.City != right.City));
        }
        #endregion
    }
}
