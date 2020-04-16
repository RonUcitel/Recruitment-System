namespace Recruitment_System.UI
{
    partial class Position_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Position_Form));
            this.label_Id = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.listBox_Position = new System.Windows.Forms.ListBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.contextMenuStrip_Position = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_Sign = new System.Windows.Forms.GroupBox();
            this.label_Language = new System.Windows.Forms.Label();
            this.label_CapsLk = new System.Windows.Forms.Label();
            this.textBox_Filter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_Position = new System.Windows.Forms.GroupBox();
            this.button_Delete = new System.Windows.Forms.Button();
            this.contextMenuStrip_Position.SuspendLayout();
            this.groupBox_Sign.SuspendLayout();
            this.groupBox_Position.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Id
            // 
            this.label_Id.AutoSize = true;
            this.label_Id.Location = new System.Drawing.Point(587, 46);
            this.label_Id.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label_Id.Name = "label_Id";
            this.label_Id.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_Id.Size = new System.Drawing.Size(35, 37);
            this.label_Id.TabIndex = 0;
            this.label_Id.Text = "0";
            this.label_Id.TextChanged += new System.EventHandler(this.label_Id_TextChanged);
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(158, 97);
            this.textBox_Name.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_Name.Size = new System.Drawing.Size(308, 44);
            this.textBox_Name.TabIndex = 1;
            this.textBox_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_Name_Letter_KeyPress);
            this.textBox_Name.Leave += new System.EventHandler(this.TextBox_Name_Leave);
            // 
            // listBox_Position
            // 
            this.listBox_Position.FormattingEnabled = true;
            this.listBox_Position.ItemHeight = 37;
            this.listBox_Position.Location = new System.Drawing.Point(775, 106);
            this.listBox_Position.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.listBox_Position.Name = "listBox_Position";
            this.listBox_Position.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBox_Position.Size = new System.Drawing.Size(371, 448);
            this.listBox_Position.TabIndex = 18;
            this.listBox_Position.DoubleClick += new System.EventHandler(this.listBox_Position_DoubleClick);
            this.listBox_Position.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_Position_MouseDown);
            // 
            // button_Save
            // 
            this.button_Save.BackColor = System.Drawing.Color.Green;
            this.button_Save.Location = new System.Drawing.Point(377, 171);
            this.button_Save.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.button_Save.Name = "button_Save";
            this.button_Save.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_Save.Size = new System.Drawing.Size(238, 65);
            this.button_Save.TabIndex = 3;
            this.button_Save.Text = "שמור";
            this.button_Save.UseVisualStyleBackColor = false;
            this.button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(29, 171);
            this.button_Clear.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_Clear.Size = new System.Drawing.Size(238, 65);
            this.button_Clear.TabIndex = 4;
            this.button_Clear.Text = "נקה";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.Button_Clear_Click);
            // 
            // contextMenuStrip_Position
            // 
            this.contextMenuStrip_Position.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.contextMenuStrip_Position.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Remove});
            this.contextMenuStrip_Position.Name = "contextMenuStrip_Position";
            this.contextMenuStrip_Position.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip_Position.Size = new System.Drawing.Size(229, 60);
            // 
            // toolStripMenuItem_Remove
            // 
            this.toolStripMenuItem_Remove.BackColor = System.Drawing.Color.Red;
            this.toolStripMenuItem_Remove.Name = "toolStripMenuItem_Remove";
            this.toolStripMenuItem_Remove.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripMenuItem_Remove.Size = new System.Drawing.Size(228, 56);
            this.toolStripMenuItem_Remove.Text = "Remove";
            this.toolStripMenuItem_Remove.Click += new System.EventHandler(this.ToolStripMenuItem_Remove_Click);
            // 
            // groupBox_Sign
            // 
            this.groupBox_Sign.Controls.Add(this.label_Language);
            this.groupBox_Sign.Controls.Add(this.label_CapsLk);
            this.groupBox_Sign.Location = new System.Drawing.Point(43, 396);
            this.groupBox_Sign.Name = "groupBox_Sign";
            this.groupBox_Sign.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox_Sign.Size = new System.Drawing.Size(348, 165);
            this.groupBox_Sign.TabIndex = 19;
            this.groupBox_Sign.TabStop = false;
            // 
            // label_Language
            // 
            this.label_Language.AutoSize = true;
            this.label_Language.Location = new System.Drawing.Point(35, 80);
            this.label_Language.Name = "label_Language";
            this.label_Language.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_Language.Size = new System.Drawing.Size(160, 37);
            this.label_Language.TabIndex = 13;
            this.label_Language.Text = "Language";
            // 
            // label_CapsLk
            // 
            this.label_CapsLk.AutoSize = true;
            this.label_CapsLk.Location = new System.Drawing.Point(35, 40);
            this.label_CapsLk.Name = "label_CapsLk";
            this.label_CapsLk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_CapsLk.Size = new System.Drawing.Size(126, 37);
            this.label_CapsLk.TabIndex = 12;
            this.label_CapsLk.Text = "CapsLk";
            // 
            // textBox_Filter
            // 
            this.textBox_Filter.Location = new System.Drawing.Point(775, 32);
            this.textBox_Filter.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.textBox_Filter.Name = "textBox_Filter";
            this.textBox_Filter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_Filter.Size = new System.Drawing.Size(371, 44);
            this.textBox_Filter.TabIndex = 20;
            this.textBox_Filter.TextChanged += new System.EventHandler(this.textBox_Filter_TextChanged);
            this.textBox_Filter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_Filter_Letter_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(561, 100);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(61, 37);
            this.label1.TabIndex = 16;
            this.label1.Text = "שם:";
            // 
            // groupBox_Position
            // 
            this.groupBox_Position.Controls.Add(this.label_Id);
            this.groupBox_Position.Controls.Add(this.label1);
            this.groupBox_Position.Controls.Add(this.textBox_Name);
            this.groupBox_Position.Controls.Add(this.button_Save);
            this.groupBox_Position.Controls.Add(this.button_Clear);
            this.groupBox_Position.Location = new System.Drawing.Point(43, 32);
            this.groupBox_Position.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.groupBox_Position.Name = "groupBox_Position";
            this.groupBox_Position.Padding = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.groupBox_Position.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox_Position.Size = new System.Drawing.Size(633, 344);
            this.groupBox_Position.TabIndex = 21;
            this.groupBox_Position.TabStop = false;
            this.groupBox_Position.Text = "הוסף משרה חדשה";
            // 
            // button_Delete
            // 
            this.button_Delete.BackColor = System.Drawing.Color.Red;
            this.button_Delete.Location = new System.Drawing.Point(438, 489);
            this.button_Delete.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_Delete.Size = new System.Drawing.Size(238, 65);
            this.button_Delete.TabIndex = 22;
            this.button_Delete.Text = "מחק";
            this.button_Delete.UseVisualStyleBackColor = false;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // Position_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 592);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.listBox_Position);
            this.Controls.Add(this.groupBox_Sign);
            this.Controls.Add(this.textBox_Filter);
            this.Controls.Add(this.groupBox_Position);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Position_Form";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "רשימת משרות";
            this.Load += new System.EventHandler(this.Form_Position_Load);
            this.InputLanguageChanged += new System.Windows.Forms.InputLanguageChangedEventHandler(this.Form_position_InputLanguageChanged);
            this.contextMenuStrip_Position.ResumeLayout(false);
            this.groupBox_Sign.ResumeLayout(false);
            this.groupBox_Sign.PerformLayout();
            this.groupBox_Position.ResumeLayout(false);
            this.groupBox_Position.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Id;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.ListBox listBox_Position;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Position;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Remove;
        private System.Windows.Forms.GroupBox groupBox_Sign;
        private System.Windows.Forms.Label label_Language;
        private System.Windows.Forms.Label label_CapsLk;
        private System.Windows.Forms.TextBox textBox_Filter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.GroupBox groupBox_Position;
    }
}