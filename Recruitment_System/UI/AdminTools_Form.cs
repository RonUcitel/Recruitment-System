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
        public AdminTools_Form(Interviewer interviewer)
        {
            InitializeComponent();
            InterviewerArrToForm();
            CurInterviewer = interviewer;
        }

        public Interviewer CurInterviewer;

        private void button_InterviewerClear_Click(object sender, EventArgs e)
        {
            InterviewerToForm(Interviewer.Empty);
        }

        #region tab interviewers
        private Interviewer FormToInterviewer()
        {
            Interviewer interviewer = new Interviewer();
            interviewer.DBId = int.Parse(label_InterviewerDBID.Text);
            interviewer.FirstName = textBox_InterviewerFirstName.Text;
            interviewer.LastName = textBox_InterviewerLastName.Text;
            interviewer.Id = textBox_InterviewerID.Text;
            interviewer.Admin = checkBox_InterviewerAdmin.Checked;
            return interviewer;
        }

        private Credentials FormToCredetials()
        {
            Credentials credentials = new Credentials();
            if (label_InterviewerDBID.Text != "0")
            {
                InterviewerArr interviewerArr = new InterviewerArr();
                interviewerArr.Fill();
                credentials.Id = interviewerArr.GetInterviewerByDBId(int.Parse(label_InterviewerDBID.Text)).Credentials.Id;
            }
            else
            {
                credentials.Id = 0;
            }
            credentials.UserName = textBox_InterviewerUserName.Text;
            credentials.Password = textBox_InterviewerPassword.Text;

            return credentials;
        }

        private void button_InterviewerSave_Click(object sender, EventArgs e)
        {
            if (!CheckInterviewerForm())
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
                        if (credentials.Update())
                        {
                            credentialsArr.Fill();
                            credentials = credentialsArr.GetCredentials(credentials.Id);
                        }
                    }



                    interviewer.Credentials = credentials;

                    InterviewerArr interviewerArr = new InterviewerArr();
                    interviewerArr.Fill();

                    if (interviewer != interviewerArr.GetInterviewerByDBId(interviewer.DBId))
                    {
                        if (interviewer.Update())
                        {
                            interviewerArr.Fill();

                            interviewer = interviewerArr.GetInterviewerByDBId(interviewer.DBId);

                            if (CurInterviewer.DBId == interviewer.DBId && !interviewer.Admin)
                            {
                                //the curent interviewer is no longer an admin.
                                this.Close();
                            }
                        }

                    }
                }

                InterviewerArrToForm();
                InterviewerToForm(interviewer);
            }
        }

        private bool CheckInterviewerForm()
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
                label_InterviewerDBID.Text = interviewer.DBId.ToString();
                checkBox_InterviewerAdmin.Checked = interviewer.Admin;
                textBox_InterviewerFirstName.Text = interviewer.FirstName;
                textBox_InterviewerLastName.Text = interviewer.LastName;
                textBox_InterviewerID.Text = interviewer.Id;
                CredentialsToForm(interviewer.Credentials);


            }
            else
            {
                label_InterviewerDBID.Text = "0";
                checkBox_InterviewerAdmin.Checked = false;
                textBox_InterviewerFirstName.Text = "";
                textBox_InterviewerLastName.Text = "";
                textBox_InterviewerID.Text = "";
                CredentialsToForm(null);
            }
        }

        private void CredentialsToForm(Credentials credentials)
        {
            if (credentials != null)
            {
                textBox_InterviewerUserName.Text = credentials.UserName;
                textBox_InterviewerPassword.Text = credentials.Password;
            }
            else
            {
                textBox_InterviewerUserName.Text = "";
                textBox_InterviewerPassword.Text = "";
            }
        }

        private void listBox_Interviewers_DoubleClick(object sender, EventArgs e)
        {
            InterviewerToForm((Interviewer)listBox_Interviewers.SelectedItem);
        }

        private void button_InterviewerDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(label_InterviewerDBID.Text);
            if (id != 0)
            {
                InterviewerArr interviewerArr = new InterviewerArr();
                interviewerArr.Fill();
                Interviewer interviewer = interviewerArr.GetInterviewerByDBId(id);

                if (interviewer == Interviewer.Empty)
                {
                    MessageBox.Show("לא נמצא מראיין למחיקה", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    return;
                }
                else
                {
                    if (MessageBox.Show("האם אתה בטוח שאתה רוצה למחוק את המראיין מהמערכת?\nפעולה זאת תמחוק גם את כל הציונים שהמראיין נתן ואינה ניתנת לשחזור!", "שגיאה", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == DialogResult.No)
                    {
                        return;
                    }
                }

                NomineeScoreTypeArr nomineeScoreTypeArr = new NomineeScoreTypeArr();
                nomineeScoreTypeArr.Fill();
                nomineeScoreTypeArr = nomineeScoreTypeArr.Filter(interviewer, Nominee.Empty, Position.Empty, DateTime.MinValue, DateTime.MaxValue);

                if (nomineeScoreTypeArr.DeleteArr())
                {
                    if (interviewer.Delete())
                    {
                        if (interviewer.Credentials.Delete())
                        {
                            MessageBox.Show("המראיין נמחק בהצלחה מהמערכת", "הצלחה!", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        }
                        else
                        {
                            MessageBox.Show("המראיין לא נמחק מהמערכת\nקרתה תקלה בזמן מחיקת המראיין", "תקלה!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        }
                    }
                    else
                    {
                        MessageBox.Show("המראיין לא נמחק מהמערכת\nקרתה תקלה בזמן מחיקת המראיין", "תקלה!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                }
                else
                {
                    MessageBox.Show("המראיין לא נמחק מהמערכת\nקרתה תקלה בזמן מחיקת המראיין", "תקלה!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }
        }

        private void button_InterviewerSearch_Click(object sender, EventArgs e)
        {
            Interviewer filter = FormToInterviewer();
            InterviewerArr interviewerArr = new InterviewerArr();
            interviewerArr.Fill();
            interviewerArr = interviewerArr.Filter(filter.FirstName, filter.LastName, filter.Id, Credentials.Empty);

            listBox_Interviewers.DataSource = interviewerArr;
            if (interviewerArr.Count > 0)
            {
                //There is a nominee standing by the filter
                InterviewerToForm(interviewerArr[0] as Interviewer);
            }
            else
            {
                //No nominee was found by the filter
                if (MessageBox.Show("אין אף מראיין התואם לנתונים שהכנסת.", "לא נמצא מראיין", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading) != DialogResult.OK)
                {
                    InterviewerToForm(null);
                }

            }
        }
        #endregion

        #region tabScoretype
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage_ScoreType)
            {
                InitializeScoreTypeTab();
            }
        }

        private void InitializeScoreTypeTab()
        {
            PositionArrToForm(Position.Empty);
            ScoreTypeArrToForm(ScoreType.Empty);
            KeyDown += Control_KeyDown;//Add the Control_KeyDown event to the form.
            AddKeyDownEvent(this.Controls);//Add the Control_KeyDown event to all of the controls on the form.
            AdminTools_Form_InputLanguageChanged(null, null);//Check the current language.
            CapsLockCheck(); //Check for the state of the CapsLk.
        }

        private void button_ClearScoreType_Click(object sender, EventArgs e)
        {
            ScoreTypeToForm(null);
            listBox_ScoreType.ClearSelected();
        }

        private void listBox_ScoreType_DoubleClick(object sender, EventArgs e)
        {
            ScoreTypeArr scoreTypearr = new ScoreTypeArr();
            scoreTypearr.Fill();

            if (!scoreTypearr.IsContains(textBox_ScoreTypeName.Text) && CheckScoreTypeForm())
            {

                //There is a valid scoreType to insert that will be erased.
                DialogResult dr = MessageBox.Show("המידע שהכנסת יכול להתווסף כקריטריון\nהאם אתה רוצה לשמור אותו?", "אזהרה!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                if (dr == DialogResult.No)
                {
                    ScoreTypeToForm(listBox_ScoreType.SelectedItem as ScoreType);
                    CheckScoreTypeForm();
                }
                else if (dr == DialogResult.Yes)
                {
                    button_SaveScoreType_Click(button_InterViewerSave, EventArgs.Empty);
                    ScoreTypeToForm(listBox_ScoreType.SelectedItem as ScoreType);
                    CheckScoreTypeForm();
                }
            }
            else
            {
                ScoreTypeToForm(listBox_ScoreType.SelectedItem as ScoreType);
                CheckScoreTypeForm();
            }
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.CapsLock)
            {
                //Only if the CapsLK key was pressed, then call the method.
                CapsLockCheck();
            }
        }

        private void button_SaveScoreType_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            if (!CheckScoreTypeForm())
            {
                //The entered information is not valid.
                dialogResult = MessageBox.Show("המידע שסיפקת אינו תקין.\nאנא תקן את השדות האדומים על מנת להמשיך", "אזהרה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }

            else
            {
                //The information was valid

                ScoreType scoreType = FormToScoreType();//Make a scoreType object from the information on the form.

                if (scoreType.Id == 0)
                {
                    //insert
                    ScoreTypeArr oldScoreTypeArr = new ScoreTypeArr();
                    oldScoreTypeArr.Fill();
                    if (!oldScoreTypeArr.IsContains(scoreType.Id))
                    {
                        if (scoreType.Insert())//Try to insert the new scoreType to the database.
                        {
                            //The insertion of the scoreType data was successfull.
                            ScoreTypeArr scoreTypeArr = new ScoreTypeArr();
                            scoreTypeArr.Fill();
                            scoreType = scoreTypeArr.GetScoreTypeWithMaxId();
                            ScoreTypeArrToForm(scoreType);


                            dialogResult = MessageBox.Show("הקריטריון נוסף בהצלחה", "יאי!", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        }
                        else
                        {
                            //There was a problem insreting the data to the database.
                            dialogResult = MessageBox.Show("קרתה תקלה בעת שמירת הקריטריון בבסיס הנתונים", "תקלה", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        }
                    }
                    else
                    {
                        dialogResult = MessageBox.Show("הקריטריון שאתה מנסה להוסיף כבר קיים במערכת!", "הפעולה נמנעה", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                }
                else
                {
                    //update
                    ScoreTypeArr scoreTypeArr = new ScoreTypeArr();
                    scoreTypeArr.Fill();
                    if (scoreType != scoreTypeArr.GetScoreTypeById(scoreType.Id))
                    {
                        //if there is any change
                        if (scoreType.Update())
                        {
                            scoreTypeArr = new ScoreTypeArr();
                            scoreTypeArr.Fill();
                            ScoreTypeArrToForm(scoreTypeArr.GetScoreTypeById(scoreType.Id));
                            dialogResult = MessageBox.Show("הקריטריון עודכן בהצלחה", "יאי!", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        }
                        else
                            dialogResult = MessageBox.Show("קרתה תקלה בעת עדכון הקריטריון בבסיס הנתונים", "תקלה", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                    else
                    {
                        dialogResult = DialogResult.OK;
                    }
                }
            }

            //MessageBox results actions:
            switch (dialogResult)
            {
                case DialogResult.OK://Do nothing
                    break;

                case DialogResult.Cancel://Clear all of the text and "restart".
                    {
                        ScoreTypeToForm(null);
                        break;
                    }

                case DialogResult.Abort://Close the form
                    {
                        Environment.Exit(0);
                        break;
                    }

                case DialogResult.Retry:
                    {
                        button_SaveScoreType_Click(null, null);//Try again.
                        break;
                    }

                case DialogResult.Ignore://Do nothing.
                    break;

                default:
                    break;
            }

        }

        private void AdminTools_Form_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        {
            InputLanguage myCurrentLang = InputLanguage.CurrentInputLanguage;
            label_Language.Text = myCurrentLang.Culture.Name.ToLower();
        }

        private void textBox_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsHeLetter(e.KeyChar) && !IsEnLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != ' ')
            {
                //If the pressed key is not a letter - Hebrew or English, or a Control Key
                //or a Hyphen or a Space char, then don't enter it to the text of the textBox.
                e.KeyChar = char.MinValue;
            }
            else
            {
                //If the key was OK, then disable the not valid sign.
                (sender as Control).BackColor = Color.White;
            }
        }

        private void textBox_FilterScoreType_KeyPress(object sender, KeyPressEventArgs e)

        {
            if (!IsHeLetter(e.KeyChar) && !IsEnLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != ' ')
            {
                //If the pressed key is not a letter - Hebrew or English, or a Control Key
                //or a Hyphen or a Space char, then don't enter it to the text of the textBox.
                e.KeyChar = char.MinValue;
            }
        }

        private void textBox_FilterScoreType_TextChanged(object sender, EventArgs e)

        {
            ScoreTypeArr scoreTypeArr = new ScoreTypeArr();
            scoreTypeArr.Fill();

            scoreTypeArr = scoreTypeArr.Filter(
                comboBox_FilterPosition.SelectedItem != null ? comboBox_FilterPosition.SelectedItem as Position : Position.Empty, textBox_FilterScoreType.Text);

            listBox_ScoreType.DataSource = scoreTypeArr;
            listBox_ScoreType.ValueMember = "Id";
            listBox_ScoreType.DisplayMember = "NameWithPosition";
        }

        private void textBox_Name_Leave(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text != "")
            {
                string output = "";
                string[] raw = t.Text.ToLower().Split(' ');
                for (int i = 0; i < raw.Length; i++)
                {
                    if (raw[i] != "")
                    {
                        output += char.ToUpper(raw[i][0]) + raw[i].Substring(1) + " ";
                    }
                }
                t.Text = output.Remove(output.Length - 1);
            }
            CheckScoreTypeForm();
        }


        private void ScoreTypeToForm(ScoreType scoreType)
        {

            if (scoreType != null && scoreType != ScoreType.Empty)
            {
                label_ScoreTypeId.Text = scoreType.Id.ToString();
                textBox_ScoreTypeName.Text = scoreType.Name;
                comboBox_ScoreTypePosition.SelectedValue = scoreType.Position.Id;
            }
            else
            {
                //Reset the text and flags of the input fields.
                label_ScoreTypeId.Text = "0";
                textBox_ScoreTypeName.Text = "";
                comboBox_ScoreTypePosition.SelectedValue = 0;

                textBox_ScoreTypeName.BackColor = Color.White;
            }
        }

        public void PositionArrToForm(Position curPosition)
        {
            PositionArr positionArr = new PositionArr();
            positionArr.Fill();
            positionArr.Insert(0, Position.Empty);

            comboBox_ScoreTypePosition.DataSource = positionArr;
            comboBox_ScoreTypePosition.ValueMember = "Id";
            comboBox_ScoreTypePosition.DisplayMember = "Name";
            comboBox_ScoreTypePosition.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_ScoreTypePosition.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (curPosition != null)
            {
                comboBox_ScoreTypePosition.SelectedValue = curPosition.Id;
            }
            else
            {
                comboBox_ScoreTypePosition.SelectedValue = 0;
            }

            PositionArr filterPositionArr = new PositionArr();
            filterPositionArr.Fill();
            filterPositionArr.Insert(0, Position.Empty);
            comboBox_FilterPosition.DataSource = filterPositionArr;
            comboBox_FilterPosition.ValueMember = "Id";
            comboBox_FilterPosition.DisplayMember = "Name";
            comboBox_FilterPosition.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_FilterPosition.AutoCompleteSource = AutoCompleteSource.ListItems;

        }

        private void ScoreTypeArrToForm(ScoreType curScoreType)
        {
            ScoreTypeArr scoreTypeArr = new ScoreTypeArr();
            scoreTypeArr.Fill();

            listBox_ScoreType.DataSource = scoreTypeArr;
            listBox_ScoreType.ValueMember = "Id";
            listBox_ScoreType.DisplayMember = "NameWithPosition";

            if (curScoreType != null)
            {
                listBox_ScoreType.SelectedValue = curScoreType.Id;
            }
            else
            {
                listBox_ScoreType.ClearSelected();
            }
            ScoreTypeToForm(curScoreType);
        }

        private bool Text_Check_Length(Control sender, bool isBiggerThan, int num)
        {
            if (isBiggerThan)
            {
                if (sender.Text.Length < num)
                {
                    sender.BackColor = Color.Red;
                    return false;
                }
                else
                {
                    sender.BackColor = Color.White;
                    return true;
                }

            }
            else
            {
                if (sender.Text.Length != num)
                {
                    sender.BackColor = Color.Red;
                    return false;
                }

                else
                {
                    sender.BackColor = Color.White;
                    return true;
                }

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

        private bool CheckScoreTypeForm()
        {                                                       //מחזירה האם הטופס תקין מבחינת שדות החובה
            return Text_Check_Length(textBox_ScoreTypeName, true, 2);
        }

        private bool IsEnLetter(char c)
        {
            return ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'));
        }

        private bool IsHeLetter(char c)
        {
            return c >= 'א' && c <= 'ת';
        }

        private void CapsLockCheck()
        {
            if (IsKeyLocked(Keys.CapsLock))
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

        public ScoreType FormToScoreType()
        {
            ScoreType scoreType = new ScoreType();
            //insert the data to the object
            scoreType.Id = int.Parse(label_ScoreTypeId.Text);
            scoreType.Name = textBox_ScoreTypeName.Text;
            scoreType.Position = comboBox_ScoreTypePosition.SelectedItem as Position;

            return scoreType;
        }

        private void label_ScoreTypeId_TextChanged(object sender, EventArgs e)

        {
            int id = int.Parse(label_ScoreTypeId.Text);
            if (id != 0)
            {
                groupBox_ScoreType.Text = "ערוך קריטריון קיים";
            }
            else
            {
                groupBox_ScoreType.Text = "הוסף קריטריון חדש";
            }
        }

        private void button_DeleteScoreType_Click(object sender, EventArgs e)

        {
            if (label_ScoreTypeId.Text == "0")
            {
                MessageBox.Show("לא נבחר קריטריון למחיקה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                return;
            }


            //remove the scoreType
            ScoreTypeArr scoreTypeArr = new ScoreTypeArr();
            scoreTypeArr.Fill();
            ScoreType scoreType = scoreTypeArr.GetScoreTypeById(int.Parse(label_ScoreTypeId.Text));

            if (scoreType == ScoreType.Empty)
            {
                MessageBox.Show("קרתה תקלה במציאת הקריטריון בבסיס הנתונים.\nאנא סגור והדלק את התוכנה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                return;
            }

            if (MessageBox.Show("האם אתה בטוח שאתה רוצה למחוק את הקריטריון שבחרת?\nפעולה זאת הינה בלתי הפיכה!", "אזהרה", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //delete from the connection table
                NomineeScoreTypeArr nomineeScoeTypeArr = new NomineeScoreTypeArr();
                nomineeScoeTypeArr.Fill();
                nomineeScoeTypeArr = nomineeScoeTypeArr.Filter(Interviewer.Empty, Nominee.Empty, scoreType, 0, DateTime.MinValue, DateTime.MaxValue);

                nomineeScoeTypeArr.DeleteArr();

                //delete from it's table
                if (scoreType.Delete())
                {
                    ScoreTypeToForm(null);
                    ScoreTypeArrToForm(null);
                    MessageBox.Show("הקריטריון נמחק בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else
                {
                    MessageBox.Show("ישנה תקלה במחיקת הקריטריון מבסיס הנתונים.\n הקריטריון לא נמחק כלל.", "תקלה!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }

        }
        #endregion

        private void comboBox_FilterPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScoreTypeArr scoreTypeArr = new ScoreTypeArr();
            scoreTypeArr.Fill();

            scoreTypeArr = scoreTypeArr.Filter(
                comboBox_FilterPosition.SelectedItem != null ? comboBox_FilterPosition.SelectedItem as Position : Position.Empty, textBox_FilterScoreType.Text);

            listBox_ScoreType.DataSource = scoreTypeArr;
            listBox_ScoreType.ValueMember = "Id";
            listBox_ScoreType.DisplayMember = "NameWithPosition";
        }

        private void button_ClearFilterScoreType_Click(object sender, EventArgs e)
        {
            comboBox_FilterPosition.SelectedValue = 0;
            textBox_FilterScoreType.Clear();
            listBox_ScoreType.SelectedValue = 0;
        }
    }
}
