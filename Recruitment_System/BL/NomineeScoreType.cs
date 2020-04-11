using Recruitment_System.DAL;
using System.Collections;
using System.Data;
using System.Reflection;
using System.IO;
using System;

namespace Recruitment_System.BL
{
    public class NomineeScoreType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position_Nominee"/> class.
        /// </summary>
        public NomineeScoreType()
        {
            m_Id = 0;

            m_Interviewer = Interviewer.Empty;

            m_Nominee = Nominee.Empty;

            m_Position = Position.Empty;

            m_ScoreType = ScoreType.Empty;

            m_Score = 0;

            m_DateTime = DateTime.MinValue;
        }
        public NomineeScoreType(DataRow NomineeScoreType_prop)
        {
            m_Id = (int)NomineeScoreType_prop["ID"];

            m_Interviewer = new Interviewer(NomineeScoreType_prop.GetParentRow("NomineeScoreType_Interviewer"));

            m_Nominee = new Nominee(NomineeScoreType_prop.GetParentRow("NomineeScoretype_Nominee"));

            m_Position = new Position(NomineeScoreType_prop.GetParentRow("NomineeScoretype_Position"));

            m_ScoreType = new ScoreType(NomineeScoreType_prop.GetParentRow("NomineeScoretype_ScoreType"));

            m_Score = (int)NomineeScoreType_prop["ScoreType"];

            m_DateTime = (DateTime)NomineeScoreType_prop["DateTime"];
        }


        #region Private containers

        private int m_Id;

        private Interviewer m_Interviewer;

        private Nominee m_Nominee;

        private Position m_Position;

        private ScoreType m_ScoreType;

        private int m_Score;

        private DateTime m_DateTime;
        #endregion


        #region Public Properties

        public int Id { get => m_Id; set => m_Id = value; }

        public Interviewer Interviewer { get => m_Interviewer; set => m_Interviewer = value; }

        public Nominee Nominee { get => m_Nominee; set => m_Nominee = value; }

        public ScoreType ScoreType { get => m_ScoreType; set => m_ScoreType = value; }

        public int Score { get => m_Score; set => m_Score = value; }

        public DateTime DateTime { get => m_DateTime; set => m_DateTime = value; }
        public Position Position { get => m_Position; set => m_Position = value; }

        public static NomineeScoreType Empty = new NomineeScoreType();
        #endregion


        #region Public methods

        /// <summary>
        /// Inserts the nominee's information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public bool Insert()
        {
            return NomineeScoreType_Dal.Insert(m_Interviewer.DBId, m_Nominee.DBId, m_ScoreType.Id, m_Score, m_DateTime);
        }

        public bool Update()
        {
            return NomineeScoreType_Dal.Update(m_Id, m_Interviewer.DBId, m_Nominee.DBId, m_ScoreType.Id, m_Score, m_DateTime);
        }


        public bool Delete()
        {
            return NomineeScoreType_Dal.Delete(m_Id);
        }


        public override bool Equals(object obj)
        {
            if (obj is NomineeScoreType)
            {
                NomineeScoreType x = obj as NomineeScoreType;

                return (this.m_Id == x.m_Id &&
                        this.m_Interviewer == x.m_Interviewer &&
                        this.m_Nominee == x.m_Nominee &&
                        this.m_Position == x.m_Position &&
                        this.m_ScoreType == x.m_ScoreType &&
                        this.m_Score == x.m_Score &&
                        this.m_DateTime == x.m_DateTime);
            }

            return base.Equals(obj);
        }

        public static bool operator ==(NomineeScoreType left, NomineeScoreType right)
        {
            return left.Id == right.Id &&
                    left.m_Interviewer.DBId == right.m_Interviewer.DBId &&
                    left.m_Nominee.DBId == right.m_Nominee.DBId &&
                    left.m_Position.Id == right.m_Position.Id &&
                    left.m_ScoreType.Id == right.m_ScoreType.Id &&
                    left.m_Score == right.m_Score &&
                    left.m_DateTime == right.m_DateTime;
        }


        public static bool operator !=(NomineeScoreType left, NomineeScoreType right)
        {
            return left.Id == right.Id ||
                    left.m_Interviewer.DBId != right.m_Interviewer.DBId ||
                    left.m_Nominee.DBId != right.m_Nominee.DBId ||
                    left.m_Position.Id != right.m_Position.Id ||
                    left.m_ScoreType.Id != right.m_ScoreType.Id ||
                    left.m_Score != right.m_Score ||
                    left.m_DateTime != right.m_DateTime;
        }
        #endregion
    }
}
