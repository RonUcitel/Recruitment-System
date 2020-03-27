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


        public bool Insert()
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


        public bool Delete()
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
                if ((nominee == Nominee.Empty || positionNominee.Nominee == nominee) && (position == Position.Empty || positionNominee.Position == position))
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


        public bool DoesExist(Position Position)
        {
            //return whether curPosition exists in a nominee on this NomineeArr.
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as PositionNominee).Position == Position)
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
                if (!nomineeArr.IsContains(nominee))
                {
                    nomineeArr.Add(nominee);
                }
            }

            return nomineeArr;
        }
    }
}
