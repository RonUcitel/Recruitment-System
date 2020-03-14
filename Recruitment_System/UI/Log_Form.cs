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
    public partial class Log_Form : Form
    {
        public Log_Form(int nomineeDBId)
        {
            InitializeComponent();
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
            listView_Log.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            foreach (ColumnHeader item in listView_Log.Columns)
            {
                item.Width = (int)(item.Width * 1.5);
            }
            SetHeight(listView_Log, 50);
        }

        private void listView_Log_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView_Log.Columns[e.ColumnIndex].Width;
        }

        private void SetHeight(ListView listView, int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            listView.SmallImageList = imgList;
        }
    }
}
