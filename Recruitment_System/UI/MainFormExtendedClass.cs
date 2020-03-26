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

namespace Recruitment_System.UI
{
    public partial class MainForm : Form
    {/*
        public void UpdateListView_Nominee(bool isOrderedByNominee)
        {
            listView_Nominee.Clear();

            if (isOrderedByNominee)
            {
                listView_Nominee.Columns.Add("מועמד");
                listView_Nominee.Columns.Add("משרות");

                PositionNomineeArr positionNomineeArr = new PositionNomineeArr();
                positionNomineeArr.Fill(isOrderedByNominee);



                ListViewItem listViewItem;
                PositionNominee cur = PositionNominee.Empty;

                for (int i = 0; i < positionNomineeArr.Count; i++)
                {
                    if ((positionNomineeArr[i] as PositionNominee) != cur)
                    {
                        cur = positionNomineeArr[i] as PositionNominee;
                        listViewItem = new ListViewItem(logEntry.DateTime.ToString("dd-MM-yyyy"));
                        listViewItem.SubItems.Add(logEntry.DateTime.ToString("HH:mm:ss"));
                        listViewItem.SubItems.Add(logEntry.Entry);
                        listView_Nominee.Items.Add(listViewItem);
                    }


                }


                for (int i = 0; i < positionNomineeArr.Count; i++)
                {
                    cur = positionNomineeArr[i] as PositionNominee;
                    listViewItem = new ListViewItem(logEntry.DateTime.ToString("dd-MM-yyyy"));
                    listViewItem.SubItems.Add(logEntry.DateTime.ToString("HH:mm:ss"));
                    listViewItem.SubItems.Add(logEntry.Entry);
                    listView_Nominee.Items.Add(listViewItem);
                }
            }
            else
            {
                listView_Nominee.Columns.Add("תאריך");
                listView_Nominee.Columns.Add("שעה");
                listView_Nominee.Columns.Add("שם מועמד");
                listView_Nominee.Columns.Add("פעולה");

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
                    listView_Nominee.Items.Add(listViewItem);
                }
            }
            listView_Nominee.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            foreach (ColumnHeader item in listView_Nominee.Columns)
            {
                item.Width = (int)(item.Width * 1.5);
            }
            SetHeight(listView_Nominee, 50);
        }

        private void listView_Nominee_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView_Nominee.Columns[e.ColumnIndex].Width;
        }

        private void SetHeight(ListView listView, int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            listView.SmallImageList = imgList;
        }
    */
    }
}
