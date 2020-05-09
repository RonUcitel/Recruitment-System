﻿namespace Recruitment_System.UI
{
    partial class NomineePosition_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NomineePosition_Form));
            this.listBox_AvailablePositions = new System.Windows.Forms.ListBox();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.label_AvailablePositions = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox_FilterAvailable = new System.Windows.Forms.TextBox();
            this.pictureBox_AvailableDisableFilter = new System.Windows.Forms.PictureBox();
            this.pictureBox_ChosenDisableFilter = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox_FilterChosen = new System.Windows.Forms.TextBox();
            this.label_ChosenPosition = new System.Windows.Forms.Label();
            this.listBox_ChosenPositions = new System.Windows.Forms.ListBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AvailableDisableFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ChosenDisableFilter)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_AvailablePositions
            // 
            this.listBox_AvailablePositions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_AvailablePositions.FormattingEnabled = true;
            this.listBox_AvailablePositions.ItemHeight = 37;
            this.listBox_AvailablePositions.Location = new System.Drawing.Point(19, 126);
            this.listBox_AvailablePositions.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.listBox_AvailablePositions.Name = "listBox_AvailablePositions";
            this.listBox_AvailablePositions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBox_AvailablePositions.Size = new System.Drawing.Size(371, 448);
            this.listBox_AvailablePositions.TabIndex = 23;
            this.listBox_AvailablePositions.SelectedValueChanged += new System.EventHandler(this.listBox_AvailablePositions_SelectedValueChanged);
            this.listBox_AvailablePositions.Enter += new System.EventHandler(this.listBox_AvailablePositions_Enter);
            // 
            // button_Add
            // 
            this.button_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Add.Location = new System.Drawing.Point(450, 201);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(238, 77);
            this.button_Add.TabIndex = 29;
            this.button_Add.Text = "הוסף >>";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Remove
            // 
            this.button_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Remove.Location = new System.Drawing.Point(450, 284);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(238, 77);
            this.button_Remove.TabIndex = 30;
            this.button_Remove.Text = "<< הסר";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // label_AvailablePositions
            // 
            this.label_AvailablePositions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_AvailablePositions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_AvailablePositions.Location = new System.Drawing.Point(19, 33);
            this.label_AvailablePositions.Name = "label_AvailablePositions";
            this.label_AvailablePositions.Size = new System.Drawing.Size(371, 37);
            this.label_AvailablePositions.TabIndex = 32;
            this.label_AvailablePositions.Text = "משרות קיימות";
            this.label_AvailablePositions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.textBox_FilterAvailable);
            this.panel2.Location = new System.Drawing.Point(19, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(371, 44);
            this.panel2.TabIndex = 40;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // textBox_FilterAvailable
            // 
            this.textBox_FilterAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_FilterAvailable.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_FilterAvailable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_FilterAvailable.Location = new System.Drawing.Point(42, 3);
            this.textBox_FilterAvailable.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.textBox_FilterAvailable.Name = "textBox_FilterAvailable";
            this.textBox_FilterAvailable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_FilterAvailable.Size = new System.Drawing.Size(327, 37);
            this.textBox_FilterAvailable.TabIndex = 38;
            this.textBox_FilterAvailable.TextChanged += new System.EventHandler(this.textBox_FilterAvailable_TextChanged);
            // 
            // pictureBox_AvailableDisableFilter
            // 
            this.pictureBox_AvailableDisableFilter.Image = global::Recruitment_System.Properties.Resources.Cancel;
            this.pictureBox_AvailableDisableFilter.Location = new System.Drawing.Point(396, 70);
            this.pictureBox_AvailableDisableFilter.Name = "pictureBox_AvailableDisableFilter";
            this.pictureBox_AvailableDisableFilter.Size = new System.Drawing.Size(44, 44);
            this.pictureBox_AvailableDisableFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_AvailableDisableFilter.TabIndex = 42;
            this.pictureBox_AvailableDisableFilter.TabStop = false;
            this.pictureBox_AvailableDisableFilter.Visible = false;
            this.pictureBox_AvailableDisableFilter.Click += new System.EventHandler(this.pictureBox_AvailableDisableFilter_Click);
            // 
            // pictureBox_ChosenDisableFilter
            // 
            this.pictureBox_ChosenDisableFilter.Image = global::Recruitment_System.Properties.Resources.Cancel;
            this.pictureBox_ChosenDisableFilter.Location = new System.Drawing.Point(1132, 70);
            this.pictureBox_ChosenDisableFilter.Name = "pictureBox_ChosenDisableFilter";
            this.pictureBox_ChosenDisableFilter.Size = new System.Drawing.Size(44, 44);
            this.pictureBox_ChosenDisableFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_ChosenDisableFilter.TabIndex = 46;
            this.pictureBox_ChosenDisableFilter.TabStop = false;
            this.pictureBox_ChosenDisableFilter.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.textBox_FilterChosen);
            this.panel1.Location = new System.Drawing.Point(755, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 44);
            this.panel1.TabIndex = 45;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(44, 44);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            // 
            // textBox_FilterChosen
            // 
            this.textBox_FilterChosen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_FilterChosen.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_FilterChosen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_FilterChosen.Location = new System.Drawing.Point(42, 3);
            this.textBox_FilterChosen.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.textBox_FilterChosen.Name = "textBox_FilterChosen";
            this.textBox_FilterChosen.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_FilterChosen.Size = new System.Drawing.Size(327, 37);
            this.textBox_FilterChosen.TabIndex = 38;
            // 
            // label_ChosenPosition
            // 
            this.label_ChosenPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ChosenPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_ChosenPosition.Location = new System.Drawing.Point(755, 33);
            this.label_ChosenPosition.Name = "label_ChosenPosition";
            this.label_ChosenPosition.Size = new System.Drawing.Size(371, 37);
            this.label_ChosenPosition.TabIndex = 44;
            this.label_ChosenPosition.Text = "משרות אליהן משוייך המועמד";
            this.label_ChosenPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox_ChosenPositions
            // 
            this.listBox_ChosenPositions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_ChosenPositions.FormattingEnabled = true;
            this.listBox_ChosenPositions.ItemHeight = 37;
            this.listBox_ChosenPositions.Location = new System.Drawing.Point(755, 126);
            this.listBox_ChosenPositions.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.listBox_ChosenPositions.Name = "listBox_ChosenPositions";
            this.listBox_ChosenPositions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBox_ChosenPositions.Size = new System.Drawing.Size(371, 448);
            this.listBox_ChosenPositions.TabIndex = 43;
            // 
            // NomineePosition_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 592);
            this.Controls.Add(this.pictureBox_ChosenDisableFilter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_ChosenPosition);
            this.Controls.Add(this.listBox_ChosenPositions);
            this.Controls.Add(this.pictureBox_AvailableDisableFilter);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label_AvailablePositions);
            this.Controls.Add(this.button_Remove);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.listBox_AvailablePositions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NomineePosition_Form";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "עריכת משרות למועמד";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AvailableDisableFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ChosenDisableFilter)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_AvailablePositions;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Label label_AvailablePositions;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox_FilterAvailable;
        private System.Windows.Forms.PictureBox pictureBox_AvailableDisableFilter;
        private System.Windows.Forms.PictureBox pictureBox_ChosenDisableFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox_FilterChosen;
        private System.Windows.Forms.Label label_ChosenPosition;
        private System.Windows.Forms.ListBox listBox_ChosenPositions;
    }
}