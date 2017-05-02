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
        private BindingSource bindingSource1;

        int iSelected = 0;

        private void frmEditManeuver_Load(object sender, EventArgs e) {
            Fill_Data("SELECT * FROM Maneuver ORDER BY ID");
            Fill_Conditions();

            if (cboSelect.Items.Count > 1) {
                cboSelect.SelectedIndex = 0;
                cboSelect.DroppedDown = true;
            }
        }

        private void Fill_Conditions() {
            Fill_CBOs(cboSelect, "SELECT ID,MANEUVER_NAME FROM Maneuver ORDER BY ID");
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
//            data.Add(new KeyValuePair<int, string>(-1, ""));
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
        private void Fill_Data(string sQuery) {

            conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
            dataAdapter = new OleDbDataAdapter(sQuery, GlobalCode.sOleDbConnectionString);
            bindingSource1 = new BindingSource();

            dtTable = new DataTable();
            dtTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            conn.Open();
            dataAdapter.Fill(dtTable);
            OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dataAdapter);
            bindingSource1.DataSource = dtTable;
            conn.Close();

//            txtDate.DataBindings.Clear();
            txtName.DataBindings.Clear();
            cboData2.DataBindings.Clear();
            cboData3.DataBindings.Clear();
            txtData4.DataBindings.Clear();
            txtData5.DataBindings.Clear();
            txtData6.DataBindings.Clear();
            txtData7.DataBindings.Clear();
            txtData8.DataBindings.Clear();
            txtData9.DataBindings.Clear();
            txtData10.DataBindings.Clear();
            txtData11.DataBindings.Clear();
            txtData12.DataBindings.Clear();
            txtData13.DataBindings.Clear();
            txtData14.DataBindings.Clear();
            txtData15.DataBindings.Clear();
            txtData16.DataBindings.Clear();
            txtData17.DataBindings.Clear();
            txtData18.DataBindings.Clear();

//            txtDate.DataBindings.Add("text", bindingSource1, "DATE_EDITED");
            txtName.DataBindings.Add("text", bindingSource1, "MANEUVER_NAME");
            cboData2.DataBindings.Add("text", bindingSource1, "ATA_CODE");
            cboData3.DataBindings.Add("text", bindingSource1, "SOP_PHASE");
            txtData4.DataBindings.Add("text", bindingSource1, "MANEUVER");
            txtData5.DataBindings.Add("text", bindingSource1, "MINUTES");
            txtData6.DataBindings.Add("text", bindingSource1, "OBJECTIVE1");
            txtData7.DataBindings.Add("text", bindingSource1, "OBJECTIVE2");
            txtData8.DataBindings.Add("text", bindingSource1, "SCOPE1");
            txtData9.DataBindings.Add("text", bindingSource1, "SCOPE2");
            txtData10.DataBindings.Add("text", bindingSource1, "SIM_POSITION");
            txtData11.DataBindings.Add("text", bindingSource1, "SIM_SETUP1");
            txtData12.DataBindings.Add("text", bindingSource1, "SIM_SETUP2");
            txtData13.DataBindings.Add("text", bindingSource1, "SIM_SETUP3");
            txtData14.DataBindings.Add("text", bindingSource1, "SIM_SETUP4");
            txtData15.DataBindings.Add("text", bindingSource1, "NOTES_1");
            txtData16.DataBindings.Add("text", bindingSource1, "NOTES_2");
            txtData17.DataBindings.Add("text", bindingSource1, "NOTES_3");
            txtData18.DataBindings.Add("text", bindingSource1, "NOTES_4");

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
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1)
                return;
            KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)comboBox.SelectedItem;
            if (selectedPair.Key > -1) {
                iSelected = selectedPair.Key;//(cboSelect.SelectedItem as dynamic).Value;
                int iPosition = bindingSource1.Find("ID", iSelected);
                bindingSource1.Position = iPosition;

                // Get the selected item in the combobox
                DataTable dt = new DataTable();
                        dt = Get_Selected_DataTable(comboBox, "Maneuver");
                        if (dt != null) {
                            int i;
                            for (i = 0; i <= dt.Rows.Count - 1; i++) {
                                string sDate = "DATE CREATED: " + (string)dt.Rows[i].ItemArray[2];
                                sDate = sDate + "\r\nDATE EDITED: " + (string)dt.Rows[i].ItemArray[3];
                                txtDate.Text = sDate;
                            }
                        }

            } else {
                Clear_Entries();
            }
        }

        private void Clear_Entries() {
            txtName.Text = "";
            cboData2.Text = "";
            cboData3.Text = "";
            txtData4.Text = "";
            txtData5.Text = "";
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
        }

        private void btnSave_Click(object sender, EventArgs e) {
            System.Data.DataRow dr = dtTable.NewRow();
            dr["MANEUVER_NAME"] = txtName.Text;
            dr["DATE_CREATED"] = GetDateString(DateTime.Now);
            dr["DATE_EDITED"] = GetDateString(DateTime.Now);
            dr["ATA_CODE"] = cboData2.Text;
            dr["SOP_PHASE"] = cboData3.Text;
            dr["MANEUVER"] = txtData4.Text;
            dr["MINUTES"] = txtData5.Text;
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

            dtTable.Rows.Add(dr);
            dataAdapter.Update(dtTable);  // write new row back to database

            iSelected = cboSelect.Items.Count;
            //Clear_Entries();
            Fill_Data("SELECT * FROM Maneuver");
            Fill_Conditions();
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            // Update the database with the user's changes.
            bindingSource1.EndEdit();
            dataAdapter.Update((DataTable)bindingSource1.DataSource);
            Fill_Data("SELECT * FROM Maneuver");
            Fill_Conditions();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Delete_Entry() {
            if ((cboSelect.SelectedItem as dynamic).Value > -1) {
                iSelected = (cboSelect.SelectedItem as dynamic).Value;

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
                    bindingSource1.RemoveCurrent();
                    dataAdapter.Update((DataTable)bindingSource1.DataSource);
                    Fill_Data("SELECT * FROM Maneuver");
                    Fill_Conditions();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            Delete_Entry();
        }

        private void btnClearData_Click(object sender, EventArgs e) {
            Clear_Entries();
        }
    }
}
