using Recruitment_System.DAL;
using System.Collections;
using System.Data;

namespace Recruitment_System.BL
{
    public class City
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="City"/> class.
        /// </summary>
        public City()
        {
            m_Id = 0;
            m_Name = "";
        }
        public City(DataRow city_prop)
        {
            m_Id = (int)city_prop["ID"];
            m_Name = city_prop["Name"].ToString();

        }

        private City(bool unused)
        {
            m_Id = -1;
            m_Name = "+";
        }

        #endregion


        #region Private containers

        private int m_Id;
        private string m_Name;

        #endregion


        #region Public variables
        public int Id { get => m_Id; set => m_Id = value; }
        public string Name { get => m_Name; set => m_Name = value; }

        public static City Empty = new City();
        public static City AddingFormButton = new City(true);

        #endregion


        #region Public methods

        /// <summary>
        /// Inserts the city's information to the database
        /// </summary>
        /// <returns>Whether the operation was successful</returns>
        public bool Insert()
        {
            CityArr ca = new CityArr();
            ca.Fill();
            ca = ca.Filter("+");

            if (City_Dal.Update((ca[0] as City).Id, m_Name))
            {
                return City_Dal.Insert("+");
            }
            return false;
        }

        public bool Update()
        {
            return City_Dal.Update(m_Id, m_Name);
        }


        public bool Delete()
        {
            return City_Dal.Delete(m_Id);
        }


        public override string ToString()
        {
            return m_Name;
        }

        #endregion
    }
}
