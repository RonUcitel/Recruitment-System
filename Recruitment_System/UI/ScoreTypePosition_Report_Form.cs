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
    public partial class ScoreTypePosition_Report_Form : Form
    {
        public ScoreTypePosition_Report_Form()
        {
            InitializeComponent();
            PositionArrToForm();
            ScoreTypeArrToTable(Position.Empty);
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




        public void ScoreTypeArrToTable(Position position)
        {
            //listView_Nominee
            ScoreTypeArr scoreTypeArr = new ScoreTypeArr();
            scoreTypeArr.Fill();
            scoreTypeArr = scoreTypeArr.Filter(position, "");

            SortedDictionary<string, string> dictionary = scoreTypeArr.GetSortedDictionary();

            UpdateListView_ScoreType_Position(dictionary);
        }


        private void UpdateListView_ScoreType_Position(SortedDictionary<string, string> dictionary)
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


        private void PositionArrToForm()
        {
            PositionArr positionArr = new PositionArr();
            positionArr.Fill();
            positionArr.Insert(0, Position.Empty);

            comboBox_Position.SelectedValueChanged -= comboBox_Position_SelectedValueChanged;
            comboBox_Position.DataSource = positionArr;
            comboBox_Position.ValueMember = "Id";
            comboBox_Position.DisplayMember = "Name";
            comboBox_Position.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_Position.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_Position.SelectedValue = 0;
            comboBox_Position.SelectedValueChanged += comboBox_Position_SelectedValueChanged;
        }


        private void comboBox_Position_SelectedValueChanged(object sender, EventArgs e)
        {
            ScoreTypeArrToTable(comboBox_Position.SelectedItem as Position);
        }


        private void button_Print_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printPreviewDialog_Reports.Document = printDocument_Reports;
            printPreviewDialog_Reports.ShowDialog();
        }


        private void printDocument_Reports_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(m_bitmap, new RectangleF(e.PageSettings.PrintableArea.Location, m_bitmap.Size));
        }
    }
}
