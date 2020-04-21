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
    public class PositionTypeArr : ArrayList
    {

        public void Fill()
        {
            this.Clear();
            DataTable dataTable = PositionType_Dal.GetDataTable();


            DataRow dataRow;
            PositionType positionType;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                positionType = new PositionType(dataRow);

                if (positionType.Id != 0)
                    Add(positionType);
            }
        }

        public PositionTypeArr Filter(string name)
        {
            PositionTypeArr positionTypeArr = new PositionTypeArr();

            PositionType positionType;
            for (int i = 0; i < this.Count; i++)
            {
                positionType = (this[i] as PositionType);
                if (name == "" || positionType.Name.StartsWith(name))
                {
                    positionTypeArr.Add(positionType);
                }
            }

            return positionTypeArr;
        }


        public PositionType GetPositionTypeById(int id)
        {
            PositionType positionType;
            for (int i = 0; i < this.Count; i++)
            {
                positionType = (this[i] as PositionType);
                if (id == positionType.Id)
                {
                    return positionType;
                }
            }

            return PositionType.Empty;
        }


        public bool IsContains(string positionTypeName)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as PositionType).Name == positionTypeName)
                    return true;
            }
            return false;
        }


        public bool IsContains(PositionTypeArr positionTypeArr)
        {
            bool isEqual;
            for (int i = 0; i < positionTypeArr.Count; i++)
            {
                isEqual = false;
                for (int x = 0; x < this.Count; x++)
                {
                    if ((this[x] as PositionType) == (positionTypeArr[i] as PositionType))
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


        public void Remove(PositionType positionType)
        {

            //מסירה מהאוסף הנוכחי את הפריט המתקבל

            for (int i = 0; i < Count; i++)
                if ((this[i] as PositionType) == positionType)
                {
                    RemoveAt(i);
                    return;
                }
        }


        public void Remove(string type)
        {
            try
            {
                base.Remove(Filter(type)[0]);
            }
            catch
            {

            }
        }


        public void Remove(int dBId)
        {
            try
            {
                base.Remove(GetPositionTypeById(dBId));
            }
            catch
            {

            }
        }


        public PositionType GetPositionTypeWithMaxId()
        {
            PositionType maxPositionType = new PositionType();

            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as PositionType).Id > maxPositionType.Id)
                {
                    maxPositionType = (this[i] as PositionType);
                }
            }
            return maxPositionType;
        }
    }
}
