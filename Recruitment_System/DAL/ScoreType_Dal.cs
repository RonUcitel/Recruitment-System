using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment_System.DAL
{
    class ScoreType_Dal
    {
        public const string tableName = "Table_ScoreType";


        /// <summary>
        /// Inserts the information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public static bool Insert(string scoreType, int positionId)
        {

            //Building the SQL command
            string str = "INSERT INTO " + tableName
                + "("
                + "[Name]"
                + ",[Position]"
                + ")"

                + " VALUES "
                + "("
                      + "N'" + scoreType + "'"
                      + "," + positionId + ""
                + ")";

            //Running the SQL command by using the ExecuteSql method from the Dal class and return if the command succeeded
            return Dal.ExecuteSql(str);
        }


        public static bool Update(int id, string scoreType, int positionId)
        {

            string str = "UPDATE " + tableName + " SET"
            + " " + "[Name] = " + "N'" + scoreType + "'"
            + "," + "[Position] = " + "" + positionId + ""

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
            Dal.FillDataSet(dataSet, tableName, "[Position],[Name]");

            Position_Dal.FillDataSet(dataSet);


            DataRelation dataRelationScoreType_Position = new DataRelation(
                "ScoreType_Position"
                , dataSet.Tables[Position_Dal.tableName].Columns["Id"]
                , dataSet.Tables[tableName].Columns["Position"]);


            dataSet.Relations.Add(dataRelationScoreType_Position);
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
