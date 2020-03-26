using Recruitment_System.DAL;
using System.Collections;
using System.Data;

namespace Recruitment_System.BL
{
    public class Position
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        public Position()
        {
            m_Id = -1;
            m_Name = "";
        }
        public Position(DataRow Position_prop)
        {
            m_Id = (int)Position_prop["ID"];
            m_Name = Position_prop["Name"].ToString();

        }
        private Position(bool unused)
        {
            m_Id = -1;
            m_Name = "+";
        }

        #endregion


        #region Private containers

        private int m_Id;
        private string m_Name;

        #endregion


        #region Public variables
        public int Id { get => m_Id; set => m_Id = value; }
        public string Name { get => m_Name; set => m_Name = value; }

        public static Position Empty = new Position();
        public static Position AddingFormButton = new Position(true);

        #endregion


        #region Public methods

        /// <summary>
        /// Inserts the Position's information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public bool Insert()
        {
            PositionArr ca = new PositionArr();
            ca.Fill();

            if (Position_Dal.Update((ca[0] as Position).Id, m_Name))
            {
                return Position_Dal.Insert("+");
            }
            return false;
        }

        public bool Update()
        {
            return Position_Dal.Update(m_Id, m_Name);
        }


        public bool Delete()
        {
            return Position_Dal.Delete(m_Id);
        }


        public override string ToString()
        {
            return m_Name;
        }


        public static bool operator ==(Position left, Position right)
        {
            if ((object)right == null)
            {
                return (object)left == null;
            }
            else if ((object)left == null)
            {
                return false;
            }


            return left.Id == right.Id && left.Name == right.Name;
        }


        public static bool operator !=(Position left, Position right)
        {
            if ((object)right == null)
            {
                return (object)left != null;
            }
            else if ((object)left == null)
            {
                return true;
            }


            return left.Id != right.Id || left.Name != right.Name;
        }

        #endregion
    }
}
