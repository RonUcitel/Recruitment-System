using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Recruitment_System.DAL;

namespace Recruitment_System.BL
{
    public class Criterion
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Criterion"/> class.
        /// </summary>
        public Criterion()
        {
            m_Id = 0;
            m_Name = "";
        }
        public Criterion(DataRow criterion_prop)
        {
            m_Id = (int)criterion_prop["ID"];
            m_Name = criterion_prop["Name"].ToString();
        }

        #endregion


        #region Private containers

        private int m_Id;
        private string m_Name;

        #endregion


        #region Public variables
        public int Id { get => m_Id; set => m_Id = value; }
        public string Name { get => m_Name; set => m_Name = value; }


        public static readonly Criterion Empty = new Criterion();

        #endregion


        #region Public methods

        /// <summary>
        /// Inserts the criterion's information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public bool Insert()
        {
            return Criterion_Dal.Insert(m_Name);
        }

        public bool Update()
        {
            return Criterion_Dal.Update(m_Id, m_Name);
        }


        public bool Delete()
        {
            return Criterion_Dal.Delete(m_Id);
        }


        public override string ToString()
        {
            return m_Name;
        }


        static public bool operator ==(Criterion right, Criterion left)
        {
            if ((object)right == null)
            {
                return (object)left == null;
            }
            else if ((object)left == null)
            {
                return false;
            }


            return right.m_Name == left.m_Name && right.m_Id == left.m_Id;
        }


        static public bool operator !=(Criterion right, Criterion left)
        {
            if ((object)right == null)
            {
                return (object)left != null;
            }
            else if ((object)left == null)
            {
                return true;
            }


            return right.m_Name != left.m_Name || right.m_Id != left.m_Id;
        }

        #endregion
    }
}
