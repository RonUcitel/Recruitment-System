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
    public partial class ContactInformation_Report_Form : Form
    {
        public ContactInformation_Report_Form()
        {
            InitializeComponent();
            PositionArrToForm();
            NomineeTypeArrToTable("", "", "", "", PositionType.Empty);
        }


        private Bitmap m_bitmap;

        private void CaptureScreen()
        {
            //תפיסת החלק של הטופס להדפסה כולל הרשימה והכותרת שמעליה - לתוך תמונת הסיביות




            Size page = printDocument_Reports.DefaultPageSettings.PrintableArea.Size.ToSize();

            Bitmap cap = new Bitmap(listView1.Width, listView1.Height);

            listView1.DrawToBitmap(cap, new Rectangle(Point.Empty, cap.Size));


            Rectangle recZoomSize = new Rectangle(0, 100, page.Width, cap.Height * page.Width / cap.Width);

            m_bitmap = new Bitmap(page.Width, recZoomSize.Height + 100);

            using (Graphics g = Graphics.FromImage(m_bitmap))
            {
                //add the title
                Font font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point);

                g.DrawString("פרטי קשר", font, new SolidBrush(Color.Black), new Rectangle(Point.Empty, page), new StringFormat(StringFormatFlags.DirectionRightToLeft));

                g.DrawImage(cap, recZoomSize);
            }
        }




        public void NomineeTypeArrToTable(string firstName, string lastName, string email, string phone, PositionType position)
        {
            //listView_Nominee
            NomineeArr nomineeArr = new NomineeArr();
            nomineeArr.Fill();
            nomineeArr = nomineeArr.Filter(firstName, lastName, email, phone, position);

            /*SortedDictionary<string, string> dictionary = nomineeArr.GetSortedDictionary();*/

            UpdateListView_Nominee(nomineeArr);
        }


        private void UpdateListView_Nominee(NomineeArr nomineeArr)
        {
            listView1.Clear();

            listView1.Columns.Add("שם");
            listView1.Columns.Add("טלפון");
            listView1.Columns.Add("אימייל");

            ListViewItem listViewItem;
            Nominee nominee;
            for (int i = 0; i < nomineeArr.Count; i++)
            {
                nominee = nomineeArr[i] as Nominee;

                listViewItem = new ListViewItem(nominee.ToString());
                listViewItem.SubItems.Add(nominee.CellAreaCode + nominee.CellPhone);
                listViewItem.SubItems.Add(nominee.Email);

                listView1.Items.Add(listViewItem);
            }


            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            foreach (ColumnHeader item in listView1.Columns)
            {
                item.Width = (int)Math.Ceiling(item.Width * 1.5);
            }
        }


        private void comboBox_Position_SelectedValueChanged(object sender, EventArgs e)
        {
            NomineeTypeArrToTable(textBox_FirstName.Text, textBox_LastName.Text, textBox_Email.Text, textBox_Cel.Text, comboBox_Position.SelectedItem as PositionType);
        }


        private void button_Print_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printPreviewDialog_Reports.Document = printDocument_Reports;
            printPreviewDialog_Reports.ShowDialog();
        }



        private void textBox_TextChanged(object sender, EventArgs e)
        {
            NomineeTypeArrToTable(textBox_FirstName.Text, textBox_LastName.Text, textBox_Email.Text, textBox_Cel.Text, comboBox_Position.SelectedItem as PositionType);
        }


        private void PositionArrToForm()
        {
            PositionTypeArr positionArr = new PositionTypeArr();
            positionArr.Fill();
            positionArr.Insert(0, PositionType.Empty);

            comboBox_Position.SelectedValueChanged -= comboBox_Position_SelectedValueChanged;
            comboBox_Position.DataSource = positionArr;
            comboBox_Position.ValueMember = "Id";
            comboBox_Position.DisplayMember = "Name";
            comboBox_Position.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_Position.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_Position.SelectedValue = 0;
            comboBox_Position.SelectedValueChanged += comboBox_Position_SelectedValueChanged;
        }

        private void printDocument_Reports_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(m_bitmap, new RectangleF(e.PageSettings.PrintableArea.Location, m_bitmap.Size));
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            listView1.BeginUpdate();
            textBox_FirstName.Clear();
            textBox_LastName.Clear();
            textBox_Email.Clear();
            textBox_Cel.Clear();

            comboBox_Position.SelectedIndex = 0;
            listView1.EndUpdate();
        }
    }
}
