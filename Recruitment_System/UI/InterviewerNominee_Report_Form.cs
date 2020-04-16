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
    public partial class InterviewerNominee_Report_Form : Form
    {
        public InterviewerNominee_Report_Form()
        {
            InitializeComponent();
            InterviewerArrToForm();
            NomineeArrToForm();

            NomineeScoreTypeToTable(Interviewer.Empty, Nominee.Empty);
        }



        private Bitmap m_bitmap;

        private void CaptureScreen()
        {
            //תפיסת החלק של הטופס להדפסה כולל הרשימה והכותרת שמעליה - לתוך תמונת הסיביות

            Size listViewCapSize = new Size(0, SystemInformation.HorizontalScrollBarHeight);
            for (int i = 0; i < listView1.Columns.Count; i++)
            {
                listViewCapSize.Width += listView1.Columns[i].Width + 1;
            }
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listViewCapSize.Height += listView1.Items[i].Bounds.Height + 1;
            }


            Size page = printDocument_Reports.DefaultPageSettings.PrintableArea.Size.ToSize();

            Bitmap cap = new Bitmap(listView1.Width, listView1.Height);

            listView1.DrawToBitmap(cap, new Rectangle(Point.Empty, cap.Size));

            cap = cap.Clone(new Rectangle(new Point(cap.Width - listViewCapSize.Width, 0), listViewCapSize), cap.PixelFormat);


            Rectangle recZoomSize = new Rectangle(0, 100, page.Width, cap.Height * page.Width / cap.Width);

            m_bitmap = new Bitmap(page.Width, recZoomSize.Height + 100);

            using (Graphics g = Graphics.FromImage(m_bitmap))
            {
                //add the title
                Font font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point);

                g.DrawString("קריטריונים של משרות", font, new SolidBrush(Color.Black), new Rectangle(Point.Empty, page), new StringFormat(StringFormatFlags.DirectionRightToLeft));

                g.DrawImage(cap, recZoomSize);
            }
        }



        public void NomineeScoreTypeToTable(Interviewer interviewer, Nominee nominee)
        {
            //listView_Nominee
            NomineeScoreTypeArr nomineeScoreTypeArr = new NomineeScoreTypeArr();
            nomineeScoreTypeArr.Fill();
            nomineeScoreTypeArr = nomineeScoreTypeArr.Filter(interviewer, nominee, Position.Empty, DateTime.MinValue, DateTime.MaxValue);

            SortedDictionary<string, string> dictionary = nomineeScoreTypeArr.GetSortedDictionary();

            UpdateListView_Interviewer_Nominee(dictionary);
        }


        private void UpdateListView_Interviewer_Nominee(SortedDictionary<string, string> dictionary)
        {
            listView1.Clear();

            listView1.Columns.Add("משרה");
            listView1.Columns.Add("קריטריונים");

            ListViewItem listViewItem;
            string[] values;
            foreach (string key in dictionary.Keys)
            {
                values = dictionary[key].Split('\n');

                listViewItem = new ListViewItem(key);
                listViewItem.SubItems.Add(values[0]);
                listViewItem.BackColor = Color.LightGreen;

                listView1.Items.Add(listViewItem);

                for (int i = 1; i < values.Length; i++)
                {
                    listViewItem = new ListViewItem("");
                    listViewItem.SubItems.Add(values[i]);

                    listView1.Items.Add(listViewItem);
                }

                listView1.Items.Add(new ListViewItem(""));
            }


            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            foreach (ColumnHeader item in listView1.Columns)
            {
                item.Width = (int)Math.Ceiling(item.Width * 1.5);
            }
        }



        private void printDocument_Reports_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(m_bitmap, new RectangleF(e.PageSettings.PrintableArea.Location, m_bitmap.Size));
        }


        private void InterviewerArrToForm()
        {
            InterviewerArr interviewerArr = new InterviewerArr();
            interviewerArr.Fill();
            interviewerArr.Insert(0, Interviewer.Empty);

            comboBox_Interviewer.SelectedValueChanged -= comboBox_Interviewer_SelectedValueChanged;
            comboBox_Interviewer.DataSource = interviewerArr;
            comboBox_Interviewer.ValueMember = "DBId";
            comboBox_Interviewer.DisplayMember = "Fullname";
            comboBox_Interviewer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_Interviewer.AutoCompleteSource = AutoCompleteSource.ListItems;

            comboBox_Interviewer.SelectedIndex = 0;

            comboBox_Interviewer.SelectedValueChanged += comboBox_Interviewer_SelectedValueChanged;

        }


        private void NomineeArrToForm()
        {
            NomineeArr nomineeArr = new NomineeArr();
            nomineeArr.Fill();
            nomineeArr.Insert(0, Nominee.Empty);

            comboBox_Nominee.SelectedValueChanged -= comboBox_Nominee_SelectedValueChanged;
            comboBox_Nominee.DataSource = nomineeArr;
            comboBox_Nominee.ValueMember = "DBId";
            comboBox_Nominee.DisplayMember = "Fullname";
            comboBox_Nominee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_Nominee.AutoCompleteSource = AutoCompleteSource.ListItems;

            comboBox_Nominee.SelectedIndex = 0;

            comboBox_Nominee.SelectedValueChanged += comboBox_Nominee_SelectedValueChanged;

        }


        private void comboBox_Interviewer_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((int)comboBox_Interviewer.SelectedValue != 0 && (int)comboBox_Nominee.SelectedValue != 0)
            {
                comboBox_Nominee.SelectedValueChanged -= comboBox_Nominee_SelectedValueChanged;
                comboBox_Nominee.SelectedValue = 0;
                comboBox_Nominee.SelectedValueChanged += comboBox_Nominee_SelectedValueChanged;
                NomineeScoreTypeToTable(comboBox_Interviewer.SelectedItem as Interviewer, Nominee.Empty);
            }
            else if ((int)comboBox_Interviewer.SelectedValue == 0 && (int)comboBox_Nominee.SelectedValue == 0)
            {
                NomineeScoreTypeToTable(Interviewer.Empty, Nominee.Empty);
            }
        }


        private void comboBox_Nominee_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((int)comboBox_Nominee.SelectedValue != 0 && (int)comboBox_Interviewer.SelectedValue != 0)
            {
                comboBox_Interviewer.SelectedValueChanged -= comboBox_Interviewer_SelectedValueChanged;
                comboBox_Interviewer.SelectedValue = 0;
                comboBox_Interviewer.SelectedValueChanged += comboBox_Interviewer_SelectedValueChanged;
                NomineeScoreTypeToTable(Interviewer.Empty, comboBox_Nominee.SelectedItem as Nominee);
            }
            else if ((int)comboBox_Interviewer.SelectedValue == 0 && (int)comboBox_Nominee.SelectedValue == 0)
            {
                NomineeScoreTypeToTable(Interviewer.Empty, Nominee.Empty);
            }
        }


        private void button_Print_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printPreviewDialog_Reports.Document = printDocument_Reports;
            printPreviewDialog_Reports.ShowDialog();
        }

    }
}
