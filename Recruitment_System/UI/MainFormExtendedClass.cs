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
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;

namespace Recruitment_System.UI
{
    public partial class MainForm
    {
        private Bitmap m_bitmap;


        private void tabControl_Main_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl_Main.SelectedTab == tabPage_PositionNomineeChart)
            {
                toolStripMenuItem_TableDesign.Visible = false;
                DataToChart(GetCurNomineeArrState());


            }
            else if (tabControl_Main.SelectedTab == tabPage_PositionNomineeTable)
            {
                PositionNomineeArrToTable(GetCurNomineeArrState());
                toolStripMenuItem_TableDesign.Visible = true;
            }
            else if (tabControl_Main.SelectedTab == tabPage_Score)
            {
                toolStripMenuItem_TableDesign.Visible = false;
                FilterArrsToForm();
                scorer_View.SetDataSource(new NomineeScoreTypeArr(), Interviewer.Empty);

            }
            else
            {
                toolStripMenuItem_TableDesign.Visible = false;
            }
        }


        #region tabPageTable

        private void listView_PositionNominee_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
                e.Item.Selected = false;
        }

        private void CaptureScreen(ListView listViewCap)
        {
            //תפיסת החלק של הטופס להדפסה כולל הרשימה והכותרת שמעליה - לתוך תמונת הסיביות

            Size listViewCapSize = new Size(0, SystemInformation.HorizontalScrollBarHeight);
            for (int i = 0; i < listViewCap.Columns.Count; i++)
            {
                listViewCapSize.Width += listViewCap.Columns[i].Width + 1;
            }
            for (int i = 0; i < listViewCap.Items.Count; i++)
            {
                listViewCapSize.Height += listViewCap.Items[i].Bounds.Height + 1;
            }


            Size page = printDocument_Reports.DefaultPageSettings.PrintableArea.Size.ToSize();

            Bitmap cap = new Bitmap(listViewCap.Width, listViewCap.Height);

            listViewCap.DrawToBitmap(cap, new Rectangle(Point.Empty, cap.Size));

            cap = cap.Clone(new Rectangle(new Point(cap.Width - listViewCapSize.Width, 0), listViewCapSize), cap.PixelFormat);


            Rectangle recZoomSize = new Rectangle(0, 100, page.Width, cap.Height * page.Width / cap.Width);

            m_bitmap = new Bitmap(page.Width, recZoomSize.Height + 100);

            using (Graphics g = Graphics.FromImage(m_bitmap))
            {
                //add the title
                Font font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point);
                if (toolStripMenuItem_Sort.Checked)
                {
                    g.DrawString("מועמדים כנגד משרות", font, new SolidBrush(Color.Black), new Rectangle(Point.Empty, page), new StringFormat(StringFormatFlags.DirectionRightToLeft));
                }
                else
                {
                    g.DrawString("משרות כנגד מעומדים", font, new SolidBrush(Color.Black), new Rectangle(Point.Empty, page), new StringFormat(StringFormatFlags.DirectionRightToLeft));
                }

                g.DrawImage(cap, recZoomSize);
            }
        }


        private void printDocument_Table_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(m_bitmap, new RectangleF(e.PageSettings.PrintableArea.Location, m_bitmap.Size));
        }


        private void הדפסToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaptureScreen(listView_PositionNominee);
            printPreviewDialog_Reports.Document = printDocument_Reports;
            printPreviewDialog_Reports.ShowDialog();
        }


        private void toolStripMenuItem_Sort_Click(object sender, EventArgs e)
        {
            toolStripMenuItem_Sort.Checked = !toolStripMenuItem_Sort.Checked;
            PositionNomineeArrToTable(GetCurNomineeArrState());
        }


        public void PositionNomineeArrToTable(NomineeArrState state)
        {
            //listView_Nominee
            PositionNomineeArr positionNomineeArr = new PositionNomineeArr();
            positionNomineeArr.Fill(state, false);

            SortedDictionary<string, string> dictionary = positionNomineeArr.GetSortedDictionary(toolStripMenuItem_Sort.Checked);

            UpdateListView_PositionNominee(dictionary, toolStripMenuItem_Sort.Checked);
        }


        private void UpdateListView_PositionNominee(SortedDictionary<string, string> dictionary, bool sortByNominee)
        {
            listView_PositionNominee.Clear();

            if (sortByNominee)
            {
                listView_PositionNominee.Columns.Add("מועמד");
                listView_PositionNominee.Columns.Add("משרות");
            }
            else
            {
                listView_PositionNominee.Columns.Add("משרה");
                listView_PositionNominee.Columns.Add("מועמדים");
            }

            ListViewItem listViewItem;
            string[] values;
            foreach (string key in dictionary.Keys)
            {
                values = dictionary[key].Split('\n');

                listViewItem = new ListViewItem(key);
                listViewItem.SubItems.Add(values[0]);
                listViewItem.BackColor = Color.LightGreen;

                listView_PositionNominee.Items.Add(listViewItem);

                for (int i = 1; i < values.Length; i++)
                {
                    listViewItem = new ListViewItem("");
                    listViewItem.SubItems.Add(values[i]);

                    listView_PositionNominee.Items.Add(listViewItem);
                }

                listView_PositionNominee.Items.Add(new ListViewItem(""));
            }


            listView_PositionNominee.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            foreach (ColumnHeader item in listView_PositionNominee.Columns)
            {
                item.Width = (int)Math.Ceiling(item.Width * 1.5);
            }
        }


        #endregion


        #region tabPageChart


        public void DataToChart(NomineeArrState state)
        {
            //פלטת הצבעים -אפשר גם להגדיר מראש במאפיינים )לא בקוד(
            chart1.Palette = ChartColorPalette.Excel;
            //מחייב הצגת כל הערכים בציר האיקס, אם רוצים שיוצגו לסירוגין רושמים 2
            chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            //כותרת הגרף -1
            chart1.Titles.Clear();
            chart1.Titles.Add("ביקוש משרות");
            //הוספת הערכים למשתנה מסוג מילון ממוין
            PositionNomineeArr curPositionNomineeArr = new PositionNomineeArr();
            curPositionNomineeArr.Fill(state, false);

            SortedDictionary<string, int> dictionary = curPositionNomineeArr.GetSortedDictionary();

            //הגדרת סדרה וערכיה - שם הסדרה מועבר למקרא - 2

            Series series = new Series("התפלגות", 0);

            //סוג הגרף

            series.ChartType = SeriesChartType.Pie;

            //המידע שיוצג לכל רכיב ערך בגרף - 3

            //שם - VALX
            //הערך - VAL//#
            //אחוז עם אפס אחרי הנקודה - {P0} PERCENT

            series.Label = /*"#VALX*/ "#VAL [#PERCENT{P0}]";

            series.LegendText = "#VALX";


            //הוספת הערכים מתוך משתנה המילון לסדרה

            series.Points.DataBindXY(dictionary.Keys, dictionary.Values);
            series.SmartLabelStyle.Enabled = true;

            //מחיקת סדרות קיימות - אם יש ולא בכוונה

            chart1.Series.Clear();

            //הוספת הסדרה לפקד הגרף

            chart1.Series.Add(series);
        }


        #endregion


        #region tabPageScore


        private void DataToScorerViewer()
        {
            Position positionFilter = comboBox_PositionFilter.SelectedItem as Position;
            if (positionFilter == null)
            {
                positionFilter = Position.Empty;
            }


            Interviewer interviewerFilter = comboBox_InterviewerFilter.SelectedItem as Interviewer;
            if (interviewerFilter == null)
            {
                interviewerFilter = Interviewer.Empty;
            }

            Nominee nomineeFilter = comboBox_NomineeFilter.SelectedItem as Nominee;
            if (nomineeFilter == null)
            {
                nomineeFilter = Nominee.Empty;
            }


            NomineeScoreTypeArr nomineeScoreTypeArr = new NomineeScoreTypeArr();
            nomineeScoreTypeArr.Fill();
            nomineeScoreTypeArr = nomineeScoreTypeArr.Filter(interviewerFilter, nomineeFilter, positionFilter, dateTimePicker_FromFilter.Value, dateTimePicker_ToFilter.Value);

            scorer_View.SetDataSource(nomineeScoreTypeArr, interviewerFilter);
        }


        private void button_SearchScoreFilter_Click(object sender, EventArgs e)
        {
            DataToScorerViewer();
        }


        private void FilterArrsToForm()
        {
            PositionArr positionArr = new PositionArr();
            positionArr.Fill();
            positionArr.Insert(0, Position.Empty);

            comboBox_PositionFilter.DataSource = positionArr;
            comboBox_PositionFilter.ValueMember = "Id";
            comboBox_PositionFilter.DisplayMember = "Name";
            comboBox_PositionFilter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_PositionFilter.AutoCompleteSource = AutoCompleteSource.ListItems;



            InterviewerArr interviewerArr = new InterviewerArr();
            interviewerArr.Fill();

            comboBox_InterviewerFilter.DataSource = interviewerArr;
            comboBox_InterviewerFilter.ValueMember = "Id";
            comboBox_InterviewerFilter.DisplayMember = "FullName";
            comboBox_InterviewerFilter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_InterviewerFilter.AutoCompleteSource = AutoCompleteSource.ListItems;



            NomineeArr nomineeArr = new NomineeArr();
            nomineeArr.Fill();
            nomineeArr.Insert(0, Nominee.Empty);

            comboBox_NomineeFilter.DataSource = nomineeArr;
            comboBox_NomineeFilter.ValueMember = "Id";
            comboBox_NomineeFilter.DisplayMember = "FullName";
            comboBox_NomineeFilter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_NomineeFilter.AutoCompleteSource = AutoCompleteSource.ListItems;
        }


        private void button_ClearScoreFilter_Click(object sender, EventArgs e)
        {
            comboBox_PositionFilter.SelectedIndex = 0;
            comboBox_InterviewerFilter.SelectedIndex = 0;
            comboBox_NomineeFilter.SelectedIndex = 0;
            scorer_View.SetDataSource(new NomineeScoreTypeArr(), Interviewer.Empty);
        }


        private void button_PrintScoreTable_Click(object sender, EventArgs e)
        {
            CaptureScreen(scorer_View);
            printPreviewDialog_Reports.Document = printDocument_Reports;
            printPreviewDialog_Reports.ShowDialog();
        }


        private void CaptureScreen(ScorerViewer scorerViewer)
        {
            Size page = printDocument_Reports.DefaultPageSettings.PrintableArea.Size.ToSize();

            Bitmap cap = new Bitmap(scorerViewer.Width, scorerViewer.Height);

            scorerViewer.DrawToBitmap(cap, new Rectangle(Point.Empty, scorerViewer.Size));

            cap = cap.Clone(new Rectangle(new Point(cap.Width - scorerViewer.Width, 0), scorerViewer.Size), cap.PixelFormat);


            Rectangle recZoomSize = new Rectangle(0, 100, page.Width, cap.Height * page.Width / cap.Width);

            m_bitmap = new Bitmap(page.Width, recZoomSize.Height + 100);

            using (Graphics g = Graphics.FromImage(m_bitmap))
            {
                //add the title
                Font font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point);

                g.DrawString("ציונים ע" + '"' + "י " + (comboBox_InterviewerFilter.SelectedItem as Interviewer).FullName, font, new SolidBrush(Color.Black), new Rectangle(Point.Empty, page), new StringFormat(StringFormatFlags.DirectionRightToLeft)); ;

                g.DrawImage(cap, recZoomSize);
            }
        }
        #endregion
    }
}
