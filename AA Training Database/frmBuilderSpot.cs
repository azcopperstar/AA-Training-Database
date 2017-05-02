using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1 {
    public partial class frmBuilderSpot : Form {
        public frmBuilderSpot() {
            InitializeComponent();
        }

        private OleDbConnection conn;
        DataSet ds = new DataSet();
        //private BindingSource bindingSource1;
        private OleDbDataAdapter dataAdapter;
        DataTable dtTable;

        private void frmEditScript_Load_1(object sender, EventArgs e) {
            //GlobalCode.sDataFile = "V:\\AA- Traing Script Developer Project\\TSD_A350.accdb";
            //GlobalCode.sOleDbConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + GlobalCode.sDataFile;

            this.Text = GlobalCode.sCARRIER + " " + GlobalCode.sFleet + this.Text;

            lblTBFilePath.Text = GlobalCode.sPATH_FILE_DATA;
            lblTBOutputPath.Text = GlobalCode.sPATH_PDF;
            lblTBFleet.Text = GlobalCode.sFleet;

            Initialize_DB();

            Fill_Spots();
            Fill_Wx();
            Fill_Ac();
            Fill_Clearance();
            Fill_Maneuver();
            Fill_Actions();
            Fill_PF();

            // set selected items to 0 by default
            cboAC.SelectedIndex = 0;
            //cboATIS.SelectedIndex = 0;
            if (cboClearance.Items.Count > 0)
                cboClearance.SelectedIndex = 0;
            cboManeuver.SelectedIndex = 0;
            //cboSpots.SelectedIndex = 0;
            cboWx.SelectedIndex = 0;

            cboAction1.SelectedIndex = 0;
            cboPF1.SelectedIndex = 0;
            cboAction2.SelectedIndex = 0;
            cboPF2.SelectedIndex = 0;
            cboAction3.SelectedIndex = 0;
            cboPF3.SelectedIndex = 0;
            cboAction4.SelectedIndex = 0;
            cboPF4.SelectedIndex = 0;
            cboAction5.SelectedIndex = 0;
            cboPF5.SelectedIndex = 0;
            cboAction6.SelectedIndex = 0;
            cboPF6.SelectedIndex = 0;
            cboAction7.SelectedIndex = 0;
            cboPF7.SelectedIndex = 0;
            cboAction8.SelectedIndex = 0;
            cboPF8.SelectedIndex = 0;

        }

        private void Initialize_DB() {

            string sQuery = "SELECT * FROM Spots";
            conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
            dataAdapter = new OleDbDataAdapter(sQuery, GlobalCode.sOleDbConnectionString);
            //bindingSource1 = new BindingSource();

            dtTable = new DataTable();
            dtTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            conn.Open();
            dataAdapter.Fill(dtTable);
            OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dataAdapter);
            conn.Close();
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
                data.Add(new KeyValuePair<int, string>((int)dt.Rows[i].ItemArray[0], (string)dt.Rows[i].ItemArray[1]));
            }
            // Bind the combobox
            cbo.DataSource = null;
            cbo.Items.Clear();
            cbo.DataSource = new BindingSource(data, null);
            cbo.DisplayMember = "Value";
            cbo.ValueMember = "Key";

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
                //data.Add(new KeyValuePair<int, string>(-1, ""));
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
        private void Fill_PF() {
            Fill_CBOs(cboPF1, "SELECT ID,PF FROM PF");
            Fill_CBOs(cboPF2, "SELECT ID,PF FROM PF");
            Fill_CBOs(cboPF3, "SELECT ID,PF FROM PF");
            Fill_CBOs(cboPF4, "SELECT ID,PF FROM PF");
            Fill_CBOs(cboPF5, "SELECT ID,PF FROM PF");
            Fill_CBOs(cboPF6, "SELECT ID,PF FROM PF");
            Fill_CBOs(cboPF7, "SELECT ID,PF FROM PF");
            Fill_CBOs(cboPF8, "SELECT ID,PF FROM PF");
        }
        private void Fill_Actions() {
            Fill_CBOs(cboAction1, "SELECT ID,ACTION_NAME FROM Actions");
            Fill_CBOs(cboAction2, "SELECT ID,ACTION_NAME FROM Actions");
            Fill_CBOs(cboAction3, "SELECT ID,ACTION_NAME FROM Actions");
            Fill_CBOs(cboAction4, "SELECT ID,ACTION_NAME FROM Actions");
            Fill_CBOs(cboAction5, "SELECT ID,ACTION_NAME FROM Actions");
            Fill_CBOs(cboAction6, "SELECT ID,ACTION_NAME FROM Actions");
            Fill_CBOs(cboAction7, "SELECT ID,ACTION_NAME FROM Actions");
            Fill_CBOs(cboAction8, "SELECT ID,ACTION_NAME FROM Actions");
        }

        private void Fill_Maneuver() {
            Fill_CBOs(cboManeuver, "SELECT ID,MANEUVER_NAME FROM Maneuver");
        }
        private void Fill_Wx() {
            Fill_WX(cboWx, "SELECT * FROM Conditions_WX ORDER BY STATION,ATIS_DESIGNATOR");
        }
        private void Fill_Ac() {
            Fill_CBOs(cboAC, "SELECT ID,COND_NAME FROM Conditions_AC");
        }
        private void Fill_Clearance() {
            Fill_CBO_Clearance(cboClearance, "SELECT * FROM Clearance ORDER BY DEP, CLEARANCE_NAME");
        }

        private void Fill_Spots() {
            string sCommand = "SELECT * FROM Spots WHERE ID>4";
            conn.Open();
            OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
            DataTable dt = new DataTable();
            dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dAdapter.Fill(dt);
            conn.Close();

            cboSpots.Items.Clear();
            cboSpots.DisplayMember = "Text";
            cboSpots.ValueMember = "Value";
            int i;
            cboSpots.Items.Add(new {
                Value = -1, Text = ""
            });
            for (i = 0; i <= dt.Rows.Count - 1; i++) {
                cboSpots.Items.Add(new {
                    Value = dt.Rows[i].ItemArray[0], Text = dt.Rows[i].ItemArray[1]
                });
            }
        }

        private void FillData() {

            ClearAllEntries();
            if (cboSpots.SelectedIndex > 0 || (cboSpots.SelectedItem as dynamic).Value > -1) {
                string sCommand = "SELECT * FROM Spots WHERE ID = " + (cboSpots.SelectedItem as dynamic).Value;
                conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
                DataTable dt = new DataTable();
                dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dAdapter.Fill(dt);
                conn.Close();

                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++) {
                    txtSpotName.Text = (string)dt.Rows[i].ItemArray[1];
                    txtNotes1.Text = (string)dt.Rows[i].ItemArray[11];
                    txtNotes2.Text = (string)dt.Rows[i].ItemArray[12];
                    txtNotes3.Text = (string)dt.Rows[i].ItemArray[13];

                    // search for value of index
                    foreach (KeyValuePair<int, string> row in cboManeuver.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[5]) {
                            cboManeuver.SelectedIndex = cboManeuver.Items.IndexOf(row);
                        }
                    }
                    txtMinutes.Value = (int)dt.Rows[i].ItemArray[6];
                    foreach (KeyValuePair<int, string> row in cboAC.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[7]) {
                            cboAC.SelectedIndex = cboAC.Items.IndexOf(row);
                        }
                    }
                    chkATIS.Checked = false;
                    if ((int)dt.Rows[i]["DISPLAY_ATIS"] == 1)
                        chkATIS.Checked = true;
                    txtATIS.Text = "";
                    chkPDC.Checked = false;
                    if ((int)dt.Rows[i]["DISPLAY_PDC"] == 1)
                        chkPDC.Checked = true;
                    foreach (KeyValuePair<int, string> row in cboWx.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[8]) {
                            cboWx.SelectedIndex = cboWx.Items.IndexOf(row);
                        }
                    }
                    foreach (KeyValuePair<int, string> row in cboClearance.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[10]) {
                            cboClearance.SelectedIndex = cboClearance.Items.IndexOf(row);
                        }
                    }

                    foreach (KeyValuePair<int, string> row in cboAction1.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[15]) {
                            cboAction1.SelectedIndex = cboAction1.Items.IndexOf(row);
                        }
                    }
                    foreach (KeyValuePair<int, string> row in cboPF1.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[14]) {
                            cboPF1.SelectedIndex = cboPF1.Items.IndexOf(row);
                        }
                    }
                    foreach (KeyValuePair<int, string> row in cboAction2.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[17]) {
                            cboAction2.SelectedIndex = cboAction2.Items.IndexOf(row);
                        }
                    }
                    foreach (KeyValuePair<int, string> row in cboPF2.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[16]) {
                            cboPF2.SelectedIndex = cboPF2.Items.IndexOf(row);
                        }
                    }
                    foreach (KeyValuePair<int, string> row in cboAction3.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[19]) {
                            cboAction3.SelectedIndex = cboAction3.Items.IndexOf(row);
                        }
                    }
                    foreach (KeyValuePair<int, string> row in cboPF3.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[18]) {
                            cboPF3.SelectedIndex = cboPF3.Items.IndexOf(row);
                        }
                    }
                    foreach (KeyValuePair<int, string> row in cboAction4.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[21]) {
                            cboAction4.SelectedIndex = cboAction4.Items.IndexOf(row);
                        }
                    }
                    foreach (KeyValuePair<int, string> row in cboPF4.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[20]) {
                            cboPF4.SelectedIndex = cboPF4.Items.IndexOf(row);
                        }
                    }
                    foreach (KeyValuePair<int, string> row in cboAction5.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[23]) {
                            cboAction5.SelectedIndex = cboAction5.Items.IndexOf(row);
                        }
                    }
                    foreach (KeyValuePair<int, string> row in cboPF5.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[22]) {
                            cboPF5.SelectedIndex = cboPF5.Items.IndexOf(row);
                        }
                    }
                    foreach (KeyValuePair<int, string> row in cboAction6.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[25]) {
                            cboAction6.SelectedIndex = cboAction6.Items.IndexOf(row);
                        }
                    }
                    foreach (KeyValuePair<int, string> row in cboPF6.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[24]) {
                            cboPF6.SelectedIndex = cboPF6.Items.IndexOf(row);
                        }
                    }
                    foreach (KeyValuePair<int, string> row in cboAction7.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[27]) {
                            cboAction7.SelectedIndex = cboAction7.Items.IndexOf(row);
                        }
                    }
                    foreach (KeyValuePair<int, string> row in cboPF7.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[26]) {
                            cboPF7.SelectedIndex = cboPF7.Items.IndexOf(row);
                        }
                    }
                    foreach (KeyValuePair<int, string> row in cboAction8.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[29]) {
                            cboAction8.SelectedIndex = cboAction8.Items.IndexOf(row);
                        }
                    }
                    foreach (KeyValuePair<int, string> row in cboPF8.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[28]) {
                            cboPF8.SelectedIndex = cboPF8.Items.IndexOf(row);
                        }
                    }
                }
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = true;
                btnClearData.Enabled = true;
            }
        }
        //private void Fill_Controls() {

        //    cboWx.DataBindings.Add("selectedindex", bindingSource1, "ATA_CODE");

        //    txtManeuver.DataBindings.Add("text", bindingSource1, "MANEUVER");
        //    txtMinutes.DataBindings.Add("text", bindingSource1, "MINUTES");


        //    cboPF1.DataBindings.Add("text", bindingSource1, "PF1");
        //    cboPF2.DataBindings.Add("text", bindingSource1, "PF2");
        //    cboPF3.DataBindings.Add("text", bindingSource1, "PF3");
        //    cboPF4.DataBindings.Add("text", bindingSource1, "PF4");
        //    cboPF5.DataBindings.Add("text", bindingSource1, "PF5");
        //    cboPF6.DataBindings.Add("text", bindingSource1, "PF6");
        //    cboPF7.DataBindings.Add("text", bindingSource1, "PF7");
        //    cboPF8.DataBindings.Add("text", bindingSource1, "PF8");


        //}


        private string GetDateString(DateTime d) {
            object value = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
            DateTime result = (DateTime)value;
            string sResult = result.ToString("M/d/yyyy HHmm");
            return sResult;
        }

        private Int32 Get_Selected_Key(ComboBox cbo) {
            ComboBox comboBox = (ComboBox)cbo;
            Int32 iKey = -1;
            if (comboBox.SelectedIndex == -1)
                return iKey;
            KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)comboBox.SelectedItem;
            iKey = selectedPair.Key;
            return iKey;
        }
        private void AddDataRow() {
            System.Data.DataRow dr = dtTable.NewRow();

            dr["SPOT_NAME"] = txtSpotName.Text;
            dr["DATE_CREATED"] = GetDateString(DateTime.Now);
            dr["DATE_EDITED"] = GetDateString(DateTime.Now);
            dr["SPOT"] = "";

            dr["MANEUVER"] = Get_Selected_Key(cboManeuver);//((KeyValuePair<int, string>)cboManeuver.SelectedItem).Key;
            dr["MINUTES"] = txtMinutes.Value;

            dr["CONDITIONS_AC"] = Get_Selected_Key(cboAC);
            dr["CONDITIONS_WX"] = Get_Selected_Key(cboWx);
            if (chkATIS.Checked) {
                dr["ATIS"] = 1;
                dr["DISPLAY_ATIS"] = 1;
            } else {
                dr["ATIS"] = 0;
                dr["DISPLAY_ATIS"] = 0;
            }
            if (chkPDC.Checked) {
                dr["DISPLAY_PDC"] = 1;
            } else {
                dr["DISPLAY_PDC"] = 1;
            }
            dr["CLEARANCE"] = Get_Selected_Key(cboClearance);

            dr["SPOT_NOTE_1"] = txtNotes1.Text;
            dr["SPOT_NOTE_2"] = txtNotes2.Text;
            dr["SPOT_NOTE_3"] = txtNotes3.Text;

            dr["PF1"] = Get_Selected_Key(cboPF1);
            dr["ACTION1"] = Get_Selected_Key(cboAction1);
            dr["PF2"] = Get_Selected_Key(cboPF2);
            dr["ACTION2"] = Get_Selected_Key(cboAction2);
            dr["PF3"] = Get_Selected_Key(cboPF3);
            dr["ACTION3"] = Get_Selected_Key(cboAction3);
            dr["PF4"] = Get_Selected_Key(cboPF4);
            dr["ACTION4"] = Get_Selected_Key(cboAction4);
            dr["PF5"] = Get_Selected_Key(cboPF5);
            dr["ACTION5"] = Get_Selected_Key(cboAction5);
            dr["PF6"] = Get_Selected_Key(cboPF6);
            dr["ACTION6"] = Get_Selected_Key(cboAction6);
            dr["PF7"] = Get_Selected_Key(cboPF7);
            dr["ACTION7"] = Get_Selected_Key(cboAction7);
            dr["PF8"] = Get_Selected_Key(cboPF8);
            dr["ACTION8"] = Get_Selected_Key(cboAction8);
            dr["PF9"] = -1;
            dr["ACTION9"] = -1;
            dr["PF10"] = -1;
            dr["ACTION10"] = -1;

            dtTable.Rows.Add(dr);
            dataAdapter.Update(dtTable);  // write new row back to database
            Fill_Spots();
        }
        private void UpdateDataRow() {

            if ((cboSpots.SelectedItem as dynamic).Value > -1) {
                string strUpdate = "UPDATE Spots SET " +
                    "SPOT_NAME = @spot_name," +
                    "DATE_EDITED = @date_edited," +
                    //"SPOT = @spot," +
                    "MANEUVER = @maneuver," +
                    "MINUTES = @minutes," +
                    "CONDITIONS_AC = @conditions_ac," +
                    "CONDITIONS_WX = @conditions_wx," +
                    "ATIS = @atis," +
                    "DISPLAY_ATIS = @display_atis," +
                    "CLEARANCE = @clearances," +
                    "DISPLAY_PDC = @display_pdc," +
                    "SPOT_NOTE_1 = @spot_note_1," +
                    "SPOT_NOTE_2 = @spot_note_2," +
                    "SPOT_NOTE_3 = @spot_note_3," +
                    "PF1 = @pf1," +
                    "ACTION1 = @actions1," +
                    "PF2 = @pf2," +
                    "ACTION2 = @actions2," +
                    "PF3 = @pf3," +
                    "ACTION3 = @actions3," +
                    "PF4 = @pf4," +
                    "ACTION4 = @actions4," +
                    "PF5 = @pf5," +
                    "ACTION5 = @actions5," +
                    "PF6 = @pf6," +
                    "ACTION6 = @actions6," +
                    "PF7 = @pf7," +
                    "ACTION7 = @actions7," +
                    "PF8 = @pf8," +
                    "ACTION8 = @actions8," +
                    "PF9 = @pf9," +
                    "ACTION9 = @actions9," +
                    "PF10 = @pf10," +
                    "ACTION10 = @actions10" +
                    " WHERE [ID] = @id";

                OleDbCommand cmd = new OleDbCommand(strUpdate, conn);

                cmd.Parameters.AddWithValue("@spot_name", txtSpotName.Text);
                cmd.Parameters.AddWithValue("@date_edited", GetDateString(DateTime.Now));
                //cmd.Parameters.AddWithValue("@spot", "");
                cmd.Parameters.AddWithValue("@maneuver", Get_Selected_Key(cboManeuver));
                cmd.Parameters.AddWithValue("@minutes", txtMinutes.Value);
                cmd.Parameters.AddWithValue("@conditions_ac", Get_Selected_Key(cboAC));
                cmd.Parameters.AddWithValue("@conditions_wx", Get_Selected_Key(cboWx));
                if (chkATIS.Checked) {
                    cmd.Parameters.AddWithValue("@atis", 1);
                    cmd.Parameters.AddWithValue("@display_atis", 1);
                } else {
                    cmd.Parameters.AddWithValue("@atis", 0);
                    cmd.Parameters.AddWithValue("@display_atis", 0);
                }
                cmd.Parameters.AddWithValue("@clearance", Get_Selected_Key(cboClearance));
                if (chkPDC.Checked) {
                    cmd.Parameters.AddWithValue("@display_pdc", 1);
                } else {
                    cmd.Parameters.AddWithValue("@display_pdc", 0);
                }
                cmd.Parameters.AddWithValue("@spot_note_1", txtNotes1.Text);
                cmd.Parameters.AddWithValue("@spot_note_2", txtNotes2.Text);
                cmd.Parameters.AddWithValue("@spot_note_3", txtNotes3.Text);
                cmd.Parameters.AddWithValue("@pf1", Get_Selected_Key(cboPF1));
                cmd.Parameters.AddWithValue("@actions1", Get_Selected_Key(cboAction1));
                cmd.Parameters.AddWithValue("@pf2", Get_Selected_Key(cboPF2));
                cmd.Parameters.AddWithValue("@actions2", Get_Selected_Key(cboAction2));
                cmd.Parameters.AddWithValue("@pf3", Get_Selected_Key(cboPF3));
                cmd.Parameters.AddWithValue("@actions3", Get_Selected_Key(cboAction3));
                cmd.Parameters.AddWithValue("@pf4", Get_Selected_Key(cboPF4));
                cmd.Parameters.AddWithValue("@actions4", Get_Selected_Key(cboAction4));
                cmd.Parameters.AddWithValue("@pf5", Get_Selected_Key(cboPF5));
                cmd.Parameters.AddWithValue("@actions5", Get_Selected_Key(cboAction5));
                cmd.Parameters.AddWithValue("@pf6", Get_Selected_Key(cboPF6));
                cmd.Parameters.AddWithValue("@actions6", Get_Selected_Key(cboAction6));
                cmd.Parameters.AddWithValue("@pf7", Get_Selected_Key(cboPF7));
                cmd.Parameters.AddWithValue("@actions7", Get_Selected_Key(cboAction7));
                cmd.Parameters.AddWithValue("@pf8", Get_Selected_Key(cboPF8));
                cmd.Parameters.AddWithValue("@actions8", Get_Selected_Key(cboAction8));
                cmd.Parameters.AddWithValue("@pf9", -1);
                cmd.Parameters.AddWithValue("@actions9", -1);
                cmd.Parameters.AddWithValue("@pf10", -1);
                cmd.Parameters.AddWithValue("@actions10", -1);
                int iID = (cboSpots.SelectedItem as dynamic).Value;
                cmd.Parameters.AddWithValue("@id", iID);

                conn.Open();
                int iRows = cmd.ExecuteNonQuery();
                conn.Close();

                //if (iRows > 0) {
                //    MessageBox.Show("Update Success!");
                //}
            }
        }

        private void ClearAllEntries() {
            // clear all entries
            txtSpotName.Text = "";
            txtNotes1.Text = "";
            txtNotes2.Text = "";
            txtNotes3.Text = "";
            cboManeuver.SelectedIndex = -1;
            cboAC.SelectedIndex = -1;
            cboWx.SelectedIndex = -1;
            chkATIS.Checked=false;
            txtATIS.Text = "";
            cboClearance.SelectedIndex = -1;
            txtClearance.Text = "";
            chkPDC.Checked = false;
            cboPF1.SelectedIndex = -1;
            cboAction1.SelectedIndex = -1;
            cboPF2.SelectedIndex = -1;
            cboAction2.SelectedIndex = -1;
            cboPF3.SelectedIndex = -1;
            cboAction3.SelectedIndex = -1;
            cboPF4.SelectedIndex = -1;
            cboAction4.SelectedIndex = -1;
            cboPF5.SelectedIndex = -1;
            cboAction5.SelectedIndex = -1;
            cboPF6.SelectedIndex = -1;
            cboAction6.SelectedIndex = -1;
            cboPF7.SelectedIndex = -1;
            cboAction7.SelectedIndex = -1;
            cboPF8.SelectedIndex = -1;
            cboAction8.SelectedIndex = -1;

            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnClearData.Enabled = false;
        }

        private void btnAddWxConditions_Click(object sender, EventArgs e) {
            frmEditWxConditions frmEditWxConditions = new frmEditWxConditions();
            frmEditWxConditions.ShowDialog();
            // save ID of selected item (NOT the selectedindex)
            int iID = GetCboID(cboWx);
            Fill_Wx();
            // return from re-filling the cbo, set to index 0 by default
            SetCboID(cboWx, iID);
        }

        private void cboWx_SelectedIndexChanged(object sender, EventArgs e) {

            //listWx1.Items.Clear();
            //listWx2.Items.Clear();
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1)
                return;
            KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)comboBox.SelectedItem;
            if (selectedPair.Key > -1) {
                DataTable dt = new DataTable();
                dt = Get_Selected_DataTable(comboBox, "Conditions_WX");
                if (dt != null) {
                    //add items to ListView
                    foreach (DataRow row in dt.Rows) {
                        //// atis info
                        //listWx1.Items.Add(Builder_ATIS.ATIS_Designator(row));
                        //// wind
                        //listWx1.Items.Add(Builder_ATIS.Wind(row));
                        //// visibility
                        //listWx1.Items.Add(Builder_ATIS.Visibility(row));
                        //// sky
                        //listWx1.Items.Add(Builder_ATIS.Sky(row));
                        //// temp/dp
                        //listWx2.Items.Add(Builder_ATIS.TempDp(row));
                        //// qnh
                        //listWx2.Items.Add(Builder_ATIS.QNH(row,false));
                        //// runways
                        //listWx2.Items.Add(Builder_ATIS.Runways(row,false));
                        //// rcam
                        //listWx2.Items.Add(Builder_ATIS.RCAM(row));
                        // display atis
                        txtATIS.Text = Builder_ATIS.CompleteATIS(row);
                    }
                }
            }
        }

        private void btnAddACConditions_Click(object sender, EventArgs e) {
            frmEditACConditions frmEditACConditions = new frmEditACConditions();
            frmEditACConditions.ShowDialog();
            // save ID of selected item (NOT the selectedindex)
            int iID = GetCboID(cboAC);
            Fill_Ac();
            // return from re-filling the cbo, set to index 0 by default
            SetCboID(cboAC, iID);
        }
        //private void btnAddATIS_Click(object sender, EventArgs e) {
        //    frmEditATIS frmEditATIS = new frmEditATIS();
        //    frmEditATIS.ShowDialog();
        //    // save ID of selected item (NOT the selectedindex)
        //    int iID = GetCboID(cboATIS);
        //    Fill_ATIS();
        //    // return from re-filling the cbo, set to index 0 by default
        //    SetCboID(cboATIS, iID);
        //}

        private void btnAddClearance_Click(object sender, EventArgs e) {
            frmEditClearance frmEditClearance = new frmEditClearance();
            frmEditClearance.ShowDialog();
            // save ID of selected item (NOT the selectedindex)
            int iID = GetCboID(cboClearance);
            Fill_Clearance();
            // return from re-filling the cbo, set to index 0 by default
            SetCboID(cboClearance, iID);
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
            if (comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0;
            // try to set the cbo back to the previously selected item by looking for its ID (NOT the selectedindex)
            foreach (KeyValuePair<int, string> keyID in comboBox.Items) {
                if (keyID.Key == iID) {
                    // match found (has not been deleted)
                    comboBox.SelectedIndex = comboBox.Items.IndexOf(keyID);
                }
            }
        }

        private void btnAddManeuver_Click(object sender, EventArgs e) {
            frmEditManeuver frmEditManeuver = new frmEditManeuver();
            frmEditManeuver.ShowDialog();
            int iMinutes = (int)txtMinutes.Value;
            // save ID of selected item (NOT the selectedindex)
            int iID = GetCboID(cboManeuver);
            Fill_Maneuver();
            // return from re-filling the cbo, set to index 0 by default
            SetCboID(cboManeuver, iID);
            txtMinutes.Value = iMinutes;
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
        private void cboManeuver_SelectedIndexChanged(object sender, EventArgs e) {

            txtMinutes.Value = 0;
            txtManeuver.Text = "";
            txtObjective.Text = "";
            txtScope.Text = "";
            txtSimPosition.Text = "";
            txtSimSetup.Text = "";
            txtNotes.Text = "";

            // Get the selected item in the combobox
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1)
                return;
            KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)comboBox.SelectedItem;
            if (selectedPair.Key > -1) {
                DataTable dt = new DataTable();
                dt = Get_Selected_DataTable(comboBox, "Maneuver");
                if (dt != null) {
                    //add items to ListView
                    int i;
                    for (i = 0; i <= dt.Rows.Count - 1; i++) {
                        txtMinutes.Value = (int)dt.Rows[i].ItemArray[8];
                        txtManeuver.Text = (string)dt.Rows[i].ItemArray[7];
                        if (!dt.Rows[i].IsNull(9) && (string)dt.Rows[i].ItemArray[9] != "")
                            txtObjective.Text = (string)dt.Rows[i].ItemArray[9];
                        if (!dt.Rows[i].IsNull(10) && (string)dt.Rows[i].ItemArray[10] != "")
                            txtObjective.Text = txtObjective.Text + "\n" + (string)dt.Rows[i].ItemArray[10];
                        if (!dt.Rows[i].IsNull(11) && (string)dt.Rows[i].ItemArray[11] != "")
                            txtScope.Text = (string)dt.Rows[i].ItemArray[11];
                        if (!dt.Rows[i].IsNull(12) && (string)dt.Rows[i].ItemArray[12] != "")
                            txtScope.Text = txtScope.Text + "\n" + (string)dt.Rows[i].ItemArray[12];
                        if (!dt.Rows[i].IsNull(13) && (string)dt.Rows[i].ItemArray[13] != "")
                            txtSimPosition.Text = (string)dt.Rows[i].ItemArray[13];
                        if (!dt.Rows[i].IsNull(14) && (string)dt.Rows[i].ItemArray[14] != "")
                            txtSimSetup.Text = (string)dt.Rows[i].ItemArray[14];
                        if (!dt.Rows[i].IsNull(15) && (string)dt.Rows[i].ItemArray[15] != "")
                            txtSimSetup.Text = txtSimSetup.Text + "\n" + (string)dt.Rows[i].ItemArray[15];
                        if (!dt.Rows[i].IsNull(16) && (string)dt.Rows[i].ItemArray[16] != "")
                            txtSimSetup.Text = txtSimSetup.Text + "\n" + (string)dt.Rows[i].ItemArray[16];
                        if (!dt.Rows[i].IsNull(17) && (string)dt.Rows[i].ItemArray[17] != "")
                            txtSimSetup.Text = txtSimSetup.Text + "\n" + (string)dt.Rows[i].ItemArray[17];
                        if (!dt.Rows[i].IsNull(21) && (string)dt.Rows[i].ItemArray[21] != "")
                            txtNotes.Text = (string)dt.Rows[i].ItemArray[21];
                        if (!dt.Rows[i].IsNull(22) && (string)dt.Rows[i].ItemArray[22] != "")
                            txtNotes.Text = txtNotes.Text + "\n" + (string)dt.Rows[i].ItemArray[22];
                        if (!dt.Rows[i].IsNull(22) && (string)dt.Rows[i].ItemArray[22] != "")
                            txtNotes.Text = txtNotes.Text + "\n" + (string)dt.Rows[i].ItemArray[22];
                        if (!dt.Rows[i].IsNull(22) && (string)dt.Rows[i].ItemArray[22] != "")
                            txtNotes.Text = txtNotes.Text + "\n" + (string)dt.Rows[i].ItemArray[22];

                    }
                }

            }
        }

        #region ACTIONS
        private void Fill_Saved_Action(ComboBox ComboBoxSelect, ComboBox ComboBoxPF, TextBox TextBoxTitle, TextBox TextBoxActions, TextBox TextBoxComm) {
            DataTable dt = new DataTable();
            dt = Get_Selected_DataTable(ComboBoxSelect, "Actions");
            if (dt != null) {
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++) {
                    foreach (KeyValuePair<int, string> row in cboPF1.Items) {
                        if (row.Key == (int)dt.Rows[i].ItemArray[5]) {
                            ComboBoxPF.SelectedIndex = ComboBoxPF.Items.IndexOf(row);
                        }
                    }
                    TextBoxTitle.Text = (string)dt.Rows[i].ItemArray[6];
                    string sActionText = (string)dt.Rows[i].ItemArray[7];
                    int iWX = (int)dt.Rows[i]["ATIS"];
                    if (iWX> 0) {
                        sActionText = sActionText + "\n" + Builder_ATIS.Get_Action_Atis(iWX);
                    }
                    int iPDC = (int)dt.Rows[i]["PDC"];
                    if (iPDC > 0) {
                        sActionText = sActionText + "\n" + Builder_Clearance.Get_Action_PDC(iPDC);
                    }
                    TextBoxActions.Text = sActionText;
                    TextBoxComm.Text = (string)dt.Rows[i].ItemArray[8];
                }
            }
        }
        private void cboAction1_SelectedIndexChanged(object sender, EventArgs e) {
            cboPF1.SelectedIndex = -1;
            txtActionTitle1.Text = "";
            txtActions1.Text = "";
            txtComm1.Text = "";

            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1)
                return;
            KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)comboBox.SelectedItem;
            if (selectedPair.Key>-1)
                Fill_Saved_Action(comboBox, cboPF1, txtActionTitle1, txtActions1, txtComm1);
        }
        private void cboAction2_SelectedIndexChanged(object sender, EventArgs e) {
            cboPF2.SelectedIndex = -1;
            txtActionTitle2.Text = "";
            txtActions2.Text = "";
            txtComm2.Text = "";
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1)
                return;
            KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)comboBox.SelectedItem;
            if (selectedPair.Key > -1)
                Fill_Saved_Action(cboAction2, cboPF2, txtActionTitle2, txtActions2, txtComm2);
        }
        private void cboAction3_SelectedIndexChanged(object sender, EventArgs e) {
            cboPF3.SelectedIndex = -1;
            txtActionTitle3.Text = "";
            txtActions3.Text = "";
            txtComm3.Text = "";
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1)
                return;
            KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)comboBox.SelectedItem;
            if (selectedPair.Key > -1)
                Fill_Saved_Action(cboAction3, cboPF3, txtActionTitle3, txtActions3, txtComm3);
        }
        private void cboAction4_SelectedIndexChanged(object sender, EventArgs e) {
            cboPF4.SelectedIndex = -1;
            txtActionTitle4.Text = "";
            txtActions4.Text = "";
            txtComm4.Text = "";
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1)
                return;
            KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)comboBox.SelectedItem;
            if (selectedPair.Key > -1)
                Fill_Saved_Action(cboAction4, cboPF4, txtActionTitle4, txtActions4, txtComm4);
        }
        private void cboAction5_SelectedIndexChanged(object sender, EventArgs e) {
            cboPF5.SelectedIndex = -1;
            txtActionTitle5.Text = "";
            txtActions5.Text = "";
            txtComm5.Text = "";
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1)
                return;
            KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)comboBox.SelectedItem;
            if (selectedPair.Key > -1)
                Fill_Saved_Action(cboAction5, cboPF5, txtActionTitle5, txtActions5, txtComm5);
        }
        private void cboAction6_SelectedIndexChanged(object sender, EventArgs e) {
            cboPF6.SelectedIndex = -1;
            txtActionTitle6.Text = "";
            txtActions6.Text = "";
            txtComm6.Text = "";
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1)
                return;
            KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)comboBox.SelectedItem;
            if (selectedPair.Key > -1)
                Fill_Saved_Action(cboAction6, cboPF6, txtActionTitle6, txtActions6, txtComm6);
        }
        private void cboAction7_SelectedIndexChanged(object sender, EventArgs e) {
            cboPF7.SelectedIndex = -1;
            txtActionTitle7.Text = "";
            txtActions7.Text = "";
            txtComm7.Text = "";
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1)
                return;
            KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)comboBox.SelectedItem;
            if (selectedPair.Key > -1)
                Fill_Saved_Action(cboAction7, cboPF7, txtActionTitle7, txtActions7, txtComm7);
        }
        private void cboAction8_SelectedIndexChanged(object sender, EventArgs e) {
            cboPF8.SelectedIndex = -1;
            txtActionTitle8.Text = "";
            txtActions8.Text = "";
            txtComm8.Text = "";
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1)
                return;
            KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)comboBox.SelectedItem;
            if (selectedPair.Key > -1)
                Fill_Saved_Action(cboAction8, cboPF8, txtActionTitle8, txtActions8, txtComm8);
        }

        private void btnAddActions_Click(object sender, EventArgs e) {
            frmEditAction frmEditAction = new frmEditAction();
            frmEditAction.ShowDialog();

            // cycle thru action cbo's and save selected item IDs
            int[] iID = new int[10];
            int[] iID1 = new int[10];
            ComboBox comboBox = (ComboBox)cboAction1;
            ComboBox comboBox1 = (ComboBox)cboPF1;
            for (int i = 1; i <= 8; i++) {
                iID[i] = -1;
                switch (i){
                    case 1:
                        comboBox = cboAction1;
                        comboBox1 = cboPF1;
                        break;
                    case 2:
                        comboBox = cboAction2;
                        comboBox1 = cboPF2;
                        break;
                    case 3:
                        comboBox = cboAction3;
                        comboBox1 = cboPF3;
                        break;
                    case 4:
                        comboBox = cboAction4;
                        comboBox1 = cboPF4;
                        break;
                    case 5:
                        comboBox = cboAction5;
                        comboBox1 = cboPF5;
                        break;
                    case 6:
                        comboBox = cboAction6;
                        comboBox1 = cboPF6;
                        break;
                    case 7:
                        comboBox = cboAction7;
                        comboBox1 = cboPF7;
                        break;
                    case 8:
                        comboBox = cboAction8;
                        comboBox1 = cboPF8;
                        break;
                }
                if (comboBox.SelectedIndex > 0) {
                    // save ID of selected item (NOT the selectedindex)
                    KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)comboBox.SelectedItem;
                    if (selectedPair.Key > -1)
                        iID[i] = selectedPair.Key;
                }
                // save index of selected item
                iID1[i] = comboBox1.SelectedIndex;
            }

            Fill_Actions();

            // return from re-filling the cbo, set to index 0 by default
            // cycle thru action cbo's and save selected item IDs
            for (int i = 1; i <= 8; i++) {
                switch (i) {
                    case 1:
                        comboBox = cboAction1;
                        comboBox1 = cboPF1;
                        break;
                    case 2:
                        comboBox = cboAction2;
                        comboBox1 = cboPF2;
                        break;
                    case 3:
                        comboBox = cboAction3;
                        comboBox1 = cboPF3;
                        break;
                    case 4:
                        comboBox = cboAction4;
                        comboBox1 = cboPF4;
                        break;
                    case 5:
                        comboBox = cboAction5;
                        comboBox1 = cboPF5;
                        break;
                    case 6:
                        comboBox = cboAction6;
                        comboBox1 = cboPF6;
                        break;
                    case 7:
                        comboBox = cboAction7;
                        comboBox1 = cboPF7;
                        break;
                    case 8:
                        comboBox = cboAction8;
                        comboBox1 = cboPF8;
                        break;
                }
                comboBox.SelectedIndex = 0;
                // try to set the cbo back to the previously selected item by looking for its ID (NOT the selectedindex)
                foreach (KeyValuePair<int, string> keyID in comboBox.Items) {
                    if (keyID.Key == iID[i]) {
                        // match found (has not been deleted)
                        comboBox.SelectedIndex = comboBox.Items.IndexOf(keyID);
                    }
                }
                comboBox1.SelectedIndex = iID1[i];
            }
        }

        #endregion
        private void Delete_Maneuver() {
            if ((cboSpots.SelectedItem as dynamic).Value > -1) {
                DialogResult result = MessageBox.Show(
                    "Deleting the selected SPOT will permantly eliminate it from the database.  Are you sure that you would like to DELETE?",
                    "DELETE SELECTED SPOT?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes) {
                    string sQuery = "DELETE FROM Spots WHERE ID=" + (cboSpots.SelectedItem as dynamic).Value;
                    conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
                    conn.Open();
                    OleDbCommand commandBuilder = new OleDbCommand(sQuery, conn);
                    commandBuilder.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private void cboSpots_SelectedIndexChanged(object sender, EventArgs e) {
            FillData();
        }

        private void btnAdd_Click_1(object sender, EventArgs e) {
            // add new record
            AddDataRow();
            ClearAllEntries();
        }
        private void btnSave_Click_1(object sender, EventArgs e) {
            //// Update the database with the user's changes.
            UpdateDataRow();
            Fill_Spots();
            ClearAllEntries();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
                Delete_Maneuver();
                Fill_Spots();
                ClearAllEntries();
        }

        private void btnEditSimData_Click(object sender, EventArgs e) {
                frmBuilderLesson frmDeveloper = new frmBuilderLesson();
                frmDeveloper.Show();
        }

        private void btnClearData_Click_1(object sender, EventArgs e) {
            cboSpots.SelectedIndex = 0;
            ClearAllEntries();
        }

        //private void cboATIS_SelectedIndexChanged(object sender, EventArgs e) {
        //    lblATIS.Text = "ATIS";
        //    ComboBox comboBox = (ComboBox)sender;
        //    if (comboBox.SelectedIndex < 1)
        //        return;
        //    KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)comboBox.SelectedItem;
        //    if (selectedPair.Key > -1) {
        //        DataTable dt = new DataTable();
        //        dt = Get_Selected_DataTable(comboBox, "ATIS");
        //        if (dt != null) {
        //            //add items to ListView
        //            int i;
        //            for (i = 0; i <= dt.Rows.Count - 1; i++) {
        //                lblATIS.Text = "ATIS: " + (string)dt.Rows[i].ItemArray[1];
        //            }
        //        }
        //    }
        //}

        private void cboClearance_SelectedIndexChanged(object sender, EventArgs e) {
            lblClearance.Text = "CLEARANCE";
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex < 0)
                return;
            KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)comboBox.SelectedItem;
            if (selectedPair.Key > -1) {
                DataTable dt = new DataTable();
                dt = Get_Selected_DataTable(comboBox, "Clearance");
                if (dt != null) {
                    foreach (DataRow row in dt.Rows) {
                        txtClearance.Text = Builder_Clearance.Build_PDC(row);
                    }
                }
            }
        }

        private void btnEditSimData_Click_1(object sender, EventArgs e) {
            frmBuilderLesson frmScripts = new frmBuilderLesson();
            frmScripts.Show();
        }

        private void button1_Click(object sender, EventArgs e){
            frmBuilderCurriculum frmDeveloper = new frmBuilderCurriculum();
            frmDeveloper.Show();
        }

        private void cboAC_SelectedIndexChanged_1(object sender, EventArgs e) {
            listAC1.Items.Clear();
            listAC2.Items.Clear();
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1)
                return;
            KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)comboBox.SelectedItem;
            if (selectedPair.Key > -1) {
                DataTable dt = new DataTable();
                dt = Get_Selected_DataTable(comboBox, "Conditions_AC");
                if (dt != null) {
                    //add items to ListView
                    int i;
                    for (i = 0; i <= dt.Rows.Count - 1; i++) {
                        listAC1.Items.Add(Format_Decimal_1(((Single)dt.Rows[i]["ZFW"]).ToString()) + "KLB / " + Format_Decimal_1(((Single)dt.Rows[i]["ZFWCG"]).ToString()) + "%");
                        listAC1.Items.Add(Format_Decimal_1(((string)dt.Rows[i]["GTOW"]).ToString()) + "KLB / " + Format_Decimal_1(((Single)dt.Rows[i]["TOWCG"]).ToString()) + "%");
                        listAC1.Items.Add((int)dt.Rows[i]["CI"]);
                        if ((int)dt.Rows[i]["FLEX"] == 1) {
                            listAC1.Items.Add("FLEX+" + (int)dt.Rows[i]["THRUST"]);
                        } else {
                            listAC1.Items.Add("TOGA");
                        }
                        listAC1.Items.Add((Single)dt.Rows[i]["STAB"] + "%");
                        listAC1.Items.Add((int)dt.Rows[i]["FLAPS"]);

                        listAC2.Items.Add((int)dt.Rows[i]["V1"] + " / " + (int)dt.Rows[i]["VR"] + " / " + (int)dt.Rows[i]["V2"]);
                        listAC2.Items.Add(Format_Decimal_1(((Single)dt.Rows[i]["FUEL"]).ToString()) + "KLB / 00:" + (int)dt.Rows[i]["RESERVE"]);
                        listAC2.Items.Add((int)dt.Rows[i]["PAX"]);
                        listAC2.Items.Add("FL"+(int)dt.Rows[i]["CRZALT"]);
                        listAC2.Items.Add((int)dt.Rows[i]["THRUST_RED_ALT"] + "AFL / " + (int)dt.Rows[i]["ACCEL_ALT"] + "AFL");
                        listAC2.Items.Add((int)dt.Rows[i]["EO_ACCEL_ALT"] + "AFL");
                    }
                }
            }
        }
        private string Format_Decimal_1(string sInput) {
            if (sInput.IndexOf(".") < 0) {
                // add decimal
                sInput = sInput + ".0";
            }
            return sInput;
        }

        private void btnPreamble_Click(object sender, EventArgs e) {
            frmBuildPreamble frmBuildPreamble = new frmBuildPreamble();
            frmBuildPreamble.ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
            frmOptions frmOptions = new frmOptions();
            frmOptions.Show();
        }

        private void openExistingFleetDatabaseToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var folderDialog = new OpenFileDialog()) {
                folderDialog.InitialDirectory = GlobalCode.sPATH_DATA;
                folderDialog.Title = "Select Database File To Open";
                folderDialog.DefaultExt = "accdb";
                folderDialog.Filter = "Access Database| *.accdb";
                folderDialog.FilterIndex = 1;

                if (folderDialog.ShowDialog() == DialogResult.OK) {
                    DialogResult result = MessageBox.Show("In order to open the selected database file, the application will have to re-start.", "Restarting Application", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.OK) {
                        GlobalCode.sPATH_DATA = folderDialog.InitialDirectory;
                        Settings.Default.PATH_DB = GlobalCode.sPATH_DATA;
                        GlobalCode.sFILE_DATA = "\\" + folderDialog.SafeFileName;
                        Settings.Default.FILE_DB = GlobalCode.sFILE_DATA;
                        Settings.Default.Save();

                        this.Close();
                        System.Diagnostics.Process.Start(Application.ExecutablePath);
                    }
                }
            }

        }

        private void newFleetDatabaseToolStripMenuItem_Click(object sender, EventArgs e) {
            // clear setting
            Settings.Default.FLEET = "";
            Settings.Default.PATH_DB = "";
            Settings.Default.FILE_DB = "";
            Settings.Default.FILE_DB_BACKUP = "";
            Settings.Default.Save();

            // call program main
            Program.Load_App();

        }
    }
}