namespace presntion_DVLD
{
    partial class person_details_usercontrol
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labw = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labresultCountry = new System.Windows.Forms.Label();
            this.labresultDOB = new System.Windows.Forms.Label();
            this.labresultEmail = new System.Windows.Forms.Label();
            this.labresultAddress = new System.Windows.Forms.Label();
            this.labresultPhone = new System.Windows.Forms.Label();
            this.labresultName = new System.Windows.Forms.Label();
            this.labresultNN = new System.Windows.Forms.Label();
            this.labresultGendar = new System.Windows.Forms.Label();
            this.labName = new System.Windows.Forms.Label();
            this.labNN = new System.Windows.Forms.Label();
            this.labEmail = new System.Windows.Forms.Label();
            this.labAddress = new System.Windows.Forms.Label();
            this.labGendar = new System.Windows.Forms.Label();
            this.labCountry = new System.Windows.Forms.Label();
            this.labPhone = new System.Windows.Forms.Label();
            this.labDOB = new System.Windows.Forms.Label();
            this.labPID = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(307, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Person Details";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labw);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.labresultCountry);
            this.groupBox1.Controls.Add(this.labresultDOB);
            this.groupBox1.Controls.Add(this.labresultEmail);
            this.groupBox1.Controls.Add(this.labresultAddress);
            this.groupBox1.Controls.Add(this.labresultPhone);
            this.groupBox1.Controls.Add(this.labresultName);
            this.groupBox1.Controls.Add(this.labresultNN);
            this.groupBox1.Controls.Add(this.labresultGendar);
            this.groupBox1.Controls.Add(this.labName);
            this.groupBox1.Controls.Add(this.labNN);
            this.groupBox1.Controls.Add(this.labEmail);
            this.groupBox1.Controls.Add(this.labAddress);
            this.groupBox1.Controls.Add(this.labGendar);
            this.groupBox1.Controls.Add(this.labCountry);
            this.groupBox1.Controls.Add(this.labPhone);
            this.groupBox1.Controls.Add(this.labDOB);
            this.groupBox1.Controls.Add(this.labPID);
            this.groupBox1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Indigo;
            this.groupBox1.Location = new System.Drawing.Point(20, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(827, 363);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Person Information";
            // 
            // labw
            // 
            this.labw.AutoSize = true;
            this.labw.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labw.Location = new System.Drawing.Point(189, 42);
            this.labw.Name = "labw";
            this.labw.Size = new System.Drawing.Size(34, 24);
            this.labw.TabIndex = 21;
            this.labw.Text = "???";
            this.labw.Click += new System.EventHandler(this.labw_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(659, 62);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(130, 23);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Edit Person Info";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::presntion_DVLD.Properties.Resources.man;
            this.pictureBox1.Location = new System.Drawing.Point(648, 117);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // labresultCountry
            // 
            this.labresultCountry.AutoSize = true;
            this.labresultCountry.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labresultCountry.Location = new System.Drawing.Point(509, 262);
            this.labresultCountry.Name = "labresultCountry";
            this.labresultCountry.Size = new System.Drawing.Size(34, 24);
            this.labresultCountry.TabIndex = 18;
            this.labresultCountry.Text = "???";
            // 
            // labresultDOB
            // 
            this.labresultDOB.AutoSize = true;
            this.labresultDOB.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labresultDOB.Location = new System.Drawing.Point(509, 152);
            this.labresultDOB.Name = "labresultDOB";
            this.labresultDOB.Size = new System.Drawing.Size(34, 24);
            this.labresultDOB.TabIndex = 17;
            this.labresultDOB.Text = "???";
            // 
            // labresultEmail
            // 
            this.labresultEmail.AutoSize = true;
            this.labresultEmail.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labresultEmail.Location = new System.Drawing.Point(189, 262);
            this.labresultEmail.Name = "labresultEmail";
            this.labresultEmail.Size = new System.Drawing.Size(34, 24);
            this.labresultEmail.TabIndex = 16;
            this.labresultEmail.Text = "???";
            // 
            // labresultAddress
            // 
            this.labresultAddress.AutoSize = true;
            this.labresultAddress.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labresultAddress.Location = new System.Drawing.Point(189, 317);
            this.labresultAddress.Name = "labresultAddress";
            this.labresultAddress.Size = new System.Drawing.Size(34, 24);
            this.labresultAddress.TabIndex = 15;
            this.labresultAddress.Text = "???";
            // 
            // labresultPhone
            // 
            this.labresultPhone.AutoSize = true;
            this.labresultPhone.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labresultPhone.Location = new System.Drawing.Point(509, 207);
            this.labresultPhone.Name = "labresultPhone";
            this.labresultPhone.Size = new System.Drawing.Size(34, 24);
            this.labresultPhone.TabIndex = 14;
            this.labresultPhone.Text = "???";
            // 
            // labresultName
            // 
            this.labresultName.AutoSize = true;
            this.labresultName.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labresultName.Location = new System.Drawing.Point(189, 97);
            this.labresultName.Name = "labresultName";
            this.labresultName.Size = new System.Drawing.Size(34, 24);
            this.labresultName.TabIndex = 12;
            this.labresultName.Text = "???";
            // 
            // labresultNN
            // 
            this.labresultNN.AutoSize = true;
            this.labresultNN.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labresultNN.Location = new System.Drawing.Point(189, 152);
            this.labresultNN.Name = "labresultNN";
            this.labresultNN.Size = new System.Drawing.Size(34, 24);
            this.labresultNN.TabIndex = 11;
            this.labresultNN.Text = "???";
            // 
            // labresultGendar
            // 
            this.labresultGendar.AutoSize = true;
            this.labresultGendar.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labresultGendar.Location = new System.Drawing.Point(189, 207);
            this.labresultGendar.Name = "labresultGendar";
            this.labresultGendar.Size = new System.Drawing.Size(34, 24);
            this.labresultGendar.TabIndex = 10;
            this.labresultGendar.Text = "???";
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labName.Location = new System.Drawing.Point(22, 97);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(69, 24);
            this.labName.TabIndex = 9;
            this.labName.Text = "Name :";
            // 
            // labNN
            // 
            this.labNN.AutoSize = true;
            this.labNN.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNN.Location = new System.Drawing.Point(22, 152);
            this.labNN.Name = "labNN";
            this.labNN.Size = new System.Drawing.Size(124, 24);
            this.labNN.TabIndex = 8;
            this.labNN.Text = "National NO :";
            // 
            // labEmail
            // 
            this.labEmail.AutoSize = true;
            this.labEmail.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEmail.Location = new System.Drawing.Point(22, 262);
            this.labEmail.Name = "labEmail";
            this.labEmail.Size = new System.Drawing.Size(67, 24);
            this.labEmail.TabIndex = 7;
            this.labEmail.Text = "Email :";
            // 
            // labAddress
            // 
            this.labAddress.AutoSize = true;
            this.labAddress.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labAddress.Location = new System.Drawing.Point(22, 317);
            this.labAddress.Name = "labAddress";
            this.labAddress.Size = new System.Drawing.Size(83, 24);
            this.labAddress.TabIndex = 6;
            this.labAddress.Text = "Address :";
            // 
            // labGendar
            // 
            this.labGendar.AutoSize = true;
            this.labGendar.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labGendar.Location = new System.Drawing.Point(22, 207);
            this.labGendar.Name = "labGendar";
            this.labGendar.Size = new System.Drawing.Size(80, 24);
            this.labGendar.TabIndex = 4;
            this.labGendar.Text = "Gendar :";
            // 
            // labCountry
            // 
            this.labCountry.AutoSize = true;
            this.labCountry.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCountry.Location = new System.Drawing.Point(394, 262);
            this.labCountry.Name = "labCountry";
            this.labCountry.Size = new System.Drawing.Size(87, 24);
            this.labCountry.TabIndex = 3;
            this.labCountry.Text = "Country :";
            // 
            // labPhone
            // 
            this.labPhone.AutoSize = true;
            this.labPhone.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPhone.Location = new System.Drawing.Point(411, 207);
            this.labPhone.Name = "labPhone";
            this.labPhone.Size = new System.Drawing.Size(70, 24);
            this.labPhone.TabIndex = 2;
            this.labPhone.Text = "Phone :";
            // 
            // labDOB
            // 
            this.labDOB.AutoSize = true;
            this.labDOB.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDOB.Location = new System.Drawing.Point(352, 152);
            this.labDOB.Name = "labDOB";
            this.labDOB.Size = new System.Drawing.Size(129, 24);
            this.labDOB.TabIndex = 1;
            this.labDOB.Text = "Date Of Birth :";
            // 
            // labPID
            // 
            this.labPID.AutoSize = true;
            this.labPID.Font = new System.Drawing.Font("Palatino Linotype", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPID.Location = new System.Drawing.Point(22, 42);
            this.labPID.Name = "labPID";
            this.labPID.Size = new System.Drawing.Size(98, 24);
            this.labPID.TabIndex = 0;
            this.labPID.Text = "Person ID :";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Indigo;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(725, 442);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "close";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // person_details_usercontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "person_details_usercontrol";
            this.Size = new System.Drawing.Size(869, 492);
            this.Load += new System.EventHandler(this.person_details_usercontrol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label labNN;
        private System.Windows.Forms.Label labEmail;
        private System.Windows.Forms.Label labAddress;
        private System.Windows.Forms.Label labGendar;
        private System.Windows.Forms.Label labCountry;
        private System.Windows.Forms.Label labPhone;
        private System.Windows.Forms.Label labDOB;
        private System.Windows.Forms.Label labPID;
        private System.Windows.Forms.Label labresultCountry;
        private System.Windows.Forms.Label labresultDOB;
        private System.Windows.Forms.Label labresultEmail;
        private System.Windows.Forms.Label labresultAddress;
        private System.Windows.Forms.Label labresultPhone;
        private System.Windows.Forms.Label labresultName;
        private System.Windows.Forms.Label labresultNN;
        private System.Windows.Forms.Label labresultGendar;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labw;
    }
}
