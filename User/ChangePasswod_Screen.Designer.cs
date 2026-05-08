namespace presntion_DVLD
{
    partial class ChangePasswod_Screen
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
            this.btnSave = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.button1 = new System.Windows.Forms.Button();
            this.personDetailsAndUserInfo_UserControl1 = new presntion_DVLD.personDetailsAndUserInfo_UserControl();
            this.change_Password_usercontrol1 = new presntion_DVLD.change_Password_usercontrol();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BorderThickness = 3;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.Indigo;
            this.btnSave.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(603, 707);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnSave.Size = new System.Drawing.Size(93, 93);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.BorderThickness = 3;
            this.guna2CircleButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButton1.FillColor = System.Drawing.Color.Indigo;
            this.guna2CircleButton1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.Location = new System.Drawing.Point(702, 782);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Size = new System.Drawing.Size(93, 93);
            this.guna2CircleButton1.TabIndex = 3;
            this.guna2CircleButton1.Text = "Close";
            this.guna2CircleButton1.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Image = global::presntion_DVLD.Properties.Resources.close1;
            this.button1.Location = new System.Drawing.Point(807, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 28);
            this.button1.TabIndex = 19;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // personDetailsAndUserInfo_UserControl1
            // 
            this.personDetailsAndUserInfo_UserControl1.Location = new System.Drawing.Point(12, 2);
            this.personDetailsAndUserInfo_UserControl1.Name = "personDetailsAndUserInfo_UserControl1";
            this.personDetailsAndUserInfo_UserControl1.Size = new System.Drawing.Size(789, 591);
            this.personDetailsAndUserInfo_UserControl1.TabIndex = 1;
            // 
            // change_Password_usercontrol1
            // 
            this.change_Password_usercontrol1.Location = new System.Drawing.Point(38, 608);
            this.change_Password_usercontrol1.Name = "change_Password_usercontrol1";
            this.change_Password_usercontrol1.Size = new System.Drawing.Size(488, 276);
            this.change_Password_usercontrol1.TabIndex = 0;
            this.change_Password_usercontrol1.Load += new System.EventHandler(this.change_Password_usercontrol1_Load);
            // 
            // ChangePasswod_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 910);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.guna2CircleButton1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.personDetailsAndUserInfo_UserControl1);
            this.Controls.Add(this.change_Password_usercontrol1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangePasswod_Screen";
            this.Text = "ChangePasswod";
            this.Load += new System.EventHandler(this.ChangePasswod_Screen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private change_Password_usercontrol change_Password_usercontrol1;
        private personDetailsAndUserInfo_UserControl personDetailsAndUserInfo_UserControl1;
        private Guna.UI2.WinForms.Guna2CircleButton btnSave;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private System.Windows.Forms.Button button1;
    }
}