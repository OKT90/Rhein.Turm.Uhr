namespace RheinTurmUhr
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.ZurückButton = new System.Windows.Forms.Button();
            this.MyPicture = new System.Windows.Forms.PictureBox();
            this.IdoitPicture = new System.Windows.Forms.PictureBox();
            this.MyName = new System.Windows.Forms.Label();
            this.MyCompany = new System.Windows.Forms.Label();
            this.MyJob = new System.Windows.Forms.Label();
            this.DesignBy = new System.Windows.Forms.Label();
            this.MyEmail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MyPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdoitPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ZurückButton
            // 
            resources.ApplyResources(this.ZurückButton, "ZurückButton");
            this.ZurückButton.Name = "ZurückButton";
            this.ZurückButton.UseVisualStyleBackColor = true;
            this.ZurückButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // MyPicture
            // 
            resources.ApplyResources(this.MyPicture, "MyPicture");
            this.MyPicture.Name = "MyPicture";
            this.MyPicture.TabStop = false;
            // 
            // IdoitPicture
            // 
            resources.ApplyResources(this.IdoitPicture, "IdoitPicture");
            this.IdoitPicture.Name = "IdoitPicture";
            this.IdoitPicture.TabStop = false;
            // 
            // MyName
            // 
            resources.ApplyResources(this.MyName, "MyName");
            this.MyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MyName.Name = "MyName";
            // 
            // MyCompany
            // 
            resources.ApplyResources(this.MyCompany, "MyCompany");
            this.MyCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MyCompany.Name = "MyCompany";
            // 
            // MyJob
            // 
            resources.ApplyResources(this.MyJob, "MyJob");
            this.MyJob.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MyJob.Name = "MyJob";
            // 
            // DesignBy
            // 
            resources.ApplyResources(this.DesignBy, "DesignBy");
            this.DesignBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DesignBy.Name = "DesignBy";
            // 
            // MyEmail
            // 
            resources.ApplyResources(this.MyEmail, "MyEmail");
            this.MyEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MyEmail.Name = "MyEmail";
            // 
            // About
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.MyJob);
            this.Controls.Add(this.MyEmail);
            this.Controls.Add(this.MyCompany);
            this.Controls.Add(this.DesignBy);
            this.Controls.Add(this.MyName);
            this.Controls.Add(this.IdoitPicture);
            this.Controls.Add(this.MyPicture);
            this.Controls.Add(this.ZurückButton);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Opacity = 0.9D;
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MyPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdoitPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ZurückButton;
        private System.Windows.Forms.PictureBox MyPicture;
        private System.Windows.Forms.PictureBox IdoitPicture;
        private System.Windows.Forms.Label MyName;
        private System.Windows.Forms.Label MyCompany;
        private System.Windows.Forms.Label MyJob;
        private System.Windows.Forms.Label DesignBy;
        private System.Windows.Forms.Label MyEmail;
    }
}