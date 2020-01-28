using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Recruitment_System.DAL
{

    class Dal
    {
        public static bool ExecuteSql(string sql)
        {
            bool flag = false;

            //מקשר
            SqlConnection connection = new SqlConnection();
            //הצבת מחרוזת הקישור במקשר - שימוש בפעולת עזר למציאת מחרוזת זאת
            connection.ConnectionString = GetConnectionString();


            //ההוראה 
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = sql;

            //בגלל שיש גישה לקבצים חיצוניים וכן בגלל פתיחת קשר לקובץ חיצוני - "עוטפים" במנגנון טיפול בשגיאות"
            try
            {
                //פתיחת הקשר
                connection.Open();

                //הפעלת הפקודה
                command.ExecuteNonQuery();
                flag = true;

                //סגירת הקשר
                connection.Close();
            }
            catch (Exception e)
            {
                //משמש רק לצרכי בקרה במקרה של תקלה - חשוב להשאיר כאן נקודת עצירה
                e.ToString();
                flag = false;
            }

            return flag;
        }

        public static void FillDataSet(DataSet dataSet, string tableName, string orderBy)
        {
            //מקשר
            SqlConnection connection = new SqlConnection();
            //הצבת מחרוזת הקישור במקשר
            connection.ConnectionString = GetConnectionString();


            //מבצע פעולה
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            if (orderBy != "")
                command.CommandText = "SELECT * FROM " + tableName + " ORDER BY " + orderBy;
            else
                command.CommandText = "SELECT * FROM " + tableName;

            //מתאם
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dataSet, tableName);
        }


        private static string GetConnectionString()
        {
            //בניית מחרוזת הקישור
            SqlConnectionStringBuilder cString = new SqlConnectionStringBuilder();
            cString.DataSource = @"(localdb)\.";
            cString.AttachDBFilename = /*Directory.GetParent(Environment.CurrentDirectory).Parent.FullName*/
                Properties.Resources.Server_Path + @"\Recruiment_System.mdf";


            cString.IntegratedSecurity = true;

            return cString.ToString();
        }
    }
}
