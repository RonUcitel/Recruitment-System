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

        public ScoreTypeArr Filter(string name, int id = 0)
        {
            ScoreTypeArr scoreTypeArr = new ScoreTypeArr();

            ScoreType scoreType;

            name = name.ToLower();
            for (int i = 0; i < this.Count; i++)
            {
                scoreType = (this[i] as ScoreType);
                if ((name == "" || scoreType.Name.ToLower().StartsWith(name)) && (id == 0 || scoreType.Id == id))
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
    }
}
