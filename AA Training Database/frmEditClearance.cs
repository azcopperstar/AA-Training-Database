using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    public partial class frmEditClearance : Form {
        public frmEditClearance() {
            InitializeComponent();
        }

        private OleDbConnection conn;
        private OleDbDataAdapter dataAdapter;
        DataTable dtTable;
        //private BindingSource bindingSource1;

        private void frmEditClearance_Load(object sender, EventArgs e) {
            try {
                Initialize_DB();
                Fill_CBOs(cboSelect, "SELECT * FROM Clearance ORDER BY DEP, CLEARANCE_NAME");
                Fill_CBOs_AutoComplete(cboDEP, "SELECT DISTINCT ICAO FROM Airport_Runways", "ICAO");
                Fill_CBOs_AutoComplete(cboDEST, "SELECT DISTINCT ICAO FROM Airport_Runways", "ICAO");
                Fill_CBOs_AutoComplete(cboALTN, "SELECT DISTINCT ICAO FROM Airport_Runways", "ICAO");

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
                string sQuery = "SELECT * FROM Clearance";
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
        private void Fill_CBOs_AutoComplete(ComboBox cbo, string query, string displaymember) {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            cbo.DisplayMember = displaymember;
            List<string> list = new List<string>();
            foreach (DataRow row in dt.Rows) {
                list.Add(row.Field<string>(displaymember));
            }
            cbo.Items.AddRange(list.ToArray<string>());
            cbo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            conn.Close();
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
                    data.Add(new KeyValuePair<int, string>((int)dt.Rows[i]["ID"], (string)dt.Rows[i]["DEP"] + "- " + (string)dt.Rows[i]["CLEARANCE_NAME"]));
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
                    string sCommand = "SELECT * FROM Clearance WHERE ID = " + iSelected;
                    conn.Open();
                    OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
                    DataTable dt = new DataTable();
                    dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dAdapter.Fill(dt);
                    conn.Close();

                    // clear all entries
                    Clear_Entries();

                    for (int i = 0; i <= dt.Rows.Count - 1; i++) {
                        txtName.Text = (string)dt.Rows[i].ItemArray[1];
                        string sDate = "CREATED: " + (string)dt.Rows[i]["DATE_CREATED"];
                        sDate = sDate + "\r\nEDITED: " + (string)dt.Rows[i]["DATE_EDITED"];
                        txtDate.Text = sDate;
                        txtFltNum.Text = (string)dt.Rows[i]["FLTNUM"];
                        cboDEP.Text = (string)dt.Rows[i]["DEP"];
                        cboDEST.Text = (string)dt.Rows[i]["DEST"];
                        cboALTN.Text = (string)dt.Rows[i]["ALTN"];
                        txtXPNDR.Value = (int)dt.Rows[i]["XPNDR"];
                        txtSID.Text = (string)dt.Rows[i]["SID"];
                        txtSIDTrans.Text = (string)dt.Rows[i]["SID_TRANS"];
                        if ((int)dt.Rows[i]["AS_FILED"] == 1) {
                            chkEnroute.Checked = true;
                            txtEnroute.Text = "";
                            lblEnroute.Enabled = false;
                            txtEnroute.Enabled = false;
                        } else {
                            chkEnroute.Checked = false;
                            txtEnroute.Text = (string)dt.Rows[i]["ENROUTE"];
                            lblEnroute.Enabled = true;
                            txtEnroute.Enabled = true;
                        }
                        txtSTAR.Text = (string)dt.Rows[i]["STAR"];
                        txtSTARTrans.Text = (string)dt.Rows[i]["STAR_TRANS"];
                        if ((int)dt.Rows[i]["CLIMB_VIA"] == 1) {
                            chkClimbVia.Checked = true;
                            txtAltInit.Value = 0;
                            lblAltInit.Enabled = false;
                            txtAltInit.Enabled = false;
                        } else {
                            chkClimbVia.Checked = false;
                            txtAltInit.Value = (int)dt.Rows[i]["ALT_INIT"];
                            lblAltInit.Enabled = true;
                            txtAltInit.Enabled = true;
                        }
                        txtAltExpect.Value = (int)dt.Rows[i]["ALT_EXPECT"];
                        double dFreq = Convert.ToDouble((Single)dt.Rows[i]["DEP_FREQ"]);
                        txtDepFreq.Value =Convert.ToDecimal(dFreq);
                        txtRemarks.Text = (string)dt.Rows[i]["REMARKS"];
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

        private DateTime GetDateWithoutMilliseconds(DateTime d) {
            return new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
        }
        private string GetDateString(DateTime d) {
            object value = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
            DateTime result = (DateTime)value;
            string sResult = result.ToString("M/d/yyyy HHmm");
            return sResult;
        }

        int iSelected = 0;
        private void cboSelect_SelectedIndexChanged(object sender, EventArgs e) {
            FillData();
        }
        private void Clear_Entries() {
            txtRemarks.Text = "";
            txtName.Text = "";

            txtFltNum.Text = "";
            cboDEP.Text = "";
            cboDEST.Text = "";
            cboALTN.Text = "";
            txtFltNum.Text = "";
            cboDEP.Text = "";
            cboDEST.Text = "";
            cboALTN.Text = "";
            txtXPNDR.Value = 1200;
            txtSID.Text = "";
            txtSIDTrans.Text = "";
            chkEnroute.Checked = true;
            txtEnroute.Text = "";
            txtSTAR.Text = "";
            txtSTARTrans.Text = "";
            txtAltInit.Value = 0;
            chkClimbVia.Checked = true;
            txtAltExpect.Value = 0;
            txtDepFreq.Value = 119;
            txtRemarks.Text = "";

            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnClear.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            System.Data.DataRow dr = dtTable.NewRow();
            dr["CLEARANCE_NAME"] = txtName.Text;
            dr["DATE_CREATED"] = GetDateString(DateTime.Now);
            dr["DATE_EDITED"] = GetDateString(DateTime.Now);
            dr["CLEARANCE"] = "";
            dr["SPOT"] = "";
            dr["FLTNUM"] = txtFltNum.Text;
            dr["DEP"] = cboDEP.Text;
            dr["DEST"] = cboDEST.Text;
            dr["ALTN"] = cboALTN.Text;
            dr["XPNDR"] = txtXPNDR.Value;
            dr["SID"] = txtSID.Text;
            dr["SID_ID"] = 0;
            dr["SID_TRANS"] = txtSIDTrans.Text;
            dr["SID_TRANS_ID"] = 0;
            if (chkEnroute.Checked) {
                dr["AS_FILED"] = 1;
                dr["ENROUTE"] = "";
            } else {
                dr["AS_FILED"] = 0;
                dr["ENROUTE"] = txtEnroute.Text;
            }
            dr["STAR"] = txtSTAR.Text;
            dr["STAR_ID"] = 0;
            dr["STAR_TRANS"] = txtSTARTrans.Text;
            dr["STAR_TRANS_ID"] = 0;
            if (chkClimbVia.Checked) {
                dr["CLIMB_VIA"] = 1;
                dr["ALT_INIT"] = 0;
            } else {
                dr["CLIMB_VIA"] = 0;
                dr["ALT_INIT"] = txtAltInit.Value;
            }
            dr["ALT_EXPECT"] = txtAltExpect.Value;
            dr["DEP_FREQ"] = txtDepFreq.Value;
            dr["REMARKS"] = txtRemarks.Text;

            dtTable.Rows.Add(dr);
            dataAdapter.Update(dtTable);  // write new row back to database
            iSelected = cboSelect.Items.Count;
            Fill_CBOs(cboSelect, "SELECT * FROM Clearance ORDER BY DEP, CLEARANCE_NAME");
        }

        private void UpdateDataRow() {
            try {
                if (Get_Selected_Key(cboSelect) > -1) {
                    string strUpdate = "UPDATE Clearance SET " +
                        "CLEARANCE_NAME = @clearance_name," +
                        "DATE_EDITED = @date_edited," +
                        "CLEARANCE = @clearance," +
                        "SPOT = @spot," +
                        "FLTNUM = @fltnum," +
                        "DEP = @from," +
                        "DEST = @to," +
                        "ALTN = @altn," +
                        "XPNDR = @xpndr," +
                        "SID = @sid," +
                        "SID_ID = @sid_id," +
                        "SID_TRANS = @sid_trans," +
                        "SID_TRANS_ID = @sid_trans_id," +
                        "AS_FILED = @as_filed," +
                        "ENROUTE = @enroute," +
                        "STAR = @star," +
                        "STAR_ID = @star_id," +
                        "STAR_TRANS = @star_trans," +
                        "STAR_TRANS_ID = @star_trans_id," +
                        "CLIMB_VIA = @climb_via," +
                        "ALT_INIT = @alt_init," +
                        "ALT_EXPECT = @alt_expect," +
                        "DEP_FREQ = @dep_freq," +
                        "REMARKS = @remarks" +
                        " WHERE [ID] = @id";

                    OleDbCommand cmd = new OleDbCommand(strUpdate, conn);

                    cmd.Parameters.AddWithValue("@clearance_name", txtName.Text);
                    cmd.Parameters.AddWithValue("@date_edited", GetDateString(DateTime.Now));
                    cmd.Parameters.AddWithValue("@clearance", txtRemarks.Text);
                    cmd.Parameters.AddWithValue("@spot", "");
                    cmd.Parameters.AddWithValue("@fltnum", txtFltNum.Text);
                    cmd.Parameters.AddWithValue("@from", cboDEP.Text);
                    cmd.Parameters.AddWithValue("@to", cboDEST.Text);
                    cmd.Parameters.AddWithValue("@altn", cboALTN.Text);

                    cmd.Parameters.AddWithValue("@xpndr", txtXPNDR.Value);
                    cmd.Parameters.AddWithValue("@sid", txtSID.Text);
                    cmd.Parameters.AddWithValue("@sid_id", 0);
                    cmd.Parameters.AddWithValue("@sid_trans", txtSIDTrans.Text);
                    cmd.Parameters.AddWithValue("@sid_trans_id", 0);
                    if (chkEnroute.Checked) {
                        cmd.Parameters.AddWithValue("@as_filed", 1);
                        cmd.Parameters.AddWithValue("@enroute", "");
                    } else {
                        cmd.Parameters.AddWithValue("@as_filed", 0);
                        cmd.Parameters.AddWithValue("@enroute", txtEnroute.Text);
                    }
                    cmd.Parameters.AddWithValue("@star", txtSTAR.Text);
                    cmd.Parameters.AddWithValue("@star_id", 0);
                    cmd.Parameters.AddWithValue("@star_trans", txtSTARTrans.Text);
                    cmd.Parameters.AddWithValue("@star_trans_id", 0);
                    if (chkClimbVia.Checked) {
                        cmd.Parameters.AddWithValue("@climb_via", 1);
                        cmd.Parameters.AddWithValue("@alt_init", 0);
                    } else {
                        cmd.Parameters.AddWithValue("@climb_via", 0);
                        cmd.Parameters.AddWithValue("@alt_init", txtAltInit.Value);
                    }
                    cmd.Parameters.AddWithValue("@alt_expect", txtAltExpect.Value);
                    cmd.Parameters.AddWithValue("@dep_freq", txtDepFreq.Value);
                    cmd.Parameters.AddWithValue("@remarks", txtRemarks.Text);
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

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Delete_Entry() {
            iSelected = Get_Selected_Key(cboSelect);
            if (iSelected > -1) {
                // search for use of this item in any existing spot
                string sCommand = "SELECT SPOT_NAME, CLEARANCE FROM Spots WHERE CLEARANCE = " + iSelected;
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
                        "The 'CLEARANCE' selected can not be deleted because it is used in the following " + iCount + " SPOTS: " + sSpots,
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
                    string sQuery = "DELETE FROM Clearance WHERE ID=" + Get_Selected_Key(cboSelect);
                    conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
                    conn.Open();
                    OleDbCommand commandBuilder = new OleDbCommand(sQuery, conn);
                    commandBuilder.ExecuteNonQuery();
                    conn.Close();
                    Fill_CBOs(cboSelect, "SELECT ID,CLEARANCE_NAME FROM Clearance ORDER BY ID");
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e) {
            Delete_Entry();
        }

        private void CheckForComplete() {
            try {
                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnClear.Enabled = false;
                if (txtName.Text != "" &&
                    txtFltNum.Text != "" &&
                    cboDEP.Text != "" &&
                    cboDEST.Text != "") {
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


        private void btnClear_Click(object sender, EventArgs e) {
            cboSelect.SelectedIndex = 0;
            Clear_Entries();
            CheckForComplete();
        }

        private void txtName_Leave(object sender, EventArgs e) {
            CheckForComplete();
        }
        private void txtFltNum_Leave(object sender, EventArgs e) {
            CheckForComplete();
        }
        private void txtFrom_Leave(object sender, EventArgs e) {
            CheckForComplete();
        }
        private void txtTo_Leave(object sender, EventArgs e) {
            CheckForComplete();
        }

        private void chkEnroute_CheckedChanged(object sender, EventArgs e) {
            if (chkEnroute.Checked) {
                lblEnroute.Enabled = false;
                txtEnroute.Enabled = false;
            } else {
                lblEnroute.Enabled = true;
                txtEnroute.Enabled = true;
            }
        }

        private void chkClimbVia_CheckedChanged(object sender, EventArgs e) {
            if (chkClimbVia.Checked) {
                lblAltInit.Enabled = false;
                txtAltInit.Enabled = false;
            } else {
                lblAltInit.Enabled = true;
                txtAltInit.Enabled = true;
            }

        }

        private void txtXPNDR_ValueChanged(object sender, EventArgs e) {
            if (txtXPNDR.Value.ToString().IndexOf("8") > -1 || txtXPNDR.Value.ToString().IndexOf("9") > -1) {
                // invalid code 0-7
                MessageBox.Show(
                    "Transponder codes can only contain the digits 0-7.  The code entered, " + txtXPNDR.Value + " is invalid.",
                    "INVALID TRANSPONDER CODE",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtXPNDR.Value = 1200;
                txtXPNDR.Focus();
            }
        }

        private void txtXPNDR_Leave(object sender, EventArgs e) {
            if (txtXPNDR.Value.ToString().IndexOf("8") > -1 || txtXPNDR.Value.ToString().IndexOf("9") > -1) {
                // invalid code 0-7
                MessageBox.Show(
                    "Transponder codes can only contain the digits 0-7.  The code entered, " + txtXPNDR.Value + " is invalid.",
                    "INVALID TRANSPONDER CODE",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtXPNDR.Value = 1200;
                txtXPNDR.Focus();
            }
        }
    }
}
