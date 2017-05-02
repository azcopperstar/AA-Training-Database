using Microsoft.Reporting.WinForms;
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

namespace WindowsFormsApplication1

{
    public partial class frmReportViewer : Form{
        // Instantiate the ScriptData class.
        private ScriptData m_SimScript = new ScriptData();

        public frmReportViewer(){
            InitializeComponent();
        }
        //private OleDbConnection conn;
        //DataSet ds = new DataSet();
        //private OleDbDataAdapter dataAdapter;

        private void Form1_Load(object sender, EventArgs e){

            //DataSet ds = new DataSet();
            //DataTable dtReport = new DataTable();
            int[] iNumbers = GlobalCode.iSPOTList;
            //dtReport = Data(iNumbers, dtReport);
            //ds.DataSetName = "DataSet2";
            //ds.Tables.Add(dtReport);

            reportViewer1.ProcessingMode = ProcessingMode.Local;
            ////reportViewer1.Reset();
            ////this.reportViewer1.LocalReport.ReportPath = Microsoft.SqlServer.Server.MapPath("Report1.rdlc");
            //ReportDataSource rds = new ReportDataSource("DataSet2", ds.Tables[0]);
            ReportDataSource rds = new ReportDataSource("DataSet2", m_SimScript.GetScriptData());
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.EnableHyperlinks = true;
            reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SetSubDataSource);

            // Bind the ScriptData collection to the DataSource.
            //this.bindingSource1.DataSource = m_SimScript.GetScriptData();
            reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            
        }
        public void SetSubDataSource(object sender, SubreportProcessingEventArgs e) {
            e.DataSources.Add(new ReportDataSource("DataSet1", m_SimScript.GetScriptData()));
        }

        //        private DataTable Data(int[] numbers, DataTable dtReport) {
        //            //DataTable dtReport = new DataTable();
        //            dtReport = CreateColumns(dtReport);

        //            conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
        //            conn.Open();
        //            int iCount = 0;
        //            foreach (int i in numbers) {
        //                iCount++;
        //                DataTable dtLoop = new DataTable();
        //                if (iCount == 1) {
        ////                    dataAdapter.Fill(dtReport);
        //                } else {
        //                    //dataAdapter.Fill(dtLoop);
        //                    dtReport.Rows.Add(FillRow(dtReport, i));

        //                    //foreach (DataRow drtableOld in dtLoop.Rows) {
        //                    //    dtReport.ImportRow(drtableOld);
        //                    //}
        //                }
        //            }
        //            conn.Close();
        //            return dtReport;
        //        }
        //private DataRow FillRow(DataTable dtLoop, int ID) {
        //    DataRow drNew = dtLoop.NewRow();
        //    DataTable dtSpot = new DataTable();
        //    DataTable dtTemp = new DataTable();
        //    OleDbDataAdapter daTemp = new OleDbDataAdapter();
        //    //conn.Open();

        //    string selectCommand = "SELECT * FROM Spots WHERE ID=" + ID;
        //    OleDbCommand comm = new OleDbCommand(selectCommand, conn);
        //    dataAdapter = new OleDbDataAdapter(selectCommand, GlobalCode.sOleDbConnectionString);
        //    dataAdapter.Fill(dtSpot);

        //    foreach (DataRow row in dtSpot.Rows) {
        //        // spot specific entries
        //        drNew["SPOT_NAME"] = row["SPOT_NAME"].ToString();
        //        drNew["MINUTES"] = row["MINUTES"].ToString();
        //        drNew["SPOT_NOTE_1"] = row["SPOT_NOTE_1"].ToString();
        //        drNew["SPOT_NOTE_2"] = row["SPOT_NOTE_2"].ToString();
        //        drNew["SPOT_NOTE_3"] = row["SPOT_NOTE_3"].ToString();
        //        drNew["PF1"] = row["PF1"].ToString();
        //        drNew["PF2"] = row["PF2"].ToString();
        //        drNew["PF3"] = row["PF3"].ToString();
        //        drNew["PF4"] = row["PF4"].ToString();
        //        drNew["PF5"] = row["PF5"].ToString();
        //        drNew["PF6"] = row["PF6"].ToString();
        //        drNew["PF7"] = row["PF7"].ToString();
        //        drNew["PF8"] = row["PF8"].ToString();
        //        drNew["PF9"] = row["PF9"].ToString();
        //        drNew["PF10"] = row["PF10"].ToString();

