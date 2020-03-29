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
    public enum NomineeArrState
    {
        ShowDisabledOnly, ShowEnabledOnly, ShowAll
    }
    public class NomineeArr : ArrayList
    {
        public void FillEnabled()
        {

            DataTable dataTable = Nominee_Dal.GetDataTable();


            DataRow dataRow;
            Nominee nominee;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                nominee = new Nominee(dataRow);
                if (!nominee.Disabled && nominee.DBId != 0)
                {
                    Add(nominee);
                }

            }
        }

        public void FillDisabled()
        {

            DataTable dataTable = Nominee_Dal.GetDataTable();


            DataRow dataRow;
            Nominee nominee;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                nominee = new Nominee(dataRow);
                if (nominee.Disabled && nominee.DBId != 0)
                {
                    Add(nominee);
                }

            }
        }

        public void Fill()
        {

            DataTable dataTable = Nominee_Dal.GetDataTable();


            DataRow dataRow;
            Nominee nominee;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                nominee = new Nominee(dataRow);
                if (nominee.DBId != 0)
                    Add(nominee);

            }
        }

        public void Fill(NomineeArrState state)
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

        public NomineeArr Filter(Nominee filter, PositionArr filterPositionArr)
        {
            NomineeArr nomineeArr = new NomineeArr();

            //check if each nominee in the database stands in the filters args. if it doe's
            //then it is added to the new NomineeArr.
            Nominee nominee;

            PositionNomineeArr positionNomineeArr;
            PositionArr positionArr;

            for (int i = 0; i < this.Count; i++)
            {
                positionNomineeArr = new PositionNomineeArr();
                nominee = (this[i] as Nominee);
                positionNomineeArr = positionNomineeArr.Filter(nominee, Position.Empty);
                positionArr = positionNomineeArr.ToPositionArr();

                if (
                    (filter.FirstName == "" || nominee.FirstName.StartsWith(filter.FirstName)) &&
                    (filter.LastName == "" || nominee.LastName.StartsWith(filter.LastName)) &&
                    (filter.Id == "" || nominee.Id.StartsWith(filter.Id)) &&
                    (filter.Email == "" || nominee.Email.Contains(filter.Email)) &&
                    (filter.BirthYear == 0 || nominee.BirthYear == filter.BirthYear) &&
                    (filter.CellPhone == "" || (nominee.CellAreaCode + nominee.CellPhone).Contains(filter.CellPhone)) &&
                    (filter.City.ToString() == "" || nominee.City.Name.StartsWith(filter.City.ToString())) &&
                    (positionArr.Count == 0 || positionArr.IsContains(filterPositionArr))
                    )
                {
                    nomineeArr.Add(nominee);
                }
            }

            return nomineeArr;
        }


        public Nominee GetNomineeByDBId(int dbId)
        {
            if (dbId == 0)
            {
                return Nominee.Empty;
            }


            Nominee check;

            for (int i = 0; i < this.Count; i++)
            {
                check = this[i] as Nominee;
                if (check.DBId == dbId)
                {
                    return check;
                }
            }
            return Nominee.Empty;
        }


        public bool IsContains(string fullName)
        {
            //finds out whether this NomineeArr contains the given nominee.
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Nominee).ToString() == fullName)
                    return true;
            }
            return false;
        }

        public bool IsContains(int dBID)
        {
            //finds out whether this NomineeArr contains the given nominee.
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Nominee).DBId == dBID)
                    return true;
            }
            return false;
        }


        public bool DoesCityExist(City curCity)
        {
            //return whether curCity exists in a nominee on this NomineeArr.
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Nominee).City.Id == curCity.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public Nominee MaxNomineeDBId()
        {
            Nominee max = Nominee.Empty;
            for (int i = 0; i < this.Count; i++)
            {
                max = (this[i] as Nominee).DBId > max.DBId ? this[i] as Nominee : max;
            }
            return max;
        }
    }
}
