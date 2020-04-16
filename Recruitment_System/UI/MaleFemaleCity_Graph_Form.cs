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
    public partial class MaleFemaleCity_Graph_Form : Form
    {
        public MaleFemaleCity_Graph_Form()
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

            SortedDictionary<string, int> dictionaryMale = curNomineeArr.GetSortedDictionaryMaleFemaleCity(true);

            //הגדרת סדרה וערכיה - שם הסדרה מועבר למקרא - 2
            Series seriesMale = new Series("גברים");
            {
                seriesMale.Color = Color.Blue;

                //סוג הגרף

                seriesMale.ChartType = SeriesChartType.Column;

                //המידע שיוצג לכל רכיב ערך בגרף - 3

                //שם - VALX
                //הערך - VAL//#
                //אחוז עם אפס אחרי הנקודה - {P0} PERCENT

                seriesMale.Label = "#VAL";

                seriesMale.LegendText = "גברים";


                //הוספת הערכים מתוך משתנה המילון לסדרה

                seriesMale.Points.DataBindXY(dictionaryMale.Keys, dictionaryMale.Values);
                seriesMale.SmartLabelStyle.Enabled = true;
            }


            SortedDictionary<string, int> dictionaryFemale = curNomineeArr.GetSortedDictionaryMaleFemaleCity(false);

            Series seriesFemale = new Series("נשים");
            {
                seriesFemale.Color = Color.DeepPink;

                //סוג הגרף

                seriesFemale.ChartType = SeriesChartType.Column;

                //המידע שיוצג לכל רכיב ערך בגרף - 3

                //שם - VALX
                //הערך - VAL//#
                //אחוז עם אפס אחרי הנקודה - {P0} PERCENT

                seriesFemale.Label = "#VAL";

                seriesFemale.LegendText = "נשים";


                //הוספת הערכים מתוך משתנה המילון לסדרה

                seriesFemale.Points.DataBindXY(dictionaryFemale.Keys, dictionaryFemale.Values);
                seriesFemale.SmartLabelStyle.Enabled = true;
            }

            //מחיקת סדרות קיימות - אם יש ולא בכוונה

            chart1.Series.Clear();

            //הוספת הסדרה לפקד הגרף

            chart1.Series.Add(seriesMale);
            chart1.Series.Add(seriesFemale);
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
