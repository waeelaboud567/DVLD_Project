namespace presntion_DVLD
{
    partial class change_Password_usercontrol
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labPID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurrentPassword = new System.Windows.Forms.MaskedTextBox();
            this.txtNewPassword = new System.Windows.Forms.MaskedTextBox();
            this.txtConfirmPassword = new System.Windows.Forms.MaskedTextBox();
            this.btnEyeConP = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnEyeNP = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnEyeCP = new Guna.UI2.WinForms.Guna2CircleButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labPID
            // 
            this.labPID.AutoSize = true;
            this.labPID.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPID.ForeColor = System.Drawing.Color.Indigo;
            this.labPID.Location = new System.Drawing.Point(25, 34);
            this.labPID.Name = "labPID";
            this.labPID.Size = new System.Drawing.Size(162, 24);
            this.labPID.TabIndex = 1;
            this.labPID.Text = "Current Password :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(50, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "New Password :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Indigo;
            this.label2.Location = new System.Drawing.Point(15, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = " Confirm Password :";
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Location = new System.Drawing.Point(207, 37);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.Size = new System.Drawing.Size(197, 24);
            this.txtCurrentPassword.TabIndex = 4;
            this.txtCurrentPassword.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtCurrentPassword_MaskInputRejected);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(207, 114);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(197, 24);
            this.txtNewPassword.TabIndex = 5;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(207, 191);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(197, 24);
            this.txtConfirmPassword.TabIndex = 6;
            // 
            // btnEyeConP
            // 
            this.btnEyeConP.BorderColor = System.Drawing.Color.Indigo;
            this.btnEyeConP.BorderThickness = 3;
            this.btnEyeConP.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEyeConP.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEyeConP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEyeConP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEyeConP.FillColor = System.Drawing.Color.White;
            this.btnEyeConP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEyeConP.ForeColor = System.Drawing.Color.White;
            this.btnEyeConP.Image = global::presntion_DVLD.Properties.Resources.eye_open1;
            this.btnEyeConP.Location = new System.Drawing.Point(427, 182);
            this.btnEyeConP.Name = "btnEyeConP";
            this.btnEyeConP.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnEyeConP.Size = new System.Drawing.Size(31, 33);
            this.btnEyeConP.TabIndex = 14;
            this.btnEyeConP.Click += new System.EventHandler(this.btnEyeConP_Click);
            // 
            // btnEyeNP
            // 
            this.btnEyeNP.BorderColor = System.Drawing.Color.Indigo;
            this.btnEyeNP.BorderThickness = 3;
            this.btnEyeNP.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEyeNP.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEyeNP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEyeNP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEyeNP.FillColor = System.Drawing.Color.White;
            this.btnEyeNP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEyeNP.ForeColor = System.Drawing.Color.White;
            this.btnEyeNP.Image = global::presntion_DVLD.Properties.Resources.eye_open;
            this.btnEyeNP.Location = new System.Drawing.Point(427, 105);
            this.btnEyeNP.Name = "btnEyeNP";
            this.btnEyeNP.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnEyeNP.Size = new System.Drawing.Size(31, 33);
            this.btnEyeNP.TabIndex = 13;
            this.btnEyeNP.Click += new System.EventHandler(this.btnEyeNP_Click);
            // 
            // btnEyeCP
            // 
            this.btnEyeCP.BorderColor = System.Drawing.Color.Indigo;
            this.btnEyeCP.BorderThickness = 3;
            this.btnEyeCP.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEyeCP.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEyeCP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEyeCP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEyeCP.FillColor = System.Drawing.Color.White;
            this.btnEyeCP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEyeCP.ForeColor = System.Drawing.Color.White;
            this.btnEyeCP.Image = global::presntion_DVLD.Properties.Resources.eye_open;
            this.btnEyeCP.Location = new System.Drawing.Point(427, 28);
            this.btnEyeCP.Name = "btnEyeCP";
            this.btnEyeCP.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnEyeCP.Size = new System.Drawing.Size(31, 33);
            this.btnEyeCP.TabIndex = 15;
            this.btnEyeCP.Click += new System.EventHandler(this.guna2CircleButton3_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // change_Password_usercontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEyeCP);
            this.Controls.Add(this.btnEyeConP);
            this.Controls.Add(this.btnEyeNP);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtCurrentPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labPID);
            this.Name = "change_Password_usercontrol";
            this.Size = new System.Drawing.Size(635, 276);
            this.Load += new System.EventHandler(this.change_Password_usercontrol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labPID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtCurrentPassword;
        private System.Windows.Forms.MaskedTextBox txtNewPassword;
        private System.Windows.Forms.MaskedTextBox txtConfirmPassword;
        private Guna.UI2.WinForms.Guna2CircleButton btnEyeConP;
        private Guna.UI2.WinForms.Guna2CircleButton btnEyeNP;
        private Guna.UI2.WinForms.Guna2CircleButton btnEyeCP;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
