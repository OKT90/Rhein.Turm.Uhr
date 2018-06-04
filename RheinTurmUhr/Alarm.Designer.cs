namespace RheinTurmUhr
{
    partial class Alarm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alarm));
            this.AlarmTimeSetting = new System.Windows.Forms.DateTimePicker();
            this.StartBottun = new System.Windows.Forms.Button();
            this.StopBottun = new System.Windows.Forms.Button();
            this.Statuslabel = new System.Windows.Forms.Label();
            this.MenuList = new System.Windows.Forms.MenuStrip();
            this.zurückToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MenuList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // AlarmTimeSetting
            // 
            resources.ApplyResources(this.AlarmTimeSetting, "AlarmTimeSetting");
            this.AlarmTimeSetting.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.AlarmTimeSetting.Name = "AlarmTimeSetting";
            this.AlarmTimeSetting.ShowUpDown = true;
            this.toolTip1.SetToolTip(this.AlarmTimeSetting, resources.GetString("AlarmTimeSetting.ToolTip"));
            // 
            // StartBottun
            // 
            resources.ApplyResources(this.StartBottun, "StartBottun");
            this.StartBottun.Name = "StartBottun";
            this.toolTip1.SetToolTip(this.StartBottun, resources.GetString("StartBottun.ToolTip"));
            this.StartBottun.UseVisualStyleBackColor = true;
            this.StartBottun.Click += new System.EventHandler(this.startBottunFunction);
            // 
            // StopBottun
            // 
            resources.ApplyResources(this.StopBottun, "StopBottun");
            this.StopBottun.Name = "StopBottun";
            this.toolTip1.SetToolTip(this.StopBottun, resources.GetString("StopBottun.ToolTip"));
            this.StopBottun.UseVisualStyleBackColor = true;
            this.StopBottun.Click += new System.EventHandler(this.stopBottunFunction);
            // 
            // Statuslabel
            // 
            resources.ApplyResources(this.Statuslabel, "Statuslabel");
            this.Statuslabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Statuslabel.Name = "Statuslabel";
            this.toolTip1.SetToolTip(this.Statuslabel, resources.GetString("Statuslabel.ToolTip"));
            // 
            // MenuList
            // 
            resources.ApplyResources(this.MenuList, "MenuList");
            this.MenuList.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zurückToolStripMenuItem});
            this.MenuList.Name = "MenuList";
            this.toolTip1.SetToolTip(this.MenuList, resources.GetString("MenuList.ToolTip"));
            // 
            // zurückToolStripMenuItem
            // 
            resources.ApplyResources(this.zurückToolStripMenuItem, "zurückToolStripMenuItem");
            this.zurückToolStripMenuItem.Name = "zurückToolStripMenuItem";
            this.zurückToolStripMenuItem.Click += new System.EventHandler(this.End);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, resources.GetString("pictureBox1.ToolTip"));
            // 
            // Alarm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Statuslabel);
            this.Controls.Add(this.StopBottun);
            this.Controls.Add(this.StartBottun);
            this.Controls.Add(this.AlarmTimeSetting);
            this.Controls.Add(this.MenuList);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Alarm";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.Alarm_Load);
            this.MenuList.ResumeLayout(false);
            this.MenuList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker AlarmTimeSetting;
        private System.Windows.Forms.Button StartBottun;
        private System.Windows.Forms.Button StopBottun;
        private System.Windows.Forms.Label Statuslabel;
        private System.Windows.Forms.MenuStrip MenuList;
        private System.Windows.Forms.ToolStripMenuItem zurückToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}