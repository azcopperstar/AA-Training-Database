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
    public partial class frmEditManeuver : Form {
        public frmEditManeuver() {
            InitializeComponent();
        }

        private OleDbConnection conn;
        private OleDbDataAdapter dataAdapter;
        DataTable dtTable;

        int iSelected = 0;

        private void frmEditManeuver_Load(object sender, EventArgs e) {
            Initialize_DB();
            FillData();
            Fill_CBOs(cboSelect, "SELECT ID,MANEUVER_NAME FROM Maneuver ORDER BY MANEUVER_NAME");

            if (cboSelect.Items.Count > 1) {
                cboSelect.SelectedIndex = 0;
                cboSelect.DroppedDown = true;
            }
        }
        private void Initialize_DB() {
            try {
                string sQuery = "SELECT * FROM Maneuver";
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

        }
        private DataTable Get_Selected_DataTable(ComboBox comboBox, string sTable) {
            DataTable dt = new DataTable();
            // Get the selected item in the combobox
            KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)comboBox.SelectedItem;
            if (selectedPair.Key > -1) {
                string sCommand = "SELECT * FROM " + sTable + " WHERE ID = " + selectedPair.Key;
                conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
                dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dAdapter.Fill(dt);
                conn.Close();
            }
            return dt;
        }
        private void FillData() {
            try {
                // clear all entries
                Clear_Entries();

                int iSelected = Get_Selected_Key(cboSelect);
                if (cboSelect.SelectedIndex > 0 || iSelected > -1) {
                    string sCommand = "SELECT * FROM Maneuver WHERE ID = " + iSelected;
                    conn.Open();
                    OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
                    DataTable dt = new DataTable();
                    dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dAdapter.Fill(dt);
                    conn.Close();

                    for (int i = 0; i <= dt.Rows.Count - 1; i++) {

                        txtName.Text = GlobalCode.CheckForNullString(dt.Rows[i], "MANEUVER_NAME");

                        string sDate = "CREATED: " + (string)dt.Rows[i]["DATE_CREATED"];
                        sDate = sDate + "\r\nEDITED: " + (string)dt.Rows[i]["DATE_EDITED"];
                        txtDate.Text = sDate;

                        cboData2.Text= GlobalCode.CheckForNullString(dt.Rows[i], "ATA_CODE");
                        cboData3.Text = GlobalCode.CheckForNullString(dt.Rows[i], "SOP_PHASE");

                        txtData4.Text = GlobalCode.CheckForNullString(dt.Rows[i],"MANEUVER");
                        txtData5.Value = GlobalCode.CheckForNullInt(dt.Rows[i], "MINUTES");
                        txtData6.Text = GlobalCode.CheckForNullString(dt.Rows[i], "OBJECTIVE1");
                        txtData7.Text = GlobalCode.CheckForNullString(dt.Rows[i], "OBJECTIVE2");
                        txtData8.Text = GlobalCode.CheckForNullString(dt.Rows[i], "SCOPE1");
                        txtData9.Text = GlobalCode.CheckForNullString(dt.Rows[i], "SCOPE2");
                        txtData10.Text = GlobalCode.CheckForNullString(dt.Rows[i], "SIM_POSITION");
                        txtData11.Text = GlobalCode.CheckForNullString(dt.Rows[i], "SIM_SETUP1");
                        txtData12.Text = GlobalCode.CheckForNullString(dt.Rows[i], "SIM_SETUP2");
                        txtData13.Text = GlobalCode.CheckForNullString(dt.Rows[i], "SIM_SETUP3");
                        txtData14.Text = GlobalCode.CheckForNullString(dt.Rows[i], "SIM_SETUP4");
                        txtData15.Text = GlobalCode.CheckForNullString(dt.Rows[i], "NOTES_1");
                        txtData16.Text = GlobalCode.CheckForNullString(dt.Rows[i], "NOTES_2");
                        txtData17.Text = GlobalCode.CheckForNullString(dt.Rows[i], "NOTES_3");
                        txtData18.Text = GlobalCode.CheckForNullString(dt.Rows[i], "NOTES_4");

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
        private void Clear_Entries() {
            try {
                txtName.Text = "";
                cboData2.SelectedIndex = 0;
                cboData3.SelectedIndex = 0;
                txtData4.Text = "";
                txtData5.Value = 5;
                txtData6.Text = "";
                txtData7.Text = "";
                txtData8.Text = "";
                txtData9.Text = "";
                txtData10.Text = "";
                txtData11.Text = "";
                txtData12.Text = "";
                txtData13.Text = "";
                txtData14.Text = "";
                txtData15.Text = "";
                txtData16.Text = "";
                txtData17.Text = "";
                txtData18.Text = "";

                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnClear.Enabled = false;

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

        private void cboSelect_SelectedIndexChanged(object sender, EventArgs e) {
            FillData();
        }

        private void Save() {
            System.Data.DataRow dr = dtTable.NewRow();
            dr["MANEUVER_NAME"] = txtName.Text;
            dr["DATE_CREATED"] = GetDateString(DateTime.Now);
            dr["DATE_EDITED"] = GetDateString(DateTime.Now);
            dr["ATA_CODE"] = cboData2.Text;
            dr["SOP_PHASE"] = cboData3.Text;
            dr["MANEUVER"] = txtData4.Text;
            dr["MINUTES"] = txtData5.Value;
            dr["OBJECTIVE1"] = txtData6.Text;
            dr["OBJECTIVE2"] = txtData7.Text;
            dr["SCOPE1"] = txtData8.Text;
            dr["SCOPE2"] = txtData9.Text;
            dr["SIM_POSITION"] = txtData10.Text;

            dr["SIM_SETUP1"] = txtData11.Text;
            dr["SIM_SETUP2"] = txtData12.Text;
            dr["SIM_SETUP3"] = txtData13.Text;
            dr["SIM_SETUP4"] = txtData14.Text;
            dr["NOTES_1"] = txtData15.Text;
            dr["NOTES_2"] = txtData16.Text;
            dr["NOTES_3"] = txtData17.Text;
            dr["NOTES_4"] = txtData18.Text;

            // unused
            dr["SPOT"] = "";

            dr["SETUP_2"] = "";
            dr["SETUP_3"] = "";
            dr["SETUP_4"] = "";

            dr["ACTIONS1"] = 0;
            dr["ACTIONS2"] = 0;
            dr["ACTIONS3"] = 0;
            dr["ACTIONS4"] = 0;
            dr["ACTIONS5"] = 0;
            dr["ACTIONS6"] = 0;
            dr["ACTIONS7"] = 0;
            dr["ACTIONS8"] = 0;
            dr["ACTIONS9"] = 0;
            dr["ACTIONS10"] = 0;

            dr["FOOTER_TEXT"] = "";

            // additional fields
            for (int x = 1; x < 11; x++) {
                dr["A" + x] = "";
            }

            dtTable.Rows.Add(dr);
            dataAdapter.Update(dtTable);  // write new row back to database

            iSelected = cboSelect.Items.Count;
            //Clear_Entries();
            //FillData();
            Fill_CBOs(cboSelect, "SELECT ID,MANEUVER_NAME FROM Maneuver ORDER BY MANEUVER_NAME");
            Clear_Entries();
        }
        private void UpdateDataRow() {
            try {
                if (Get_Selected_Key(cboSelect) > -1) {
                    string strUpdate = "UPDATE Maneuver SET " +
                        "MANEUVER_NAME = @cond_name," +
                        "DATE_EDITED = @date_edited," +
                        "ATA_CODE = @ata_code," +
                        "SOP_PHASE = @sop_phase," +
                        "MANEUVER = @maneuver," +
                        "MINUTES = @minutes," +
                        "OBJECTIVE1 = @objective1," +
                        "OBJECTIVE2 = @objective2," +

                        "SCOPE1 = @scope1," +
                        "SCOPE2 = @scope2," +

                        "SIM_POSITION = @sim_position," +

                        "SIM_SETUP1 = @sim_setup1," +
                        "SIM_SETUP2 = @sim_setup2," +
                        "SIM_SETUP3 = @sim_setup3," +
                        "SIM_SETUP4 = @sim_setup4," +

                        "NOTES_1 = @notes1," +
                        "NOTES_2 = @notes2," +
                        "NOTES_3 = @notes3," +
                        "NOTES_4 = @notes4," +

                        "SPOT = @spot," +
                        "SETUP_2 = @setup2," +
                        "SETUP_3 = @setup3," +
                        "SETUP_4 = @setup4," +

                        "ACTIONS1 = @actions1," +
                        "ACTIONS2 = @actions2," +
                        "ACTIONS3 = @actions3," +
                        "ACTIONS4 = @actions4," +
                        "ACTIONS5 = @actions5," +
                        "ACTIONS6 = @actions6," +
                        "ACTIONS7 = @actions7," +
                        "ACTIONS8 = @actions8," +
                        "ACTIONS9 = @actions9," +
                        "ACTIONS10 = @actions10," +

                        "FOOTER_TEXT = @footer_text," +

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

                    cmd.Parameters.AddWithValue("@ata_code", cboData2.Text);
                    cmd.Parameters.AddWithValue("@sop_phase", cboData3.Text);

                    cmd.Parameters.AddWithValue("@maneuver", txtData4.Text);
                    cmd.Parameters.AddWithValue("@minutes", txtData5.Value);
                    cmd.Parameters.AddWithValue("@objective1", txtData6.Text);
                    cmd.Parameters.AddWithValue("@objective2", txtData7.Text);

                    cmd.Parameters.AddWithValue("@scope1", txtData8.Text);
                    cmd.Parameters.AddWithValue("@scope2", txtData9.Text);

                    cmd.Parameters.AddWithValue("@sim_position", txtData10.Text);

                    cmd.Parameters.AddWithValue("@sim_setup1", txtData11.Text);
                    cmd.Parameters.AddWithValue("@sim_setup2", txtData12.Text);
                    cmd.Parameters.AddWithValue("@sim_setup3", txtData13.Text);
                    cmd.Parameters.AddWithValue("@sim_setup4", txtData14.Text);

                    cmd.Parameters.AddWithValue("@notes1", txtData15.Text);
                    cmd.Parameters.AddWithValue("@notes2", txtData16.Text);
                    cmd.Parameters.AddWithValue("@notes3", txtData17.Text);
                    cmd.Parameters.AddWithValue("@notes4", txtData18.Text);

                    cmd.Parameters.AddWithValue("@spot", "");

                    cmd.Parameters.AddWithValue("@setup2", "");
                    cmd.Parameters.AddWithValue("@setup3", "");
                    cmd.Parameters.AddWithValue("@setup4", "");

                    cmd.Parameters.AddWithValue("@actions1", 0);
                    cmd.Parameters.AddWithValue("@actions2", 0);
                    cmd.Parameters.AddWithValue("@actions3", 0);
                    cmd.Parameters.AddWithValue("@actions4", 0);
                    cmd.Parameters.AddWithValue("@actions5", 0);
                    cmd.Parameters.AddWithValue("@actions6", 0);
                    cmd.Parameters.AddWithValue("@actions7", 0);
                    cmd.Parameters.AddWithValue("@actions8", 0);
                    cmd.Parameters.AddWithValue("@actions9", 0);
                    cmd.Parameters.AddWithValue("@actions10", 0);

                    cmd.Parameters.AddWithValue("@footer_text", "");

                    // additional fields
                    for (int x = 1; x < 11; x++) {
                        cmd.Parameters.AddWithValue("@a" + x, "");
                    }

                    cmd.Parameters.AddWithValue("@id", Get_Selected_Key(cboSelect));

                    conn.Open();
                    int iRows = cmd.ExecuteNonQuery();
                    conn.Close();

                    Fill_CBOs(cboSelect, "SELECT ID,MANEUVER_NAME FROM Maneuver ORDER BY MANEUVER_NAME");
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


        private void Delete_Entry() {
            iSelected = Get_Selected_Key(cboSelect);
            if (iSelected > -1) {

                // search for use of this item in any existing spot
                string sCommand = "SELECT SPOT_NAME, MANEUVER FROM Spots WHERE MANEUVER = " + iSelected;
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
                        "The 'MANEUVER' selected can not be deleted because it is used in the following " + iCount + " SPOTS: " + sSpots,
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
                    string sQuery = "DELETE FROM Maneuver WHERE ID=" + Get_Selected_Key(cboSelect);
                    conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
                    conn.Open();
                    OleDbCommand commandBuilder = new OleDbCommand(sQuery, conn);
                    commandBuilder.ExecuteNonQuery();
                    conn.Close();
                    Clear_Entries();
                    Fill_CBOs(cboSelect, "SELECT ID,MANEUVER_NAME FROM Maneuver ORDER BY MANEUVER_NAME");
                }
            }
        }
        private void Check_Complete() {
            try {
                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnClear.Enabled = false;
                if (txtName.Text != "" && txtData4.Text != "" && txtData5.Value > 0) {
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

        private void btnCancel_Click_1(object sender, EventArgs e) {
            this.Close();
        }
        private void btnSave_Click_1(object sender, EventArgs e) {
            Save();
        }
        private void btnUpdate_Click_1(object sender, EventArgs e) {
            UpdateDataRow();
            Fill_CBOs(cboSelect, "SELECT ID,MANEUVER_NAME FROM Maneuver ORDER BY ID");
        }
        private void btnDelete_Click_1(object sender, EventArgs e) {
            Delete_Entry();
        }
        private void btnClear_Click(object sender, EventArgs e) {
            Clear_Entries();
        }

        private void txtName_TextChanged(object sender, EventArgs e) {
            Check_Complete();
        }

        private void txtData4_TextChanged(object sender, EventArgs e) {
            Check_Complete();
        }
    }
}
