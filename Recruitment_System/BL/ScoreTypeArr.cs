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
    public class ScoreTypeArr : ArrayList
    {
        public void Fill()
        {
            this.Clear();
            DataTable dataTable = ScoreType_Dal.GetDataTable();


            DataRow dataRow;
            ScoreType scoreType;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                scoreType = new ScoreType(dataRow);
                if (scoreType.Id != 0)
                    Add(scoreType);
            }
        }

        public ScoreTypeArr Filter(Position position, string name, int id = 0)
        {
            ScoreTypeArr scoreTypeArr = new ScoreTypeArr();

            ScoreType scoreType;

            name = name.ToLower();
            for (int i = 0; i < this.Count; i++)
            {
                scoreType = (this[i] as ScoreType);
                if ((name == "" || scoreType.Name.ToLower().StartsWith(name)) && (id == 0 || scoreType.Id == id) &&
                    (position == Position.Empty || position == scoreType.Position))
                {
                    scoreTypeArr.Add(scoreType);
                }
            }

            return scoreTypeArr;
        }


        public bool IsContains(string scoreType)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as ScoreType).ToString() == scoreType)
                    return true;
            }
            return false;
        }


        public bool IsContains(int scoreTypeId)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as ScoreType).Id == scoreTypeId)
                    return true;
            }
            return false;
        }


        public void Remove(int id)
        {
            ScoreType scoreType = GetScoreTypeById(id);
            if (scoreType != ScoreType.Empty)
            {
                try
                {

                    base.Remove(scoreType);
                }
                catch
                {

                }
            }
        }


        public PositionArr ToPositionArr()
        {
            PositionArr positionArr = new PositionArr();
            Position position;
            for (int i = 0; i < this.Count; i++)
            {
                position = (this[i] as ScoreType).Position;
                if (!positionArr.IsContains(position))
                {
                    positionArr.Add(position);
                }
            }
            return positionArr;
        }

        public ScoreType GetScoreTypeWithMaxId()
        {
            ScoreType maxScoreType = new ScoreType();

            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as ScoreType).Id > maxScoreType.Id)
                {
                    maxScoreType = (this[i] as ScoreType);
                }
            }
            return maxScoreType;
        }

        public ScoreType GetScoreTypeById(int id)
        {
            ScoreType scoreType;

            for (int i = 0; i < this.Count; i++)
            {
                scoreType = (this[i] as ScoreType);
                if (scoreType.Id == id)
                {
                    return scoreType;
                }
            }
            return ScoreType.Empty;
        }
    }
}
