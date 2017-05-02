namespace WindowsFormsApplication1 {
    partial class frmMain {
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
            this.btnEditSimData = new System.Windows.Forms.Button();
            this.btnDeveloper = new System.Windows.Forms.Button();
            this.btnConditions_Wx = new System.Windows.Forms.Button();
            this.btnConditionsAc = new System.Windows.Forms.Button();
            this.btnATIS = new System.Windows.Forms.Button();
            this.btnClearance = new System.Windows.Forms.Button();
            this.btnActions = new System.Windows.Forms.Button();
            this.btnManeuver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEditSimData
            // 
            this.btnEditSimData.Location = new System.Drawing.Point(23, 92);
            this.btnEditSimData.Name = "btnEditSimData";
            this.btnEditSimData.Size = new System.Drawing.Size(209, 23);
            this.btnEditSimData.TabIndex = 0;
            this.btnEditSimData.Text = "Test Script Builder";
            this.btnEditSimData.UseVisualStyleBackColor = true;
            this.btnEditSimData.Click += new System.EventHandler(this.btnEditSimData_Click);
            // 
            // btnDeveloper
            // 
            this.btnDeveloper.Location = new System.Drawing.Point(23, 150);
            this.btnDeveloper.Name = "btnDeveloper";
            this.btnDeveloper.Size = new System.Drawing.Size(209, 23);
            this.btnDeveloper.TabIndex = 2;
            this.btnDeveloper.Text = "Develop Curriculum Scripts";
            this.btnDeveloper.UseVisualStyleBackColor = true;
            this.btnDeveloper.Click += new System.EventHandler(this.btnDeveloper_Click);
            // 
            // btnConditions_Wx
            // 
            this.btnConditions_Wx.Location = new System.Drawing.Point(232, 284);
            this.btnConditions_Wx.Name = "btnConditions_Wx";
            this.btnConditions_Wx.Size = new System.Drawing.Size(209, 23);
            this.btnConditions_Wx.TabIndex = 3;
            this.btnConditions_Wx.Text = "Edit Weather Conditions";
            this.btnConditions_Wx.UseVisualStyleBackColor = true;
            this.btnConditions_Wx.Click += new System.EventHandler(this.btnConditions_Wx_Click);
            // 
            // btnConditionsAc
            // 
            this.btnConditionsAc.Location = new System.Drawing.Point(232, 313);
            this.btnConditionsAc.Name = "btnConditionsAc";
            this.btnConditionsAc.Size = new System.Drawing.Size(209, 23);
            this.btnConditionsAc.TabIndex = 4;
            this.btnConditionsAc.Text = "Edit Aircraft Conditions";
            this.btnConditionsAc.UseVisualStyleBackColor = true;
            this.btnConditionsAc.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnATIS
            // 
            this.btnATIS.Location = new System.Drawing.Point(232, 342);
            this.btnATIS.Name = "btnATIS";
            this.btnATIS.Size = new System.Drawing.Size(209, 23);
            this.btnATIS.TabIndex = 5;
            this.btnATIS.Text = "Edit ATIS";
            this.btnATIS.UseVisualStyleBackColor = true;
            this.btnATIS.Click += new System.EventHandler(this.btnATIS_Click);
            // 
            // btnClearance
            // 
            this.btnClearance.Location = new System.Drawing.Point(232, 371);
            this.btnClearance.Name = "btnClearance";
            this.btnClearance.Size = new System.Drawing.Size(209, 23);
            this.btnClearance.TabIndex = 6;
            this.btnClearance.Text = "Edit Clearances";
            this.btnClearance.UseVisualStyleBackColor = true;
            this.btnClearance.Click += new System.EventHandler(this.btnClearance_Click);
            // 
            // btnActions
            // 
            this.btnActions.Location = new System.Drawing.Point(232, 255);
            this.btnActions.Name = "btnActions";
            this.btnActions.Size = new System.Drawing.Size(209, 23);
            this.btnActions.TabIndex = 7;
            this.btnActions.Text = "Edit Actions";
            this.btnActions.UseVisualStyleBackColor = true;
            this.btnActions.Click += new System.EventHandler(this.btnActions_Click);
            // 
            // btnManeuver
            // 
            this.btnManeuver.Location = new System.Drawing.Point(232, 226);
            this.btnManeuver.Name = "btnManeuver";
            this.btnManeuver.Size = new System.Drawing.Size(209, 23);
            this.btnManeuver.TabIndex = 8;
            this.btnManeuver.Text = "Edit Maneuvers";
            this.btnManeuver.UseVisualStyleBackColor = true;
            this.btnManeuver.Click += new System.EventHandler(this.btnManeuver_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 446);
            this.Controls.Add(this.btnManeuver);
            this.Controls.Add(this.btnActions);
            this.Controls.Add(this.btnClearance);
            this.Controls.Add(this.btnATIS);
            this.Controls.Add(this.btnConditionsAc);
            this.Controls.Add(this.btnConditions_Wx);
            this.Controls.Add(this.btnDeveloper);
            this.Controls.Add(this.btnEditSimData);
            this.Name = "frmMain";
            this.Text = "AA Training Curiculum Management";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEditSimData;
        private System.Windows.Forms.Button btnDeveloper;
        private System.Windows.Forms.Button btnConditions_Wx;
        private System.Windows.Forms.Button btnConditionsAc;
        private System.Windows.Forms.Button btnATIS;
        private System.Windows.Forms.Button btnClearance;
        private System.Windows.Forms.Button btnActions;
        private System.Windows.Forms.Button btnManeuver;
    }
}