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
using System.Collections;

namespace Recruitment_System.UI
{
    public enum ColumType
    {
        Date, Time, Nominee, Enty
    }
    public partial class Log_Form : Form
    {
        public Log_Form(int nomineeDBId, string name = "")
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            listView_Log.ListViewItemSorter = lvwColumnSorter;
            NomineeArrToForm(nomineeDBId);
            dateTimePicker_To.Value = DateTime.Now;
            UpdateListView_Log(nomineeDBId, DateTimePicker.MinimumDateTime, DateTimePicker.MaximumDateTime);
        }

        private ListViewColumnSorter lvwColumnSorter;

        private Bitmap[] m_bitmaps;
        private int pageNum;


        private void UpdateListView_Log(int nomineeDBId, DateTime from, DateTime to)
        {
            listView_Log.Clear();


            listView_Log.Columns.Add("תאריך");
            listView_Log.Columns.Add("שעה");
            listView_Log.Columns.Add("שם מועמד");
            listView_Log.Columns.Add("פעולה");

            LogEntryArr logEntryArr = new LogEntryArr();
            logEntryArr.Fill();
            logEntryArr = logEntryArr.Filter((int)comboBox_Nominee.SelectedValue, from, to);

            ListViewItem listViewItem;
            LogEntry logEntry;
            for (int i = 0; i < logEntryArr.Count; i++)
            {
                logEntry = logEntryArr[i] as LogEntry;
                listViewItem = new ListViewItem(logEntry.DateTime.ToString("dd-MM-yyyy"));
                listViewItem.SubItems.Add(logEntry.DateTime.ToString("HH:mm:ss"));
                listViewItem.SubItems.Add(logEntry.Nominee.ToString());
                listViewItem.SubItems.Add(logEntry.Entry);
                listView_Log.Items.Add(listViewItem);
            }



            //stop drawing the listview to prevent flickering.
            listView_Log.BeginUpdate();

            int width;
            foreach (ColumnHeader item in listView_Log.Columns)
            {
                //set the width to match the headersize and save the width in the int
                item.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                width = item.Width;

                //reset the width to match the columncontent size 
                item.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

                //if the header size is bigger then the column size the return to the headersize.
                if (width > item.Width)
                {
                    item.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                }

                //make the width bigger in abit.
                item.Width = (int)Math.Ceiling(item.Width * 1.5);
            }

            //redraw the listview
            listView_Log.EndUpdate();


            Size size = new Size(SystemInformation.VerticalScrollBarWidth, SystemInformation.HorizontalScrollBarHeight * 2 /*somehow the same as the columnHeader hight- wifh is unavailable*/);

            for (int i = 0; i < listView_Log.Columns.Count; i++)
            {
                size.Width += listView_Log.Columns[i].Width + 1;
            }
            for (int i = 0; i < listView_Log.Items.Count; i++)
            {
                size.Height += listView_Log.Items[i].Bounds.Height + 1;
            }
            listView_Log.Size = size;
        }


