namespace Recruitment_System.UI
{
    partial class AdminTools_Form
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
            this.groupBox_Credentials = new System.Windows.Forms.GroupBox();
            this.checkBox_Admin = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.groupBox_PD = new System.Windows.Forms.GroupBox();
            this.label_DBID = new System.Windows.Forms.Label();
            this.label_ID = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label_LastName = new System.Windows.Forms.Label();
            this.textBox_LastName = new System.Windows.Forms.TextBox();
            this.label_FirstName = new System.Windows.Forms.Label();
            this.textBox_FirstName = new System.Windows.Forms.TextBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Search = new System.Windows.Forms.Button();
            this.listBox_Interviewers = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox_Credentials.SuspendLayout();
            this.groupBox_PD.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Credentials
            // 
            this.groupBox_Credentials.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Credentials.Controls.Add(this.label3);
            this.groupBox_Credentials.Controls.Add(this.textBox_Password);
            this.groupBox_Credentials.Controls.Add(this.label4);
            this.groupBox_Credentials.Controls.Add(this.textBox_UserName);
            this.groupBox_Credentials.Location = new System.Drawing.Point(12, 350);
            this.groupBox_Credentials.Name = "groupBox_Credentials";
            this.groupBox_Credentials.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox_Credentials.Size = new System.Drawing.Size(731, 211);
            this.groupBox_Credentials.TabIndex = 33;
            this.groupBox_Credentials.TabStop = false;
            this.groupBox_Credentials.Text = "פרטי התחברות";
            // 
            // checkBox_Admin
            // 
            this.checkBox_Admin.AutoSize = true;
            this.checkBox_Admin.Location = new System.Drawing.Point(457, 266);
            this.checkBox_Admin.Name = "checkBox_Admin";
            this.checkBox_Admin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_Admin.Size = new System.Drawing.Size(219, 41);
            this.checkBox_Admin.TabIndex = 27;
            this.checkBox_Admin.Text = "אדמיניסטרטור";
            this.checkBox_Admin.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(585, 138);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(98, 37);
            this.label3.TabIndex = 3;
            this.label3.Text = "סיסמה:";
            // 
            // textBox_Password
            // 
            this.textBox_Password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Password.Location = new System.Drawing.Point(65, 135);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_Password.Size = new System.Drawing.Size(460, 44);
            this.textBox_Password.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(531, 88);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(156, 37);
            this.label4.TabIndex = 1;
            this.label4.Text = "שם משתמש:";
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_UserName.Location = new System.Drawing.Point(65, 85);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_UserName.Size = new System.Drawing.Size(460, 44);
            this.textBox_UserName.TabIndex = 1;
            // 
            // groupBox_PD
            // 
            this.groupBox_PD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_PD.Controls.Add(this.checkBox_Admin);
            this.groupBox_PD.Controls.Add(this.label_DBID);
            this.groupBox_PD.Controls.Add(this.label_ID);
            this.groupBox_PD.Controls.Add(this.textBox_ID);
            this.groupBox_PD.Controls.Add(this.label_LastName);
            this.groupBox_PD.Controls.Add(this.textBox_LastName);
            this.groupBox_PD.Controls.Add(this.label_FirstName);
            this.groupBox_PD.Controls.Add(this.textBox_FirstName);
            this.groupBox_PD.Location = new System.Drawing.Point(12, 12);
            this.groupBox_PD.Name = "groupBox_PD";
            this.groupBox_PD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox_PD.Size = new System.Drawing.Size(731, 332);
            this.groupBox_PD.TabIndex = 28;
            this.groupBox_PD.TabStop = false;
            this.groupBox_PD.Text = "פרטים אישיים";
            // 
            // label_DBID
            // 
            this.label_DBID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_DBID.AutoSize = true;
            this.label_DBID.Location = new System.Drawing.Point(648, 40);
            this.label_DBID.Name = "label_DBID";
            this.label_DBID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_DBID.Size = new System.Drawing.Size(35, 37);
            this.label_DBID.TabIndex = 12;
            this.label_DBID.Text = "0";
            // 
            // label_ID
            // 
            this.label_ID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ID.AutoSize = true;
            this.label_ID.Location = new System.Drawing.Point(611, 188);
            this.label_ID.Name = "label_ID";
            this.label_ID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_ID.Size = new System.Drawing.Size(72, 37);
            this.label_ID.TabIndex = 5;
            this.label_ID.Text = "ת.ז.:";
            // 
            // textBox_ID
            // 
            this.textBox_ID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ID.Location = new System.Drawing.Point(65, 185);
            this.textBox_ID.MaxLength = 9;
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_ID.Size = new System.Drawing.Size(460, 44);
            this.textBox_ID.TabIndex = 3;
            // 
            // label_LastName
            // 
            this.label_LastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_LastName.AutoSize = true;
            this.label_LastName.Location = new System.Drawing.Point(531, 138);
            this.label_LastName.Name = "label_LastName";
            this.label_LastName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_LastName.Size = new System.Drawing.Size(152, 37);
            this.label_LastName.TabIndex = 3;
            this.label_LastName.Text = "שם משפחה:";
            // 
            // textBox_LastName
            // 
            this.textBox_LastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_LastName.Location = new System.Drawing.Point(65, 135);
            this.textBox_LastName.Name = "textBox_LastName";
            this.textBox_LastName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_LastName.Size = new System.Drawing.Size(460, 44);
            this.textBox_LastName.TabIndex = 2;
            // 
            // label_FirstName
            // 
            this.label_FirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FirstName.AutoSize = true;
            this.label_FirstName.Location = new System.Drawing.Point(561, 88);
            this.label_FirstName.Name = "label_FirstName";
            this.label_FirstName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_FirstName.Size = new System.Drawing.Size(122, 37);
            this.label_FirstName.TabIndex = 1;
            this.label_FirstName.Text = "שם פרטי:";
            // 
            // textBox_FirstName
            // 
            this.textBox_FirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_FirstName.Location = new System.Drawing.Point(65, 85);
            this.textBox_FirstName.Name = "textBox_FirstName";
            this.textBox_FirstName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_FirstName.Size = new System.Drawing.Size(460, 44);
            this.textBox_FirstName.TabIndex = 1;
            // 
            // button_Save
            // 
            this.button_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Save.BackColor = System.Drawing.Color.Green;
            this.button_Save.Location = new System.Drawing.Point(0, 212);
            this.button_Save.Name = "button_Save";
            this.button_Save.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_Save.Size = new System.Drawing.Size(415, 184);
            this.button_Save.TabIndex = 30;
            this.button_Save.Text = "שמור";
            this.button_Save.UseVisualStyleBackColor = false;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Clear.Location = new System.Drawing.Point(12, 603);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_Clear.Size = new System.Drawing.Size(731, 94);
            this.button_Clear.TabIndex = 31;
            this.button_Clear.Text = "נקה";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Delete.BackColor = System.Drawing.Color.Red;
            this.button_Delete.Location = new System.Drawing.Point(0, 593);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_Delete.Size = new System.Drawing.Size(189, 114);
            this.button_Delete.TabIndex = 18;
            this.button_Delete.Text = "מחק";
            this.button_Delete.UseVisualStyleBackColor = false;
            // 
            // button_Search
            // 
            this.button_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Search.Location = new System.Drawing.Point(6, 467);
            this.button_Search.Name = "button_Search";
            this.button_Search.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_Search.Size = new System.Drawing.Size(403, 94);
            this.button_Search.TabIndex = 29;
            this.button_Search.Text = "חפש";
            this.button_Search.UseVisualStyleBackColor = true;
            // 
            // listBox_Interviewers
            // 
            this.listBox_Interviewers.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox_Interviewers.FormattingEnabled = true;
            this.listBox_Interviewers.ItemHeight = 37;
            this.listBox_Interviewers.Location = new System.Drawing.Point(1170, 0);
            this.listBox_Interviewers.Name = "listBox_Interviewers";
            this.listBox_Interviewers.Size = new System.Drawing.Size(500, 715);
            this.listBox_Interviewers.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Delete);
            this.groupBox1.Controls.Add(this.button_Save);
            this.groupBox1.Controls.Add(this.button_Search);
            this.groupBox1.Location = new System.Drawing.Point(749, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(415, 703);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "פעולות";
            // 
            // AdminTools_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1670, 715);
            this.Controls.Add(this.groupBox_Credentials);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.groupBox_PD);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox_Interviewers);
            this.Name = "AdminTools_Form";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "AdminTools_Form";
            this.Load += new System.EventHandler(this.AdminTools_Form_Load);
            this.groupBox_Credentials.ResumeLayout(false);
            this.groupBox_Credentials.PerformLayout();
            this.groupBox_PD.ResumeLayout(false);
            this.groupBox_PD.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Credentials;
        private System.Windows.Forms.CheckBox checkBox_Admin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.GroupBox groupBox_PD;
        private System.Windows.Forms.Label label_DBID;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.Label label_LastName;
        private System.Windows.Forms.TextBox textBox_LastName;
        private System.Windows.Forms.Label label_FirstName;
        private System.Windows.Forms.TextBox textBox_FirstName;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.ListBox listBox_Interviewers;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}