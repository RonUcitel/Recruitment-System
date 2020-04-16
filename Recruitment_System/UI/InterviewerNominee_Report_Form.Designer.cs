namespace Recruitment_System.UI
{
    partial class InterviewerNominee_Report_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InterviewerNominee_Report_Form));
            this.printPreviewDialog_Reports = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument_Reports = new System.Drawing.Printing.PrintDocument();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Nominee = new System.Windows.Forms.ComboBox();
            this.button_Print = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Interviewer = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // printPreviewDialog_Reports
            // 
            this.printPreviewDialog_Reports.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog_Reports.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog_Reports.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog_Reports.Enabled = true;
            this.printPreviewDialog_Reports.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog_Reports.Icon")));
            this.printPreviewDialog_Reports.Name = "printPreviewDialog1";
            this.printPreviewDialog_Reports.Visible = false;
            // 
            // printDocument_Reports
            // 
            this.printDocument_Reports.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_Reports_PrintPage_1);
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
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_Nominee);
            this.splitContainer1.Panel1.Controls.Add(this.button_Print);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_Interviewer);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Panel1MinSize = 455;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(1443, 849);
            this.splitContainer1.SplitterDistance = 458;
            this.splitContainer1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 37);
            this.label2.TabIndex = 38;
            this.label2.Text = "מועמד:";
            // 
            // comboBox_Nominee
            // 
            this.comboBox_Nominee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Nominee.FormattingEnabled = true;
            this.comboBox_Nominee.Location = new System.Drawing.Point(40, 378);
            this.comboBox_Nominee.Name = "comboBox_Nominee";
            this.comboBox_Nominee.Size = new System.Drawing.Size(397, 45);
            this.comboBox_Nominee.TabIndex = 37;
            this.comboBox_Nominee.SelectedValueChanged += new System.EventHandler(this.comboBox_Nominee_SelectedValueChanged);
            // 
            // button_Print
            // 
            this.button_Print.Location = new System.Drawing.Point(40, 641);
            this.button_Print.Name = "button_Print";
            this.button_Print.Size = new System.Drawing.Size(397, 135);
            this.button_Print.TabIndex = 36;
            this.button_Print.Text = "הדפס";
            this.button_Print.UseVisualStyleBackColor = true;
            this.button_Print.Click += new System.EventHandler(this.button_Print_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 37);
            this.label1.TabIndex = 35;
            this.label1.Text = "מראיין:";
            // 
            // comboBox_Interviewer
            // 
            this.comboBox_Interviewer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Interviewer.FormattingEnabled = true;
            this.comboBox_Interviewer.Location = new System.Drawing.Point(40, 241);
            this.comboBox_Interviewer.Name = "comboBox_Interviewer";
            this.comboBox_Interviewer.Size = new System.Drawing.Size(397, 45);
            this.comboBox_Interviewer.TabIndex = 34;
            this.comboBox_Interviewer.SelectedValueChanged += new System.EventHandler(this.comboBox_Interviewer_SelectedValueChanged);
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.AutoArrange = false;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listView1.RightToLeftLayout = true;
            this.listView1.Size = new System.Drawing.Size(979, 847);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // InterviewerNominee_Report_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 849);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InterviewerNominee_Report_Form";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "מראיינים כנגד מועמדים";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog_Reports;
        private System.Drawing.Printing.PrintDocument printDocument_Reports;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_Print;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Interviewer;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Nominee;
    }
}