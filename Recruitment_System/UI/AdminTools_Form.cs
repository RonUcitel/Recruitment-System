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

        #region tab interviewers
        private void button_InterviewerClear_Click(object sender, EventArgs e)
        {
            InterviewerToForm(Interviewer.Empty);
        }


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

                InterviewCriterionArr interviewCriterionArr = new InterviewCriterionArr();
                interviewCriterionArr.Fill();
                interviewCriterionArr = interviewCriterionArr.Filter(interviewer, Nominee.Empty, Position.Empty, DateTime.MinValue, DateTime.MaxValue);

                if (interviewCriterionArr.DeleteArr())
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

        #region tabCriterion
        private void button_ClearFilterCriterion_Click(object sender, EventArgs e)
        {
            comboBox_PositionTypeFilter.SelectedIndex = 0;
            textBox_FilterCriterion.Clear();
            listBox_Criterion.SelectedValue = 0;
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage_Criterion)
            {
                InitializeCriterionTab();
            }
        }


        private void InitializeCriterionTab()
        {
            PositionTypeArrToForm();
            CriterionArrToForm(Criterion.Empty);
            KeyDown += Control_KeyDown;//Add the Control_KeyDown event to the form.
            AddKeyDownEvent(this.Controls);//Add the Control_KeyDown event to all of the controls on the form.
            AdminTools_Form_InputLanguageChanged(null, null);//Check the current language.
            CapsLockCheck(); //Check for the state of the CapsLk.
        }

        private void button_ClearCriterion_Click(object sender, EventArgs e)
        {
            CriterionToForm(null);
            listBox_Criterion.ClearSelected();
        }

        private void listBox_Criterion_DoubleClick(object sender, EventArgs e)
        {
            CriterionArr criterionarr = new CriterionArr();
            criterionarr.Fill();

            if (!criterionarr.IsContains(textBox_CriterionName.Text) && CheckCriterionForm())
            {

                //There is a valid criterion to insert that will be erased.
                DialogResult dr = MessageBox.Show("המידע שהכנסת יכול להתווסף כקריטריון\nהאם אתה רוצה לשמור אותו?", "אזהרה!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                if (dr == DialogResult.No)
                {
                    CriterionToForm(listBox_Criterion.SelectedItem as Criterion);
                    CheckCriterionForm();
                }
                else if (dr == DialogResult.Yes)
                {
                    button_SaveCriterion_Click(button_InterViewerSave, EventArgs.Empty);
                    CriterionToForm(listBox_Criterion.SelectedItem as Criterion);
                    CheckCriterionForm();
                }
            }
            else
            {
                CriterionToForm(listBox_Criterion.SelectedItem as Criterion);
                CheckCriterionForm();
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

        private void button_SaveCriterion_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            if (!CheckCriterionForm())
            {
                //The entered information is not valid.
                dialogResult = MessageBox.Show("המידע שסיפקת אינו תקין.\nאנא תקן את השדות האדומים על מנת להמשיך", "אזהרה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }

            else
            {
                //The information was valid

                Criterion criterion = FormToCriterion();//Make a criterion object from the information on the form.

                if (criterion.Id == 0)
                {
                    //insert
                    CriterionArr oldCriterionArr = new CriterionArr();
                    oldCriterionArr.Fill();
                    if (!oldCriterionArr.IsContains(criterion.Id))
                    {
                        if (criterion.Insert())//Try to insert the new criterion to the database.
                        {
                            //The insertion of the criterion data was successfull.
                            CriterionArr criterionArr = new CriterionArr();
                            criterionArr.Fill();
                            criterion = criterionArr.GetCriterionWithMaxId();
                            CriterionArrToForm(criterion);


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
                    CriterionArr criterionArr = new CriterionArr();
                    criterionArr.Fill();
                    if (criterion != criterionArr.GetCriterionById(criterion.Id))
                    {
                        //if there is any change
                        if (criterion.Update())
                        {
                            criterionArr = new CriterionArr();
                            criterionArr.Fill();
                            CriterionArrToForm(criterionArr.GetCriterionById(criterion.Id));
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
                        CriterionToForm(null);
                        break;
                    }

                case DialogResult.Abort://Close the form
                    {
                        Environment.Exit(0);
                        break;
                    }

                case DialogResult.Retry:
                    {
                        button_SaveCriterion_Click(null, null);//Try again.
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

        private void textBox_FilterCriterion_KeyPress(object sender, KeyPressEventArgs e)

        {
            if (!IsHeLetter(e.KeyChar) && !IsEnLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != ' ')
            {
                //If the pressed key is not a letter - Hebrew or English, or a Control Key
                //or a Hyphen or a Space char, then don't enter it to the text of the textBox.
                e.KeyChar = char.MinValue;
            }
        }

        private void textBox_FilterCriterion_TextChanged(object sender, EventArgs e)

        {
            CriterionArr criterionArr = new CriterionArr();
            criterionArr.Fill();

            criterionArr = criterionArr.Filter(
                comboBox_PositionTypeFilter.SelectedItem != null ? comboBox_PositionTypeFilter.SelectedItem as PositionType : PositionType.Empty, textBox_FilterCriterion.Text);

            listBox_Criterion.DataSource = criterionArr;
            listBox_Criterion.ValueMember = "Id";
            listBox_Criterion.DisplayMember = "NameWithPosition";
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
            CheckCriterionForm();
        }


        private void CriterionToForm(Criterion criterion)
        {

            if (criterion != null && criterion != Criterion.Empty)
            {
                label_CriterionId.Text = criterion.Id.ToString();
                textBox_CriterionName.Text = criterion.Name;
                /*comboBox_CriterionPosition.SelectedValue = criterion.Position.Id;*/
            }
            else
            {
                //Reset the text and flags of the input fields.
                label_CriterionId.Text = "0";
                textBox_CriterionName.Text = "";
                comboBox_PositionTypeFilter.SelectedValue = 0;

                textBox_CriterionName.BackColor = Color.White;
            }
        }

        public void PositionTypeArrToForm()
        {
            PositionTypeArr positionTypeArr = new PositionTypeArr();
            positionTypeArr.Fill();
            positionTypeArr.Insert(0, PositionType.Empty);

            comboBox_PositionTypeFilter.DataSource = positionTypeArr;
            comboBox_PositionTypeFilter.ValueMember = "Id";
            comboBox_PositionTypeFilter.DisplayMember = "Name";
            comboBox_PositionTypeFilter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_PositionTypeFilter.AutoCompleteSource = AutoCompleteSource.ListItems;

            comboBox_PositionTypeFilter.SelectedValue = 0;

        }

        private void CriterionArrToForm(Criterion curCriterion)
        {
            CriterionArr criterionArr = new CriterionArr();
            criterionArr.Fill();

            listBox_Criterion.DataSource = criterionArr;
            listBox_Criterion.ValueMember = "Id";
            listBox_Criterion.DisplayMember = "NameWithPosition";

            if (curCriterion != null)
            {
                listBox_Criterion.SelectedValue = curCriterion.Id;
            }
            else
            {
                listBox_Criterion.ClearSelected();
            }
            CriterionToForm(curCriterion);
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

        private bool CheckCriterionForm()
        {                                                       //מחזירה האם הטופס תקין מבחינת שדות החובה
            return Text_Check_Length(textBox_CriterionName, true, 2);
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

        public Criterion FormToCriterion()
        {
            Criterion criterion = new Criterion();
            //insert the data to the object
            criterion.Id = int.Parse(label_CriterionId.Text);
            criterion.Name = textBox_CriterionName.Text;
            //criterion.Position = comboBox_CriterionPosition.SelectedItem as PositionType;

            return criterion;
        }

        private void label_CriterionId_TextChanged(object sender, EventArgs e)

        {
            int id = int.Parse(label_CriterionId.Text);
            if (id != 0)
            {
                groupBox_Criterion.Text = "ערוך קריטריון קיים";
            }
            else
            {
                groupBox_Criterion.Text = "הוסף קריטריון חדש";
            }
        }

        private void button_DeleteCriterion_Click(object sender, EventArgs e)

        {
            if (label_CriterionId.Text == "0")
            {
                MessageBox.Show("לא נבחר קריטריון למחיקה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                return;
            }


            //remove the criterion
            CriterionArr criterionArr = new CriterionArr();
            criterionArr.Fill();
            Criterion criterion = criterionArr.GetCriterionById(int.Parse(label_CriterionId.Text));

            if (criterion == Criterion.Empty)
            {
                MessageBox.Show("קרתה תקלה במציאת הקריטריון בבסיס הנתונים.\nאנא סגור והדלק את התוכנה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                return;
            }

            if (MessageBox.Show("האם אתה בטוח שאתה רוצה למחוק את הקריטריון שבחרת?\nפעולה זאת הינה בלתי הפיכה!", "אזהרה", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //delete from the connection table
                InterviewCriterionArr nomineeScoeTypeArr = new InterviewCriterionArr();
                nomineeScoeTypeArr.Fill();
                nomineeScoeTypeArr = nomineeScoeTypeArr.Filter(Interviewer.Empty, Nominee.Empty, criterion, 0, DateTime.MinValue, DateTime.MaxValue);

                nomineeScoeTypeArr.DeleteArr();

                //delete from it's table
                if (criterion.Delete())
                {
                    CriterionToForm(null);
                    CriterionArrToForm(null);
                    MessageBox.Show("הקריטריון נמחק בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else
                {
                    MessageBox.Show("ישנה תקלה במחיקת הקריטריון מבסיס הנתונים.\n הקריטריון לא נמחק כלל.", "תקלה!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }

        }
        #endregion

    }
}
