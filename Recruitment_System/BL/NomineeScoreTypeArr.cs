using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using Recruitment_System.DAL;

namespace Recruitment_System.BL
{
    public class NomineeScoreTypeArr : ArrayList
    {
        public void Fill()
        {
            this.Clear();
            DataTable dataTable = NomineeScoreType_Dal.GetDataTable();


            DataRow dataRow;
            NomineeScoreType nomineeScoreType;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                nomineeScoreType = new NomineeScoreType(dataRow);

                Add(nomineeScoreType);
            }
        }

        public void FillDisabled()
        {
            this.Clear();
            DataTable dataTable = NomineeScoreType_Dal.GetDataTable();


            DataRow dataRow;
            NomineeScoreType nomineeScoreType;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                nomineeScoreType = new NomineeScoreType(dataRow);
                if (nomineeScoreType.Nominee.Disabled)
                {
                    Add(nomineeScoreType);
                }
            }
        }

        public void FillEnabled()
        {
            this.Clear();
            DataTable dataTable = NomineeScoreType_Dal.GetDataTable();


            DataRow dataRow;
            NomineeScoreType nomineeScoreType;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                nomineeScoreType = new NomineeScoreType(dataRow);
                if (!nomineeScoreType.Nominee.Disabled)
                {
                    Add(nomineeScoreType);
                }
            }
        }

        public void Fill(NomineeArrState state)
        {
            switch (state)
            {
                case NomineeArrState.ShowDisabledOnly:
                    {
                        FillDisabled();
                        break;
                    }
                case NomineeArrState.ShowEnabledOnly:
                    {
                        FillEnabled();
                        break;
                    }
                case NomineeArrState.ShowAll:
                    {
                        Fill();
                        break;
                    }
                default:
                    {
                        FillEnabled();
                        break;
                    }
            }
        }

        public bool InsertArr()
        {
            //מוסיפה את אוסף המוצרים להזמנה למסד הנתונים

            NomineeScoreType nomineeScoreType;
            for (int i = 0; i < this.Count; i++)
            {
                nomineeScoreType = (this[i] as NomineeScoreType);
                if (!nomineeScoreType.Insert())
                    return false;

            }
            return true;
        }


        public bool DeleteArr()
        {
            //מוחקת את אוסף המוצרים להזמנה מ מסד הנתונים

            NomineeScoreType nomineeScoreType;
            for (int i = 0; i < this.Count; i++)
            {
                nomineeScoreType = (this[i] as NomineeScoreType);
                if (!nomineeScoreType.Delete())
                    return false;

            }
            return true;
        }


        public NomineeScoreTypeArr Filter(Interviewer interviewer, Nominee nominee, ScoreType scoreType, int score, DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            NomineeScoreTypeArr positionnomineeArr = new NomineeScoreTypeArr();

            NomineeScoreType nomineeScoreType;
            for (int i = 0; i < this.Count; i++)
            {
                nomineeScoreType = this[i] as NomineeScoreType;
                if ((interviewer == Interviewer.Empty || interviewer == nomineeScoreType.Interviewer) &&
                    (nominee == Nominee.Empty || nominee == nomineeScoreType.Nominee) &&
                    (scoreType == ScoreType.Empty || scoreType == nomineeScoreType.ScoreType) &&
                    (score == 0 || score == nomineeScoreType.Score) &&
                    (dateTimeFrom <= nomineeScoreType.DateTime && nomineeScoreType.DateTime <= dateTimeTo))
                {
                    positionnomineeArr.Add(nomineeScoreType);
                }
            }

            return positionnomineeArr;
        }


        public NomineeScoreTypeArr Filter(Interviewer interviewer, Nominee nominee, Position position, DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            NomineeScoreTypeArr positionnomineeArr = new NomineeScoreTypeArr();

            NomineeScoreType nomineeScoreType;
            for (int i = 0; i < this.Count; i++)
            {
                nomineeScoreType = this[i] as NomineeScoreType;
                if ((interviewer == Interviewer.Empty || interviewer == nomineeScoreType.Interviewer) &&
                    (nominee == Nominee.Empty || nominee == nomineeScoreType.Nominee) &&
                    (position == Position.Empty || position == nomineeScoreType.ScoreType.Position) &&
                    (dateTimeFrom <= nomineeScoreType.DateTime && nomineeScoreType.DateTime <= dateTimeTo))
                {
                    positionnomineeArr.Add(nomineeScoreType);
                }
            }

            return positionnomineeArr;
        }


        public NomineeScoreType GetNomineeScoreTypeById(int id)
        {
            NomineeScoreType check;
            for (int i = 0; i < this.Count; i++)
            {
                check = this[i] as NomineeScoreType;
                if (check.Id == id)
                {
                    return check;
                }
            }
            return NomineeScoreType.Empty;
        }


        public bool IsContains(NomineeScoreType nomineeScoreType)
        {
            //finds out whether this NomineeScoreTypeArr contains the given NomineeScoreType.
            NomineeScoreType x;
            for (int i = 0; i < this.Count; i++)
            {
                x = (this[i] as NomineeScoreType);
                if (x.Id == nomineeScoreType.Id || nomineeScoreType.Id == 0)
                {
                    if (x.Equals(nomineeScoreType))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public bool DoesExist(Interviewer interviewer)
        {
            //return whether curPosition exists in a nominee on this NomineeArr.
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as NomineeScoreType).Interviewer == interviewer)
                {
                    return true;
                }
            }
            return false;
        }


        public bool DoesExist(Nominee nominee)
        {
            //return whether curCity exists in a nominee on this NomineeArr.
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as NomineeScoreType).Nominee == nominee)
                {
                    return true;
                }
            }
            return false;
        }


        public bool DoesExist(ScoreType scoreType)
        {
            //return whether curPosition exists in a nominee on this NomineeArr.
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as NomineeScoreType).ScoreType == scoreType)
                {
                    return true;
                }
            }
            return false;
        }


        public bool DoesExist(Position position)
        {
            //return whether curPosition exists in a nominee on this NomineeArr.
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as NomineeScoreType).ScoreType.Position == position)
                {
                    return true;
                }
            }
            return false;
        }


        public NomineeScoreType MaxNomineeScoreTypeDBId()
        {
            NomineeScoreType max = NomineeScoreType.Empty;
            for (int i = 0; i < this.Count; i++)
            {
                max = (this[i] as NomineeScoreType).Id > max.Id ? this[i] as NomineeScoreType : max;
            }
            return max;
        }


        public InterviewerArr ToInterviewerArr()
        {
            InterviewerArr interviewerArr = new InterviewerArr();

            NomineeScoreType nomineeScoreType;
            Interviewer interviewer;
            for (int i = 0; i < this.Count; i++)
            {
                nomineeScoreType = this[i] as NomineeScoreType;
                interviewer = nomineeScoreType.Interviewer;
                if (!interviewerArr.IsContains(interviewer.Id))
                {
                    interviewerArr.Add(interviewer);
                }
            }

            return interviewerArr;
        }


        public NomineeArr ToNomineeArr()
        {
            NomineeArr nomineeArr = new NomineeArr();

            NomineeScoreType nomineeScoreType;
            Nominee nominee;
            for (int i = 0; i < this.Count; i++)
            {
                nomineeScoreType = this[i] as NomineeScoreType;
                nominee = nomineeScoreType.Nominee;
                if (!nomineeArr.IsContains(nominee.DBId))
                {
                    nomineeArr.Add(nominee);
                }
            }

            return nomineeArr;
        }


        public ScoreTypeArr ToScoreTypeArr()
        {
            ScoreTypeArr scoreTypeArr = new ScoreTypeArr();

            NomineeScoreType nomineeScoreType;
            ScoreType scoreType;
            for (int i = 0; i < this.Count; i++)
            {
                nomineeScoreType = this[i] as NomineeScoreType;
                scoreType = nomineeScoreType.ScoreType;
                if (!scoreTypeArr.IsContains(scoreType.Id))
                {
                    scoreTypeArr.Add(scoreType);
                }
            }

            return scoreTypeArr;
        }


        public void SortByPositions()
        {
            PositionComparer mc = new PositionComparer();
            Sort(mc);
        }


        public bool DoesContainData(Interviewer interviewer, Nominee nominee, ScoreType scoreType)
        {
            NomineeScoreType nomineeScoreType;

            for (int i = 0; i < this.Count; i++)
            {
                nomineeScoreType = this[i] as NomineeScoreType;
                if (nomineeScoreType.Interviewer.Id == interviewer.Id && nomineeScoreType.Nominee.DBId == nominee.DBId && nomineeScoreType.ScoreType.Id == scoreType.Id)
                {
                    return true;
                }
            }

            return false;
        }
    }

    class PositionComparer : IComparer
    {

        // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        int IComparer.Compare(object x, object y)
        {
            NomineeScoreType n1 = (NomineeScoreType)x;
            NomineeScoreType n2 = (NomineeScoreType)y;
            if (n1.ScoreType.Position.Id > n2.ScoreType.Position.Id)
                return 1;
            if (n1.ScoreType.Position.Id < n2.ScoreType.Position.Id)
                return -1;
            else
                return 0;
        }
    }
}
