namespace Recruitment_System.UI
{
    partial class Log_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Log_Form));
            this.listView_Log = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.הדפסדוחToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView_Log
            // 
            this.listView_Log.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView_Log.ContextMenuStrip = this.contextMenuStrip1;
            this.listView_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Log.FullRowSelect = true;
            this.listView_Log.GridLines = true;
            this.listView_Log.HideSelection = false;
            this.listView_Log.Location = new System.Drawing.Point(0, 0);
            this.listView_Log.Name = "listView_Log";
            this.listView_Log.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listView_Log.RightToLeftLayout = true;
            this.listView_Log.Size = new System.Drawing.Size(1214, 657);
            this.listView_Log.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView_Log.TabIndex = 0;
            this.listView_Log.UseCompatibleStateImageBehavior = false;
            this.listView_Log.View = System.Windows.Forms.View.Details;
            this.listView_Log.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView_Log_ColumnWidthChanging);
            this.listView_Log.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView_Log_ItemSelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.הדפסדוחToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(249, 60);
            // 
            // הדפסדוחToolStripMenuItem
            // 
            this.הדפסדוחToolStripMenuItem.Name = "הדפסדוחToolStripMenuItem";
            this.הדפסדוחToolStripMenuItem.Size = new System.Drawing.Size(248, 56);
            this.הדפסדוחToolStripMenuItem.Text = "הדפס דוח";
            this.הדפסדוחToolStripMenuItem.Click += new System.EventHandler(this.הדפסדוחToolStripMenuItem_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.document_PrintPage);
            // 
            // Log_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 657);
            this.Controls.Add(this.listView_Log);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Log_Form";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "תיעוד אירועים";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView_Log;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem הדפסדוחToolStripMenuItem;
    }
}