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
    public partial class NomineesPosition_Form : Form
    {
        public NomineesPosition_Form(Nominee nominee)
        {
            InitializeComponent();

            //לשונית פריטים להזמנה
            //תיבת רשימה - פריטים בהזמנה
            //מוצאים את הפריטים בהזמנה הנוכחית
            // כל הזוגות פריט -הזמנה
            if (nominee != Nominee.Empty)
            {
                PositionNomineeArr positionNomineeArr = new PositionNomineeArr();
                positionNomineeArr.Fill();

                //סינון לפי הזמנה נוכחית

                positionNomineeArr = positionNomineeArr.Filter(nominee, Position.Empty);

                //רק אוסף הפריטים מתוך אוסף הזוגות פריט -הזמנה

                PositionArr positionArrInNominee = positionNomineeArr.ToPositionArr();
                PositionArrToForm(positionArrInNominee, listBox_ChosenPositions);


                //תיבת רשימה - פריטים פוטנציאלים
                //כל הפריטים - פחות אלו שכבר נבחרו

                PositionArr positionArrNotInNominee = new PositionArr();
                positionArrNotInNominee.Fill();

                //הורדת הפריטים שכבר קיימים בהזמנה

                positionArrNotInNominee.Remove(positionArrInNominee);
                PositionArrToForm(positionArrNotInNominee, listBox_AvailablePositions);


            }
            else
            {
                PositionArrToForm(new PositionArr(), listBox_ChosenPositions);

                PositionArr positionArrNotInNominee = new PositionArr();
                positionArrNotInNominee.Fill();

                //הורדת הפריטים שכבר קיימים בהזמנה
                PositionArrToForm(positionArrNotInNominee, listBox_AvailablePositions);
            }





            button_Add.Enabled = false;
            button_Remove.Enabled = false;

            listBox_AvailablePositions.ClearSelected();
            listBox_ChosenPositions.ClearSelected();
        }


        public NomineesPosition_Form(PositionArr positionArr)
        {
            InitializeComponent();

            PositionArrToForm(positionArr, listBox_ChosenPositions);


            PositionArr positionArrNotInNominee = new PositionArr();
            positionArrNotInNominee.Fill();

            positionArrNotInNominee.Remove(positionArr);
            PositionArrToForm(positionArrNotInNominee, listBox_AvailablePositions);



            button_Add.Enabled = false;
            button_Remove.Enabled = false;

            listBox_AvailablePositions.ClearSelected();
            listBox_ChosenPositions.ClearSelected();
        }


        public PositionArr ChosenPositionArr => chosenPosArr;
        private PositionArr availablePosArr, chosenPosArr;



        #region not interesting events for buttons managment
        private void listBox_AvailablePositions_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox_AvailablePositions.SelectedItem != null)
            {
                button_Add.Enabled = true;
            }
            else
            {
                button_Add.Enabled = false;
            }
        }


        private void listBox_ChosenPositions_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox_ChosenPositions.SelectedItem != null)
            {
                button_Remove.Enabled = true;
            }
            else
            {
                button_Remove.Enabled = false;
            }
        }


        private void listBox_AvailablePositions_Enter(object sender, EventArgs e)
        {
            button_Remove.Enabled = false;
        }


        private void listBox_ChosenPositions_Enter(object sender, EventArgs e)
        {
            button_Add.Enabled = false;
        }
        #endregion




        #region Events

        private void button_Remove_Click(object sender, EventArgs e)
        {
            MoveSelectedItemBetweenListBox(listBox_ChosenPositions, listBox_AvailablePositions);

            listBox_AvailablePositions.Focus();

            listBox_ChosenPositions.ClearSelected();
            listBox_AvailablePositions.SetSelected(0, true);
        }


        private void pictureBox_ChosenDisableFilter_Click(object sender, EventArgs e)
        {
            textBox_FilterChosen.Clear();
            pictureBox_ChosenDisableFilter.Visible = false;
        }


        private void pictureBox_AvailableDisableFilter_Click(object sender, EventArgs e)
        {
            textBox_FilterAvailable.Clear();
            pictureBox_AvailableDisableFilter.Visible = false;
        }


        private void button_Add_Click(object sender, EventArgs e)
        {
            MoveSelectedItemBetweenListBox(listBox_AvailablePositions, listBox_ChosenPositions);

            listBox_ChosenPositions.Focus();

            listBox_AvailablePositions.ClearSelected();
            listBox_ChosenPositions.SetSelected(0, true);
        }


        private void textBox_FilterAvailable_TextChanged(object sender, EventArgs e)
        {
            string text = textBox_FilterAvailable.Text;
            listBox_AvailablePositions.DataSource = availablePosArr.Filter(text, PositionType.Empty, DateTime.MinValue, DateTime.MinValue);

            if (text == "")
            {
                pictureBox_AvailableDisableFilter.Visible = false;
            }
            else
            {
                pictureBox_AvailableDisableFilter.Visible = true;
            }
        }


        private void textBox_FilterChosen_TextChanged(object sender, EventArgs e)
        {
            string text = textBox_FilterChosen.Text;
            listBox_ChosenPositions.DataSource = chosenPosArr.Filter(text, PositionType.Empty, DateTime.MinValue, DateTime.MinValue);

            if (text == "")
            {
                pictureBox_ChosenDisableFilter.Visible = false;
            }
            else
            {
                pictureBox_ChosenDisableFilter.Visible = true;
            }
        }


        #endregion


        //----------------------------------------------------------------------------------------------------

        private void PositionArrToForm(PositionArr positionArr, ListBox listBox)
        {

            //מקבלת אוסף פריטים ותיבת רשימה לפריטים ומציבה את האוסף בתוך התיבה
            //אם האוסף ריק - מייצרת אוסף חדש מלא בכל הערכים מהטבלה

            listBox.DataSource = null;
            if (positionArr == null)
            {
                positionArr = new PositionArr();
                positionArr.Fill();
            }
            listBox.DataSource = positionArr;

            if (listBox == listBox_AvailablePositions)
            {
                availablePosArr = positionArr;
            }
            else
            {
                chosenPosArr = positionArr;
            }
        }


        /*        private void PositionArrToForm()
                {
                    PositionArr positionArr = new PositionArr();
                    positionArr.Fill();

                    Position pos;
                    for (int i = 0; i < chosenPosNomArr.Count; i++)
                    {
                        pos = (chosenPosNomArr[i] as PositionNominee).Position;
                        positionArr.Remove(pos.Id);
                    }

                    listBox_AvailablePositions.DataSource = positionArr;

                    availablePosArr = positionArr;
                }*/


        private PositionNomineeArr FormToPositionNomineeArr(Nominee curNom)
        {

            //יצירת אוסף המוצרים להזמנה מהטופס
            //מייצרים זוגות של הזמנה-מוצר, ההזמנה - תמיד אותה הזמנה )הרי מדובר על הזמנה אחת(, המוצר - מגיע מרשימת
            //המוצרים שנבחרו

            PositionNomineeArr positionNomineeArr = new PositionNomineeArr();
            //יצירת אוסף הזוגות הזמנה-מוצר
            PositionNominee positionNominee;
            //סורקים את כל הערכים בתיבת הרשימה של המוצרים שנבחרו להזמנה
            for (int i = 0; i < listBox_ChosenPositions.Items.Count; i++)
            {
                positionNominee = new PositionNominee();
                //ההזמנה הנוכחית היא ההזמנה לכל הזוגות באוסף
                positionNominee.Nominee = curNom;
                //מוצר נוכחי לזוג הזמנה-מוצר
                positionNominee.Position = listBox_ChosenPositions.Items[i] as Position;

                //הוספת הזוג הזמנה - מוצר לאוסף
                positionNomineeArr.Add(positionNominee);
            }
            return positionNomineeArr;
        }

        private void MoveSelectedItemBetweenListBox(ListBox listBox_From, ListBox listBox_To)
        {
            PositionArr positionArr;

            //מוצאים את הפריט הנבחר

            object selectedItem = listBox_From.SelectedItem;

            //מוסיפים את הפריט הנבחר לרשימת הפריטים הפוטנציאליים
            //אם כבר יש פריטים ברשימת הפוטנציאליים

            if (listBox_To.DataSource != null)
                positionArr = listBox_To.DataSource as PositionArr;
            else
                positionArr = new PositionArr();

            positionArr.Insert(0, selectedItem);
            PositionArrToForm(positionArr, listBox_To);

            ///הסרת הפריט הנבחרים מרשימת הפריטים הנבחרים

            positionArr = listBox_From.DataSource as PositionArr;
            positionArr.Remove(selectedItem);
            PositionArrToForm(positionArr, listBox_From);
        }
    }
}
