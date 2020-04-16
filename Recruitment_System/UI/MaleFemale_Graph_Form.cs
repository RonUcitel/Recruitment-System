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
    public partial class MaleFemale_Graph_Form : Form
    {
        public MaleFemale_Graph_Form()
        {
            InitializeComponent();
            CityArrToForm();
            PositionArrToForm();
            DataToChart(Position.Empty, City.Empty);
        }

        public void DataToChart(Position position, City city)
        {
            //פלטת הצבעים -אפשר גם להגדיר מראש במאפיינים )לא בקוד(
            chart1.Palette = ChartColorPalette.Excel;
            //מחייב הצגת כל הערכים בציר האיקס, אם רוצים שיוצגו לסירוגין רושמים 2
            chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            //כותרת הגרף -1
            chart1.Titles.Clear();
            chart1.Titles.Add("יחס גברים - נשים");
            //הוספת הערכים למשתנה מסוג מילון ממוין
            NomineeArr curNomineeArr = new NomineeArr();
            curNomineeArr.FillEnabled();
            curNomineeArr = curNomineeArr.Filter(position, city);

            SortedDictionary<string, int> dictionary = curNomineeArr.GetSortedDictionaryMaleFemaleProportion();

            //הגדרת סדרה וערכיה - שם הסדרה מועבר למקרא - 2

            Series series = new Series("התפלגות", 0);

            //סוג הגרף

            series.ChartType = SeriesChartType.Doughnut;

            //המידע שיוצג לכל רכיב ערך בגרף - 3

            //שם - VALX
            //הערך - VAL//#
            //אחוז עם אפס אחרי הנקודה - {P0} PERCENT

            series.Label = "#PERCENT{P0}";

            series.LegendText = "#VALX";


            //הוספת הערכים מתוך משתנה המילון לסדרה

            series.Points.DataBindXY(dictionary.Keys, dictionary.Values);
            series.SmartLabelStyle.Enabled = true;


            //מחיקת סדרות קיימות - אם יש ולא בכוונה

            chart1.Series.Clear();

            //הוספת הסדרה לפקד הגרף

            chart1.Series.Add(series);
        }

        private void button_Filter_Click(object sender, EventArgs e)
        {
            DataToChart(comboBox_Position.SelectedItem as Position, comboBox_City.SelectedItem as City);
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

        private void CityArrToForm()
        {
            CityArr cityArr = new CityArr();
            cityArr.Fill();
            cityArr.Insert(0, City.Empty);

            comboBox_City.DataSource = cityArr;
            comboBox_City.ValueMember = "Id";
            comboBox_City.DisplayMember = "Name";
            comboBox_City.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_City.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_City.SelectedValue = 0;
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            comboBox_Position.SelectedIndex = 0;
            comboBox_City.SelectedIndex = 0;
            DataToChart(comboBox_Position.SelectedItem as Position, comboBox_City.SelectedItem as City);
        }
    }
}
