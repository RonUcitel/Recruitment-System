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

        public void Fill()
        {
            this.Clear();
            DataTable dataTable = Position_Dal.GetDataTable();


            DataRow dataRow;
            Position position;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                position = new Position(dataRow);

                if (position.Id != 0)
                    Add(position);
            }
        }

        public PositionArr Filter(string name, PositionType positionType, DateTime creationDate, DateTime deadLine, int id = 0)
        {

            PositionArr positionArr = new PositionArr();

            Position position;
            for (int i = 0; i < this.Count; i++)
            {
                position = (this[i] as Position);
                if ((id == 0 || position.Id == id) &&
                    (name == "" || position.Name.StartsWith(name)) &&
                    (positionType == PositionType.Empty || positionType == position.PositionType) &&
                    (creationDate == DateTime.MinValue || creationDate == null || position.CreationDate == creationDate) &&
                    (deadLine == DateTime.MinValue || deadLine == null || position.DeadLine == deadLine))
                {
                    positionArr.Add(position);
                }
            }

            return positionArr;
        }


        public Position GetPositionById(int id)
        {
            Position position;
            for (int i = 0; i < this.Count; i++)
            {
                position = (this[i] as Position);
                if (id == position.Id)
                {
                    return position;
                }
            }

            return Position.Empty;
        }

        public Position GetPositionByName(string name)
        {
            Position position;
            for (int i = 0; i < this.Count; i++)
            {
                position = (this[i] as Position);
                if (name == position.Name)
                {
                    return position;
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


        public bool IsContains(PositionType positionType)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as PositionType) == positionType)
                    return true;
            }
            return false;
        }


        public void Remove(PositionTypeArr positionTypeArr)
        {
            //מסירה מהאוסף הנוכחי את האוסף המתקבל

            for (int i = 0; i < positionTypeArr.Count; i++)
                this.Remove(positionTypeArr[i] as PositionType);
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
                base.Remove(GetPositionByName(name));
            }
            catch
            {

            }
        }


        public void Remove(int id)
        {
            try
            {
                base.Remove(GetPositionById(id));
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
