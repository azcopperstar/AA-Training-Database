namespace WindowsFormsApplication1 {
    partial class frmEditManeuver {
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
            this.cboSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnClearData = new System.Windows.Forms.Button();
            this.txtData18 = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.txtData17 = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtData16 = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.txtData15 = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtData14 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtData13 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtData12 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtData11 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtData10 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtData9 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtData8 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtData7 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtData6 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtData5 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtData4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboData3 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboData2 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtData5)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSelect
            // 
            this.cboSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSelect.FormattingEnabled = true;
            this.cboSelect.Location = new System.Drawing.Point(138, 12);
            this.cboSelect.Name = "cboSelect";
            this.cboSelect.Size = new System.Drawing.Size(652, 21);
            this.cboSelect.TabIndex = 158;
            this.cboSelect.SelectedIndexChanged += new System.EventHandler(this.cboSelect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 159;
            this.label1.Text = "SAVED MANEUVERS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDate
            // 
            this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDate.Enabled = false;
            this.txtDate.Location = new System.Drawing.Point(566, 431);
            this.txtDate.Multiline = true;
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(235, 32);
            this.txtDate.TabIndex = 157;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Maroon;
            this.btnDelete.Location = new System.Drawing.Point(16, 77);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(268, 23);
            this.btnDelete.TabIndex = 161;
            this.btnDelete.Text = "DELETE SELECTED RECORD";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(818, 402);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 113);
            this.groupBox2.TabIndex = 162;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SAVE / UPDATE";
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(16, 48);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(268, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "UPDATE SELECTED MANEUVER";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(16, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(268, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "SAVE AS NEW MANEUVER";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(706, 402);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 23);
            this.btnCancel.TabIndex = 160;
            this.btnCancel.Text = "Close Dialog";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 200;
            this.label2.Text = "MANEUVER NAME";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(138, 65);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(342, 35);
            this.txtName.TabIndex = 0;
            // 
            // btnClearData
            // 
            this.btnClearData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearData.Location = new System.Drawing.Point(986, 7);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(133, 29);
            this.btnClearData.TabIndex = 198;
            this.btnClearData.Text = "CLEAR ALL DATA";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // txtData18
            // 
            this.txtData18.Location = new System.Drawing.Point(636, 361);
            this.txtData18.Multiline = true;
            this.txtData18.Name = "txtData18";
            this.txtData18.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData18.Size = new System.Drawing.Size(483, 35);
            this.txtData18.TabIndex = 17;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(573, 366);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(60, 13);
            this.label40.TabIndex = 197;
            this.label40.Text = "NOTES 4";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtData17
            // 
            this.txtData17.Location = new System.Drawing.Point(636, 325);
            this.txtData17.Multiline = true;
            this.txtData17.Name = "txtData17";
            this.txtData17.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData17.Size = new System.Drawing.Size(483, 35);
            this.txtData17.TabIndex = 16;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(573, 329);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(60, 13);
            this.label41.TabIndex = 196;
            this.label41.Text = "NOTES 3";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtData16
            // 
            this.txtData16.Location = new System.Drawing.Point(636, 289);
            this.txtData16.Multiline = true;
            this.txtData16.Name = "txtData16";
            this.txtData16.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData16.Size = new System.Drawing.Size(483, 35);
            this.txtData16.TabIndex = 15;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(573, 293);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(60, 13);
            this.label42.TabIndex = 195;
            this.label42.Text = "NOTES 2";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtData15
            // 
            this.txtData15.Location = new System.Drawing.Point(636, 253);
            this.txtData15.Multiline = true;
            this.txtData15.Name = "txtData15";
            this.txtData15.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData15.Size = new System.Drawing.Size(483, 35);
            this.txtData15.TabIndex = 14;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(573, 257);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(60, 13);
            this.label43.TabIndex = 194;
            this.label43.Text = "NOTES 1";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtData14
            // 
            this.txtData14.Location = new System.Drawing.Point(636, 211);
            this.txtData14.Multiline = true;
            this.txtData14.Name = "txtData14";
            this.txtData14.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData14.Size = new System.Drawing.Size(483, 35);
            this.txtData14.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(548, 214);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 13);
            this.label13.TabIndex = 193;
            this.label13.Text = "SIM SETUP 4";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtData13
            // 
            this.txtData13.Location = new System.Drawing.Point(636, 175);
            this.txtData13.Multiline = true;
            this.txtData13.Name = "txtData13";
            this.txtData13.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData13.Size = new System.Drawing.Size(483, 35);
            this.txtData13.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(548, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 13);
            this.label12.TabIndex = 192;
            this.label12.Text = "SIM SETUP 3";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtData12
            // 
            this.txtData12.Location = new System.Drawing.Point(636, 138);
            this.txtData12.Multiline = true;
            this.txtData12.Name = "txtData12";
            this.txtData12.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData12.Size = new System.Drawing.Size(483, 35);
            this.txtData12.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(548, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 190;
            this.label11.Text = "SIM SETUP 2";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtData11
            // 
            this.txtData11.Location = new System.Drawing.Point(636, 101);
            this.txtData11.Multiline = true;
            this.txtData11.Name = "txtData11";
            this.txtData11.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData11.Size = new System.Drawing.Size(483, 35);
            this.txtData11.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(548, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 189;
            this.label10.Text = "SIM SETUP 1";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtData10
            // 
            this.txtData10.Location = new System.Drawing.Point(636, 65);
            this.txtData10.Multiline = true;
            this.txtData10.Name = "txtData10";
            this.txtData10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData10.Size = new System.Drawing.Size(483, 35);
            this.txtData10.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(541, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 188;
            this.label9.Text = "SIM POSITION";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtData9
            // 
            this.txtData9.Location = new System.Drawing.Point(138, 453);
            this.txtData9.Multiline = true;
            this.txtData9.Name = "txtData9";
            this.txtData9.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData9.Size = new System.Drawing.Size(342, 58);
            this.txtData9.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(76, 456);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 187;
            this.label7.Text = "SCOPE 2";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtData8
            // 
            this.txtData8.Location = new System.Drawing.Point(138, 393);
            this.txtData8.Multiline = true;
            this.txtData8.Name = "txtData8";
            this.txtData8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData8.Size = new System.Drawing.Size(342, 58);
            this.txtData8.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(76, 396);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 186;
            this.label8.Text = "SCOPE 1";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtData7
            // 
            this.txtData7.Location = new System.Drawing.Point(138, 310);
            this.txtData7.Multiline = true;
            this.txtData7.Name = "txtData7";
            this.txtData7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData7.Size = new System.Drawing.Size(342, 73);
            this.txtData7.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(50, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 185;
            this.label6.Text = "OBJECTIVE 2";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtData6
            // 
            this.txtData6.Location = new System.Drawing.Point(138, 235);
            this.txtData6.Multiline = true;
            this.txtData6.Name = "txtData6";
            this.txtData6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData6.Size = new System.Drawing.Size(342, 73);
            this.txtData6.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 182;
            this.label5.Text = "OBJECTIVE 1";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtData5
            // 
            this.txtData5.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtData5.Location = new System.Drawing.Point(138, 213);
            this.txtData5.Name = "txtData5";
            this.txtData5.Size = new System.Drawing.Size(51, 20);
            this.txtData5.TabIndex = 4;
            this.txtData5.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 178;
            this.label4.Text = "DEFAULT MINUTES";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtData4
            // 
            this.txtData4.Location = new System.Drawing.Point(138, 175);
            this.txtData4.Multiline = true;
            this.txtData4.Name = "txtData4";
            this.txtData4.Size = new System.Drawing.Size(342, 35);
            this.txtData4.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 176;
            this.label3.Text = "MANEUVER TITLE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(57, 137);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 13);
            this.label14.TabIndex = 172;
            this.label14.Text = "SOP PHASE";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboData3
            // 
            this.cboData3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboData3.FormattingEnabled = true;
            this.cboData3.Items.AddRange(new object[] {
            "",
            "1- GENERAL",
            "2- PREFLIGHT",
            "3- BEFORE START",
            "4- START",
            "5- TAXI",
            "6- TAKEOFF",
            "7- CLIMB",
            "8- CRUISE",
            "9- DESCENT",
            "10- APPROACH",
            "11- LANDING",
            "12- AFTER LANDING",
            "13- SHUTDOWN"});
            this.cboData3.Location = new System.Drawing.Point(137, 134);
            this.cboData3.Name = "cboData3";
            this.cboData3.Size = new System.Drawing.Size(173, 21);
            this.cboData3.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(78, 113);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 13);
            this.label15.TabIndex = 169;
            this.label15.Text = "SYSTEM";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboData2
            // 
            this.cboData2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboData2.FormattingEnabled = true;
            this.cboData2.Items.AddRange(new object[] {
            "",
            "00- None",
            "21- Air Conditioning and Press",
            "22- Autopilot",
            "23- Communications",
            "24- Electrical Power",
            "25- Equipment & Furnishings",
            "26- Fire Protection",
            "27- Flight Controls",
            "28- Fuel",
            "29- Hydraulics",
            "30- Ice & Rain Protecion",
            "31- Instruments",
            "32- Landing Gear",
            "33- Lights",
            "34- Navigation",
            "35- Oxygen",
            "36- Pneumatic",
            "38- Water / Waste",
            "46- Information Systems",
            "47- Inert Gas System",
            "49- Auxiliary Power Unit",
            "52- Doors",
            "71- Powerplant",
            "73- Engine Fuel & Control",
            "74- Ignition Systems",
            "76- Engine Control",
            "77- Engine Indicating",
            "78- Exhaust",
            "79- Oil",
            "80- Starting",
            "CDL"});
            this.cboData2.Location = new System.Drawing.Point(138, 109);
            this.cboData2.Name = "cboData2";
            this.cboData2.Size = new System.Drawing.Size(173, 21);
            this.cboData2.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(141, 162);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(212, 13);
            this.label16.TabIndex = 201;
            this.label16.Text = "Text displayed in the SPOT title area";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(141, 51);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(357, 13);
            this.label17.TabIndex = 202;
            this.label17.Text = "Text displayed in the \'SPOT BUILDER\' maneuver selection box";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmEditManeuver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 527);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnClearData);
            this.Controls.Add(this.txtData18);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.txtData17);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.txtData16);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.txtData15);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.txtData14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtData13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtData12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtData11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtData10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtData9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtData8);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtData7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtData6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtData5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtData4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cboData3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cboData2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cboSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmEditManeuver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANEUVER BUILDER";
            this.Load += new System.EventHandler(this.frmEditManeuver_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtData5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.TextBox txtData18;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtData17;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtData16;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtData15;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtData14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtData13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtData12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtData11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtData10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtData9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtData8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtData7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtData6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown txtData5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtData4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboData3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboData2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
    }
}