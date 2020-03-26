using Recruitment_System.DAL;
using System.Collections;
using System.Data;
using System.Reflection;
using System.IO;
using System;

namespace Recruitment_System.BL
{
    public class PositionNominee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position_Nominee"/> class.
        /// </summary>
        public PositionNominee()
        {
            m_DBId = 0;
            Position = Position.Empty;
            Nominee = Nominee.Empty;
        }
        public PositionNominee(DataRow PositionNominee_prop)
        {
            m_DBId = (int)PositionNominee_prop["ID"];
            Position = new Position(PositionNominee_prop.GetParentRow("PositionNominee_Position"));
            Nominee = new Nominee(PositionNominee_prop.GetParentRow("PositionNominee_Nominee"));
        }


        #region Private containers

        private int m_DBId;

        private Position m_Position;

        private Nominee m_Nominee;
        #endregion


        #region Public Properties
        public int DBId { get => m_DBId; set => m_DBId = value; }

        public Position Position { get => m_Position; set => m_Position = value; }

        public Nominee Nominee { get => m_Nominee; set => m_Nominee = value; }

        public static PositionNominee Empty = new PositionNominee();
        #endregion


        #region Public methods

        /// <summary>
        /// Inserts the nominee's information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public bool Insert()
        {
            /*if (Position_Nominee_Dal.Insert(m_Position.Id, m_Nominee.DBId))
            {
                NomineeArr nomineeArr = new NomineeArr();
                nomineeArr.Fill();

                return true;
            }*/

            return false;
        }

        public bool Update()
        {
            /*if (Nominee_Dal.Update(m_DBId, m_FirstName, m_LastName, m_Id, m_Email, m_BirthYear, m_CellAreaCode, m_CellPhoneNumber, m_City.Id, m_PositionType.Id, m_Match, m_Professionalism, m_GeneralAssessment))
            {
                NomineeArr nomineeArr = new NomineeArr();
                nomineeArr.Fill();

                LogEntry logEntry = new LogEntry(DateTime.Now, "המועמד " + m_FirstName + " " + m_LastName + " עודכן בהצלחה", nomineeArr.MaxNomineeDBId());

                logEntry.Insert();
                return true;
            }*/
            return false;
        }


        public bool Delete()
        {
            return false;/*Nominee_Dal.Delete(m_DBId);*/
        }


        public override bool Equals(object obj)
        {
            //returns if the Nominee's properties are identicle to the object's ( if it is a Nominee object) properties. 
            if (obj is Nominee)
            {
                bool output = true;
                foreach (PropertyInfo item in typeof(Nominee).GetProperties())
                {
                    if (true)
                    {
                        output &= item.GetValue(this) == item.GetValue(obj);
                    }

                }
                return output;
            }

            return base.Equals(obj);
        }

        public void Clear()
        {
            //sets each property of the nominee to it's "empty" state.
            foreach (PropertyInfo item in this.GetType().GetProperties())
            {
                if (item.PropertyType == typeof(string))
                {
                    try
                    {
                        item.SetValue(this, "");
                    }
                    catch
                    {

                    }

                }
                else if (item.PropertyType == typeof(int))
                {
                    if (item.Name == "Match" || item.Name == "Professionalism" || item.Name == "GeneralAssessment")
                    {
                        try
                        {
                            item.SetValue(this, 1);
                        }
                        catch
                        {

                        }

                    }
                    else
                    {
                        try
                        {
                            item.SetValue(this, 0);
                        }
                        catch
                        {

                        }
                    }
                }
                else if (item.PropertyType == typeof(City))
                {
                    try
                    {
                        item.SetValue(this, City.Empty);
                    }
                    catch
                    {

                    }

                }
                else if (item.PropertyType == typeof(Position))
                {
                    try
                    {
                        item.SetValue(this, Position.Empty);
                    }
                    catch
                    {

                    }

                }
            }
        }

        public bool isEmpty()
        {
            //checks if the nominee's properties matches the Empty Nominee's properties.
            //AKA it finds out if the nominee is an empty nominee.
            bool output = true;
            foreach (PropertyInfo item in typeof(Nominee).GetProperties())
            {
                if (true)
                {
                    output &= item.GetValue(this) == item.GetValue(Empty);
                }

            }
            return output;
        }

        public static bool operator ==(PositionNominee left, PositionNominee right)
        {
            return left.Nominee == right.Nominee && left.Position == left.Position;
        }


        public static bool operator !=(PositionNominee left, PositionNominee right)
        {
            return left.Nominee != right.Nominee || left.Position != left.Position;
        }
        #endregion
    }
}
