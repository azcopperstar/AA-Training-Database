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
    public partial class frmEditWxConditions : Form {
        public frmEditWxConditions() {
            InitializeComponent();
        }

        private OleDbConnection conn;
        private OleDbDataAdapter dataAdapter;
        DataTable dtTable;
        //private BindingSource bindingSource1;

        private void frmEditWxConditions_Load(object sender, EventArgs e) {
            try {
                Initialize_DB();
                Fill_CBOs(cboSelect, "SELECT * FROM Conditions_WX ORDER BY STATION,ATIS_DESIGNATOR");
                Fill_CBOs_AutoComplete(cboStation, "SELECT DISTINCT ICAO FROM Airport_Runways","ICAO");
                if (cboSelect.Items.Count > 1) {
                    cboSelect.SelectedIndex = 0;
                    cboSelect.DroppedDown = true;
                }
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
        private void Initialize_DB() {
            try {
                string sQuery = "SELECT * FROM Conditions_WX";
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
        private void Fill_Runways(ComboBox cbo, string query) {
            //try {
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
                    data.Add(new KeyValuePair<int, string>((int)dt.Rows[i]["ID"], (string)dt.Rows[i]["RUNWAY1"]));
                    data.Add(new KeyValuePair<int, string>((int)dt.Rows[i]["ID"], (string)dt.Rows[i]["RUNWAY2"]));
                }
                // Bind the combobox
                cbo.DataSource = null;
                cbo.Items.Clear();
                cbo.DataSource = new BindingSource(data, null);
                cbo.DisplayMember = "Value";
                cbo.ValueMember = "Key";
            //} catch (Exception) {
            //    throw;
            //}
        }
        private void FillData() {
            //try {
                int iSelected = Get_Selected_Key(cboSelect);
                if (cboSelect.SelectedIndex > 0 || iSelected > -1) {
                    string sCommand = "SELECT * FROM CONDITIONS_WX WHERE ID = " + iSelected;
                    conn.Open();
                    OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
                    DataTable dt = new DataTable();
                    dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    dAdapter.Fill(dt);
                    conn.Close();


                    for (int i = 0; i <= dt.Rows.Count - 1; i++) {
                        string sDate = "CREATED: " + (string)dt.Rows[i]["DATE_CREATED"];
                        sDate = sDate + "\r\nEDITED: " + (string)dt.Rows[i]["DATE_EDITED"];
                        txtDate.Text = sDate;

                        txtName.Text = (string)dt.Rows[i]["COND_NAME"];
                        if (!DBNull.Value.Equals(dt.Rows[i]["ATIS_DESIGNATOR"]))
                            cboATIS.Text = (string)dt.Rows[i]["ATIS_DESIGNATOR"];
                        string sStation = "";
                        if (!DBNull.Value.Equals(dt.Rows[i]["STATION"])) {
                            sStation = (string)dt.Rows[i]["STATION"];
                        }
                        cboStation.Text = sStation;
                        if (sStation != "") {
                            Fill_Runways(cboRwyDep, "SELECT * FROM Airport_Runways WHERE ICAO = '" + sStation + "'");
                            Fill_Runways(cboRwyArr, "SELECT * FROM Airport_Runways WHERE ICAO = '" + sStation + "'");
                        }

                        cboRwyDep.SelectedIndex = 0;
                        if (!DBNull.Value.Equals(dt.Rows[i]["RUNWAY_DEP"])) {
                            string sRwy = (string)dt.Rows[i]["RUNWAY_DEP"];
                            cboRwyDep.Text = sRwy;
                        }
                        cboRwyArr.SelectedIndex = 0;
                        if (!DBNull.Value.Equals(dt.Rows[i]["RUNWAY_ARR"])) {
                            string sRwy = (string)dt.Rows[i]["RUNWAY_ARR"];
                             cboRwyArr.Text = sRwy;
                        }
                        cboRCAM.SelectedIndex = 0;
                        if (!DBNull.Value.Equals(dt.Rows[i]["RUNWAY_COND"]))
                            cboRCAM.Text = (string)dt.Rows[i]["RUNWAY_COND"];
                        cboApproach.SelectedIndex = 0;
                        if (!DBNull.Value.Equals(dt.Rows[i]["APPROACH"]))
                            cboApproach.Text = (string)dt.Rows[i]["APPROACH"];
                        cboApproachDesignator.SelectedIndex = 0;
                        if (!DBNull.Value.Equals(dt.Rows[i]["APP_DESIGNATOR"]))
                            cboApproachDesignator.Text = (string)dt.Rows[i]["APP_DESIGNATOR"];

                        txtWindDir.Text = (string)dt.Rows[i]["WIND"];
                        if (!DBNull.Value.Equals(dt.Rows[i]["WIND_VEL"]))
                            txtWindVel.Text = (string)dt.Rows[i]["WIND_VEL"];
                        if (!DBNull.Value.Equals(dt.Rows[i]["GUST_VEL"]))
                            txtGustVel.Text = (string)dt.Rows[i]["GUST_VEL"];
                        txtTemp.Text = (string)dt.Rows[i]["TEMP"];
                        if (!DBNull.Value.Equals(dt.Rows[i]["DEWPOINT"]))
                            txtDewpoint.Text = (string)dt.Rows[i]["DEWPOINT"];
                        txtQNH.Text = (string)dt.Rows[i]["QNH"];
                        if (!DBNull.Value.Equals(dt.Rows[i]["QNH_TYPE"])) {
                            string sQNHType = (string)dt.Rows[i]["QNH_TYPE"];
                            optINHG.Checked = true;
                            if (sQNHType == "hPA") {
                                optHPA.Checked = true;
                            }
                        }
                        if (!DBNull.Value.Equals(dt.Rows[i]["VISIBILITY"])) {
                            string sWxX = (string)dt.Rows[i]["VISIBILITY"];
                            txtVis.Enabled = false;
                            if (sWxX == "1/16") {
                                optVis1.Checked = true;
                            } else if (sWxX == "1/8") {
                                optVis2.Checked = true;
                            } else if (sWxX == "1/4") {
                                optVis3.Checked = true;
                            } else if (sWxX == "1/2") {
                                optVis4.Checked = true;
                            } else if (sWxX == "5/8") {
                                optVis5.Checked = true;
                            } else {
                                // => 1SM
                                txtVis.Enabled = true;
                                txtVis.Value = int.Parse(sWxX);
                                optVis6.Checked = true;
                            }
                        }

                        if (!DBNull.Value.Equals(dt.Rows[i]["WX_PRECIPITATION"])) {
                            string sWxX = (string)dt.Rows[i]["WX_PRECIPITATION"];
                            optIntensity1.Checked = false;
                            optIntensity2.Checked = false;
                            optIntensity3.Checked = false;
                            if (sWxX == "NONE") {
                                optPrecip5.Checked = true;
                            } else {
                                // precipitation
                                if (sWxX == "RA") {
                                    optPrecip1.Checked = true;
                                } else if (sWxX == "DZ") {
                                    optPrecip2.Checked = true;
                                } else if (sWxX == "SN") {
                                    optPrecip3.Checked = true;
                                } else if (sWxX == "PL") {
                                    optPrecip4.Checked = true;
                                }
                                // intensity
                                if (!DBNull.Value.Equals(dt.Rows[i]["WX_INTENSITY"])) {
                                    sWxX = (string)dt.Rows[i]["WX_INTENSITY"];
                                    if (sWxX == "-") {
                                        optIntensity1.Checked = true;
                                    } else if (sWxX == "") {
                                        optIntensity2.Checked = true;
                                    } else if (sWxX == "+") {
                                        optIntensity3.Checked = true;
                                    }
                                }
                                // descriptor
                                if (!DBNull.Value.Equals(dt.Rows[i]["WX_DESCRIPTOR"])) {
                                    sWxX = (string)dt.Rows[i]["WX_DESCRIPTOR"];
                                    optDescriptor5.Checked = true;
                                    if (sWxX == "TS") {
                                        optDescriptor1.Checked = true;
                                    } else if (sWxX == "SH") {
                                        optDescriptor2.Checked = true;
                                    } else if (sWxX == "FS") {
                                        optDescriptor3.Checked = true;
                                    } else if (sWxX == "BL") {
                                        optDescriptor4.Checked = true;
                                    } else if (sWxX == "NONE") {
                                        optDescriptor5.Checked = true;
                                }
                            }
                            }
                        }
                        // sky condition
                        if (!DBNull.Value.Equals(dt.Rows[i]["SKY_AMOUNT"])) {
                            string sWxX = (string)dt.Rows[i]["SKY_AMOUNT"];
                            optType3.Checked = true;
                            txtCeiling.Value = int.Parse((string)dt.Rows[i]["CEILING"]);
                            if (sWxX == "SKC") {
                                optAmount1.Checked = true;
                            } else {
                                if (sWxX == "FEW") {
                                    optAmount2.Checked = true;
                                } else if (sWxX == "SCT") {
                                    optAmount3.Checked = true;
                                } else if (sWxX == "BRK") {
                                    optAmount4.Checked = true;
                                } else if (sWxX == "OVC") {
                                    optAmount5.Checked = true;
                                }
                                // sky type
                                if (!DBNull.Value.Equals(dt.Rows[i]["SKY_TYPE"])) {
                                    sWxX = (string)dt.Rows[i]["SKY_TYPE"];
                                    if (sWxX == "CB") {
                                        optType1.Checked = true;
                                    } else if (sWxX == "TCU") {
                                        optType2.Checked = true;
                                    }
                                }
                            }
                        }
                        // obstruction
                        txtRVR.Enabled = false;
                        if (!DBNull.Value.Equals(dt.Rows[i]["OBSTRUCTION"])) {
                            string sWxX = (string)dt.Rows[i]["OBSTRUCTION"];
                            optObscruction4.Checked = true;
                            if (sWxX == "FG") {
                                txtRVR.Enabled = true;
                                txtRVR.Value = int.Parse((string)dt.Rows[i]["RVR"]);
                                optObscruction1.Checked = true;
                            } else {
                                if (sWxX == "BR") {
                                    optObscruction2.Checked = true;
                                } else if (sWxX == "HZ") {
                                    optObscruction3.Checked = true;
                                }
                            }
                        }
                        chkRVR.Checked = false;
                        if (!DBNull.Value.Equals(dt.Rows[i]["REPORT_RVR"])) {
                            int iRVRReport = (int)dt.Rows[i]["REPORT_RVR"];
                            if (iRVRReport == 1) {
                                chkRVR.Checked = true;
                            }
                        }
                        optRVRType1.Checked = true;
                    if (!DBNull.Value.Equals(dt.Rows[i]["RVR_TYPE"])) {
                        string sRVRType = (string)dt.Rows[i]["RVR_TYPE"];
                        optRVRType1.Checked = true;
                        if (sRVRType == "METERS") {
                            optRVRType2.Checked = true;
                        }
                    }

                    if (!DBNull.Value.Equals(dt.Rows[i]["NOTAMS"]))
                            txtNotams.Text = (string)dt.Rows[i]["NOTAMS"];
                    }

                    Visibility_Changed();
                    Precip_Changed();
                    Sky_Changed();

                    btnSave.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    btnClear.Enabled = true;
                } else {
                    // clear all entries
                    Clear_Entries();
                }
            //} catch (Exception) {
            //    throw;
            //}
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

        private DateTime GetDateWithoutMilliseconds(DateTime d) {
            return new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e) {
            Save_Data();
        }
        private void Save_Data() {
            try {
                string sVisibility = "1";
                if (optVis1.Checked) {
                    sVisibility = "1/16";
                } else if (optVis2.Checked) {
                    sVisibility = "1/8";
                } else if (optVis3.Checked) {
                    sVisibility = "1/4";
                } else if (optVis4.Checked) {
                    sVisibility = "1/2";
                } else if (optVis5.Checked) {
                    sVisibility = "5/8";
                } else if (optVis6.Checked) {
                    sVisibility = txtVis.Value.ToString();
                }

                string sIntensity = "";
                if (optIntensity1.Checked) {
                    sIntensity = "-";
                } else if (optIntensity2.Checked) {
                    sIntensity = "";
                } else if (optIntensity3.Checked) {
                    sIntensity = "+";
                }

                string sDescriptor= "NONE";
                if (optDescriptor1.Checked) {
                    sDescriptor = "TS";
                } else if (optDescriptor2.Checked) {
                    sDescriptor = "SH";
                } else if (optDescriptor3.Checked) {
                    sDescriptor = "FZ";
                } else if (optDescriptor4.Checked) {
                    sDescriptor = "BL";
                }

                string sPrecipitation = "NONE";
                if (optPrecip1.Checked) {
                    sPrecipitation = "RA";
                } else if (optPrecip2.Checked) {
                    sPrecipitation = "DZ";
                } else if (optPrecip3.Checked) {
                    sPrecipitation = "SN";
                } else if (optPrecip4.Checked) {
                    sPrecipitation = "PL";
                }

                string sSkyAmount = "OVC";
                if (optAmount1.Checked) {
                    sSkyAmount = "SKC";
                } else if (optAmount2.Checked) {
                    sSkyAmount = "FEW";
                } else if (optAmount3.Checked) {
                    sSkyAmount = "SCT";
                } else if (optAmount4.Checked) {
                    sSkyAmount = "BKN";
                }

                string sSkyType = "NONE";
                if (optType1.Checked) {
                    sSkyType = "CB";
                } else if (optType2.Checked) {
                    sSkyType = "TCU";
                }

                string sObstruction = "NONE";
                string sRVR = "6000";
                if (optObscruction1.Checked) {
                    sObstruction = "FG";
                    sRVR = txtRVR.Value.ToString();
                } else if (optObscruction2.Checked) {
                    sObstruction = "BR";
                    sRVR = txtRVR.Value.ToString();
                } else if (optObscruction3.Checked) {
                    sObstruction = "HZ";
                }

                string sQNHType = "inHG";
                if (optHPA.Checked)
                    sQNHType = "hPA";
                string sRVRType = "FEET";
                if (optRVRType2.Checked)
                    sRVRType = "METERS";
                int iRVRReport = 0;
                if (chkRVR.Checked)
                    iRVRReport = 1;

                System.Data.DataRow dr = dtTable.NewRow();
                dr["COND_NAME"] = txtName.Text;
                dr["DATE_CREATED"] = GetDateString(DateTime.Now);
                dr["DATE_EDITED"] = GetDateString(DateTime.Now);
                dr["WIND"] = txtWindDir.Value.ToString();
                dr["CEILING"] = txtCeiling.Value.ToString();
                dr["VISIBILITY"] = sVisibility;
                dr["TEMP"] = txtTemp.Value.ToString();
                dr["QNH"] = txtQNH.Value.ToString();
                dr["RUNWAY_COND"] = cboRCAM.Text;
                dr["SPOT"] = "";
                dr["WIND_VEL"] = txtWindVel.Value.ToString();
                dr["GUST_VEL"] = txtGustVel.Value.ToString();
                dr["STATION"] = cboStation.Text;
                dr["RUNWAY_DEP"] = cboRwyDep.Text;
                dr["RUNWAY_ARR"] = cboRwyArr.Text;
                dr["NOTAMS"] = txtNotams.Text;
                dr["ATIS_DESIGNATOR"] = cboATIS.Text;
                dr["DEWPOINT"] = txtDewpoint.Text;
                dr["QNH_TYPE"] = sQNHType;
                dr["WX_INTENSITY"] = sIntensity;
                dr["WX_DESCRIPTOR"] = sDescriptor;
                dr["WX_PRECIPITATION"] = sPrecipitation;
                dr["SKY_AMOUNT"] = sSkyAmount;
                dr["SKY_TYPE"] = sSkyType;
                dr["OBSTRUCTION"] = sObstruction;
                dr["REPORT_RVR"] = iRVRReport;
                dr["RVR"] = sRVR;
                dr["RVR_TYPE"] = sRVRType;
                dr["APPROACH"] = cboApproach.Text;
                dr["APP_DESIGNATOR"] = cboApproachDesignator.Text;

                dtTable.Rows.Add(dr);
                dataAdapter.Update(dtTable);  // write new row back to database
                iSelected = cboSelect.Items.Count;
                Fill_CBOs(cboSelect, "SELECT * FROM Conditions_WX ORDER BY STATION,ATIS_DESIGNATOR");
                cboSelect.SelectedIndex = 0;
            } catch (Exception) {
                throw;
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e) {
            UpdateDataRow();
        }
        private void UpdateDataRow() {
            if (Get_Selected_Key(cboSelect) > -1) {
                string sVisibility = "1";
                if (optVis1.Checked) {
                    sVisibility = "1/16";
                } else if (optVis2.Checked) {
                    sVisibility = "1/8";
                } else if (optVis3.Checked) {
                    sVisibility = "1/4";
                } else if (optVis4.Checked) {
                    sVisibility = "1/2";
                } else if (optVis5.Checked) {
                    sVisibility = "5/8";
                } else if (optVis6.Checked) {
                    sVisibility = txtVis.Value.ToString();
                }

                string sIntensity = "";
                if (optIntensity1.Checked) {
                    sIntensity = "-";
                } else if (optIntensity2.Checked) {
                    sIntensity = "";
                } else if (optIntensity3.Checked) {
                    sIntensity = "+";
                }

                string sDescriptor = "NONE";
                if (optDescriptor1.Checked) {
                    sDescriptor = "TS";
                } else if (optDescriptor2.Checked) {
                    sDescriptor = "SH";
                } else if (optDescriptor3.Checked) {
                    sDescriptor = "FZ";
                } else if (optDescriptor4.Checked) {
                    sDescriptor = "BL";
                }

                string sPrecipitation = "NONE";
                if (optPrecip1.Checked) {
                    sPrecipitation = "RA";
                } else if (optPrecip2.Checked) {
                    sPrecipitation = "DZ";
                } else if (optPrecip3.Checked) {
                    sPrecipitation = "SN";
                } else if (optPrecip4.Checked) {
                    sPrecipitation = "PL";
                }

                string sSkyAmount = "OVC";
                if (optAmount1.Checked) {
                    sSkyAmount = "SKC";
                } else if (optAmount2.Checked) {
                    sSkyAmount = "FEW";
                } else if (optAmount3.Checked) {
                    sSkyAmount = "SCT";
                } else if (optAmount4.Checked) {
                    sSkyAmount = "BKN";
                }

                string sSkyType = "NONE";
                if (optType1.Checked) {
                    sSkyType = "CB";
                } else if (optType2.Checked) {
                    sSkyType = "TCU";
                }

                string sObstruction = "NONE";
                string sRVR = "6000";
                if (optObscruction1.Checked) {
                    sObstruction = "FG";
                    sRVR = txtRVR.Value.ToString();
                } else if (optObscruction2.Checked) {
                    sObstruction = "BR";
                    sRVR = txtRVR.Value.ToString();
                } else if (optObscruction3.Checked) {
                    sObstruction = "HZ";
                }

                string sQNHType = "inHG";
                if (optHPA.Checked)
                    sQNHType = "hPA";
                string sRVRType = "FEET";
                if (optRVRType2.Checked)
                    sRVRType = "METERS";
                int iRVRReport = 0;
                if (chkRVR.Checked)
                    iRVRReport = 1;

                string strUpdate = "UPDATE Conditions_WX SET " +
                    "COND_NAME = @cond_name," +
                    "DATE_EDITED = @date_edited," +
                    "WIND = @wind," +
                    "CEILING = @ceiling," +
                    "VISIBILITY = @visibility," +
                    "TEMP = @temp," +
                    "QNH = @qnh," +
                    "RUNWAY_COND = @runway_cond," +
                    "SPOT = @spot," +
                    "WIND_VEL = @wind_vel," +
                    "GUST_VEL = @gust_vel," +
                    "STATION = @station," +
                    "RUNWAY_DEP = @runway_dep," +
                    "RUNWAY_ARR = @runway_arr," +
                    "NOTAMS = @notams," +
                    "ATIS_DESIGNATOR = @atis_designator," +
                    "DEWPOINT = @dewpoint," +
                    "QNH_TYPE = @qnh_type," +
                    "WX_INTENSITY = @wx_intensity," +
                    "WX_DESCRIPTOR = @wx_descriptor," +
                    "WX_PRECIPITATION = @wx_precipitation," +
                    "SKY_AMOUNT = @sky_amount," +
                    "SKY_TYPE = @sky_type," +
                    "OBSTRUCTION = @obstruction," +
                    "REPORT_RVR = @report_rvr," +
                    "RVR = @rvr," +
                    "RVR_TYPE = @rvr_type," +
                    "APPROACH = @approach," +
                    "APP_DESIGNATOR = @app_designator" +
                    " WHERE [ID] = @id";

                OleDbCommand cmd = new OleDbCommand(strUpdate, conn);

                cmd.Parameters.AddWithValue("@cond_name", txtName.Text);
                cmd.Parameters.AddWithValue("@date_edited", GetDateString(DateTime.Now));
                cmd.Parameters.AddWithValue("@wind", txtWindDir.Value.ToString());
                cmd.Parameters.AddWithValue("@ceiling", txtCeiling.Value.ToString());
                cmd.Parameters.AddWithValue("@visibility", sVisibility);
                cmd.Parameters.AddWithValue("@temp", txtTemp.Value.ToString());
                cmd.Parameters.AddWithValue("@qnh", txtQNH.Value.ToString());
                cmd.Parameters.AddWithValue("@runway_cond", cboRCAM.Text);
                cmd.Parameters.AddWithValue("@spot", "");
                cmd.Parameters.AddWithValue("@wind_vel", txtWindVel.Value.ToString());
                cmd.Parameters.AddWithValue("@gust_vel", txtGustVel.Value.ToString());
                cmd.Parameters.AddWithValue("@station", cboStation.Text);
                cmd.Parameters.AddWithValue("@runway_dep", cboRwyDep.Text);
                cmd.Parameters.AddWithValue("@runway_arr", cboRwyArr.Text);
                cmd.Parameters.AddWithValue("@notams", txtNotams.Text);
                cmd.Parameters.AddWithValue("@atis_designator", cboATIS.Text);
                cmd.Parameters.AddWithValue("@dewpoint", txtDewpoint.Value.ToString());
                cmd.Parameters.AddWithValue("@qnh_type", sQNHType);
                cmd.Parameters.AddWithValue("@wx_intensity", sIntensity);
                cmd.Parameters.AddWithValue("@wx_descriptor", sDescriptor);
                cmd.Parameters.AddWithValue("@wx_precipitation", sPrecipitation);
                cmd.Parameters.AddWithValue("@sky_amount", sSkyAmount);
                cmd.Parameters.AddWithValue("@sky_type", sSkyType);
                cmd.Parameters.AddWithValue("@obstruction", sObstruction);
                cmd.Parameters.AddWithValue("@report_rvr", iRVRReport);
                cmd.Parameters.AddWithValue("@rvr", txtRVR.Value.ToString());
                cmd.Parameters.AddWithValue("@rvr_type", sRVRType);
                cmd.Parameters.AddWithValue("@approach", cboApproach.Text);
                cmd.Parameters.AddWithValue("@app_designator", cboApproachDesignator.Text);
                cmd.Parameters.AddWithValue("@id", Get_Selected_Key(cboSelect));

                conn.Open();
                int iRows = cmd.ExecuteNonQuery();
                conn.Close();

                int iSelected = cboSelect.SelectedIndex;
                Fill_CBOs(cboSelect, "SELECT * FROM Conditions_WX ORDER BY STATION,ATIS_DESIGNATOR");
                cboSelect.SelectedIndex = iSelected;

            }
        }

        int iSelected =0;
        private void cboWxConditions_SelectedIndexChanged(object sender, EventArgs e) {
            FillData();
        }
        private void Clear_Entries() {
            try {
                txtName.Text = "";
                txtWindDir.Value = 1;
                txtCeiling.Value = 12000;
                txtVis.Value = 10;
                txtTemp.Value = 10;
                txtQNH.Value = 2992;
                cboRCAM.SelectedIndex = 0;
                txtWindVel.Value = 0;
                txtGustVel.Value = 0;
                cboRwyDep.SelectedIndex = 0;
                cboRwyArr.SelectedIndex = 0;
                txtNotams.Text = "";
                cboATIS.SelectedIndex = 0;
                txtDewpoint.Value = 10;
                optINHG.Checked=true;
                optDescriptor5.Checked=true;
                optPrecip5.Checked=true;
                optAmount5.Checked=true;
                optType3.Checked=true;
                optObscruction4.Checked=true;
                chkRVR.Checked=false;
                txtRVR.Value = 0;
                optRVRType1.Checked=true;
                cboApproach.SelectedIndex = 0;
                cboApproachDesignator.SelectedIndex = 0;

                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnClear.Enabled = false;
            } catch (Exception) {
                throw;
            }
        }
        private void Delete_Entry() {
            try {
                iSelected = Get_Selected_Key(cboSelect);
                if (iSelected > -1) {
                    // search for use of this item in any existing spot
                    string sCommand = "SELECT SPOT_NAME, CONDITIONS_WX FROM Spots WHERE CONDITIONS_WX = " + iSelected;
                    OleDbConnection conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
                    conn.Open();
                    OleDbCommand comm = new OleDbCommand(sCommand, conn);
                    OleDbDataReader reader = comm.ExecuteReader();
                    int iCountSPOT = 0;
                    string sSpots = "";
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            iCountSPOT++;
                            if (sSpots != "") {
                                sSpots = sSpots + ", " + reader.GetValue(0).ToString();
                            } else {
                                sSpots = reader.GetValue(0).ToString();
                            }
                        }
                    }
                    reader.Close();
                    conn.Close();

                    // search for use of this item in any existing spot
                    sCommand = "SELECT ACTION_NAME, ATIS FROM Actions WHERE ATIS = " + iSelected;
                    conn.Open();
                    comm = new OleDbCommand(sCommand, conn);
                    reader = comm.ExecuteReader();
                    int iCountATIS = 0;
                    string sATIS = "";
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            iCountATIS++;
                            if (sATIS != "") {
                                sATIS = sATIS + ", " + reader.GetValue(0).ToString();
                            } else {
                                sATIS = reader.GetValue(0).ToString();
                            }
                        }
                    }
                    reader.Close();
                    conn.Close();

                    if (iCountSPOT > 0) {
                        MessageBox.Show("The WEATHER CONDITIONS selected can not be deleted because it is used in the following " + iCountSPOT + " SPOTS: " + sSpots,
                                        "UNABLE TO DELETE RECORD",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return;
                    } else if (iCountATIS > 0) {
                        MessageBox.Show("The WEATHER CONDITIONS selected can not be deleted because it is used in the following " + iCountATIS + " ACTIONS: " + sATIS,
                                        "UNABLE TO DELETE RECORD",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return;
                    }

                    DialogResult result = MessageBox.Show(
                                            "Deleting the selected entry will permantly eliminate it from the database.  Are you sure that you would like to DELETE?",
                                            "DELETE SELECTED RECORD?",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Warning,
                                            MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes) {
                        string sQuery = "DELETE FROM Conditions_WX WHERE ID=" + Get_Selected_Key(cboSelect);
                        conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
                        conn.Open();
                        OleDbCommand commandBuilder = new OleDbCommand(sQuery, conn);
                        commandBuilder.ExecuteNonQuery();
                        conn.Close();
                        Clear_Entries();
                        Fill_CBOs(cboSelect, "SELECT * FROM Conditions_WX ORDER BY STATION,ATIS_DESIGNATOR");
                    }
                }

            } catch (Exception) {
                throw;
            }
        }


        private void btnDelete_Click(object sender, EventArgs e) {
            Delete_Entry();
        }

        private void txtVisibility_ValueChanged(object sender, EventArgs e) {

        }

        private void cboStation_DropDownClosed(object sender, EventArgs e) {
            string sStation = "";
            sStation = cboStation.Text;
            if (sStation.Length == 4) {
                Fill_Runways(cboRwyDep, "SELECT * FROM Airport_Runways WHERE ICAO = '" + sStation + "'");
                Fill_Runways(cboRwyArr, "SELECT * FROM Airport_Runways WHERE ICAO = '" + sStation + "'");
            }
        }

        // visibility
        private void optVis1_CheckedChanged(object sender, EventArgs e) {
            Visibility_Changed();
        }
        private void optVis2_CheckedChanged(object sender, EventArgs e) {
            Visibility_Changed();
        }
        private void optVis3_CheckedChanged(object sender, EventArgs e) {
            Visibility_Changed();
        }
        private void optVis4_CheckedChanged(object sender, EventArgs e) {
            Visibility_Changed();
        }
        private void optVis5_CheckedChanged(object sender, EventArgs e) {
            Visibility_Changed();
        }
        private void optVis6_CheckedChanged(object sender, EventArgs e) {
            Visibility_Changed();
        }
        private void txtVis_ValueChanged(object sender, EventArgs e) {
            Visibility_Changed();
        }
        private void chkRVR_CheckedChanged(object sender, EventArgs e) {
            Visibility_Changed();
        }
        private void optRVRType1_CheckedChanged(object sender, EventArgs e) {
            Visibility_Changed();
        }
        private void optRVRType2_CheckedChanged(object sender, EventArgs e) {
            Visibility_Changed();
        }
        private void Visibility_Changed() {
            /*
            RVR: 100' increments below 800', 200' increments between 800' and 3,000', 
            and 500' increments between 3,000' 6,500'
            */

            // get RVR
            string sRVR = "";
            int iSelected = Get_Selected_Key(cboSelect);
            if (cboSelect.SelectedIndex > 0 || iSelected > -1) {
                string sCommand = "SELECT * FROM CONDITIONS_WX WHERE ID = " + iSelected;
                conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
                DataTable dt = new DataTable();
                dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dAdapter.Fill(dt);
                conn.Close();
                for (int i = 0; i <= dt.Rows.Count - 1; i++) {
                    if (!DBNull.Value.Equals(dt.Rows[i]["RVR"]))
                        sRVR = (string)dt.Rows[i]["RVR"];
                }
            }

            chkRVR.Enabled = true;
            if (optVis1.Checked) {
                // vis 1/16SM
                txtVis.Enabled = false;
                optObscruction1.Enabled = true;
                optObscruction2.Enabled = true;
                lblRVR.Enabled = false;
                if (chkRVR.Checked) {
                    lblRVR.Enabled = true;
                    if (sRVR == "") {
                        txtRVR.Value = 300;
                        if (optRVRType2.Checked)
                            txtRVR.Value = 100;
                    }
                }
            } else if (optVis2.Checked) {
                // vis 1/8SM
                txtVis.Enabled = false;
                optObscruction1.Enabled = true;
                optObscruction2.Enabled = true;
                lblRVR.Enabled = false;
                if (chkRVR.Checked) {
                    lblRVR.Enabled = true;
                    if (sRVR == "") {
                        txtRVR.Value = 600;
                        if (optRVRType2.Checked)
                            txtRVR.Value = 175;
                    }
                }
            } else if (optVis3.Checked) {
                // vis 1/4SM
                txtVis.Enabled = false;
                optObscruction1.Enabled = true;
                optObscruction2.Enabled = true;
                lblRVR.Enabled = false;
                if (chkRVR.Checked) {
                    lblRVR.Enabled = true;
                    if (sRVR == "") {
                        txtRVR.Value = 1200;
                        if (optRVRType2.Checked)
                            txtRVR.Value = 350;
                    }
                }
            } else if (optVis4.Checked) {
                // vis 1/2SM
                txtVis.Enabled = false;
                optObscruction1.Enabled = true;
                optObscruction2.Enabled = true;
                lblRVR.Enabled = false;
                if (chkRVR.Checked) {
                    lblRVR.Enabled = true;
                    if (sRVR == "") {
                        txtRVR.Value = 2400;
                        if (optRVRType2.Checked)
                            txtRVR.Value = 750;
                    }
                }
            } else if (optVis5.Checked) {
                txtVis.Enabled = false;
                optObscruction1.Enabled = false;
                optObscruction2.Enabled = true;
                if (optObscruction1.Checked) {
                    optObscruction2.Checked = true;
                }
                lblRVR.Enabled = false;
                if (chkRVR.Checked) {
                    lblRVR.Enabled = true;
                    if (sRVR == "") {
                        txtRVR.Value = 3600;
                        if (optRVRType2.Checked)
                            txtRVR.Value = 1100;
                    }
                }
            } else if (optVis6.Checked) {
                // vis > 1SM
                txtVis.Enabled = true;
                chkRVR.Enabled = false;
                lblRVR.Enabled = false;
                txtRVR.Value = 6000;
                optObscruction1.Enabled = false;
                optObscruction2.Enabled = true;
                if (optObscruction1.Checked) {
                    optObscruction2.Checked = true;
                }
                if (txtVis.Value > 6) {
                    // vis > 6SM
                    txtVis.Enabled = true;
                    txtRVR.Enabled = false;
                    lblRVR.Enabled = false;
                    optObscruction1.Enabled = false;
                    optObscruction2.Enabled = false;
                    if (optObscruction1.Checked || optObscruction2.Checked)
                        optObscruction4.Checked = true;
                }
            }
        }

        // precip
        private void optPrecip1_CheckedChanged(object sender, EventArgs e) {
            Precip_Changed();
        }
        private void optPrecip2_CheckedChanged(object sender, EventArgs e) {
            Precip_Changed();
        }
        private void optPrecip3_CheckedChanged(object sender, EventArgs e) {
            Precip_Changed();
        }
        private void optPrecip4_CheckedChanged(object sender, EventArgs e) {
            Precip_Changed();
        }
        private void optPrecip5_CheckedChanged(object sender, EventArgs e) {
            Precip_Changed();
        }
        private void Precip_Changed() {
            if (optPrecip5.Checked) {
                // no precip
                cboRCAM.SelectedIndex = 1;
                optIntensity1.Enabled = false;
                optIntensity2.Enabled = false;
                optIntensity3.Enabled = false;
                optDescriptor1.Enabled = false;
                optDescriptor2.Enabled = false;
                optDescriptor3.Enabled = false;
                optDescriptor4.Enabled = false;
                optIntensity1.Checked = false;
                optIntensity2.Checked = false;
                optIntensity3.Checked = false;
                optDescriptor5.Checked = true;
            } else if (optPrecip1.Checked || optPrecip2.Checked || optPrecip3.Checked || optPrecip4.Checked) {
                // some type of precip selected
                if (optPrecip1.Checked || optPrecip2.Checked) {
                    // RA & DZ, set RCAM to WET
                    cboRCAM.SelectedIndex = 2;
                } else if (optPrecip3.Checked || optPrecip4.Checked) {
                    // RA & DZ, set RCAM to WET
                    cboRCAM.SelectedIndex = 4;
                }
                optIntensity1.Enabled = true;
                optIntensity2.Enabled = true;
                optIntensity3.Enabled = true;
                optDescriptor1.Enabled = true;
                optDescriptor2.Enabled = true;
                optDescriptor3.Enabled = true;
                optDescriptor4.Enabled = true;
                if (!optIntensity1.Checked && !optIntensity2.Checked && !optIntensity3.Checked) {
                    // if nothing else checked, set to light by default
                    optIntensity1.Checked = true;
                }
            }
        }

        // sky conditions
        private void optAmount1_CheckedChanged(object sender, EventArgs e) {
            Sky_Changed();
        }
        private void optAmount2_CheckedChanged(object sender, EventArgs e) {
            Sky_Changed();
        }
        private void optAmount3_CheckedChanged(object sender, EventArgs e) {
            Sky_Changed();
        }
        private void optAmount4_CheckedChanged(object sender, EventArgs e) {
            Sky_Changed();
        }
        private void optAmount5_CheckedChanged(object sender, EventArgs e) {
            Sky_Changed();
        }
        private void Sky_Changed() {
            if (optAmount1.Checked) {
                // skc
                optType1.Enabled = false;
                optType2.Enabled = false;
                txtCeiling.Enabled = false;
                lblCeiling.Enabled = false;
                optType3.Checked = true;
            } else if (optAmount2.Checked || optAmount3.Checked || optAmount4.Checked || optAmount5.Checked) {
                // some type of precip selected
                optType1.Enabled = true;
                optType2.Enabled = true;
                txtCeiling.Enabled = true;
                lblCeiling.Enabled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e) {
            Clear_Entries();
        }
    }
}