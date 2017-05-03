using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    public partial class frmEditACConditions : Form {
        public frmEditACConditions() {
            InitializeComponent();
        }

        private static OleDbConnection conn;
        private OleDbDataAdapter dataAdapter;
        DataTable dtTable;
        //private BindingSource bindingSource1;

        private void frmEditACConditions_Load(object sender, EventArgs e) {
            try {
                Initialize_DB();
                Fill_CBOs(cboSelect, "SELECT ID, COND_NAME FROM Conditions_AC ORDER BY ID");
                Fill_CBO_Flap();
                if (cboSelect.Items.Count > 1) {
                    cboSelect.SelectedIndex = 0;
                    cboSelect.DroppedDown = true;
                }
            } catch (Exception) {
                throw;
            }
        }

        private void Fill_CBO_Flap() {
            cboFlaps.Items.Add("0");
            cboFlaps.Items.Add("1");
            cboFlaps.Items.Add("2");
            cboFlaps.Items.Add("3");

        }
        private void Initialize_DB() {
            try {
                string sQuery = "SELECT * FROM Conditions_AC";
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
                    string sCommand = "SELECT * FROM CONDITIONS_AC WHERE ID = " + iSelected;
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

                        txtTOW.Text= Format_Decimal_1((string)dt.Rows[i]["GTOW"]);
                        txtTOWCG.Value = Convert.ToDecimal((Single)dt.Rows[i]["TOWCG"]);
                        cboFlaps.Text = dt.Rows[i]["FLAPS"].ToString();
                        txtCI.Value = (int)dt.Rows[i]["CI"];
                        txtZFW.Value = Convert.ToDecimal((Single)dt.Rows[i]["ZFW"]);
                        txtZFWCG.Value = Convert.ToDecimal((Single)dt.Rows[i]["ZFWCG"]);
                        txtV1.Value = (int)dt.Rows[i]["V1"];
                        txtV2.Value = (int)dt.Rows[i]["V2"];
                        txtVR.Value = (int)dt.Rows[i]["VR"];
                        if ((int)dt.Rows[i]["FLEX"] == 1) {
                            optFLEX.Checked = true;
                            txtThrust.Value = (int)dt.Rows[i]["THRUST"];
                        } else {
                            optFLEX.Checked = false;
                            txtThrust.Value = 0;
                        }
                        txtFuel.Value = Convert.ToDecimal((Single)dt.Rows[i]["FUEL"]);
                        txtFuelTaxi.Value = Convert.ToDecimal((Single)dt.Rows[i]["FUEL_TAXI"]);
                        txtReserve.Value = (int)dt.Rows[i]["RESERVE"];

                        txtStab.Value = Convert.ToDecimal((Single)dt.Rows[i]["STAB"]);
                        optStabPercent.Checked = true;
                        if ((string)dt.Rows[i]["A1"] == "UP") {
                            optStabUp.Checked = true;
                        } else if ((string)dt.Rows[i]["A1"] == "DN") {
                            optStabDn.Checked = true;
                        }

                        txtPAX.Value = (int)dt.Rows[i]["PAX"];
                        txtCRZFL.Value = (int)dt.Rows[i]["CRZALT"];
                        txtTRA.Value = (int)dt.Rows[i]["THRUST_RED_ALT"];
                        txtAcelAlt.Value = (int)dt.Rows[i]["ACCEL_ALT"];
                        txtEoAccelAlt.Value = (int)dt.Rows[i]["EO_ACCEL_ALT"];

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

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            try {
                System.Data.DataRow dr = dtTable.NewRow();
                dr["COND_NAME"] = txtName.Text;
                dr["DATE_CREATED"] = GetDateString(DateTime.Now);
                dr["DATE_EDITED"] = GetDateString(DateTime.Now);
                dr["GTOW"] = Format_Decimal_1(txtTOW.Text);
                dr["TOWCG"] = txtTOWCG.Value;
                dr["FLAPS"] = cboFlaps.Text;
                dr["CI"] = txtCI.Value;
                dr["ZFW"] = txtZFW.Value;
                dr["ZFWCG"] = txtZFWCG.Value;
                dr["V1"] = txtV1.Value;
                dr["V2"] = txtV2.Value;
                dr["VR"] = txtVR.Value;
                dr["THRUST"] = txtThrust.Value;
                dr["FUEL"] = txtFuel.Value;
                dr["FUEL_TAXI"] = txtFuelTaxi.Value;
                dr["RESERVE"] = txtReserve.Value;
                dr["STAB"] = txtStab.Value;
                dr["PAX"] = txtPAX.Value;
                dr["CRZALT"] = txtCRZFL.Value;
                dr["THRUST_RED_ALT"] = txtTRA.Value;
                dr["ACCEL_ALT"] = txtAcelAlt.Value;
                dr["EO_ACCEL_ALT"] = txtEoAccelAlt.Value;
                if (optFLEX.Checked) {
                    dr["FLEX"] = 1;
                } else {
                    dr["FLEX"] = 0;
                }
                dr["RT_RESERVE_PERCENT"] = 0;
                dr["RT_RESERVE_AMOUNT"] = 0;
                if (optStabDn.Checked) {
                    dr["A1"] = "DN";
                } else if (optStabPercent.Checked) {
                    dr["A1"] = "%";
                } else if (optStabUp.Checked) {
                    dr["A1"] = "UP";
                }

                // additional fields
                for (int x = 2; x < 11; x++) {
                    dr["A" + x] = "";
                }

                dtTable.Rows.Add(dr);
                dataAdapter.Update(dtTable);  // write new row back to database
                iSelected = cboSelect.Items.Count;
                Fill_CBOs(cboSelect, "SELECT ID, COND_NAME FROM Conditions_AC ORDER BY ID");
                cboSelect.SelectedIndex = 0;
            } catch (Exception) {
                throw;
            }
        }
        private void UpdateDataRow() {
            if (Get_Selected_Key(cboSelect) > -1) {
                string strUpdate = "UPDATE Conditions_AC SET " +
                    "COND_NAME = @cond_name," +
                    "DATE_EDITED = @date_edited," +
                    "GTOW = @gtow," +
                    "TOWCG = @towcg," +
                    "FLAPS = @flaps," +
                    "CI = @ci," +
                    "ZFW = @zfw," +
                    "ZFWCG = @zfwcg," +
                    "V1 = @v1," +
                    "V2 = @v2," +
                    "VR = @vr," +
                    "THRUST = @thrust," +
                    "FUEL = @fuel," +
                    "FUEL_TAXI = @fuel_taxi," +
                    "RESERVE = @reserve," +
                    "STAB = @stab," +
                    "PAX = @pax," +
                    "CRZALT = @crzalt," +
                    "THRUST_RED_ALT = @thrust_red_alt," +
                    "ACCEL_ALT = @accel_alt," +
                    "EO_ACCEL_ALT = @eo_accel_alt," +
                    "FLEX = @flex," +
                    "RT_RESERVE_PERCENT = @rt_reserve_percent," +
                    "RT_RESERVE_AMOUNT = @rt_reserve_amount," +

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
                cmd.Parameters.AddWithValue("@gtow", Format_Decimal_1(txtTOW.Text));
                cmd.Parameters.AddWithValue("@towcg", txtTOWCG.Value);
                cmd.Parameters.AddWithValue("@flaps", cboFlaps.Text);
                cmd.Parameters.AddWithValue("@ci", txtCI.Value);
                cmd.Parameters.AddWithValue("@zfw", txtZFW.Value);
                cmd.Parameters.AddWithValue("@zfwcg", txtZFWCG.Value);
                cmd.Parameters.AddWithValue("@v1", txtV1.Value);
                cmd.Parameters.AddWithValue("@v2", txtV2.Value);
                cmd.Parameters.AddWithValue("@vr", txtVR.Value);
                cmd.Parameters.AddWithValue("@thrust", txtThrust.Value);
                cmd.Parameters.AddWithValue("@fuel", txtFuel.Value);
                cmd.Parameters.AddWithValue("@fuel_taxi", txtFuelTaxi.Value);
                cmd.Parameters.AddWithValue("@reserve", txtReserve.Value);
                cmd.Parameters.AddWithValue("@stab", txtStab.Value);
                cmd.Parameters.AddWithValue("@pax", txtPAX.Value);
                cmd.Parameters.AddWithValue("@crzalt", txtCRZFL.Value);
                cmd.Parameters.AddWithValue("@thrust_red_alt", txtTRA.Value);
                cmd.Parameters.AddWithValue("@accel_alt", txtAcelAlt.Value);
                cmd.Parameters.AddWithValue("@eo_accel_alt", txtEoAccelAlt.Value);
                if (optFLEX.Checked) {
                    cmd.Parameters.AddWithValue("@flex", 1);
                } else {
                    cmd.Parameters.AddWithValue("@flex", 0);
                }
                cmd.Parameters.AddWithValue("@rt_reserve_percent", 0);
                cmd.Parameters.AddWithValue("@rt_reserve_amount", 0);

                if (optStabDn.Checked) {
                    cmd.Parameters.AddWithValue("@a1", "DN");
                } else if (optStabPercent.Checked) {
                    cmd.Parameters.AddWithValue("@a1", "%");
                } else if (optStabUp.Checked) {
                    cmd.Parameters.AddWithValue("@a1", "UP");
                }

                // additional fields
                for (int x = 2; x < 11; x++) {
                    cmd.Parameters.AddWithValue("@a" + x, "");
                }

                cmd.Parameters.AddWithValue("@id", Get_Selected_Key(cboSelect));

                conn.Open();
                int iRows = cmd.ExecuteNonQuery();
                conn.Close();

                //if (iRows > 0) {
                //    MessageBox.Show("Update Success!");
                //}
            }
        }

        private void Clear_Entries() {
            try {
                txtName.Text = "";
                txtTOW.Text = "0.0";
                txtTOWCG.Value = 30;
                cboFlaps.Text = "1";
                txtCI.Value = 0;
                txtZFW.Value = 0;
                txtZFWCG.Value = 30;
                txtV1.Value = 0;
                txtV2.Value = 0;
                txtVR.Value = 0;
                txtThrust.Value = 0;
                txtFuel.Value = 10;
                txtReserve.Value = 45;
                txtStab.Value = 30;
                optStabPercent.Checked = true;
                txtPAX.Value = 0;
                txtCRZFL.Value = 300;
                txtTRA.Value = 1000;
                txtAcelAlt.Value = 1000;
                txtEoAccelAlt.Value = 1000;
                optFLEX.Checked = true;

                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnClear.Enabled = false;
            } catch (Exception) {
                throw;
            }        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            // Update the database with the user's changes.
            UpdateDataRow();
        }

        int iSelected = 0;
        private void cboAcConditions_SelectedIndexChanged(object sender, EventArgs e) {
            FillData();
        }
        private void Delete_Entry() {
            try {
                iSelected = Get_Selected_Key(cboSelect);
                if (iSelected > -1) {
                    // search for use of this item in any existing spot
                    string sCommand = "SELECT SPOT_NAME, CONDITIONS_AC FROM Spots WHERE CONDITIONS_AC = " + iSelected;
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
                            "The AIRCRAFT CONDITIONS selected can not be deleted because it is used in the following " + iCount + " SPOTS: " + sSpots,
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
                        string sQuery = "DELETE FROM Conditions_AC WHERE ID=" + Get_Selected_Key(cboSelect);
                        conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
                        conn.Open();
                        OleDbCommand commandBuilder = new OleDbCommand(sQuery, conn);
                        commandBuilder.ExecuteNonQuery();
                        conn.Close();
                        Clear_Entries();
                        Fill_CBOs(cboSelect, "SELECT ID, COND_NAME FROM Conditions_AC ORDER BY ID");
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

        private void txtData16_Leave(object sender, EventArgs e) {
            try {
                if (txtAcelAlt.Text == "")
                    txtAcelAlt.Text = txtTRA.Text;
                if (txtEoAccelAlt.Text == "")
                    txtEoAccelAlt.Text = txtTRA.Text;
            } catch (Exception) {
                throw;
            }        }

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


        private string Format_Decimal_1(string sInput) {
            if (sInput.IndexOf(".") < 0) {
                // add decimal
                sInput = sInput + ".0";
            }
            return sInput;
        }

        private void Calc_TOW() {
            txtTOW.Text = Format_Decimal_1((txtZFW.Value + txtFuel.Value - txtFuelTaxi.Value).ToString());
        }

        private void txtZFW_Leave(object sender, EventArgs e) {
            Calc_TOW();
        }
        private void txtZFW_ValueChanged(object sender, EventArgs e) {
            Calc_TOW();
        }
        private void txtFuel_ValueChanged(object sender, EventArgs e) {
            Calc_TOW();
        }
        private void txtFuel_Leave(object sender, EventArgs e) {
            Calc_TOW();
        }
        private void txtFuelTaxi_ValueChanged(object sender, EventArgs e) {
            Calc_TOW();
        }
        private void txtFuelTaxi_Leave(object sender, EventArgs e) {
            Calc_TOW();
        }

        private void SelectAll_Numeric(object sender) {
            NumericUpDown curBox = sender as NumericUpDown;
            curBox.Select();
            curBox.Select(0, curBox.Text.Length);
        }

        private void txtZFW_Enter(object sender, EventArgs e) {
            SelectAll_Numeric(sender);
        }

        private void txtFuel_Enter(object sender, EventArgs e) {
            SelectAll_Numeric(sender);
        }

        private void txtFuelTaxi_Enter(object sender, EventArgs e) {
            SelectAll_Numeric(sender);
        }

        private void txtZFWCG_Enter(object sender, EventArgs e) {
            SelectAll_Numeric(sender);
        }

        private void txtReserve_Enter(object sender, EventArgs e) {
            SelectAll_Numeric(sender);
        }

        private void txtTOWCG_Enter(object sender, EventArgs e) {
            SelectAll_Numeric(sender);
        }

        private void txtRteRsv_Enter(object sender, EventArgs e) {
            SelectAll_Numeric(sender);
        }

        private void txtFuelAltn_Enter(object sender, EventArgs e) {
            SelectAll_Numeric(sender);
        }

        private void txtStab_Enter(object sender, EventArgs e) {
            SelectAll_Numeric(sender);
        }

        private void txtPAX_Enter(object sender, EventArgs e) {
            SelectAll_Numeric(sender);
        }

        private void txtCI_Enter(object sender, EventArgs e) {
            SelectAll_Numeric(sender);
        }

        private void txtV1_Enter(object sender, EventArgs e) {
            SelectAll_Numeric(sender);
        }

        private void txtVR_Enter(object sender, EventArgs e) {
            SelectAll_Numeric(sender);
        }

        private void txtV2_Enter(object sender, EventArgs e) {
            SelectAll_Numeric(sender);
        }

        private void txtThrust_Enter(object sender, EventArgs e) {
            SelectAll_Numeric(sender);
        }

        private void txtCRZFL_Enter(object sender, EventArgs e) {
            SelectAll_Numeric(sender);
        }

        private void txtTRA_Enter(object sender, EventArgs e) {
            SelectAll_Numeric(sender);
        }

        private void txtAcelAlt_Enter(object sender, EventArgs e) {
            SelectAll_Numeric(sender);
        }

        private void txtEoAccelAlt_Enter(object sender, EventArgs e) {
            SelectAll_Numeric(sender);
        }
    }
}
