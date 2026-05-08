namespace presntion_DVLD
{
    partial class person_DetailsAndUserInfo
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
            this.personDetailsAndUserInfo_UserControl1 = new presntion_DVLD.personDetailsAndUserInfo_UserControl();
            this.SuspendLayout();
            // 
            // personDetailsAndUserInfo_UserControl1
            // 
            this.personDetailsAndUserInfo_UserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.personDetailsAndUserInfo_UserControl1.Location = new System.Drawing.Point(0, 0);
            this.personDetailsAndUserInfo_UserControl1.Name = "personDetailsAndUserInfo_UserControl1";
            this.personDetailsAndUserInfo_UserControl1.Size = new System.Drawing.Size(957, 711);
            this.personDetailsAndUserInfo_UserControl1.TabIndex = 0;
            // 
            // person_DetailsAndUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 711);
            this.Controls.Add(this.personDetailsAndUserInfo_UserControl1);
            this.Name = "person_DetailsAndUserInfo";
            this.Text = "person_DetailsAndUserInfo";
            this.Load += new System.EventHandler(this.person_DetailsAndUserInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private personDetailsAndUserInfo_UserControl personDetailsAndUserInfo_UserControl1;
    }
}