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
            else if (tabControl_Main.SelectedTab == tabPage_Interview)
            {
                toolStripMenuItem_TableDesign.Visible = false;
                ArrsToForm();
                InterviewToForm(curInterview);


            }
            else if (tabControl_Main.SelectedTab == tabPage_Interviews)
            {
                toolStripMenuItem_TableDesign.Visible = false;
                InterviewArr interviewArr = new InterviewArr();
                ResetinterviewdateTimePickers(interviewArr);
                SetUpInterviewComboBoxes();
                InterviewArrToForm(interviewArr);
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


        #region tabInterview
        private void button_Interview_Delete_Click(object sender, EventArgs e)
        {
            if (curInterview != Interview.Empty)
            {
                if (curInterview.Delete())
                {
                    //MessageBox.Show();
                }
                else
                {
                    //MessageBox.Show();
                }
            }
        }


        private void button_Interview_Clear_Click(object sender, EventArgs e)
        {
            NomineeToForm(Nominee.Empty);
            InterviewToForm(Interview.Empty);
        }


        private void scorer_Interview_ScoreChanged(object sender, ScoreChangedEventArgs e)
        {
            InterviewCriterion interviewCriterion = e.InterviewCriterion;
        }


        private void InterviewToForm(Interview interview)
        {
            bool isNew = interview == Interview.Empty;

            SetInterviewPage(isNew);

            comboBox_Interview_Interviewer.SelectedValue = isNew ? curInterviewer.DBId : interview.Interviewer.DBId;

            if (isNew)
            {
                comboBox_Interview_Nominee.SelectedValue = int.Parse(label_DBID.Text);
            }
            else
            {
                comboBox_Interview_Nominee.SelectedValue = interview.Nominee.Id;
            }

            comboBox_Interview_Co_Interviewer.SelectedValue = interview.Co_Interviewer.DBId;

            comboBox_Interview_Position.SelectedValue = interview.Position.Id;

            dateTimePicker_Interview_Date.Value = interview.Date;

            label_Interview_Id.Text = interview.Id.ToString();

            scorer_Interview.SetDataSource(interview);
        }


        private Interview FormToInterview()
        {
            Interview interview = new Interview();
            interview.Id = int.Parse(label_Interview_Id.Text);

            interview.Position = comboBox_Interview_Position.SelectedItem != null ? comboBox_Interview_Position.SelectedItem as Position : Position.Empty;

            interview.Interviewer = comboBox_Interview_Interviewer.SelectedItem != null ? comboBox_Interview_Interviewer.SelectedItem as Interviewer : Interviewer.Empty;

            interview.Co_Interviewer = comboBox_Interview_Co_Interviewer.SelectedItem != null ? comboBox_Interview_Co_Interviewer.SelectedItem as Interviewer : Interviewer.Empty;

            interview.Nominee = comboBox_Interview_Nominee.SelectedItem != null ? comboBox_Interview_Nominee.SelectedItem as Nominee : Nominee.Empty;

            interview.Date = dateTimePicker_Interview_Date.Value;

            return interview;
        }


        private bool InterviewCheckForm()
        {
            bool isOk = true;

            isOk &= (comboBox_Interview_Interviewer.SelectedItem as Interviewer) != Interviewer.Empty;

            isOk &= (comboBox_Interview_Nominee.SelectedItem as Nominee) != Nominee.Empty;

            isOk &= (comboBox_Interview_Position.SelectedItem as Position) != Position.Empty;

            return isOk;
        }


        private void button_Interview_Save_Click(object sender, EventArgs e)
        {
            Interview interview = FormToInterview();
            if (curInterview == Interview.Empty)
            {
                //insert
                if (!InterviewCheckForm())
                {
                    //fail
                }
                else
                {
                    if (interview.Insert())
                    {
                        InterviewArr interviewArr = new InterviewArr();
                        interviewArr.Fill();
                        curInterview = interviewArr.GetInterviewWithMaxId();
                        InterviewToForm(curInterview);
                    }
                }
            }
            else
            {
                //update
                if (!InterviewCheckForm())
                {
                    //fail
                }
                else
                {
                    if (interview.Update())
                    {
                        InterviewArr interviewArr = new InterviewArr();
                        interviewArr.Fill();
                        curInterview = interviewArr.GetInterviewById(interview.Id);
                        InterviewToForm(curInterview);
                    }
                }
            }


        }


        private void button_Interview_Edit_Click(object sender, EventArgs e)
        {
            SetInterviewPage(true);
        }


        private void SetInterviewPage(bool isNewOrEdit)
        {
            panel_Interview_Buttons.Enabled = !isNewOrEdit;
            scorer_Interview.Enabled = !isNewOrEdit;
            comboBox_InterviewsPosition.Enabled = isNewOrEdit;
            comboBox_Interview_Co_Interviewer.Enabled = isNewOrEdit;
            comboBox_Interview_Nominee.Enabled = isNewOrEdit;
            button_Interview_Save.Visible = isNewOrEdit;
        }


        private void ArrsToForm()
        {
            PositionArr positionArr = new PositionArr();
            positionArr.Fill();
            positionArr.Insert(0, Position.Empty);

            comboBox_Interview_Position.DataSource = positionArr;
            comboBox_Interview_Position.ValueMember = "Id";
            comboBox_Interview_Position.DisplayMember = "Name";
            comboBox_Interview_Position.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_Interview_Position.AutoCompleteSource = AutoCompleteSource.ListItems;



            InterviewerArr interviewerArr = new InterviewerArr();
            interviewerArr.Fill();

            comboBox_Interview_Interviewer.DataSource = interviewerArr;
            comboBox_Interview_Interviewer.ValueMember = "DBId";
            comboBox_Interview_Interviewer.DisplayMember = "FullName";
            comboBox_Interview_Interviewer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_Interview_Interviewer.AutoCompleteSource = AutoCompleteSource.ListItems;



            interviewerArr = new InterviewerArr();
            interviewerArr.Fill();
            interviewerArr.Insert(0, Interviewer.Empty);

            comboBox_Interview_Co_Interviewer.DataSource = interviewerArr;
            comboBox_Interview_Co_Interviewer.ValueMember = "DBId";
            comboBox_Interview_Co_Interviewer.DisplayMember = "FullName";
            comboBox_Interview_Co_Interviewer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_Interview_Co_Interviewer.AutoCompleteSource = AutoCompleteSource.ListItems;



            NomineeArr nomineeArr = new NomineeArr();
            nomineeArr.Fill();
            nomineeArr.Insert(0, Nominee.Empty);

            comboBox_Interview_Nominee.DataSource = nomineeArr;
            comboBox_Interview_Nominee.ValueMember = "DBId";
            comboBox_Interview_Nominee.DisplayMember = "FullName";
            comboBox_Interview_Nominee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_Interview_Nominee.AutoCompleteSource = AutoCompleteSource.ListItems;


            dateTimePicker_Interview_Date.Value = DateTime.Now;
        }

        private void button_PrintScoreTable_Click(object sender, EventArgs e)
        {
            CaptureScreen(scorer_Interview);
            printPreviewDialog_Reports.Document = printDocument_Reports;
            printPreviewDialog_Reports.ShowDialog();
        }


        private void CaptureScreen(Scorer scorer)
        {
            Size page = printDocument_Reports.DefaultPageSettings.PrintableArea.Size.ToSize();

            Bitmap cap = new Bitmap(scorer.Width, scorer.Height);

            scorer.DrawToBitmap(cap, new Rectangle(Point.Empty, scorer.Size));

            cap = cap.Clone(new Rectangle(new Point(cap.Width - scorer.Width, 0), scorer.Size), cap.PixelFormat);


            Rectangle recZoomSize = new Rectangle(0, 100, page.Width, cap.Height * page.Width / cap.Width);

            m_bitmap = new Bitmap(page.Width, recZoomSize.Height + 100);

            using (Graphics g = Graphics.FromImage(m_bitmap))
            {
                //add the title
                Font font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point);

                g.DrawString("ציונים ע" + '"' + "י " + (comboBox_Interview_Interviewer.SelectedItem as Interviewer).FullName, font, new SolidBrush(Color.Black), new Rectangle(Point.Empty, page), new StringFormat(StringFormatFlags.DirectionRightToLeft)); ;

                g.DrawImage(cap, recZoomSize);
            }
        }
        #endregion


        #region Interviews

        private void SetUpInterviewComboBoxes()
        {
            #region Position
            PositionArr positionArr = new PositionArr();
            positionArr.Fill();
            positionArr.Insert(0, Position.Empty);

            comboBox_InterviewsPosition.DataSource = positionArr;
            comboBox_InterviewsPosition.ValueMember = "Id";
            comboBox_InterviewsPosition.DisplayMember = "Name";
            comboBox_InterviewsPosition.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_InterviewsPosition.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_InterviewsPosition.SelectedItem = Position.Empty;
            #endregion


            #region Interviewer
            InterviewerArr interviewerArr = new InterviewerArr();
            interviewerArr.Fill();
            interviewerArr.Insert(0, Interviewer.Empty);

            comboBox_InterviewsInterviewer.DataSource = interviewerArr;
            comboBox_InterviewsInterviewer.ValueMember = "DBId";
            comboBox_InterviewsInterviewer.DisplayMember = "FullName";
            comboBox_InterviewsInterviewer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_InterviewsInterviewer.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_InterviewsInterviewer.SelectedItem = Interviewer.Empty;
            #endregion


            #region Nominee
            NomineeArr nomineeArr = new NomineeArr();
            nomineeArr.Fill();
            nomineeArr.Insert(0, Nominee.Empty);

            comboBox_InterviewsNominee.DataSource = nomineeArr;
            comboBox_InterviewsNominee.ValueMember = "DBId";
            comboBox_InterviewsNominee.DisplayMember = "FullName";
            comboBox_InterviewsNominee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_InterviewsNominee.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_InterviewsNominee.SelectedItem = Nominee.Empty;
            #endregion
        }

        private void InterviewArrToForm(InterviewArr interviewArr)
        {
            listView_Interviews.Clear();

            listView_Interviews.Columns.Add("מראיין");
            listView_Interviews.Columns.Add("מועמד");
            listView_Interviews.Columns.Add("משרה");
            listView_Interviews.Columns.Add("תאריך");


            ListViewItem listViewItem;
            Interview interview;
            for (int i = 0; i < interviewArr.Count; i++)
            {
                interview = interviewArr[i] as Interview;
                listViewItem = new ListViewItem(interview.Interviewer.FullName);
                listViewItem.SubItems.Add(interview.Nominee.FullName);
                listViewItem.SubItems.Add(interview.Position.Name);
                listViewItem.SubItems.Add(interview.Date.ToString("dd-MM-yyyy"));
                listViewItem.Tag = interview;
                listView_Interviews.Items.Add(listViewItem);
            }


            listView_Interviews.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            foreach (ColumnHeader item in listView_Interviews.Columns)
            {
                item.Width = (int)Math.Ceiling(item.Width * 1.5);
            }
        }

        private void ResetinterviewdateTimePickers(InterviewArr interviewArr)
        {
            (DateTime min, DateTime max) edge = (DateTimePicker.MinimumDateTime, DateTimePicker.MaximumDateTime);


            DateTime x;
            for (int i = 0; i < interviewArr.Count; i++)
            {
                x = (interviewArr[i] as Interview).Date;

                edge.min = x < edge.min ? x : edge.min;

                edge.max = x > edge.max ? x : edge.max;
            }

            dateTimePicker_Interviews_From.MinDate = edge.min;
            dateTimePicker_Interviews_From.MaxDate = edge.max;
            dateTimePicker_Interviews_To.MinDate = edge.min;
            dateTimePicker_Interviews_To.MaxDate = edge.max;
        }


        private void button_InterviewsFilter_Click(object sender, EventArgs e)
        {
            InterviewArr interviewArr = new InterviewArr();
            interviewArr.Fill();
            interviewArr = interviewArr.Filter(comboBox_InterviewsInterviewer.SelectedItem as Interviewer, Interviewer.Empty, comboBox_InterviewsNominee.SelectedItem as Nominee, comboBox_InterviewsPosition.SelectedItem as Position, dateTimePicker_Interviews_From.Value, dateTimePicker_Interviews_To.Value);

            InterviewArrToForm(interviewArr);
        }


        private void button_InterviewsClear_Click(object sender, EventArgs e)
        {
            comboBox_InterviewsInterviewer.SelectedIndex = 0;
            comboBox_InterviewsNominee.SelectedIndex = 0;
            comboBox_InterviewsPosition.SelectedIndex = 0;
            InterviewArr interviewArr = new InterviewArr();
            interviewArr.Fill();
            ResetinterviewdateTimePickers(interviewArr);

            InterviewArrToForm(interviewArr);
        }


        private void dateTimePicker_Interviews_From_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_Interviews_To.MinDate = dateTimePicker_Interviews_From.Value;
        }


        private void dateTimePicker_Interviews_To_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_Interviews_From.MaxDate = dateTimePicker_Interviews_To.Value;
        }


        private void listView_Interviews_DoubleClick(object sender, EventArgs e)
        {
            //open the form
            Interview interview = listView_Interviews.SelectedItems[0].Tag as Interview;
        }
        #endregion
    }
}
