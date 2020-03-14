using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment_System.DAL
{
    class JobNominee_Dal
    {
        public const string tableName = "Table_JobNominee";
        /// <summary>
        /// Inserts the information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public static bool Insert(int jobId, int nomineeDBId)
        {

            //Building the SQL command
            string str = "INSERT INTO " + tableName
                + "("
                + "[Job]"
                + ",[Nominee]"
                + ")"

                + " VALUES "
                + "("
                      + "" + jobId + ""
                + "," + "" + nomineeDBId + ""
                + ")";

            //Running the SQL command by using the ExecuteSql method from the Dal class and return if the command succeeded
            return Dal.ExecuteSql(str);
        }


        public static bool Update(int id, int jobId, int nomineeDBId)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE " + tableName + " SET"
            + " " + "[Job] = " + "" + jobId + ""
            + "," + "[Nominee] = " + "" + nomineeDBId + ""
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
            Dal.FillDataSet(dataSet, tableName, "[Job]");

            Job_Dal.FillDataSet(dataSet);


            DataRelation dataRelationJob_NomineeJob = new DataRelation(
                "JobNominee_Job"
                , dataSet.Tables[Job_Dal.tableName].Columns["ID"]
                , dataSet.Tables[tableName].Columns["Job"]);


            dataSet.Relations.Add(dataRelationJob_NomineeJob);




            Nominee_Dal.FillDataSet(dataSet);


            DataRelation dataRelationJob_NomineeNominee = new DataRelation(
                "JobNominee_Nominee"
                , dataSet.Tables[Nominee_Dal.tableName].Columns["Id"]
                , dataSet.Tables[tableName].Columns["Nominee"]);


            dataSet.Relations.Add(dataRelationJob_NomineeNominee);
        }


        /// <summary>
        /// Delete the city from the DataBase
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
