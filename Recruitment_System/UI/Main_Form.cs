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
        private Job lastSelectedcomboBox_JobIndex = Job.Empty;
        public MainForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.allnet;
            ClientArrToForm();
            CityArrToForm(null);
            JobArrToForm(null);
        }


        #region events

        private void comboBox_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_City.SelectedItem != null)
            {
                if (comboBox_City.SelectedItem.ToString() == "+")
                {
                    if (comboBox_City.Focused)
                    {
                        City_Form fc = new City_Form(lastSelectedcomboBox_CityIndex);
                        fc.StartPosition = FormStartPosition.CenterParent;
                        fc.ShowDialog();
                        CityArrToForm(fc.SelectedCity);
                    }
                }

                lastSelectedcomboBox_CityIndex = (comboBox_City.SelectedItem as City);
            }

        }


        private void comboBox_Job_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Job.SelectedItem != null)
            {
                if (comboBox_Job.SelectedItem.ToString() == "+")
                {
                    if (comboBox_Job.Focused)
                    {
                        Job_Form fc = new Job_Form(lastSelectedcomboBox_JobIndex);
                        fc.StartPosition = FormStartPosition.CenterParent;
                        fc.ShowDialog();
                        JobArrToForm(fc.SelectedJob);
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

                Client client = FormToClient();//Make a Client object from the information on the form.

                if (client.DBId == 0)
                {
                    if (client.Insert())//Try to insert the new Client to the database.
                    {
                        //The insertion of the client data was successfull.

                        //Check the cv file:
                        ClientArr clientarr = new ClientArr();
                        clientarr.Fill();
                        SetCV(clientarr.MaxClientDBId().DBId);


                        ClientArrToForm();

                        SetLastChangedTextbox(client.DBId);

                        dialogResult = MessageBox.Show("The Client was ADDED successfully", "Yay!", MessageBoxButtons.OK);
                        listBox_Client.SelectedItem = listBox_Client.Items[listBox_Client.Items.Count - 1];
                    }
                    else
                    {
                        //There was a problem insreting the data to the database.
                        dialogResult = MessageBox.Show("There was a problem ADDING the client to the database", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //it is an update

                    ClientArr dbClients = new ClientArr();
                    dbClients.Fill();
                    Client dbClient = dbClients.GetClientByDBId(client.DBId);

                    if (!client.Equals(dbClient))
                    {
                        //if there is a change in the data

                        if (client.Update())
                        {
                            //Check the cv file:

                            dialogResult = MessageBox.Show("The Client was UPDATED successfully", "Yay!", MessageBoxButtons.OK);
                        }
                        else
                            dialogResult = MessageBox.Show("There was a problem UPDATING the client to the database", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
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
                        ClientToForm(null);
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

            ClientArrToForm();
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
                    if (FormToClient().DBId != 0)
                    {
                        SetCV(FormToClient().DBId);
                    }
                    button_Add_CV.BackColor = Color.Green;
                    button_Add_CV.Text = "ישנם קורות חיים";
                    return;
                }
            }
        }


        private void listBox_Client_DoubleClick(object sender, EventArgs e)
        {
            ClientToForm((Client)listBox_Client.SelectedValue);
        }


        private void button_Search_Click(object sender, EventArgs e)
        {
            Client filter = FormToClient();
            ClientArr clientArr = new ClientArr();
            clientArr.Fill();
            clientArr = clientArr.Filter(filter);
            listBox_Client.DataSource = clientArr;
            if (clientArr.Count > 0)
            {
                //There is a client standing by the filter
                ClientToForm(clientArr[0] as Client);
            }
            else
            {
                //No client was found by the filter
                if (MessageBox.Show("There is no client matching the fields you filled. please check the values you entered.", "No Client was found", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                {
                    ClientToForm(null);
                }

            }
        }


        private void button_Clear_Click(object sender, EventArgs e)
        {
            ClientToForm(null);
            ClientArr clientArr = new ClientArr();
            clientArr.Fill();
            listBox_Client.DataSource = clientArr;
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
                if (FormToClient().DBId != 0)
                {
                    SetCV(FormToClient().DBId);
                }
            }
        }


        private void button_Remove_CV_Click(object sender, EventArgs e)
        {
            button_Add_CV.Tag = null;
            int dbid = FormToClient().DBId;
            SetCV(dbid);
            button_Add_CV.Text = "הוסף קורות חיים";
            button_Add_CV.BackColor = SystemColors.ButtonFace;
            button_Add_CV.UseVisualStyleBackColor = true;

        }


        private void button_Delete_Click(object sender, EventArgs e)
        {
            Client delete = FormToClient();
            if (delete.DBId == 0)
            {
                MessageBox.Show("לא נבחר לקוח למחיקה!", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("פעולה זאת הינה בלתי ניתנת לשיחזור!\nהאם אתה בטוח שברצונך להמשיך?", "אזהרה!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == DialogResult.Yes)
                {
                    //delete this client from the database

                    delete.Delete();

                    LogEntryArr logToDelete = new LogEntryArr();
                    logToDelete.Fill();
                    logToDelete = logToDelete.Filter(delete.DBId, DateTime.MinValue, "");

                    for (int i = 0; i < logToDelete.Count; i++)
                    {
                        (logToDelete[i] as LogEntry).Delete();
                    }

                    ClientArr clientarr = new ClientArr();
                    clientarr.Fill();

                    listBox_Client.DataSource = clientarr;
                    ClientToForm(null);
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
        public Client FormToClient()
        {
            Client client = new Client();//Create a new instance of the Client class.

            //insert the data to the object
            client.DBId = int.Parse(label_DBID.Text);
            client.FirstName = textBox_FirstName.Text;
            client.LastName = textBox_LastName.Text;
            client.Id = textBox_ID.Text;
            client.Email = textBox_Email.Text;
            client.BirthYear = textBox_BirthYear.Text == "" ? 0 : int.Parse(textBox_BirthYear.Text);
            client.CellAreaCode = comboBox_CellAreaCode.Text;
            client.CellPhone = textBox_Cel.Text;
            client.City = (comboBox_City.SelectedItem as City) != null ? comboBox_City.SelectedItem as City : City.Empty;
            client.JobType = (comboBox_Job.SelectedItem as Job) != null ? comboBox_Job.SelectedItem as Job : Job.Empty;
            client.Match = (int)numericUpDown_Match.Value;
            client.Professionalism = (int)numericUpDown_Professionalism.Value;
            client.GeneralAssessment = (int)numericUpDown_GA.Value;

            return client;
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
            if (curCity != null && lastSelectedcomboBox_CityIndex != null && lastSelectedcomboBox_CityIndex != City.Empty)
            {
                comboBox_City.SelectedValue = curCity.Id;
            }
            else
            {
                comboBox_City.Text = "";
            }
        }


        public void JobArrToForm(Job curJob)
        {
            JobArr jobArr = new JobArr();
            jobArr.Fill();
            jobArr.Insert(0, Job.Empty);
            jobArr.Insert(1, Job.AddingFormButton);

            comboBox_Job.SelectedIndexChanged -= comboBox_Job_SelectedIndexChanged;
            comboBox_Job.DataSource = jobArr;
            comboBox_Job.ValueMember = "Id";
            comboBox_Job.DisplayMember = "Name";
            comboBox_Job.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_Job.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_Job.SelectedIndexChanged += comboBox_Job_SelectedIndexChanged;
            if (curJob != null && lastSelectedcomboBox_JobIndex != null && lastSelectedcomboBox_JobIndex != Job.Empty)
            {
                comboBox_Job.SelectedValue = curJob.Id;
            }
            else
            {
                comboBox_Job.Text = "";
            }
        }

        #endregion


        #region private methods

        private void SetLastChangedTextbox(int clientDBId)
        {
            if (clientDBId > 0)
            {
                LogEntryArr logEntryArr = new LogEntryArr();
                logEntryArr.Fill();
                logEntryArr = logEntryArr.Filter(clientDBId, DateTime.MinValue, "");

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



            //ID - 3
            if (0 >= textBox_ID.Text.Length && textBox_ID.Text.Length >= 9 && !IsNumber(textBox_ID.Text))
                flag &= false;


            //CellPhone area code - 4
            if (!comboBox_CellAreaCode.Items.Contains(comboBox_CellAreaCode.Text))
            {
                flag &= false;
                comboBox_CellAreaCode.BackColor = Color.Red;
            }
            else
                comboBox_CellAreaCode.BackColor = Color.White;


            //CellPhone number - 5
            if (!Text_Check_Length(textBox_Cel, false, 7))
                flag &= false;


            //City - 6
            if (!Text_Check_Length(comboBox_City, true, 2))
                flag &= false;


            //Job type - 7
            if (comboBox_Job.Text.Length == 0)
            {
                flag &= false;
                comboBox_Job.BackColor = Color.Red;
            }
            else
                comboBox_Job.BackColor = Color.White;


            return flag;
        }


        private void ClientToForm(Client client)
        {
            if (client != null)
            {
                SetLastChangedTextbox(client.DBId);
                label_DBID.Text = client.DBId.ToString();
                textBox_FirstName.Text = client.FirstName;
                textBox_LastName.Text = client.LastName;
                textBox_ID.Text = client.Id;
                textBox_Email.Text = client.Email;
                textBox_BirthYear.Text = client.BirthYear.ToString();
                comboBox_CellAreaCode.Text = client.CellAreaCode;
                textBox_Cel.Text = client.CellPhone;
                comboBox_City.SelectedValue = client.City.Id;
                comboBox_Job.SelectedValue = client.JobType.Id;
                numericUpDown_Match.Value = client.Match;
                numericUpDown_Professionalism.Value = client.Professionalism;
                numericUpDown_GA.Value = client.GeneralAssessment;


                (string path, string type) cv = GetCV(client.DBId);
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
                comboBox_Job.SelectedItem = null;
                //Reset the text and flags of the input fields.
                foreach (Control item in groupBox_PD.Controls)
                {
                    if (item is TextBox || item is ComboBox)
                    {
                        item.Text = "";
                        item.BackColor = Color.White;
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
                label_DBID.Text = "0";
            }
        }


        private void ClientArrToForm()
        {
            ClientArr clientarr = new ClientArr();
            clientarr.Fill();
            listBox_Client.DataSource = clientarr;
        }


        private void SetCV(int DBId)
        {
            string path = Properties.Resources.Server_Path + Properties.Resources.CVS_path + DBId + @"\";

            if (button_Add_CV.Tag != null)
            {
                string[] pathParts = (button_Add_CV.Tag as string).Split('\\');
                string fileName = pathParts[pathParts.Length - 1];
                //There is a file selected for CV

                //if there is no directory for this client, create one
                Directory.CreateDirectory(path);
                string[] files = Directory.GetFiles(path);
                if (files.Length == 0)
                {
                    //There is no CV in the client's directory
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
                //you want to remove the cv or the client is brand new with no directory
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


            //if there is no directory for this client, return empty
            if (!Directory.Exists(path))
            {
                return ("", "");
            }

            //There is a directory
            string[] files = Directory.GetFiles(path);
            if (files.Length == 0)
            {
                //There is no CV in the client's directory
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
    }
}
