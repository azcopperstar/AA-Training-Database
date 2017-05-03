using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1 {
    public partial class frmOptions : Form {
        public frmOptions() {
            InitializeComponent();
        }

        private static OleDbConnection conn;
        private OleDbDataAdapter dataAdapter;
        DataTable dtTable;

        private void frmOptions_Load(object sender, EventArgs e) {
            try {
                Initialize_DB();
                Fill_CBOs(cboFleet, "SELECT ID, TYPE FROM Aircraft ORDER BY [TYPE]");
                FillData();
            } catch (Exception) {
                throw;
            }
        }
        private void Initialize_DB() {
            try {
                string sQuery = "SELECT * FROM Options";
                conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
                dataAdapter = new OleDbDataAdapter(sQuery, GlobalCode.sOleDbConnectionString);
                dtTable = new DataTable();
                dtTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                conn.Open();
                dataAdapter.Fill(dtTable);
                OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dataAdapter);
                conn.Close();
            } catch (Exception) {
                throw;
            }
        }
        private void Fill_CBOs(ComboBox cbo, string query) {
            try {
                string sCommand = query;
                conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
                DataTable dt = new DataTable();
                dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dAdapter.Fill(dt);
                conn.Close();

                // Create a List to store our KeyValuePairs and add data
                List<KeyValuePair<int, string>> data = new List<KeyValuePair<int, string>>();
                data.Add(new KeyValuePair<int, string>(-1, ""));
                for (int i = 0; i <= dt.Rows.Count - 1; i++) {
                    data.Add(new KeyValuePair<int, string>((int)dt.Rows[i].ItemArray[0], (string)dt.Rows[i].ItemArray[1]));
                }
                // Bind the combobox
                cbo.DataSource = null;
                cbo.Items.Clear();
                cbo.DataSource = new BindingSource(data, null);
                cbo.DisplayMember = "Value";
                cbo.ValueMember = "Key";
            } catch (Exception) {
                throw;
            }
        }
        private Int32 Get_Selected_Key(ComboBox cbo) {
            try {
                ComboBox comboBox = (ComboBox)cbo;
                Int32 iKey = -1;
                if (comboBox.SelectedIndex == -1)
                    return iKey;
                KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)comboBox.SelectedItem;
                iKey = selectedPair.Key;
                return iKey;
            } catch (Exception) {
                throw;
            }
        }

        private void FillData() {
            try {
                string sCommand = "SELECT * FROM Options WHERE ID = 1";
                conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
                DataTable dt = new DataTable();
                dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dAdapter.Fill(dt);
                conn.Close();

                cboFleet.Enabled = true;

                if (GlobalCode.bFirstRun) {
                    Clear_Controls();
                } else {
                    // load db options
                    for (int i = 0; i <= dt.Rows.Count - 1; i++) {
                        foreach (KeyValuePair<int, string> row in cboFleet.Items) {
                            if (row.Key == (int)dt.Rows[i]["AIRCRAFT"]) {
                                if ((int)dt.Rows[i]["AIRCRAFT"] > -1) {
                                    cboFleet.SelectedIndex = cboFleet.Items.IndexOf(row);
                                    // if fleet selection found, disable cbo
                                    cboFleet.Enabled = false;
                                }
                            }
                        }

                        if ((string)dt.Rows[i]["PATH_PDF"] != "0") {
                            GlobalCode.sPATH_PDF = (string)dt.Rows[i]["PATH_PDF"];
                        } else {
                            GlobalCode.sPATH_PDF = "";
                        }
                        if ((string)dt.Rows[i]["FILE_PDF"] != "0") {
                            GlobalCode.sFILE_PDF = (string)dt.Rows[i]["FILE_PDF"];
                        } else {
                            GlobalCode.sFILE_PDF = "";
                        }
                        lblPathOutput.Text = GlobalCode.sPATH_PDF;

                        if ((string)dt.Rows[i]["PATH_LOGO"] != "0") {
                            GlobalCode.sPATH_LOGO = (string)dt.Rows[i]["PATH_LOGO"];
                        } else {
                            GlobalCode.sPATH_LOGO = "";
                        }
                        if ((string)dt.Rows[i]["PATH_IMAGE_PDF"] != "0") {
                            GlobalCode.sPATH_IMAGE_PDF = (string)dt.Rows[i]["PATH_IMAGE_PDF"];
                        } else {
                            GlobalCode.sPATH_IMAGE_PDF = "";
                        }
                        GlobalCode.sCARRIER = (string)dt.Rows[i]["CARRIER"];
                    }
                    lblPathImagePdf.Text = GlobalCode.sPATH_IMAGE_PDF;

                    lblPathLogo.Text = GlobalCode.sPATH_LOGO;

                    lblPathData.Text = GlobalCode.sPATH_DATA;

                    lblPathDataOriginal.Text = GlobalCode.sPATH_DATA;

                    lblPathDataBackup.Text = GlobalCode.sPATH_FILE_DATA_BACKUP;

                    lblPathOutput.Text = GlobalCode.sPATH_PDF;

                    txtFilePDF.Text = GlobalCode.sFILE_PDF;

                    txtAirCarrier.Text = GlobalCode.sCARRIER;

                }

                CheckForComplete();

            } catch (Exception) {
                throw;
            }
        }
        private void Clear_Controls() {
            lblPathImagePdf.Text = "";
            btnPathImagePdf.ForeColor = Color.Red;

            lblPathLogo.Text = "";
            btnPathLogo.ForeColor = Color.Red;

            lblPathData.Text = "";
            btnPathData.ForeColor = Color.Red;

            lblPathDataBackup.Text = "";
            btnPathDataBackup.ForeColor = Color.Red;

            lblPathOutput.Text = "";
            btnPathOutput.ForeColor = Color.Red;

            txtFilePDF.Text = "";
            txtAirCarrier.Text = "";

            cboFleet.Text = "";
            cboFleet.Enabled = true;

            btnSave.Enabled = false;

        }
        private void CheckForComplete() {
            try {
                bool bComplete = true;

                if (lblPathImagePdf.Text == "") {
                    bComplete = false;
                    btnPathImagePdf.ForeColor = Color.Red;
                } else {
                    btnPathImagePdf.ForeColor = Color.Black;
                }

                if (lblPathLogo.Text == "") {
                    bComplete = false;
                    btnPathLogo.ForeColor = Color.Red;
                } else {
                    btnPathLogo.ForeColor = Color.Black;
                }

                if (lblPathData.Text == "") {
                    bComplete = false;
                    btnPathData.ForeColor = Color.Red;
                } else {
                    btnPathData.ForeColor = Color.Black;
                }

                if (lblPathDataBackup.Text == "") {
                    bComplete = false;
                    btnPathDataBackup.ForeColor = Color.Red;
                } else {
                    btnPathDataBackup.ForeColor = Color.Black;
                }

                if (lblPathOutput.Text == "") {
                    bComplete = false;
                    btnPathOutput.ForeColor = Color.Red;
                } else {
                    btnPathOutput.ForeColor = Color.Black;
                }

                if (txtAirCarrier.Text == "") {
                    bComplete = false;
                    lblCarrier.ForeColor = Color.Red;
                } else {
                    lblCarrier.ForeColor = Color.Black;
                }

                if (txtFilePDF.Text == "") {
                    bComplete = false;
                    lblOutput.ForeColor = Color.Red;
                } else {
                    lblOutput.ForeColor = Color.Black;
                }

                if (cboFleet.Text == "") {
                    bComplete = false;
                    lblFleet.ForeColor = Color.Red;
                } else {
                    lblFleet.ForeColor = Color.Black;
                }


                if (!bComplete) {
                        btnSave.Enabled = false;
                } else {
                        btnSave.Enabled = true;
                }

            } catch (Exception) {
                throw;
            }
        }

        private void UpdateDataRow() {
            try {

                GlobalCode.sFleet = cboFleet.Text;

                // save setting
                Settings.Default.FLEET = cboFleet.Text;


                string sPathDataOriginal = lblPathDataOriginal.Text;
                string sPathFileDataOriginal = "";

                GlobalCode.sPATH_DATA = lblPathData.Text;
                Settings.Default.PATH_DB = GlobalCode.sPATH_DATA;
                GlobalCode.sPATH_FILE_DATA_BACKUP = lblPathDataBackup.Text;
                Settings.Default.FILE_DB_BACKUP = GlobalCode.sPATH_FILE_DATA_BACKUP;
                GlobalCode.sFILE_DATA = "\\TSD_" + cboFleet.Text + ".accdb";
                Settings.Default.FILE_DB = GlobalCode.sFILE_DATA;
                GlobalCode.sPATH_FILE_DATA = GlobalCode.sPATH_DATA + GlobalCode.sFILE_DATA;

                GlobalCode.sPATH_PDF = lblPathOutput.Text;
                GlobalCode.sFILE_PDF = txtFilePDF.Text;

                GlobalCode.sPATH_IMAGE_PDF = lblPathImagePdf.Text;
                GlobalCode.sPATH_LOGO = lblPathLogo.Text;

                // 1st, test for fleet file in original folder
                sPathFileDataOriginal = sPathDataOriginal + GlobalCode.sFILE_DATA;
                if (!File.Exists(sPathFileDataOriginal)) {
                    // fleet file NOT found in original folder, set to default file and test
                    sPathFileDataOriginal = sPathDataOriginal + "\\TSD_.accdb";
                    if (!File.Exists(sPathFileDataOriginal)) {
                        // default db file not found in original folder, set to 'app\Include' folder
                        sPathFileDataOriginal = GlobalCode.sPATH_APP + "\\Include\\TSD_.accdb";
                        if (!File.Exists(sPathFileDataOriginal)) {
                            // file not found in the Include folder, try app root directory
                            sPathFileDataOriginal = GlobalCode.sPATH_APP + "\\TSD_.accdb";
                        }
                    }
                }
                if (sPathFileDataOriginal != GlobalCode.sPATH_FILE_DATA) {
                    // data path has changed
                    // check for correct data file in the new path
                    if (File.Exists(GlobalCode.sPATH_FILE_DATA)) {
                        // the data file already exists in the selected folder
                        DialogResult result = MessageBox.Show(
                            "A file (" + GlobalCode.sFILE_DATA + ") already exists in the selected folder.  Select 'YES' to use this file." +
                            "\nSelect 'NO' to overwrite this file with the database file from the orginal folder (the original file will be archived).",
                            "DUPLICATE FILE FOUND",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button1);
                        if (result == DialogResult.No) {
                            // overwrite selected, 1st create a backup of the original
                            File.Copy(sPathFileDataOriginal, GlobalCode.sPATH_FILE_DATA + "_archive", true);
                            if (File.Exists(GlobalCode.sPATH_FILE_DATA + "_archive")) {
                                // check that archive file created, then overwrite the original file
                                File.Copy(sPathFileDataOriginal, GlobalCode.sPATH_FILE_DATA, true);
                            }
                        }
                    } else {
                        // the data file does not exist in the selected folder, create a new file from the template
                        File.Copy(sPathFileDataOriginal, GlobalCode.sPATH_FILE_DATA, true);
                    }
                    // update connection string
                    GlobalCode.sOleDbConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + GlobalCode.sPATH_FILE_DATA;
                    GlobalCode.connData = new OleDbConnection(GlobalCode.sOleDbConnectionString);
                    Initialize_DB();
                }

                Settings.Default.Save();


                string strUpdate = "UPDATE Options SET " +
                "AIRCRAFT = @aircraft," +
                "FLEET = @fleet," +
                "PATH_DB = @path_db," +
                "PATH_DB_BACKUP = @path_db_backup," +
                "PATH_PDF = @path_pdf," +
                "FILE_PDF = @file_pdf," +
                "CARRIER = @carrier," +
                "PATH_IMAGE_PDF = @path_image_pdf," +
                "PATH_LOGO = @path_logo," +

                "A1 = @a1," +
                "A2 = @a2," +
                "A3 = @a3," +
                "A4 = @a4," +
                "A5 = @a5," +
                "A6 = @a6," +
                "A7 = @a7," +
                "A8 = @a8," +
                "A9 = @a9," +
                "A10 = @a10," +
                "A11 = @a11," +
                "A12 = @a12," +
                "A13 = @a13," +
                "A14 = @a14," +
                "A15 = @a15," +
                "A16 = @a16," +
                "A17 = @a17," +
                "A18 = @a18," +
                "A19 = @a19," +
                "A20 = @a20," +
                "A21 = @a21," +
                "A22 = @a22," +
                "A23 = @a23," +
                "A24 = @a24," +
                "A25 = @a25," +
                "A26 = @a26," +
                "A27 = @a27," +
                "A28 = @a28," +
                "A29 = @a29," +
                "A30 = @a30" +

                " WHERE [ID] = @id";

                OleDbCommand cmd = new OleDbCommand(strUpdate, conn);

                cmd.Parameters.AddWithValue("@aircraft", Get_Selected_Key(cboFleet));
                cmd.Parameters.AddWithValue("@fleet", cboFleet.Text);
                cmd.Parameters.AddWithValue("@path_db", lblPathData.Text);
                cmd.Parameters.AddWithValue("@path_db_backup", lblPathDataBackup.Text);
                cmd.Parameters.AddWithValue("@path_pdf", lblPathOutput.Text);
                cmd.Parameters.AddWithValue("@file_pdf", txtFilePDF.Text);

                cmd.Parameters.AddWithValue("@carrier", txtAirCarrier.Text);
                cmd.Parameters.AddWithValue("@path_image_pdf", lblPathImagePdf.Text);
                cmd.Parameters.AddWithValue("@path_logo", lblPathLogo.Text);

                // additional fields
                for (int x = 1; x < 31; x++) {
                    cmd.Parameters.AddWithValue("@a" + x, "");
                }

                cmd.Parameters.AddWithValue("@id", 1);

                conn.Open();
                int iRows = cmd.ExecuteNonQuery();
                conn.Close();


            } catch (Exception) {
                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            UpdateDataRow();
            Program.Load_App();
            this.Close();
        }

        private void btnPathData_Click(object sender, EventArgs e) {
            using (var folderDialog = new FolderBrowserDialog()) {

                if (GlobalCode.sPATH_DATA == "")
                    folderDialog.SelectedPath = GlobalCode.sPATH_OPTIONS;
                else
                    folderDialog.SelectedPath = GlobalCode.sPATH_DATA;

                if (folderDialog.ShowDialog() == DialogResult.OK) {
                    lblPathData.Text = folderDialog.SelectedPath;
                    GlobalCode.sPATH_OPTIONS = folderDialog.SelectedPath;
                }
            }
            CheckForComplete();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void frmOptions_FormClosing(object sender, FormClosingEventArgs e) {
            Settings.Default.Save();

        }

        private void btnPathDataBackup_Click(object sender, EventArgs e) {
            using (var folderDialog = new FolderBrowserDialog()) {
                if (GlobalCode.sPATH_DATA == "")
                    folderDialog.SelectedPath = GlobalCode.sPATH_OPTIONS;
                else
                    folderDialog.SelectedPath = GlobalCode.sPATH_FILE_DATA_BACKUP;
                if (folderDialog.ShowDialog() == DialogResult.OK) {
                    lblPathDataBackup.Text = folderDialog.SelectedPath;
                    GlobalCode.sPATH_OPTIONS = folderDialog.SelectedPath;
                }
            }
            CheckForComplete();
        }

        private void btnPathOutput_Click(object sender, EventArgs e) {
            using (var folderDialog = new FolderBrowserDialog()) {
                if (GlobalCode.sPATH_DATA == "")
                    folderDialog.SelectedPath = GlobalCode.sPATH_OPTIONS;
                else
                    folderDialog.SelectedPath = GlobalCode.sPATH_PDF;
                if (folderDialog.ShowDialog() == DialogResult.OK) {
                    lblPathOutput.Text = folderDialog.SelectedPath;
                    GlobalCode.sPATH_OPTIONS = folderDialog.SelectedPath;
                }
            }
            CheckForComplete();
        }

        private void btnPathImagePdf_Click(object sender, EventArgs e) {
            using (var folderDialog = new OpenFileDialog()) {
                if (GlobalCode.sPATH_DATA == "")
                    folderDialog.InitialDirectory = GlobalCode.sPATH_OPTIONS;
                else
                    folderDialog.InitialDirectory = GlobalCode.sPATH_DATA;
                folderDialog.Title = "Select Title Page Image";
                folderDialog.Filter = "PNG| *.png";
                folderDialog.FilterIndex = 1;
                if (folderDialog.ShowDialog() == DialogResult.OK) {
                    lblPathImagePdf.Text = folderDialog.FileName;
                    GlobalCode.sPATH_OPTIONS = folderDialog.InitialDirectory;
                }
            }
            CheckForComplete();
        }

        private void btnPathLogo_Click(object sender, EventArgs e) {
            using (var folderDialog = new OpenFileDialog()) {
                if (GlobalCode.sPATH_DATA == "")
                    folderDialog.InitialDirectory = GlobalCode.sPATH_OPTIONS;
                else
                    folderDialog.InitialDirectory = GlobalCode.sPATH_DATA;
                folderDialog.Title = "Select Page Logo Image";
                folderDialog.Filter = "PNG| *.png";
                folderDialog.FilterIndex = 1;
                if (folderDialog.ShowDialog() == DialogResult.OK) {
                    lblPathLogo.Text = folderDialog.FileName;
                    GlobalCode.sPATH_OPTIONS = folderDialog.InitialDirectory;
                }
            }
            CheckForComplete();
        }

        private void txtAirCarrier_Leave(object sender, EventArgs e) {
            CheckForComplete();
        }
        private void txtAirCarrier_TextChanged(object sender, EventArgs e) {
            CheckForComplete();
        }

        private void txtFilePDF_Leave(object sender, EventArgs e) {
            CheckForComplete();
        }

        private void txtFilePDF_TextChanged(object sender, EventArgs e) {
            CheckForComplete();
        }

        private void cboFleet_TextChanged(object sender, EventArgs e) {
            CheckForComplete();
        }
    }
}
