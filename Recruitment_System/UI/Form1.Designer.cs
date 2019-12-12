namespace Recruitment_System.UI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox_PD = new System.Windows.Forms.GroupBox();
            this.label_Position = new System.Windows.Forms.Label();
            this.comboBox_Position = new System.Windows.Forms.ComboBox();
            this.comboBox_CellAreaCode = new System.Windows.Forms.ComboBox();
            this.label_DBID = new System.Windows.Forms.Label();
            this.label_City = new System.Windows.Forms.Label();
            this.comboBox_City = new System.Windows.Forms.ComboBox();
            this.label_Phone = new System.Windows.Forms.Label();
            this.textBox_Cel = new System.Windows.Forms.TextBox();
            this.label_Email = new System.Windows.Forms.Label();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.label_ID = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label_LastName = new System.Windows.Forms.Label();
            this.textBox_LastName = new System.Windows.Forms.TextBox();
            this.label_FirstName = new System.Windows.Forms.Label();
            this.textBox_FirstName = new System.Windows.Forms.TextBox();
            this.groupBox_Ranking = new System.Windows.Forms.GroupBox();
            this.numericUpDown_GA = new System.Windows.Forms.NumericUpDown();
            this.label_GA = new System.Windows.Forms.Label();
            this.numericUpDown_Professionalism = new System.Windows.Forms.NumericUpDown();
            this.label_Professionalism = new System.Windows.Forms.Label();
            this.numericUpDown_Match = new System.Windows.Forms.NumericUpDown();
            this.label_Match = new System.Windows.Forms.Label();
            this.button_Add_CV = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_Search = new System.Windows.Forms.Button();
            this.listBox_Client = new System.Windows.Forms.ListBox();
            this.PDF_CV_Viewer = new AxAcroPDFLib.AxAcroPDF();
            this.button_Remove_CV = new System.Windows.Forms.Button();
            this.groupBox_PD.SuspendLayout();
            this.groupBox_Ranking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_GA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Professionalism)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Match)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PDF_CV_Viewer)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_PD
            // 
            this.groupBox_PD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_PD.Controls.Add(this.label_Position);
            this.groupBox_PD.Controls.Add(this.comboBox_Position);
            this.groupBox_PD.Controls.Add(this.comboBox_CellAreaCode);
            this.groupBox_PD.Controls.Add(this.label_DBID);
            this.groupBox_PD.Controls.Add(this.label_City);
            this.groupBox_PD.Controls.Add(this.comboBox_City);
            this.groupBox_PD.Controls.Add(this.label_Phone);
            this.groupBox_PD.Controls.Add(this.textBox_Cel);
            this.groupBox_PD.Controls.Add(this.label_Email);
            this.groupBox_PD.Controls.Add(this.textBox_Email);
            this.groupBox_PD.Controls.Add(this.label_ID);
            this.groupBox_PD.Controls.Add(this.textBox_ID);
            this.groupBox_PD.Controls.Add(this.label_LastName);
            this.groupBox_PD.Controls.Add(this.textBox_LastName);
            this.groupBox_PD.Controls.Add(this.label_FirstName);
            this.groupBox_PD.Controls.Add(this.textBox_FirstName);
            this.groupBox_PD.Location = new System.Drawing.Point(750, 12);
            this.groupBox_PD.Name = "groupBox_PD";
            this.groupBox_PD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox_PD.Size = new System.Drawing.Size(731, 509);
            this.groupBox_PD.TabIndex = 0;
            this.groupBox_PD.TabStop = false;
            this.groupBox_PD.Text = "פרטים אישיים";
            // 
            // label_Position
            // 
            this.label_Position.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Position.AutoSize = true;
            this.label_Position.Location = new System.Drawing.Point(593, 389);
            this.label_Position.Name = "label_Position";
            this.label_Position.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_Position.Size = new System.Drawing.Size(90, 37);
            this.label_Position.TabIndex = 15;
            this.label_Position.Text = "משרה:";
            // 
            // comboBox_Position
            // 
            this.comboBox_Position.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Position.FormattingEnabled = true;
            this.comboBox_Position.Location = new System.Drawing.Point(65, 386);
            this.comboBox_Position.Name = "comboBox_Position";
            this.comboBox_Position.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox_Position.Size = new System.Drawing.Size(460, 45);
            this.comboBox_Position.TabIndex = 14;
            this.comboBox_Position.Text = "מנהל";
            // 
            // comboBox_CellAreaCode
            // 
            this.comboBox_CellAreaCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_CellAreaCode.FormattingEnabled = true;
            this.comboBox_CellAreaCode.Items.AddRange(new object[] {
            "050",
            "051",
            "052",
            "053",
            "054",
            "055",
            "058",
            "059"});
            this.comboBox_CellAreaCode.Location = new System.Drawing.Point(65, 285);
            this.comboBox_CellAreaCode.Name = "comboBox_CellAreaCode";
            this.comboBox_CellAreaCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox_CellAreaCode.Size = new System.Drawing.Size(121, 45);
            this.comboBox_CellAreaCode.TabIndex = 13;
            this.comboBox_CellAreaCode.Text = "050";
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
            // label_City
            // 
            this.label_City.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_City.AutoSize = true;
            this.label_City.Location = new System.Drawing.Point(618, 338);
            this.label_City.Name = "label_City";
            this.label_City.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_City.Size = new System.Drawing.Size(65, 37);
            this.label_City.TabIndex = 11;
            this.label_City.Text = "עיר:";
            // 
            // comboBox_City
            // 
            this.comboBox_City.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_City.FormattingEnabled = true;
            this.comboBox_City.Location = new System.Drawing.Point(65, 335);
            this.comboBox_City.Name = "comboBox_City";
            this.comboBox_City.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox_City.Size = new System.Drawing.Size(460, 45);
            this.comboBox_City.TabIndex = 10;
            this.comboBox_City.Text = "תל אביב";
            // 
            // label_Phone
            // 
            this.label_Phone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Phone.AutoSize = true;
            this.label_Phone.Location = new System.Drawing.Point(594, 288);
            this.label_Phone.Name = "label_Phone";
            this.label_Phone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_Phone.Size = new System.Drawing.Size(89, 37);
            this.label_Phone.TabIndex = 9;
            this.label_Phone.Text = "טלפון:";
            // 
            // textBox_Cel
            // 
            this.textBox_Cel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Cel.Location = new System.Drawing.Point(192, 285);
            this.textBox_Cel.Name = "textBox_Cel";
            this.textBox_Cel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_Cel.Size = new System.Drawing.Size(333, 44);
            this.textBox_Cel.TabIndex = 8;
            this.textBox_Cel.Text = "5930503";
            // 
            // label_Email
            // 
            this.label_Email.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Email.AutoSize = true;
            this.label_Email.Location = new System.Drawing.Point(586, 238);
            this.label_Email.Name = "label_Email";
            this.label_Email.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_Email.Size = new System.Drawing.Size(97, 37);
            this.label_Email.TabIndex = 7;
            this.label_Email.Text = "אימייל:";
            // 
            // textBox_Email
            // 
            this.textBox_Email.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Email.Location = new System.Drawing.Point(65, 235);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_Email.Size = new System.Drawing.Size(460, 44);
            this.textBox_Email.TabIndex = 6;
            this.textBox_Email.Text = "ron.ucitel@hotmail.com";
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
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_ID.Size = new System.Drawing.Size(460, 44);
            this.textBox_ID.TabIndex = 4;
            this.textBox_ID.Text = "213102072";
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
            this.textBox_LastName.Text = "אוצ\'יטל";
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
            this.textBox_FirstName.TabIndex = 0;
            this.textBox_FirstName.Text = "רון";
            // 
            // groupBox_Ranking
            // 
            this.groupBox_Ranking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Ranking.Controls.Add(this.numericUpDown_GA);
            this.groupBox_Ranking.Controls.Add(this.label_GA);
            this.groupBox_Ranking.Controls.Add(this.numericUpDown_Professionalism);
            this.groupBox_Ranking.Controls.Add(this.label_Professionalism);
            this.groupBox_Ranking.Controls.Add(this.numericUpDown_Match);
            this.groupBox_Ranking.Controls.Add(this.label_Match);
            this.groupBox_Ranking.Location = new System.Drawing.Point(317, 12);
            this.groupBox_Ranking.Name = "groupBox_Ranking";
            this.groupBox_Ranking.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox_Ranking.Size = new System.Drawing.Size(409, 509);
            this.groupBox_Ranking.TabIndex = 1;
            this.groupBox_Ranking.TabStop = false;
            this.groupBox_Ranking.Text = "ניקוד";
            // 
            // numericUpDown_GA
            // 
            this.numericUpDown_GA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_GA.Location = new System.Drawing.Point(22, 192);
            this.numericUpDown_GA.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_GA.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_GA.Name = "numericUpDown_GA";
            this.numericUpDown_GA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numericUpDown_GA.Size = new System.Drawing.Size(174, 44);
            this.numericUpDown_GA.TabIndex = 11;
            this.numericUpDown_GA.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label_GA
            // 
            this.label_GA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_GA.AutoSize = true;
            this.label_GA.Location = new System.Drawing.Point(219, 194);
            this.label_GA.Name = "label_GA";
            this.label_GA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_GA.Size = new System.Drawing.Size(184, 37);
            this.label_GA.TabIndex = 10;
            this.label_GA.Text = "הערכה כללית:";
            // 
            // numericUpDown_Professionalism
            // 
            this.numericUpDown_Professionalism.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_Professionalism.Location = new System.Drawing.Point(22, 127);
            this.numericUpDown_Professionalism.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_Professionalism.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Professionalism.Name = "numericUpDown_Professionalism";
            this.numericUpDown_Professionalism.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numericUpDown_Professionalism.Size = new System.Drawing.Size(174, 44);
            this.numericUpDown_Professionalism.TabIndex = 9;
            this.numericUpDown_Professionalism.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label_Professionalism
            // 
            this.label_Professionalism.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Professionalism.AutoSize = true;
            this.label_Professionalism.Location = new System.Drawing.Point(270, 127);
            this.label_Professionalism.Name = "label_Professionalism";
            this.label_Professionalism.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_Professionalism.Size = new System.Drawing.Size(133, 37);
            this.label_Professionalism.TabIndex = 8;
            this.label_Professionalism.Text = "מקצועיות:";
            // 
            // numericUpDown_Match
            // 
            this.numericUpDown_Match.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_Match.Location = new System.Drawing.Point(22, 75);
            this.numericUpDown_Match.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_Match.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Match.Name = "numericUpDown_Match";
            this.numericUpDown_Match.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numericUpDown_Match.Size = new System.Drawing.Size(174, 44);
            this.numericUpDown_Match.TabIndex = 1;
            this.numericUpDown_Match.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label_Match
            // 
            this.label_Match.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Match.AutoSize = true;
            this.label_Match.Location = new System.Drawing.Point(295, 77);
            this.label_Match.Name = "label_Match";
            this.label_Match.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_Match.Size = new System.Drawing.Size(108, 37);
            this.label_Match.TabIndex = 0;
            this.label_Match.Text = "התאמה:";
            // 
            // button_Add_CV
            // 
            this.button_Add_CV.AllowDrop = true;
            this.button_Add_CV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Add_CV.Location = new System.Drawing.Point(1349, 541);
            this.button_Add_CV.Name = "button_Add_CV";
            this.button_Add_CV.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_Add_CV.Size = new System.Drawing.Size(132, 157);
            this.button_Add_CV.TabIndex = 12;
            this.button_Add_CV.Text = "הוסף קורות חיים";
            this.button_Add_CV.UseVisualStyleBackColor = true;
            this.button_Add_CV.Click += new System.EventHandler(this.button_Add_CV_Click);
            this.button_Add_CV.DragDrop += new System.Windows.Forms.DragEventHandler(this.button_File_DragDrop);
            this.button_Add_CV.DragEnter += new System.Windows.Forms.DragEventHandler(this.button_File_DragEnter);
            // 
            // button_Save
            // 
            this.button_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Save.Location = new System.Drawing.Point(345, 528);
            this.button_Save.Name = "button_Save";
            this.button_Save.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_Save.Size = new System.Drawing.Size(289, 94);
            this.button_Save.TabIndex = 2;
            this.button_Save.Text = "שמור";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Clear.Location = new System.Drawing.Point(712, 541);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_Clear.Size = new System.Drawing.Size(198, 69);
            this.button_Clear.TabIndex = 3;
            this.button_Clear.Text = "נקה";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // button_Search
            // 
            this.button_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Search.Location = new System.Drawing.Point(26, 528);
            this.button_Search.Name = "button_Search";
            this.button_Search.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_Search.Size = new System.Drawing.Size(237, 94);
            this.button_Search.TabIndex = 4;
            this.button_Search.Text = "חפש";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // listBox_Client
            // 
            this.listBox_Client.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_Client.FormattingEnabled = true;
            this.listBox_Client.ItemHeight = 37;
            this.listBox_Client.Location = new System.Drawing.Point(12, 662);
            this.listBox_Client.Name = "listBox_Client";
            this.listBox_Client.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBox_Client.Size = new System.Drawing.Size(898, 189);
            this.listBox_Client.TabIndex = 5;
            this.listBox_Client.DoubleClick += new System.EventHandler(this.listBox_Client_DoubleClick);
            // 
            // PDF_CV_Viewer
            // 
            this.PDF_CV_Viewer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PDF_CV_Viewer.Enabled = true;
            this.PDF_CV_Viewer.Location = new System.Drawing.Point(1487, 13);
            this.PDF_CV_Viewer.Name = "PDF_CV_Viewer";
            this.PDF_CV_Viewer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("PDF_CV_Viewer.OcxState")));
            this.PDF_CV_Viewer.Size = new System.Drawing.Size(707, 843);
            this.PDF_CV_Viewer.TabIndex = 6;
            // 
            // button_Remove_CV
            // 
            this.button_Remove_CV.AllowDrop = true;
            this.button_Remove_CV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Remove_CV.Location = new System.Drawing.Point(1211, 541);
            this.button_Remove_CV.Name = "button_Remove_CV";
            this.button_Remove_CV.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_Remove_CV.Size = new System.Drawing.Size(132, 157);
            this.button_Remove_CV.TabIndex = 13;
            this.button_Remove_CV.Text = "הסר קורות חיים";
            this.button_Remove_CV.UseVisualStyleBackColor = true;
            this.button_Remove_CV.Click += new System.EventHandler(this.button_Remove_CV_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2206, 868);
            this.Controls.Add(this.button_Remove_CV);
            this.Controls.Add(this.button_Add_CV);
            this.Controls.Add(this.PDF_CV_Viewer);
            this.Controls.Add(this.listBox_Client);
            this.Controls.Add(this.button_Search);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.groupBox_Ranking);
            this.Controls.Add(this.groupBox_PD);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox_PD.ResumeLayout(false);
            this.groupBox_PD.PerformLayout();
            this.groupBox_Ranking.ResumeLayout(false);
            this.groupBox_Ranking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_GA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Professionalism)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Match)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PDF_CV_Viewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_PD;
        private System.Windows.Forms.ComboBox comboBox_CellAreaCode;
        private System.Windows.Forms.Label label_DBID;
        private System.Windows.Forms.Label label_City;
        private System.Windows.Forms.ComboBox comboBox_City;
        private System.Windows.Forms.Label label_Phone;
        private System.Windows.Forms.TextBox textBox_Cel;
        private System.Windows.Forms.Label label_Email;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.Label label_LastName;
        private System.Windows.Forms.TextBox textBox_LastName;
        private System.Windows.Forms.Label label_FirstName;
        private System.Windows.Forms.TextBox textBox_FirstName;
        private System.Windows.Forms.GroupBox groupBox_Ranking;
        private System.Windows.Forms.NumericUpDown numericUpDown_Match;
        private System.Windows.Forms.Label label_Match;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.ListBox listBox_Client;
        private AxAcroPDFLib.AxAcroPDF PDF_CV_Viewer;
        private System.Windows.Forms.Label label_Position;
        private System.Windows.Forms.ComboBox comboBox_Position;
        private System.Windows.Forms.NumericUpDown numericUpDown_GA;
        private System.Windows.Forms.Label label_GA;
        private System.Windows.Forms.NumericUpDown numericUpDown_Professionalism;
        private System.Windows.Forms.Label label_Professionalism;
        private System.Windows.Forms.Button button_Add_CV;
        private System.Windows.Forms.Button button_Remove_CV;
    }
}

