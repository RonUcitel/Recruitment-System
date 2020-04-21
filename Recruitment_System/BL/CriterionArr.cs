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
    public class CriterionArr : ArrayList
    {
        public void Fill()
        {
            this.Clear();
            DataTable dataTable = Criterion_Dal.GetDataTable();


            DataRow dataRow;
            Criterion criterion;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                criterion = new Criterion(dataRow);
                if (criterion.Id != 0)
                    Add(criterion);
            }
        }

        public CriterionArr Filter(PositionType positionType, string name, int id = 0)
        {
            PositionTypeCriterionArr positionTypeCriterionArr = new PositionTypeCriterionArr();
            positionTypeCriterionArr.Fill();
            positionTypeCriterionArr = positionTypeCriterionArr.Filter(positionType, Criterion.Empty);

            CriterionArr criterionArr = new CriterionArr();

            Criterion criterion;

            for (int i = 0; i < this.Count; i++)
            {
                criterion = (this[i] as Criterion);
                if ((name == "" || criterion.Name.StartsWith(name)) && (id == 0 || criterion.Id == id) &&
                    (positionType == PositionType.Empty || positionType.Id == positionType.Id))
                {
                    criterionArr.Add(criterion);
                }
            }

            return criterionArr;
        }


        public bool IsContains(string scoreType)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Criterion).ToString() == scoreType)
                    return true;
            }
            return false;
        }


        public bool IsContains(int scoreTypeId)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Criterion).Id == scoreTypeId)
                    return true;
            }
            return false;
        }


        public void Remove(int id)
        {
            Criterion scoreType = GetScoreTypeById(id);
            if (scoreType != Criterion.Empty)
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


        public PositionTypeArr ToPositionTypeArr()
        {
            PositionTypeArr positionTypeArr = new PositionTypeArr();
            PositionType positionType;
            for (int i = 0; i < this.Count; i++)
            {
                positionType = (this[i] as PositionType);
                if (!positionTypeArr.IsContains(positionType))
                {
                    positionTypeArr.Add(positionType);
                }
            }
            return positionTypeArr;
        }

        public Criterion GetScoreTypeWithMaxId()
        {
            Criterion maxScoreType = new Criterion();

            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Criterion).Id > maxScoreType.Id)
                {
                    maxScoreType = (this[i] as Criterion);
                }
            }
            return maxScoreType;
        }

        public Criterion GetScoreTypeById(int id)
        {
            Criterion scoreType;

            for (int i = 0; i < this.Count; i++)
            {
                scoreType = (this[i] as Criterion);
                if (scoreType.Id == id)
                {
                    return scoreType;
                }
            }
            return Criterion.Empty;
        }


        public SortedDictionary<string, string> GetSortedDictionary()
        {
            SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();
            string y = "";
            PositionTypeArr positionTypeArr = this.ToPositionTypeArr();
            CriterionArr scoreTypeArr;

            foreach (PositionType curPosition in positionTypeArr)
            {
                scoreTypeArr = this.Filter(curPosition, "");

                y += (scoreTypeArr[0] as Criterion).ToString();

                for (int i = 1; i < scoreTypeArr.Count; i++)
                {
                    y += "\n" + (scoreTypeArr[i] as Criterion).ToString();
                }

                dictionary.Add(curPosition.ToString(), y);
                y = "";
            }
            return dictionary;
        }
    }
}
