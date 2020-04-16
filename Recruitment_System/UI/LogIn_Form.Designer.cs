namespace Recruitment_System.UI
{
    partial class LogIn_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn_Form));
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_LogIn = new System.Windows.Forms.Button();
            this.groupBox_Sign = new System.Windows.Forms.GroupBox();
            this.label_Language = new System.Windows.Forms.Label();
            this.label_CapsLk = new System.Windows.Forms.Label();
            this.groupBox_Sign.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_UserName.Location = new System.Drawing.Point(218, 84);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(481, 44);
            this.textBox_UserName.TabIndex = 0;
            this.textBox_UserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Password_KeyDown);
            // 
            // textBox_Password
            // 
            this.textBox_Password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Password.Location = new System.Drawing.Point(218, 214);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '*';
            this.textBox_Password.Size = new System.Drawing.Size(481, 44);
            this.textBox_Password.TabIndex = 1;
            this.textBox_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Password_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "שם משתמש:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 46);
            this.label2.TabIndex = 3;
            this.label2.Text = "סיסמה:";
            // 
            // button_LogIn
            // 
            this.button_LogIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_LogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_LogIn.Location = new System.Drawing.Point(218, 318);
            this.button_LogIn.Name = "button_LogIn";
            this.button_LogIn.Size = new System.Drawing.Size(298, 88);
            this.button_LogIn.TabIndex = 4;
            this.button_LogIn.Text = "התחבר";
            this.button_LogIn.UseVisualStyleBackColor = true;
            this.button_LogIn.Click += new System.EventHandler(this.button_LogIn_Click);
            // 
            // groupBox_Sign
            // 
            this.groupBox_Sign.Controls.Add(this.label_Language);
            this.groupBox_Sign.Controls.Add(this.label_CapsLk);
            this.groupBox_Sign.Location = new System.Drawing.Point(549, 307);
            this.groupBox_Sign.Name = "groupBox_Sign";
            this.groupBox_Sign.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox_Sign.Size = new System.Drawing.Size(239, 131);
            this.groupBox_Sign.TabIndex = 20;
            this.groupBox_Sign.TabStop = false;
            // 
            // label_Language
            // 
            this.label_Language.AutoSize = true;
            this.label_Language.Location = new System.Drawing.Point(6, 80);
            this.label_Language.Name = "label_Language";
            this.label_Language.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_Language.Size = new System.Drawing.Size(160, 37);
            this.label_Language.TabIndex = 13;
            this.label_Language.Text = "Language";
            // 
            // label_CapsLk
            // 
            this.label_CapsLk.AutoSize = true;
            this.label_CapsLk.Location = new System.Drawing.Point(6, 40);
            this.label_CapsLk.Name = "label_CapsLk";
            this.label_CapsLk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_CapsLk.Size = new System.Drawing.Size(126, 37);
            this.label_CapsLk.TabIndex = 12;
            this.label_CapsLk.Text = "CapsLk";
            // 
            // LogIn_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox_Sign);
            this.Controls.Add(this.button_LogIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_UserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LogIn_Form";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "מערכת גיוס עובדים";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogIn_Form_FormClosing);
            this.InputLanguageChanged += new System.Windows.Forms.InputLanguageChangedEventHandler(this.LogIn_Form_InputLanguageChanged);
            this.groupBox_Sign.ResumeLayout(false);
            this.groupBox_Sign.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_LogIn;
        private System.Windows.Forms.GroupBox groupBox_Sign;
        private System.Windows.Forms.Label label_Language;
        private System.Windows.Forms.Label label_CapsLk;
    }
}