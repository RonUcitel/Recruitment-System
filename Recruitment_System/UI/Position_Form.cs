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
    public partial class Position_Form : Form
    {
        public Position_Form(/*Position selectedPosition*/)
        {
            InitializeComponent();
            SelectedPosition = Position.Empty/*selectedPosition*/;
            PositionArrToForm(Position.Empty/*selectedPosition*/);
            PositionToForm(Position.Empty/*selectedPosition*/);
        }

        public Position SelectedPosition { get; private set; }

        #region Events


        /// <summary>
        /// The first event to fire ofter the form loads.
        /// </summary>
        private void Form_Position_Load(object sender, EventArgs e)
        {
            KeyDown += Control_KeyDown;//Add the Control_KeyDown event to the form.
            AddKeyDownEvent(this.Controls);//Add the Control_KeyDown event to all of the controls on the form.
            Form_position_InputLanguageChanged(null, null);//Check the current language.
            CapsLockCheck(); //Check for the state of the CapsLk.
        }


        private void listBox_Position_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = listBox_Position.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    listBox_Position.SelectedIndex = index;
                    contextMenuStrip_Position.Show(listBox_Position, e.Location);
                }
            }
        }


        private void ToolStripMenuItem_Remove_Click(object sender, EventArgs e)
        {
            //remove the position

            Position position = listBox_Position.SelectedItem as Position;

            if (MessageBox.Show("האם אתה בטוח שאתה רוצה למחוק את המשרה שבחרת?\nפעולה זאת הינה בלתי הפיכה!", "אזהרה", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                PositionNomineeArr positionNominee = new PositionNomineeArr();
                positionNominee.Fill();
                positionNominee = positionNominee.Filter(Nominee.Empty, position);

                if (positionNominee.Count > 0)
                {
                    MessageBox.Show("לא ניתן למחוק את המשרה.\n המשרה שנבחרה משוייכת למועמדים קיימים במערכת.", "הפעולה לא ניתן לביצוע", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else
                {
                    if (position.Delete())
                    {
                        PositionToForm(null);
                        PositionArrToForm(null);
                        MessageBox.Show("המשרה נמחקה בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                    else
                    {
                        MessageBox.Show("ישנה תקלה במחיקת המשרה מבסיס הנתונים.\n המשרה לא נמחקה כלל.", "תקלה!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                }
            }
        }


        private void Button_Clear_Click(object sender, EventArgs e)
        {
            PositionToForm(null);
            listBox_Position.ClearSelected();
        }


        private void listBox_Position_DoubleClick(object sender, EventArgs e)
        {
            PositionArr positionarr = new PositionArr();
            positionarr.Fill();

            if (!positionarr.IsContains(textBox_Name.Text) && CheckForm())
            {

                //There is a valid position to insert that will be erased.
                DialogResult dr = MessageBox.Show("המידע שהכנסת יכול להתווסף כמשרה.\nהאם אתה רוצה לשמור אותה?", "אזהרה!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                if (dr == DialogResult.No)
                {
                    PositionToForm(listBox_Position.SelectedItem as Position);
                    CheckForm();
                }
                else if (dr == DialogResult.Yes)
                {
                    Button_Save_Click(button_Save, EventArgs.Empty);
                    PositionToForm(listBox_Position.SelectedItem as Position);
                    CheckForm();
                }
            }
            else
            {
                PositionToForm(listBox_Position.SelectedItem as Position);
                CheckForm();
            }
        }


        /// <summary>
        /// Attached to all of the controls and checks when to call the CapsLockCheck method.
        /// </summary>
        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.CapsLock)
            {
                //Only if the CapsLK key was pressed, then call the method.
                CapsLockCheck();
            }
        }


        /// <summary>
        /// Check the final data on the form and if it is ok, then it sends the data to the database.
        /// </summary>
        private void Button_Save_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            if (!CheckForm())
            {
                //The entered information is not valid.
                dialogResult = MessageBox.Show("המידע שהכנסת אינו תקין.\nאנא תקן את השדות האדומים", "שגיאה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }

            else
            {
                //The information was valid

                Position position = FormToPosition();//Make a position object from the information on the form.

                if (position.Id == 0)
                {
                    PositionArr oldPositionArr = new PositionArr();
                    oldPositionArr.Fill();
                    if (!oldPositionArr.IsContains(position.Name))
                    {
                        if (position.Insert())//Try to insert the new position to the database.
                        {
                            //The insertion of the position data was successfull.
                            PositionArr positionArr = new PositionArr();
                            positionArr.Fill();
                            PositionArrToForm(positionArr.GetPositionWithMaxId());
                            dialogResult = MessageBox.Show("המשרה התווספה בהצלחה!", "יאי!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        }
                        else
                        {
                            //There was a problem insreting the data to the database.
                            dialogResult = MessageBox.Show("קרתה תקלה במהלך ההכנסה של המשרה לבסיס הנתונים.\nהאם תרצה לנסות שוב, לבטל את הפעולה, או להמשיך?", "תקלה", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        }
                    }
                    else
                    {
                        dialogResult = MessageBox.Show("המשרה שאתה מנסה להוסיף כבר קיימת במערכת", "שגיאה", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                }
                else
                {
                    if (textBox_Name.Text != SelectedPosition.Name)
                    {
                        if (position.Update())
                        {
                            PositionArr positionArr = new PositionArr();
                            positionArr.Fill();
                            PositionArrToForm(positionArr.GetPositionWithMaxId());
                            dialogResult = MessageBox.Show("המשרה התעדכנה בהצלחה", "יאי!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        }
                        else
                            dialogResult = MessageBox.Show("קרתה תקלה במהלך העדכון של המשרה לבסיס הנתונים.\nהאם תרצה לנסות שוב, לבטל את הפעולה, או להמשיך?", "תקלה", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                    else
                        dialogResult = DialogResult.OK;
                }
            }

            //MessageBox results actions:
            switch (dialogResult)
            {
                case DialogResult.OK://Do nothing
                    break;

                case DialogResult.Cancel://Clear all of the text and "restart".
                    {
                        PositionToForm(null);
                        break;
                    }

                case DialogResult.Abort://Close the form
                    {
                        Environment.Exit(0);
                        break;
                    }

                case DialogResult.Retry:
                    {
                        Button_Save_Click(null, null);//Try again.
                        break;
                    }

                case DialogResult.Ignore://Do nothing.
                    break;

                default:
                    break;
            }

        }//<<<<<<<<<<<<<<<<<<-------------------------


        /// <summary>
        /// Checks the current language and updating the label_Language.
        /// </summary>
        private void Form_position_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        {
            InputLanguage myCurrentLang = InputLanguage.CurrentInputLanguage;
            label_Language.Text = myCurrentLang.Culture.Name.ToLower();
        }


        /// <summary>
        /// Check if the pressed key is valid for a letter based textBox.
        /// </summary>
        private void TextBox_Name_Letter_KeyPress(object sender, KeyPressEventArgs e)
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


        /// <summary>
        /// Filter the listbox
        /// </summary>
        private void TextBox_Filter_Letter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!IsHeLetter(e.KeyChar) && !IsEnLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != ' ')
            {
                //If the pressed key is not a letter - Hebrew or English, or a Control Key
                //or a Hyphen or a Space char, then don't enter it to the text of the textBox.
                e.KeyChar = char.MinValue;
            }
        }


        private void textBox_Filter_TextChanged(object sender, EventArgs e)
        {
            PositionArr positionArr = new PositionArr();
            positionArr.Fill();

            positionArr = positionArr.Filter(textBox_Filter.Text);

            listBox_Position.DataSource = positionArr;
        }


        /// <summary>
        /// Checks if the length of the text in the name textBoxes is valid (one textbox at a fire).
        /// </summary>
        private void TextBox_Name_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text != "")
            {
                string output = "";
                string[] raw = (sender as TextBox).Text.ToLower().Split(' ');
                for (int i = 0; i < raw.Length; i++)
                {
                    if (raw[i] != "")
                    {
                        output += char.ToUpper(raw[i][0]) + raw[i].Substring(1) + " ";
                    }
                }
                (sender as TextBox).Text = output.Remove(output.Length - 1);
            }
            CheckForm();
        }


        #endregion


        #region Private methods

        private void PositionToForm(Position position)
        {

            if (position != null && position != Position.Empty)
            {
                label_Id.Text = position.Id.ToString();
                textBox_Name.Text = position.Name;
                //SelectedPosition = 
            }
            else
            {
                //Reset the text and flags of the input fields.
                textBox_Name.Text = "";
                textBox_Name.BackColor = Color.White;
                label_Id.Text = "0";
            }
        }


        private void PositionArrToForm(Position curPosition)
        {
            PositionArr positionArr = new PositionArr();
            positionArr.Fill();

            listBox_Position.DataSource = positionArr;
            listBox_Position.ValueMember = "Id";
            listBox_Position.DisplayMember = "Name";
            if (curPosition != null)
            {
                listBox_Position.SelectedValue = curPosition;
            }
            else
            {
                listBox_Position.ClearSelected();
            }
            PositionToForm(curPosition);
        }



        /// <summary>
        /// compares the length of the text of the given control to the given number.
        /// </summary>
        /// <param name="sender">The Control on which the method should operate.</param>
        /// <param name="isBiggerThan">Is the length of the text should be bigger than the nu or equal to it.</param>
        /// <param name="num">The number being compared.</param>
        /// <returns>The flag status</returns>
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


        /// <summary>
        /// Recursively adds the Control_KeyDown as the KeyDown event to all of the controls on the form.
        /// </summary>
        /// <param name="collection">The desired collection of Controls</param>
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


        /// <summary>
        /// Cheks the validation of input field.
        /// </summary>
        /// <returns>Is there any raised flag.</returns>
        private bool CheckForm()
        {                                                       //מחזירה האם הטופס תקין מבחינת שדות החובה
            return Text_Check_Length(textBox_Name, true, 2);
        }


        /// <summary>
        /// Check if a char is an English letter.
        /// </summary>
        /// <param name="c">The desired char.</param>
        /// <returns>Is the char an English letter?</returns>
        private bool IsEnLetter(char c)
        {
            return ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'));
        }


        /// <summary>
        /// Check if a char is a Hebrew letter.
        /// </summary>
        /// <param name="c">The desired char.</param>
        /// <returns>Is the char a Hebrew letter?</returns>
        private bool IsHeLetter(char c)
        {
            return c >= 'א' && c <= 'ת';
        }


        /// <summary>
        /// Checks the state of the CapsLk Control Key, and updates the label_CapsLk accordingly.
        /// </summary>
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


        #endregion


        #region Public methods


        /// <summary>
        /// Create a Position object with the information from the form.
        /// </summary>
        /// <returns>Position object with the information from the form.</returns>
        public Position FormToPosition()
        {
            Position position = new Position();

            //insert the data to the object
            position.Id = int.Parse(label_Id.Text);
            position.Name = textBox_Name.Text;

            return position;
        }


        #endregion

        private void label_Id_TextChanged(object sender, EventArgs e)
        {
            int id = int.Parse(label_Id.Text);
            if (id != 0)
            {
                groupBox_Position.Text = "ערוך משרה קיימת";

                PositionArr positionarr = new PositionArr();
                positionarr.Fill();

                SelectedPosition = positionarr.Filter(id);
            }
            else
            {
                groupBox_Position.Text = "הוסף משרה חדשה";

                SelectedPosition = Position.Empty;
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (label_Id.Text == "0")
            {
                MessageBox.Show("לא נבחרה משרה למחיקה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                return;
            }


            //remove the position
            Position position;
            PositionArr positionArr = new PositionArr();
            positionArr.Fill();
            position = positionArr.Filter(int.Parse(label_Id.Text));

            if (position == Position.Empty)
            {
                MessageBox.Show("קרתה תקלה במציאת המשרה בבסיס הנתונים.\nאנא סגור והדלק את התוכנה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                return;
            }


            if (MessageBox.Show("האם אתה בטוח שאתה רוצה למחוק את המשרה שבחרת?\nפעולה זאת הינה בלתי הפיכה!", "אזהרה", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading) == DialogResult.Yes)
            {
                PositionNomineeArr positionNominee = new PositionNomineeArr();
                positionNominee.Fill();
                positionNominee = positionNominee.Filter(Nominee.Empty, position);


                if (positionNominee.Count > 0)
                {
                    MessageBox.Show("לא ניתן למחוק את המשרה.\n המשרה שנבחרה משוייכת למועמדים קיימים במערכת.", "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else
                {
                    if (position.Delete())
                    {
                        PositionToForm(null);
                        PositionArrToForm(null);
                        MessageBox.Show("המשרה נמחקה בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                    else
                    {
                        MessageBox.Show("ישנה תקלה במחיקת המשרה מבסיס הנתונים.\n המשרה לא נמחקה כלל.", "תקלה!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                }
            }

        }
    }
}
