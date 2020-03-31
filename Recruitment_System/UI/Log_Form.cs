﻿using System;
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
    public partial class Log_Form : Form
    {
        public Log_Form(int nomineeDBId, string name = "")
        {
            InitializeComponent();

            Text += ((name == "" || name == " ") ? name : " - ") + name;

            this.Tag = nomineeDBId;
            UpdateListView_Log(nomineeDBId);


            Size size = new Size(SystemInformation.VerticalScrollBarWidth, SystemInformation.HorizontalScrollBarHeight /*somehow the same as the columnHeader hight- wifh is unavailable*/);

            for (int i = 0; i < listView_Log.Columns.Count; i++)
            {
                size.Width += listView_Log.Columns[i].Width + 1;
            }
            for (int i = 0; i < listView_Log.Items.Count; i++)
            {
                size.Height += listView_Log.Items[i].Bounds.Height + 1;
            }
            this.ClientSize = size;
        }


        private Bitmap[] m_bitmaps;
        private int pageNum;

        private void listView_Log_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView_Log.Columns[e.ColumnIndex].Width;
        }


        private void UpdateListView_Log(int nomineeDBId)
        {
            listView_Log.Clear();

            if (nomineeDBId > 0)
            {
                listView_Log.Columns.Add("תאריך");
                listView_Log.Columns.Add("שעה");
                listView_Log.Columns.Add("פעולה");

                LogEntryArr logEntryArr = new LogEntryArr();
                logEntryArr.Fill();
                logEntryArr = logEntryArr.Filter(nomineeDBId, DateTime.MinValue, "");

                ListViewItem listViewItem;
                LogEntry logEntry;
                for (int i = 0; i < logEntryArr.Count; i++)
                {
                    logEntry = logEntryArr[i] as LogEntry;
                    listViewItem = new ListViewItem(logEntry.DateTime.ToString("dd-MM-yyyy"));
                    listViewItem.SubItems.Add(logEntry.DateTime.ToString("HH:mm:ss"));
                    listViewItem.SubItems.Add(logEntry.Entry);
                    listView_Log.Items.Add(listViewItem);
                }
            }
            else
            {
                listView_Log.Columns.Add("תאריך");
                listView_Log.Columns.Add("שעה");
                listView_Log.Columns.Add("שם מועמד");
                listView_Log.Columns.Add("פעולה");

                LogEntryArr logEntryArr = new LogEntryArr();
                logEntryArr.Fill();

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
            Bitmap cap = new Bitmap(listView_Log.Width, listView_Log.Height);

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
                    UpdateListView_Log((int)this.Tag);
                }

            }
        }
    }
}
