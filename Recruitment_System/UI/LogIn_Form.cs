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
            this.DialogResult = DialogResult.Cancel;

            KeyDown += Control_KeyDown;//Add the Control_KeyDown event to the form.
            AddKeyDownEvent(this.Controls);//Add the Control_KeyDown event to all of the controls on the form.
            LogIn_Form_InputLanguageChanged(null, null);//Check the current language.
            CapsLockCheck(); //Check for the state of the CapsLk.
        }

        public Interviewer Interviewer;

        private void button_LogIn_Click(object sender, EventArgs e)
        {
            Credentials cred = FormToCredentials();

            InterviewerArr interviewerArr = new InterviewerArr();
            interviewerArr.Fill();

            if (interviewerArr.Filter("", "", "", Credentials.Empty, true).Count == 0 && cred == Credentials.Empty)
            {
                Interviewer = new Interviewer();
                Interviewer.FirstName = "Admin";
                Interviewer.LastName = "Admin";
                Interviewer.Admin = true;
                Interviewer.DBId = -1;
                Interviewer.Credentials = Credentials.Empty;
            }
            else if (cred.Id != 0)
            {
                Interviewer = interviewerArr.GetInterviewerByCredentials(cred);
                if (Interviewer == Interviewer.Empty)
                {
                    label_Error.Visible = true;
                    return;
                }
            }
            else
            {
                label_Error.Visible = true;
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private Credentials FormToCredentials()
        {
            Credentials c = new Credentials();
            c.UserName = textBox_UserName.Text;
            c.Password = textBox_Password.Text;

            if (textBox_UserName.Text == "" && textBox_Password.Text == "")
            {
                return Credentials.Empty;
            }
            else if (textBox_UserName.Text == "" || textBox_Password.Text == "")
            {
                return c;
            }
            CredentialsArr credentialsArr = new CredentialsArr();
            credentialsArr.Fill();
            credentialsArr = credentialsArr.Filter(textBox_UserName.Text, textBox_Password.Text);

            Credentials cred;
            for (int i = 0; i < credentialsArr.Count; i++)
            {
                cred = credentialsArr[0] as Credentials;
                if (cred.UserName == c.UserName && cred.Password == c.Password)
                {
                    return cred;
                }
            }
            return c;
        }

        private void LogIn_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*            if (e.CloseReason == CloseReason.WindowsShutDown) return;

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
                        }*/
        }

        private void textBox_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_LogIn_Click(null, null);
            }
        }

        private void CapsLockCheck()
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                //CapsLk is on
                label_CapsLk.Text = "CapsLk on";
                label_CapsLk.ForeColor = Color.Red;
            }
            else
            {
                //CapsLk is off
                label_CapsLk.Text = "CapsLk off";
                label_CapsLk.ForeColor = Color.Black;
            }
        }

        private void LogIn_Form_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        {
            InputLanguage myCurrentLang = InputLanguage.CurrentInputLanguage;
            label_Language.Text = myCurrentLang.Culture.Name.ToLower();
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.CapsLock)
            {
                //Only if the CapsLK key was pressed, then call the method.
                CapsLockCheck();
            }
        }

        private void AddKeyDownEvent(Control.ControlCollection collection)
        {
            foreach (Control item in collection)
            {
                item.KeyDown += Control_KeyDown;
                if (item.Controls.Count > 0)
                {
                    AddKeyDownEvent(item.Controls);
                }
            }
        }
    }
}
