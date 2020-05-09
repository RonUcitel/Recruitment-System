using Recruitment_System.DAL;
using System.Collections;
using System.Data;
using System.Reflection;
using System.IO;
using System;
using System.Windows.Forms;

namespace Recruitment_System.BL
{
    public class InterviewCriterion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InterviewCriterion"/> class.
        /// </summary>
        public InterviewCriterion()
        {
            m_Id = 0;

            m_Interview = Interview.Empty;

            m_Criterion = Criterion.Empty;

            m_Score = 0;

            m_DateTime = DateTimePicker.MinimumDateTime;
        }
        public InterviewCriterion(DataRow InterviewCriterion_prop)
        {
            m_Id = (int)InterviewCriterion_prop["ID"];

            m_Interview = new Interview(InterviewCriterion_prop.GetParentRow("InterviewCriterion_Interview"));


            m_Criterion = new Criterion(InterviewCriterion_prop.GetParentRow("InterviewCriterion_Criterion"));

            m_Score = (byte)InterviewCriterion_prop["Score"];

            m_DateTime = (DateTime)InterviewCriterion_prop["Date"];
        }


        #region Private containers

        private int m_Id;

        private Interview m_Interview;

        private Criterion m_Criterion;

        private int m_Score;

        private DateTime m_DateTime;
        #endregion


        #region Public Properties

        public int Id { get => m_Id; set => m_Id = value; }
        public Interview Interview { get => m_Interview; set => m_Interview = value; }
        public Criterion Criterion { get => m_Criterion; set => m_Criterion = value; }
        public int Score { get => m_Score; set => m_Score = value; }
        public DateTime DateTime { get => m_DateTime; set => m_DateTime = value; }


        public static InterviewCriterion Empty = new InterviewCriterion();
        #endregion


        #region Public methods

        public bool Insert()
        {
            return InterviewCriterion_Dal.Insert(m_Interview.Id, m_Criterion.Id, m_Score, m_DateTime);
        }

        public bool Update()
        {
            return InterviewCriterion_Dal.Update(m_Id, m_Interview.Id, m_Criterion.Id, m_Score, m_DateTime);
        }


        public bool Delete()
        {
            return InterviewCriterion_Dal.Delete(m_Id);
        }


        public override bool Equals(object obj)
        {
            if (obj is InterviewCriterion)
            {
                InterviewCriterion x = obj as InterviewCriterion;

                return m_Id == x.m_Id &&
                        m_Interview == x.m_Interview &&
                        m_Criterion == x.m_Criterion &&
                        m_Score == x.m_Score &&
                        m_DateTime == x.m_DateTime;
            }

            return base.Equals(obj);
        }

        public static bool operator ==(InterviewCriterion left, InterviewCriterion right)
        {
            return left.m_Id == right.m_Id &&
                    left.m_Interview.Id == right.m_Interview.Id &&
                    left.m_Criterion.Id == right.m_Criterion.Id &&
                    left.m_Score == right.m_Score &&
                    left.m_DateTime == right.m_DateTime;
        }


        public static bool operator !=(InterviewCriterion left, InterviewCriterion right)
        {
            return left.m_Id != right.m_Id ||
                    left.m_Interview.Id != right.m_Interview.Id ||
                    left.m_Criterion.Id != right.m_Criterion.Id ||
                    left.m_Score != right.m_Score ||
                    left.m_DateTime != right.m_DateTime;
        }
        #endregion
    }
}
