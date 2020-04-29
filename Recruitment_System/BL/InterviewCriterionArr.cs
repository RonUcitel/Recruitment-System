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
    public class InterviewCriterionArr : ArrayList
    {
        public void Fill()
        {
            this.Clear();
            DataTable dataTable = InterviewCriterion_Dal.GetDataTable();


            DataRow dataRow;
            InterviewCriterion interviewCriterion;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                interviewCriterion = new InterviewCriterion(dataRow);

                Add(interviewCriterion);
            }
        }

        public void FillDisabled()
        {
            this.Clear();
            DataTable dataTable = InterviewCriterion_Dal.GetDataTable();


            DataRow dataRow;
            InterviewCriterion interviewCriterion;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                interviewCriterion = new InterviewCriterion(dataRow);
                if (interviewCriterion.Interview.Nominee.Disabled)
                {
                    Add(interviewCriterion);
                }
            }
        }

        public void FillEnabled()
        {
            this.Clear();
            DataTable dataTable = InterviewCriterion_Dal.GetDataTable();


            DataRow dataRow;
            InterviewCriterion interviewCriterion;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                interviewCriterion = new InterviewCriterion(dataRow);
                if (!interviewCriterion.Interview.Nominee.Disabled)
                {
                    Add(interviewCriterion);
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

            InterviewCriterion interviewCriterion;
            for (int i = 0; i < this.Count; i++)
            {
                interviewCriterion = (this[i] as InterviewCriterion);
                if (!interviewCriterion.Insert())
                    return false;

            }
            return true;
        }


        public bool DeleteArr()
        {
            //מוחקת את אוסף המוצרים להזמנה מ מסד הנתונים

            InterviewCriterion interviewCriterion;
            for (int i = 0; i < this.Count; i++)
            {
                interviewCriterion = (this[i] as InterviewCriterion);
                if (!interviewCriterion.Delete())
                    return false;

            }
            return true;
        }


        public InterviewCriterionArr Filter(Interview interview)
        {
            InterviewCriterionArr interviewCriterionArr = new InterviewCriterionArr();

            InterviewCriterion interviewCriterion;
            for (int i = 0; i < this.Count; i++)
            {
                interviewCriterion = this[i] as InterviewCriterion;
                if (interview.Id == interviewCriterion.Interview.Id)
                {
                    interviewCriterionArr.Add(interviewCriterion);
                }
            }

            return interviewCriterionArr;
        }


        public InterviewCriterionArr Filter(Criterion criterion)
        {
            InterviewCriterionArr interviewCriterionArr = new InterviewCriterionArr();

            InterviewCriterion interviewCriterion;
            for (int i = 0; i < this.Count; i++)
            {
                interviewCriterion = this[i] as InterviewCriterion;
                if (criterion.Id == interviewCriterion.Criterion.Id)
                {
                    interviewCriterionArr.Add(interviewCriterion);
                }
            }

            return interviewCriterionArr;
        }

        public InterviewCriterionArr Filter(Position position)
        {
            InterviewCriterionArr interviewCriterionArr = new InterviewCriterionArr();

            InterviewCriterion interviewCriterion;
            for (int i = 0; i < this.Count; i++)
            {
                interviewCriterion = this[i] as InterviewCriterion;
                if (position.Id == interviewCriterion.Interview.Position.Id)
                {
                    interviewCriterionArr.Add(interviewCriterion);
                }
            }

            return interviewCriterionArr;
        }

        public InterviewCriterionArr Filter(Interviewer interviewer, Nominee nominee, Criterion criterion, int score, DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            InterviewCriterionArr interviewCriterionArr = new InterviewCriterionArr();

            InterviewCriterion interviewCriterion;
            for (int i = 0; i < this.Count; i++)
            {
                interviewCriterion = this[i] as InterviewCriterion;
                if ((interviewer == Interviewer.Empty || interviewer == interviewCriterion.Interview.Interviewer) &&
                    (nominee == Nominee.Empty || nominee == interviewCriterion.Interview.Nominee) &&
                    (criterion == Criterion.Empty || criterion == interviewCriterion.Criterion) &&
                    (score == 0 || score == interviewCriterion.Score) &&
                    (dateTimeFrom <= interviewCriterion.DateTime && interviewCriterion.DateTime <= dateTimeTo))
                {
                    interviewCriterionArr.Add(interviewCriterion);
                }
            }

            return interviewCriterionArr;
        }




        public InterviewCriterionArr Filter(Interviewer interviewer, Nominee nominee, Position position, DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            InterviewCriterionArr interviewCriterionArr = new InterviewCriterionArr();

            InterviewCriterion interviewCriterion;
            for (int i = 0; i < this.Count; i++)
            {
                interviewCriterion = this[i] as InterviewCriterion;
                if ((interviewer == Interviewer.Empty || interviewer.DBId == interviewCriterion.Interview.Interviewer.DBId) &&
                    (nominee == Nominee.Empty || nominee.DBId == interviewCriterion.Interview.Nominee.DBId) &&
                    (position == Position.Empty || position.Id == interviewCriterion.Interview.Position.Id) &&
                    (dateTimeFrom <= interviewCriterion.DateTime && interviewCriterion.DateTime <= dateTimeTo))
                {
                    interviewCriterionArr.Add(interviewCriterion);
                }
            }

            return interviewCriterionArr;
        }


        public InterviewCriterionArr Filter(Interviewer interviewer, Nominee nominee)
        {
            InterviewCriterionArr interviewCriterionArr = new InterviewCriterionArr();

            InterviewCriterion interviewCriterion;
            for (int i = 0; i < this.Count; i++)
            {
                interviewCriterion = this[i] as InterviewCriterion;
                if ((interviewer == Interviewer.Empty || interviewer.DBId == interviewCriterion.Interview.Interviewer.DBId) &&
                    (nominee == Nominee.Empty || nominee.DBId == interviewCriterion.Interview.Nominee.DBId))
                {
                    interviewCriterionArr.Add(interviewCriterion);
                }
            }

            return interviewCriterionArr;
        }

        public InterviewCriterionArr FilterMonth(Criterion criterion, DateTime monthYear)
        {
            InterviewCriterionArr interviewCriterionArr = new InterviewCriterionArr();

            InterviewCriterion interviewCriterion;
            for (int i = 0; i < this.Count; i++)
            {
                interviewCriterion = this[i] as InterviewCriterion;
                if ((criterion == Criterion.Empty || criterion.Id == interviewCriterion.Criterion.Id) &&
                    (monthYear.Month == interviewCriterion.DateTime.Month) &&
                    (monthYear.Year == interviewCriterion.DateTime.Year))
                {
                    interviewCriterionArr.Add(interviewCriterion);
                }
            }

            return interviewCriterionArr;
        }


        public InterviewCriterion GetInterviewCriterionById(int id)
        {
            InterviewCriterion check;
            for (int i = 0; i < this.Count; i++)
            {
                check = this[i] as InterviewCriterion;
                if (check.Id == id)
                {
                    return check;
                }
            }
            return InterviewCriterion.Empty;
        }


        public bool IsContains(InterviewCriterion interviewCriterion)
        {
            //finds out whether this interviewCriterionArr contains the given InterviewCriterion.
            InterviewCriterion x;
            for (int i = 0; i < this.Count; i++)
            {
                x = (this[i] as InterviewCriterion);
                if (x.Id == interviewCriterion.Id || interviewCriterion.Id == 0)
                {
                    if (x.Equals(interviewCriterion))
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
                if ((this[i] as InterviewCriterion).Interview.Interviewer == interviewer)
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
                if ((this[i] as InterviewCriterion).Interview.Nominee == nominee)
                {
                    return true;
                }
            }
            return false;
        }


        public bool DoesExist(Criterion criterion)
        {
            //return whether curPosition exists in a nominee on this NomineeArr.
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as InterviewCriterion).Criterion == criterion)
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
                if ((this[i] as InterviewCriterion).Interview.Position == position)
                {
                    return true;
                }
            }
            return false;
        }
        public bool DoesExist(PositionType positionType)
        {
            //return whether curPosition exists in a nominee on this NomineeArr.
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as InterviewCriterion).Interview.Position.PositionType == positionType)
                {
                    return true;
                }
            }
            return false;
        }

        public InterviewCriterion MaxInterviewCriterionDBId()
        {
            InterviewCriterion max = InterviewCriterion.Empty;
            for (int i = 0; i < this.Count; i++)
            {
                max = (this[i] as InterviewCriterion).Id > max.Id ? this[i] as InterviewCriterion : max;
            }
            return max;
        }


        public InterviewerArr ToInterviewerArr()
        {
            InterviewerArr interviewerArr = new InterviewerArr();

            InterviewCriterion interviewCriterion;
            Interviewer interviewer;
            for (int i = 0; i < this.Count; i++)
            {
                interviewCriterion = this[i] as InterviewCriterion;
                interviewer = interviewCriterion.Interview.Interviewer;
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

            InterviewCriterion interviewCriterion;
            Nominee nominee;
            for (int i = 0; i < this.Count; i++)
            {
                interviewCriterion = this[i] as InterviewCriterion;
                nominee = interviewCriterion.Interview.Nominee;
                if (!nomineeArr.IsContains(nominee.DBId))
                {
                    nomineeArr.Add(nominee);
                }
            }

            return nomineeArr;
        }


        public CriterionArr ToCriterionArr()
        {
            CriterionArr criterionArr = new CriterionArr();

            InterviewCriterion interviewCriterion;
            Criterion criterion;
            for (int i = 0; i < this.Count; i++)
            {
                interviewCriterion = this[i] as InterviewCriterion;
                criterion = interviewCriterion.Criterion;
                if (!criterionArr.IsContains(criterion.Id))
                {
                    criterionArr.Add(criterion);
                }
            }

            return criterionArr;
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


        public bool DoesContainData(Interview interview, Criterion criterion)
        {
            InterviewCriterion interviewCriterion;

            for (int i = 0; i < this.Count; i++)
            {
                interviewCriterion = this[i] as InterviewCriterion;
                if (interviewCriterion.Interview.Id == interview.Id && interviewCriterion.Criterion.Id == criterion.Id)
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

        public SortedDictionary<string, float> GetSortedDictionaryScore(Criterion criterion, DateTime from, DateTime to)
        {

            // מחזירה משתנה מסוג מילון ממוין עם ערכים רלוונטיים לדוח
            SortedDictionary<string, float> dictionary = new SortedDictionary<string, float>();

            InterviewCriterionArr interviewCriterionArr;
            int sum = 0;
            int count = 0;
            int x = 0;
            string key = "";
            for (DateTime d = from; d <= to; d = d.AddMonths(1))
            {
                interviewCriterionArr = this.FilterMonth(criterion, d);

                for (int i = 0; i < interviewCriterionArr.Count; i++)
                {
                    x = (interviewCriterionArr[i] as InterviewCriterion).Score;
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
            InterviewCriterion n1 = (InterviewCriterion)x;
            InterviewCriterion n2 = (InterviewCriterion)y;
            if (n1.Interview.Position.Id > n2.Interview.Position.Id)
                return 1;
            if (n1.Interview.Position.Id < n2.Interview.Position.Id)
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
            InterviewCriterion n1 = (InterviewCriterion)x;
            InterviewCriterion n2 = (InterviewCriterion)y;
            if (n1.DateTime > n2.DateTime)
                return 1;
            if (n1.DateTime < n2.DateTime)
                return -1;
            else
                return 0;
        }
    }
}
