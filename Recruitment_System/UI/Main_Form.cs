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
using System.IO;
using System.Diagnostics;

namespace Recruitment_System.UI
{
    public partial class MainForm : Form
    {
        private City lastSelectedcomboBox_CityIndex = City.Empty;
        public MainForm()
        {
            InitializeComponent();
            label_ShowDisabled.Hide();
            Icon = Properties.Resources.allnet;
            SetUpNomineeArrShowMenu();
            ChangeShowNomineeArrCurState(NomineeArrState.ShowEnabledOnly);
            NomineeArrToForm();
            CityArrToForm(null);
            SetButton_ChangeDisabled(true);
            /*-------------------------->>>>>>>>>>>>>>>>*/
            textBox_Positions.Tag = new PositionArr();
            /*<<<<<<<<<<<<<<<<--------------------------*/
            SetPositionTextBoxAndToolTip(new PositionArr());
        }


        #region events


        private void label_DBID_TextChanged(object sender, EventArgs e)
        {
            //the selected nominee had changed
            SetButton_ChangeDisabled(label_ShowDisabled.Visible);
        }


        private void רשימותלוגToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log_Form log_Form = new Log_Form(int.Parse(label_DBID.Text));
            log_Form.Show();
        }


        private void עריםToolStripMenuItem_Click(object sender, EventArgs e)
        {
            City_Form cF = new City_Form(lastSelectedcomboBox_CityIndex);
            cF.StartPosition = FormStartPosition.CenterParent;
            cF.ShowDialog();
            CityArrToForm(cF.SelectedCity);

            lastSelectedcomboBox_CityIndex = (comboBox_City.SelectedItem as City);
        }


        private void button_ShowPositions_Click(object sender, EventArgs e)
        {
            PositionArr positionArr = textBox_Positions.Tag as PositionArr;
            Nominee nom;
            if (label_DBID.Text != "0")
            {
                NomineeArr nomineeArr = new NomineeArr();
                nomineeArr.Fill();
                nom = nomineeArr.GetNomineeByDBId(int.Parse(label_DBID.Text));
            }
            else
            {
                nom = Nominee.Empty;
            }


            NomineesPosition_Form npForm;

            if ((textBox_Positions.Tag as PositionArr).Count == 0)
            {
                npForm = new NomineesPosition_Form(nom);
            }
            else
            {
                npForm = new NomineesPosition_Form(positionArr);
            }

            npForm.ShowDialog();

            positionArr = npForm.ChosenPositionArr;
            textBox_Positions.Tag = positionArr;

            SetPositionTextBoxAndToolTip(positionArr);
        }


