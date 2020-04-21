using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Recruitment_System.DAL
{
    class Interview_Dal

    {
        public const string tableName = "Table_Interview";
        /// <summary>
        /// Inserts the information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public static bool Insert(int interviewerDBId, int co_InterviewerDBId, int nomineeDBId, int positionId, DateTime date)
        {

            //Building the SQL command
            string str = "INSERT INTO " + tableName
                + "("
                + "[Interviewer]"
                + ",[Co-Interviewer]"
                + ",[Nominee]"
                + ",[Position]"
                + ",[Date]"
                + ")"

                + " VALUES "
                + "("
                      + "" + interviewerDBId + ""
                + "," + "" + co_InterviewerDBId + ""
                + "," + "" + nomineeDBId + ""
                + "," + "" + positionId + ""
                + "," + "'" + date.ToString("yyyy-MM-dd") + "'"
                + ")";

            //Running the SQL command by using the ExecuteSql method from the Dal class and return if the command succeeded
            return Dal.ExecuteSql(str);
        }


        public static bool Update(int id, int interviewerDBId, int co_InterviewerDBId, int nomineeDBId, int positionId, DateTime date)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE " + tableName + " SET"

            + " " + "[Interviewer]" + "" + interviewerDBId + ""
            + "," + "[Co-Interviewer]" + "" + co_InterviewerDBId + ""
            + "," + "[Nominee]" + "" + nomineeDBId + ""
            + "," + "[Position]" + "" + positionId + ""
            + "," + "[Date]" + "'" + date.ToString("yyyy-MM-dd") + "'"

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
            Dal.FillDataSet(dataSet, tableName, "[Interviewer],[Co-Interviewer],[Position], [Nominee]");


            Interviewer_Dal.FillDataSet(dataSet);


            DataRelation dataRelationInterviewInterviewer = new DataRelation(
                "InterviewInterviewer"
                , dataSet.Tables[Interviewer_Dal.tableName].Columns["Id"]
                , dataSet.Tables[tableName].Columns["Interviewer"]);


            dataSet.Relations.Add(dataRelationInterviewInterviewer);



            DataRelation dataRelationInterviewCo_Interviewer = new DataRelation(
                "InterviewCo_Interviewer"
                , dataSet.Tables[Interviewer_Dal.tableName].Columns["Id"]
                , dataSet.Tables[tableName].Columns["Co-Interviewer"]);


            dataSet.Relations.Add(dataRelationInterviewCo_Interviewer);



            Nominee_Dal.FillDataSet(dataSet);


            DataRelation dataRelationInterviewNominee = new DataRelation(
                "InterviewNominee"
                , dataSet.Tables[Nominee_Dal.tableName].Columns["Id"]
                , dataSet.Tables[tableName].Columns["Nominee"]);


            dataSet.Relations.Add(dataRelationInterviewNominee);



            Position_Dal.FillDataSet(dataSet);


            DataRelation dataRelationInterviewPosition = new DataRelation(
                "InterviewPosition"
                , dataSet.Tables[Position_Dal.tableName].Columns["Id"]
                , dataSet.Tables[tableName].Columns["Position"]);


            dataSet.Relations.Add(dataRelationInterviewPosition);
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
