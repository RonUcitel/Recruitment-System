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
    public class PositionNomineeArr : ArrayList
    {
        public void Fill(bool isOrderedByNominee = true)
        {

            DataTable dataTable = PositionNominee_Dal.GetDataTable(isOrderedByNominee);


            DataRow dataRow;
            PositionNominee positionNominee;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                positionNominee = new PositionNominee(dataRow);

                Add(positionNominee);
            }
        }

        public void FillDisabled(bool isOrderedByNominee = true)
        {

            DataTable dataTable = PositionNominee_Dal.GetDataTable(isOrderedByNominee);


            DataRow dataRow;
            PositionNominee positionNominee;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                positionNominee = new PositionNominee(dataRow);
                if (positionNominee.Nominee.Disabled)
                {
                    Add(positionNominee);
                }
            }
        }
        public void FillEnabled(bool isOrderedByNominee = true)
        {

            DataTable dataTable = PositionNominee_Dal.GetDataTable(isOrderedByNominee);


            DataRow dataRow;
            PositionNominee positionNominee;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                positionNominee = new PositionNominee(dataRow);
                if (!positionNominee.Nominee.Disabled)
                {
                    Add(positionNominee);
                }
            }
        }
        public void Fill(NomineeArrState state, bool isOrderedByNominee = true)
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

            PositionNominee positionNominee;
            for (int i = 0; i < this.Count; i++)
            {
                positionNominee = (this[i] as PositionNominee);
                if (!positionNominee.Insert())
                    return false;

            }
            return true;
        }


        public bool DeleteArr()
        {
            //מוחקת את אוסף המוצרים להזמנה מ מסד הנתונים

            PositionNominee positionNominee;
            for (int i = 0; i < this.Count; i++)
            {
                positionNominee = (this[i] as PositionNominee);
                if (!positionNominee.Delete())
                    return false;

            }
            return true;
        }


        public PositionNomineeArr Filter(Nominee nominee, Position position)
        {
            PositionNomineeArr positionnomineeArr = new PositionNomineeArr();

            PositionNominee positionNominee;
            for (int i = 0; i < this.Count; i++)
            {
                positionNominee = this[i] as PositionNominee;
                if ((nominee == Nominee.Empty || nominee == positionNominee.Nominee) && (position == Position.Empty || positionNominee.Position == position))
                {
                    positionnomineeArr.Add(positionNominee);
                }
            }

            return positionnomineeArr;
        }


        public PositionNominee GetPositionNomineeByDBId(int dbId)
        {
            PositionNominee check;
            for (int i = 0; i < this.Count; i++)
            {
                check = this[i] as PositionNominee;
                if (check.DBId == dbId)
                {
                    return check;
                }
            }
            return PositionNominee.Empty;
        }


        public bool IsContains(PositionNominee positionNominee)
        {
            //finds out whether this PositionNomineeArr contains the given PositionNominee.
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as PositionNominee).DBId == positionNominee.DBId || positionNominee.DBId == 0)
                {
                    if ((this[i] as PositionNominee).Equals(positionNominee))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public bool DoesExist(Nominee nominee)
        {
            //return whether curCity exists in a nominee on this NomineeArr.
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as PositionNominee).Nominee == nominee)
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
                if ((this[i] as PositionNominee).Position == position)
                {
                    return true;
                }
            }
            return false;
        }


        public PositionNominee MaxPositionNomineeDBId()
        {
            PositionNominee max = PositionNominee.Empty;
            for (int i = 0; i < this.Count; i++)
            {
                max = (this[i] as PositionNominee).DBId > max.DBId ? this[i] as PositionNominee : max;
            }
            return max;
        }


        public PositionArr ToPositionArr()
        {
            PositionArr positionArr = new PositionArr();

            PositionNominee positionNominee;
            Position position;
            for (int i = 0; i < this.Count; i++)
            {
                positionNominee = this[i] as PositionNominee;
                position = positionNominee.Position;
                if (!positionArr.IsContains(position.Name))
                {
                    positionArr.Add(position);
                }
            }

            return positionArr;
        }


        public NomineeArr ToNomineeArr()
        {
            NomineeArr nomineeArr = new NomineeArr();

            PositionNominee positionNominee;
            Nominee nominee;
            for (int i = 0; i < this.Count; i++)
            {
                positionNominee = this[i] as PositionNominee;
                nominee = positionNominee.Nominee;
                if (!nomineeArr.IsContains(nominee.DBId))
                {
                    nomineeArr.Add(nominee);
                }
            }

            return nomineeArr;
        }


        public SortedDictionary<string, int> GetSortedDictionary()
        {

            // מחזירה משתנה מסוג מילון ממוין עם ערכים רלוונטיים לדוח
            SortedDictionary<string, int> dictionary = new SortedDictionary<string, int>();

            PositionArr positionArr = this.ToPositionArr();
            foreach (Position curPosition in positionArr)
                dictionary.Add(curPosition.Name, this.Filter(Nominee.Empty, curPosition).Count);
            return dictionary;
        }

        public SortedDictionary<string, string> GetSortedDictionary(bool sortByNominee)
        {
            SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();
            string y = "";
            if (sortByNominee)
            {
                NomineeArr nomineeArr = this.ToNomineeArr();
                PositionArr positionArr;
                foreach (Nominee curNominee in nomineeArr)
                {
                    positionArr = this.Filter(curNominee, Position.Empty).ToPositionArr();

                    y += (positionArr[0] as Position).Name;

                    for (int i = 1; i < positionArr.Count; i++)
                    {
                        y += "\n" + (positionArr[i] as Position).Name;
                    }

                    dictionary.Add(curNominee.ToString() + (curNominee.Disabled ? " (לא זמין)" : ""), y);
                    y = "";
                }
                return dictionary;
            }
            else
            {
                PositionArr positionArr = this.ToPositionArr();
                NomineeArr nomineeArr;

                foreach (Position curPosition in positionArr)
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
        }
    }
}
