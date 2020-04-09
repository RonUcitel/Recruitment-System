using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recruitment_System.DAL;

namespace Recruitment_System.BL
{
    public class Credentials

    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Credentials"/> class.
        /// </summary>
        public Credentials()
        {
            m_Id = 0;
            m_UserName = "";
            m_Password = "";
        }
        public Credentials(DataRow credentials_prop)
        {
            m_Id = (int)credentials_prop["ID"];
            m_UserName = credentials_prop["UserName"].ToString();
            m_Password = credentials_prop["Password"].ToString();

        }

        #endregion


        #region Private containers

        private int m_Id;
        private string m_UserName;
        private string m_Password;

        #endregion


        #region Public variables
        public int Id { get => m_Id; set => m_Id = value; }
        public string UserName { get => m_UserName; set => m_UserName = value; }
        public string Password { get => m_Password; set => m_Password = value; }

        public static Credentials Empty = new Credentials();

        #endregion


        #region Public methods

        /// <summary>
        /// Inserts the credentials's information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public bool Insert()
        {
            return Credentials_Dal.Insert(m_UserName, m_Password);
        }

        public bool Update()
        {
            return Credentials_Dal.Update(m_Id, m_UserName, m_Password);
        }


        public bool Delete()
        {
            return Credentials_Dal.Delete(m_Id);
        }


        static public bool operator ==(Credentials right, Credentials left)
        {
            if ((object)right == null)
            {
                return (object)left == null;
            }
            else if ((object)left == null)
            {
                return false;
            }


            return right.UserName == left.UserName && right.Password == left.Password;
        }


        static public bool operator !=(Credentials right, Credentials left)
        {
            if ((object)right == null)
            {
                return (object)left != null;
            }
            else if ((object)left == null)
            {
                return true;
            }


            return right.UserName != left.UserName && right.Password != left.Password;
        }

        #endregion
    }
}
