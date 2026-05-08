namespace presntion_DVLD
{
    partial class Person_Details
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
            this.person_details_usercontrol1 = new presntion_DVLD.person_details_usercontrol();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // person_details_usercontrol1
            // 
            this.person_details_usercontrol1.id = null;
            this.person_details_usercontrol1.Location = new System.Drawing.Point(0, 0);
            this.person_details_usercontrol1.Name = "person_details_usercontrol1";
            this.person_details_usercontrol1.Size = new System.Drawing.Size(760, 492);
            this.person_details_usercontrol1.TabIndex = 0;
            this.person_details_usercontrol1.Load += new System.EventHandler(this.person_details_usercontrol1_Load);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Image = global::presntion_DVLD.Properties.Resources.close1;
            this.button1.Location = new System.Drawing.Point(733, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 28);
            this.button1.TabIndex = 18;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Person_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(764, 489);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.person_details_usercontrol1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Person_Details";
            this.Text = "Person_Details";
            this.ResumeLayout(false);

        }

        #endregion

        private person_details_usercontrol person_details_usercontrol1;
        private System.Windows.Forms.Button button1;
    }
}