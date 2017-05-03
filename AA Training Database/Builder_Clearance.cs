using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1 {
    class Builder_Clearance {

        static string sReturn;
        static string sLF = "\n\r";

        public static string Build_PDC(DataRow row) {
            sReturn = "";
            try {
                string sPDC = "";
                sPDC = "PDC AAL" + row["FLTNUM"].ToString();
                sPDC = sPDC + ". XPNDR " + row["XPNDR"].ToString();
                sPDC = sPDC + ". " + row["DEP"].ToString();
                if((string)row["SID"] != "")
                    sPDC = sPDC + " " + row["SID"].ToString();
                if ((string)row["SID_TRANS"] != "")
                    sPDC = sPDC + " " + row["SID_TRANS"].ToString();
                if ((int)row["AS_FILED"] == 0) {
                    sPDC = sPDC + " " + (string)row["ENROUTE"];
                } else {
                    sPDC = sPDC + " AS FILED";
                }
                if ((string)row["STAR_TRANS"] != "")
                    sPDC = sPDC + " " + (string)row["STAR_TRANS"];
                if ((string)row["STAR"] != "")
                    sPDC = sPDC + " " + (string)row["STAR"];
                sPDC = sPDC + " " + (string)row["DEST"];
                if ((int)row["CLIMB_VIA"] == 0) {
                    if ((string)row["SID"] != "") {
                        sPDC = sPDC + ". CLIMB VIA SID EXCEPT MAINTAIN " + row["ALT_INIT"].ToString();
                    } else {
                        sPDC = sPDC + ". CLIMB AND MAINTAIN " + row["ALT_INIT"].ToString();
                    }
                } else {
                    sPDC = sPDC + ". CLIMB VIA SID";
                }
                sPDC = sPDC + ". EXP FL" + row["ALT_EXPECT"].ToString() + " " + row["EXPECT_TIME"].ToString() + " MIN AFT DEP,";
                sPDC = sPDC + " DPFRQ " + row["DEP_FREQ"].ToString() + ".";

                sReturn = sPDC;
                return sReturn;
            } catch (Exception) {
                return sReturn;
                throw;
            }
        }

        public static string Get_Action_PDC(int iWX) {
            string sPDC = "";
            DataTable dt = new DataTable();
            dt = Get_Selected_DataTable_ID(iWX, "Clearance");
            if (dt != null) {
                foreach (DataRow row in dt.Rows) {
                    sPDC = "\r\n" + Build_PDC(row);
                }
            }
            return sPDC;
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

        public static DataTable Get_Selected_DataTable_DEP(string sDEP) {
            //OleDbConnection conn = new OleDbConnection(GlobalCode.sOleDbConnectionStringAirport);
            DataTable dt = new DataTable();
            string sCommand = "SELECT * FROM Airport_Runways WHERE ICAO = '" + sDEP + "'";
            GlobalCode.connAirport.Open();
            OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionStringAirport);
            //dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dAdapter.Fill(dt);
            GlobalCode.connAirport.Close();
            return dt;
        }





    }
}
