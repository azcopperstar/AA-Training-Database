namespace WindowsFormsApplication1 {
    partial class frmRTFEditor {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRTFEditor));
            this.txtRTF = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBullet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPicture = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveChangesAndReturnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discardChangesAndCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBulletsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeBulletsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRTF
            // 
            this.txtRTF.AcceptsTab = true;
            this.txtRTF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRTF.AutoWordSelection = true;
            this.txtRTF.BulletIndent = 2;
            this.txtRTF.EnableAutoDragDrop = true;
            this.txtRTF.Location = new System.Drawing.Point(0, 47);
            this.txtRTF.Name = "txtRTF";
            this.txtRTF.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtRTF.ShowSelectionMargin = true;
            this.txtRTF.Size = new System.Drawing.Size(712, 556);
            this.txtRTF.TabIndex = 184;
            this.txtRTF.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnClose,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator2,
            this.btnBullet,
            this.toolStripSeparator3,
            this.btnPicture});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(720, 25);
            this.toolStrip1.TabIndex = 185;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::WindowsFormsApplication1.Properties.Resources.Accept;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Save changes and close";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClose.Image = global::WindowsFormsApplication1.Properties.Resources.Bad_mark;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 22);
            this.btnClose.Text = "toolStripButton2";
            this.btnClose.ToolTipText = "Close editor without saving changes";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.CheckOnClick = true;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::WindowsFormsApplication1.Properties.Resources.Bold_16x;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Bold";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.CheckOnClick = true;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::WindowsFormsApplication1.Properties.Resources.Italic_16x;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "Italics";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.CheckOnClick = true;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::WindowsFormsApplication1.Properties.Resources.Underline_16x;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "Underline";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnBullet
            // 
            this.btnBullet.CheckOnClick = true;
            this.btnBullet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBullet.Image = ((System.Drawing.Image)(resources.GetObject("btnBullet.Image")));
            this.btnBullet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBullet.Name = "btnBullet";
            this.btnBullet.Size = new System.Drawing.Size(23, 22);
            this.btnBullet.Text = "Add/Remove Bullet";
            this.btnBullet.Click += new System.EventHandler(this.btnBullet_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPicture
            // 
            this.btnPicture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPicture.Image = ((System.Drawing.Image)(resources.GetObject("btnPicture.Image")));
            this.btnPicture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.Size = new System.Drawing.Size(23, 22);
            this.btnPicture.Text = "toolStripButton2";
            this.btnPicture.Click += new System.EventHandler(this.btnPicture_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.bulletToolStripMenuItem,
            this.fontToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(720, 24);
            this.menuStrip1.TabIndex = 187;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveChangesAndReturnToolStripMenuItem,
            this.discardChangesAndCloseToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // saveChangesAndReturnToolStripMenuItem
            // 
            this.saveChangesAndReturnToolStripMenuItem.Name = "saveChangesAndReturnToolStripMenuItem";
            this.saveChangesAndReturnToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.saveChangesAndReturnToolStripMenuItem.Text = "Save Changes and Return";
            // 
            // discardChangesAndCloseToolStripMenuItem
            // 
            this.discardChangesAndCloseToolStripMenuItem.Name = "discardChangesAndCloseToolStripMenuItem";
            this.discardChangesAndCloseToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.discardChangesAndCloseToolStripMenuItem.Text = "Discard Changes and Close";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // bulletToolStripMenuItem
            // 
            this.bulletToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBulletsToolStripMenuItem,
            this.removeBulletsToolStripMenuItem});
            this.bulletToolStripMenuItem.Name = "bulletToolStripMenuItem";
            this.bulletToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.bulletToolStripMenuItem.Text = "Bullet";
            // 
            // addBulletsToolStripMenuItem
            // 
            this.addBulletsToolStripMenuItem.Name = "addBulletsToolStripMenuItem";
            this.addBulletsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.addBulletsToolStripMenuItem.Text = "Add Bullets";
            this.addBulletsToolStripMenuItem.Click += new System.EventHandler(this.addBulletsToolStripMenuItem_Click);
            // 
            // removeBulletsToolStripMenuItem
            // 
            this.removeBulletsToolStripMenuItem.Name = "removeBulletsToolStripMenuItem";
            this.removeBulletsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.removeBulletsToolStripMenuItem.Text = "Remove Bullets";
            this.removeBulletsToolStripMenuItem.Click += new System.EventHandler(this.removeBulletsToolStripMenuItem_Click);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.fontToolStripMenuItem.Text = "Font";
            // 
            // frmRTFEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 603);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtRTF);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmRTFEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RTF EDITOR";
            this.Load += new System.EventHandler(this.frmRTFEditor_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtRTF;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveChangesAndReturnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discardChangesAndCloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bulletToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBulletsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeBulletsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnBullet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnPicture;
    }
}