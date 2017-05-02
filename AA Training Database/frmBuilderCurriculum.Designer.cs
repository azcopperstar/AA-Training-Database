namespace WindowsFormsApplication1 {
    partial class frmBuilderCurriculum {
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
            this.label15 = new System.Windows.Forms.Label();
            this.cboScripts = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtScriptName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPreamble = new System.Windows.Forms.Button();
            this.chk4PlaceAfter = new System.Windows.Forms.CheckBox();
            this.chk4PlaceBefore = new System.Windows.Forms.CheckBox();
            this.cboPreamble4 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chk3PlaceAfter = new System.Windows.Forms.CheckBox();
            this.chk3PlaceBefore = new System.Windows.Forms.CheckBox();
            this.cboPreamble3 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chk2PlaceAfter = new System.Windows.Forms.CheckBox();
            this.chk2PlaceBefore = new System.Windows.Forms.CheckBox();
            this.cboPreamble2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chk1PlaceAfter = new System.Windows.Forms.CheckBox();
            this.chk1PlaceBefore = new System.Windows.Forms.CheckBox();
            this.cboPreamble1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGenerateScript = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblTrash = new System.Windows.Forms.Label();
            this.listManeuvers = new System.Windows.Forms.ListBox();
            this.listScript = new System.Windows.Forms.ListBox();
            this.chk8PlaceAfter = new System.Windows.Forms.CheckBox();
            this.chk8PlaceBefore = new System.Windows.Forms.CheckBox();
            this.cboPreamble8 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chk7PlaceAfter = new System.Windows.Forms.CheckBox();
            this.chk7PlaceBefore = new System.Windows.Forms.CheckBox();
            this.cboPreamble7 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chk6PlaceAfter = new System.Windows.Forms.CheckBox();
            this.chk6PlaceBefore = new System.Windows.Forms.CheckBox();
            this.cboPreamble6 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chk5PlaceAfter = new System.Windows.Forms.CheckBox();
            this.chk5PlaceBefore = new System.Windows.Forms.CheckBox();
            this.cboPreamble5 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chk10PlaceAfter = new System.Windows.Forms.CheckBox();
            this.chk10PlaceBefore = new System.Windows.Forms.CheckBox();
            this.cboPreamble10 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chk9PlaceAfter = new System.Windows.Forms.CheckBox();
            this.chk9PlaceBefore = new System.Windows.Forms.CheckBox();
            this.cboPreamble9 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(353, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(138, 13);
            this.label15.TabIndex = 109;
            this.label15.Text = "SAVED CURRICULUM:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboScripts
            // 
            this.cboScripts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboScripts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboScripts.FormattingEnabled = true;
            this.cboScripts.Location = new System.Drawing.Point(494, 6);
            this.cboScripts.Name = "cboScripts";
            this.cboScripts.Size = new System.Drawing.Size(464, 21);
            this.cboScripts.Sorted = true;
            this.cboScripts.TabIndex = 108;
            this.cboScripts.SelectedIndexChanged += new System.EventHandler(this.cboScripts_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Control;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Enabled = false;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "LESSON 01",
            "LESSON 02",
            "LESSON 03",
            "LESSON 04",
            "LESSON 05",
            "LESSON 06",
            "LESSON 07",
            "LESSON 08",
            "LESSON 09",
            "LESSON 10",
            "LESSON 11",
            "LESSON 12",
            "LESSON 13",
            "LESSON 14",
            "LESSON 15",
            "LESSON 16",
            "LESSON 17",
            "LESSON 18",
            "LESSON 19",
            "LESSON 20",
            "LESSON 21",
            "LESSON 22",
            "LESSON 23",
            "LESSON 24",
            "LESSON 25",
            "LESSON 26",
            "LESSON 27",
            "LESSON 28",
            "LESSON 29",
            "LESSON 30"});
            this.listBox1.Location = new System.Drawing.Point(832, 75);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBox1.Size = new System.Drawing.Size(67, 403);
            this.listBox1.TabIndex = 103;
            // 
            // txtScriptName
            // 
            this.txtScriptName.Location = new System.Drawing.Point(494, 34);
            this.txtScriptName.Name = "txtScriptName";
            this.txtScriptName.Size = new System.Drawing.Size(464, 20);
            this.txtScriptName.TabIndex = 102;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(359, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 101;
            this.label3.Text = "CURRICULUM NAME:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(903, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 13);
            this.label2.TabIndex = 100;
            this.label2.Text = "LESSONS IN CURRICULUM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(419, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "AVAILABLE LESSONS";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chk10PlaceAfter);
            this.groupBox2.Controls.Add(this.chk10PlaceBefore);
            this.groupBox2.Controls.Add(this.cboPreamble10);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.chk9PlaceAfter);
            this.groupBox2.Controls.Add(this.chk9PlaceBefore);
            this.groupBox2.Controls.Add(this.cboPreamble9);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.chk8PlaceAfter);
            this.groupBox2.Controls.Add(this.chk8PlaceBefore);
            this.groupBox2.Controls.Add(this.cboPreamble8);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.chk7PlaceAfter);
            this.groupBox2.Controls.Add(this.chk7PlaceBefore);
            this.groupBox2.Controls.Add(this.cboPreamble7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.chk6PlaceAfter);
            this.groupBox2.Controls.Add(this.chk6PlaceBefore);
            this.groupBox2.Controls.Add(this.cboPreamble6);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.chk5PlaceAfter);
            this.groupBox2.Controls.Add(this.chk5PlaceBefore);
            this.groupBox2.Controls.Add(this.cboPreamble5);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btnPreamble);
            this.groupBox2.Controls.Add(this.chk4PlaceAfter);
            this.groupBox2.Controls.Add(this.chk4PlaceBefore);
            this.groupBox2.Controls.Add(this.cboPreamble4);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.chk3PlaceAfter);
            this.groupBox2.Controls.Add(this.chk3PlaceBefore);
            this.groupBox2.Controls.Add(this.cboPreamble3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.chk2PlaceAfter);
            this.groupBox2.Controls.Add(this.chk2PlaceBefore);
            this.groupBox2.Controls.Add(this.cboPreamble2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.chk1PlaceAfter);
            this.groupBox2.Controls.Add(this.chk1PlaceBefore);
            this.groupBox2.Controls.Add(this.cboPreamble1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 577);
            this.groupBox2.TabIndex = 118;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MATERIAL BEFORE OR AFTER";
            // 
            // btnPreamble
            // 
            this.btnPreamble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreamble.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPreamble.Location = new System.Drawing.Point(25, 19);
            this.btnPreamble.Name = "btnPreamble";
            this.btnPreamble.Size = new System.Drawing.Size(186, 29);
            this.btnPreamble.TabIndex = 205;
            this.btnPreamble.Text = "PREAMBLE BUILDER";
            this.btnPreamble.UseVisualStyleBackColor = true;
            this.btnPreamble.Click += new System.EventHandler(this.btnPreamble_Click);
            // 
            // chk4PlaceAfter
            // 
            this.chk4PlaceAfter.AutoSize = true;
            this.chk4PlaceAfter.Location = new System.Drawing.Point(212, 236);
            this.chk4PlaceAfter.Name = "chk4PlaceAfter";
            this.chk4PlaceAfter.Size = new System.Drawing.Size(109, 17);
            this.chk4PlaceAfter.TabIndex = 107;
            this.chk4PlaceAfter.Text = "PLACE AFTER";
            this.chk4PlaceAfter.UseVisualStyleBackColor = true;
            // 
            // chk4PlaceBefore
            // 
            this.chk4PlaceBefore.AutoSize = true;
            this.chk4PlaceBefore.Location = new System.Drawing.Point(25, 236);
            this.chk4PlaceBefore.Name = "chk4PlaceBefore";
            this.chk4PlaceBefore.Size = new System.Drawing.Size(118, 17);
            this.chk4PlaceBefore.TabIndex = 106;
            this.chk4PlaceBefore.Text = "PLACE BEFORE";
            this.chk4PlaceBefore.UseVisualStyleBackColor = true;
            // 
            // cboPreamble4
            // 
            this.cboPreamble4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPreamble4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPreamble4.FormattingEnabled = true;
            this.cboPreamble4.Location = new System.Drawing.Point(109, 209);
            this.cboPreamble4.Name = "cboPreamble4";
            this.cboPreamble4.Size = new System.Drawing.Size(289, 21);
            this.cboPreamble4.Sorted = true;
            this.cboPreamble4.TabIndex = 105;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 104;
            this.label7.Text = "PREAMBLE 4";
            // 
            // chk3PlaceAfter
            // 
            this.chk3PlaceAfter.AutoSize = true;
            this.chk3PlaceAfter.Location = new System.Drawing.Point(212, 186);
            this.chk3PlaceAfter.Name = "chk3PlaceAfter";
            this.chk3PlaceAfter.Size = new System.Drawing.Size(109, 17);
            this.chk3PlaceAfter.TabIndex = 103;
            this.chk3PlaceAfter.Text = "PLACE AFTER";
            this.chk3PlaceAfter.UseVisualStyleBackColor = true;
            // 
            // chk3PlaceBefore
            // 
            this.chk3PlaceBefore.AutoSize = true;
            this.chk3PlaceBefore.Location = new System.Drawing.Point(25, 186);
            this.chk3PlaceBefore.Name = "chk3PlaceBefore";
            this.chk3PlaceBefore.Size = new System.Drawing.Size(118, 17);
            this.chk3PlaceBefore.TabIndex = 102;
            this.chk3PlaceBefore.Text = "PLACE BEFORE";
            this.chk3PlaceBefore.UseVisualStyleBackColor = true;
            // 
            // cboPreamble3
            // 
            this.cboPreamble3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPreamble3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPreamble3.FormattingEnabled = true;
            this.cboPreamble3.Location = new System.Drawing.Point(109, 159);
            this.cboPreamble3.Name = "cboPreamble3";
            this.cboPreamble3.Size = new System.Drawing.Size(289, 21);
            this.cboPreamble3.Sorted = true;
            this.cboPreamble3.TabIndex = 101;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 100;
            this.label6.Text = "PREAMBLE 3";
            // 
            // chk2PlaceAfter
            // 
            this.chk2PlaceAfter.AutoSize = true;
            this.chk2PlaceAfter.Location = new System.Drawing.Point(212, 136);
            this.chk2PlaceAfter.Name = "chk2PlaceAfter";
            this.chk2PlaceAfter.Size = new System.Drawing.Size(109, 17);
            this.chk2PlaceAfter.TabIndex = 99;
            this.chk2PlaceAfter.Text = "PLACE AFTER";
            this.chk2PlaceAfter.UseVisualStyleBackColor = true;
            // 
            // chk2PlaceBefore
            // 
            this.chk2PlaceBefore.AutoSize = true;
            this.chk2PlaceBefore.Location = new System.Drawing.Point(25, 136);
            this.chk2PlaceBefore.Name = "chk2PlaceBefore";
            this.chk2PlaceBefore.Size = new System.Drawing.Size(118, 17);
            this.chk2PlaceBefore.TabIndex = 98;
            this.chk2PlaceBefore.Text = "PLACE BEFORE";
            this.chk2PlaceBefore.UseVisualStyleBackColor = true;
            // 
            // cboPreamble2
            // 
            this.cboPreamble2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPreamble2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPreamble2.FormattingEnabled = true;
            this.cboPreamble2.Location = new System.Drawing.Point(109, 109);
            this.cboPreamble2.Name = "cboPreamble2";
            this.cboPreamble2.Size = new System.Drawing.Size(289, 21);
            this.cboPreamble2.Sorted = true;
            this.cboPreamble2.TabIndex = 97;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 96;
            this.label5.Text = "PREAMBLE 2";
            // 
            // chk1PlaceAfter
            // 
            this.chk1PlaceAfter.AutoSize = true;
            this.chk1PlaceAfter.Location = new System.Drawing.Point(212, 86);
            this.chk1PlaceAfter.Name = "chk1PlaceAfter";
            this.chk1PlaceAfter.Size = new System.Drawing.Size(109, 17);
            this.chk1PlaceAfter.TabIndex = 95;
            this.chk1PlaceAfter.Text = "PLACE AFTER";
            this.chk1PlaceAfter.UseVisualStyleBackColor = true;
            // 
            // chk1PlaceBefore
            // 
            this.chk1PlaceBefore.AutoSize = true;
            this.chk1PlaceBefore.Location = new System.Drawing.Point(25, 86);
            this.chk1PlaceBefore.Name = "chk1PlaceBefore";
            this.chk1PlaceBefore.Size = new System.Drawing.Size(118, 17);
            this.chk1PlaceBefore.TabIndex = 94;
            this.chk1PlaceBefore.Text = "PLACE BEFORE";
            this.chk1PlaceBefore.UseVisualStyleBackColor = true;
            // 
            // cboPreamble1
            // 
            this.cboPreamble1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPreamble1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPreamble1.FormattingEnabled = true;
            this.cboPreamble1.Location = new System.Drawing.Point(109, 59);
            this.cboPreamble1.Name = "cboPreamble1";
            this.cboPreamble1.Size = new System.Drawing.Size(289, 21);
            this.cboPreamble1.Sorted = true;
            this.cboPreamble1.TabIndex = 93;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "PREAMBLE 1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnGenerateScript);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Location = new System.Drawing.Point(900, 491);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 171);
            this.groupBox1.TabIndex = 117;
            this.groupBox1.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.ForeColor = System.Drawing.Color.Maroon;
            this.btnClear.Location = new System.Drawing.Point(29, 132);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(194, 23);
            this.btnClear.TabIndex = 96;
            this.btnClear.Text = "CLEAR DATA";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGenerateScript
            // 
            this.btnGenerateScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateScript.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGenerateScript.Location = new System.Drawing.Point(29, 16);
            this.btnGenerateScript.Name = "btnGenerateScript";
            this.btnGenerateScript.Size = new System.Drawing.Size(194, 23);
            this.btnGenerateScript.TabIndex = 8;
            this.btnGenerateScript.Text = "GENERATE LESSON PDF";
            this.btnGenerateScript.UseVisualStyleBackColor = true;
            this.btnGenerateScript.Click += new System.EventHandler(this.btnGenerateScript_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.ForeColor = System.Drawing.Color.Maroon;
            this.btnDelete.Location = new System.Drawing.Point(29, 103);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(194, 23);
            this.btnDelete.TabIndex = 95;
            this.btnDelete.Text = "DELETE SELECTED LESSON";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Green;
            this.btnSave.Location = new System.Drawing.Point(29, 45);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(194, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "SAVE NEW LESSON";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnUpdate.Location = new System.Drawing.Point(29, 74);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(194, 23);
            this.btnUpdate.TabIndex = 94;
            this.btnUpdate.Text = "UPDATE CURRENT LESSON";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblTrash
            // 
            this.lblTrash.AllowDrop = true;
            this.lblTrash.Image = global::WindowsFormsApplication1.Properties.Resources.Trash;
            this.lblTrash.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblTrash.Location = new System.Drawing.Point(1223, 24);
            this.lblTrash.Name = "lblTrash";
            this.lblTrash.Size = new System.Drawing.Size(47, 48);
            this.lblTrash.TabIndex = 115;
            this.lblTrash.Text = "TRASH";
            // 
            // listManeuvers
            // 
            this.listManeuvers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listManeuvers.FormattingEnabled = true;
            this.listManeuvers.Location = new System.Drawing.Point(416, 75);
            this.listManeuvers.Name = "listManeuvers";
            this.listManeuvers.Size = new System.Drawing.Size(401, 394);
            this.listManeuvers.TabIndex = 110;
            // 
            // listScript
            // 
            this.listScript.AllowDrop = true;
            this.listScript.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listScript.FormattingEnabled = true;
            this.listScript.Location = new System.Drawing.Point(900, 75);
            this.listScript.Name = "listScript";
            this.listScript.Size = new System.Drawing.Size(373, 394);
            this.listScript.TabIndex = 111;
            // 
            // chk8PlaceAfter
            // 
            this.chk8PlaceAfter.AutoSize = true;
            this.chk8PlaceAfter.Location = new System.Drawing.Point(212, 436);
            this.chk8PlaceAfter.Name = "chk8PlaceAfter";
            this.chk8PlaceAfter.Size = new System.Drawing.Size(109, 17);
            this.chk8PlaceAfter.TabIndex = 221;
            this.chk8PlaceAfter.Text = "PLACE AFTER";
            this.chk8PlaceAfter.UseVisualStyleBackColor = true;
            // 
            // chk8PlaceBefore
            // 
            this.chk8PlaceBefore.AutoSize = true;
            this.chk8PlaceBefore.Location = new System.Drawing.Point(25, 436);
            this.chk8PlaceBefore.Name = "chk8PlaceBefore";
            this.chk8PlaceBefore.Size = new System.Drawing.Size(118, 17);
            this.chk8PlaceBefore.TabIndex = 220;
            this.chk8PlaceBefore.Text = "PLACE BEFORE";
            this.chk8PlaceBefore.UseVisualStyleBackColor = true;
            // 
            // cboPreamble8
            // 
            this.cboPreamble8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPreamble8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPreamble8.FormattingEnabled = true;
            this.cboPreamble8.Location = new System.Drawing.Point(109, 409);
            this.cboPreamble8.Name = "cboPreamble8";
            this.cboPreamble8.Size = new System.Drawing.Size(289, 21);
            this.cboPreamble8.Sorted = true;
            this.cboPreamble8.TabIndex = 219;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 412);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 218;
            this.label8.Text = "PREAMBLE 8";
            // 
            // chk7PlaceAfter
            // 
            this.chk7PlaceAfter.AutoSize = true;
            this.chk7PlaceAfter.Location = new System.Drawing.Point(212, 386);
            this.chk7PlaceAfter.Name = "chk7PlaceAfter";
            this.chk7PlaceAfter.Size = new System.Drawing.Size(109, 17);
            this.chk7PlaceAfter.TabIndex = 217;
            this.chk7PlaceAfter.Text = "PLACE AFTER";
            this.chk7PlaceAfter.UseVisualStyleBackColor = true;
            // 
            // chk7PlaceBefore
            // 
            this.chk7PlaceBefore.AutoSize = true;
            this.chk7PlaceBefore.Location = new System.Drawing.Point(25, 386);
            this.chk7PlaceBefore.Name = "chk7PlaceBefore";
            this.chk7PlaceBefore.Size = new System.Drawing.Size(118, 17);
            this.chk7PlaceBefore.TabIndex = 216;
            this.chk7PlaceBefore.Text = "PLACE BEFORE";
            this.chk7PlaceBefore.UseVisualStyleBackColor = true;
            // 
            // cboPreamble7
            // 
            this.cboPreamble7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPreamble7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPreamble7.FormattingEnabled = true;
            this.cboPreamble7.Location = new System.Drawing.Point(109, 359);
            this.cboPreamble7.Name = "cboPreamble7";
            this.cboPreamble7.Size = new System.Drawing.Size(289, 21);
            this.cboPreamble7.Sorted = true;
            this.cboPreamble7.TabIndex = 215;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(22, 362);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 214;
            this.label9.Text = "PREAMBLE 7";
            // 
            // chk6PlaceAfter
            // 
            this.chk6PlaceAfter.AutoSize = true;
            this.chk6PlaceAfter.Location = new System.Drawing.Point(212, 336);
            this.chk6PlaceAfter.Name = "chk6PlaceAfter";
            this.chk6PlaceAfter.Size = new System.Drawing.Size(109, 17);
            this.chk6PlaceAfter.TabIndex = 213;
            this.chk6PlaceAfter.Text = "PLACE AFTER";
            this.chk6PlaceAfter.UseVisualStyleBackColor = true;
            // 
            // chk6PlaceBefore
            // 
            this.chk6PlaceBefore.AutoSize = true;
            this.chk6PlaceBefore.Location = new System.Drawing.Point(25, 336);
            this.chk6PlaceBefore.Name = "chk6PlaceBefore";
            this.chk6PlaceBefore.Size = new System.Drawing.Size(118, 17);
            this.chk6PlaceBefore.TabIndex = 212;
            this.chk6PlaceBefore.Text = "PLACE BEFORE";
            this.chk6PlaceBefore.UseVisualStyleBackColor = true;
            // 
            // cboPreamble6
            // 
            this.cboPreamble6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPreamble6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPreamble6.FormattingEnabled = true;
            this.cboPreamble6.Location = new System.Drawing.Point(109, 309);
            this.cboPreamble6.Name = "cboPreamble6";
            this.cboPreamble6.Size = new System.Drawing.Size(289, 21);
            this.cboPreamble6.Sorted = true;
            this.cboPreamble6.TabIndex = 211;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(22, 312);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 210;
            this.label10.Text = "PREAMBLE 6";
            // 
            // chk5PlaceAfter
            // 
            this.chk5PlaceAfter.AutoSize = true;
            this.chk5PlaceAfter.Location = new System.Drawing.Point(212, 286);
            this.chk5PlaceAfter.Name = "chk5PlaceAfter";
            this.chk5PlaceAfter.Size = new System.Drawing.Size(109, 17);
            this.chk5PlaceAfter.TabIndex = 209;
            this.chk5PlaceAfter.Text = "PLACE AFTER";
            this.chk5PlaceAfter.UseVisualStyleBackColor = true;
            // 
            // chk5PlaceBefore
            // 
            this.chk5PlaceBefore.AutoSize = true;
            this.chk5PlaceBefore.Location = new System.Drawing.Point(25, 286);
            this.chk5PlaceBefore.Name = "chk5PlaceBefore";
            this.chk5PlaceBefore.Size = new System.Drawing.Size(118, 17);
            this.chk5PlaceBefore.TabIndex = 208;
            this.chk5PlaceBefore.Text = "PLACE BEFORE";
            this.chk5PlaceBefore.UseVisualStyleBackColor = true;
            // 
            // cboPreamble5
            // 
            this.cboPreamble5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPreamble5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPreamble5.FormattingEnabled = true;
            this.cboPreamble5.Location = new System.Drawing.Point(109, 259);
            this.cboPreamble5.Name = "cboPreamble5";
            this.cboPreamble5.Size = new System.Drawing.Size(289, 21);
            this.cboPreamble5.Sorted = true;
            this.cboPreamble5.TabIndex = 207;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(22, 262);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 206;
            this.label11.Text = "PREAMBLE 5";
            // 
            // chk10PlaceAfter
            // 
            this.chk10PlaceAfter.AutoSize = true;
            this.chk10PlaceAfter.Location = new System.Drawing.Point(212, 536);
            this.chk10PlaceAfter.Name = "chk10PlaceAfter";
            this.chk10PlaceAfter.Size = new System.Drawing.Size(109, 17);
            this.chk10PlaceAfter.TabIndex = 229;
            this.chk10PlaceAfter.Text = "PLACE AFTER";
            this.chk10PlaceAfter.UseVisualStyleBackColor = true;
            // 
            // chk10PlaceBefore
            // 
            this.chk10PlaceBefore.AutoSize = true;
            this.chk10PlaceBefore.Location = new System.Drawing.Point(25, 536);
            this.chk10PlaceBefore.Name = "chk10PlaceBefore";
            this.chk10PlaceBefore.Size = new System.Drawing.Size(118, 17);
            this.chk10PlaceBefore.TabIndex = 228;
            this.chk10PlaceBefore.Text = "PLACE BEFORE";
            this.chk10PlaceBefore.UseVisualStyleBackColor = true;
            // 
            // cboPreamble10
            // 
            this.cboPreamble10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPreamble10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPreamble10.FormattingEnabled = true;
            this.cboPreamble10.Location = new System.Drawing.Point(109, 509);
            this.cboPreamble10.Name = "cboPreamble10";
            this.cboPreamble10.Size = new System.Drawing.Size(289, 21);
            this.cboPreamble10.Sorted = true;
            this.cboPreamble10.TabIndex = 227;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(15, 512);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 13);
            this.label12.TabIndex = 226;
            this.label12.Text = "PREAMBLE 10";
            // 
            // chk9PlaceAfter
            // 
            this.chk9PlaceAfter.AutoSize = true;
            this.chk9PlaceAfter.Location = new System.Drawing.Point(212, 486);
            this.chk9PlaceAfter.Name = "chk9PlaceAfter";
            this.chk9PlaceAfter.Size = new System.Drawing.Size(109, 17);
            this.chk9PlaceAfter.TabIndex = 225;
            this.chk9PlaceAfter.Text = "PLACE AFTER";
            this.chk9PlaceAfter.UseVisualStyleBackColor = true;
            // 
            // chk9PlaceBefore
            // 
            this.chk9PlaceBefore.AutoSize = true;
            this.chk9PlaceBefore.Location = new System.Drawing.Point(25, 486);
            this.chk9PlaceBefore.Name = "chk9PlaceBefore";
            this.chk9PlaceBefore.Size = new System.Drawing.Size(118, 17);
            this.chk9PlaceBefore.TabIndex = 224;
            this.chk9PlaceBefore.Text = "PLACE BEFORE";
            this.chk9PlaceBefore.UseVisualStyleBackColor = true;
            // 
            // cboPreamble9
            // 
            this.cboPreamble9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPreamble9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPreamble9.FormattingEnabled = true;
            this.cboPreamble9.Location = new System.Drawing.Point(109, 459);
            this.cboPreamble9.Name = "cboPreamble9";
            this.cboPreamble9.Size = new System.Drawing.Size(289, 21);
            this.cboPreamble9.Sorted = true;
            this.cboPreamble9.TabIndex = 223;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(22, 462);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 13);
            this.label13.TabIndex = 222;
            this.label13.Text = "PREAMBLE 9";
            // 
            // frmBuilderCurriculum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 671);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTrash);
            this.Controls.Add(this.listManeuvers);
            this.Controls.Add(this.listScript);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cboScripts);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtScriptName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmBuilderCurriculum";
            this.Text = " Flight Training - CURRICULUM BUILDER";
            this.Load += new System.EventHandler(this.frmBuilderCurriculum_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboScripts;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtScriptName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPreamble;
        private System.Windows.Forms.CheckBox chk4PlaceAfter;
        private System.Windows.Forms.CheckBox chk4PlaceBefore;
        private System.Windows.Forms.ComboBox cboPreamble4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chk3PlaceAfter;
        private System.Windows.Forms.CheckBox chk3PlaceBefore;
        private System.Windows.Forms.ComboBox cboPreamble3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chk2PlaceAfter;
        private System.Windows.Forms.CheckBox chk2PlaceBefore;
        private System.Windows.Forms.ComboBox cboPreamble2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chk1PlaceAfter;
        private System.Windows.Forms.CheckBox chk1PlaceBefore;
        private System.Windows.Forms.ComboBox cboPreamble1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnGenerateScript;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblTrash;
        private System.Windows.Forms.ListBox listManeuvers;
        private System.Windows.Forms.ListBox listScript;
        private System.Windows.Forms.CheckBox chk8PlaceAfter;
        private System.Windows.Forms.CheckBox chk8PlaceBefore;
        private System.Windows.Forms.ComboBox cboPreamble8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chk7PlaceAfter;
        private System.Windows.Forms.CheckBox chk7PlaceBefore;
        private System.Windows.Forms.ComboBox cboPreamble7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chk6PlaceAfter;
        private System.Windows.Forms.CheckBox chk6PlaceBefore;
        private System.Windows.Forms.ComboBox cboPreamble6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chk5PlaceAfter;
        private System.Windows.Forms.CheckBox chk5PlaceBefore;
        private System.Windows.Forms.ComboBox cboPreamble5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chk10PlaceAfter;
        private System.Windows.Forms.CheckBox chk10PlaceBefore;
        private System.Windows.Forms.ComboBox cboPreamble10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chk9PlaceAfter;
        private System.Windows.Forms.CheckBox chk9PlaceBefore;
        private System.Windows.Forms.ComboBox cboPreamble9;
        private System.Windows.Forms.Label label13;
    }
}