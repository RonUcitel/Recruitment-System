using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Recruitment_System.BL;

namespace Recruitment_System.UI
{
    public partial class NomineeCity_Graph_Form : Form
    {
        public NomineeCity_Graph_Form()
        {
            InitializeComponent();
            PositionArrToForm();
            NomineeArrStateToForm();
            DataToChart(Position.Empty, 0, 100, NomineeArrState.ShowEnabledOnly);
        }

        public void DataToChart(Position position, int from, int to, NomineeArrState state)
        {
            //פלטת הצבעים -אפשר גם להגדיר מראש במאפיינים )לא בקוד(
            chart1.Palette = ChartColorPalette.Excel;
            //מחייב הצגת כל הערכים בציר האיקס, אם רוצים שיוצגו לסירוגין רושמים 2
            chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            //כותרת הגרף -1
            chart1.Titles.Clear();
            chart1.Titles.Add("כמות מועמדים לכל עיר");
            //הוספת הערכים למשתנה מסוג מילון ממוין
            NomineeArr curNomineeArr = new NomineeArr();
            curNomineeArr.Fill(state);
            curNomineeArr = curNomineeArr.Filter(position, City.Empty, from, to);

            SortedDictionary<string, int> dictionary = curNomineeArr.GetSortedDictionaryCity();

            //הגדרת סדרה וערכיה - שם הסדרה מועבר למקרא - 2

            Series series = new Series("אוכלוסייה");

            //סוג הגרף

            series.ChartType = SeriesChartType.Column;

            //המידע שיוצג לכל רכיב ערך בגרף - 3

            //שם - VALX
            //הערך - VAL//#
            //אחוז עם אפס אחרי הנקודה - {P0} PERCENT

            series.Label = "#VAL";

            //series.LegendText = "#VAL";


            //הוספת הערכים מתוך משתנה המילון לסדרה

            series.Points.DataBindXY(dictionary.Keys, dictionary.Values);
            series.SmartLabelStyle.Enabled = true;


            //מחיקת סדרות קיימות - אם יש ולא בכוונה

            chart1.Series.Clear();

            //הוספת הסדרה לפקד הגרף

            chart1.Series.Add(series);
        }

        private void PositionArrToForm()
        {
            PositionArr positionArr = new PositionArr();
            positionArr.Fill();
            positionArr.Insert(0, Position.Empty);

            comboBox_Position.DataSource = positionArr;
            comboBox_Position.ValueMember = "Id";
            comboBox_Position.DisplayMember = "Name";
            comboBox_Position.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_Position.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_Position.SelectedValue = 0;
        }

        private void NomineeArrStateToForm()
        {
            comboBox_NomineeState.Items.Insert((int)NomineeArrState.ShowDisabledOnly, "לא זמינים בלבד");
            comboBox_NomineeState.Items.Insert((int)NomineeArrState.ShowEnabledOnly, "זמינים בלבד");
            comboBox_NomineeState.Items.Insert((int)NomineeArrState.ShowAll, "כולם");
            comboBox_NomineeState.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_NomineeState.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_NomineeState.SelectedIndex = (int)NomineeArrState.ShowEnabledOnly;
        }

        private void button_Filter_Click(object sender, EventArgs e)
        {
            DataToChart(comboBox_Position.SelectedItem as Position, (int)numericUpDown_From.Value, (int)numericUpDown_To.Value, (NomineeArrState)comboBox_NomineeState.SelectedIndex);
        }

        private void numericUpDown_From_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_To.Minimum = numericUpDown_From.Value;
        }

        private void numericUpDown_To_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_From.Maximum = numericUpDown_To.Value;
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            comboBox_Position.SelectedIndex = 0;
            comboBox_NomineeState.SelectedIndex = (int)NomineeArrState.ShowEnabledOnly;
            numericUpDown_From.Value = 0;
            numericUpDown_To.Value = 100;

            DataToChart(comboBox_Position.SelectedItem as Position, (int)numericUpDown_From.Value, (int)numericUpDown_To.Value, (NomineeArrState)comboBox_NomineeState.SelectedIndex);
        }
    }
}
