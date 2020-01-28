using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment_System.DAL
{
    class LogEntry_Dal
    {
        public const string tableName = "Table_Log";

        /// <summary>
        /// Inserts the information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public static bool Insert(int clientDBId, DateTime dateTime, string entry)
        {

            //Building the SQL command
            string str = "INSERT INTO " + tableName
                + "("
                + "[Client]"
                + ",[DateTime]"
                + ",[Entry]"
                + ")"

                + " VALUES "
                + "("
                     + "" + clientDBId + ""
                + "," + "'" + dateTime.ToString("yyyy-MM-dd HH:mm:ss") + "'"
                + "," + "N'" + entry.Replace("'", "$") + "'"
                + ")";

            //Running the SQL command by using the ExecuteSql method from the Dal class and return if the command succeeded
            return Dal.ExecuteSql(str);
        }


        public static bool Update(int id, int clientDBId, DateTime dateTime, string entry)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE " + tableName + " SET"
            + " " + "[Client] = " + "" + clientDBId + ""
            + "," + "[DateTime] = " + "'" + dateTime.ToString("yyyy-MM-dd HH:mm:ss") + "'"
            + "," + "[Entry] = " + "N'" + entry + "'"

            + " WHERE ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה

            return Dal.ExecuteSql(str);
        }


        public static DataTable GetDataTable()
        {
            DataTable dataTable;
            DataSet dataSet = new DataSet();

            FillDataSet(dataSet);
            dataTable = dataSet.Tables[tableName];

            return dataTable;
        }


        public static void FillDataSet(DataSet dataSet)
        {
            Dal.FillDataSet(dataSet, tableName, "[DateTime], [Client]");

            Client_Dal.FillDataSet(dataSet);


            DataRelation dataRelationLogEntryClient = new DataRelation(
                "LogEntryClient"
                , dataSet.Tables[Client_Dal.tableName].Columns["Id"]
                , dataSet.Tables[tableName].Columns["Client"]);


            dataSet.Relations.Add(dataRelationLogEntryClient);



            Job_Dal.FillDataSet(dataSet);
        }


        /// <summary>
        /// Delete the log from the DataBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {

            //מוחקת את הלקוח ממסד הנתונים
            string str = "DELETE FROM " + tableName
            + " WHERE ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה
            return Dal.ExecuteSql(str);
        }
    }
}
