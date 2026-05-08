namespace presntion_DVLD.Application
{
    partial class LocalDrivingLicenseApplication_Info
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
            this.infoApplication_usercontrol1 = new presntion_DVLD.InfoApplication_usercontrol();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // infoApplication_usercontrol1
            // 
            this.infoApplication_usercontrol1.appid = 0;
            this.infoApplication_usercontrol1.BackColor = System.Drawing.Color.White;
            this.infoApplication_usercontrol1.localid = 0;
            this.infoApplication_usercontrol1.Location = new System.Drawing.Point(12, 32);
            this.infoApplication_usercontrol1.Name = "infoApplication_usercontrol1";
            this.infoApplication_usercontrol1.Size = new System.Drawing.Size(986, 525);
            this.infoApplication_usercontrol1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Image = global::presntion_DVLD.Properties.Resources.close1;
            this.button1.Location = new System.Drawing.Point(994, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 28);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 21);
            this.label1.TabIndex = 80;
            this.label1.Text = "Local Driving License Information";
            // 
            // LocalDrivingLicenseApplication_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1022, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.infoApplication_usercontrol1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LocalDrivingLicenseApplication_Info";
            this.Text = "LocalDrivingLicenseApplication_Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private InfoApplication_usercontrol infoApplication_usercontrol1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}