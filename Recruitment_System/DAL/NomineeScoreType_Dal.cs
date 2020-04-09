using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment_System.DAL
{
    class NomineeScoreType_Dal

    {
        public const string tableName = "Table_NomineeScoreType";
        /// <summary>
        /// Inserts the information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public static bool Insert(int InterviewerId, int nomineeDBId, int positionId, int scoreTypeId, int score, DateTime dateTime)
        {

            //Building the SQL command
            string str = "INSERT INTO " + tableName
                + "("
                + "[Interviewer]"
                + ",[Nominee]"
                + ",[Position]"
                + ",[ScoreType]"
                + ",[Score]"
                + ",[DateTime]"
                + ")"

                + " VALUES "
                + "("
                      + "" + InterviewerId + ""
                + "," + "" + nomineeDBId + ""
                + "," + "" + positionId + ""
                + "," + "" + scoreTypeId + ""
                + "," + "" + score + ""
                + "," + "" + dateTime + ""
                + ")";

            //Running the SQL command by using the ExecuteSql method from the Dal class and return if the command succeeded
            return Dal.ExecuteSql(str);
        }


        public static bool Update(int id, int InterviewerId, int nomineeDBId, int positionId, int scoreType, int score, DateTime dateTime)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE " + tableName + " SET"
            + " " + "[Interviewer] = " + "" + InterviewerId + ""
            + "," + "[Nominee] = " + "" + nomineeDBId + ""
            + "," + "[Position] = " + "" + positionId + ""
            + "," + "[ScoreType] = " + "" + scoreType + ""
            + "," + "[Score] = " + "" + score + ""
            + "," + "[DateTime] = " + "" + dateTime + ""
            + " WHERE ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה

            return Dal.ExecuteSql(str);
        }


        public static DataTable GetDataTable()
        {
            DataTable dataTable;
            DataSet dataSet = new DataSet();

            FillDataSet(dataSet, "[Interviewer]");


            dataTable = dataSet.Tables[tableName];

            return dataTable;
        }


        public static void FillDataSet(DataSet dataSet, string orderBy)
        {
            Dal.FillDataSet(dataSet, tableName, orderBy);

            Interviewer_Dal.FillDataSet(dataSet);


            DataRelation dataRelationNomineeScoreType_Interviewer = new DataRelation(
                "NomineeScoreType_Interviewer"
                , dataSet.Tables[Interviewer_Dal.tableName].Columns["ID"]
                , dataSet.Tables[tableName].Columns["Interviewer"]);


            dataSet.Relations.Add(dataRelationNomineeScoreType_Interviewer);




            Nominee_Dal.FillDataSet(dataSet);


            DataRelation dataRelationNomineeScoreType_Nominee = new DataRelation(
                "NomineeScoretype_Nominee"
                , dataSet.Tables[Nominee_Dal.tableName].Columns["Id"]
                , dataSet.Tables[tableName].Columns["Nominee"]);


            dataSet.Relations.Add(dataRelationNomineeScoreType_Nominee);



            Position_Dal.FillDataSet(dataSet);


            DataRelation dataRelationNomineeScoreType_Position = new DataRelation(
                "NomineeScoreType_Position"
                , dataSet.Tables[Position_Dal.tableName].Columns["ID"]
                , dataSet.Tables[tableName].Columns["Position"]);


            dataSet.Relations.Add(dataRelationNomineeScoreType_Position);




            ScoreType_Dal.FillDataSet(dataSet);


            DataRelation dataRelationNomineeScoreType_ScoreType = new DataRelation(
                "NomineeScoretype_ScoreType"
                , dataSet.Tables[ScoreType_Dal.tableName].Columns["Id"]
                , dataSet.Tables[tableName].Columns["ScoreType"]);


            dataSet.Relations.Add(dataRelationNomineeScoreType_ScoreType);
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
