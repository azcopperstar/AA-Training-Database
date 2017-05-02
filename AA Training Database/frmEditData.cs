using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    public partial class frmEditData : Form {
        public frmEditData() {
            InitializeComponent();
        }

        private OleDbConnection conn;
        DataSet ds = new DataSet();
        private BindingSource bindingSource1;
        private OleDbDataAdapter dataAdapter;
        DataTable dtTable;

        private void frmEditData_Load(object sender, EventArgs e) {

            conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
            bindingSource1 = new BindingSource();
            dataGridView1.DataSource = bindingSource1;

            FillData("SELECT * FROM Maneuvers");
            Fill_Controls();
        }

        private void FillData(string selectCommand) {

            conn.Open();

            dataGridView1.AutoGenerateColumns = true;

            //dataAdapter = new SQLiteDataAdapter(selectCommand, connString);
            dataAdapter = new OleDbDataAdapter(selectCommand, GlobalCode.sOleDbConnectionString);

            DataSet ds = new DataSet();
            dtTable = new DataTable();
            dtTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(dtTable);
            dataAdapter.Fill(ds);
            OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dataAdapter);

            bindingSource1.DataSource = dtTable;

            // Resize the DataGridView columns to fit the newly loaded content.
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (dataGridView1.RowCount > 0)
                dataGridView1.Rows[0].Selected = true;

            conn.Close();
        }
        private void Fill_Controls() {
            // connect each control to the bindingsource
            cboATA.DataBindings.Add("text", bindingSource1, "ATA_CODE");
            cboSOP.DataBindings.Add("text", bindingSource1, "SOP_PHASE");
            //chkSeatSpec.DataBindings.Add("checked", bindingSource1, "seat_specific");
            txtManeuver.DataBindings.Add("text", bindingSource1, "MANEUVER");
            txtMinutes.DataBindings.Add("text", bindingSource1, "MINUTES");

            txtObjective1.DataBindings.Add("text", bindingSource1, "OBJECTIVE1");
            txtObjective2.DataBindings.Add("text", bindingSource1, "OBJECTIVE2");

            txtScope1.DataBindings.Add("text", bindingSource1, "SCOPE1");
            txtScope2.DataBindings.Add("text", bindingSource1, "SCOPE2");

            txtSimPosition.DataBindings.Add("text", bindingSource1, "SIM_POSITION");

            txtSimSetup1.DataBindings.Add("text", bindingSource1, "SIM_SETUP1");
            txtSimSetup2.DataBindings.Add("text", bindingSource1, "SIM_SETUP2");
            txtSimSetup3.DataBindings.Add("text", bindingSource1, "SIM_SETUP3");
            txtSimSetup4.DataBindings.Add("text", bindingSource1, "SIM_SETUP4");

            txtNotes1.DataBindings.Add("text", bindingSource1, "NOTES_1");
            txtNotes2.DataBindings.Add("text", bindingSource1, "NOTES_2");
            txtNotes3.DataBindings.Add("text", bindingSource1, "NOTES_3");
            txtNotes4.DataBindings.Add("text", bindingSource1, "NOTES_4");

            txtZFW.DataBindings.Add("text", bindingSource1, "ZFW");
            txtZFWCG.DataBindings.Add("text", bindingSource1, "ZFWCG");

            txtGTOW.DataBindings.Add("text", bindingSource1, "GTOW");
            txtTOWCG.DataBindings.Add("text", bindingSource1, "TOWCG");

            txtFlaps.DataBindings.Add("text", bindingSource1, "FLAPS");
            txtCI.DataBindings.Add("text", bindingSource1, "CI");
            txtThrust.DataBindings.Add("text", bindingSource1, "THRUST");

            txtV1.DataBindings.Add("text", bindingSource1, "V1");
            txtV2.DataBindings.Add("text", bindingSource1, "V2");
            txtVR.DataBindings.Add("text", bindingSource1, "VR");

            txtFuel.DataBindings.Add("text", bindingSource1, "FUEL");
            txtReserve.DataBindings.Add("text", bindingSource1, "RESERVE");

            txtStab.DataBindings.Add("text", bindingSource1, "STAB");
            txtPax.DataBindings.Add("text", bindingSource1, "PAX");
            txtCrzAlt.DataBindings.Add("text", bindingSource1, "CRZALT");

            txtThrRedAlt.DataBindings.Add("text", bindingSource1, "THRUST_RED_ALT");
            txtAccelAlt.DataBindings.Add("text", bindingSource1, "ACCEL_ALT");
            txtEoAccelAlt.DataBindings.Add("text", bindingSource1, "EO_ACCEL_ALT");

            cboRCAM.DataBindings.Add("text", bindingSource1, "RUNWAY_COND");

            txtWind.DataBindings.Add("text", bindingSource1, "WIND");
            txtCeiling.DataBindings.Add("text", bindingSource1, "CEILING");
            txtVis.DataBindings.Add("text", bindingSource1, "VISIBILITY");
            txtTemp.DataBindings.Add("text", bindingSource1, "TEMP");
            txtQNH.DataBindings.Add("text", bindingSource1, "QNH");

            txtAtis.DataBindings.Add("text", bindingSource1, "ATIS");
            txtClearance.DataBindings.Add("text", bindingSource1, "CLEARANCE");

            cboPF1.DataBindings.Add("text", bindingSource1, "PF1");
            txtActionTitle1.DataBindings.Add("text", bindingSource1, "ACTIONTITLE1");
            txtActions1.DataBindings.Add("text", bindingSource1, "ACTIONS1");
            txtComm1.DataBindings.Add("text", bindingSource1, "COMM1");

            cboPF2.DataBindings.Add("text", bindingSource1, "PF2");
            txtActionTitle2.DataBindings.Add("text", bindingSource1, "ACTIONTITLE2");
            txtActions2.DataBindings.Add("text", bindingSource1, "ACTIONS2");
            txtComm2.DataBindings.Add("text", bindingSource1, "COMM2");

            cboPF3.DataBindings.Add("text", bindingSource1, "PF3");
            txtActionTitle3.DataBindings.Add("text", bindingSource1, "ACTIONTITLE3");
            txtActions3.DataBindings.Add("text", bindingSource1, "ACTIONS3");
            txtComm3.DataBindings.Add("text", bindingSource1, "COMM3");

            cboPF4.DataBindings.Add("text", bindingSource1, "PF4");
            txtActionTitle4.DataBindings.Add("text", bindingSource1, "ACTIONTITLE4");
            txtActions4.DataBindings.Add("text", bindingSource1, "ACTIONS4");
            txtComm4.DataBindings.Add("text", bindingSource1, "COMM4");

            cboPF5.DataBindings.Add("text", bindingSource1, "PF5");
            txtActionTitle5.DataBindings.Add("text", bindingSource1, "ACTIONTITLE5");
            txtActions5.DataBindings.Add("text", bindingSource1, "ACTIONS5");
            txtComm5.DataBindings.Add("text", bindingSource1, "COMM5");

            cboPF6.DataBindings.Add("text", bindingSource1, "PF6");
            txtActionTitle6.DataBindings.Add("text", bindingSource1, "ACTIONTITLE6");
            txtActions6.DataBindings.Add("text", bindingSource1, "ACTIONS6");
            txtComm6.DataBindings.Add("text", bindingSource1, "COMM6");

            cboPF7.DataBindings.Add("text", bindingSource1, "PF7");
            txtActionTitle7.DataBindings.Add("text", bindingSource1, "ACTIONTITLE7");
            txtActions7.DataBindings.Add("text", bindingSource1, "ACTIONS7");
            txtComm7.DataBindings.Add("text", bindingSource1, "COMM7");

            cboPF8.DataBindings.Add("text", bindingSource1, "PF8");
            txtActionTitle8.DataBindings.Add("text", bindingSource1, "ACTIONTITLE8");
            txtActions8.DataBindings.Add("text", bindingSource1, "ACTIONS8");
            txtComm8.DataBindings.Add("text", bindingSource1, "COMM8");

        }

        private void btnSave_Click(object sender, EventArgs e) {
            // Update the database with the user's changes.
            bindingSource1.EndEdit();
            dataAdapter.Update((DataTable)bindingSource1.DataSource);
            FillData("select * from Maneuvers");
        }
        private void btnDelete_Click(object sender, EventArgs e) {
            Delete_Maneuver();
        }
        private void btnDelete_Click_1(object sender, EventArgs e) {
            Delete_Maneuver();
        }
        private void Delete_Maneuver() {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            int nRow = dataGridView1.CurrentCell.RowIndex;
            DialogResult result = MessageBox.Show(
                "Deleting the selected maneuver will permantly eliminate it from the database.  Are you sure that you would like to DELETE?",
                "DELETE SELECTED RECORD?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes) {
                dataGridView1.Rows.Remove(row);
                dataAdapter.Update((DataTable)bindingSource1.DataSource);
                FillData("select * from Maneuvers");
                dataGridView1.Rows[nRow - 1].Selected = true;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e) {
            // Update the database with the user's changes.
            //bindingSource1.EndEdit();
            AddDataRow();

            //dataAdapter.Update((DataTable)bindingSource1.DataSource);
            //FillData("select * from a320_sim");
        }
        
        private void AddDataRow() {
            System.Data.DataRow dr = dtTable.NewRow();

            dr["SPOT"] = "";
            dr["ATA_CODE"] = cboATA.Text;
            dr["SOP_PHASE"] = cboSOP.Text;
            dr["MANEUVER"] = txtManeuver.Text;
            dr["SEAT_SPECIFIC"] = "";
            dr["MINUTES"] = txtMinutes.Value;
            dr["OBJECTIVE1"] = txtObjective1.Text;
            dr["OBJECTIVE2"] = txtObjective2.Text;
            dr["SCOPE1"] = txtScope1.Text;
            dr["SCOPE2"] = txtScope2.Text;

            dr["SIM_POSITION"] = txtSimPosition.Text;
            dr["SIM_SETUP1"] = txtSimSetup1.Text;
            dr["SIM_SETUP2"] = txtSimSetup2.Text;
            dr["SIM_SETUP3"] = txtSimSetup3.Text;
            dr["SIM_SETUP4"] = txtSimSetup4.Text;

            dr["GTOW"] = txtGTOW.Text;
            dr["TOWCG"] = txtTOWCG.Text;
            dr["FLAPS"] = txtFlaps.Text;
            dr["CI"] = txtCI.Text;
            dr["ZFW"] = txtZFW.Text;
            dr["ZFWCG"] = txtZFWCG.Text;
            dr["V1"] = txtV1.Text;
            dr["V2"] = txtV2.Text;
            dr["VR"] = txtVR.Text;
            dr["THRUST"] = txtThrust.Text;
            dr["FUEL"] = txtFuel.Text;
            dr["RESERVE"] = txtReserve.Text;
            dr["STAB"] = txtStab.Text;
            dr["PAX"] = txtPax.Text;
            dr["CRZALT"] = txtCrzAlt.Text;
            dr["THRUST_RED_ALT"] = txtThrRedAlt.Text;
            dr["ACCEL_ALT"] = txtAccelAlt.Text;
            dr["EO_ACCEL_ALT"] = txtEoAccelAlt.Text;
            dr["RUNWAY_COND"] = cboRCAM.Text;

            dr["WIND"] = txtWind.Text;
            dr["CEILING"] = txtCeiling.Text;
            dr["VISIBILITY"] = txtVis.Text;
            dr["TEMP"] = txtTemp.Text;
            dr["QNH"] = txtQNH.Text;
            dr["ATIS"] = txtAtis.Text;
            dr["CLEARANCE"] = txtClearance.Text;

            //  SETUP_2,3,4
            dr["SETUP_2"] = "";
            dr["SETUP_3"] = "";
            dr["SETUP_4"] = "";

            dr["NOTES_1"] = txtNotes1.Text;
            dr["NOTES_2"] = txtNotes2.Text;
            dr["NOTES_3"] = txtNotes3.Text;
            dr["NOTES_4"] = txtNotes4.Text;
            dr["NOTES_5"] = "";

            dr["PF1"] = cboPF1.Text;
            dr["ACTIONTITLE1"] = txtActionTitle1.Text;
            dr["ACTIONS1"] = txtActions1.Text;
            dr["COMM1"] = txtComm1.Text;

            dr["PF2"] = cboPF2.Text;
            dr["ACTIONTITLE2"] = txtActionTitle2.Text;
            dr["ACTIONS2"] = txtActions2.Text;
            dr["COMM2"] = txtComm2.Text;

            dr["PF3"] = cboPF3.Text;
            dr["ACTIONTITLE3"] = txtActionTitle3.Text;
            dr["ACTIONS3"] = txtActions3.Text;
            dr["COMM3"] = txtComm3.Text;

            dr["PF4"] = cboPF4.Text;
            dr["ACTIONTITLE4"] = txtActionTitle4.Text;
            dr["ACTIONS4"] = txtActions4.Text;
            dr["COMM4"] = txtComm4.Text;

            dr["PF5"] = cboPF5.Text;
            dr["ACTIONTITLE5"] = txtActionTitle5.Text;
            dr["ACTIONS5"] = txtActions5.Text;
            dr["COMM5"] = txtComm5.Text;

            dr["PF6"] = cboPF6.Text;
            dr["ACTIONTITLE6"] = txtActionTitle6.Text;
            dr["ACTIONS6"] = txtActions6.Text;
            dr["COMM6"] = txtComm6.Text;

            dr["PF7"] = cboPF7.Text;
            dr["ACTIONTITLE7"] = txtActionTitle7.Text;
            dr["ACTIONS7"] = txtActions7.Text;
            dr["COMM7"] = txtComm7.Text;

            dr["PF8"] = cboPF8.Text;
            dr["ACTIONTITLE8"] = txtActionTitle8.Text;
            dr["ACTIONS8"] = txtActions8.Text;
            dr["COMM8"] = txtComm8.Text;

            dr["PF9"] = "";
            dr["ACTIONTITLE9"] = "";
            dr["ACTIONS9"] = "";
            dr["COMM9"] = "";

            dr["PF10"] = "";
            dr["ACTIONTITLE10"] = "";
            dr["ACTIONS10"] = "";
            dr["COMM10"] = "";

            dr["FOOTER_TEXT"] = "";

            dtTable.Rows.Add(dr);
            dataAdapter.Update(dtTable);  // write new row back to database
            FillData("select * from maneuvers");
        }

        private void btnClearData_Click(object sender, EventArgs e) {
            // clear all controls
            cboATA.Text="";
            cboSOP.Text = "";
            //chkSeatSpec.DataBindings.Add("checked", bindingSource1, "seat_specific");
            txtManeuver.Text = "";
            txtMinutes.Value = 5;

            txtObjective1.Text = "";
            txtObjective2.Text = "";

            txtScope1.Text = "";
            txtScope2.Text = "";

            txtSimPosition.Text = "";

            txtSimSetup1.Text = "";
            txtSimSetup2.Text = "";
            txtSimSetup3.Text = "";
            txtSimSetup4.Text = "";

            txtNotes1.Text = "";
            txtNotes2.Text = "";
            txtNotes3.Text = "";
            txtNotes4.Text = "";

            txtZFW.Text = "";
            txtZFWCG.Text = "";

            txtGTOW.Text = "";
            txtTOWCG.Text = "";

            txtFlaps.Text = "";
            txtCI.Text = "";
            txtThrust.Text = "";

            txtV1.Text = "";
            txtV2.Text = "";
            txtVR.Text = "";

            txtFuel.Text = "";
            txtReserve.Text = "";

            txtStab.Text = "";
            txtPax.Text = "";
            txtCrzAlt.Text = "";

            txtThrRedAlt.Text = "";
            txtAccelAlt.Text = "";
            txtEoAccelAlt.Text = "";

            cboRCAM.Text = "";

            txtWind.Text = "";
            txtCeiling.Text = "";
            txtVis.Text = "";
            txtTemp.Text = "";
            txtQNH.Text = "";

            txtAtis.Text = "";
            txtClearance.Text = "";

            cboPF1.Text = "";
            txtActionTitle1.Text = "";
            txtActions1.Text = "";
            txtComm1.Text = "";

            cboPF2.Text = "";
            txtActionTitle2.Text = "";
            txtActions2.Text = "";
            txtComm2.Text = "";

            cboPF3.Text = "";
            txtActionTitle3.Text = "";
            txtActions3.Text = "";
            txtComm3.Text = "";

            cboPF4.Text = "";
            txtActionTitle4.Text = "";
            txtActions4.Text = "";
            txtComm4.Text = "";

            cboPF5.Text = "";
            txtActionTitle5.Text = "";
            txtActions5.Text = "";
            txtComm5.Text = "";

            cboPF6.Text = "";
            txtActionTitle6.Text = "";
            txtActions6.Text = "";
            txtComm6.Text = "";

            cboPF7.Text = "";
            txtActionTitle7.Text = "";
            txtActions7.Text = "";
            txtComm7.Text = "";

            cboPF8.Text = "";
            txtActionTitle8.Text = "";
            txtActions8.Text = "";
            txtComm8.Text = "";

        }



        // new shit

    }
}
