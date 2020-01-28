using Recruitment_System.DAL;
using System;
using System.Collections;
using System.Data;

namespace Recruitment_System.BL
{
    public class LogEntry
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="LogEntry"/> class.
        /// </summary>
        public LogEntry()
        {
            m_Id = 0;
            m_Client = Client.Empty;
            m_DateTime = DateTime.MinValue;
            m_Entry = "";
        }

        public LogEntry(DateTime dateTime, string entry, Client client, int id = 0)
        {
            m_Id = id;
            m_Client = client;
            m_DateTime = dateTime;
            m_Entry = entry;
        }

        public LogEntry(DataRow logEntry_prop)
        {
            m_Id = (int)logEntry_prop["Id"];
            m_Client = new Client(logEntry_prop.GetParentRow("LogEntryClient"));
            m_DateTime = (DateTime)logEntry_prop["DateTime"];
            m_Entry = logEntry_prop["Entry"].ToString().Replace("$", "'");
        }

        #endregion


        #region Private containers

        private int m_Id;
        private Client m_Client;
        private DateTime m_DateTime;
        private string m_Entry;

        #endregion


        #region Public variables
        public int Id { get => m_Id; set => m_Id = value; }
        public DateTime DateTime { get => m_DateTime; set => m_DateTime = value; }
        public string Entry { get => m_Entry; set => m_Entry = value; }
        public Client Client { get => m_Client; set => m_Client = value; }

        public static LogEntry Empty = new LogEntry();

        #endregion


        #region Public methods

        /// <summary>
        /// Inserts the logEntry's information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public bool Insert()
        {
            return LogEntry_Dal.Insert(m_Client.DBId, m_DateTime, m_Entry);
        }

        public bool Update()
        {
            return LogEntry_Dal.Update(m_Id, m_Client.DBId, m_DateTime, m_Entry);
        }


        public bool Delete()
        {
            return LogEntry_Dal.Delete(m_Id);
        }


        public override string ToString()
        {
            return m_Entry;
        }

        #endregion
    }
}
