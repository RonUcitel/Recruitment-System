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
    public partial class City_Form : Form
    {
        public City_Form(City selectedCity)
        {
            InitializeComponent();
            SelectedCity = selectedCity;
            CityArrToForm(selectedCity);
            CityToForm(selectedCity);
        }

        public City SelectedCity { get; private set; }

        #region Events


        /// <summary>
        /// The first event to fire ofter the form loads.
        /// </summary>
        private void Form_City_Load(object sender, EventArgs e)
        {
            KeyDown += Control_KeyDown;//Add the Control_KeyDown event to the form.
            AddKeyDownEvent(this.Controls);//Add the Control_KeyDown event to all of the controls on the form.
            Form_city_InputLanguageChanged(null, null);//Check the current language.
            CapsLockCheck(); //Check for the state of the CapsLk.
        }


        private void listBox_City_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = listBox_City.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    listBox_City.SelectedIndex = index;
                    contextMenuStrip_City.Show(listBox_City, e.Location);
                }
            }
        }


        private void ToolStripMenuItem_Remove_Click(object sender, EventArgs e)
        {
            //remove the city

            City city = listBox_City.SelectedItem as City;

            if (MessageBox.Show("האם אתה בטוח שאתה רוצה למחוק את העיר שבחרת?\nפעולה זאת הינה בלתי הפיכה!", "אזהרה", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                NomineeArr clientArr = new NomineeArr();
                clientArr.Fill();
                if (clientArr.DoesCityExist(city))
                {
                    MessageBox.Show("לא ניתן למחוק את העיר.\n העיר שנבחרה משוייכת למועמדים קיימים במערכת.", "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else
                {
                    if (city.Delete())
                    {
                        CityToForm(null);
                        CityArrToForm(null);
                        MessageBox.Show("העיר נמחקה בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                    else
                    {
                        MessageBox.Show("ישנה תקלה במחיקת העיר מבסיס הנתונים.\n העיר לא נמחקה כלל.", "תקלה!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                }
            }
        }


        private void Button_Clear_Click(object sender, EventArgs e)
        {
            CityToForm(null);
            listBox_City.ClearSelected();
        }


        private void listBox_City_DoubleClick(object sender, EventArgs e)
        {
            CityArr cityarr = new CityArr();
            cityarr.Fill();

            if (!cityarr.IsContains(textBox_Name.Text) && CheckForm())
            {

                //There is a valid city to insert that will be erased.
                DialogResult dr = MessageBox.Show("המידע שהכנסת יכול להתווסף כעיר\nהאם אתה רוצה לשמור אותה?", "אזהרה!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                if (dr == DialogResult.No)
                {
                    CityToForm(listBox_City.SelectedItem as City);
                    CheckForm();
                }
                else if (dr == DialogResult.Yes)
                {
                    Button_Save_Click(button_Save, EventArgs.Empty);
                    CityToForm(listBox_City.SelectedItem as City);
                    CheckForm();
                }
            }
            else
            {
                CityToForm(listBox_City.SelectedItem as City);
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
                dialogResult = MessageBox.Show("המידע שסיפקת אינו תקין.\nאנא תקן את השדות האדומים על מנת להמשיך", "אזהרה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }

            else
            {
                //The information was valid

                City city = FormToCity();//Make a city object from the information on the form.

                if (city.Id == 0)
                {
                    CityArr oldCityArr = new CityArr();
                    oldCityArr.Fill();
                    if (!oldCityArr.IsContains(city.Name))
                    {
                        if (city.Insert())//Try to insert the new city to the database.
                        {
                            //The insertion of the city data was successfull.
                            CityArr cityArr = new CityArr();
                            cityArr.Fill();
                            CityArrToForm(cityArr.GetCityWithMaxId());
                            dialogResult = MessageBox.Show("העיר נוספה בהצלחה", "יאי!", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        }
                        else
                        {
                            //There was a problem insreting the data to the database.
                            dialogResult = MessageBox.Show("קרתה תקלה בעת שמירת העיר בבסיס הנתונים", "תקלה", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        }
                    }
                    else
                    {
                        dialogResult = MessageBox.Show("העיר שאתה מנסה להוסיף כבר קיימת במערכת!", "הפעולה נמנעה", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                }
                else
                {
                    if (textBox_Name.Text != SelectedCity.Name)
                    {
                        if (city.Update())
                        {
                            CityArr cityArr = new CityArr();
                            cityArr.Fill();
                            CityArrToForm(cityArr.GetCityWithMaxId());
                            dialogResult = MessageBox.Show("העיר עודכנה בהצלחה", "יאי!", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        }
                        else
                            dialogResult = MessageBox.Show("קרתה תקלה בעת עדכון העיר בבסיס הנתונים", "תקלה", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
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
                        CityToForm(null);
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
        private void Form_city_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
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
            CityArr cityArr = new CityArr();
            cityArr.Fill();

            cityArr = cityArr.Filter(textBox_Filter.Text);
            cityArr.Remove("+");

            listBox_City.DataSource = cityArr;
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

        private void CityToForm(City city)
        {

            if (city != null && city != City.Empty)
            {
                label_Id.Text = city.Id.ToString();
                textBox_Name.Text = city.Name;
                //SelectedCity = 
            }
            else
            {
                //Reset the text and flags of the input fields.
                textBox_Name.Text = "";
                textBox_Name.BackColor = Color.White;
                label_Id.Text = "0";
            }
        }


        private void CityArrToForm(City curCity)
        {
            CityArr cityArr = new CityArr();
            cityArr.Fill();

            listBox_City.DataSource = cityArr;
            listBox_City.ValueMember = "Id";
            listBox_City.DisplayMember = "Name";
            if (curCity != null)
            {
                listBox_City.SelectedValue = curCity;
            }
            else
            {
                listBox_City.ClearSelected();
            }
            CityToForm(curCity);
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
        /// Create a City object with the information from the form.
        /// </summary>
        /// <returns>City object with the information from the form.</returns>
        public City FormToCity()
        {
            City city = new City();
            //insert the data to the object
            city.Id = int.Parse(label_Id.Text);
            city.Name = textBox_Name.Text;

            return city;
        }


        #endregion

        private void label_Id_TextChanged(object sender, EventArgs e)
        {
            int id = int.Parse(label_Id.Text);
            if (id != 0)
            {
                groupBox_City.Text = "ערוך עיר קיימת";

                CityArr cityarr = new CityArr();
                cityarr.Fill();
                cityarr = cityarr.Filter("", id);
                if (cityarr.Count > 0)
                {
                    SelectedCity = cityarr[0] as City;
                }
                else
                {
                    SelectedCity = City.Empty;
                }
            }
            else
            {
                groupBox_City.Text = "הוסף עיר חדשה";
                SelectedCity = City.Empty;
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (label_Id.Text == "0")
            {
                MessageBox.Show("לא נבחרה עיר למחיקה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                return;
            }


            //remove the city
            CityArr cityArr = new CityArr();
            cityArr.Fill();
            cityArr = cityArr.Filter("", int.Parse(label_Id.Text));

            if (cityArr.Count == 0)
            {
                MessageBox.Show("קרתה תקלה במציאת העיר בבסיס הנתונים.\nאנא סגור והדלק את התוכנה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                return;
            }

            City city = cityArr[0] as City;

            if (MessageBox.Show("האם אתה בטוח שאתה רוצה למחוק את העיר שבחרת?\nפעולה זאת הינה בלתי הפיכה!", "אזהרה", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                NomineeArr clientArr = new NomineeArr();
                clientArr.Fill();
                if (clientArr.DoesCityExist(city))
                {
                    MessageBox.Show("לא ניתן למחוק את העיר.\n העיר שנבחרה משוייכת למועמדים קיימים במערכת.", "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else
                {
                    if (city.Delete())
                    {
                        CityToForm(null);
                        CityArrToForm(null);
                        MessageBox.Show("העיר נמחקה בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                    else
                    {
                        MessageBox.Show("ישנה תקלה במחיקת העיר מבסיס הנתונים.\n העיר לא נמחקה כלל.", "תקלה!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                }
            }

        }
    }
}
