using Recruitment_System.DAL;
using System;
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
            m_Id = 0;
            m_Name = "";
            m_PositionType = PositionType.Empty;
            m_CreationDate = DateTime.Now;
            m_DeadLine = DateTime.MaxValue;
        }
        public Position(DataRow Position_prop)
        {
            m_Id = (int)Position_prop["ID"];
            Name = Position_prop["Name"].ToString();
            m_PositionType = new PositionType(Position_prop.GetParentRow("PositionPositionType"));
            m_CreationDate = (DateTime)Position_prop["CreationDate"];
            m_DeadLine = (DateTime)Position_prop["DeadLine"];
        }

        #endregion


        #region Private containers

        private int m_Id;
        private string m_Name;
        private PositionType m_PositionType;
        private DateTime m_CreationDate;
        private DateTime m_DeadLine;

        #endregion


        #region Public variables
        public int Id { get => m_Id; set => m_Id = value; }
        public string Name { get => m_Name; set => m_Name = value; }
        public PositionType PositionType { get => m_PositionType; set => m_PositionType = value; }
        public DateTime CreationDate { get => m_CreationDate; set => m_CreationDate = value; }
        public DateTime DeadLine { get => m_DeadLine; set => m_DeadLine = value; }

        public static readonly Position Empty = new Position();

        #endregion


        #region Public methods

        /// <summary>
        /// Inserts the Position's information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public bool Insert()
        {
            return Position_Dal.Insert(m_Name, m_PositionType.Id, m_CreationDate, m_DeadLine);
        }

        public bool Update()
        {
            return Position_Dal.Update(m_Id, m_Name, m_PositionType.Id, m_CreationDate, m_DeadLine);
        }


        public bool Delete()
        {
            return PositionType_Dal.Delete(m_Id);
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


            return left.m_Id == right.m_Id && left.m_Name == right.m_Name && left.m_PositionType.Id == right.m_PositionType.Id;
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


            return left.m_Id != right.m_Id || left.m_Name != right.m_Name || left.m_PositionType.Id != right.m_PositionType.Id;
        }

        #endregion
    }
}
