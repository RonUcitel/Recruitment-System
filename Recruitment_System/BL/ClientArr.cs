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
    class ClientArr : ArrayList
    {
        public void Fill()
        {

            DataTable dataTable = Client_Dal.GetDataTable();


            DataRow dataRow;
            Client client;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                client = new Client(dataRow);

                Add(client);
            }
        }

        public ClientArr Filter(Client filter)
        {
            ClientArr clientArr = new ClientArr();

            //check if each client in the database stands in the filters args. if it doe's
            //then it is added to the new ClientArr.
            Client client;
            for (int i = 0; i < this.Count; i++)
            {
                client = (this[i] as Client);
                if (
                    (filter.FirstName == "" || client.FirstName.StartsWith(filter.FirstName)) &&
                    (filter.LastName == "" || client.LastName.StartsWith(filter.LastName)) &&
                    (filter.Id == "" || client.Id.StartsWith(filter.Id)) &&
                    (filter.CellPhone == "" || (client.CellAreaCode + client.CellPhone).Contains(filter.CellPhone)) &&
                    (filter.City.ToString() == "" || client.City.Name.StartsWith(filter.City.ToString())) &&
                    (filter.JobType.ToString() == "" || client.JobType.Name.StartsWith(filter.JobType.ToString()))
                    )
                {
                    clientArr.Add(client);
                }
            }

            return clientArr;
        }


        public bool IsContains(Client client)
        {
            //finds out whether this ClientArr contains the given client.
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Client).DBId == client.DBId || client.DBId == 0)
                {
                    if ((this[i] as Client).Equals(client))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public bool DoesExist(City curCity)
        {
            //return whether curCity exists in a client on this ClientArr.
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Client).City.Id == curCity.Id)
                {
                    return true;
                }
            }
            return false;
        }


        public bool DoesExist(Job curJob)
        {
            //return whether curJob exists in a client on this ClientArr.
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Client).JobType.Id == curJob.Id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
