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
    class CityArr : ArrayList
    {
        public void Fill()
        {

            DataTable dataTable = City_Dal.GetDataTable();


            DataRow dataRow;
            City city;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                city = new City(dataRow);

                Add(city);
            }
        }

        public CityArr Filter(string arg)
        {
            arg = arg.ToLower();
            CityArr cityArr = new CityArr();

            City city;
            for (int i = 0; i < this.Count; i++)
            {
                city = (this[i] as City);
                if (arg == "" || city.Name.ToLower().StartsWith(arg))
                {
                    cityArr.Add(city);
                }
            }

            return cityArr;
        }


        public bool IsContains(string cityName)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as City).ToString() == cityName)
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


        public City GetCityWithMaxId()
        {
            City maxCity = new City();

            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as City).Id > maxCity.Id)
                {
                    maxCity = (this[i] as City);
                }
            }
            return maxCity;
        }
    }
}
