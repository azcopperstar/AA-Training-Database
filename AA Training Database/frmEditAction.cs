using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    public partial class frmEditAction : Form {
        public frmEditAction() {
            InitializeComponent();
        }

        private OleDbConnection conn;
        private OleDbDataAdapter dataAdapter;
        DataTable dtTable;
        //private BindingSource bindingSource1;

        int iSelected = 0;

        private void frmEditAction_Load(object sender, EventArgs e) {
            try {
                Initialize_DB();
                Fill_CBOs(cboPF1, "SELECT ID,PF FROM PF", false);
                Fill_WX(cboWx1, "SELECT * FROM Conditions_WX ORDER BY STATION,ATIS_DESIGNATOR");
                Fill_WX(cboWx2, "SELECT * FROM Conditions_WX ORDER BY STATION,ATIS_DESIGNATOR");
                Fill_WX(cboWx3, "SELECT * FROM Conditions_WX ORDER BY STATION,ATIS_DESIGNATOR");
                Fill_CBO_Clearance(cboClearance, "SELECT * FROM Clearance ORDER BY DEP, CLEARANCE_NAME");
                Fill_CBOs(cboSelect, "SELECT ID, ACTION_NAME FROM Actions ORDER BY ID", true);

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
                string sQuery = "SELECT * FROM Actions";
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
        private void Fill_CBOs(ComboBox cbo, string query, bool bBlankLine) {
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
                if (bBlankLine)
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
        private void Fill_WX(ComboBox cbo, string query) {
            try {
                conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(query, GlobalCode.sOleDbConnectionString);
                DataTable dt = new DataTable();
                dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dAdapter.Fill(dt);
                conn.Close();
                // Create a List to store our KeyValuePairs and add data
                List<KeyValuePair<int, string>> data = new List<KeyValuePair<int, string>>();
                data.Add(new KeyValuePair<int, string>(-1, ""));
                for (int i = 0; i <= dt.Rows.Count - 1; i++) {
                    data.Add(new KeyValuePair<int, string>((int)dt.Rows[i]["ID"], (string)dt.Rows[i]["STATION"] + " " + (string)dt.Rows[i]["ATIS_DESIGNATOR"] + "- " + (string)dt.Rows[i]["COND_NAME"]));
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
        private void Fill_CBO_Clearance(ComboBox cbo, string query) {
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
                    data.Add(new KeyValuePair<int, string>((int)dt.Rows[i]["ID"], (string)dt.Rows[i]["DEP"] + " - AAL" + (string)dt.Rows[i]["FLTNUM"] + " (" + (string)dt.Rows[i]["CLEARANCE_NAME"] + ")"));
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
                    string sCommand = "SELECT * FROM Actions WHERE ID = " + iSelected;
                    conn.Open();
                    OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
                    DataTable dt = new DataTable();
                    dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dAdapter.Fill(dt);
                    conn.Close();

                    for (int i = 0; i <= dt.Rows.Count - 1; i++) {
                        txtName.Text = (string)dt.Rows[i].ItemArray[1];
                        string sDate = "CREATED: " + (string)dt.Rows[i]["DATE_CREATED"];
                        sDate = sDate + "\r\nEDITED: " + (string)dt.Rows[i]["DATE_EDITED"];
                        txtDate.Text = sDate;
                        foreach (KeyValuePair<int, string> row in cboPF1.Items) {
                            if (row.Key == (int)dt.Rows[i]["PF"]) {
                                cboPF1.SelectedIndex = cboPF1.Items.IndexOf(row);
                            }
                        }
                        if (cboWx1.Items.Count>0)
                            cboWx1.SelectedIndex = 0;
                        foreach (KeyValuePair<int, string> row in cboWx1.Items) {
                            if (row.Key == GlobalCode.CheckForNullInt(dt.Rows[i], "ATIS1")) {
                                cboWx1.SelectedIndex = cboWx1.Items.IndexOf(row);
                            }
                        }
                        if (cboWx2.Items.Count > 0)
                            cboWx2.SelectedIndex = 0;
                        foreach (KeyValuePair<int, string> row in cboWx2.Items) {
                            if (row.Key == GlobalCode.CheckForNullInt(dt.Rows[i], "ATIS2")) {
                                cboWx2.SelectedIndex = cboWx2.Items.IndexOf(row);
                            }
                        }
                        if (cboWx3.Items.Count > 0)
                            cboWx3.SelectedIndex = 0;
                        foreach (KeyValuePair<int, string> row in cboWx3.Items) {
                            if (row.Key == GlobalCode.CheckForNullInt(dt.Rows[i], "ATIS3")) {
                                cboWx3.SelectedIndex = cboWx3.Items.IndexOf(row);
                            }
                        }
                        if (cboClearance.Items.Count > 0)
                            cboClearance.SelectedIndex = 0;
                        foreach (KeyValuePair<int, string> row in cboWx1.Items) {
                            if (row.Key == (int)dt.Rows[i]["PDC"]) {
                                cboClearance.SelectedIndex = cboWx1.Items.IndexOf(row);
                            }
                        }
                        cboData2.Text = GlobalCode.CheckForNullString(dt.Rows[i], "ATA_CODE");
                        cboData3.Text = GlobalCode.CheckForNullString(dt.Rows[i], "SOP_PHASE");
                        txtData6.Text = (string)dt.Rows[i]["ACTIONTITLE"];
                        txtData7.Text = (string)dt.Rows[i]["ACTIONS"];
                        txtData8.Text = (string)dt.Rows[i]["COMM"];
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

        private DateTime GetDateWithoutMilliseconds(DateTime d) {
            return new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
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

        private void cboSelect_SelectedIndexChanged(object sender, EventArgs e) {
           FillData();
        }
        private void Clear_Entries() {
            try {
                cboPF1.SelectedIndex = 0;
                if (cboClearance.Items.Count > 0)
                    cboClearance.SelectedIndex = 0;
                if (cboWx1.Items.Count > 0)
                    cboWx1.SelectedIndex = 0;
                cboData2.SelectedIndex = 0;
                cboData3.SelectedIndex = 0;
                txtName.Text = "";
                txtData6.Text = "";
                txtData7.Text = "";
                txtData8.Text = "";
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
                dr["ACTION_NAME"] = txtName.Text;
                dr["DATE_CREATED"] = GetDateString(DateTime.Now);
                dr["DATE_EDITED"] = GetDateString(DateTime.Now);
                dr["ATA_CODE"] = cboData2.Text;
                dr["SOP_PHASE"] = cboData3.Text;
                dr["PF"] = Get_Selected_Key(cboPF1);
                dr["ACTIONTITLE"] = txtData6.Text;
                dr["ACTIONS"] = txtData7.Text;
                dr["COMM"] = txtData8.Text;
                dr["ATIS1"] = Get_Selected_Key(cboWx1);
                dr["ATIS2"] = Get_Selected_Key(cboWx2);
                dr["ATIS3"] = Get_Selected_Key(cboWx3);
                dr["PDC"] = Get_Selected_Key(cboClearance);

                // additional fields
                for (int x = 1; x < 11; x++) {
                    dr["A" + x] = "";
                }

                dtTable.Rows.Add(dr);
                dataAdapter.Update(dtTable);  // write new row back to database

                iSelected = cboSelect.Items.Count;
                //Clear_Entries();
                Fill_CBOs(cboSelect, "SELECT ID, ACTION_NAME FROM Actions ORDER BY ID", true);

            } catch (Exception) {

                throw;
            }
        }
        private void UpdateDataRow() {
            try {
                if (Get_Selected_Key(cboSelect) > -1) {
                    string strUpdate = "UPDATE Actions SET " +
                        "ACTION_NAME = @cond_name," +
                        "DATE_EDITED = @date_edited," +
                        "PF = @pf," +
                        "ATA_CODE = @ata_code," +
                        "SOP_PHASE = @sop_phase," +
                        "ACTIONTITLE = @actiontitle," +
                        "ACTIONS = @actions," +
                        "COMM = @comm," +
                        "ATIS1 = @atis1," +
                        "ATIS2 = @atis2," +
                        "ATIS3 = @atis3," +
                        "PDC = @pdc," +

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

                    cmd.Parameters.AddWithValue("@cond_name", txtName.Text);
                    cmd.Parameters.AddWithValue("@date_edited", GetDateString(DateTime.Now));
                    cmd.Parameters.AddWithValue("@pf", Get_Selected_Key(cboPF1));

                    cmd.Parameters.AddWithValue("@ata_code", cboData2.Text);
                    cmd.Parameters.AddWithValue("@sop_phase", cboData3.Text);

                    cmd.Parameters.AddWithValue("@actiontitle", txtData6.Text);
                    cmd.Parameters.AddWithValue("@actions", txtData7.Text);
                    cmd.Parameters.AddWithValue("@comm", txtData8.Text);
                    cmd.Parameters.AddWithValue("@atis1", Get_Selected_Key(cboWx1));
                    cmd.Parameters.AddWithValue("@atis2", Get_Selected_Key(cboWx2));
                    cmd.Parameters.AddWithValue("@atis3", Get_Selected_Key(cboWx3));
                    cmd.Parameters.AddWithValue("@pdc", Get_Selected_Key(cboClearance));

                    // additional fields
                    for (int x = 1; x < 11; x++) {
                        cmd.Parameters.AddWithValue("@a" + x, "");
                    }

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
            // Update the database with the user's changes.
            UpdateDataRow();
            Fill_CBOs(cboSelect, "SELECT ID, ACTION_NAME FROM Actions ORDER BY ID",true);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Delete_Entry() {
            try {
                iSelected = Get_Selected_Key(cboSelect);
                if (iSelected > -1) {

                    // search for use of this item in any existing spot
                    string sCommand = "SELECT SPOT_NAME, ACTION1,ACTION2,ACTION3,ACTION4,ACTION5,ACTION6,ACTION7,ACTION8 FROM Spots " +
                        "WHERE ACTION1 = " + iSelected +
                        " OR ACTION2 = " + iSelected +
                        " OR ACTION3 = " + iSelected +
                        " OR ACTION4 = " + iSelected +
                        " OR ACTION5 = " + iSelected +
                        " OR ACTION6 = " + iSelected +
                        " OR ACTION7 = " + iSelected +
                        " OR ACTION8 = " + iSelected;
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
                            "The ACTIONS selected can not be deleted because it is used in the following " + iCount + " SPOTS: " + sSpots,
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
                        string sQuery = "DELETE FROM Actions WHERE ID=" + Get_Selected_Key(cboSelect);
                        conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
                        conn.Open();
                        OleDbCommand commandBuilder = new OleDbCommand(sQuery, conn);
                        commandBuilder.ExecuteNonQuery();
                        conn.Close();
                        Fill_CBOs(cboSelect, "SELECT ID, ACTION_NAME FROM Actions ORDER BY ID",true);
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
        }

        private void txtName_Leave(object sender, EventArgs e) {
            Check_Complete();
        }
        private void Check_Complete() {
            try {
                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnClear.Enabled = false;
                if (txtName.Text != "" && cboPF1.Text != "" && txtData6.Text != "" && (txtData7.Text != "" || txtData8.Text != "")) {
                    this.AcceptButton = btnSave;
                    if (cboSelect.SelectedIndex > 0) {
                        btnUpdate.Enabled = true;
                        this.AcceptButton = btnUpdate;
                        btnDelete.Enabled = true;
                    }
                    btnSave.Enabled = true;
                    btnClear.Enabled = true;
                }
            } catch (Exception) {
                throw;
            }
        }
        private void btnAddWxConditions_Click(object sender, EventArgs e) {
            frmEditWxConditions frmEditWxConditions = new frmEditWxConditions();
            frmEditWxConditions.ShowDialog();
            // save ID of selected item (NOT the selectedindex)
            int iID = GetCboID(cboWx1);
            Fill_WX(cboWx1, "SELECT * FROM Conditions_WX ORDER BY STATION,ATIS_DESIGNATOR");
            // return from re-filling the cbo, set to index 0 by default
            SetCboID(cboWx1, iID);
        }
        private int GetCboID(ComboBox comboBox) {
            int iID = -1;
            if (comboBox.SelectedIndex > 0) {
                // save ID of selected item (NOT the selectedindex)
                KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)comboBox.SelectedItem;
                if (selectedPair.Key > -1)
                    iID = selectedPair.Key;
            }
            return iID;
        }
        private void SetCboID(ComboBox comboBox, int iID) {
            comboBox.SelectedIndex = 0;
            // try to set the cbo back to the previously selected item by looking for its ID (NOT the selectedindex)
            foreach (KeyValuePair<int, string> keyID in comboBox.Items) {
                if (keyID.Key == iID) {
                    // match found (has not been deleted)
                    comboBox.SelectedIndex = comboBox.Items.IndexOf(keyID);
                }
            }
        }

        private void btnAddClearance_Click(object sender, EventArgs e) {
            frmEditClearance frmEditClearance = new frmEditClearance();
            frmEditClearance.ShowDialog();
            // save ID of selected item (NOT the selectedindex)
            int iID = GetCboID(cboClearance);
            Fill_CBO_Clearance(cboClearance, "SELECT * FROM Clearance ORDER BY DEP, CLEARANCE_NAME");
            // return from re-filling the cbo, set to index 0 by default
            SetCboID(cboClearance, iID);
        }

        private void cboPF1_SelectedIndexChanged(object sender, EventArgs e) {
            Check_Complete();
        }

        private void txtData6_TextChanged(object sender, EventArgs e) {
            Check_Complete();
        }

        private void txtData7_TextChanged(object sender, EventArgs e) {
            Check_Complete();
        }
    }
}
