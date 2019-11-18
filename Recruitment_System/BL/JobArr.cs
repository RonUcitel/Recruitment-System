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
    class JobArr : ArrayList
    {
        public void Fill()
        {

            DataTable dataTable = Job_Dal.GetDataTable();


            DataRow dataRow;
            Job job;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];

                job = new Job(dataRow);

                Add(job);
            }
        }

        public JobArr Filter(string arg)
        {
            arg = arg.ToLower();
            JobArr jobArr = new JobArr();

            Job job;
            for (int i = 0; i < this.Count; i++)
            {
                job = (this[i] as Job);
                if (arg == "" || job.Name.ToLower().StartsWith(arg))
                {
                    jobArr.Add(job);
                }
            }

            return jobArr;
        }


        public bool IsContains(string jobName)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Job).ToString() == jobName)
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


        public Job GetJobWithMaxId()
        {
            Job maxJob = new Job();

            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Job).Id > maxJob.Id)
                {
                    maxJob = (this[i] as Job);
                }
            }
            return maxJob;
        }
    }
}
