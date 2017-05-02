using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    public partial class frmPDF : Form {
        public frmPDF(string sPDFFile) {
            InitializeComponent();
            Load_PDF_Viewer(@sPDFFile);
            lblTBFleet.Text = "FLEET: " + GlobalCode.sFleet;
            lblTBOutputPath.Text = GlobalCode.sPATH_PDF + "\\" + GlobalCode.sFILE_PDF + ".pdf";

        }

        private void frmPDF_Load(object sender, EventArgs e) {
            this.Text = GlobalCode.sCARRIER + " " + GlobalCode.sFleet + this.Text;
        }

        private void Load_PDF_Viewer(string pdfDoc) {
            if (File.Exists(pdfDoc)) {
                axAcroPDF1.src = pdfDoc;
                axAcroPDF1.setView("Fit");
                axAcroPDF1.setPageMode("bookmarks");
                axAcroPDF1.setLayoutMode("SinglePage");
                axAcroPDF1.setShowToolbar(true);
            }
        }
    }
}
