using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment_System.DAL
{
    class PositionTypeCriterion_Dal
    {
        public const string tableName = "Table_PositionType_Criterion";
        /// <summary>
        /// Inserts the information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public static bool Insert(int positionTypeId, int criterionId)
        {

            //Building the SQL command
            string str = "INSERT INTO " + tableName
                + "("
                + "[PositionType]"
                + ",[Criterion]"
                + ")"

                + " VALUES "
                + "("
                      + "" + positionTypeId + ""
                + "," + "" + criterionId + ""
                + ")";

            //Running the SQL command by using the ExecuteSql method from the Dal class and return if the command succeeded
            return Dal.ExecuteSql(str);
        }


        public static bool Update(int id, int positionTypeId, int criterionId)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE " + tableName + " SET"
            + " " + "[Position] = " + "" + positionTypeId + ""
            + "," + "[Criterion] = " + "" + criterionId + ""
            + " WHERE ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה

            return Dal.ExecuteSql(str);
        }


        public static DataTable GetDataTable()
        {
            DataTable dataTable;
            DataSet dataSet = new DataSet();

            FillDataSet(dataSet, "[PositionType]");

            dataTable = dataSet.Tables[tableName];

            return dataTable;
        }


        public static void FillDataSet(DataSet dataSet, string orderBy)
        {
            Dal.FillDataSet(dataSet, tableName, orderBy);

            PositionType_Dal.FillDataSet(dataSet);


            DataRelation dataRelationPositionTypeCriterion_PositionType = new DataRelation(
                "PositionTypeCriterion_PositionType"
                , dataSet.Tables[PositionType_Dal.tableName].Columns["ID"]
                , dataSet.Tables[tableName].Columns["PositionType"]);


            dataSet.Relations.Add(dataRelationPositionTypeCriterion_PositionType);




            Criterion_Dal.FillDataSet(dataSet);


            DataRelation dataRelationPositionTypeCriterion_Criterion = new DataRelation(
                "PositionTypeCriterion_Criterion"
                , dataSet.Tables[Criterion_Dal.tableName].Columns["Id"]
                , dataSet.Tables[tableName].Columns["Criterion"]);


            dataSet.Relations.Add(dataRelationPositionTypeCriterion_Criterion);
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
