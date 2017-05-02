using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    class GlobalCode {
        public static int[] iSPOTList;
        public static int[] iLessonList;
        public static string sOleDbConnectionString;
        public static OleDbConnection conn;

        public static string sCARRIER;
        public static string sPATH_IMAGE_PDF;

        public static string sPATH_APP;
        public static string sPATH_LOGO;
        public static string sPATH_DATA;
        public static string sFILE_DATA;
        public static string sPATH_FILE_DATA;
        public static string sPATH_FILE_DATA_BACKUP;

        public static bool bFirstRun;

        public static int iFleet;
        public static string sFleet;

        public static string sPATH_PDF;
        public static string sFILE_PDF;


        //public static string sRTFSender;
        //public static string sRTFData;
        //public static string sPDFFile;

        public static string Convert_MinutesToTime(int iMinutes) {
            TimeSpan span = TimeSpan.FromMinutes(iMinutes);
            string sTime = span.ToString(@"hh\:mm");
            return sTime;
        }

        public static int GetCboID(ComboBox comboBox) {
            int iID = -1;
            if (comboBox.SelectedIndex > 0) {
                // save ID of selected item (NOT the selectedindex)
                KeyValuePair<int, string> selectedPair = (KeyValuePair<int, string>)comboBox.SelectedItem;
                if (selectedPair.Key > -1)
                    iID = selectedPair.Key;
            }
            return iID;
        }
        public static void SetCboID(ComboBox comboBox, int iID) {
            comboBox.SelectedIndex = 0;
            // try to set the cbo back to the previously selected item by looking for its ID (NOT the selectedindex)
            foreach (KeyValuePair<int, string> keyID in comboBox.Items) {
                if (keyID.Key == iID) {
                    // match found (has not been deleted)
                    comboBox.SelectedIndex = comboBox.Items.IndexOf(keyID);
                }
            }
        }

    }
}
