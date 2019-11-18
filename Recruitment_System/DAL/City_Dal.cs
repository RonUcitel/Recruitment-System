using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment_System.DAL
{
    class City_Dal
    {
        /// <summary>
        /// Inserts the information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public static bool Insert(string cityName)
        {

            //Building the SQL command
            string str = "INSERT INTO Table_City"
                + "("
                + "[Name]"
                + ")"

                + " VALUES "
                + "("
                      + "'" + cityName + "'"
                + ")";

            //Running the SQL command by using the ExecuteSql method from the Dal class and return if the command succeeded
            return Dal.ExecuteSql(str);
        }


        public static bool Update(int id, string cityName)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE Table_City SET"
            + " " + "[Name] = " + "'" + cityName + "'"

            + " WHERE ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה

            return Dal.ExecuteSql(str);
        }


        public static DataTable GetDataTable()
        {
            DataTable dataTable;
            DataSet dataSet = new DataSet();

            FillDataSet(dataSet);
            dataTable = dataSet.Tables["Table_City"];

            return dataTable;
        }


        public static void FillDataSet(DataSet dataSet)
        {
            if (!dataSet.Tables.Contains("Table_City"))
            {
                Dal.FillDataSet(dataSet, "Table_City", "[Name]");
            }

        }


        /// <summary>
        /// Delete the city from the DataBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {

            //מוחקת את הלקוח ממסד הנתונים
            string str = "DELETE FROM Table_City"
            + " WHERE ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה
            return Dal.ExecuteSql(str);
        }
    }
}
