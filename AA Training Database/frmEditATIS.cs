using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    public partial class frmEditATIS : Form {
        public frmEditATIS() {
            InitializeComponent();
        }

        private OleDbConnection conn;
        private OleDbDataAdapter dataAdapter;
        DataTable dtTable;
        private BindingSource bindingSource1;

        private void frmEditATIS_Load(object sender, EventArgs e) {
            try {
                Initialize_DB();
                Fill_CBOs(cboSelect, "SELECT ID,ATIS_NAME FROM ATIS ORDER BY ID");

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
                string sQuery = "SELECT * FROM ATIS";
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
        private void FillData() {
            try {
                int iSelected = Get_Selected_Key(cboSelect);
                if (cboSelect.SelectedIndex > 0 || iSelected > -1) {
                    string sCommand = "SELECT * FROM ATIS WHERE ID = " + iSelected;
                    conn.Open();
                    OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
                    DataTable dt = new DataTable();
                    dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dAdapter.Fill(dt);
                    conn.Close();

                    for (int i = 0; i <= dt.Rows.Count - 1; i++) {
                        txtName.Text = (string)dt.Rows[i].ItemArray[1];
                        string sDate = "CREATED: " + (string)dt.Rows[i].ItemArray[2];
                        sDate = sDate + "\r\nEDITED: " + (string)dt.Rows[i].ItemArray[3];
                        txtDate.Text = sDate;
                        txtData5.Text = (string)dt.Rows[i].ItemArray[5];
                    }
                    btnSave.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    btnClear.Enabled = true;
                } else {
                    // clear all entries
                    Clear_Entries();
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

        int iSelected = 0;
        private void cboATIS_SelectedIndexChanged(object sender, EventArgs e) {
            FillData();
        }

        private void Clear_Entries() {
            try {
                txtData5.Text = "";
                txtName.Text = "";
                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnClear.Enabled = false;
            } catch (Exception) {
                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            try {
                System.Data.DataRow dr = dtTable.NewRow();
                dr["ATIS_NAME"] = txtName.Text;
                dr["DATE_CREATED"] = GetDateString(DateTime.Now);
                dr["DATE_EDITED"] = GetDateString(DateTime.Now);
                dr["ATIS"] = txtData5.Text;
                dtTable.Rows.Add(dr);
                dataAdapter.Update(dtTable);  // write new row back to database
                iSelected = cboSelect.Items.Count;
                Fill_CBOs(cboSelect, "SELECT ID,ATIS_NAME FROM ATIS ORDER BY ID");
            } catch (Exception) {
                throw;
            }
        }

        private void UpdateDataRow() {
            try {
                if (Get_Selected_Key(cboSelect) > -1) {
                    string strUpdate = "UPDATE ATIS SET " +
                        "ATIS_NAME = @atis_name," +
                        "DATE_EDITED = @date_edited," +
                        "ATIS = @atis" +
                        " WHERE [ID] = @id";

                    OleDbCommand cmd = new OleDbCommand(strUpdate, conn);

                    cmd.Parameters.AddWithValue("@atis_name", txtName.Text);
                    cmd.Parameters.AddWithValue("@date_edited", GetDateString(DateTime.Now));
                    cmd.Parameters.AddWithValue("@atis", txtData5.Text);
                    cmd.Parameters.AddWithValue("@id", Get_Selected_Key(cboSelect));

                    conn.Open();
                    int iRows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            } catch (Exception) {
                throw;
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e) {
            UpdateDataRow();
        }

        private DateTime GetDateWithoutMilliseconds(DateTime d) {
            return new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
        }
        private string GetDateString(DateTime d) {
            object value = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
            DateTime result = (DateTime)value;
            string sResult = result.ToString("M/d/yyyy HHmm");
            return sResult;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }
        private void Delete_Entry() {
            try {
                iSelected = Get_Selected_Key(cboSelect);
                if (iSelected > -1) {

                    // search for use of this item in any existing spot
                    string sCommand = "SELECT SPOT_NAME, ATIS FROM Spots WHERE ATIS = " + iSelected;
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
                            "The ATIS selected can not be deleted because it is used in the following " + iCount + " SPOTS: " + sSpots,
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
                        string sQuery = "DELETE FROM ATIS WHERE ID=" + Get_Selected_Key(cboSelect);
                        conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
                        conn.Open();
                        OleDbCommand commandBuilder = new OleDbCommand(sQuery, conn);
                        commandBuilder.ExecuteNonQuery();
                        conn.Close();
                        Fill_CBOs(cboSelect, "SELECT ID,ATIS_NAME FROM ATIS ORDER BY ID");
                    }
                }
            } catch (Exception) {
                throw;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e) {
            Delete_Entry();
        }

        private void btnClear_Click(object sender, EventArgs e) {
            cboSelect.SelectedIndex = 0;
            Clear_Entries();
        }

        private void txtName_Leave(object sender, EventArgs e) {
            try {
                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnClear.Enabled = false;
                if (txtName.Text != "") {
                    if (cboSelect.SelectedIndex > 0) {
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    btnSave.Enabled = true;
                    btnClear.Enabled = true;
                }
            } catch (Exception) {
                throw;
            }
        }
    }
}
