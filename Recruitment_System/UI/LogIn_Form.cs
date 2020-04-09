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
    public partial class LogIn_Form : Form
    {
        public LogIn_Form()
        {
            InitializeComponent();
        }
        public Interviewer Interviewer;

        private void button_LogIn_Click(object sender, EventArgs e)
        {
            Credentials cred = FormToCredentials();

            InterviewerArr interviewerArr = new InterviewerArr();
            interviewerArr.Fill();
            interviewerArr = interviewerArr.Filter("", "", "", Credentials.Empty, true);
            if (interviewerArr.Count > 0)
            {
                Interviewer = interviewerArr.GetInterviewerByCredentials(cred);
            }
            else
            {
                Interviewer = new Interviewer();
                Interviewer.FirstName = "Admin";
                Interviewer.LastName = "Admin";
                Interviewer.Admin = true;
                Interviewer.DBId = -1;
                Interviewer.Credentials = Credentials.Empty;

            }
            this.DialogResult = DialogResult.OK;
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private Credentials FormToCredentials()
        {
            CredentialsArr credentialsArr = new CredentialsArr();
            credentialsArr.Fill();
            credentialsArr = credentialsArr.Filter(textBox_UserName.Text, textBox_Password.Text);

            if (credentialsArr.Count > 0)
            {
                return credentialsArr[0] as Credentials;
            }
            else
            {
                return Credentials.Empty;
            }
        }

        private void LogIn_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            if (Interviewer != Interviewer.Empty && this.DialogResult == DialogResult.OK)
            {
            }
            else if (this.DialogResult != DialogResult.OK)
            {
                e.Cancel = true;
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
