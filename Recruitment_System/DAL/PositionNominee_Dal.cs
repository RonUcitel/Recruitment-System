using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment_System.DAL
{
    class PositionNominee_Dal
    {
        public const string tableName = "Table_PositionNominee";
        /// <summary>
        /// Inserts the information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public static bool Insert(int positionId, int nomineeDBId)
        {

            //Building the SQL command
            string str = "INSERT INTO " + tableName
                + "("
                + "[Position]"
                + ",[Nominee]"
                + ")"

                + " VALUES "
                + "("
                      + "" + positionId + ""
                + "," + "" + nomineeDBId + ""
                + ")";

            //Running the SQL command by using the ExecuteSql method from the Dal class and return if the command succeeded
            return Dal.ExecuteSql(str);
        }


        public static bool Update(int id, int positionId, int nomineeDBId)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE " + tableName + " SET"
            + " " + "[Position] = " + "" + positionId + ""
            + "," + "[Nominee] = " + "" + nomineeDBId + ""
            + " WHERE ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה

            return Dal.ExecuteSql(str);
        }


        public static DataTable GetDataTable(bool isOrderedByNominee)
        {
            DataTable dataTable;
            DataSet dataSet = new DataSet();

            if (isOrderedByNominee)
            {
                FillDataSet(dataSet, "[Nominee]");
            }
            else
            {
                FillDataSet(dataSet, "[Position]");
            }


            dataTable = dataSet.Tables[tableName];

            return dataTable;
        }


        public static void FillDataSet(DataSet dataSet, string orderBy)
        {
            Dal.FillDataSet(dataSet, tableName, orderBy);

            Position_Dal.FillDataSet(dataSet);


            DataRelation dataRelationPosition_NomineePosition = new DataRelation(
                "PositionNominee_Position"
                , dataSet.Tables[Position_Dal.tableName].Columns["ID"]
                , dataSet.Tables[tableName].Columns["Position"]);


            dataSet.Relations.Add(dataRelationPosition_NomineePosition);




            Nominee_Dal.FillDataSet(dataSet);


            DataRelation dataRelationPosition_NomineeNominee = new DataRelation(
                "PositionNominee_Nominee"
                , dataSet.Tables[Nominee_Dal.tableName].Columns["Id"]
                , dataSet.Tables[tableName].Columns["Nominee"]);


            dataSet.Relations.Add(dataRelationPosition_NomineeNominee);
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
