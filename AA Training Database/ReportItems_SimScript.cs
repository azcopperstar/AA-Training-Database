using System;
using System.Data.OleDb;
using System.Collections.Generic;
using WindowsFormsApplication1;

public class Report_SimScript{
    private List<ReportItems> m_SimReportItems;

    public Report_SimScript(){

        m_SimReportItems = new List<ReportItems>();

        //string sDataFile = "V:\\AA- A320\\AATraining.OleDb";
        //string sDataFile = "V:\\AA- A350\\Simulator Training Curriculum.accdb";
        //string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sDataFile;
        //OleDbConnection conn = new OleDbConnection(connString);
        using (OleDbConnection con = new OleDbConnection(GlobalCode.sOleDbConnectionString)) {
            con.Open();                             // Open the connection to the database
            using (OleDbCommand com = new OleDbCommand()) {
                com.Connection = con;
                com.CommandText = "SELECT * FROM Maneuvers";      // Select all rows from our database table
                Int64 iSpot = 0;
                using (OleDbDataReader reader = com.ExecuteReader()) {
                    while (reader.Read()) {
                        iSpot++;
                        string sAtaCode="";
                        string sManeuver="";
                        int iMinutes =0;
                        string sObjective1="";
                        string sScope1="";
                        string sSimPosition="";

                        if (reader["ata_code"] != DBNull.Value) sAtaCode = (string)reader["ata_code"];
                        if (reader["maneuver"] != DBNull.Value) sManeuver = (string)reader["maneuver"];
                        if (reader["minutes"] != DBNull.Value) iMinutes = (int)reader["minutes"];
                        if (reader["objective1"] != DBNull.Value) sObjective1 = (string)reader["objective1"];
                        if (reader["scope1"] != DBNull.Value) sScope1 = (string)reader["scope1"];
                        if (reader["sim_position"] != DBNull.Value) sSimPosition= (string)reader["sim_position"];


                        m_SimReportItems.Add(new ReportItems(iSpot,
                                                            sAtaCode,
                                                            sManeuver,
                                                            iMinutes,
                                                            sObjective1, 
                                                            sScope1,
                                                            sSimPosition
                                                            ));
                        Console.WriteLine(reader["ata_code"] + " : " + reader["maneuver"]);     // Display the value of the key and value column for every row
                    }
                }
                con.Close();        // Close the connection to the database
            }
        }

    }

    public List<ReportItems> GetSimReportItems(){
        return m_SimReportItems;
    }
}

// Define the Business Object "SimReportItem" with two public properties
//    of simple datatypes.

public class ReportItems {

    private Int64 m_spot;
    private string m_ata_code;
    private string m_maneuver;
    private Int64 m_minutes;
    private string m_objective1;
    private string m_scope1;
    private string m_simposition;

    public ReportItems(Int64 spot, string ata_code, string maneuver, Int64 minutes, string objective1, string scope1, string simposition) {
        m_spot = spot;
        m_ata_code = ata_code;
        m_maneuver = maneuver;
        m_minutes = minutes;
        m_objective1 = objective1;
        m_scope1 = scope1;
        m_simposition = simposition;


    }

    public Int64 Spot {
        get {
            return m_spot;
        }
    }
    public string Ata_code {
        get {
            return m_ata_code;
        }
    }
    public string Maneuver {
        get {
            return m_maneuver;
        }
    }
    public Int64 Minutes {
        get {
            return m_minutes;
        }
    }
    public string Objective1 {
        get {
            return m_objective1;
        }
    }
    public string Scope1 {
        get {
            return m_scope1;
        }
    }
    public string Simposition {
        get {
            return m_simposition;
        }
    }
}
