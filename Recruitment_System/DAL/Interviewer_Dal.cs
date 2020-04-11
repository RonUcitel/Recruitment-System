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
        public static bool Insert(string firstName, string lastName, string id, int credentialsId, bool admin)
        {

            //Building the SQL command
            string str = "INSERT INTO " + tableName
                + "("
                + "[FirstName]"
                + ",[LastName]"
                + ",[Id_Num]"
                + ",[Credentials]"
                + ",[Admin]"
                + ")"

                + " VALUES "
                + "("
                      + "N'" + firstName.Replace("'", "$") + "'"
                + "," + "N'" + lastName.Replace("'", "$") + "'"
                + "," + "N'" + id + "'"
                + "," + "" + credentialsId + ""
                + "," + "" + (admin ? 1 : 0) + ""
                + ")";

            //Running the SQL command by using the ExecuteSql method from the Dal class and return if the command succeeded
            return Dal.ExecuteSql(str);
        }


        public static bool Update(int dBId, string firstName, string lastName, string id, int credentialsId, bool admin)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE " + tableName + " SET"
            + " " + "[FirstName] = " + "N'" + firstName.Replace("'", "$") + "'"
            + "," + "[LastName] = " + "N'" + lastName.Replace("'", "$") + "'"
            + "," + "[Id_Num] = " + "N'" + id + "'"
            + "," + "[Credentials] = " + "" + credentialsId + ""
            + "," + "[Admin] = " + "" + (admin ? 1 : 0) + ""
            + " WHERE ID = " + dBId;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה

            return Dal.ExecuteSql(str);
        }


        public static bool ChangeAdmin(int dBId, bool isAdmin)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE " + tableName + " SET"
            + " " + "[Admin] = " + "" + (isAdmin ? 1 : 0) + ""

            + " WHERE ID = " + dBId;

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


            Credentials_Dal.FillDataSet(dataSet);


            DataRelation dataRelationInterviewerCredentials = new DataRelation(
                "InterviewerCredentials"
                , dataSet.Tables[Credentials_Dal.tableName].Columns["Id"]
                , dataSet.Tables[tableName].Columns["Credentials"]);


            dataSet.Relations.Add(dataRelationInterviewerCredentials);
        }


        /// <summary>
        /// Delete the nominee from the DataBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int dBId)
        {

            //מוחקת את הלקוח ממסד הנתונים
            string str = "DELETE FROM " + tableName
            + " WHERE ID = " + dBId;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה
            return Dal.ExecuteSql(str);
        }
    }
}
