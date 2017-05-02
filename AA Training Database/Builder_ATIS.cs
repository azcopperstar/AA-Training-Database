using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1 {
    class Builder_ATIS {

        static string sReturn;

        public static string CompleteATIS(DataRow row) {
            sReturn = "";
            try {
                string sATIS = "";
                sATIS = ATIS_Designator(row) + " 0000Z."
                            + " " + Wind(row)
                            + " " + Visibility(row)
                            + " " + Sky(row)
                            + " " + TempDp(row)
                            + " " + QNH(row, true)
                            + ". " + Runways(row, true);
                //+ " " + RCAM(row)
                //+ " NOTAMS... " + Notams(row);

                if (Notams(row) != "")
                    sATIS = sATIS + " NOTAMS... " + Notams(row);
                sReturn = sATIS;
                return sReturn;
            } catch (Exception) {
                return sReturn;
                throw;
            }
        }
        public static string Get_Action_Atis(int iWX) {
            string sATIS = "";
            DataTable dt = new DataTable();
            dt = Get_Selected_DataTable_ID(iWX, "Conditions_WX");
            if (dt != null) {
                foreach (DataRow row in dt.Rows) {
                    sATIS = "\r\n\r\n" + Builder_ATIS.CompleteATIS(row);
                }
            }
            return sATIS;
        }
        public static DataTable Get_Selected_DataTable_ID(int iID, string sTable) {
            OleDbConnection conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
            DataTable dt = new DataTable();
            string sCommand = "SELECT * FROM " + sTable + " WHERE ID = " + iID;
            conn.Open();
            OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
            dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dAdapter.Fill(dt);
            conn.Close();
            return dt;
        }

        public static string ATIS_Designator(DataRow row) {
            sReturn = "";
            try {
                // atis info
                string sATIS = "";
                if (!DBNull.Value.Equals(row["ATIS_DESIGNATOR"]))
                    sATIS = " ATIS INFO " + (string)row["ATIS_DESIGNATOR"];
                if (!DBNull.Value.Equals(row["STATION"])) {
                    sATIS = (string)row["STATION"] + sATIS;
                }
                sReturn = sATIS;
                return sReturn;
            } catch (Exception) {
                return sReturn;
                throw;
            }
        }
        public static string Wind(DataRow row) {
            sReturn = "";
            try {
                string sWind = "";
                string sWindVel = (string)row["WIND_VEL"];
                string sGustVel = (string)row["GUST_VEL"];
                if (int.Parse(sWindVel) > 0) {
                    // create wind string
                    sWind = (string)row["WIND"];
                    if (sWind.Length == 1) {
                        sWind = "00" + sWind;
                    } else if (sWind.Length == 2) {
                        sWind = "0" + sWind;
                    }
                    if (sWindVel.Length == 1) {
                        sWindVel = "0" + sWindVel;
                    }
                    int iGustVel = int.Parse(sGustVel);
                    if (iGustVel > 0) {
                        if (sGustVel.Length == 1) {
                            sGustVel = "0" + sGustVel;
                        }
                        sGustVel = "G" + sGustVel;
                    } else {
                        sGustVel = "";
                    }
                }
                sReturn = sWind + sWindVel + sGustVel + "KT";
                return sReturn;
            } catch (Exception) {
                return sReturn;
                throw;
            }
        }

        public static string Visibility(DataRow row) {
            sReturn = "";
            try {
                string sVis = "";
                if (!DBNull.Value.Equals(row["VISIBILITY"])) {
                    sVis = (string)row["VISIBILITY"] + "SM";
                    // obstruction
                    if (!DBNull.Value.Equals(row["OBSTRUCTION"])) {
                        if ((string)row["OBSTRUCTION"] != "NONE") {
                            // add obstruction
                            sVis = sVis + " " + (string)row["OBSTRUCTION"];
                        }
                    }
                    if (!DBNull.Value.Equals(row["REPORT_RVR"])) {
                        if ((int)row["REPORT_RVR"] == 1) {
                            if (!DBNull.Value.Equals(row["RVR"])) {
                                if (!DBNull.Value.Equals(row["RUNWAY_ARR"])) {
                                    // add runway for rvr
                                    sVis = sVis + " R" + (string)row["RUNWAY_ARR"] + "/";
                                }
                            }
                            if (!DBNull.Value.Equals(row["RVR"])) {
                                // add rvr value
                                sVis = sVis + (string)row["RVR"];
                            }
                            if (!DBNull.Value.Equals(row["RVR_TYPE"])) {
                                // add rvr type
                                if ((string)row["RVR_TYPE"] == "METERS") {
                                    sVis = sVis + "M";
                                } else {
                                    sVis = sVis + "FT";
                                }
                            }
                        }
                    }

                }
                sReturn = sVis;
                return sReturn;
            } catch (Exception) {
                return sReturn;
                throw;
            }
        }

        public static string Sky(DataRow row) {
            sReturn = "";
            try {
                string sSky = (string)row["SKY_AMOUNT"];
                string sCeiling = (string)row["CEILING"];
                if (sSky != "SKC") {
                    // format ceiling
                    if (sCeiling.Length == 1) {
                        // 0 to 000
                        sCeiling = "000";
                    } else if (sCeiling.Length == 3) {
                        // 200 to 002
                        sCeiling = "00" + sCeiling.Substring(0, 1);
                    } else if (sCeiling.Length == 4) {
                        // 2000 to 020
                        sCeiling = "0" + sCeiling.Substring(0, 2);
                    } else if (sCeiling.Length == 5) {
                        // 12000 to 120
                        sCeiling = sCeiling.Substring(0, 3);
                    }
                    sSky = sSky + sCeiling;
                    // sky type
                    if (!DBNull.Value.Equals(row["SKY_TYPE"]) && (string)row["SKY_TYPE"] != "NONE") {
                        sSky = sSky + (string)row["SKY_TYPE"];
                    }
                    if (!DBNull.Value.Equals(row["WX_PRECIPITATION"])) {
                        string sPrecip = (string)row["WX_PRECIPITATION"];
                        if (sPrecip != "NONE") {
                            // build precip string
                            if (!DBNull.Value.Equals(row["WX_INTENSITY"])) {
                                sSky = sSky + " " + (string)row["WX_INTENSITY"] + sPrecip;
                            }
                            // descriptor
                            if (!DBNull.Value.Equals(row["WX_DESCRIPTOR"])) {
                                if ((string)row["WX_DESCRIPTOR"] != "NONE") {
                                    sSky = sSky + (string)row["WX_DESCRIPTOR"];
                                }
                            }
                        }
                    }
                }
                sReturn = sSky;
                return sReturn;
            } catch (Exception) {
                return sReturn;
                throw;
            }
        }

        public static string TempDp(DataRow row) {
            sReturn = "";
            try {
                string sTempDp = (string)row["TEMP"];
                string sMinusT = "";
                if (sTempDp.IndexOf("-") > -1) {
                    // minus value
                    sMinusT = "M";
                    sTempDp = sTempDp.Substring(1, sTempDp.Length - 1);
                }
                if (sTempDp.Length < 2) {
                    // 4 to 04
                    sTempDp = "0" + sTempDp;
                }
                sTempDp = sMinusT + sTempDp;

                string sDp = (string)row["DEWPOINT"];
                string sMinusD = "";
                if (sDp.IndexOf("-") > -1) {
                    // minus value
                    sMinusD = "M";
                    sDp = sDp.Substring(1, sDp.Length - 1);
                }
                if (sDp.Length < 2) {
                    // 4 to 04
                    sDp = "0" + sDp;
                }
                sDp = sMinusD + sDp;
                sTempDp = sTempDp + "/" + sDp;
                sReturn = sTempDp;
                return sReturn;
            } catch (Exception) {
                return sReturn;
                throw;
            }
        }

        public static string QNH(DataRow row, Boolean bLong) {
            sReturn = "";
            try {
                string sQNH = (string)row["QNH"];
                if (bLong)
                    sQNH = sQNH + " " + QNHText(sQNH);

                if (!DBNull.Value.Equals(row["QNH_TYPE"])) {
                    string sQNHType = (string)row["QNH_TYPE"];
                    if (sQNHType == "hPA") {
                        sQNH = "Q" + sQNH;
                    } else {
                        sQNH = "A" + sQNH;
                    }
                }
                sReturn = sQNH;
                return sReturn;
            } catch (Exception) {
                return sReturn;
                throw;
            }
        }
        private static string QNHText(string sQNH) {
            sReturn = "";
            try {
                foreach (char c in sQNH) {
                    string sNumber = c.ToString();
                    if (sNumber == "0") {
                        sReturn = sReturn +  " ZERO";
                    } else if (sNumber == "1") {
                        sReturn = sReturn + " ONE";
                    } else if (sNumber == "2") {
                        sReturn = sReturn + " TWO";
                    } else if (sNumber == "3") {
                        sReturn = sReturn + " THREE";
                    } else if (sNumber == "4") {
                        sReturn = sReturn + " FOUR";
                    } else if (sNumber == "5") {
                        sReturn = sReturn + " FIVE";
                    } else if (sNumber == "6") {
                        sReturn = sReturn + " SIX";
                    } else if (sNumber == "7") {
                        sReturn = sReturn + " SEVEN";
                    } else if (sNumber == "8") {
                        sReturn = sReturn + " EIGHT";
                    } else if (sNumber == "9") {
                        sReturn = sReturn + " NINER";
                    }
                }
                sReturn = "(" + sReturn.Trim() + ")";
                return sReturn;
            } catch (Exception) {
                return sReturn;
                throw;
            }
        }

        public static string Runways(DataRow row, bool sLong) {
            sReturn = "";
            try {
                string sRwyDep = "";
                string sRwyArr = "";
                string sRwyArrApp = "";
                if (!DBNull.Value.Equals(row["RUNWAY_DEP"])) {
                    sRwyDep = (string)row["RUNWAY_DEP"];
                }
                if (!DBNull.Value.Equals(row["RUNWAY_ARR"])) {
                    sRwyArr = (string)row["RUNWAY_ARR"];
                }
                if (!DBNull.Value.Equals(row["APPROACH"]))
                    sRwyArrApp = (string)row["APPROACH"];
                if (!DBNull.Value.Equals(row["APP_DESIGNATOR"]))
                    sRwyArrApp = sRwyArrApp + " " + (string)row["APP_DESIGNATOR"];

                if (sLong) {
                    sReturn = " EXPECT " + sRwyArrApp + " APCH RWY " + sRwyArr + ". DEPARTING RWY " + sRwyDep + ".";

                } else {
                    sReturn = sRwyDep + " / " + sRwyArrApp + " " + sRwyArr;
                }
                return sReturn;
            } catch (Exception) {
                return sReturn;
                throw;
            }
        }

        public static string RCAM(DataRow row) {
            sReturn = "";
            try {
                string sRCAM = "";
                if (!DBNull.Value.Equals(row["RUNWAY_COND"]))
                    sRCAM = (string)row["RUNWAY_COND"];
                sReturn = sRCAM;
                return sReturn;
            } catch (Exception) {
                return sReturn;
                throw;
            }
        }

        public static string Notams(DataRow row) {
            sReturn = "";
            try {
                string sNotams = "";
                if (!DBNull.Value.Equals(row["NOTAMS"]))
                    sNotams = (string)row["NOTAMS"];
                sReturn = sNotams;
                return sReturn;
            } catch (Exception) {
                return sReturn;
                throw;
            }
        }



    }
}
