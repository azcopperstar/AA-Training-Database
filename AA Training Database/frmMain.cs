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
    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();

            GlobalCode.sDataFile = "V:\\AA- Traing Script Developer Project\\TSD_A350.accdb";
            GlobalCode.sOleDbConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + GlobalCode.sDataFile;

        }

        private void btnEditSimData_Click(object sender, EventArgs e) {
            frmBuilderLesson frmDeveloper = new frmBuilderLesson();
            frmDeveloper.Show();
        }

        private void btnCreateSimReport_Click(object sender, EventArgs e) {
            frmReportViewer frmReport = new frmReportViewer();
            frmReport.Show();
        }

        private void btnDeveloper_Click(object sender, EventArgs e) {
            //frmDeveloper frmDeveloper = new frmDeveloper();
            //frmDeveloper.Show();
            frmBuilderSpot frmEditScript = new frmBuilderSpot();
            frmEditScript.Show();
        }

        private void btnConditions_Wx_Click(object sender, EventArgs e) {
            frmEditWxConditions frmEditWxConditions = new frmEditWxConditions();
            frmEditWxConditions.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e) {
            frmEditACConditions frmEditACConditions = new frmEditACConditions();
            frmEditACConditions.ShowDialog();
        }

        private void btnATIS_Click(object sender, EventArgs e) {
            frmEditATIS frmEditATIS = new frmEditATIS();
            frmEditATIS.ShowDialog();
        }

        private void btnClearance_Click(object sender, EventArgs e) {
            frmEditClearance frmEditClearance = new frmEditClearance();
            frmEditClearance.ShowDialog();
        }

        private void btnActions_Click(object sender, EventArgs e) {
            frmEditAction frmEditAction = new frmEditAction();
            frmEditAction.ShowDialog();
        }

        private void btnManeuver_Click(object sender, EventArgs e) {
            frmEditManeuver frmEditManeuver = new frmEditManeuver();
            frmEditManeuver.ShowDialog();
        }
    }
}
