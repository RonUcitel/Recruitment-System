using Recruitment_System.DAL;
using System.Collections;
using System.Data;
using System.Reflection;
using System.IO;
using System;

namespace Recruitment_System.BL
{
    public class PositionTypeCriterion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position_Nominee"/> class.
        /// </summary>
        public PositionTypeCriterion()
        {
            m_Id = 0;
            m_PositionType = PositionType.Empty;
            m_Criterion = Criterion.Empty;
        }
        public PositionTypeCriterion(DataRow PositionTypeCriterion_prop)
        {
            m_Id = (int)PositionTypeCriterion_prop["ID"];
            PositionType = new PositionType(PositionTypeCriterion_prop.GetParentRow("PositionTypeCriterion_PositionType"));
            Criterion = new Criterion(PositionTypeCriterion_prop.GetParentRow("PositionTypeCriterion_Criterion"));
        }


        #region Private containers

        private int m_Id;

        private PositionType m_PositionType;

        private Criterion m_Criterion;
        #endregion


        #region Public Properties
        public int Id { get => m_Id; set => m_Id = value; }

        public PositionType PositionType { get => m_PositionType; set => m_PositionType = value; }

        public Criterion Criterion { get => m_Criterion; set => m_Criterion = value; }

        public static PositionTypeCriterion Empty = new PositionTypeCriterion();
        #endregion


        #region Public methods

        /// <summary>
        /// Inserts the nominee's information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public bool Insert()
        {
            InterviewArr interviewArr = new InterviewArr();
            interviewArr.Fill();
            interviewArr = interviewArr.Filter(m_PositionType);

            InterviewCriterionArr interviewCriterionArr = new InterviewCriterionArr();

            InterviewCriterion interviewCriterion;

            for (int i = 0; i < interviewArr.Count; i++)
            {
                interviewCriterion = new InterviewCriterion();
                interviewCriterion.Interview = interviewArr[i] as Interview;
                interviewCriterion.Criterion = m_Criterion;
                interviewCriterion.Score = 0;
                interviewCriterion.DateTime = DateTime.Now;
                interviewCriterionArr.Add(interviewCriterion);
            }
            if (interviewCriterionArr.InsertArr())
            {
                return PositionTypeCriterion_Dal.Insert(m_PositionType.Id, m_Criterion.Id);
            }
            return false;
        }


        public bool Delete()
        {
            InterviewCriterionArr interviewCriterionArr = new InterviewCriterionArr();
            interviewCriterionArr.Fill();
            interviewCriterionArr = interviewCriterionArr.Filter(m_PositionType, m_Criterion);

            if (interviewCriterionArr.DeleteArr())
            {
                return PositionTypeCriterion_Dal.Delete(m_Id);
            }
            return false;
        }


        public override bool Equals(object obj)
        {
            //returns if the Nominee's properties are identicle to the object's ( if it is a Nominee object) properties. 
            if (obj is PositionTypeCriterion)
            {
                PositionTypeCriterion x = obj as PositionTypeCriterion;

                return (this.m_Id == x.m_Id &&
                           this.m_Criterion == x.m_Criterion &&
                           this.m_PositionType == x.m_PositionType);
            }

            return base.Equals(obj);
        }

        public bool isEmpty()
        {
            //checks if the nominee's properties matches the Empty Nominee's properties.
            //AKA it finds out if the nominee is an empty nominee.
            bool output = true;
            foreach (PropertyInfo item in typeof(PositionTypeCriterion).GetProperties())
            {
                if (true)
                {
                    output &= item.GetValue(this) == item.GetValue(Empty);
                }

            }
            return output;
        }

        public static bool operator ==(PositionTypeCriterion left, PositionTypeCriterion right)
        {
            return left.m_Id == right.m_Id && left.Criterion == right.Criterion && left.m_PositionType == right.m_PositionType;
        }


        public static bool operator !=(PositionTypeCriterion left, PositionTypeCriterion right)
        {
            return left.m_Id != right.m_Id || left.Criterion != right.Criterion || left.m_PositionType != right.m_PositionType;
        }
        #endregion
    }
}
