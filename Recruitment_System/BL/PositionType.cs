using Recruitment_System.DAL;
using System.Collections;
using System.Data;

namespace Recruitment_System.BL
{
    public class PositionType
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="PositionType"/> class.
        /// </summary>
        public PositionType()
        {
            m_Id = 0;
            m_Name = "";
        }
        public PositionType(DataRow PositionType_prop)
        {
            m_Id = (int)PositionType_prop["ID"];
            m_Name = PositionType_prop["Name"].ToString();
        }

        #endregion


        #region Private containers

        private int m_Id;
        private string m_Name;

        #endregion


        #region Public variables
        public int Id { get => m_Id; set => m_Id = value; }
        public string Name { get => m_Name; set => m_Name = value; }

        public static readonly PositionType Empty = new PositionType();

        #endregion


        #region Public methods

        /// <summary>
        /// Inserts the Position's information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public bool Insert()
        {
            return PositionType_Dal.Insert(m_Name);
        }

        public bool Update()
        {
            return PositionType_Dal.Update(m_Id, m_Name);
        }


        public bool Delete()
        {
            PositionTypeCriterionArr positionTypeCriterionArr = new PositionTypeCriterionArr();
            positionTypeCriterionArr.Fill();
            positionTypeCriterionArr = positionTypeCriterionArr.Filter(this, Criterion.Empty);

            if (positionTypeCriterionArr.DeleteArr())
            {
                return PositionType_Dal.Delete(m_Id);
            }
            return false;
        }


        public override string ToString()
        {
            return m_Name;
        }


        public static bool operator ==(PositionType left, PositionType right)
        {
            if ((object)right == null)
            {
                return (object)left == null;
            }
            else if ((object)left == null)
            {
                return false;
            }


            return left.m_Id == right.m_Id && left.m_Name == right.m_Name;
        }


        public static bool operator !=(PositionType left, PositionType right)
        {
            if ((object)right == null)
            {
                return (object)left != null;
            }
            else if ((object)left == null)
            {
                return true;
            }


            return left.m_Id != right.m_Id || left.m_Name != right.m_Name;
        }

        #endregion
    }
}
