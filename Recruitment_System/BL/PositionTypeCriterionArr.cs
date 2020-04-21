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
    public class PositionTypeCriterionArr : ArrayList
    {
        public void Fill()
        {
            this.Clear();
            DataTable dataTable = PositionTypeCriterion_Dal.GetDataTable();


            DataRow dataRow;
            PositionTypeCriterion positionTypeCriterion;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                positionTypeCriterion = new PositionTypeCriterion(dataRow);

                Add(positionTypeCriterion);
            }
        }

        public bool InsertArr()
        {
            //מוסיפה את אוסף המוצרים להזמנה למסד הנתונים

            PositionTypeCriterion positionTypeCriterion;
            for (int i = 0; i < this.Count; i++)
            {
                positionTypeCriterion = (this[i] as PositionTypeCriterion);
                if (!positionTypeCriterion.Insert())
                    return false;

            }
            return true;
        }


        public bool DeleteArr()
        {
            //מוחקת את אוסף המוצרים להזמנה מ מסד הנתונים

            PositionTypeCriterion positionTypeCriterion;
            for (int i = 0; i < this.Count; i++)
            {
                positionTypeCriterion = (this[i] as PositionTypeCriterion);
                if (!positionTypeCriterion.Delete())
                    return false;

            }
            return true;
        }


        public PositionTypeCriterionArr Filter(PositionType positionType, Criterion criterion)
        {
            PositionTypeCriterionArr positionTypeCriterionArr = new PositionTypeCriterionArr();

            PositionTypeCriterion positionTypeCriterion;
            for (int i = 0; i < this.Count; i++)
            {
                positionTypeCriterion = this[i] as PositionTypeCriterion;
                if ((positionType == PositionType.Empty || positionType == positionTypeCriterion.PositionType) && (criterion == Criterion.Empty || positionTypeCriterion.Criterion == criterion))
                {
                    positionTypeCriterionArr.Add(positionTypeCriterion);
                }
            }

            return positionTypeCriterionArr;
        }


        public PositionTypeCriterion GetPositionTypeCriterionById(int id)
        {
            PositionTypeCriterion check;
            for (int i = 0; i < this.Count; i++)
            {
                check = this[i] as PositionTypeCriterion;
                if (check.Id == id)
                {
                    return check;
                }
            }
            return PositionTypeCriterion.Empty;
        }


        public bool IsContains(PositionTypeCriterion positionTypeCriterion)
        {
            //finds out whether this PositionNomineeArr contains the given PositionNominee.
            PositionTypeCriterion x;
            for (int i = 0; i < this.Count; i++)
            {
                x = this[i] as PositionTypeCriterion;
                if ((positionTypeCriterion.Id == x.Id || positionTypeCriterion.Id == 0) &&
                    (positionTypeCriterion.PositionType == x.PositionType || positionTypeCriterion.PositionType == PositionType.Empty || positionTypeCriterion.PositionType == null) &&
                     (positionTypeCriterion.Criterion == x.Criterion || positionTypeCriterion.Criterion == Criterion.Empty || positionTypeCriterion.Criterion == null))
                {
                    if ((this[i] as PositionTypeCriterion).Equals(positionTypeCriterion))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public bool DoesExist(Criterion criterion)
        {
            //return whether curCity exists in a nominee on this NomineeArr.
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as PositionTypeCriterion).Criterion == criterion)
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
                if ((this[i] as PositionTypeCriterion).PositionType == positionType)
                {
                    return true;
                }
            }
            return false;
        }


        public PositionTypeCriterion MaxPositionTypeCriterionDBId()
        {
            PositionTypeCriterion max = PositionTypeCriterion.Empty;
            for (int i = 0; i < this.Count; i++)
            {
                max = (this[i] as PositionTypeCriterion).Id > max.Id ? this[i] as PositionTypeCriterion : max;
            }
            return max;
        }


        public PositionTypeArr ToPositionTypeArr()
        {
            PositionTypeArr positionTypeArr = new PositionTypeArr();

            PositionTypeCriterion positionTypeCriterion;
            PositionType positionType;
            for (int i = 0; i < this.Count; i++)
            {
                positionTypeCriterion = this[i] as PositionTypeCriterion;
                positionType = positionTypeCriterion.PositionType;
                if (!positionTypeArr.IsContains(positionType.Name))
                {
                    positionTypeArr.Add(positionType);
                }
            }

            return positionTypeArr;
        }


        public CriterionArr ToCriterionArr()
        {
            CriterionArr criterionArr = new CriterionArr();

            PositionTypeCriterion positionTypeCriterion;
            Criterion criterion;
            for (int i = 0; i < this.Count; i++)
            {
                positionTypeCriterion = this[i] as PositionTypeCriterion;
                criterion = positionTypeCriterion.Criterion;
                if (!criterionArr.IsContains(criterion.Id))
                {
                    criterionArr.Add(criterion);
                }
            }

            return criterionArr;
        }


        public SortedDictionary<string, int> GetSortedDictionary()
        {

            // מחזירה משתנה מסוג מילון ממוין עם ערכים רלוונטיים לדוח
            SortedDictionary<string, int> dictionary = new SortedDictionary<string, int>();

            PositionTypeArr positionTypeArr = this.ToPositionTypeArr();
            foreach (PositionType curPositionType in positionTypeArr)
                dictionary.Add(curPositionType.Name, this.Filter(curPositionType, Criterion.Empty).Count);
            return dictionary;
        }


        /*public SortedDictionary<string, string> GetSortedDictionary()
        {
            SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();
            string y = "";
            if (sortByNominee)
            {
                NomineeArr nomineeArr = this.ToNomineeArr();
                PositionTypeArr positionArr;
                foreach (Nominee curNominee in nomineeArr)
                {
                    positionArr = this.Filter(curNominee, PositionType.Empty).ToPositionArr();

                    y += (positionArr[0] as PositionType).Name;

                    for (int i = 1; i < positionArr.Count; i++)
                    {
                        y += "\n" + (positionArr[i] as PositionType).Name;
                    }

                    dictionary.Add(curNominee.ToString() + (curNominee.Disabled ? " (לא זמין)" : ""), y);
                    y = "";
                }
                return dictionary;
            }
            else
            {
                PositionTypeArr positionArr = this.ToPositionArr();
                NomineeArr nomineeArr;

                foreach (PositionType curPosition in positionArr)
                {
                    nomineeArr = this.Filter(Nominee.Empty, curPosition).ToNomineeArr();

                    y += (nomineeArr[0] as Nominee).ToString();

                    for (int i = 1; i < nomineeArr.Count; i++)
                    {
                        y += "\n" + (nomineeArr[i] as Nominee).ToString() + ((nomineeArr[i] as Nominee).Disabled ? " (לא זמין)" : "");
                    }

                    dictionary.Add(curPosition.ToString(), y);
                    y = "";
                }
                return dictionary;
            }
        }*/
    }
}
