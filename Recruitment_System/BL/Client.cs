using Recruitment_System.DAL;
using System.Collections;
using System.Data;
using System.Reflection;
using System.IO;

namespace Recruitment_System.BL
{
    public class Client
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        public Client()
        {
            Clear();
            //m_DBId = 0;
            //m_FirstName = "";
            //m_LastName = "";
            //m_Id = "";
            //m_CellAreaCode = "";
            //m_CellPhoneNumber = "";
            //m_City = City.Empty;
            //m_JobType = Job.Empty;
            //m_Match = 0;
            //m_Professionalism = 0;
            //m_GeneralAssessment = 0;
        }
        public Client(DataRow client_prop)
        {
            m_DBId = (int)client_prop["ID"];
            m_FirstName = client_prop["FirstName"].ToString().Replace("$", "'");
            m_LastName = client_prop["LastName"].ToString().Replace("$", "'");
            m_Id = client_prop["ID_Num"].ToString();
            m_CellAreaCode = client_prop["CellAreaCode"].ToString();
            m_CellPhoneNumber = client_prop["CellPhoneNumber"].ToString();
            m_City = new City(client_prop.GetParentRow("ClientCity"));
            m_JobType = new Job(client_prop.GetParentRow("ClientJob"));
            m_Match = (byte)client_prop["Match"];
            m_Professionalism = (byte)client_prop["Professionalism"];
            m_GeneralAssessment = (byte)client_prop["GeneralAssessment"];
        }

        #region Private containers

        private int m_DBId;

        private string m_FirstName;

        private string m_LastName;

        private string m_Id;

        private string m_CellAreaCode;

        private string m_CellPhoneNumber;

        private City m_City;

        private Job m_JobType;

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
        public Job JobType { get => m_JobType; set => m_JobType = value; }
        public int Match { get => m_Match; set => m_Match = value; }
        public int Professionalism { get => m_Professionalism; set => m_Professionalism = value; }
        public int GeneralAssessment { get => m_GeneralAssessment; set => m_GeneralAssessment = value; }

        public bool HaveCV { get => File.Exists(""); }

        public string CV { get => (HaveCV) ? @"\CVS\" + m_Id + @"\" + m_Id + ".pdf" : ""; }


        public static Client Empty = new Client();
        #endregion


        #region Public methods

        /// <summary>
        /// Inserts the client's information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public bool Insert()
        {
            return Client_Dal.Insert(m_FirstName, m_LastName, m_Id, m_CellAreaCode, m_CellPhoneNumber, m_City.Id, m_JobType.Id, m_Match, m_Professionalism, m_GeneralAssessment);
        }

        public bool Update()
        {
            return Client_Dal.Update(m_DBId, m_FirstName, m_LastName, m_Id, m_CellAreaCode, m_CellPhoneNumber, m_City.Id, m_JobType.Id, m_Match, m_Professionalism, m_GeneralAssessment);
        }


        public bool Delete()
        {
            return Client_Dal.Delete(m_DBId);
        }


        public override string ToString()
        {
            return m_LastName + " " + m_FirstName;
        }


        public override bool Equals(object obj)
        {
            //returns if the Client's properties are identicle to the object's ( if it is a Client object) properties. 
            if (obj is Client)
            {
                bool output = true;
                foreach (PropertyInfo item in typeof(Client).GetProperties())
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
            //sets each property of the client to it's "empty" state.
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
            //checks if the client's properties matches the Empty Client's properties.
            //AKA it finds out if the client is an empty client.
            bool output = true;
            foreach (PropertyInfo item in typeof(Client).GetProperties())
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
