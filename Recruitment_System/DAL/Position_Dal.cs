using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment_System.DAL
{
    class Position_Dal
    {
        public const string tableName = "Table_Position";

        /// <summary>
        /// Inserts the information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public static bool Insert(string name, int positionType, DateTime creationDate, DateTime deadlineDate)
        {

            //Building the SQL command
            string str = "INSERT INTO " + tableName
                + "("
                + "[Name]"
                + ",[PositionType]"
                + ",[CreationDate]"
                + ",[DeadLine]"
                + ")"

                + " VALUES "
                + "("
                      + "N'" + name + "'"
                + "," + "" + positionType + ""
                + "," + "'" + creationDate.ToString("yyyy-MM-dd") + "'"
                + "," + "'" + deadlineDate.ToString("yyyy-MM-dd") + "'"
                + ")";

            //Running the SQL command by using the ExecuteSql method from the Dal class and return if the command succeeded
            return Dal.ExecuteSql(str);
        }


        public static bool Update(int id, string name, int positionType, DateTime creationDate, DateTime deadlineDate)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE " + tableName + " SET"
            + " " + "[Name] = " + "N'" + name + "'"
            + "," + "[PositionType] = " + "" + positionType + ""
            + "," + "[CreationDate] = " + "'" + creationDate.ToString("yyyy-MM-dd") + "'"
            + "," + "[DeadLine] = " + "'" + deadlineDate.ToString("yyyy-MM-dd") + "'"

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
            Dal.FillDataSet(dataSet, tableName, "[Name]");

            PositionType_Dal.FillDataSet(dataSet);


            DataRelation dataRelationPositionPositionType = new DataRelation(
                "PositionPositionType"
                , dataSet.Tables[PositionType_Dal.tableName].Columns["Id"]
                , dataSet.Tables[tableName].Columns["PositionType"]);


            dataSet.Relations.Add(dataRelationPositionPositionType);
        }


        /// <summary>
        /// Delete the Position from the DataBase
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