        //        // maneuver specific entries
        //        OleDbCommand command = new OleDbCommand("SELECT * FROM Maneuver WHERE ID=" + row["MANEUVER"].ToString(), conn);
        //        using (OleDbDataReader reader = command.ExecuteReader()) {
        //            while (reader.Read()) {
        //                drNew["MANEUVER_NAME"] = reader.GetValue(reader.GetOrdinal("MANEUVER_NAME")).ToString();
        //                drNew["ATA_CODE"] = reader.GetValue(reader.GetOrdinal("ATA_CODE")).ToString();
        //                drNew["SOP_PHASE"] = reader.GetValue(reader.GetOrdinal("SOP_PHASE")).ToString();
        //                drNew["MANEUVER"] = reader.GetValue(reader.GetOrdinal("MANEUVER")).ToString();
        //                drNew["OBJECTIVE1"] = reader.GetValue(reader.GetOrdinal("OBJECTIVE1")).ToString();
        //                drNew["OBJECTIVE2"] = reader.GetValue(reader.GetOrdinal("OBJECTIVE2")).ToString();
        //                drNew["SCOPE1"] = reader.GetValue(reader.GetOrdinal("SCOPE1")).ToString();
        //                drNew["SCOPE2"] = reader.GetValue(reader.GetOrdinal("SCOPE2")).ToString();
        //                drNew["SIM_POSITION"] = reader.GetValue(reader.GetOrdinal("SIM_POSITION")).ToString();
        //                drNew["SIM_SETUP1"] = reader.GetValue(reader.GetOrdinal("SIM_SETUP1")).ToString();
        //                drNew["SIM_SETUP2"] = reader.GetValue(reader.GetOrdinal("SIM_SETUP2")).ToString();
        //                drNew["SIM_SETUP3"] = reader.GetValue(reader.GetOrdinal("SIM_SETUP3")).ToString();
        //                drNew["SIM_SETUP4"] = reader.GetValue(reader.GetOrdinal("SIM_SETUP4")).ToString();
        //                drNew["NOTES_1"] = reader.GetValue(reader.GetOrdinal("NOTES_1")).ToString();
        //                drNew["NOTES_2"] = reader.GetValue(reader.GetOrdinal("NOTES_2")).ToString();
        //                drNew["NOTES_3"] = reader.GetValue(reader.GetOrdinal("NOTES_3")).ToString();
        //                drNew["NOTES_4"] = reader.GetValue(reader.GetOrdinal("NOTES_4")).ToString();
        //            }
        //        }

        //    }

        //    return drNew;
        //}

        //// MANEUVER TABLE ENTRIES
        ////MANEUVER_NAME
        ////DATE_CREATED
        ////DATE_EDITED
        ////ATA_CODE
        ////SOP_PHASE
        ////MANEUVER
        ////MINUTES
        ////OBJECTIVE1
        ////OBJECTIVE2
        ////SCOPE1
        ////SCOPE2
        ////SIM_POSITION
        ////SIM_SETUP1
        ////SIM_SETUP2
        ////SIM_SETUP3
        ////SIM_SETUP4
        ////NOTES_1
        ////NOTES_2
        ////NOTES_3
        ////NOTES_4

        //private DataTable CreateColumns(DataTable dtReport) {

