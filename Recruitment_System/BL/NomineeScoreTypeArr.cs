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
                if ((interviewer == Interviewer.Empty || interviewer.DBId == nomineeScoreType.Interviewer.DBId) &&
                    (nominee == Nominee.Empty || nominee.DBId == nomineeScoreType.Nominee.DBId) &&
                    (position == Position.Empty || position.Id == nomineeScoreType.ScoreType.Position.Id) &&
                    (dateTimeFrom <= nomineeScoreType.DateTime && nomineeScoreType.DateTime <= dateTimeTo))
                {
                    positionnomineeArr.Add(nomineeScoreType);
                }
            }

            return positionnomineeArr;
        }


        public NomineeScoreTypeArr Filter(Interviewer interviewer, Nominee nominee)
        {
            NomineeScoreTypeArr positionnomineeArr = new NomineeScoreTypeArr();

            NomineeScoreType nomineeScoreType;
            for (int i = 0; i < this.Count; i++)
            {
                nomineeScoreType = this[i] as NomineeScoreType;
                if ((interviewer == Interviewer.Empty || interviewer.DBId == nomineeScoreType.Interviewer.DBId) &&
                    (nominee == Nominee.Empty || nominee.DBId == nomineeScoreType.Nominee.DBId))
                {
                    positionnomineeArr.Add(nomineeScoreType);
                }
            }

            return positionnomineeArr;
        }

        public NomineeScoreTypeArr FilterMonth(ScoreType scoreType, DateTime monthYear)
        {
            NomineeScoreTypeArr positionnomineeArr = new NomineeScoreTypeArr();

            NomineeScoreType nomineeScoreType;
            for (int i = 0; i < this.Count; i++)
            {
                nomineeScoreType = this[i] as NomineeScoreType;
                if ((scoreType == ScoreType.Empty || scoreType.Id == nomineeScoreType.ScoreType.Id) &&
                    (monthYear.Month == nomineeScoreType.DateTime.Month) &&
                    (monthYear.Year == nomineeScoreType.DateTime.Year))
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
                if (!interviewerArr.IsContains(interviewer.DBId))
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
            PositionComparer pc = new PositionComparer();
            Sort(pc);
        }


        public void SortByDateTime()
        {
            DateTimeComparer dc = new DateTimeComparer();
            Sort(dc);
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

        public SortedDictionary<string, string> GetSortedDictionary()
        {
            SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();
            string y = "";
            InterviewerArr interviewerArr = this.ToInterviewerArr();
            NomineeArr nomineeArr;

            foreach (Interviewer curInterviewer in interviewerArr)
            {
                nomineeArr = this.Filter(curInterviewer, Nominee.Empty).ToNomineeArr();

                y += (nomineeArr[0] as Nominee).ToString();

                for (int i = 1; i < nomineeArr.Count; i++)
                {
                    y += "\n" + (nomineeArr[i] as Nominee).ToString();
                }

                dictionary.Add(curInterviewer.ToString(), y);
                y = "";
            }
            return dictionary;
        }

        public SortedDictionary<string, float> GetSortedDictionaryScore(ScoreType scoreType, DateTime from, DateTime to)
        {

            // מחזירה משתנה מסוג מילון ממוין עם ערכים רלוונטיים לדוח
            SortedDictionary<string, float> dictionary = new SortedDictionary<string, float>();

            NomineeScoreTypeArr nomineeScoreTypeArr;
            int sum = 0;
            int count = 0;
            int x = 0;
            string key = "";
            for (DateTime d = from; d <= to; d = d.AddMonths(1))
            {
                nomineeScoreTypeArr = this.FilterMonth(scoreType, d);

                for (int i = 0; i < nomineeScoreTypeArr.Count; i++)
                {
                    x = (nomineeScoreTypeArr[i] as NomineeScoreType).Score;
                    if (x > 0)
                    {
                        sum += x;
                        count++;
                    }
                }

                key += d.Month;
                key += "/" + d.Year;

                dictionary.Add(key, sum / (float)count);


                sum = 0;
                count = 0;
                x = 0;
                key = "";
            }
            return dictionary;
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

    class DateTimeComparer : IComparer
    {

        // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        int IComparer.Compare(object x, object y)
        {
            NomineeScoreType n1 = (NomineeScoreType)x;
            NomineeScoreType n2 = (NomineeScoreType)y;
            if (n1.DateTime > n2.DateTime)
                return 1;
            if (n1.DateTime < n2.DateTime)
                return -1;
            else
                return 0;
        }
    }
}
