using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    public partial class frmRTFEditor : Form {
        public frmRTFEditor() {
            InitializeComponent();

        }

        string sSender;
        private frmBuildPreamble frmBuildPreamble = null;

        public frmRTFEditor(Form callingForm, string sSend) {
            frmBuildPreamble = callingForm as frmBuildPreamble;
            sSender = sSend;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (sSender == "Preamble.txtBody1") {
                this.frmBuildPreamble.Body1Text = txtRTF.Rtf;
            } else if (sSender == "Preamble.txtBody2") {
                this.frmBuildPreamble.Body2Text = txtRTF.Rtf;
            } else if (sSender == "Preamble.txtBody3") {
                this.frmBuildPreamble.Body3Text = txtRTF.Rtf;
            }

            this.Close();
        }

        private void frmRTFEditor_Load(object sender, EventArgs e) {
            if (sSender == "Preamble.txtBody1") {
                txtRTF.Rtf = this.frmBuildPreamble.Body1Text;
            } else if (sSender == "Preamble.txtBody2") {
                txtRTF.Rtf = this.frmBuildPreamble.Body2Text;
            } else if (sSender == "Preamble.txtBody3") {
                txtRTF.Rtf = this.frmBuildPreamble.Body3Text;
            }

        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {

        }
        private void BoldToolStripMenuItem_Click(object sender, System.EventArgs e) {
            try {
                if (!(txtRTF.SelectionFont == null)) {
                    System.Drawing.Font currentFont = txtRTF.SelectionFont;
                    System.Drawing.FontStyle newFontStyle;

                    newFontStyle = txtRTF.SelectionFont.Style ^ FontStyle.Bold;

                    txtRTF.SelectionFont = new Font(currentFont.FontFamily,currentFont.Size, newFontStyle);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void Bullets_Add() {
            try {
                txtRTF.BulletIndent = 10;
                txtRTF.SelectionBullet = true;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
        private void Bullets_Remove() {
            try {
                txtRTF.SelectionBullet = false;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void addBulletsToolStripMenuItem_Click(object sender, EventArgs e) {
            Bullets_Add();
        }

        private void removeBulletsToolStripMenuItem_Click(object sender, EventArgs e) {
            Bullets_Remove();
        }

        private void btnBullet_Click(object sender, EventArgs e) {
            if (btnBullet.Checked) {
                Bullets_Add();
            } else {
                Bullets_Remove();
            }
        }
        private void InsertImage() {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Title = "RTE - Insert Image File";
            OpenFileDialog1.DefaultExt = "rtf";
            OpenFileDialog1.Filter = "Bitmap Files|*.bmp|JPEG Files|*.jpg|GIF Files | *.gif|PNG Files | *.png";
            OpenFileDialog1.FilterIndex = 1;
            OpenFileDialog1.ShowDialog();

            if (OpenFileDialog1.FileName == "") {
                return;
            }

            try {
                string strImagePath = OpenFileDialog1.FileName;
                Image img;
                img = Image.FromFile(strImagePath);
                Clipboard.SetDataObject(img);
                DataFormats.Format df;
                df = DataFormats.GetFormat(DataFormats.Bitmap);
                if (this.txtRTF.CanPaste(df)) {
                    this.txtRTF.Paste(df);
                }
            } catch {
                MessageBox.Show("Unable to insert image format selected.",
                    "RTE - Paste", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnPicture_Click(object sender, EventArgs e) {
            InsertImage();
        }
    }
}
