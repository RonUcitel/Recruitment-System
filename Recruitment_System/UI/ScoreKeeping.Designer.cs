﻿namespace Recruitment_System.UI
{
    partial class ScoreKeeping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreKeeping));
            this.scorer1 = new Recruitment_System.UI.Scorer();
            this.SuspendLayout();
            // 
            // scorer1
            // 
            this.scorer1.CanEdit = true;
            this.scorer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scorer1.Location = new System.Drawing.Point(0, 0);
            this.scorer1.Name = "scorer1";
            this.scorer1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.scorer1.Size = new System.Drawing.Size(1102, 597);
            this.scorer1.TabIndex = 0;
            // 
            // ScoreKeeping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 597);
            this.Controls.Add(this.scorer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ScoreKeeping";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "ScoreKeeping";
            this.ResumeLayout(false);

        }

        #endregion

        private Scorer scorer1;
    }
}