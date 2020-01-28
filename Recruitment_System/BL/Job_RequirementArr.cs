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
    class Job_RequirementArr : ArrayList
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

        public Job_RequirementArr Filter(int id, string requirement, Job job)
        {
            Job_RequirementArr job_RequirementArr = new Job_RequirementArr();

            for (int i = 0; i < this.Count; i++)
            {

                //הצבת הדרישה הנוכחית במשתנה עזר - דרישה

                Job_Requirement job_Requirement = (this[i] as Job_Requirement);
                if (

                //סינון לפי מזהה הדרישה

                (id <= 0 || job_Requirement.Id == id)

                //סינון לפי שם הדרישה

                && job_Requirement.Requirement.StartsWith(requirement)

                //סינון לפי המשרה
                && (job == null || job.Id == -1 || job == Job.Empty)//???
                )
                {

                    //המוצר ענה לדרישות החיפוש - הוספה שלו לאוסף המוחזר

                    job_RequirementArr.Add(job_Requirement);
                    if (id > 0)
                        break;

                }
            }
            return job_RequirementArr;
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
                base.Remove(Filter(-1, name, null)[0]);
            }
            catch
            {

            }
        }
    }
}
