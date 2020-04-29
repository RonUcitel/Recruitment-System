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
    public partial class CriterionDate_Graph_Form : Form
    {
        public CriterionDate_Graph_Form()
        {
            InitializeComponent();
            ResetDateTimeMinMax(NomineeArrState.ShowEnabledOnly);
            PositionArrToForm();
            NomineeArrStateToForm();
            DataToChart(Position.Empty, minDate, maxDate, NomineeArrState.ShowEnabledOnly);
        }

        private DateTime minDate, maxDate;

        private void ResetDateTimeMinMax(NomineeArrState state)
        {
            InterviewCriterionArr interviewCriterionArr = new InterviewCriterionArr();
            interviewCriterionArr.Fill(state);

            interviewCriterionArr.SortByDateTime();
            try
            {
                minDate = (interviewCriterionArr[0] as InterviewCriterion).DateTime;
                maxDate = (interviewCriterionArr[interviewCriterionArr.Count - 1] as InterviewCriterion).DateTime;
            }
            catch
            {
                minDate = DateTimePicker.MinimumDateTime;
                maxDate = DateTimePicker.MaximumDateTime;
            }


            dateTimePicker_FromFilter.MinDate = minDate;
            dateTimePicker_FromFilter.MaxDate = maxDate;

            dateTimePicker_ToFilter.MinDate = minDate;
            dateTimePicker_ToFilter.MaxDate = maxDate;
        }

        public void DataToChart(Position position, DateTime from, DateTime to, NomineeArrState state)
        {/*
        
            //מחייב הצגת כל הערכים בציר האיקס, אם רוצים שיוצגו לסירוגין רושמים 2
            chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            //כותרת הגרף -1
            chart1.Titles.Clear();
            chart1.Titles.Add("ממוצע ציונים לחודש");
            //הוספת הערכים למשתנה מסוג מילון ממוין
            InterviewCriterionArr interviewCriterionArr = new InterviewCriterionArr();
            interviewCriterionArr.Fill(state);
            interviewCriterionArr = interviewCriterionArr.Filter(Interviewer.Empty, Nominee.Empty, position, from, to);


            chart1.Series.Clear();
            chart1.BeginInit();
            CriterionArr criterionArr = interviewCriterionArr.ToCriterionArr();
            Series series;
            Criterion criterion;
            SortedDictionary<string, float> dictionary;
            for (int i = 0; i < criterionArr.Count; i++)
            {
                criterion = criterionArr[i] as Criterion;
                dictionary = interviewCriterionArr.GetSortedDictionaryScore(criterion, from, to);

                //הגדרת סדרה וערכיה - שם הסדרה מועבר למקרא - 2


                series = new Series(criterion.NameWithPosition);

                //סוג הגרף

                series.ChartType = SeriesChartType.Line;

                //המידע שיוצג לכל רכיב ערך בגרף - 3

                //שם - VALX
                //הערך - VAL//#
                //אחוז עם אפס אחרי הנקודה - {P0} PERCENT

                series.Label = "#VAL";

                //series.LegendText = ;


                //הוספת הערכים מתוך משתנה המילון לסדרה

                series.Points.DataBindXY(dictionary.Keys, dictionary.Values);
                series.SmartLabelStyle.Enabled = true;

                chart1.Series.Add(series);
            }
            chart1.EndInit();


            //מחיקת סדרות קיימות - אם יש ולא בכוונה



            //הוספת הסדרה לפקד הגרף
        */
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
            DataToChart(comboBox_Position.SelectedItem as Position, dateTimePicker_FromFilter.Value, dateTimePicker_ToFilter.Value, (NomineeArrState)comboBox_NomineeState.SelectedIndex);
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            comboBox_Position.SelectedIndex = 0;
            comboBox_NomineeState.SelectedIndex = (int)NomineeArrState.ShowEnabledOnly;
            ResetDateTimeMinMax(NomineeArrState.ShowEnabledOnly);
            dateTimePicker_FromFilter.Value = minDate;
            dateTimePicker_ToFilter.Value = maxDate;

            DataToChart(comboBox_Position.SelectedItem as Position, minDate, maxDate, NomineeArrState.ShowEnabledOnly);
        }

        private void dateTimePicker_FromFilter_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_ToFilter.MinDate = dateTimePicker_FromFilter.Value;
        }

        private void dateTimePicker_ToFilter_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_FromFilter.MaxDate = dateTimePicker_ToFilter.Value;
        }
    }
}
