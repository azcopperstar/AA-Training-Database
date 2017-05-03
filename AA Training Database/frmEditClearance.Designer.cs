namespace WindowsFormsApplication1 {
    partial class frmEditClearance {
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.cboSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboALTN = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblEnroute = new System.Windows.Forms.Label();
            this.txtEnroute = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSTAR = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtXPNDR = new System.Windows.Forms.NumericUpDown();
            this.chkClimbVia = new System.Windows.Forms.CheckBox();
            this.txtAltInit = new System.Windows.Forms.NumericUpDown();
            this.lblAltInit = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtAltExpect = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDepFreq = new System.Windows.Forms.NumericUpDown();
            this.chkEnroute = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboDEST = new System.Windows.Forms.ComboBox();
            this.cboDEP = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFltNum = new System.Windows.Forms.TextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSTARTrans = new System.Windows.Forms.TextBox();
            this.txtSIDTrans = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtXPNDR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAltInit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAltExpect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepFreq)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Maroon;
            this.btnDelete.Location = new System.Drawing.Point(16, 77);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(268, 23);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "DELETE SELECTED RECORD";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cboSelect
            // 
            this.cboSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSelect.FormattingEnabled = true;
            this.cboSelect.Location = new System.Drawing.Point(177, 12);
            this.cboSelect.Name = "cboSelect";
            this.cboSelect.Size = new System.Drawing.Size(419, 21);
            this.cboSelect.TabIndex = 0;
            this.cboSelect.SelectedIndexChanged += new System.EventHandler(this.cboSelect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 159;
            this.label1.Text = "SAVED CLEARANCES";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(354, 439);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 140);
            this.groupBox1.TabIndex = 157;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SAVE / UPDATE";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(16, 106);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(268, 23);
            this.btnClear.TabIndex = 21;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "CLEAR ENTRIES";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(16, 48);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(268, 23);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "UPDATE SELECTED CLEARANCE";
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
            this.btnSave.TabIndex = 18;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "SAVE AS NEW CLEARANCE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(543, 623);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Close Dialog";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(177, 375);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(470, 55);
            this.txtRemarks.TabIndex = 17;
            this.txtRemarks.Enter += new System.EventHandler(this.txtRemarks_Enter);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(78, 378);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(96, 13);
            this.label35.TabIndex = 154;
            this.label35.Text = "PDC REMARKS";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDate
            // 
            this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDate.Enabled = false;
            this.txtDate.Location = new System.Drawing.Point(354, 585);
            this.txtDate.Multiline = true;
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(301, 32);
            this.txtDate.TabIndex = 160;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 13);
            this.label6.TabIndex = 169;
            this.label6.Text = "ALTERNATE AIRPORT";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboALTN
            // 
            this.cboALTN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboALTN.FormattingEnabled = true;
            this.cboALTN.Location = new System.Drawing.Point(177, 176);
            this.cboALTN.Name = "cboALTN";
            this.cboALTN.Size = new System.Drawing.Size(108, 21);
            this.cboALTN.Sorted = true;
            this.cboALTN.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(107, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 230;
            this.label8.Text = "SID NAME";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSID
            // 
            this.txtSID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSID.Location = new System.Drawing.Point(177, 225);
            this.txtSID.MaxLength = 20;
            this.txtSID.Name = "txtSID";
            this.txtSID.Size = new System.Drawing.Size(108, 20);
            this.txtSID.TabIndex = 7;
            this.txtSID.WordWrap = false;
            this.txtSID.Enter += new System.EventHandler(this.txtSID_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(303, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 232;
            this.label7.Text = "SID TRANSITION";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEnroute
            // 
            this.lblEnroute.AutoSize = true;
            this.lblEnroute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnroute.Location = new System.Drawing.Point(190, 254);
            this.lblEnroute.Name = "lblEnroute";
            this.lblEnroute.Size = new System.Drawing.Size(94, 13);
            this.lblEnroute.TabIndex = 234;
            this.lblEnroute.Text = "-or- ENROUTE ";
            this.lblEnroute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEnroute
            // 
            this.txtEnroute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnroute.Location = new System.Drawing.Point(287, 251);
            this.txtEnroute.MaxLength = 200;
            this.txtEnroute.Name = "txtEnroute";
            this.txtEnroute.Size = new System.Drawing.Size(360, 20);
            this.txtEnroute.TabIndex = 10;
            this.txtEnroute.WordWrap = false;
            this.txtEnroute.Enter += new System.EventHandler(this.txtEnroute_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(291, 280);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 13);
            this.label10.TabIndex = 238;
            this.label10.Text = "STAR TRANSITION";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(95, 280);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 236;
            this.label11.Text = "STAR NAME";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSTAR
            // 
            this.txtSTAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTAR.Location = new System.Drawing.Point(177, 277);
            this.txtSTAR.MaxLength = 20;
            this.txtSTAR.Name = "txtSTAR";
            this.txtSTAR.Size = new System.Drawing.Size(108, 20);
            this.txtSTAR.TabIndex = 11;
            this.txtSTAR.WordWrap = false;
            this.txtSTAR.Enter += new System.EventHandler(this.txtSTAR_Enter);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(123, 203);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 239;
            this.label12.Text = "XPNDR";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtXPNDR
            // 
            this.txtXPNDR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXPNDR.Location = new System.Drawing.Point(177, 201);
            this.txtXPNDR.Maximum = new decimal(new int[] {
            7477,
            0,
            0,
            0});
            this.txtXPNDR.Name = "txtXPNDR";
            this.txtXPNDR.Size = new System.Drawing.Size(54, 20);
            this.txtXPNDR.TabIndex = 5;
            this.txtXPNDR.Value = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.txtXPNDR.ValueChanged += new System.EventHandler(this.txtXPNDR_ValueChanged);
            this.txtXPNDR.Enter += new System.EventHandler(this.txtXPNDR_Enter);
            this.txtXPNDR.Leave += new System.EventHandler(this.txtXPNDR_Leave);
            // 
            // chkClimbVia
            // 
            this.chkClimbVia.AutoSize = true;
            this.chkClimbVia.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkClimbVia.Checked = true;
            this.chkClimbVia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClimbVia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClimbVia.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkClimbVia.Location = new System.Drawing.Point(79, 303);
            this.chkClimbVia.Name = "chkClimbVia";
            this.chkClimbVia.Size = new System.Drawing.Size(112, 17);
            this.chkClimbVia.TabIndex = 13;
            this.chkClimbVia.Text = "CLIMB VIA SID";
            this.chkClimbVia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkClimbVia.UseVisualStyleBackColor = true;
            this.chkClimbVia.CheckedChanged += new System.EventHandler(this.chkClimbVia_CheckedChanged);
            // 
            // txtAltInit
            // 
            this.txtAltInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAltInit.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtAltInit.Location = new System.Drawing.Point(332, 302);
            this.txtAltInit.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.txtAltInit.Name = "txtAltInit";
            this.txtAltInit.Size = new System.Drawing.Size(79, 20);
            this.txtAltInit.TabIndex = 14;
            this.txtAltInit.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.txtAltInit.Enter += new System.EventHandler(this.txtAltInit_Enter);
            // 
            // lblAltInit
            // 
            this.lblAltInit.AutoSize = true;
            this.lblAltInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltInit.Location = new System.Drawing.Point(190, 305);
            this.lblAltInit.Name = "lblAltInit";
            this.lblAltInit.Size = new System.Drawing.Size(139, 13);
            this.lblAltInit.TabIndex = 243;
            this.lblAltInit.Text = "-or- INITIAL ALTITUDE";
            this.lblAltInit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(413, 305);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 13);
            this.label14.TabIndex = 244;
            this.label14.Text = "FT";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(101, 327);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 13);
            this.label16.TabIndex = 246;
            this.label16.Text = "EXPECT FL";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAltExpect
            // 
            this.txtAltExpect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAltExpect.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtAltExpect.Location = new System.Drawing.Point(177, 324);
            this.txtAltExpect.Maximum = new decimal(new int[] {
            430,
            0,
            0,
            0});
            this.txtAltExpect.Name = "txtAltExpect";
            this.txtAltExpect.Size = new System.Drawing.Size(43, 20);
            this.txtAltExpect.TabIndex = 15;
            this.txtAltExpect.Value = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.txtAltExpect.Enter += new System.EventHandler(this.txtAltExpect_Enter);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(223, 327);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(205, 13);
            this.label15.TabIndex = 247;
            this.label15.Text = "10 MINUTES AFTER DEPARTURE";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(53, 352);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(120, 13);
            this.label17.TabIndex = 249;
            this.label17.Text = "DEPARTURE FREQ";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDepFreq
            // 
            this.txtDepFreq.DecimalPlaces = 3;
            this.txtDepFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepFreq.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.txtDepFreq.Location = new System.Drawing.Point(177, 349);
            this.txtDepFreq.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.txtDepFreq.Minimum = new decimal(new int[] {
            118,
            0,
            0,
            0});
            this.txtDepFreq.Name = "txtDepFreq";
            this.txtDepFreq.Size = new System.Drawing.Size(79, 20);
            this.txtDepFreq.TabIndex = 16;
            this.txtDepFreq.Value = new decimal(new int[] {
            1192,
            0,
            0,
            65536});
            this.txtDepFreq.Enter += new System.EventHandler(this.txtDepFreq_Enter);
            // 
            // chkEnroute
            // 
            this.chkEnroute.AutoSize = true;
            this.chkEnroute.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEnroute.Checked = true;
            this.chkEnroute.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnroute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnroute.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEnroute.Location = new System.Drawing.Point(106, 253);
            this.chkEnroute.Name = "chkEnroute";
            this.chkEnroute.Size = new System.Drawing.Size(85, 17);
            this.chkEnroute.TabIndex = 9;
            this.chkEnroute.Text = " AS FILED";
            this.chkEnroute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEnroute.UseVisualStyleBackColor = true;
            this.chkEnroute.CheckedChanged += new System.EventHandler(this.chkEnroute_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cboDEST);
            this.groupBox2.Controls.Add(this.cboDEP);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtFltNum);
            this.groupBox2.Controls.Add(this.label79);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Location = new System.Drawing.Point(19, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(638, 117);
            this.groupBox2.TabIndex = 252;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MANDITORY ENTRIES";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Maroon;
            this.label19.Location = new System.Drawing.Point(269, 93);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 13);
            this.label19.TabIndex = 248;
            this.label19.Text = "Required";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Maroon;
            this.label18.Location = new System.Drawing.Point(269, 67);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 13);
            this.label18.TabIndex = 247;
            this.label18.Text = "Required";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Maroon;
            this.label13.Location = new System.Drawing.Point(214, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 246;
            this.label13.Text = "Required";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(579, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 245;
            this.label9.Text = "Required";
            // 
            // cboDEST
            // 
            this.cboDEST.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDEST.FormattingEnabled = true;
            this.cboDEST.Location = new System.Drawing.Point(158, 90);
            this.cboDEST.Name = "cboDEST";
            this.cboDEST.Size = new System.Drawing.Size(108, 21);
            this.cboDEST.Sorted = true;
            this.cboDEST.TabIndex = 3;
            this.cboDEST.SelectedIndexChanged += new System.EventHandler(this.cboDEST_SelectedIndexChanged);
            // 
            // cboDEP
            // 
            this.cboDEP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDEP.FormattingEnabled = true;
            this.cboDEP.Location = new System.Drawing.Point(158, 64);
            this.cboDEP.Name = "cboDEP";
            this.cboDEP.Size = new System.Drawing.Size(108, 21);
            this.cboDEP.Sorted = true;
            this.cboDEP.TabIndex = 2;
            this.cboDEP.SelectedIndexChanged += new System.EventHandler(this.cboDEP_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 13);
            this.label5.TabIndex = 244;
            this.label5.Text = "DESTINATION AIRPORT";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 243;
            this.label4.Text = "DEPARTURE AIRPORT";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(128, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 242;
            this.label3.Text = "AAL";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 241;
            this.label2.Text = "FLIGHT NUMBER";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFltNum
            // 
            this.txtFltNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFltNum.Location = new System.Drawing.Point(158, 40);
            this.txtFltNum.MaxLength = 4;
            this.txtFltNum.Name = "txtFltNum";
            this.txtFltNum.Size = new System.Drawing.Size(54, 20);
            this.txtFltNum.TabIndex = 1;
            this.txtFltNum.WordWrap = false;
            this.txtFltNum.TextChanged += new System.EventHandler(this.txtFltNum_TextChanged);
            this.txtFltNum.Enter += new System.EventHandler(this.txtFltNum_Enter);
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label79.Location = new System.Drawing.Point(36, 19);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(119, 13);
            this.label79.TabIndex = 240;
            this.label79.Text = "CLEARANCE NAME";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(158, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(419, 20);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtSTARTrans
            // 
            this.txtSTARTrans.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTARTrans.Location = new System.Drawing.Point(415, 277);
            this.txtSTARTrans.MaxLength = 20;
            this.txtSTARTrans.Name = "txtSTARTrans";
            this.txtSTARTrans.Size = new System.Drawing.Size(108, 20);
            this.txtSTARTrans.TabIndex = 12;
            this.txtSTARTrans.WordWrap = false;
            this.txtSTARTrans.Enter += new System.EventHandler(this.txtSTARTrans_Enter);
            // 
            // txtSIDTrans
            // 
            this.txtSIDTrans.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSIDTrans.Location = new System.Drawing.Point(415, 225);
            this.txtSIDTrans.MaxLength = 20;
            this.txtSIDTrans.Name = "txtSIDTrans";
            this.txtSIDTrans.Size = new System.Drawing.Size(108, 20);
            this.txtSIDTrans.TabIndex = 8;
            this.txtSIDTrans.WordWrap = false;
            this.txtSIDTrans.Enter += new System.EventHandler(this.txtSIDTrans_Enter);
            // 
            // frmEditClearance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 652);
            this.Controls.Add(this.txtSTARTrans);
            this.Controls.Add(this.txtSIDTrans);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chkEnroute);
            this.Controls.Add(this.txtDepFreq);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtAltExpect);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.chkClimbVia);
            this.Controls.Add(this.txtXPNDR);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtSTAR);
            this.Controls.Add(this.lblEnroute);
            this.Controls.Add(this.txtEnroute);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSID);
            this.Controls.Add(this.cboALTN);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.cboSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.lblAltInit);
            this.Controls.Add(this.txtAltInit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmEditClearance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CLEARANCE BUILDER";
            this.Load += new System.EventHandler(this.frmEditClearance_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtXPNDR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAltInit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAltExpect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepFreq)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cboSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboALTN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblEnroute;
        private System.Windows.Forms.TextBox txtEnroute;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSTAR;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown txtXPNDR;
        private System.Windows.Forms.CheckBox chkClimbVia;
        private System.Windows.Forms.NumericUpDown txtAltInit;
        private System.Windows.Forms.Label lblAltInit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown txtAltExpect;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown txtDepFreq;
        private System.Windows.Forms.CheckBox chkEnroute;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboDEST;
        private System.Windows.Forms.ComboBox cboDEP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFltNum;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSTARTrans;
        private System.Windows.Forms.TextBox txtSIDTrans;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
    }
}