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
        public NomineesPosition_Form()
        {
            Nominee nominee = Nominee.Empty;
            InitializeComponent();
            button_Add.Enabled = false;
            button_Remove.Enabled = false;
            ChosenPositionNomineeArrToForm(nominee);
            AvailablePositionArrToForm();
        }

        public PositionArr ChosenPositionArr => chosenPosArr;
        private PositionArr availablePosArr, chosenPosArr;
        private PositionNomineeArr chosenPosNomArr;


        private void AvailablePositionArrToForm()
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
        }


        private void ChosenPositionNomineeArrToForm(Nominee nominee)
        {
            PositionNomineeArr positionNomineeArr = new PositionNomineeArr();
            positionNomineeArr.Filter(nominee, Position.Empty);
            PositionArr positionArr = positionNomineeArr.ToPositionArr();

            listBox_AvailablePositions.DataSource = positionArr;

            chosenPosNomArr = positionNomineeArr;
            chosenPosArr = positionArr;
        }


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


        private void button_Remove_Click(object sender, EventArgs e)
        {
            Position pos = listBox_ChosenPositions.SelectedItem as Position;
            chosenPosArr.Remove(pos.Id);
            availablePosArr.Insert(0, pos);

            listBox_AvailablePositions.DataSource = availablePosArr.Clone();
            listBox_ChosenPositions.DataSource = chosenPosArr.Clone();

            listBox_AvailablePositions.Focus();

            listBox_ChosenPositions.ClearSelected();
            listBox_AvailablePositions.SetSelected(availablePosArr.IndexOf(pos), true);
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
            Position pos = listBox_AvailablePositions.SelectedItem as Position;
            availablePosArr.Remove(pos.Id);
            chosenPosArr.Insert(0, pos);

            listBox_AvailablePositions.DataSource = availablePosArr.Clone();
            listBox_ChosenPositions.DataSource = chosenPosArr.Clone();

            listBox_ChosenPositions.Focus();

            listBox_AvailablePositions.ClearSelected();
            listBox_ChosenPositions.SetSelected(chosenPosArr.IndexOf(pos), true);
        }


        private void textBox_FilterAvailable_TextChanged(object sender, EventArgs e)
        {
            string text = textBox_FilterAvailable.Text;
            listBox_AvailablePositions.DataSource = availablePosArr.Filter(text);

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
            listBox_ChosenPositions.DataSource = chosenPosArr.Filter(text);

            if (text == "")
            {
                pictureBox_ChosenDisableFilter.Visible = false;
            }
            else
            {
                pictureBox_ChosenDisableFilter.Visible = true;
            }
        }
    }
}
