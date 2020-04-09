using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Recruitment_System.BL;

namespace Recruitment_System.UI
{
    public partial class AdminTools_Form : Form
    {
        public AdminTools_Form()
        {
            InitializeComponent();
        }

        private void AdminTools_Form_Load(object sender, EventArgs e)
        {

        }

        private void button_Clear_Click(object sender, EventArgs e)
        {

        }


        private Interviewer FormToInterviewer()
        {
            Interviewer interviewer = new Interviewer();
            interviewer.DBId = int.Parse(label_ID.Text);
            interviewer.FirstName = textBox_FirstName.Text;
            interviewer.LastName = textBox_LastName.Text;
            interviewer.Id = textBox_ID.Text;
            return interviewer;
        }

        private Credentials FormToCredetials()
        {
            Credentials credentials = new Credentials();
            if (label_ID.Text != "0")
            {
                InterviewerArr interviewerArr = new InterviewerArr();
                interviewerArr.Fill();
                credentials.Id = interviewerArr.GetInterviewerByDBId(int.Parse(label_ID.Text)).Credentials.Id;
            }
            else
            {
                credentials.Id = 0;
            }
            credentials.UserName = textBox_UserName.Text;
            credentials.Password = textBox_Password.Text;

            return credentials;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (!CheckForm())
            {

            }
            else
            {
                Credentials credentials = FormToCredetials();

                Interviewer interviewer = FormToInterviewer();
                if (interviewer.DBId == 0)
                {
                    //insert
                    if (credentials.Insert())
                    {
                        CredentialsArr credentialsArr = new CredentialsArr();
                        credentialsArr.Fill();
                        credentials = credentialsArr.GetCredentialsWithMaxId();
                        interviewer.Credentials = credentials;

                        if (interviewer.Insert())
                        {
                            InterviewerArr interviewerArr = new InterviewerArr();
                            interviewerArr.Fill();
                            interviewer = interviewerArr.GetInterviewerWithMaxDBId();
                            MessageBox.Show("המראיין נכנס לבסיס הנתונים בהצלחה", "יאי!", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        }
                        else
                        {
                            MessageBox.Show("המראיין לא נכנס לבסיס הנתונים", "תקלה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        }
                    }
                    else
                    {
                        MessageBox.Show("המראיין לא נכנס לבסיס הנתונים", "תקלה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                }
                else
                {
                    //update

                    CredentialsArr credentialsArr = new CredentialsArr();
                    credentialsArr.Fill();
                    if (credentials != credentialsArr.GetCredentials(credentials.Id))
                    {
                        credentials.Update();
                    }

                    InterviewerArr interviewerArr = new InterviewerArr();
                    interviewerArr.Fill();
                    if (interviewer != interviewerArr.GetInterviewerByDBId(interviewer.DBId))
                    {
                        interviewer.Update();
                    }

                    interviewerArr.Fill();

                    interviewer = interviewerArr.GetInterviewerByDBId(interviewer.DBId);
                }

                InterviewerArrToForm();
                InterviewerToForm(interviewer);
            }
        }

        private bool CheckForm()
        {
            return true;
        }

        private void InterviewerArrToForm()
        {
            InterviewerArr interviewerArr = new InterviewerArr();
            interviewerArr.Fill();

            listBox_Interviewers.DataSource = interviewerArr;
        }

        private void InterviewerToForm(Interviewer interviewer)
        {
            if (interviewer != null)
            {
                checkBox_Admin.Checked = interviewer.Admin;
                textBox_FirstName.Text = interviewer.FirstName;
                textBox_LastName.Text = interviewer.LastName;
                textBox_ID.Text = interviewer.Id;
                CredentialsToForm(interviewer.Credentials);


            }
            else
            {
                checkBox_Admin.Checked = false;
                textBox_FirstName.Text = "";
                textBox_LastName.Text = "";
                textBox_ID.Text = "0";
                CredentialsToForm(null);
            }
        }


        private void CredentialsToForm(Credentials credentials)
        {
            if (credentials != null)
            {
                textBox_UserName.Text = credentials.UserName;
                textBox_Password.Text = credentials.Password;
            }
            else
            {
                textBox_UserName.Text = "";
                textBox_Password.Text = "";
            }
        }
    }
}
