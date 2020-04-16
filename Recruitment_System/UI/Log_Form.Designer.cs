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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.הדפסדוחToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_ClearLog = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label_Nominee = new System.Windows.Forms.Label();
            this.comboBox_Nominee = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_To = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_From = new System.Windows.Forms.DateTimePicker();
            this.button_CleaerFilter = new System.Windows.Forms.Button();
            this.button_Filter = new System.Windows.Forms.Button();
            this.label_To = new System.Windows.Forms.Label();
            this.label_From = new System.Windows.Forms.Label();
            this.listView_Log = new System.Windows.Forms.ListView();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.הדפסדוחToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem_ClearLog});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(249, 122);
            // 
            // הדפסדוחToolStripMenuItem
            // 
            this.הדפסדוחToolStripMenuItem.Name = "הדפסדוחToolStripMenuItem";
            this.הדפסדוחToolStripMenuItem.Size = new System.Drawing.Size(248, 56);
            this.הדפסדוחToolStripMenuItem.Text = "הדפס דוח";
            this.הדפסדוחToolStripMenuItem.Click += new System.EventHandler(this.הדפסדוחToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(245, 6);
            // 
            // toolStripMenuItem_ClearLog
            // 
            this.toolStripMenuItem_ClearLog.BackColor = System.Drawing.Color.Red;
            this.toolStripMenuItem_ClearLog.Name = "toolStripMenuItem_ClearLog";
            this.toolStripMenuItem_ClearLog.Size = new System.Drawing.Size(248, 56);
            this.toolStripMenuItem_ClearLog.Text = "נקה לוג";
            this.toolStripMenuItem_ClearLog.Click += new System.EventHandler(this.toolStripMenuItem_ClearLog_Click);
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
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label_Nominee);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_Nominee);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker_To);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker_From);
            this.splitContainer1.Panel1.Controls.Add(this.button_CleaerFilter);
            this.splitContainer1.Panel1.Controls.Add(this.button_Filter);
            this.splitContainer1.Panel1.Controls.Add(this.label_To);
            this.splitContainer1.Panel1.Controls.Add(this.label_From);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Panel1MinSize = 455;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView_Log);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(2114, 657);
            this.splitContainer1.SplitterDistance = 458;
            this.splitContainer1.TabIndex = 1;
            // 
            // label_Nominee
            // 
            this.label_Nominee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Nominee.AutoSize = true;
            this.label_Nominee.Location = new System.Drawing.Point(346, 26);
            this.label_Nominee.Name = "label_Nominee";
            this.label_Nominee.Size = new System.Drawing.Size(98, 37);
            this.label_Nominee.TabIndex = 35;
            this.label_Nominee.Text = "מועמד:";
            // 
            // comboBox_Nominee
            // 
            this.comboBox_Nominee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Nominee.FormattingEnabled = true;
            this.comboBox_Nominee.Location = new System.Drawing.Point(40, 66);
            this.comboBox_Nominee.Name = "comboBox_Nominee";
            this.comboBox_Nominee.Size = new System.Drawing.Size(397, 45);
            this.comboBox_Nominee.TabIndex = 34;
            // 
            // dateTimePicker_To
            // 
            this.dateTimePicker_To.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_To.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dateTimePicker_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_To.Location = new System.Drawing.Point(40, 241);
            this.dateTimePicker_To.Name = "dateTimePicker_To";
            this.dateTimePicker_To.RightToLeftLayout = true;
            this.dateTimePicker_To.Size = new System.Drawing.Size(397, 44);
            this.dateTimePicker_To.TabIndex = 33;
            this.dateTimePicker_To.Value = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            // 
            // dateTimePicker_From
            // 
            this.dateTimePicker_From.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_From.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dateTimePicker_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_From.Location = new System.Drawing.Point(40, 154);
            this.dateTimePicker_From.Name = "dateTimePicker_From";
            this.dateTimePicker_From.RightToLeftLayout = true;
            this.dateTimePicker_From.Size = new System.Drawing.Size(397, 44);
            this.dateTimePicker_From.TabIndex = 32;
            this.dateTimePicker_From.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // button_CleaerFilter
            // 
            this.button_CleaerFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_CleaerFilter.Location = new System.Drawing.Point(40, 545);
            this.button_CleaerFilter.Name = "button_CleaerFilter";
            this.button_CleaerFilter.Size = new System.Drawing.Size(397, 60);
            this.button_CleaerFilter.TabIndex = 5;
            this.button_CleaerFilter.Text = "נקה סינון";
            this.button_CleaerFilter.UseVisualStyleBackColor = true;
            this.button_CleaerFilter.Click += new System.EventHandler(this.button_CleaerFilter_Click);
            // 
            // button_Filter
            // 
            this.button_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Filter.Location = new System.Drawing.Point(40, 341);
            this.button_Filter.Name = "button_Filter";
            this.button_Filter.Size = new System.Drawing.Size(397, 130);
            this.button_Filter.TabIndex = 4;
            this.button_Filter.Text = "סנן";
            this.button_Filter.UseVisualStyleBackColor = true;
            this.button_Filter.Click += new System.EventHandler(this.button_Filter_Click);
            // 
            // label_To
            // 
            this.label_To.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_To.AutoSize = true;
            this.label_To.Location = new System.Drawing.Point(387, 201);
            this.label_To.Name = "label_To";
            this.label_To.Size = new System.Drawing.Size(57, 37);
            this.label_To.TabIndex = 3;
            this.label_To.Text = "עד:";
            // 
            // label_From
            // 
            this.label_From.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_From.AutoSize = true;
            this.label_From.Location = new System.Drawing.Point(402, 114);
            this.label_From.Name = "label_From";
            this.label_From.Size = new System.Drawing.Size(42, 37);
            this.label_From.TabIndex = 2;
            this.label_From.Text = "מ:";
            // 
            // listView_Log
            // 
            this.listView_Log.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView_Log.AutoArrange = false;
            this.listView_Log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView_Log.ContextMenuStrip = this.contextMenuStrip1;
            this.listView_Log.Dock = System.Windows.Forms.DockStyle.Top;
            this.listView_Log.FullRowSelect = true;
            this.listView_Log.GridLines = true;
            this.listView_Log.HideSelection = false;
            this.listView_Log.Location = new System.Drawing.Point(0, 0);
            this.listView_Log.Name = "listView_Log";
            this.listView_Log.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listView_Log.RightToLeftLayout = true;
            this.listView_Log.Size = new System.Drawing.Size(1650, 657);
            this.listView_Log.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView_Log.TabIndex = 1;
            this.listView_Log.UseCompatibleStateImageBehavior = false;
            this.listView_Log.View = System.Windows.Forms.View.Details;
            this.listView_Log.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_Log_ColumnClick);
            this.listView_Log.SizeChanged += new System.EventHandler(this.listView_Log_SizeChanged);
            // 
            // Log_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2114, 657);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(36, 760);
            this.Name = "Log_Form";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "תיעוד אירועים";
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem הדפסדוחToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ClearLog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listView_Log;
        private System.Windows.Forms.Button button_CleaerFilter;
        private System.Windows.Forms.Button button_Filter;
        private System.Windows.Forms.Label label_To;
        private System.Windows.Forms.Label label_From;
        private System.Windows.Forms.DateTimePicker dateTimePicker_To;
        private System.Windows.Forms.DateTimePicker dateTimePicker_From;
        private System.Windows.Forms.Label label_Nominee;
        private System.Windows.Forms.ComboBox comboBox_Nominee;
    }
}