        private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(m_bitmaps[pageNum], new RectangleF(e.PageSettings.PrintableArea.Location, m_bitmaps[pageNum].Size));
            if (pageNum < m_bitmaps.Length - 1)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            pageNum++;
        }


        /*private void CaptureScreen()
        {
            //תפיסת החלק של הטופס להדפסה כולל הרשימה והכותרת שמעליה - לתוך תמונת הסיביות

            int addAboveListView = 30;
            int moveLeft = 150;
            Graphics graphics = listView_Log.CreateGraphics();
            Size curSize = listView_Log.Size;
            curSize.Height += addAboveListView;
            curSize.Width += moveLeft;
            m_bitmap = new Bitmap(curSize.Width, curSize.Height, graphics);
            graphics = Graphics.FromImage(m_bitmap);
            Point panelLocation = listView_Log.PointToScreen(new Point(listView_Log.Right, listView_Log.Top));
            graphics.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, listView_Log.Size);
        }*/

        private void הדפסדוחToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView_Log.SelectedIndices.Count; i++)
            {
                listView_Log.Items[listView_Log.SelectedIndices[i]].Selected = false;
            }
            button_CleaerFilter.Focus();
            SetPrint();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void listView_Log_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //disable selection
            if (e.IsSelected)
                e.Item.Selected = false;
        }

        private void SetPrint()
        {
            Size page = printDocument1.DefaultPageSettings.PrintableArea.Size.ToSize();
            pageNum = 0;
            Bitmap cap;

            cap = new Bitmap(listView_Log.Width, listView_Log.Height);

            listView_Log.DrawToBitmap(cap, new Rectangle(Point.Empty, listView_Log.Size));

            Rectangle recZoomSize = new Rectangle(0, 100, page.Width, cap.Height * page.Width / cap.Width);

            Bitmap fullDoc = new Bitmap(page.Width, recZoomSize.Height + 100);

            using (Graphics g = Graphics.FromImage(fullDoc))
            {
                //add the title
                Font font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point);

                g.DrawString("דוח תיעוד אירועים", font, new SolidBrush(Color.Black), new Rectangle(Point.Empty, page), new StringFormat(StringFormatFlags.DirectionRightToLeft));

                g.DrawImage(cap, recZoomSize);
            }


            int numOfPagesToPrint = Convert.ToInt32(Math.Ceiling(fullDoc.Height / (double)page.Height));

            Rectangle pageRec = new Rectangle(Point.Empty, page);


            m_bitmaps = new Bitmap[numOfPagesToPrint];
            for (int i = 0; i < m_bitmaps.Length; i++)
            {
                if (pageRec.Height < fullDoc.Height - pageRec.Height * i)
                {
                    m_bitmaps[i] = fullDoc.Clone(pageRec, fullDoc.PixelFormat);
                    pageRec.Y += pageRec.Height;
                }
                else
                {
                    pageRec.Height = fullDoc.Height - pageRec.Height * i;
                    m_bitmaps[i] = fullDoc.Clone(pageRec, fullDoc.PixelFormat);
                }


            }
        }

        private void toolStripMenuItem_ClearLog_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("פעולה זאת אינה ניתנת לשיחזור!\nהאם אתה רוצה להמשיך?", "אזהרה", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading))
            {
                LogEntryArr logEntryArr = new LogEntryArr();
                logEntryArr.Fill();
                if (!logEntryArr.DeleteArr())
                {
                    MessageBox.Show("קרתה תקלה בעת ביצוע המחיקה", "תקלה", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else
                {
                    UpdateListView_Log((int)comboBox_Nominee.SelectedValue, DateTimePicker.MinimumDateTime, DateTimePicker.MaximumDateTime);
                }

            }
        }

        private void button_Filter_Click(object sender, EventArgs e)
        {
            if (dateTimePicker_From.Value <= dateTimePicker_To.Value)
            {
                UpdateListView_Log((int)comboBox_Nominee.SelectedValue, dateTimePicker_From.Value, dateTimePicker_To.Value);

                if ((int)comboBox_Nominee.SelectedValue > 0)
                {
                    string name = (comboBox_Nominee.SelectedItem as Nominee).FullName;
                    Text = "תיעוד אירועים - " + name;
                }
                else
                {
                    Text = "תיעוד אירועים";
                }
            }
            else
            {
                MessageBox.Show("התאריך - שעה ההתחלתי חייב להיות קטן יותר מהתאריך - שעה הסופיים", "שגיאה!", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private void button_CleaerFilter_Click(object sender, EventArgs e)
        {
            UpdateListView_Log(0, DateTimePicker.MinimumDateTime, DateTime.Now);
            lvwColumnSorter.SortColumn = 0;
            lvwColumnSorter.Order = SortOrder.Ascending;
            listView_Log.Sort();
            Text = "תיעוד אירועים";
        }


        private void NomineeArrToForm(int nomineeDBId)
        {

            NomineeArr nomineeArr = new NomineeArr();
            nomineeArr.Fill();
            nomineeArr.Insert(0, Nominee.Empty);


            comboBox_Nominee.DataSource = nomineeArr;
            comboBox_Nominee.ValueMember = "DBId";
            comboBox_Nominee.DisplayMember = "FullName";
            comboBox_Nominee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_Nominee.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox_Nominee.SelectedValue = nomineeDBId;

            if ((int)comboBox_Nominee.SelectedValue > 0)
            {
                string name = (comboBox_Nominee.SelectedItem as Nominee).FullName;
                Text = "תיעוד אירועים - " + name;
            }
            else
            {
                Text = "תיעוד אירועים";
            }
        }

        private void listView_Log_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            listView_Log.Sort();
        }

        private void listView_Log_SizeChanged(object sender, EventArgs e)
        {
            ClientSize = new Size(ClientSize.Width, listView_Log.Height);
        }
    }

    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int ColumnToSort;

        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder OrderOfSort;
        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare the two items
            if (ColumnToSort == (int)ColumType.Date)
            {

                compareResult = ObjectCompare.Compare(
                    DateTime.ParseExact(listviewX.SubItems[ColumnToSort].Text, "dd-MM-yyyy", null), DateTime.ParseExact(listviewY.SubItems[ColumnToSort].Text, "dd-MM-yyyy", null));
            }
            else if (ColumnToSort == (int)ColumType.Time)
            {
                compareResult = ObjectCompare.Compare(
                       DateTime.ParseExact(listviewX.SubItems[ColumnToSort].Text, "HH:mm:ss", null), DateTime.ParseExact(listviewY.SubItems[ColumnToSort].Text, "HH:mm:ss", null));
            }
            else
            {
                compareResult = ObjectCompare.Compare(
                       listviewX.SubItems[ColumnToSort].Text,
                       listviewY.SubItems[ColumnToSort].Text);
            }

            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

    }
}
