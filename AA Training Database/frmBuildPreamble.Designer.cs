namespace WindowsFormsApplication1 {
    partial class frmBuildPreamble {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuildPreamble));
            this.cboSelect = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.grpText = new System.Windows.Forms.GroupBox();
            this.btnEdit2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTitle2 = new System.Windows.Forms.TextBox();
            this.txtBody2 = new System.Windows.Forms.RichTextBox();
            this.btnEdit3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTitle3 = new System.Windows.Forms.TextBox();
            this.txtBody3 = new System.Windows.Forms.RichTextBox();
            this.btnEdit1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle1 = new System.Windows.Forms.TextBox();
            this.txtBody1 = new System.Windows.Forms.RichTextBox();
            this.optText = new System.Windows.Forms.RadioButton();
            this.grpPDF = new System.Windows.Forms.GroupBox();
            this.lblPDFPath = new System.Windows.Forms.Label();
            this.btnPDF = new System.Windows.Forms.Button();
            this.optPDF = new System.Windows.Forms.RadioButton();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.groupBox1.SuspendLayout();
            this.grpText.SuspendLayout();
            this.grpPDF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSelect
            // 
            this.cboSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSelect.FormattingEnabled = true;
            this.cboSelect.Location = new System.Drawing.Point(141, 12);
            this.cboSelect.Name = "cboSelect";
            this.cboSelect.Size = new System.Drawing.Size(430, 21);
            this.cboSelect.TabIndex = 177;
            this.cboSelect.SelectedIndexChanged += new System.EventHandler(this.cboSelect_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(126, 13);
            this.label14.TabIndex = 178;
            this.label14.Text = "SAVED PREAMBLES";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label79.Location = new System.Drawing.Point(10, 42);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(128, 13);
            this.label79.TabIndex = 176;
            this.label79.Text = "PREAMBLE HEADER";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(141, 39);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(430, 20);
            this.txtName.TabIndex = 175;
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave_1);
            // 
            // txtDate
            // 
            this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDate.Enabled = false;
            this.txtDate.Location = new System.Drawing.Point(1026, 644);
            this.txtDate.Multiline = true;
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(301, 32);
            this.txtDate.TabIndex = 181;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1026, 498);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 142);
            this.groupBox1.TabIndex = 180;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SAVE / UPDATE";
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(16, 106);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(268, 23);
            this.btnClear.TabIndex = 176;
            this.btnClear.Text = "CLEAR ENTRIES";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnUpdate.Location = new System.Drawing.Point(16, 48);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(268, 23);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.Text = "UPDATE SELECTED PREAMBLE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Maroon;
            this.btnDelete.Location = new System.Drawing.Point(16, 77);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(268, 23);
            this.btnDelete.TabIndex = 175;
            this.btnDelete.Text = "DELETE SELECTED PREAMBLE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Green;
            this.btnSave.Location = new System.Drawing.Point(16, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(268, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "SAVE AS A NEW PREAMBLE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1215, 682);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 23);
            this.btnCancel.TabIndex = 179;
            this.btnCancel.Text = "Close Dialog";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // txtMessage
            // 
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Enabled = false;
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(1027, 687);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(183, 16);
            this.txtMessage.TabIndex = 182;
            // 
            // grpText
            // 
            this.grpText.Controls.Add(this.btnEdit2);
            this.grpText.Controls.Add(this.label5);
            this.grpText.Controls.Add(this.label6);
            this.grpText.Controls.Add(this.txtTitle2);
            this.grpText.Controls.Add(this.txtBody2);
            this.grpText.Controls.Add(this.btnEdit3);
            this.grpText.Controls.Add(this.label3);
            this.grpText.Controls.Add(this.label4);
            this.grpText.Controls.Add(this.txtTitle3);
            this.grpText.Controls.Add(this.txtBody3);
            this.grpText.Controls.Add(this.btnEdit1);
            this.grpText.Controls.Add(this.label2);
            this.grpText.Controls.Add(this.label1);
            this.grpText.Controls.Add(this.txtTitle1);
            this.grpText.Controls.Add(this.txtBody1);
            this.grpText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpText.Location = new System.Drawing.Point(15, 97);
            this.grpText.Name = "grpText";
            this.grpText.Size = new System.Drawing.Size(579, 615);
            this.grpText.TabIndex = 198;
            this.grpText.TabStop = false;
            this.grpText.Text = "TEXT PREAMBLE";
            // 
            // btnEdit2
            // 
            this.btnEdit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit2.Location = new System.Drawing.Point(7, 256);
            this.btnEdit2.Name = "btnEdit2";
            this.btnEdit2.Size = new System.Drawing.Size(68, 23);
            this.btnEdit2.TabIndex = 208;
            this.btnEdit2.Text = "EDIT";
            this.btnEdit2.UseVisualStyleBackColor = true;
            this.btnEdit2.Click += new System.EventHandler(this.btnEdit2_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 207;
            this.label5.Text = "BODY 2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 206;
            this.label6.Text = "TITLE 2";
            // 
            // txtTitle2
            // 
            this.txtTitle2.Location = new System.Drawing.Point(78, 215);
            this.txtTitle2.Name = "txtTitle2";
            this.txtTitle2.Size = new System.Drawing.Size(491, 20);
            this.txtTitle2.TabIndex = 205;
            // 
            // txtBody2
            // 
            this.txtBody2.AcceptsTab = true;
            this.txtBody2.BackColor = System.Drawing.SystemColors.Window;
            this.txtBody2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBody2.Location = new System.Drawing.Point(78, 237);
            this.txtBody2.Name = "txtBody2";
            this.txtBody2.ReadOnly = true;
            this.txtBody2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtBody2.ShowSelectionMargin = true;
            this.txtBody2.Size = new System.Drawing.Size(491, 169);
            this.txtBody2.TabIndex = 204;
            this.txtBody2.Text = "";
            // 
            // btnEdit3
            // 
            this.btnEdit3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit3.Location = new System.Drawing.Point(7, 453);
            this.btnEdit3.Name = "btnEdit3";
            this.btnEdit3.Size = new System.Drawing.Size(68, 23);
            this.btnEdit3.TabIndex = 203;
            this.btnEdit3.Text = "EDIT";
            this.btnEdit3.UseVisualStyleBackColor = true;
            this.btnEdit3.Click += new System.EventHandler(this.btnEdit3_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 437);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 202;
            this.label3.Text = "BODY 3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 415);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 201;
            this.label4.Text = "TITLE 3";
            // 
            // txtTitle3
            // 
            this.txtTitle3.Location = new System.Drawing.Point(78, 412);
            this.txtTitle3.Name = "txtTitle3";
            this.txtTitle3.Size = new System.Drawing.Size(491, 20);
            this.txtTitle3.TabIndex = 200;
            // 
            // txtBody3
            // 
            this.txtBody3.AcceptsTab = true;
            this.txtBody3.BackColor = System.Drawing.SystemColors.Window;
            this.txtBody3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBody3.Location = new System.Drawing.Point(78, 434);
            this.txtBody3.Name = "txtBody3";
            this.txtBody3.ReadOnly = true;
            this.txtBody3.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtBody3.ShowSelectionMargin = true;
            this.txtBody3.Size = new System.Drawing.Size(491, 169);
            this.txtBody3.TabIndex = 199;
            this.txtBody3.Text = "";
            // 
            // btnEdit1
            // 
            this.btnEdit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit1.Image = global::WindowsFormsApplication1.Properties.Resources.Modify;
            this.btnEdit1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit1.Location = new System.Drawing.Point(7, 61);
            this.btnEdit1.Name = "btnEdit1";
            this.btnEdit1.Size = new System.Drawing.Size(68, 23);
            this.btnEdit1.TabIndex = 198;
            this.btnEdit1.Text = "EDIT";
            this.btnEdit1.UseVisualStyleBackColor = true;
            this.btnEdit1.Click += new System.EventHandler(this.btnEdit1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 197;
            this.label2.Text = "BODY 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 196;
            this.label1.Text = "TITLE 1";
            // 
            // txtTitle1
            // 
            this.txtTitle1.Location = new System.Drawing.Point(78, 20);
            this.txtTitle1.Name = "txtTitle1";
            this.txtTitle1.Size = new System.Drawing.Size(491, 20);
            this.txtTitle1.TabIndex = 195;
            // 
            // txtBody1
            // 
            this.txtBody1.AcceptsTab = true;
            this.txtBody1.BackColor = System.Drawing.SystemColors.Window;
            this.txtBody1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBody1.Location = new System.Drawing.Point(78, 42);
            this.txtBody1.Name = "txtBody1";
            this.txtBody1.ReadOnly = true;
            this.txtBody1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtBody1.ShowSelectionMargin = true;
            this.txtBody1.Size = new System.Drawing.Size(491, 169);
            this.txtBody1.TabIndex = 194;
            this.txtBody1.Text = "";
            // 
            // optText
            // 
            this.optText.Appearance = System.Windows.Forms.Appearance.Button;
            this.optText.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optText.Checked = true;
            this.optText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optText.Location = new System.Drawing.Point(413, 68);
            this.optText.Name = "optText";
            this.optText.Size = new System.Drawing.Size(181, 24);
            this.optText.TabIndex = 200;
            this.optText.TabStop = true;
            this.optText.Text = "USE TEXT PREAMBLE";
            this.optText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optText.UseVisualStyleBackColor = true;
            this.optText.CheckedChanged += new System.EventHandler(this.optText_CheckedChanged);
            // 
            // grpPDF
            // 
            this.grpPDF.Controls.Add(this.axAcroPDF1);
            this.grpPDF.Controls.Add(this.btnPDF);
            this.grpPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPDF.Location = new System.Drawing.Point(598, 97);
            this.grpPDF.Name = "grpPDF";
            this.grpPDF.Size = new System.Drawing.Size(422, 615);
            this.grpPDF.TabIndex = 201;
            this.grpPDF.TabStop = false;
            this.grpPDF.Text = "EXTERNAL PDF";
            // 
            // lblPDFPath
            // 
            this.lblPDFPath.AutoSize = true;
            this.lblPDFPath.Location = new System.Drawing.Point(783, 73);
            this.lblPDFPath.Name = "lblPDFPath";
            this.lblPDFPath.Size = new System.Drawing.Size(0, 13);
            this.lblPDFPath.TabIndex = 200;
            // 
            // btnPDF
            // 
            this.btnPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDF.Image = global::WindowsFormsApplication1.Properties.Resources.Modify;
            this.btnPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPDF.Location = new System.Drawing.Point(6, 19);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(410, 23);
            this.btnPDF.TabIndex = 199;
            this.btnPDF.Text = "SELECT EXTERNAL PDF FILE...";
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click_1);
            // 
            // optPDF
            // 
            this.optPDF.Appearance = System.Windows.Forms.Appearance.Button;
            this.optPDF.AutoSize = true;
            this.optPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optPDF.Location = new System.Drawing.Point(598, 68);
            this.optPDF.Name = "optPDF";
            this.optPDF.Size = new System.Drawing.Size(181, 23);
            this.optPDF.TabIndex = 202;
            this.optPDF.Text = "USE EXTERNAL PREAMBLE";
            this.optPDF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optPDF.UseVisualStyleBackColor = true;
            this.optPDF.CheckedChanged += new System.EventHandler(this.optPDF_CheckedChanged);
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(6, 45);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(410, 561);
            this.axAcroPDF1.TabIndex = 201;
            // 
            // frmBuildPreamble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1339, 718);
            this.Controls.Add(this.optPDF);
            this.Controls.Add(this.lblPDFPath);
            this.Controls.Add(this.grpPDF);
            this.Controls.Add(this.optText);
            this.Controls.Add(this.grpText);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cboSelect);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label79);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmBuildPreamble";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PREAMBLE BUILDER";
            this.Load += new System.EventHandler(this.frmBuildPreamble_Load);
            this.groupBox1.ResumeLayout(false);
            this.grpText.ResumeLayout(false);
            this.grpText.PerformLayout();
            this.grpPDF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboSelect;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.GroupBox grpText;
        private System.Windows.Forms.Button btnEdit2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTitle2;
        private System.Windows.Forms.RichTextBox txtBody2;
        private System.Windows.Forms.Button btnEdit3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTitle3;
        private System.Windows.Forms.RichTextBox txtBody3;
        private System.Windows.Forms.Button btnEdit1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle1;
        private System.Windows.Forms.RichTextBox txtBody1;
        private System.Windows.Forms.RadioButton optText;
        private System.Windows.Forms.GroupBox grpPDF;
        private System.Windows.Forms.Label lblPDFPath;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.RadioButton optPDF;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
    }
}