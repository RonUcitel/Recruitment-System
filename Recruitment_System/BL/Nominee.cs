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
            m_PositionType = new Position(nominee_prop.GetParentRow("NomineePosition"));
            m_Match = (byte)nominee_prop["Match"];
            m_Professionalism = (byte)nominee_prop["Professionalism"];
            m_GeneralAssessment = (byte)nominee_prop["GeneralAssessment"];
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

        private Position m_PositionType;

        private int m_Match;

        private int m_Professionalism;

        private int m_GeneralAssessment;
        #endregion


        #region Public Properties
        public int DBId { get => m_DBId; set => m_DBId = value; }
        public string FirstName { get => m_FirstName; set => m_FirstName = value; }
        public string LastName { get => m_LastName; set => m_LastName = value; }
        public string Id { get => m_Id; set => m_Id = value; }
        public string CellAreaCode { get => m_CellAreaCode; set => m_CellAreaCode = value; }
        public string CellPhone { get => m_CellPhoneNumber; set => m_CellPhoneNumber = value; }
        public City City { get => m_City; set => m_City = value; }
        public Position PositionType { get => m_PositionType; set => m_PositionType = value; }
        public int Match { get => m_Match; set => m_Match = value; }
        public int Professionalism { get => m_Professionalism; set => m_Professionalism = value; }
        public int GeneralAssessment { get => m_GeneralAssessment; set => m_GeneralAssessment = value; }

        public bool HaveCV { get => File.Exists(""); }

        public string CV { get => (HaveCV) ? @"\CVS\" + m_Id + @"\" + m_Id + ".pdf" : ""; }
        public int BirthYear { get => m_BirthYear; set => m_BirthYear = value; }
        public string Email { get => m_Email; set => m_Email = value; }
        public bool Disabled { get => m_Disabled; set => m_Disabled = value; }

        public static Nominee Empty = new Nominee();
        #endregion


        #region Public methods

        /// <summary>
        /// Inserts the nominee's information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public bool Insert()
        {
            if (Nominee_Dal.Insert(m_FirstName, m_LastName, m_Id, m_Email, m_BirthYear, m_CellAreaCode, m_CellPhoneNumber, m_City.Id, m_PositionType.Id, m_Match, m_Professionalism, m_GeneralAssessment))
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
            if (Nominee_Dal.Update(m_DBId, m_FirstName, m_LastName, m_Id, m_Email, m_BirthYear, m_CellAreaCode, m_CellPhoneNumber, m_City.Id, m_PositionType.Id, m_Match, m_Professionalism, m_GeneralAssessment))
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
            return Nominee_Dal.Delete(m_DBId);
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
                else if (item.PropertyType == typeof(Position))
                {
                    try
                    {
                        item.SetValue(this, Position.Empty);
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
