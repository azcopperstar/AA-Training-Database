using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        /*
            // read setting
            string setting1 = (string)Settings.Default["MySetting1"];

            // save setting
            Settings.Default["MySetting2"] = "My Setting Value";

            // you can force a save with
            Properties.Settings.Default.Save();

            // force upgrade of settings
            Properties.Settings.Default.Upgrade(); 
        */

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // force upgrade of settings: this is due to updates creating new settings file
            Settings.Default.Upgrade();

            Load_App();

            Application.Run(new frmBuilderSpot());

        }

        public static void Load_App() {

            // set the app path for a default data app on first run
            GlobalCode.sPATH_APP = Application.StartupPath;


            // read setting
            GlobalCode.sFleet = (string)Settings.Default.FLEET;
            GlobalCode.sPATH_DATA = (string)Settings.Default.PATH_DB;
            GlobalCode.sFILE_DATA = (string)Settings.Default.FILE_DB;
            GlobalCode.sPATH_FILE_DATA_BACKUP = (string)Settings.Default.FILE_DB_BACKUP;

            GlobalCode.bFirstRun = false;
            //GlobalCode.bFirstRun = true;
            GlobalCode.sPATH_FILE_DATA = GlobalCode.sPATH_DATA + GlobalCode.sFILE_DATA;
            if (GlobalCode.sPATH_DATA == "" || !File.Exists(GlobalCode.sPATH_FILE_DATA)) {
                // set flag and load default database
                GlobalCode.bFirstRun = true;
                GlobalCode.sFILE_DATA = "\\TSD_.accdb";
                GlobalCode.sPATH_DATA = GlobalCode.sPATH_APP;
            }
            GlobalCode.sPATH_FILE_DATA = GlobalCode.sPATH_DATA + GlobalCode.sFILE_DATA;

            DataSet ds = new DataSet();
            //OleDbDataAdapter dataAdapter = null;
            //DataTable dtTable = null;

            GlobalCode.sOleDbConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + GlobalCode.sPATH_FILE_DATA;
            GlobalCode.conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);


            if (GlobalCode.bFirstRun) {
                // first run- launch prefs form
                frmOptions frmOptions = new frmOptions();
                frmOptions.ShowDialog();
                // return from prefs page, set path to newly sellected path
                GlobalCode.sPATH_FILE_DATA = GlobalCode.sPATH_DATA + GlobalCode.sFILE_DATA;
                GlobalCode.sOleDbConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + GlobalCode.sPATH_FILE_DATA;
            }

            string sCommand = "SELECT * FROM Options WHERE ID = 1";
            GlobalCode.conn.Open();
            OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
            DataTable dt = new DataTable();
            dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dAdapter.Fill(dt);
            GlobalCode.conn.Close();

            for (int i = 0; i <= dt.Rows.Count - 1; i++) {

                GlobalCode.iFleet = (int)dt.Rows[i]["AIRCRAFT"];
                if ((string)dt.Rows[i]["FLEET"] != "0") {
                    GlobalCode.sFleet = (string)dt.Rows[i]["FLEET"];
                } else {
                    GlobalCode.sFleet = "";
                }
                //GlobalCode.sFleet = (string)Settings.Default.FLEET;

                if ((string)dt.Rows[i]["PATH_LOGO"] != "0") {
                    GlobalCode.sPATH_LOGO = (string)dt.Rows[i]["PATH_LOGO"];
                } else {
                    GlobalCode.sPATH_LOGO = "";
                }
                if ((string)dt.Rows[i]["PATH_IMAGE_PDF"] != "0") {
                    GlobalCode.sPATH_IMAGE_PDF = (string)dt.Rows[i]["PATH_IMAGE_PDF"];
                } else {
                    GlobalCode.sPATH_IMAGE_PDF = "";
                }
                GlobalCode.sCARRIER = (string)dt.Rows[i]["CARRIER"];
                if ((string)dt.Rows[i]["PATH_DB_BACKUP"] != "0") {
                    GlobalCode.sPATH_FILE_DATA_BACKUP = (string)dt.Rows[i]["PATH_DB_BACKUP"];
                } else {
                    GlobalCode.sPATH_FILE_DATA_BACKUP = "";
                }

                if ((string)dt.Rows[i]["PATH_PDF"] != "0") {
                    GlobalCode.sPATH_PDF = (string)dt.Rows[i]["PATH_PDF"];
                } else {
                    GlobalCode.sPATH_PDF = "";
                }
                if ((string)dt.Rows[i]["FILE_PDF"] != "0") {
                    GlobalCode.sFILE_PDF = (string)dt.Rows[i]["FILE_PDF"];
                } else {
                    GlobalCode.sFILE_PDF = "";
                }
            }

        }
    }
}
