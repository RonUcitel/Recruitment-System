namespace Recruitment_System.UI
{
    partial class ContactInformation_Report_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactInformation_Report_Form));
            this.listView1 = new System.Windows.Forms.ListView();
            this.printPreviewDialog_Reports = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument_Reports = new System.Drawing.Printing.PrintDocument();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_Clear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_LastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_FirstName = new System.Windows.Forms.TextBox();
            this.label_Phone = new System.Windows.Forms.Label();
            this.textBox_Cel = new System.Windows.Forms.TextBox();
            this.label_Email = new System.Windows.Forms.Label();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Position = new System.Windows.Forms.ComboBox();
            this.button_Print = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
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
            this.listView1.Size = new System.Drawing.Size(1150, 847);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
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
            this.printDocument_Reports.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_Reports_PrintPage);
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
            this.splitContainer1.Panel1.Controls.Add(this.button_Clear);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_LastName);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_FirstName);
            this.splitContainer1.Panel1.Controls.Add(this.label_Phone);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_Cel);
            this.splitContainer1.Panel1.Controls.Add(this.label_Email);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_Email);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_Position);
            this.splitContainer1.Panel1.Controls.Add(this.button_Print);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Panel1MinSize = 455;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(1614, 849);
            this.splitContainer1.SplitterDistance = 458;
            this.splitContainer1.TabIndex = 3;
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(40, 574);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(397, 54);
            this.button_Clear.TabIndex = 52;
            this.button_Clear.Text = "נקה סינון";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 137);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(152, 37);
            this.label3.TabIndex = 51;
            this.label3.Text = "שם משפחה:";
            // 
            // textBox_LastName
            // 
            this.textBox_LastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_LastName.Location = new System.Drawing.Point(40, 177);
            this.textBox_LastName.Name = "textBox_LastName";
            this.textBox_LastName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_LastName.Size = new System.Drawing.Size(397, 44);
            this.textBox_LastName.TabIndex = 50;
            this.textBox_LastName.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 34);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(122, 37);
            this.label2.TabIndex = 49;
            this.label2.Text = "שם פרטי:";
            // 
            // textBox_FirstName
            // 
            this.textBox_FirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_FirstName.Location = new System.Drawing.Point(40, 74);
            this.textBox_FirstName.Name = "textBox_FirstName";
            this.textBox_FirstName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_FirstName.Size = new System.Drawing.Size(397, 44);
            this.textBox_FirstName.TabIndex = 48;
            this.textBox_FirstName.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label_Phone
            // 
            this.label_Phone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Phone.AutoSize = true;
            this.label_Phone.Location = new System.Drawing.Point(355, 459);
            this.label_Phone.Name = "label_Phone";
            this.label_Phone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_Phone.Size = new System.Drawing.Size(89, 37);
            this.label_Phone.TabIndex = 47;
            this.label_Phone.Text = "טלפון:";
            // 
            // textBox_Cel
            // 
            this.textBox_Cel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Cel.Location = new System.Drawing.Point(40, 499);
            this.textBox_Cel.MaxLength = 7;
            this.textBox_Cel.Name = "textBox_Cel";
            this.textBox_Cel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_Cel.Size = new System.Drawing.Size(397, 44);
            this.textBox_Cel.TabIndex = 45;
            this.textBox_Cel.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label_Email
            // 
            this.label_Email.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Email.AutoSize = true;
            this.label_Email.Location = new System.Drawing.Point(347, 354);
            this.label_Email.Name = "label_Email";
            this.label_Email.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_Email.Size = new System.Drawing.Size(97, 37);
            this.label_Email.TabIndex = 46;
            this.label_Email.Text = "אימייל:";
            // 
            // textBox_Email
            // 
            this.textBox_Email.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Email.Location = new System.Drawing.Point(40, 394);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_Email.Size = new System.Drawing.Size(397, 44);
            this.textBox_Email.TabIndex = 44;
            this.textBox_Email.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(354, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 37);
            this.label1.TabIndex = 43;
            this.label1.Text = "משרה:";
            // 
            // comboBox_Position
            // 
            this.comboBox_Position.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Position.FormattingEnabled = true;
            this.comboBox_Position.Location = new System.Drawing.Point(40, 280);
            this.comboBox_Position.Name = "comboBox_Position";
            this.comboBox_Position.Size = new System.Drawing.Size(397, 45);
            this.comboBox_Position.TabIndex = 42;
            this.comboBox_Position.SelectedValueChanged += new System.EventHandler(this.comboBox_Position_SelectedValueChanged);
            // 
            // button_Print
            // 
            this.button_Print.Location = new System.Drawing.Point(40, 686);
            this.button_Print.Name = "button_Print";
            this.button_Print.Size = new System.Drawing.Size(397, 135);
            this.button_Print.TabIndex = 36;
            this.button_Print.Text = "הדפס";
            this.button_Print.UseVisualStyleBackColor = true;
            this.button_Print.Click += new System.EventHandler(this.button_Print_Click);
            // 
            // ContactInformation_Report_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1614, 849);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ContactInformation_Report_Form";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "פרטי קשר";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog_Reports;
        private System.Drawing.Printing.PrintDocument printDocument_Reports;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_Print;
        private System.Windows.Forms.Label label_Phone;
        private System.Windows.Forms.TextBox textBox_Cel;
        private System.Windows.Forms.Label label_Email;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Position;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_LastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_FirstName;
        private System.Windows.Forms.Button button_Clear;
    }
}