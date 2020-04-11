using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recruitment_System.DAL;

namespace Recruitment_System.BL
{
    public class CredentialsArr : ArrayList
    {
        public void Fill()
        {
            this.Clear();
            DataTable dataTable = Credentials_Dal.GetDataTable();


            DataRow dataRow;
            Credentials credentials;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                credentials = new Credentials(dataRow);
                if (credentials.Id != 0)
                    Add(credentials);
            }
        }

        public CredentialsArr Filter(string userName, string password, int id = 0)
        {
            CredentialsArr credentialsArr = new CredentialsArr();

            Credentials credentials;

            for (int i = 0; i < this.Count; i++)
            {
                credentials = (this[i] as Credentials);
                if ((userName == "" || credentials.UserName.StartsWith(userName)) &&
                    (password == "" || credentials.Password.StartsWith(password)) &&
                    (id == 0 || credentials.Id == id))
                {
                    credentialsArr.Add(credentials);
                }
            }

            return credentialsArr;
        }


        public bool IsContains(string userName)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Credentials).UserName == userName)
                    return true;
            }
            return false;
        }


        public bool IsContains(int credentialsId)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Credentials).Id == credentialsId)
                    return true;
            }
            return false;
        }


        public void Remove(int id)
        {
            Credentials c = GetCredentials(id);
            if (c != null && c != Credentials.Empty)
            {
                Remove(c);
            }

        }


        public Credentials GetCredentialsWithMaxId()
        {
            Credentials maxCredentials = new Credentials();

            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Credentials).Id > maxCredentials.Id)
                {
                    maxCredentials = (this[i] as Credentials);
                }
            }
            return maxCredentials;
        }

        public Credentials GetCredentials(int id)
        {
            Credentials c;
            for (int i = 0; i < this.Count; i++)
            {
                c = (this[i] as Credentials);
                if (c.Id == id)
                {
                    return c;
                }
            }
            return Credentials.Empty;
        }
    }
}
