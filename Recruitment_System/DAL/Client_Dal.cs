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
        public const string tableName = "Table_Client";
        /// <summary>
        /// Inserts the information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public static bool Insert(string firstName, string lastName, string iDNum, string email, int birthYear, string cellPhoneAreaCode, string cellPhoneNumber, int city, int jobType, int match, int professionalism, int generalAssessment)
        {

            //Building the SQL command
            string str = "INSERT INTO " + tableName
                + "("
                + "[FirstName]"
                + ",[LastName]"
                + ",[ID_Num]"
                + ",[Email]"
                + ",[BirthYear]"
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
                + "," + "'" + email + "'"
                + "," + "" + birthYear + ""
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


        public static bool Update(int id, string firstName, string lastName, string iDNum, string email, int birthYear, string cellPhoneAreaCode, string cellPhoneNumber, int city, int jobType, int match, int professionalism, int generalAssessment)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE " + tableName + " SET"
            + " " + "[FirstName] = " + "N'" + firstName.Replace("'", "$") + "'"
            + "," + "[LastName] = " + "N'" + lastName.Replace("'", "$") + "'"
            + "," + "[ID_Num] = " + "'" + iDNum + "'"
            + "," + "[Email] = " + "'" + email + "'"
            + "," + "[BirthYear] = " + "" + birthYear + ""
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
            Dal.FillDataSet(dataSet, tableName, "[lastName],[FirstName]");

            City_Dal.FillDataSet(dataSet);


            DataRelation dataRelationClientCity = new DataRelation(
                "ClientCity"
                , dataSet.Tables[City_Dal.tableName].Columns["Id"]
                , dataSet.Tables[tableName].Columns["City"]);


            dataSet.Relations.Add(dataRelationClientCity);



            Job_Dal.FillDataSet(dataSet);


            DataRelation dataRelationClientJob = new DataRelation(
                "ClientJob"
                , dataSet.Tables[Job_Dal.tableName].Columns["ID"]
                , dataSet.Tables[tableName].Columns["JobType"]);


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
            string str = "DELETE FROM " + tableName
            + " WHERE ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה
            return Dal.ExecuteSql(str);
        }
    }
}
