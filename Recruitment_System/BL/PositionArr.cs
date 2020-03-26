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

            DataTable dataTable = Position_Dal.GetDataTable();


            DataRow dataRow;
            Position Position;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                Position = new Position(dataRow);

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


        public Position Filter(int DBId)
        {
            Position Position;
            for (int i = 0; i < this.Count; i++)
            {
                Position = (this[i] as Position);
                if (DBId == Position.Id)
                {
                    return Position;
                }
            }

            return Position.Empty;
        }


        public bool IsContains(string PositionName)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Position).Name == PositionName)
                    return true;
            }
            return false;
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


        public void Remove(int DBId)
        {
            try
            {
                base.Remove(Filter(DBId));
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
