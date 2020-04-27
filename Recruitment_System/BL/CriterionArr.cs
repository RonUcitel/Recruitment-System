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

            if (positionType != PositionType.Empty)
            {
                positionTypeCriterionArr.Fill();
            }


            CriterionArr criterionArr = positionTypeCriterionArr.Filter(positionType, Criterion.Empty).ToCriterionArr();

            Criterion criterion;

            for (int i = 0; i < this.Count; i++)
            {
                criterion = (this[i] as Criterion);
                if ((name == "" || criterion.Name.StartsWith(name)) && (id == 0 || criterion.Id == id) &&
                    (positionType == PositionType.Empty || positionTypeCriterionArr.DoesExist(criterion)))
                {
                    criterionArr.Add(criterion);
                }
            }

            return criterionArr;
        }


        public bool IsContains(string criterion)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Criterion).ToString() == criterion)
                    return true;
            }
            return false;
        }


        public bool IsContains(int criterionId)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Criterion).Id == criterionId)
                    return true;
            }
            return false;
        }


        public void Remove(int id)
        {
            Criterion criterion = GetCriterionById(id);
            if (criterion != Criterion.Empty)
            {
                try
                {

                    base.Remove(criterion);
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

        public Criterion GetCriterionWithMaxId()
        {
            Criterion maxCriterion = new Criterion();

            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Criterion).Id > maxCriterion.Id)
                {
                    maxCriterion = (this[i] as Criterion);
                }
            }
            return maxCriterion;
        }

        public Criterion GetCriterionById(int id)
        {
            Criterion criterion;

            for (int i = 0; i < this.Count; i++)
            {
                criterion = (this[i] as Criterion);
                if (criterion.Id == id)
                {
                    return criterion;
                }
            }
            return Criterion.Empty;
        }


        public SortedDictionary<string, string> GetSortedDictionary()
        {
            SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();
            string y = "";
            PositionTypeArr positionTypeArr = this.ToPositionTypeArr();
            CriterionArr criterionArr;

            foreach (PositionType curPosition in positionTypeArr)
            {
                criterionArr = this.Filter(curPosition, "");

                y += (criterionArr[0] as Criterion).ToString();

                for (int i = 1; i < criterionArr.Count; i++)
                {
                    y += "\n" + (criterionArr[i] as Criterion).ToString();
                }

                dictionary.Add(curPosition.ToString(), y);
                y = "";
            }
            return dictionary;
        }
    }
}
