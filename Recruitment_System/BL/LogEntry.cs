using Recruitment_System.DAL;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

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
            m_Nominee = Nominee.Empty;
            m_DateTime = DateTimePicker.MinimumDateTime;
            m_Entry = "";
        }

        public LogEntry(DateTime dateTime, string entry, Nominee nominee, int id = 0)
        {
            m_Id = id;
            m_Nominee = nominee;
            m_DateTime = dateTime;
            m_Entry = entry;
        }

        public LogEntry(DataRow logEntry_prop)
        {
            m_Id = (int)logEntry_prop["Id"];
            m_Nominee = new Nominee(logEntry_prop.GetParentRow("LogEntryNominee"));
            m_DateTime = (DateTime)logEntry_prop["DateTime"];
            m_Entry = logEntry_prop["Entry"].ToString().Replace("&acute;", "'");
        }

        #endregion


        #region Private containers

        private int m_Id;
        private Nominee m_Nominee;
        private DateTime m_DateTime;
        private string m_Entry;

        #endregion


        #region Public variables
        public int Id { get => m_Id; set => m_Id = value; }
        public DateTime DateTime { get => m_DateTime; set => m_DateTime = value; }
        public string Entry { get => m_Entry; set => m_Entry = value; }
        public Nominee Nominee { get => m_Nominee; set => m_Nominee = value; }

        public static LogEntry Empty = new LogEntry();

        #endregion


        #region Public methods

        /// <summary>
        /// Inserts the logEntry's information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public bool Insert()
        {
            return LogEntry_Dal.Insert(m_Nominee.DBId, m_DateTime, m_Entry);
        }

        public bool Update()
        {
            return LogEntry_Dal.Update(m_Id, m_Nominee.DBId, m_DateTime, m_Entry);
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
