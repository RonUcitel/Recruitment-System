using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Recruitment_System.DAL
{
    class Interviewer_Dal

    {
        public const string tableName = "Table_Interviewer";
        /// <summary>
        /// Inserts the information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public static bool Insert(string firstName, string lastName, int credentialsId)
        {

            //Building the SQL command
            string str = "INSERT INTO " + tableName
                + "("
                + "[FirstName]"
                + ",[LastName]"
                + ",[Credentials]"
                + ")"

                + " VALUES "
                + "("
                      + "N'" + firstName.Replace("'", "$") + "'"
                + "," + "N'" + lastName.Replace("'", "$") + "'"
                + "," + "" + credentialsId + ""
                + ")";

            //Running the SQL command by using the ExecuteSql method from the Dal class and return if the command succeeded
            return Dal.ExecuteSql(str);
        }


        public static bool Update(int id, string firstName, string lastName, int credentialsId)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE " + tableName + " SET"
            + " " + "[FirstName] = " + "N'" + firstName + "'"
            + "," + "[LastName] = " + "N'" + lastName + "'"
            + "," + "[Credentials] = " + "" + credentialsId + ""

            + " WHERE ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה

            return Dal.ExecuteSql(str);
        }


        public static bool ChangeHidden(int id, bool isHidden)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE " + tableName + " SET"
            + " " + "[Hidden] = " + "" + (isHidden ? 1 : 0) + ""

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
            Dal.FillDataSet(dataSet, tableName, "");
        }


        /// <summary>
        /// Delete the nominee from the DataBase
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
