﻿using System;
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

                for (int i = 0; i <= dt.Rows.Count - 1; i++) {
                    cboFleet.Enabled = true;
                    foreach (KeyValuePair<int, string> row in cboFleet.Items) {
                        if (row.Key == (int)dt.Rows[i]["AIRCRAFT"]) {
                            cboFleet.SelectedIndex = cboFleet.Items.IndexOf(row);
                            // if fleet selection found, disable cbo
                            cboFleet.Enabled = false;
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
                txtFilePDF.Text = GlobalCode.sFILE_PDF;
                txtAirCarrier.Text = GlobalCode.sCARRIER;

                btnSave.Enabled = true;
            } catch (Exception) {
                throw;
            }
        }

        private void UpdateDataRow() {
            try {
                string strUpdate = "UPDATE Options SET " +
                "AIRCRAFT = @aircraft," +
                "FLEET = @fleet," +
                "PATH_DB = @path_db," +
                "PATH_DB_BACKUP = @path_db_backup," +
                "PATH_PDF = @path_pdf," +
                "FILE_PDF = @file_pdf," +
                "CARRIER = @carrier," +
                "PATH_IMAGE_PDF = @path_image_pdf," +
                "PATH_LOGO = @path_logo" +
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

                cmd.Parameters.AddWithValue("@id", 1);

                conn.Open();
                int iRows = cmd.ExecuteNonQuery();
                conn.Close();

                GlobalCode.sFleet = cboFleet.Text;

                // save setting
                Settings.Default.FLEET = cboFleet.Text;


                string sPathDataOriginal = lblPathDataOriginal.Text;
                string sPathFileDataOriginal = "";

                GlobalCode.sPATH_DATA = lblPathData.Text;
                Settings.Default.PATH_DB = GlobalCode.sPATH_DATA;
                GlobalCode.sPATH_FILE_DATA_BACKUP= lblPathDataBackup.Text;
                Settings.Default.FILE_DB_BACKUP= GlobalCode.sPATH_FILE_DATA_BACKUP;
                GlobalCode.sFILE_DATA = "\\TSD_" + cboFleet.Text + ".accdb";
                Settings.Default.FILE_DB = GlobalCode.sFILE_DATA;
                GlobalCode.sPATH_FILE_DATA = GlobalCode.sPATH_DATA + GlobalCode.sFILE_DATA;

                GlobalCode.sPATH_PDF = lblPathOutput.Text;
                GlobalCode.sFILE_PDF = txtFilePDF.Text;

                GlobalCode.sPATH_IMAGE_PDF= lblPathImagePdf.Text;
                GlobalCode.sPATH_LOGO= lblPathLogo.Text;

                // 1st, test for fleet file in original folder
                sPathFileDataOriginal = sPathDataOriginal + GlobalCode.sFILE_DATA;
                if (!File.Exists(sPathFileDataOriginal)) {
                    // fleet file NOT found in original folder, set to default file and test
                    sPathFileDataOriginal = sPathDataOriginal + "\\TSD_.accdb";
                    if (!File.Exists(sPathFileDataOriginal)) {
                        // default db file not found in original folder, set to app folder
                        sPathFileDataOriginal = GlobalCode.sPATH_APP + "\\TSD_.accdb";
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
                    GlobalCode.conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
                }


                // you can force a save with
                Settings.Default.Save();

            } catch (Exception) {
                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (lblPathData.Text == "" || lblPathOutput.Text == "") {
                DialogResult result = MessageBox.Show(
                    "All required fields of the preferences were not completed.",
                    "UNABLE TO UPDATE",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
                return;
            }
            UpdateDataRow();
            this.Close();
        }

        private void btnPathData_Click(object sender, EventArgs e) {
            using (var folderDialog = new FolderBrowserDialog()) {
                folderDialog.SelectedPath = GlobalCode.sPATH_DATA;
                if (folderDialog.ShowDialog() == DialogResult.OK) {
                    lblPathData.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void frmOptions_FormClosing(object sender, FormClosingEventArgs e) {
            Settings.Default.Save();

        }

        private void btnPathDataBackup_Click(object sender, EventArgs e) {
            using (var folderDialog = new FolderBrowserDialog()) {
                folderDialog.SelectedPath = GlobalCode.sPATH_FILE_DATA_BACKUP;
                if (folderDialog.ShowDialog() == DialogResult.OK) {
                    lblPathDataBackup.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void btnPathOutput_Click(object sender, EventArgs e) {
            using (var folderDialog = new FolderBrowserDialog()) {
                folderDialog.SelectedPath = GlobalCode.sPATH_PDF;
                if (folderDialog.ShowDialog() == DialogResult.OK) {
                    lblPathOutput.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void btnPathImagePdf_Click(object sender, EventArgs e) {
            using (var folderDialog = new OpenFileDialog()) {
                folderDialog.InitialDirectory = GlobalCode.sPATH_DATA;
                folderDialog.Title = "Select Title Page Image";
                folderDialog.Filter = "PNG| *.png";
                folderDialog.FilterIndex = 1;
                if (folderDialog.ShowDialog() == DialogResult.OK) {
                    lblPathImagePdf.Text = folderDialog.FileName;
                }
            }
        }

        private void btnPathLogo_Click(object sender, EventArgs e) {
            using (var folderDialog = new OpenFileDialog()) {
                folderDialog.InitialDirectory = GlobalCode.sPATH_DATA;
                folderDialog.Title = "Select Page Logo Image";
                folderDialog.Filter = "PNG| *.png";
                folderDialog.FilterIndex = 1;
                if (folderDialog.ShowDialog() == DialogResult.OK) {
                    lblPathLogo.Text = folderDialog.FileName;
                }
            }
        }
    }
}