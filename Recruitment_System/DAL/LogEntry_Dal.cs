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
        public static bool Insert(int nomineeDBId, DateTime dateTime, string entry)
        {

            //Building the SQL command
            string str = "INSERT INTO " + tableName
                + "("
                + "[Nominee]"
                + ",[DateTime]"
                + ",[Entry]"
                + ")"

                + " VALUES "
                + "("
                     + "" + nomineeDBId + ""
                + "," + "'" + dateTime.ToString("yyyy-MM-dd HH:mm:ss") + "'"
                + "," + "N'" + entry.Replace("'", "$") + "'"
                + ")";

            //Running the SQL command by using the ExecuteSql method from the Dal class and return if the command succeeded
            return Dal.ExecuteSql(str);
        }


        public static bool Update(int id, int nomineeDBId, DateTime dateTime, string entry)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE " + tableName + " SET"
            + " " + "[Nominee] = " + "" + nomineeDBId + ""
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
            Dal.FillDataSet(dataSet, tableName, "[DateTime], [Nominee]");

            Nominee_Dal.FillDataSet(dataSet);


            DataRelation dataRelationLogEntryNominee = new DataRelation(
                "LogEntryNominee"
                , dataSet.Tables[Nominee_Dal.tableName].Columns["Id"]
                , dataSet.Tables[tableName].Columns["Nominee"]);


            dataSet.Relations.Add(dataRelationLogEntryNominee);



            Position_Dal.FillDataSet(dataSet);
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
