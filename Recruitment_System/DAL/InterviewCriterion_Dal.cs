using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment_System.DAL
{
    class InterviewCriterion_Dal

    {
        public const string tableName = "Table_Scores";
        /// <summary>
        /// Inserts the information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public static bool Insert(int InterviewId, int CriterionId, int score, DateTime date)
        {

            //Building the SQL command
            string str = "INSERT INTO " + tableName
                + "("
                + "[Interview]"
                + ",[Criterion]"
                + ",[Score]"
                + ",[Date]"
                + ")"

                + " VALUES "
                + "("
                      + "" + InterviewId + ""
                + "," + "" + CriterionId + ""
                + "," + "" + score + ""
                + "," + "'" + date.ToString("yyyy-MM-dd") + "'"
                + ")";

            //Running the SQL command by using the ExecuteSql method from the Dal class and return if the command succeeded
            return Dal.ExecuteSql(str);
        }


        public static bool Update(int id, int interviewId, int criterionId, int score, DateTime date)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE " + tableName + " SET"
            + " " + "[Interview] = " + "" + interviewId + ""
            + "," + "[Criterion] = " + "" + criterionId + ""
            + "," + "[Score] = " + "" + score + ""
            + "," + "[Date] = " + "'" + date.ToString("yyyy-MM-dd") + "'"
            + " WHERE ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה

            return Dal.ExecuteSql(str);
        }


        public static DataTable GetDataTable()
        {
            DataTable dataTable;
            DataSet dataSet = new DataSet();

            FillDataSet(dataSet, "[Interview], [Criterion]");


            dataTable = dataSet.Tables[tableName];

            return dataTable;
        }


        public static void FillDataSet(DataSet dataSet, string orderBy)
        {
            Dal.FillDataSet(dataSet, tableName, orderBy);

            Interview_Dal.FillDataSet(dataSet);


            DataRelation dataRelationInterviewCriterion_Interview = new DataRelation(
                "InterviewCriterion_Interview"
                , dataSet.Tables[Interview_Dal.tableName].Columns["ID"]
                , dataSet.Tables[tableName].Columns["Interview"]);


            dataSet.Relations.Add(dataRelationInterviewCriterion_Interview);




            Criterion_Dal.FillDataSet(dataSet);


            DataRelation dataRelationInterviewCriterion_Criterion = new DataRelation(
                "InterviewCriterion_Criterion"
                , dataSet.Tables[Criterion_Dal.tableName].Columns["Id"]
                , dataSet.Tables[tableName].Columns["Criterion"]);


            dataSet.Relations.Add(dataRelationInterviewCriterion_Criterion);



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
