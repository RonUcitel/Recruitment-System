using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Recruitment_System.DAL;

namespace Recruitment_System.BL
{
    public class ScoreType
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreType"/> class.
        /// </summary>
        public ScoreType()
        {
            m_Id = 0;
            m_Name = "";
            m_Position = Position.Empty;
        }
        public ScoreType(DataRow scoreType_prop)
        {
            m_Id = (int)scoreType_prop["ID"];
            m_Name = scoreType_prop["Name"].ToString();
            m_Position = new Position(scoreType_prop.GetParentRow("ScoreType_Position"));
        }

        #endregion


        #region Private containers

        private int m_Id;
        private string m_Name;
        private Position m_Position;

        #endregion


        #region Public variables
        public int Id { get => m_Id; set => m_Id = value; }
        public string Name { get => m_Name; set => m_Name = value; }
        public Position Position { get => m_Position; set => m_Position = value; }

        public string NameWithPosition { get { return m_Name + " (" + m_Position.Name + ")"; } }

        public static ScoreType Empty = new ScoreType();

        #endregion


        #region Public methods

        /// <summary>
        /// Inserts the scoreType's information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public bool Insert()
        {
            return ScoreType_Dal.Insert(m_Name, m_Position.Id);
        }

        public bool Update()
        {
            return ScoreType_Dal.Update(m_Id, m_Name, m_Position.Id);
        }


        public bool Delete()
        {
            return ScoreType_Dal.Delete(m_Id);
        }


        public override string ToString()
        {
            return m_Name;
        }


        static public bool operator ==(ScoreType right, ScoreType left)
        {
            if ((object)right == null)
            {
                return (object)left == null;
            }
            else if ((object)left == null)
            {
                return false;
            }


            return right.m_Name == left.m_Name && right.m_Id == left.m_Id && right.m_Position.Id == left.m_Position.Id;
        }


        static public bool operator !=(ScoreType right, ScoreType left)
        {
            if ((object)right == null)
            {
                return (object)left != null;
            }
            else if ((object)left == null)
            {
                return true;
            }


            return right.m_Name != left.m_Name || right.m_Id != left.m_Id || right.m_Position.Id != left.m_Position.Id;
        }

        #endregion
    }
}
