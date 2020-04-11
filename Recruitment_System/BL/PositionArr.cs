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
    public class PositionArr : ArrayList
    {
        //public static PositionArr Empty = new PositionArr();

        public void Fill()
        {
            this.Clear();
            DataTable dataTable = Position_Dal.GetDataTable();


            DataRow dataRow;
            Position Position;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                Position = new Position(dataRow);

                if (Position.Id != 0)
                    Add(Position);
            }
        }

        public PositionArr Filter(string arg)
        {
            arg = arg.ToLower();
            PositionArr PositionArr = new PositionArr();

            Position Position;
            for (int i = 0; i < this.Count; i++)
            {
                Position = (this[i] as Position);
                if (arg == "" || Position.Name.ToLower().StartsWith(arg))
                {
                    PositionArr.Add(Position);
                }
            }

            return PositionArr;
        }


        public Position Filter(int dBId)
        {
            Position Position;
            for (int i = 0; i < this.Count; i++)
            {
                Position = (this[i] as Position);
                if (dBId == Position.Id)
                {
                    return Position;
                }
            }

            return Position.Empty;
        }


        public bool IsContains(string positionName)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Position).Name == positionName)
                    return true;
            }
            return false;
        }


        public bool IsContains(PositionArr positionArr)
        {
            bool isEqual;
            for (int i = 0; i < positionArr.Count; i++)
            {
                isEqual = false;
                for (int x = 0; x < this.Count; x++)
                {
                    if ((this[x] as Position) == (positionArr[i] as Position))
                    {
                        isEqual = true;
                        break;
                    }
                }
                if (!isEqual)
                {
                    return false;
                }
            }
            return true;
        }


        public bool IsContains(Position position)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Position) == position)
                    return true;
            }
            return false;
        }


        public void Remove(PositionArr positionArr)
        {
            //מסירה מהאוסף הנוכחי את האוסף המתקבל

            for (int i = 0; i < positionArr.Count; i++)
                this.Remove(positionArr[i] as Position);
        }


        public void Remove(Position position)
        {

            //מסירה מהאוסף הנוכחי את הפריט המתקבל

            for (int i = 0; i < Count; i++)
                if ((this[i] as Position) == position)
                {
                    RemoveAt(i);
                    return;
                }
        }


        public void Remove(string name)
        {
            try
            {
                base.Remove(Filter(name)[0]);
            }
            catch
            {

            }
        }


        public void Remove(int dBId)
        {
            try
            {
                base.Remove(Filter(dBId));
            }
            catch
            {

            }
        }


        public Position GetPositionWithMaxId()
        {
            Position maxPosition = new Position();

            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Position).Id > maxPosition.Id)
                {
                    maxPosition = (this[i] as Position);
                }
            }
            return maxPosition;
        }
    }
}
