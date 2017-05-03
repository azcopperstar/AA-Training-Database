using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;

namespace WindowsFormsApplication1 {
    class GlobalCode {
        public static int[] iSPOTList;
        public static int[] iLessonList;

        public static int iLesson;

        public static string sOleDbConnectionString;
        public static OleDbConnection connData;
        public static string sOleDbConnectionStringAirport;
        public static OleDbConnection connAirport;

        public static string sCARRIER;
        public static string sPATH_IMAGE_PDF;

        public static string sPATH_OPTIONS;

        public static string sPATH_APP;
        public static string sPATH_LOGO;
        public static string sPATH_DATA;
        public static string sFILE_DATA;
        public static string sPATH_FILE_DATA;
        public static string sPATH_FILE_DATA_BACKUP;

        public static string sPATH_FILE_AIRPORT;

        public static bool bFirstRun;

        public static int iFleet;
        public static string sFleet;

        public static string sPATH_PDF;
        public static string sFILE_PDF;


        //public static string sRTFSender;
        //public static string sRTFData;
        //public static string sPDFFile;

        public static void DATA_BACKUP(string sContingent) {
            try {
                if (!File.Exists(sPATH_FILE_DATA)) {
                    // data file does not exist, exit
                    return;
                }
                if (sPATH_FILE_DATA_BACKUP == "") {
                    // backup path empty, set to app path
                    sPATH_FILE_DATA_BACKUP = sPATH_APP + "\\Backup";
                }

                if (!Directory.Exists(sPATH_FILE_DATA_BACKUP)) {
                    // create the folder
                    Directory.CreateDirectory(sPATH_FILE_DATA_BACKUP);
                }

                string destZipFile = sPATH_FILE_DATA_BACKUP + "\\" + BackupDateString() + "_" + sContingent + "_" + sFleet + "_Data_Backup.zip";
                using (ZipFile zipF = new ZipFile(destZipFile)) {
                    ZipEntry ze = zipF.UpdateFile(sPATH_FILE_DATA, string.Empty);
                    ze.Comment = "Working copy stored in date: " + DateTime.Today.ToShortDateString();
                    zipF.Comment = "This zip archive created: " + BackupDateString();
                    zipF.Save();
                }
                //File.Copy(sPATH_FILE_DATA, sPATH_FILE_DATA + "_archive_" + BackupDateString(), true);
            } catch (Exception) {
                throw;
            }
        }
        public static string BackupDateString() {
            try {
                DateTime d = DateTime.Now;
                object value = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
                DateTime result = (DateTime)value;
                string sResult = result.ToString("MMddyyyy_HHmmss");
                return sResult;
            } catch (Exception) {
                throw;
            }
        }
        public static string GetDateString(DateTime d) {
            try {
                object value = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
                DateTime result = (DateTime)value;
                string sResult = result.ToString("M/d/yyyy HHmm");
                return sResult;

            } catch (Exception) {
                throw;
            }
        }

        public static string CheckForNullString(DataRow row, string fieldName) {
            if (!DBNull.Value.Equals(row[fieldName]))
                return (string)row[fieldName];
            else
                return "";
        }
        public static int CheckForNullInt(DataRow row, string fieldName) {
            if (!DBNull.Value.Equals(row[fieldName]))
                return (int)row[fieldName];
            else
                return 0;
        }
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
