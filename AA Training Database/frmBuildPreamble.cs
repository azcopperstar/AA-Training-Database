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

namespace WindowsFormsApplication1 {
    public partial class frmBuildPreamble : Form {
        public frmBuildPreamble() {
            InitializeComponent();
        }

        private static OleDbConnection conn;
        private OleDbDataAdapter dataAdapter;
        DataTable dtTable;
        //private BindingSource bindingSource1;

        static string strPath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);

        // used to get set data to editor
        public string Body1Text {
            get {
                return txtBody1.Rtf;
            }
            set {
                txtBody1.Rtf = value;
            }
        }
        public string Body2Text {
            get {
                return txtBody2.Rtf;
            }
            set {
                txtBody2.Rtf = value;
            }
        }
        public string Body3Text {
            get {
                return txtBody3.Rtf;
            }
            set {
                txtBody3.Rtf = value;
            }
        }

        private void frmBuildPreamble_Load(object sender, EventArgs e) {
            try {
                Initialize_DB();
                Fill_CBOs(cboSelect, "SELECT ID, P_NAME FROM Preamble ORDER BY [P_NAME]");
                if (cboSelect.Items.Count > 1) {
                    cboSelect.SelectedIndex = 0;
                    cboSelect.DroppedDown = true;
                }


            } catch (Exception) {
                throw;
            }

        }
        private void Initialize_DB() {
            try {
                string sQuery = "SELECT * FROM Preamble";
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
                    if (!dt.Rows[i].IsNull(1))
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
        private void FillData() {
            try {
                Clear_Entries();
                int iSelected = Get_Selected_Key(cboSelect);
                if (cboSelect.SelectedIndex > 0 || iSelected > -1) {
                    string sCommand = "SELECT * FROM Preamble WHERE ID = " + iSelected;
                    conn.Open();
                    OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
                    DataTable dt = new DataTable();
                    dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dAdapter.Fill(dt);
                    conn.Close();

                    for (int i = 0; i <= dt.Rows.Count - 1; i++) {
                        txtName.Text = (string)dt.Rows[i]["P_NAME"];
                        string sDate = "CREATED: " + (string)dt.Rows[i]["DATE_CREATED"];
                        sDate = sDate + "\r\nEDITED: " + (string)dt.Rows[i]["DATE_EDITED"];
                        txtDate.Text = sDate;

                        txtTitle1.Text = (string)dt.Rows[i]["TITLE1"];
                        txtBody1.Rtf = (string)dt.Rows[i]["BODY1"];
                        txtTitle2.Text = (string)dt.Rows[i]["TITLE2"];
                        txtBody2.Rtf = (string)dt.Rows[i]["BODY2"];
                        txtTitle3.Text = (string)dt.Rows[i]["TITLE3"];
                        txtBody3.Rtf = (string)dt.Rows[i]["BODY3"];

                        if ((string)dt.Rows[i]["P_PATH"] == "0" || (string)dt.Rows[i]["P_PATH"] == "") {
                            // enable text group
                            optText.Checked = true;
                        } else {
                            optPDF.Checked = true;
                            lblPDFPath.Text = (string)dt.Rows[i]["P_PATH"];
                            Load_PDF_Viewer(lblPDFPath.Text);
                        }
                    }
                    btnSave.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    btnClear.Enabled = true;
                }
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

        private string GetDateString(DateTime d) {
            try {
                object value = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
                DateTime result = (DateTime)value;
                string sResult = result.ToString("M/d/yyyy HHmm");
                return sResult;
            } catch (Exception) {
                throw;
            }
        }


        private void btnSave_Click_1(object sender, EventArgs e) {
            try {
                System.Data.DataRow dr = dtTable.NewRow();
                dr["P_NAME"] = txtName.Text;
                dr["DATE_CREATED"] = GetDateString(DateTime.Now);
                dr["DATE_EDITED"] = GetDateString(DateTime.Now);
                dr["TITLE1"] = txtTitle1.Text;
                dr["BODY1"] = txtBody1.Rtf;
                dr["TITLE2"] = txtTitle2.Text;
                dr["BODY2"] = txtBody2.Rtf;
                dr["TITLE3"] = txtTitle3.Text;
                dr["BODY3"] = txtBody3.Rtf;
                dr["TITLE4"] = "";
                dr["BODY4"] = "";
                dr["P_PATH"] = lblPDFPath.Text;

                // additional fields
                for (int x = 1; x < 11; x++) {
                    dr["A" + x] = "";
                }

                dtTable.Rows.Add(dr);
                dataAdapter.Update(dtTable);  // write new row back to database
                iSelected = cboSelect.Items.Count;
                Fill_CBOs(cboSelect, "SELECT ID, P_NAME FROM Preamble ORDER BY [P_NAME]");
                cboSelect.SelectedIndex = 0;
            } catch (Exception) {
                throw;
            }
        }
        private void UpdateDataRow() {
            if (Get_Selected_Key(cboSelect) > -1) {
                string strUpdate = "UPDATE Preamble SET " +
                    "P_NAME = @p_name," +
                    "DATE_EDITED = @date_edited," +
                    "TITLE1 = @title1," +
                    "BODY1= @body1," +
                    "TITLE2 = @title2," +
                    "BODY2 = @body2," +
                    "TITLE3 = @title3," +
                    "BODY3 = @body3," +
                    "TITLE4 = @title4," +
                    "BODY4 = @body4," +
                    "P_PATH = @p_path," +

                        "A1 = @a1," +
                        "A2 = @a2," +
                        "A3 = @a3," +
                        "A4 = @a4," +
                        "A5 = @a5," +
                        "A6 = @a6," +
                        "A7 = @a7," +
                        "A8 = @a8," +
                        "A9 = @a9," +
                        "A10 = @a10" +

                    " WHERE [ID] = @id";

                OleDbCommand cmd = new OleDbCommand(strUpdate, conn);

                cmd.Parameters.AddWithValue("@p_name", txtName.Text);
                cmd.Parameters.AddWithValue("@date_edited", GetDateString(DateTime.Now));
                cmd.Parameters.AddWithValue("@title1", txtTitle1.Text);
                cmd.Parameters.AddWithValue("@body1", txtBody1.Rtf);
                cmd.Parameters.AddWithValue("@title2", txtTitle2.Text);
                cmd.Parameters.AddWithValue("@body2", txtBody2.Rtf);
                cmd.Parameters.AddWithValue("@title3", txtTitle3.Text);
                cmd.Parameters.AddWithValue("@body3", txtBody3.Rtf);
                cmd.Parameters.AddWithValue("@title4", "");
                cmd.Parameters.AddWithValue("@body4", "");
                cmd.Parameters.AddWithValue("@p_path", lblPDFPath.Text);

                // additional fields
                for (int x = 1; x < 11; x++) {
                    cmd.Parameters.AddWithValue("@a" + x, "");
                }

                cmd.Parameters.AddWithValue("@id", Get_Selected_Key(cboSelect));

                conn.Open();
                int iRows = cmd.ExecuteNonQuery();
                conn.Close();


                if (iRows > 0) {
                    MessageBox.Show("Update Success!");
                }
            }
        }

        private void Clear_Entries() {
            try {
                txtName.Text = "";
                txtTitle1.Text = "";
                txtBody1.Text = "";
                txtTitle2.Text = "";
                txtBody2.Text = "";
                txtTitle3.Text = "";
                txtBody3.Text = "";
                lblPDFPath.Text = "";

                axAcroPDF1.src = "";
                //pdfDocumentViewer1.CloseDocument();

                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnClear.Enabled = false;
            } catch (Exception) {
                throw;
            }
        }


        int iSelected = 0;
        private void cboSelect_SelectedIndexChanged(object sender, EventArgs e) {
            FillData();
        }
        private void Delete_Entry() {
            try {
                iSelected = Get_Selected_Key(cboSelect);
                if (iSelected > -1) {
                    // search for use of this item in any existing spot
                    string sCommand = "SELECT SPOT_NAME, PREAMBLE FROM Spots WHERE PREAMBLE = " + iSelected;
                    OleDbConnection conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
                    conn.Open();
                    OleDbCommand comm = new OleDbCommand(sCommand, conn);
                    OleDbDataReader reader = comm.ExecuteReader();
                    int iCount = 0;
                    string sSpots = "";
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            iCount++;
                            if (sSpots != "") {
                                sSpots = sSpots + ", " + reader.GetValue(0).ToString();
                            } else {
                                sSpots = reader.GetValue(0).ToString();
                            }
                        }
                        MessageBox.Show(
                            "The PREAMBLE selected can not be deleted because it is used in the following " + iCount + " SPOTS: " + sSpots,
                            "UNABLE TO DELETE RECORD",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                    reader.Close();
                    conn.Close();

                    DialogResult result = MessageBox.Show(
                        "Deleting the selected entry will permantly eliminate it from the database.  Are you sure that you would like to DELETE?",
                        "DELETE SELECTED RECORD?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes) {
                        string sQuery = "DELETE FROM Preamble WHERE ID=" + Get_Selected_Key(cboSelect);
                        conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
                        conn.Open();
                        OleDbCommand commandBuilder = new OleDbCommand(sQuery, conn);
                        commandBuilder.ExecuteNonQuery();
                        conn.Close();
                        Clear_Entries();
                        Fill_CBOs(cboSelect, "SELECT ID, P_NAME FROM Preamble ORDER BY [P_NAME]");
                    }
                }

            } catch (Exception) {

                throw;
            }
        }


        private void txtName_Leave_1(object sender, EventArgs e) {
            CheckForComplete();
        }
        private void txtTitle1_Leave_1(object sender, EventArgs e) {
            CheckForComplete();
        }
        private void txtBody1_Leave_1(object sender, EventArgs e) {
            CheckForComplete();
        }
        private void CheckForComplete() {
            try {
                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnClear.Enabled = false;

                if (grpText.Enabled) {
                    if (txtName.Text != "" &&
                        txtBody1.Text != "") {
                        // must have at least name and body1 to save
                        if (cboSelect.SelectedIndex > 0) {
                            btnUpdate.Enabled = true;
                            btnDelete.Enabled = true;
                        }
                        btnSave.Enabled = true;
                        btnClear.Enabled = true;
                    }
                } else {
                    if (txtName.Text != "" && lblPDFPath.Text != "") {
                        // must have lbl path
                        if (cboSelect.SelectedIndex > 0) {
                            btnUpdate.Enabled = true;
                            btnDelete.Enabled = true;
                        }
                        btnSave.Enabled = true;
                        btnClear.Enabled = true;
                    }
                }

            } catch (Exception) {
                throw;
            }
        }


        private void btnUpdate_Click_1(object sender, EventArgs e) {
            UpdateDataRow();
        }
        private void btnDelete_Click_1(object sender, EventArgs e) {
            Delete_Entry();
        }
        private void btnClear_Click_1(object sender, EventArgs e) {
            cboSelect.SelectedIndex = 0;
            Clear_Entries();
            CheckForComplete();
        }
        private void btnCancel_Click_1(object sender, EventArgs e) {
            this.Close();
        }


        private void txtTitle1_TextChanged(object sender, EventArgs e) {

        }


        private void Load_PDF_Viewer(string pdfDoc) {
            if (File.Exists(pdfDoc)) {
                axAcroPDF1.src = pdfDoc;
                axAcroPDF1.setView("Fit");
                axAcroPDF1.setPageMode("bookmarks");
                axAcroPDF1.setLayoutMode("SinglePage");
                axAcroPDF1.setShowToolbar(false);
                //this.pdfDocumentViewer1.LoadFromFile(pdfDoc);
                //pdfDocumentViewer1.ZoomTo(Spire.PdfViewer.Forms.ZoomMode.FitPage);

            }
        }

        private void Select_Group() {
            if (optText.Checked) {
                grpText.Enabled = true;
                grpPDF.Enabled = false;
            } else {
                grpText.Enabled = false;
                grpPDF.Enabled = true;
            }
        }
        private void optText_CheckedChanged(object sender, EventArgs e) {
            Select_Group();
        }

        private void optPDF_CheckedChanged(object sender, EventArgs e) {
            Select_Group();
        }

        private void btnPDF_Click_1(object sender, EventArgs e) {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Title = "Select External PDF File";
            OpenFileDialog1.DefaultExt = "rtf";
            OpenFileDialog1.Filter = "PDF Files | *.pdf";
            OpenFileDialog1.FilterIndex = 1;
            OpenFileDialog1.ShowDialog();

            if (OpenFileDialog1.FileName == "") {
                return;
            }

            string sPDFPath = OpenFileDialog1.FileName;
            lblPDFPath.Text = sPDFPath;

            Load_PDF_Viewer(lblPDFPath.Text);
        }

        private void btnEdit1_Click(object sender, EventArgs e) {
            frmRTFEditor frmRTFEditor = new frmRTFEditor(this, "Preamble.txtBody1");
            frmRTFEditor.Show();
        }

        private void btnEdit2_Click_1(object sender, EventArgs e) {
            frmRTFEditor frmRTFEditor = new frmRTFEditor(this, "Preamble.txtBody2");
            frmRTFEditor.Show();
        }

        private void btnEdit3_Click_1(object sender, EventArgs e) {
            frmRTFEditor frmRTFEditor = new frmRTFEditor(this, "Preamble.txtBody3");
            frmRTFEditor.Show();
        }
    }

}
