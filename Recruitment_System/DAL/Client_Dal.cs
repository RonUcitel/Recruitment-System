using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Recruitment_System.DAL
{
    class Client_Dal
    {
        /// <summary>
        /// Inserts the information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public static bool Insert(string firstName, string lastName, string iDNum, string cellPhoneAreaCode, string cellPhoneNumber, int city, int jobType, int match, int professionalism, int generalAssessment)
        {

            //Building the SQL command
            string str = "INSERT INTO Table_Client"
                + "("
                + "[FirstName]"
                + ",[LastName]"
                + ",[ID_Num]"
                + ",[CellAreaCode]"
                + ",[CellPhoneNumber]"
                + ",[City]"
                + ",[JobType]"
                + ",[Match]"
                + ",[Professionalism]"
                + ",[GeneralAssessment]"
                + ")"

                + " VALUES "
                + "("
                      + "N'" + firstName.Replace("'", "$") + "'"
                + "," + "N'" + lastName.Replace("'", "$") + "'"
                + "," + "'" + iDNum + "'"
                + "," + "'" + cellPhoneAreaCode + "'"
                + "," + "'" + cellPhoneNumber + "'"
                + "," + "" + city + ""
                + "," + "" + jobType + ""
                + "," + "'" + match + "'"
                + "," + "'" + professionalism + "'"
                + "," + "'" + generalAssessment + "'"
                + ")";

            //Running the SQL command by using the ExecuteSql method from the Dal class and return if the command succeeded
            return Dal.ExecuteSql(str);
        }


        public static bool Update(int id, string firstName, string lastName, string iDNum, string cellPhoneAreaCode, string cellPhoneNumber, int city, int jobType, int match, int professionalism, int generalAssessment)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE Table_Client SET"
            + " " + "[FirstName] = " + "N'" + firstName.Replace("'", "$") + "'"
            + "," + "[LastName] = " + "N'" + lastName.Replace("'", "$") + "'"
            + "," + "[ID_Num] = " + "'" + iDNum + "'"
            + "," + "[CellAreaCode] = " + "'" + cellPhoneAreaCode + "'"
            + "," + "[CellPhoneNumber] = " + "'" + cellPhoneNumber + "'"
            + "," + "[City] = " + "" + city + ""
            + "," + "[JobType] = " + "" + jobType + ""
            + "," + "[Match] = " + "'" + match + "'"
            + "," + "[Professionalism] = " + "'" + professionalism + "'"
            + "," + "[GeneralAssessment] = " + "'" + generalAssessment + "'"

            + " WHERE ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה

            return Dal.ExecuteSql(str);
        }


        public static DataTable GetDataTable()
        {
            DataTable dataTable;
            DataSet dataSet = new DataSet();

            FillDataSet(dataSet);
            dataTable = dataSet.Tables["Table_Client"];

            return dataTable;
        }


        public static void FillDataSet(DataSet dataSet)
        {
            Dal.FillDataSet(dataSet, "Table_Client", "[lastName],[FirstName]");

            City_Dal.FillDataSet(dataSet);


            DataRelation dataRelationClientCity = new DataRelation(
                "ClientCity"
                , dataSet.Tables["Table_City"].Columns["Id"]
                , dataSet.Tables["Table_Client"].Columns["City"]);


            dataSet.Relations.Add(dataRelationClientCity);



            Job_Dal.FillDataSet(dataSet);


            DataRelation dataRelationClientJob = new DataRelation(
                "ClientJob"
                , dataSet.Tables["Table_Job"].Columns["ID"]
                , dataSet.Tables["Table_Client"].Columns["JobType"]);


            dataSet.Relations.Add(dataRelationClientJob);
        }


        /// <summary>
        /// Delete the client from the DataBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {

            //מוחקת את הלקוח ממסד הנתונים
            string str = "DELETE FROM Table_Client"
            + " WHERE ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה
            return Dal.ExecuteSql(str);
        }
    }
}
