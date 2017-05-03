namespace WindowsFormsApplication1 {
    partial class frmBuilderLesson {
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
            this.listManeuvers = new System.Windows.Forms.ListBox();
            this.listScript = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtScriptName = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblTrash = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cboScripts = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listManeuvers
            // 
            this.listManeuvers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listManeuvers.FormattingEnabled = true;
            this.listManeuvers.Location = new System.Drawing.Point(414, 94);
            this.listManeuvers.Name = "listManeuvers";
            this.listManeuvers.Size = new System.Drawing.Size(401, 394);
            this.listManeuvers.TabIndex = 0;
            // 
            // listScript
            // 
            this.listScript.AllowDrop = true;
            this.listScript.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listScript.FormattingEnabled = true;
            this.listScript.Location = new System.Drawing.Point(898, 94);
            this.listScript.Name = "listScript";
            this.listScript.Size = new System.Drawing.Size(373, 394);
            this.listScript.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(411, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "AVAILABLE SPOTS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(895, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "SPOTS IN LESSON";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "LESSON NAME:";
            // 
            // txtScriptName
            // 
            this.txtScriptName.Location = new System.Drawing.Point(169, 40);
            this.txtScriptName.Name = "txtScriptName";
            this.txtScriptName.Size = new System.Drawing.Size(464, 20);
            this.txtScriptName.TabIndex = 5;
            this.txtScriptName.TextChanged += new System.EventHandler(this.txtScriptName_TextChanged);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Control;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Enabled = false;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "SPOT 01",
            "SPOT 02",
            "SPOT 03",
            "SPOT 04",
            "SPOT 05",
            "SPOT 06",
            "SPOT 07",
            "SPOT 08",
            "SPOT 09",
            "SPOT 10",
            "SPOT 11",
            "SPOT 12",
            "SPOT 13",
            "SPOT 14",
            "SPOT 15",
            "SPOT 16",
            "SPOT 17",
            "SPOT 18",
            "SPOT 19",
            "SPOT 20",
            "SPOT 21",
            "SPOT 22",
            "SPOT 23",
            "SPOT 24",
            "SPOT 25",
            "SPOT 26",
            "SPOT 27",
            "SPOT 28",
            "SPOT 29",
            "SPOT 30"});
            this.listBox1.Location = new System.Drawing.Point(829, 95);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBox1.Size = new System.Drawing.Size(67, 403);
            this.listBox1.TabIndex = 6;
            // 
            // lblTrash
            // 
            this.lblTrash.AllowDrop = true;
            this.lblTrash.Image = global::WindowsFormsApplication1.Properties.Resources.Trash;
            this.lblTrash.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblTrash.Location = new System.Drawing.Point(1221, 43);
            this.lblTrash.Name = "lblTrash";
            this.lblTrash.Size = new System.Drawing.Size(47, 48);
            this.lblTrash.TabIndex = 7;
            this.lblTrash.Text = "TRASH";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Green;
            this.btnSave.Location = new System.Drawing.Point(24, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(194, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "SAVE NEW LESSON";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Green;
            this.lblTime.Location = new System.Drawing.Point(810, 491);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(126, 13);
            this.lblTime.TabIndex = 10;
            this.lblTime.Text = "SCRIPT TIME: 00:00";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(53, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 13);
            this.label15.TabIndex = 93;
            this.label15.Text = "SAVED LESSONS:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboScripts
            // 
            this.cboScripts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboScripts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboScripts.FormattingEnabled = true;
            this.cboScripts.Location = new System.Drawing.Point(169, 14);
            this.cboScripts.Name = "cboScripts";
            this.cboScripts.Size = new System.Drawing.Size(464, 21);
            this.cboScripts.Sorted = true;
            this.cboScripts.TabIndex = 92;
            this.cboScripts.SelectedIndexChanged += new System.EventHandler(this.cboScripts_SelectedIndexChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnUpdate.Location = new System.Drawing.Point(24, 48);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(194, 23);
            this.btnUpdate.TabIndex = 94;
            this.btnUpdate.Text = "UPDATE CURRENT LESSON";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.ForeColor = System.Drawing.Color.Maroon;
            this.btnDelete.Location = new System.Drawing.Point(24, 77);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(194, 23);
            this.btnDelete.TabIndex = 95;
            this.btnDelete.Text = "DELETE SELECTED LESSON";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.ForeColor = System.Drawing.Color.Maroon;
            this.btnClear.Location = new System.Drawing.Point(24, 106);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(194, 23);
            this.btnClear.TabIndex = 96;
            this.btnClear.Text = "CLEAR DATA";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Location = new System.Drawing.Point(898, 507);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 144);
            this.groupBox1.TabIndex = 97;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
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
            this.groupBox2.Location = new System.Drawing.Point(4, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 400);
            this.groupBox2.TabIndex = 98;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LESSON PREAMBLE";
            // 
            // btnPreamble
            // 
            this.btnPreamble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreamble.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPreamble.Location = new System.Drawing.Point(25, 229);
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
            this.chk4PlaceAfter.Location = new System.Drawing.Point(212, 196);
            this.chk4PlaceAfter.Name = "chk4PlaceAfter";
            this.chk4PlaceAfter.Size = new System.Drawing.Size(162, 17);
            this.chk4PlaceAfter.TabIndex = 107;
            this.chk4PlaceAfter.Text = "PLACE AFTER LESSON";
            this.chk4PlaceAfter.UseVisualStyleBackColor = true;
            // 
            // chk4PlaceBefore
            // 
            this.chk4PlaceBefore.AutoSize = true;
            this.chk4PlaceBefore.Location = new System.Drawing.Point(25, 196);
            this.chk4PlaceBefore.Name = "chk4PlaceBefore";
            this.chk4PlaceBefore.Size = new System.Drawing.Size(171, 17);
            this.chk4PlaceBefore.TabIndex = 106;
            this.chk4PlaceBefore.Text = "PLACE BEFORE LESSON";
            this.chk4PlaceBefore.UseVisualStyleBackColor = true;
            // 
            // cboPreamble4
            // 
            this.cboPreamble4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPreamble4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPreamble4.FormattingEnabled = true;
            this.cboPreamble4.Location = new System.Drawing.Point(109, 169);
            this.cboPreamble4.Name = "cboPreamble4";
            this.cboPreamble4.Size = new System.Drawing.Size(289, 21);
            this.cboPreamble4.Sorted = true;
            this.cboPreamble4.TabIndex = 105;
            this.cboPreamble4.SelectedIndexChanged += new System.EventHandler(this.cboPreamble4_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 104;
            this.label7.Text = "PREAMBLE 4";
            // 
            // chk3PlaceAfter
            // 
            this.chk3PlaceAfter.AutoSize = true;
            this.chk3PlaceAfter.Location = new System.Drawing.Point(212, 146);
            this.chk3PlaceAfter.Name = "chk3PlaceAfter";
            this.chk3PlaceAfter.Size = new System.Drawing.Size(162, 17);
            this.chk3PlaceAfter.TabIndex = 103;
            this.chk3PlaceAfter.Text = "PLACE AFTER LESSON";
            this.chk3PlaceAfter.UseVisualStyleBackColor = true;
            // 
            // chk3PlaceBefore
            // 
            this.chk3PlaceBefore.AutoSize = true;
            this.chk3PlaceBefore.Location = new System.Drawing.Point(25, 146);
            this.chk3PlaceBefore.Name = "chk3PlaceBefore";
            this.chk3PlaceBefore.Size = new System.Drawing.Size(171, 17);
            this.chk3PlaceBefore.TabIndex = 102;
            this.chk3PlaceBefore.Text = "PLACE BEFORE LESSON";
            this.chk3PlaceBefore.UseVisualStyleBackColor = true;
            // 
            // cboPreamble3
            // 
            this.cboPreamble3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPreamble3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPreamble3.FormattingEnabled = true;
            this.cboPreamble3.Location = new System.Drawing.Point(109, 119);
            this.cboPreamble3.Name = "cboPreamble3";
            this.cboPreamble3.Size = new System.Drawing.Size(289, 21);
            this.cboPreamble3.Sorted = true;
            this.cboPreamble3.TabIndex = 101;
            this.cboPreamble3.SelectedIndexChanged += new System.EventHandler(this.cboPreamble3_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 100;
            this.label6.Text = "PREAMBLE 3";
            // 
            // chk2PlaceAfter
            // 
            this.chk2PlaceAfter.AutoSize = true;
            this.chk2PlaceAfter.Location = new System.Drawing.Point(212, 96);
            this.chk2PlaceAfter.Name = "chk2PlaceAfter";
            this.chk2PlaceAfter.Size = new System.Drawing.Size(162, 17);
            this.chk2PlaceAfter.TabIndex = 99;
            this.chk2PlaceAfter.Text = "PLACE AFTER LESSON";
            this.chk2PlaceAfter.UseVisualStyleBackColor = true;
            // 
            // chk2PlaceBefore
            // 
            this.chk2PlaceBefore.AutoSize = true;
            this.chk2PlaceBefore.Location = new System.Drawing.Point(25, 96);
            this.chk2PlaceBefore.Name = "chk2PlaceBefore";
            this.chk2PlaceBefore.Size = new System.Drawing.Size(171, 17);
            this.chk2PlaceBefore.TabIndex = 98;
            this.chk2PlaceBefore.Text = "PLACE BEFORE LESSON";
            this.chk2PlaceBefore.UseVisualStyleBackColor = true;
            // 
            // cboPreamble2
            // 
            this.cboPreamble2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPreamble2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPreamble2.FormattingEnabled = true;
            this.cboPreamble2.Location = new System.Drawing.Point(109, 69);
            this.cboPreamble2.Name = "cboPreamble2";
            this.cboPreamble2.Size = new System.Drawing.Size(289, 21);
            this.cboPreamble2.Sorted = true;
            this.cboPreamble2.TabIndex = 97;
            this.cboPreamble2.SelectedIndexChanged += new System.EventHandler(this.cboPreamble2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 96;
            this.label5.Text = "PREAMBLE 2";
            // 
            // chk1PlaceAfter
            // 
            this.chk1PlaceAfter.AutoSize = true;
            this.chk1PlaceAfter.Location = new System.Drawing.Point(212, 46);
            this.chk1PlaceAfter.Name = "chk1PlaceAfter";
            this.chk1PlaceAfter.Size = new System.Drawing.Size(162, 17);
            this.chk1PlaceAfter.TabIndex = 95;
            this.chk1PlaceAfter.Text = "PLACE AFTER LESSON";
            this.chk1PlaceAfter.UseVisualStyleBackColor = true;
            // 
            // chk1PlaceBefore
            // 
            this.chk1PlaceBefore.AutoSize = true;
            this.chk1PlaceBefore.Location = new System.Drawing.Point(25, 46);
            this.chk1PlaceBefore.Name = "chk1PlaceBefore";
            this.chk1PlaceBefore.Size = new System.Drawing.Size(171, 17);
            this.chk1PlaceBefore.TabIndex = 94;
            this.chk1PlaceBefore.Text = "PLACE BEFORE LESSON";
            this.chk1PlaceBefore.UseVisualStyleBackColor = true;
            // 
            // cboPreamble1
            // 
            this.cboPreamble1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPreamble1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPreamble1.FormattingEnabled = true;
            this.cboPreamble1.Location = new System.Drawing.Point(109, 19);
            this.cboPreamble1.Name = "cboPreamble1";
            this.cboPreamble1.Size = new System.Drawing.Size(289, 21);
            this.cboPreamble1.Sorted = true;
            this.cboPreamble1.TabIndex = 93;
            this.cboPreamble1.SelectedIndexChanged += new System.EventHandler(this.cboPreamble1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "PREAMBLE 1";
            // 
            // frmBuilderLesson
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 780);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cboScripts);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblTrash);
            this.Controls.Add(this.listManeuvers);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtScriptName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listScript);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmBuilderLesson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Flight Training - LESSON BUILDER";
            this.Load += new System.EventHandler(this.frmDeveloper_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listManeuvers;
        private System.Windows.Forms.ListBox listScript;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtScriptName;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblTrash;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboScripts;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.Button btnPreamble;
    }
}