        private void עלתוכנהזוToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }


        private void משרותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Position_Form pF = new Position_Form();
            pF.StartPosition = FormStartPosition.CenterParent;
            pF.ShowDialog();
        }


        private void button_Show_Log_Click(object sender, EventArgs e)
        {
            Log_Form log_Form = new Log_Form(int.Parse(label_DBID.Text));
            log_Form.Show();
        }


        private void textBox_Email_Leave(object sender, EventArgs e)
        {
            textBox_Email.Text = textBox_Email.Text.ToLower();
        }


        private void textBox_Email_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (HasNonASCIIChars(e.KeyChar))
            {
                e.KeyChar = char.MinValue;
            }
        }


        private void button_ChangeDisabled_Click(object sender, EventArgs e)
        {
            Nominee nom = FormToNominee();
            if (nom.DBId == 0)
            {
                MessageBox.Show("לא נבחר לקוח תקין!", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (!nom.Disabled)
            {
                if (MessageBox.Show("האם אתה בטוח שאתה רוצה להפוך את המועמד ללא זמין?\nהאם אתה בטוח שברצונך להמשיך?", "אזהרה!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == DialogResult.Yes)
                {
                    //make this nominee disabled

                    nom.Disable();

                    NomineeArr nomineearr = new NomineeArr();
                    nomineearr.Fill(GetCurNomineeArrState());

                    listBox_Nominee.DataSource = nomineearr;
                    NomineeToForm(null);
                }
            }
            else
            {
                if (MessageBox.Show("האם אתה בטוח שאתה רוצה להפוך את המועמד לזמין?\nהאם אתה בטוח שברצונך להמשיך?", "אזהרה!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == DialogResult.Yes)
                {
                    //make this nominee enabled

                    nom.Enable();

                    NomineeArr nomineearr = new NomineeArr();
                    nomineearr.Fill(GetCurNomineeArrState());

                    listBox_Nominee.DataSource = nomineearr;
                    NomineeToForm(null);
                }
            }
        }


        private void View_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem x = sender as ToolStripMenuItem;

            ChangeShowNomineeArrCurState((NomineeArrState)x.Tag);

            if (tabControl_Main.SelectedTab == tabPage_PositionNomineeChart)
            {
                DataToChart(GetCurNomineeArrState());
            }
            else if (tabControl_Main.SelectedTab == tabPage_PositionNomineeTable)
            {
                PositionNomineeArrToTable(GetCurNomineeArrState());
            }
        }


        private void comboBox_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_City.SelectedItem != null)
            {
                if (comboBox_City.SelectedItem.ToString() == "+")
                {
                    if (comboBox_City.Focused)
                    {
                        City_Form cF = new City_Form(lastSelectedcomboBox_CityIndex);
                        cF.StartPosition = FormStartPosition.CenterParent;
                        cF.ShowDialog();
                        CityArrToForm(cF.SelectedCity);
                    }
                }

                lastSelectedcomboBox_CityIndex = (comboBox_City.SelectedItem as City);
            }

        }


        private void comboBox_City_Leave(object sender, EventArgs e)
        {
            CityArr cityArr = new CityArr();
            cityArr.Fill();
            if (!cityArr.IsContains(comboBox_City.Text))//Contains(comboBox_City.Text)
            {
                comboBox_City.BackColor = Color.Red;
            }
            else
            {
                comboBox_City.BackColor = Color.White;
            }
        }


        private void button_Add_CV_DragLeave(object sender, EventArgs e)
        {
            if (button_Add_CV.Tag == null)
            {
                button_Add_CV.Text = "הוסף קורות חיים";
                button_Add_CV.BackColor = SystemColors.ButtonFace;
                button_Add_CV.UseVisualStyleBackColor = true;

            }
            else
            {
                button_Add_CV.BackColor = Color.Green;
                button_Add_CV.Text = "ישנם קורות חיים";
            }

        }


        private void comboBox_CellAreaCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.KeyChar = char.MinValue;
            }
            else
            {
                comboBox_CellAreaCode.BackColor = Color.White;

                if (comboBox_CellAreaCode.Text.Length >= 2 && comboBox_CellAreaCode.SelectionLength == 0 && !char.IsControl(e.KeyChar))
                {
                    //If the key was OK and there will be 3 digits after this method returns, then move the focus to the next textBox.


                    //It can be that the next char will be in the textBox_Cel, so save it in a container.
                    char c = e.KeyChar;
                    e.KeyChar = char.MinValue;
                    if (comboBox_CellAreaCode.Text.Length > 2)
                    {
                        textBox_Cel.Text += c;//Add the last digit to the textBox_Cel.
                        textBox_Cel.Select(textBox_Cel.TextLength, textBox_Cel.TextLength);//move the curor to the end of the text within the textBox_Cel;
                        textBox_Cel.BackColor = Color.White;
                    }
                    else
                    {
                        comboBox_CellAreaCode.Text += c;//Add the last digit to the comboBox_CellAreaCode.
                    }
                    textBox_Cel.Focus();//move the focus to textBox_Cel when comboBox_CellAreaCode is full.
                }
            }
        }


        private void textBox_Cel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.KeyChar = char.MinValue;
            }
            else if (e.KeyChar == (char)8 && textBox_Cel.TextLength <= 1)
            {
                comboBox_CellAreaCode.Focus();
                comboBox_CellAreaCode.SelectionStart = comboBox_CellAreaCode.Text.Length;
                comboBox_CellAreaCode.SelectionLength = 0;
            }
        }


        private void button_Save_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            if (!CheckForm())
            {
                //The entered information is not valid.
                dialogResult = MessageBox.Show("The information you entered is not valid.\nPlease check the red fields for problems.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }

            else
            {
                //The information was valid

                Nominee nominee = FormToNominee();//Make a Nominee object from the information on the form.


                PositionNomineeArr positionNomineeArr_New;

                if (nominee.DBId == 0)
                {
                    if (nominee.Insert())//Try to insert the new Nominee to the database.
                    {
                        //The insertion of the nominee data was successfull.

                        positionNomineeArr_New = FormToPositionNomineeArr(nominee);

                        //מוסיפים את הפריטים החדשים להזמנה

                        if (!positionNomineeArr_New.Insert())
                        {
                            MessageBox.Show("הייתה שגיעה בעדכון המשרות\nאנא נסה שנית.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                            SetPositionTextBoxAndToolTip(new PositionArr());
                        }

                        //Check the cv file:
                        NomineeArr nomineearr = new NomineeArr();
                        nomineearr.Fill(GetCurNomineeArrState());
                        SetCV(nomineearr.MaxNomineeDBId().DBId);


                        NomineeArrToForm();

                        SetLastChangedTextbox(nominee.DBId);

                        dialogResult = MessageBox.Show("The Nominee was ADDED successfully", "Yay!", MessageBoxButtons.OK);
                        listBox_Nominee.SelectedItem = listBox_Nominee.Items[listBox_Nominee.Items.Count - 1];
                    }
                    else
                    {
                        //There was a problem insreting the data to the database.
                        dialogResult = MessageBox.Show("There was a problem ADDING the nominee to the database", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //it is an update                  

                    //if there is a change in the data

                    if (nominee.Update())
                    {

                        positionNomineeArr_New = FormToPositionNomineeArr(nominee);

                        //מוחקים את הפריטים הקודמים של ההזמנה
                        //אוסף כלל הזוגות - הזמנה-פריט

                        PositionNomineeArr positionNomineeArr_Old = new PositionNomineeArr();
                        positionNomineeArr_Old.Fill();

                        //סינון לפי ההזמנה הנוכחית

                        positionNomineeArr_Old = positionNomineeArr_Old.Filter(nominee, Position.Empty);

                        //מחיקת כל הפריטים באוסף ההזמנה-פריט של ההזמנה הנוכחית

                        positionNomineeArr_Old.Delete();

                        //מוסיפים את הפריטים החדשים להזמנה

                        positionNomineeArr_New.Insert();



                        //Check the cv file:

                        dialogResult = MessageBox.Show("The Nominee was UPDATED successfully", "Yay!", MessageBoxButtons.OK);
                    }
                    else
                        dialogResult = MessageBox.Show("There was a problem UPDATING the nominee to the database", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

                }
            }

            //MessageBox results actions:
            switch (dialogResult)
            {
                case DialogResult.OK://Do nothing
                    break;

                case DialogResult.Cancel://Clear all of the text and "restart".
                    {
                        NomineeToForm(null);
                        break;
                    }

                case DialogResult.Abort://Close the form
                    {
                        Environment.Exit(0);
                        break;
                    }

                case DialogResult.Retry:
                    {
                        button_Save_Click(null, null);//Try again.
                        break;
                    }

                case DialogResult.Ignore://Do nothing.
                    break;

                default:
                    break;
            }

            NomineeArrToForm();
        }


        private void button_File_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
                button_Add_CV.Text = "שחרר כאן!";
                button_Add_CV.BackColor = SystemColors.MenuHighlight;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }


        private void button_File_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            for (int i = 0; i < paths.Length; i++)
            {
                //get the first file which is in the pdf or docx format.
                if (paths[i].EndsWith(".docx") || paths[i].EndsWith(".pdf"))
                {
                    //file accepted
                    button_Add_CV.Tag = paths[i];
                    if (FormToNominee().DBId != 0)
                    {
                        SetCV(FormToNominee().DBId);
                    }
                    button_Add_CV.BackColor = Color.Green;
                    button_Add_CV.Text = "ישנם קורות חיים";
                    return;
                }
            }
        }


        private void listBox_Nominee_DoubleClick(object sender, EventArgs e)
        {
            NomineeToForm((Nominee)listBox_Nominee.SelectedValue);
        }


        private void button_Search_Click(object sender, EventArgs e)
        {
            Nominee filter = FormToNominee();
            NomineeArr nomineeArr = new NomineeArr();
            nomineeArr.Fill(GetCurNomineeArrState());
            nomineeArr = nomineeArr.Filter(filter, null);
            listBox_Nominee.DataSource = nomineeArr;
            if (nomineeArr.Count > 0)
            {
                //There is a nominee standing by the filter
                NomineeToForm(nomineeArr[0] as Nominee);
            }
            else
            {
                //No nominee was found by the filter
                if (MessageBox.Show("There is no nominee matching the fields you filled. please check the values you entered.", "No Nominee was found", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                {
                    NomineeToForm(null);
                }

            }
        }


        private void button_Clear_Click(object sender, EventArgs e)
        {
            NomineeToForm(null);
            NomineeArr nomineeArr = new NomineeArr();
            nomineeArr.Fill(GetCurNomineeArrState());

            listBox_Nominee.DataSource = nomineeArr;
        }


        private void button_Add_CV_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Users\" + Environment.UserName + @"\Desktop";
                openFileDialog.Filter = "pdf files (*.pdf)|*.pdf|word files (*.docx)|*.docx";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                //Get the path of specified file
                button_Add_CV.Tag = openFileDialog.FileName;
                if (FormToNominee().DBId != 0)
                {
                    SetCV(FormToNominee().DBId);
                }
            }
        }


        private void button_Remove_CV_Click(object sender, EventArgs e)
        {
            button_Add_CV.Tag = null;
            int dbid = FormToNominee().DBId;
            SetCV(dbid);
            button_Add_CV.Text = "הוסף קורות חיים";
            button_Add_CV.BackColor = SystemColors.ButtonFace;
            button_Add_CV.UseVisualStyleBackColor = true;

        }


        private void button_Delete_Click(object sender, EventArgs e)
        {
            Nominee delete = FormToNominee();
            if (delete.DBId == 0)
            {
                MessageBox.Show("לא נבחר לקוח למחיקה!", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("פעולה זאת הינה בלתי ניתנת לשיחזור!\nהאם אתה בטוח שברצונך להמשיך?", "אזהרה!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == DialogResult.Yes)
                {
                    //delete this nominee from the database

                    delete.Delete();

                    LogEntryArr logToDelete = new LogEntryArr();
                    logToDelete.Fill();
                    logToDelete = logToDelete.Filter(delete.DBId, DateTime.MinValue, "");

                    for (int i = 0; i < logToDelete.Count; i++)
                    {
                        (logToDelete[i] as LogEntry).Delete();
                    }

                    NomineeArr nomineearr = new NomineeArr();
                    nomineearr.Fill(GetCurNomineeArrState());

                    listBox_Nominee.DataSource = nomineearr;
                    NomineeToForm(null);
                }
            }
        }


        private void textBox_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.KeyChar = char.MinValue;
        }


        #endregion


        #region public methods


        public Nominee FormToNominee()
        {
            Nominee nominee = new Nominee();//Create a new instance of the Nominee class.

            //insert the data to the object
            nominee.DBId = int.Parse(label_DBID.Text);
            nominee.Disabled = label_ShowDisabled.Visible;
            nominee.FirstName = textBox_FirstName.Text;
            nominee.LastName = textBox_LastName.Text;
            nominee.Id = textBox_ID.Text;
            nominee.Email = textBox_Email.Text;
            nominee.BirthYear = textBox_BirthYear.Text == "" ? 0 : int.Parse(textBox_BirthYear.Text);
            nominee.CellAreaCode = comboBox_CellAreaCode.Text;
            nominee.CellPhone = textBox_Cel.Text;
            nominee.City = comboBox_City.SelectedItem != null ? comboBox_City.SelectedItem as City : City.Empty;
            nominee.Match = (int)numericUpDown_Match.Value;
            nominee.Professionalism = (int)numericUpDown_Professionalism.Value;
            nominee.GeneralAssessment = (int)numericUpDown_GA.Value;

            return nominee;
        }


        public void CityArrToForm(City curCity)
        {
            CityArr cityArr = new CityArr();
            cityArr.Fill();
            cityArr.Insert(0, City.Empty);
            cityArr.Insert(1, City.AddingFormButton);

            comboBox_City.SelectedIndexChanged -= comboBox_City_SelectedIndexChanged;
            comboBox_City.DataSource = cityArr;
            comboBox_City.ValueMember = "Id";
            comboBox_City.DisplayMember = "Name";
            comboBox_City.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_City.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_City.SelectedIndexChanged += comboBox_City_SelectedIndexChanged;
            if (curCity != null)
            {
                comboBox_City.SelectedValue = curCity.Id;
            }
            else
            {
                comboBox_City.Text = "";
            }
        }


        #endregion


        #region private methods


        private void ChangeShowNomineeArrCurState(NomineeArrState state)
        {
            ToolStripMenuItem tool;
            for (int i = 0; i < הצגToolStripMenuItem.DropDownItems.Count; i++)
            {
                if (הצגToolStripMenuItem.DropDownItems[i] is ToolStripSeparator)
                {
                    break;
                }
                else if (הצגToolStripMenuItem.DropDownItems[i] is ToolStripMenuItem)
                {
                    tool = הצגToolStripMenuItem.DropDownItems[i] as ToolStripMenuItem;
                    if ((NomineeArrState)tool.Tag == state)
                    {
                        tool.Checked = true;
                    }
                    else
                    {
                        tool.Checked = false;
                    }
                }
            }
            NomineeArrToForm();

        }


        private NomineeArrState GetCurNomineeArrState()
        {
            foreach (ToolStripMenuItem item in הצגToolStripMenuItem.DropDownItems)
            {
                if (item.Checked)
                {
                    return (NomineeArrState)item.Tag;
                }
            }

            ChangeShowNomineeArrCurState(NomineeArrState.ShowEnabledOnly);
            return NomineeArrState.ShowEnabledOnly;
        }


        private void SetButton_ChangeDisabled(bool isDisabled)
        {
            if (isDisabled)
            {
                button_ChangeDisabled.Text = "הפוך לזמין";
                button_ChangeDisabled.BackColor = Color.FromArgb(128, 255, 128);
            }
            else
            {
                button_ChangeDisabled.Text = "הפוך ללא זמין";
                button_ChangeDisabled.BackColor = Color.FromArgb(255, 128, 128);
            }
        }


        private void SetPositionTextBoxAndToolTip(PositionArr positionArr)
        {
            if (positionArr == null)
            {
                textBox_Positions.Text = "נבחרו 0 משרות";
                toolTip_Positions.SetToolTip(textBox_Positions, "אף משרה לא נבחרה");
                return;
            }

            if (positionArr.Count == 0)
            {
                textBox_Positions.Text = "נבחרו 0 משרות";
                toolTip_Positions.SetToolTip(textBox_Positions, "אף משרה לא נבחרה");
            }
            else if (positionArr.Count == 1)
            {
                textBox_Positions.Text = "נבחרה משרה אחת";
                toolTip_Positions.SetToolTip(textBox_Positions, positionArr[0].ToString());
            }
            else
            {
                textBox_Positions.Text = "נבחרו " + positionArr.Count + " משרות";
                string positions = positionArr[0].ToString();
                for (int i = 1; i < positionArr.Count; i++)
                {
                    positions += /*", "*/"\n" + positionArr[i].ToString();
                }

                toolTip_Positions.SetToolTip(textBox_Positions, positions);
            }
        }


        private PositionNomineeArr FormToPositionNomineeArr(Nominee curNom)
        {

            //יצירת אוסף המוצרים להזמנה מהטופס
            //מייצרים זוגות של הזמנה-מוצר, ההזמנה - תמיד אותה הזמנה )הרי מדובר על הזמנה אחת(, המוצר - מגיע מרשימת
            //המוצרים שנבחרו
            PositionArr positionArr = (textBox_Positions.Tag as PositionArr);

            PositionNomineeArr positionNomineeArr = new PositionNomineeArr();
            //יצירת אוסף הזוגות הזמנה-מוצר
            PositionNominee positionNominee;
            //סורקים את כל הערכים בתיבת הרשימה של המוצרים שנבחרו להזמנה
            for (int i = 0; i < positionArr.Count; i++)
            {
                positionNominee = new PositionNominee();
                //ההזמנה הנוכחית היא ההזמנה לכל הזוגות באוסף
                positionNominee.Nominee = curNom;
                //מוצר נוכחי לזוג הזמנה-מוצר
                positionNominee.Position = positionArr[i] as Position;

                //הוספת הזוג הזמנה - מוצר לאוסף
                positionNomineeArr.Add(positionNominee);
            }
            return positionNomineeArr;
        }


        private void SetUpNomineeArrShowMenu()
        {
            מועמדיםזמיניםToolStripMenuItem.Tag = NomineeArrState.ShowEnabledOnly;
            מועמדיםלאזמיניםToolStripMenuItem.Tag = NomineeArrState.ShowDisabledOnly;
            כלהמועמדיםToolStripMenuItem.Tag = NomineeArrState.ShowAll;
        }


        private void SetLastChangedTextbox(int nomineeDBId)
        {
            if (nomineeDBId > 0)
            {
                LogEntryArr logEntryArr = new LogEntryArr();
                logEntryArr.Fill();
                logEntryArr = logEntryArr.Filter(nomineeDBId, DateTime.MinValue, "");

                LogEntry logEntry = logEntryArr.GetLogEntryWithMaxId();
                textBox_Last_Change.Text = logEntry.DateTime.ToString();
                toolTip_Last_Changed.SetToolTip(textBox_Last_Change, logEntry.Entry);

            }
            else
            {
                textBox_Last_Change.Text = "";
                toolTip_Last_Changed.SetToolTip(textBox_Last_Change, null);
            }
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


        private bool CheckForm()

        {                                                       //מחזירה האם הטופס תקין מבחינת שדות החובה
            bool flag = true;


            //First name - 1
            if (!Text_Check_Length(textBox_FirstName, true, 2))
                flag &= false;


            //Last name - 2
            if (!Text_Check_Length(textBox_LastName, true, 2))
                flag &= false;

            //city
            if (!(comboBox_City.DataSource as CityArr).IsContains(comboBox_City.Text))
            {
                flag &= false;
            }

            return flag;
        }


        private void NomineeToForm(Nominee nominee)
        {
            if (nominee != null)
            {
                SetLastChangedTextbox(nominee.DBId);
                label_ShowDisabled.Visible = nominee.Disabled;
                textBox_FirstName.Text = nominee.FirstName;
                textBox_LastName.Text = nominee.LastName;
                textBox_ID.Text = nominee.Id;
                textBox_Email.Text = nominee.Email;
                textBox_BirthYear.Text = nominee.BirthYear.ToString();
                comboBox_CellAreaCode.Text = nominee.CellAreaCode;
                textBox_Cel.Text = nominee.CellPhone;
                comboBox_City.SelectedValue = nominee.City.Id;
                numericUpDown_Match.Value = nominee.Match;
                numericUpDown_Professionalism.Value = nominee.Professionalism;
                numericUpDown_GA.Value = nominee.GeneralAssessment;

                PositionNomineeArr positionNomineeArr = new PositionNomineeArr();
                positionNomineeArr.Fill();
                positionNomineeArr = positionNomineeArr.Filter(nominee, Position.Empty);

                PositionArr positionArr = positionNomineeArr.ToPositionArr();

                textBox_Positions.Tag = positionArr;
                SetPositionTextBoxAndToolTip(positionArr);

                label_DBID.Text = nominee.DBId.ToString();


                (string path, string type) cv = GetCV(nominee.DBId);
                if (cv.path != "")
                {
                    button_Add_CV.BackColor = Color.Green;
                    button_Add_CV.Text = "ישנם קורות חיים";

                    //there is a cv file
                    if (cv.type == "pdf")
                    {
                        //the file is a pdf file
                        PDF_CV_Viewer.src = cv.path;
                    }
                    else
                    {
                        //the file is a docx file. open it with a word program.
                        PDF_CV_Viewer.src = null;
                        Process.Start(cv.path);
                    }
                }
                else
                {
                    //there is no file
                    button_Add_CV.Text = "הוסף קורות חיים";
                    button_Add_CV.BackColor = SystemColors.ButtonFace;
                    button_Add_CV.UseVisualStyleBackColor = true;
                }
            }
            else
            {
                comboBox_City.SelectedItem = null;
                SetPositionTextBoxAndToolTip(new PositionArr());
                //Reset the text and flags of the input fields.
                foreach (Control item in groupBox_PD.Controls)
                {
                    if (item is TextBox || item is ComboBox)
                    {
                        item.Text = "";
                        if (item.Name != "textBox_Last_Change")
                        {
                            item.BackColor = Color.White;
                        }

                    }
                }

                foreach (Control item in groupBox_Ranking.Controls)
                {
                    if (item is TextBox || item is ComboBox)
                    {
                        item.Text = "";
                        item.BackColor = Color.White;
                    }
                    if (item is NumericUpDown)
                    {
                        (item as NumericUpDown).Value = 1;
                        item.BackColor = Color.White;
                    }
                }
                PDF_CV_Viewer.src = null;
                label_ShowDisabled.Visible = false;
                label_DBID.Text = "0";
            }
        }


        private void NomineeArrToForm()
        {
            NomineeArr nomineearr = new NomineeArr();
            nomineearr.Fill(GetCurNomineeArrState());

            listBox_Nominee.DataSource = nomineearr;
        }


        private void SetCV(int DBId)
        {
            string path = Properties.Resources.Server_Path + Properties.Resources.CVS_path + DBId + @"\";

            if (button_Add_CV.Tag != null)
            {
                string[] pathParts = (button_Add_CV.Tag as string).Split('\\');
                string fileName = pathParts[pathParts.Length - 1];
                //There is a file selected for CV

                //if there is no directory for this nominee, create one
                Directory.CreateDirectory(path);
                string[] files = Directory.GetFiles(path);
                if (files.Length == 0)
                {
                    //There is no CV in the nominee's directory
                    File.Copy(button_Add_CV.Tag as string, path + fileName, true);
                }
                else
                {
                    //There is already a CV in the diractory
                    for (int i = 0; i < files.Length; i++)
                    {
                        File.Delete(files[i]);
                    }
                    File.Copy(button_Add_CV.Tag as string, path + fileName, true);
                }

            }
            else
            {
                //you want to remove the cv or the nominee is brand new with no directory
                if (Directory.Exists(path))
                {
                    //you want to remove the cv
                    string[] files = Directory.GetFiles(path);
                    for (int i = 0; i < files.Length; i++)
                    {
                        File.Delete(files[i]);
                    }
                }
                else
                {
                    Directory.CreateDirectory(path);
                }
            }
        }


        private (string path, string type) GetCV(int DBId)
        {
            string path = Properties.Resources.Server_Path + Properties.Resources.CVS_path + DBId + @"\";


            //if there is no directory for this nominee, return empty
            if (!Directory.Exists(path))
            {
                return ("", "");
            }

            //There is a directory
            string[] files = Directory.GetFiles(path);
            if (files.Length == 0)
            {
                //There is no CV in the nominee's directory
                return ("", "");
            }
            else
            {
                //There is a CV in the diractory
                string[] nameParts = files[0].Split('\\');
                string fileType = nameParts[nameParts.Length - 1].Split('.')[1];
                return (files[0], fileType);
            }

        }


        private bool IsNumber(string text)
        {
            try
            {
                int.Parse(text);
            }
            catch
            {
                return false;
            }
            return true;
        }


        bool HasNonASCIIChars(char c)
        {
            return (Encoding.UTF8.GetByteCount(new char[] { c }) != new char[] { c }.Length);
        }



        #endregion
    }
}
