namespace WindowsFormsApplication1 {
    partial class frmOptions {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cboFleet = new System.Windows.Forms.ComboBox();
            this.lblFleet = new System.Windows.Forms.Label();
            this.lblPathData = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPathData = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblPathDataOriginal = new System.Windows.Forms.Label();
            this.lblPathDataBackup = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPathDataBackup = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFilePDF = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblPathOutput = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPathOutput = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAirCarrier = new System.Windows.Forms.TextBox();
            this.lblCarrier = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnPathLogo = new System.Windows.Forms.Button();
            this.lblPathLogo = new System.Windows.Forms.Label();
            this.lblPathImagePdf = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnPathImagePdf = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Enabled = false;
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(766, 628);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(183, 16);
            this.txtMessage.TabIndex = 186;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Green;
            this.btnSave.Location = new System.Drawing.Point(46, 428);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(268, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save Changes and Close Dialog";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboFleet
            // 
            this.cboFleet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFleet.FormattingEnabled = true;
            this.cboFleet.Location = new System.Drawing.Point(191, 129);
            this.cboFleet.Name = "cboFleet";
            this.cboFleet.Size = new System.Drawing.Size(103, 21);
            this.cboFleet.Sorted = true;
            this.cboFleet.TabIndex = 187;
            this.cboFleet.TextChanged += new System.EventHandler(this.cboFleet_TextChanged);
            // 
            // lblFleet
            // 
            this.lblFleet.AutoSize = true;
            this.lblFleet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFleet.Location = new System.Drawing.Point(143, 132);
            this.lblFleet.Name = "lblFleet";
            this.lblFleet.Size = new System.Drawing.Size(45, 13);
            this.lblFleet.TabIndex = 188;
            this.lblFleet.Text = "FLEET";
            this.lblFleet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPathData
            // 
            this.lblPathData.AutoSize = true;
            this.lblPathData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPathData.Location = new System.Drawing.Point(296, 212);
            this.lblPathData.Name = "lblPathData";
            this.lblPathData.Size = new System.Drawing.Size(0, 13);
            this.lblPathData.TabIndex = 194;
            this.lblPathData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(112, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 193;
            this.label4.Text = "DATA PATH";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPathData
            // 
            this.btnPathData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPathData.ForeColor = System.Drawing.Color.Red;
            this.btnPathData.Location = new System.Drawing.Point(191, 207);
            this.btnPathData.Name = "btnPathData";
            this.btnPathData.Size = new System.Drawing.Size(103, 23);
            this.btnPathData.TabIndex = 192;
            this.btnPathData.Text = "Select Path ...";
            this.btnPathData.UseVisualStyleBackColor = true;
            this.btnPathData.Click += new System.EventHandler(this.btnPathData_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Green;
            this.button1.Location = new System.Drawing.Point(46, 457);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(268, 23);
            this.button1.TabIndex = 195;
            this.button1.Text = "Close Dialog Without Saving";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblPathDataOriginal
            // 
            this.lblPathDataOriginal.AutoSize = true;
            this.lblPathDataOriginal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPathDataOriginal.Location = new System.Drawing.Point(195, 191);
            this.lblPathDataOriginal.Name = "lblPathDataOriginal";
            this.lblPathDataOriginal.Size = new System.Drawing.Size(25, 13);
            this.lblPathDataOriginal.TabIndex = 196;
            this.lblPathDataOriginal.Text = "C:/";
            this.lblPathDataOriginal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPathDataOriginal.Visible = false;
            // 
            // lblPathDataBackup
            // 
            this.lblPathDataBackup.AutoSize = true;
            this.lblPathDataBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPathDataBackup.Location = new System.Drawing.Point(296, 253);
            this.lblPathDataBackup.Name = "lblPathDataBackup";
            this.lblPathDataBackup.Size = new System.Drawing.Size(0, 13);
            this.lblPathDataBackup.TabIndex = 199;
            this.lblPathDataBackup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(59, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 13);
            this.label5.TabIndex = 198;
            this.label5.Text = "BACKUP DATA PATH";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPathDataBackup
            // 
            this.btnPathDataBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPathDataBackup.ForeColor = System.Drawing.Color.Red;
            this.btnPathDataBackup.Location = new System.Drawing.Point(191, 249);
            this.btnPathDataBackup.Name = "btnPathDataBackup";
            this.btnPathDataBackup.Size = new System.Drawing.Size(103, 23);
            this.btnPathDataBackup.TabIndex = 197;
            this.btnPathDataBackup.Text = "Select Path ...";
            this.btnPathDataBackup.UseVisualStyleBackColor = true;
            this.btnPathDataBackup.Click += new System.EventHandler(this.btnPathDataBackup_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtFilePDF);
            this.groupBox1.Controls.Add(this.lblOutput);
            this.groupBox1.Controls.Add(this.lblPathOutput);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnPathOutput);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(46, 295);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 112);
            this.groupBox1.TabIndex = 200;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PDF OUTPUT FILE";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(150, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(345, 13);
            this.label11.TabIndex = 214;
            this.label11.Text = "The machine path and folder that the fleet output pdf file will be located.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(149, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 13);
            this.label7.TabIndex = 210;
            this.label7.Text = "This is the filename of the output curricula.\r\n";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFilePDF
            // 
            this.txtFilePDF.Location = new System.Drawing.Point(145, 61);
            this.txtFilePDF.Name = "txtFilePDF";
            this.txtFilePDF.Size = new System.Drawing.Size(201, 20);
            this.txtFilePDF.TabIndex = 208;
            this.txtFilePDF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFilePDF.WordWrap = false;
            this.txtFilePDF.TextChanged += new System.EventHandler(this.txtFilePDF_TextChanged);
            this.txtFilePDF.Leave += new System.EventHandler(this.txtFilePDF_Leave);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.Location = new System.Drawing.Point(17, 64);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(125, 13);
            this.lblOutput.TabIndex = 207;
            this.lblOutput.Text = "PDF OUTPUT NAME";
            this.lblOutput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPathOutput
            // 
            this.lblPathOutput.AutoSize = true;
            this.lblPathOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPathOutput.Location = new System.Drawing.Point(250, 24);
            this.lblPathOutput.Name = "lblPathOutput";
            this.lblPathOutput.Size = new System.Drawing.Size(0, 13);
            this.lblPathOutput.TabIndex = 206;
            this.lblPathOutput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 205;
            this.label1.Text = "PDF OUTPUT PATH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPathOutput
            // 
            this.btnPathOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPathOutput.ForeColor = System.Drawing.Color.Red;
            this.btnPathOutput.Location = new System.Drawing.Point(145, 19);
            this.btnPathOutput.Name = "btnPathOutput";
            this.btnPathOutput.Size = new System.Drawing.Size(103, 23);
            this.btnPathOutput.TabIndex = 204;
            this.btnPathOutput.Text = "Select Path ...";
            this.btnPathOutput.UseVisualStyleBackColor = true;
            this.btnPathOutput.Click += new System.EventHandler(this.btnPathOutput_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(344, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 209;
            this.label6.Text = ".PDF";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(195, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(342, 26);
            this.label8.TabIndex = 211;
            this.label8.Text = "The fleet type can not be changed once a data file has been created.  \r\nA new fil" +
    "e must be created to change fleet.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(195, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(341, 13);
            this.label9.TabIndex = 212;
            this.label9.Text = "The machine path and folder that the fleet database file will be located.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(196, 273);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(380, 13);
            this.label10.TabIndex = 213;
            this.label10.Text = "The machine path and folder that the fleet backup database file will be located.";
            // 
            // txtAirCarrier
            // 
            this.txtAirCarrier.Location = new System.Drawing.Point(191, 14);
            this.txtAirCarrier.Name = "txtAirCarrier";
            this.txtAirCarrier.Size = new System.Drawing.Size(201, 20);
            this.txtAirCarrier.TabIndex = 215;
            this.txtAirCarrier.TextChanged += new System.EventHandler(this.txtAirCarrier_TextChanged);
            this.txtAirCarrier.Leave += new System.EventHandler(this.txtAirCarrier_Leave);
            // 
            // lblCarrier
            // 
            this.lblCarrier.AutoSize = true;
            this.lblCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarrier.Location = new System.Drawing.Point(62, 17);
            this.lblCarrier.Name = "lblCarrier";
            this.lblCarrier.Size = new System.Drawing.Size(126, 13);
            this.lblCarrier.TabIndex = 214;
            this.lblCarrier.Text = "AIR CARRIER NAME";
            this.lblCarrier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(118, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 217;
            this.label13.Text = "LOGO FILE";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPathLogo
            // 
            this.btnPathLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPathLogo.ForeColor = System.Drawing.Color.Red;
            this.btnPathLogo.Location = new System.Drawing.Point(191, 40);
            this.btnPathLogo.Name = "btnPathLogo";
            this.btnPathLogo.Size = new System.Drawing.Size(103, 23);
            this.btnPathLogo.TabIndex = 216;
            this.btnPathLogo.Text = "Select Path ...";
            this.btnPathLogo.UseVisualStyleBackColor = true;
            this.btnPathLogo.Click += new System.EventHandler(this.btnPathLogo_Click);
            // 
            // lblPathLogo
            // 
            this.lblPathLogo.AutoSize = true;
            this.lblPathLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPathLogo.Location = new System.Drawing.Point(297, 46);
            this.lblPathLogo.Name = "lblPathLogo";
            this.lblPathLogo.Size = new System.Drawing.Size(0, 13);
            this.lblPathLogo.TabIndex = 218;
            this.lblPathLogo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPathImagePdf
            // 
            this.lblPathImagePdf.AutoSize = true;
            this.lblPathImagePdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPathImagePdf.Location = new System.Drawing.Point(297, 90);
            this.lblPathImagePdf.Name = "lblPathImagePdf";
            this.lblPathImagePdf.Size = new System.Drawing.Size(0, 13);
            this.lblPathImagePdf.TabIndex = 221;
            this.lblPathImagePdf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(39, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(150, 13);
            this.label15.TabIndex = 220;
            this.label15.Text = "PDF TITLE PAGE IMAGE";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPathImagePdf
            // 
            this.btnPathImagePdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPathImagePdf.ForeColor = System.Drawing.Color.Red;
            this.btnPathImagePdf.Location = new System.Drawing.Point(191, 84);
            this.btnPathImagePdf.Name = "btnPathImagePdf";
            this.btnPathImagePdf.Size = new System.Drawing.Size(103, 23);
            this.btnPathImagePdf.TabIndex = 219;
            this.btnPathImagePdf.Text = "Select Path ...";
            this.btnPathImagePdf.UseVisualStyleBackColor = true;
            this.btnPathImagePdf.Click += new System.EventHandler(this.btnPathImagePdf_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(195, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(275, 13);
            this.label14.TabIndex = 222;
            this.label14.Text = "The path to the aircraft image displayed on the title page.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(195, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(312, 13);
            this.label16.TabIndex = 223;
            this.label16.Text = "The path to the corporate logo displayed on all curriculum pages.";
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 653);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblPathImagePdf);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnPathImagePdf);
            this.Controls.Add(this.lblPathLogo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnPathLogo);
            this.Controls.Add(this.txtAirCarrier);
            this.Controls.Add(this.lblCarrier);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblPathDataBackup);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPathDataBackup);
            this.Controls.Add(this.lblPathDataOriginal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPathData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPathData);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboFleet);
            this.Controls.Add(this.lblFleet);
            this.Controls.Add(this.txtMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DEVELOPER OPTIONS";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOptions_FormClosing);
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cboFleet;
        private System.Windows.Forms.Label lblFleet;
        private System.Windows.Forms.Label lblPathData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPathData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPathDataOriginal;
        private System.Windows.Forms.Label lblPathDataBackup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPathDataBackup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFilePDF;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblPathOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPathOutput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAirCarrier;
        private System.Windows.Forms.Label lblCarrier;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnPathLogo;
        private System.Windows.Forms.Label lblPathLogo;
        private System.Windows.Forms.Label lblPathImagePdf;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnPathImagePdf;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
    }
}