        //    dtReport.Clear();
        //    dtReport.Columns.Add("ID");
        //    dtReport.Columns.Add("SPOT_NAME");
        //    dtReport.Columns.Add("SEAT_SPECIFIC");
        //    dtReport.Columns.Add("MINUTES");
        //    dtReport.Columns.Add("MANEUVER_NAME");
        //    dtReport.Columns.Add("DATE_CREATED");
        //    dtReport.Columns.Add("DATE_EDITED");
        //    dtReport.Columns.Add("SPOT");
        //    dtReport.Columns.Add("ATA_CODE");
        //    dtReport.Columns.Add("SOP_PHASE");
        //    dtReport.Columns.Add("MANEUVER");
        //    dtReport.Columns.Add("OBJECTIVE1");
        //    dtReport.Columns.Add("OBJECTIVE2");
        //    dtReport.Columns.Add("SCOPE1");
        //    dtReport.Columns.Add("SCOPE2");
        //    dtReport.Columns.Add("SIM_POSITION");
        //    dtReport.Columns.Add("SIM_SETUP1");
        //    dtReport.Columns.Add("SIM_SETUP2");
        //    dtReport.Columns.Add("SIM_SETUP3");
        //    dtReport.Columns.Add("SIM_SETUP4");
        //    dtReport.Columns.Add("GTOW");
        //    dtReport.Columns.Add("TOWCG");
        //    dtReport.Columns.Add("FLAPS");
        //    dtReport.Columns.Add("CI");
        //    dtReport.Columns.Add("ZFW");
        //    dtReport.Columns.Add("ZFWCG");
        //    dtReport.Columns.Add("V1");
        //    dtReport.Columns.Add("V2");
        //    dtReport.Columns.Add("VR");
        //    dtReport.Columns.Add("THRUST");
        //    dtReport.Columns.Add("FUEL");
        //    dtReport.Columns.Add("RESERVE");
        //    dtReport.Columns.Add("STAB");
        //    dtReport.Columns.Add("PAX");
        //    dtReport.Columns.Add("CRZALT");
        //    dtReport.Columns.Add("THRUST_RED_ALT");
        //    dtReport.Columns.Add("ACCEL_ALT");
        //    dtReport.Columns.Add("EO_ACCEL_ALT");
        //    dtReport.Columns.Add("RUNWAY_COND");
        //    dtReport.Columns.Add("WIND");
        //    dtReport.Columns.Add("CEILING");
        //    dtReport.Columns.Add("VISIBILITY");
        //    dtReport.Columns.Add("TEMP");
        //    dtReport.Columns.Add("QNH");
        //    dtReport.Columns.Add("ATIS");
        //    dtReport.Columns.Add("CLEARANCE");
        //    dtReport.Columns.Add("SETUP_2");
        //    dtReport.Columns.Add("SETUP_3");
        //    dtReport.Columns.Add("SETUP_4");
        //    dtReport.Columns.Add("NOTES_1");
        //    dtReport.Columns.Add("NOTES_2");
        //    dtReport.Columns.Add("NOTES_3");
        //    dtReport.Columns.Add("NOTES_4");
        //    dtReport.Columns.Add("NOTES_5");
        //    dtReport.Columns.Add("SPOT_NOTE_1");
        //    dtReport.Columns.Add("SPOT_NOTE_2");
        //    dtReport.Columns.Add("SPOT_NOTE_3");
        //    dtReport.Columns.Add("PF1");
        //    dtReport.Columns.Add("ACTIONTITLE1");
        //    dtReport.Columns.Add("ACTIONS1");
        //    dtReport.Columns.Add("COMM1");
        //    dtReport.Columns.Add("PF2");
        //    dtReport.Columns.Add("ACTIONTITLE2");
        //    dtReport.Columns.Add("ACTIONS2");
        //    dtReport.Columns.Add("COMM2");
        //    dtReport.Columns.Add("PF3");
        //    dtReport.Columns.Add("ACTIONTITLE3");
        //    dtReport.Columns.Add("ACTIONS3");
        //    dtReport.Columns.Add("COMM3");
        //    dtReport.Columns.Add("PF4");
        //    dtReport.Columns.Add("ACTIONTITLE14");
        //    dtReport.Columns.Add("ACTIONS4");
        //    dtReport.Columns.Add("COMM4");
        //    dtReport.Columns.Add("PF5");
        //    dtReport.Columns.Add("ACTIONTITLE5");
        //    dtReport.Columns.Add("ACTIONS5");
        //    dtReport.Columns.Add("COMM5");
        //    dtReport.Columns.Add("PF6");
        //    dtReport.Columns.Add("ACTIONTITLE6");
        //    dtReport.Columns.Add("ACTIONS6");
        //    dtReport.Columns.Add("COMM6");
        //    dtReport.Columns.Add("PF7");
        //    dtReport.Columns.Add("ACTIONTITLE7");
        //    dtReport.Columns.Add("ACTIONS7");
        //    dtReport.Columns.Add("COMM7");
        //    dtReport.Columns.Add("PF8");
        //    dtReport.Columns.Add("ACTIONTITLE8");
        //    dtReport.Columns.Add("ACTIONS8");
        //    dtReport.Columns.Add("COMM8");
        //    dtReport.Columns.Add("PF9");
        //    dtReport.Columns.Add("ACTIONTITLE9");
        //    dtReport.Columns.Add("ACTIONS9");
        //    dtReport.Columns.Add("COMM9");
        //    dtReport.Columns.Add("PF10");
        //    dtReport.Columns.Add("ACTIONTITLE10");
        //    dtReport.Columns.Add("ACTIONS10");
        //    dtReport.Columns.Add("COMM10");
        //    dtReport.Columns.Add("FOOTER_TEXT");

        //    return dtReport;
        //}
    }
}
