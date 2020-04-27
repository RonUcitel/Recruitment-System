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
            PositionTypeArrToForm();
            DataToChart(PositionType.Empty, City.Empty);
        }

        public void DataToChart(PositionType positionType, City city)
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
            curNomineeArr = curNomineeArr.Filter(positionType, city);

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
            DataToChart(comboBox_PositionType.SelectedItem as PositionType, comboBox_City.SelectedItem as City);
        }

        private void PositionTypeArrToForm()
        {
            PositionTypeArr positionTypeArr = new PositionTypeArr();
            positionTypeArr.Fill();
            positionTypeArr.Insert(0, PositionType.Empty);

            comboBox_PositionType.DataSource = positionTypeArr;
            comboBox_PositionType.ValueMember = "Id";
            comboBox_PositionType.DisplayMember = "Name";
            comboBox_PositionType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_PositionType.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_PositionType.SelectedValue = 0;
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
            comboBox_PositionType.SelectedIndex = 0;
            comboBox_City.SelectedIndex = 0;
            DataToChart(comboBox_PositionType.SelectedItem as PositionType, comboBox_City.SelectedItem as City);
        }
    }
}
