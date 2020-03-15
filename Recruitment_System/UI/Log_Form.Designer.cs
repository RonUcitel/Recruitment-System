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
            this.listView_Log = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listView_Log
            // 
            this.listView_Log.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Log.FullRowSelect = true;
            this.listView_Log.HideSelection = false;
            this.listView_Log.Location = new System.Drawing.Point(0, 0);
            this.listView_Log.Name = "listView_Log";
            this.listView_Log.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listView_Log.RightToLeftLayout = true;
            this.listView_Log.Size = new System.Drawing.Size(1004, 650);
            this.listView_Log.TabIndex = 0;
            this.listView_Log.UseCompatibleStateImageBehavior = false;
            this.listView_Log.View = System.Windows.Forms.View.Details;
            this.listView_Log.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView_Log_ColumnWidthChanging);
            // 
            // Log_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 650);
            this.Controls.Add(this.listView_Log);
            this.Name = "Log_Form";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "תיעוד אירועים";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView_Log;
    }
}