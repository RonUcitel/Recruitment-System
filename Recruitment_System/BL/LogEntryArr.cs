using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using Recruitment_System.DAL;

namespace Recruitment_System.BL
{
    public class LogEntryArr : ArrayList
    {
        public void Fill()
        {
            this.Clear();
            DataTable dataTable = LogEntry_Dal.GetDataTable();


            DataRow dataRow;
            LogEntry logEntry;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                logEntry = new LogEntry(dataRow);

                Add(logEntry);
            }
        }

        public LogEntryArr Filter(int nomineeDBId, DateTime dateTime, string entry)
        {
            LogEntryArr logEntryArr = new LogEntryArr();

            LogEntry logEntry;
            for (int i = 0; i < this.Count; i++)
            {
                logEntry = (this[i] as LogEntry);
                if ((nomineeDBId <= 0 || logEntry.Nominee.DBId == nomineeDBId) &
                    (dateTime == DateTime.MinValue || logEntry.DateTime.ToString("dd-MM-yyyy") == dateTime.ToString("dd-MM-yyyy")) &&
                    (entry == null || entry == "" || logEntry.Entry.Contains(entry)))
                {
                    logEntryArr.Add(logEntry);
                }
            }

            return logEntryArr;
        }

        public LogEntryArr Filter(int nomineeDBId, DateTime from, DateTime to)
        {
            LogEntryArr logEntryArr = new LogEntryArr();

            LogEntry logEntry;
            for (int i = 0; i < this.Count; i++)
            {
                logEntry = (this[i] as LogEntry);
                if ((nomineeDBId <= 0 || logEntry.Nominee.DBId == nomineeDBId) &
                    (from <= logEntry.DateTime && logEntry.DateTime <= to))
                {
                    logEntryArr.Add(logEntry);
                }
            }

            return logEntryArr;
        }

        public bool DeleteArr()
        {
            //מוחקת את אוסף המוצרים להזמנה מ מסד הנתונים

            LogEntry logEntry;
            for (int i = 0; i < this.Count; i++)
            {
                logEntry = (this[i] as LogEntry);
                if (!logEntry.Delete())
                    return false;

            }
            return true;
        }

        public bool IsContains(string logEntryName)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as LogEntry).ToString() == logEntryName)
                    return true;
            }
            return false;
        }


        public LogEntry GetLogEntryWithMaxId()
        {
            LogEntry maxLogEntry = new LogEntry();

            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as LogEntry).Id > maxLogEntry.Id)
                {
                    maxLogEntry = (this[i] as LogEntry);
                }
            }
            return maxLogEntry;
        }
    }
}
