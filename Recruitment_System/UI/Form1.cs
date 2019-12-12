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

namespace Recruitment_System.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClientArrToForm();
        }


        #region events
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
                        if (!File.Exists(Properties.Resources.Server_Path + Properties.Resources.CVS_path + client.Id + ".pdf") && !File.Exists(Properties.Resources.Server_Path + Properties.Resources.CVS_path + client.Id + ".docx"))
                        {
                            File.Copy(PDF_CV_Viewer.Tag as string, Properties.Resources.Server_Path + Properties.Resources.CVS_path + client.Id, true);
                        }


                        ClientArrToForm();
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
                    if (client.Update())
                    {
                        dialogResult = MessageBox.Show("The Client was UPDATED successfully", "Yay!", MessageBoxButtons.OK);
                    }
                    else
                        dialogResult = MessageBox.Show("There was a problem UPDATING the client to the database", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
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
                    button_Add_CV.BackColor = Color.Green;
                    return;
                }
            }
        }


        private void listBox_Client_DoubleClick(object sender, EventArgs e)
        {
            ClientToForm((Client)listBox_Client.SelectedValue);
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
            client.CellAreaCode = comboBox_CellAreaCode.Text;
            client.CellPhone = textBox_Cel.Text;
            client.City = (comboBox_City.SelectedItem as City) != null ? comboBox_City.SelectedItem as City : City.Empty;
            client.JobType = (comboBox_Position.SelectedItem as Job) != null ? comboBox_Position.SelectedItem as Job : Job.Empty;
            client.Match = (int)numericUpDown_Match.Value;
            client.Professionalism = (int)numericUpDown_Professionalism.Value;
            client.GeneralAssessment = (int)numericUpDown_GA.Value;

            return client;
        }

        #endregion


        #region private methods
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
            if (!Text_Check_Length(textBox_ID, false, 9))
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
            if (comboBox_Position.Text.Length == 0)
            {
                flag &= false;
                comboBox_Position.BackColor = Color.Red;
            }
            else
                comboBox_Position.BackColor = Color.White;


            return flag;
        }


        private void ClientToForm(Client client)
        {
            if (client != null)
            {
                label_DBID.Text = client.DBId.ToString();
                textBox_FirstName.Text = client.FirstName;
                textBox_LastName.Text = client.LastName;
                textBox_ID.Text = client.Id;
                comboBox_CellAreaCode.Text = client.CellAreaCode;
                textBox_Cel.Text = client.CellPhone;
                comboBox_City.SelectedValue = client.City.Id;
                comboBox_Position.SelectedValue = client.JobType.Id;
                numericUpDown_Match.Value = client.Match;
                numericUpDown_Professionalism.Value = client.Professionalism;
                numericUpDown_GA.Value = client.GeneralAssessment;
            }
            else
            {
                comboBox_City.SelectedItem = null;
                comboBox_Position.SelectedItem = null;
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
                label_DBID.Text = "0";
            }
        }


        private void ClientArrToForm()
        {
            ClientArr clientarr = new ClientArr();
            clientarr.Fill();

            listBox_Client.DataSource = clientarr;
        }


        #endregion


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
                ClientToForm(null);
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {

        }


        private void button_Add_CV_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Users\" + Environment.UserName + @"\Desktop";
                openFileDialog.Filter = "pdf files (*.pdf)|*.pdf|word files (*.docx)|*.docx";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    PDF_CV_Viewer.Tag = openFileDialog.FileName;
                }
            }
        }

        private void button_Remove_CV_Click(object sender, EventArgs e)
        {
            PDF_CV_Viewer.Tag = null;
        }
    }
}
