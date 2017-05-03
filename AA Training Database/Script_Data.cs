using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using WindowsFormsApplication1;

// Define the Business Object "Script"
public class Script {

    #region m_Data_Types
    private int m_id;

    // added atis fields
    private string m_runway;
    //private string m_atis3;
    // added spot/event set fields

    // added performance fields
    private string m_fuel_taxi;
    private string m_fuel_altn;
    // added clearance fields
    private string m_fltnum;
    private string m_dep;
    private string m_dest;
    private string m_altn;

    // added preamble fields
    private bool m_preamble_Before_1;
    private bool m_preamble_After_1;
    private string m_preamble_title_1;
    private string m_preamble_text_1;
    private string m_preamble_title_2;
    private string m_preamble_text_2;
    private string m_preamble_title_3;
    private string m_preamble_text_3;

    private bool m_preamble_Before_21;
    private bool m_preamble_After_21;
    private string m_preamble_title_21;
    private string m_preamble_text_21;
    private string m_preamble_title_22;
    private string m_preamble_text_22;
    private string m_preamble_title_23;
    private string m_preamble_text_23;

    private bool m_preamble_Before_31;
    private bool m_preamble_After_31;
    private string m_preamble_title_31;
    private string m_preamble_text_31;
    private string m_preamble_title_32;
    private string m_preamble_text_32;
    private string m_preamble_title_33;
    private string m_preamble_text_33;

    private bool m_preamble_Before_41;
    private bool m_preamble_After_41;
    private string m_preamble_title_41;
    private string m_preamble_text_41;
    private string m_preamble_title_42;
    private string m_preamble_text_42;
    private string m_preamble_title_43;
    private string m_preamble_text_43;
    
    //added fields
    private string m_setup_visable;
    private string m_text_header;
    private string m_text_title;
    private string m_text_footer;
    private string m_time_start;
    private string m_time_spot;
    private string m_time_end;
    //added fields
    private string m_maneuver_name;
    private string m_date_created;
    private string m_date_edited;
    private string m_spot;
    private string m_ata_code;
    private string m_sop_phase;
    private string m_maneuver;
    private int m_minutes;
    private string m_objective1;
    private string m_objective2;
    private string m_scope1;
    private string m_scope2;
    private string m_sim_position;
    private string m_sim_setup1;
    private string m_sim_setup2;
    private string m_sim_setup3;
    private string m_sim_setup4;
    private string m_gtow;
    private string m_towcg;
    private string m_flaps;
    private string m_ci;
    private string m_zfw;
    private string m_zfwcg;
    private string m_v1;
    private string m_v2;
    private string m_vr;
    private string m_thrust;
    private string m_fuel;
    private string m_reserve;
    private string m_stab;
    private string m_pax;
    private string m_crzalt;
    private string m_thrust_red_alt;
    private string m_accel_alt;
    private string m_eo_accel_alt;
    private string m_runway_cond;
    private string m_wind;
    private string m_ceiling;
    private string m_visibility;
    private string m_temp;
    private string m_qnh;
    private string m_atis;
    private string m_clearance;
    private string m_setup_2;
    private string m_setup_3;
    private string m_setup_4;
    private string m_notes_1;
    private string m_notes_2;
    private string m_notes_3;
    private string m_notes_4;
    private string m_notes_5;
    private string m_pf_1;
    private string m_actiontitle_1;
    private string m_actions_1;
    private string m_comm_1;
    private string m_pf_2;
    private string m_actiontitle_2;
    private string m_actions_2;
    private string m_comm_2;
    private string m_pf_3;
    private string m_actiontitle_3;
    private string m_actions_3;
    private string m_comm_3;
    private string m_pf_4;
    private string m_actiontitle_4;
    private string m_actions_4;
    private string m_comm_4;
    private string m_pf_5;
    private string m_actiontitle_5;
    private string m_actions_5;
    private string m_comm_5;
    private string m_pf_6;
    private string m_actiontitle_6;
    private string m_actions_6;
    private string m_comm_6;
    private string m_pf_7;
    private string m_actiontitle_7;
    private string m_actions_7;
    private string m_comm_7;
    private string m_pf_8;
    private string m_actiontitle_8;
    private string m_actions_8;
    private string m_comm_8;
    private string m_pf_9;
    private string m_actiontitle_9;
    private string m_actions_9;
    private string m_comm_9;
    private string m_pf_10;
    private string m_actiontitle_10;
    private string m_actions_10;
    private string m_comm_10;

    #endregion

    /*
    //added fields
    //private bool m_setup_visable;
    //private string m_text_header;
    //private string m_text_title;
    //private string m_text_footer;
    //private string m_time_start;
    //private string m_time_spot;
    //private string m_time_end;
    //added fields
        // added preamble fields
    private string m_preamble_title_1;
    private string m_preamble_text_1;
    private string m_preamble_title_2;
    private string m_preamble_text_2;
    private string m_preamble_title_3;
    private string m_preamble_text_3;

    */
    public Script(int id, string runway, string fuel_taxi, string fuel_altn, string fltnum, string dep, string dest, string altn,
        bool preamble_Before_1, bool preamble_After_1,
        string preamble_title_1, string preamble_text_1, string preamble_title_2, string preamble_text_2, string preamble_title_3, string preamble_text_3,
        bool preamble_Before_21, bool preamble_After_21,
        string preamble_title_21, string preamble_text_21, string preamble_title_22, string preamble_text_22, string preamble_title_23, string preamble_text_23,
        bool preamble_Before_31, bool preamble_After_31,
        string preamble_title_31, string preamble_text_31, string preamble_title_32, string preamble_text_32, string preamble_title_33, string preamble_text_33,
        bool preamble_Before_41, bool preamble_After_41,
        string preamble_title_41, string preamble_text_41, string preamble_title_42, string preamble_text_42, string preamble_title_43, string preamble_text_43,
        string setup_visable, string text_header, string text_title, string text_footer, string time_start, string time_spot, string time_end, string maneuver_name,
        string date_created,string date_edited,string spot,string ata_code,string sop_phase,string maneuver,int minutes,string objective1,string objective2,
        string scope1,string scope2,string sim_position,string sim_setup1,string sim_setup2,string sim_setup3,string sim_setup4,
        string gtow,string towcg,string flaps,string ci,string zfw,string zfwcg,string v1,string v2,string vr,string thrust,string fuel,string reserve,string stab,string pax,
        string crzalt,string thrust_red_alt,string accel_alt,string eo_accel_alt,string runway_cond,string wind,string ceiling,string visibility,string temp,string qnh,
        string atis,string clearance,string setup_2,string setup_3,string setup_4,string notes_1,string notes_2,string notes_3,string notes_4,string notes_5,string pf_1,
        string actiontitle_1,string actions_1,string comm_1,string pf_2,string actiontitle_2,string actions_2,string comm_2,string pf_3,string actiontitle_3,string actions_3,
        string comm_3,string pf_4,string actiontitle_4,string actions_4,string comm_4,string pf_5,string actiontitle_5,string actions_5,string comm_5,string pf_6,string actiontitle_6,
        string actions_6,string comm_6,string pf_7,string actiontitle_7,string actions_7,string comm_7,string pf_8,string actiontitle_8,string actions_8,string comm_8,string pf_9,
        string actiontitle_9,string actions_9,string comm_9,string pf_10,string actiontitle_10,string actions_10,string comm_10) {

        m_id = id;
        m_runway = runway;
        m_fuel_taxi = fuel_taxi;
        m_fuel_altn = fuel_altn;
        m_fltnum = fltnum;
        m_dep = dep;
        m_dest = dest;
        m_altn = altn;

        m_preamble_Before_1 = preamble_Before_1;
        m_preamble_After_1 = preamble_After_1;
        m_preamble_title_1 = preamble_title_1;
        m_preamble_text_1= preamble_text_1;
        m_preamble_title_2= preamble_title_2;
        m_preamble_text_2= preamble_text_2;
        m_preamble_title_3= preamble_title_3;
        m_preamble_text_3= preamble_text_3;

        m_preamble_Before_21 = preamble_Before_21;
        m_preamble_After_21 = preamble_After_21;
        m_preamble_title_21 = preamble_title_21;
        m_preamble_text_21 = preamble_text_21;
        m_preamble_title_22 = preamble_title_22;
        m_preamble_text_22 = preamble_text_22;
        m_preamble_title_23 = preamble_title_23;
        m_preamble_text_23 = preamble_text_23;

        m_preamble_Before_31 = preamble_Before_31;
        m_preamble_After_31 = preamble_After_31;
        m_preamble_title_31 = preamble_title_31;
        m_preamble_text_31 = preamble_text_31;
        m_preamble_title_32 = preamble_title_32;
        m_preamble_text_32 = preamble_text_32;
        m_preamble_title_33 = preamble_title_33;
        m_preamble_text_33 = preamble_text_33;

        m_preamble_Before_41 = preamble_Before_41;
        m_preamble_After_41 = preamble_After_41;
        m_preamble_title_41 = preamble_title_41;
        m_preamble_text_41 = preamble_text_41;
        m_preamble_title_42 = preamble_title_42;
        m_preamble_text_42 = preamble_text_42;
        m_preamble_title_43 = preamble_title_43;
        m_preamble_text_43 = preamble_text_43;

        m_setup_visable = setup_visable;
        m_text_header = text_header;
        m_text_title = text_title;
        m_text_footer = text_footer;
        m_time_start = time_start;
        m_time_spot = time_spot;
        m_time_end = time_end;
        m_maneuver_name = maneuver_name;
        m_date_created= date_created;
        m_date_edited= date_edited;
        m_spot= spot;
        m_ata_code= ata_code;
        m_sop_phase= sop_phase;
        m_maneuver= maneuver;
        m_minutes= minutes;
        m_objective1= objective1;
        m_objective2= objective2;
        m_scope1= scope1;
        m_scope2= scope2;
        m_sim_position= sim_position;
        m_sim_setup1= sim_setup1;
        m_sim_setup2 = sim_setup2;
        m_sim_setup3 = sim_setup3;
        m_sim_setup4 = sim_setup4;
        m_gtow= gtow;
        m_towcg= towcg;
        m_flaps= flaps;
        m_ci= ci;
        m_zfw=zfw;
        m_zfwcg= zfwcg;
        m_v1=v1;
        m_v2=v2;
        m_vr=vr;
        m_thrust= thrust;
        m_fuel= fuel;
        m_reserve= reserve;
        m_stab= stab;
        m_pax= pax;
        m_crzalt= crzalt;
        m_thrust_red_alt= thrust_red_alt;
        m_accel_alt= accel_alt;
        m_eo_accel_alt= eo_accel_alt;
        m_runway_cond= runway_cond;
        m_wind= wind;
        m_ceiling= ceiling;
        m_visibility= visibility;
        m_temp= temp;
        m_qnh= qnh;
        m_atis= atis;
        m_clearance= clearance;
        m_setup_2= setup_2;
        m_setup_3= setup_3;
        m_setup_4= setup_4;
        m_notes_1= notes_1;
        m_notes_2 = notes_2;
        m_notes_3 = notes_3;
        m_notes_4 = notes_4;
        m_notes_5 = notes_5;
        m_pf_1= pf_1;
        m_actiontitle_1= actiontitle_1;
        m_actions_1= actions_1;
        m_comm_1= comm_1;
        m_pf_2 = pf_2;
        m_actiontitle_2 = actiontitle_2;
        m_actions_2 = actions_2;
        m_comm_2 = comm_2;
        m_pf_3 = pf_3;
        m_actiontitle_3 = actiontitle_3;
        m_actions_3 = actions_3;
        m_comm_3 = comm_3;
        m_pf_4 = pf_4;
        m_actiontitle_4 = actiontitle_4;
        m_actions_4 = actions_4;
        m_comm_4 = comm_4;
        m_pf_5 = pf_5;
        m_actiontitle_5 = actiontitle_5;
        m_actions_5 = actions_5;
        m_comm_5 = comm_5;
        m_pf_6 = pf_6;
        m_actiontitle_6 = actiontitle_6;
        m_actions_6 = actions_6;
        m_comm_6 = comm_6;
        m_pf_7 = pf_7;
        m_actiontitle_7 = actiontitle_7;
        m_actions_7 = actions_7;
        m_comm_7 = comm_7;
        m_pf_8 = pf_8;
        m_actiontitle_8 = actiontitle_8;
        m_actions_8 = actions_8;
        m_comm_8 = comm_8;
        m_pf_9 = pf_9;
        m_actiontitle_9 = actiontitle_9;
        m_actions_9 = actions_9;
        m_comm_9 = comm_9;
        m_pf_10 = pf_10;
        m_actiontitle_10 = actiontitle_10;
        m_actions_10 = actions_10;
        m_comm_10 = comm_10;

    }

    public int ID {get {return m_id;}}
    //added fields
    public string RUNWAY {
        get {
            return m_runway;
        }
    }
    public string FUEL_TAXI {
        get {
            return m_fuel_taxi;
        }
    }
    public string FUEL_ALTN {
        get {
            return m_fuel_altn;
        }
    }
    public string FLTNUM{
        get {
            return m_fltnum;
        }
    }
    public string DEP{
        get {
            return m_dep;
        }
    }
    public string DEST{
        get {
            return m_dest;
        }
    }
    public string ALTN{
        get {
            return m_altn;
        }
    }

    //private bool m_preamble_Before_1;
    //private bool m_preamble_After_1;

    public bool PREAMBLE_BEFORE_1 {
        get {
            return m_preamble_Before_1;
        }
    }
    public bool PREAMBLE_AFTER_1 {
        get {
            return m_preamble_After_1;
        }
    }
    public string PREAMBLE_TITLE_1 {
        get {
            return m_preamble_title_1;
        }
    }
    public string PREAMBLE_TEXT_1 {
        get {
            return m_preamble_text_1;
        }
    }
    public string PREAMBLE_TITLE_2 {
        get {
            return m_preamble_title_2;
        }
    }
    public string PREAMBLE_TEXT_2 {
        get {
            return m_preamble_text_2;
        }
    }
    public string PREAMBLE_TITLE_3 {
        get {
            return m_preamble_title_3;
        }
    }
    public string PREAMBLE_TEXT_3 {
        get {
            return m_preamble_text_3;
        }
    }

    public bool PREAMBLE_BEFORE_21 {
        get {
            return m_preamble_Before_21;
        }
    }
    public bool PREAMBLE_AFTER_21 {
        get {
            return m_preamble_After_21;
        }
    }
    public string PREAMBLE_TITLE_21 {
        get {
            return m_preamble_title_21;
        }
    }
    public string PREAMBLE_TEXT_21 {
        get {
            return m_preamble_text_21;
        }
    }
    public string PREAMBLE_TITLE_22 {
        get {
            return m_preamble_title_22;
        }
    }
    public string PREAMBLE_TEXT_22 {
        get {
            return m_preamble_text_22;
        }
    }
    public string PREAMBLE_TITLE_23 {
        get {
            return m_preamble_title_23;
        }
    }
    public string PREAMBLE_TEXT_23 {
        get {
            return m_preamble_text_23;
        }
    }

    public bool PREAMBLE_BEFORE_31 {
        get {
            return m_preamble_Before_31;
        }
    }
    public bool PREAMBLE_AFTER_31 {
        get {
            return m_preamble_After_31;
        }
    }
    public string PREAMBLE_TITLE_31 {
        get {
            return m_preamble_title_31;
        }
    }
    public string PREAMBLE_TEXT_31 {
        get {
            return m_preamble_text_31;
        }
    }
    public string PREAMBLE_TITLE_32 {
        get {
            return m_preamble_title_32;
        }
    }
    public string PREAMBLE_TEXT_32 {
        get {
            return m_preamble_text_32;
        }
    }
    public string PREAMBLE_TITLE_33 {
        get {
            return m_preamble_title_33;
        }
    }
    public string PREAMBLE_TEXT_33 {
        get {
            return m_preamble_text_33;
        }
    }

    public bool PREAMBLE_BEFORE_41 {
        get {
            return m_preamble_Before_41;
        }
    }
    public bool PREAMBLE_AFTER_41 {
        get {
            return m_preamble_After_41;
        }
    }
    public string PREAMBLE_TITLE_41 {
        get {
            return m_preamble_title_41;
        }
    }
    public string PREAMBLE_TEXT_41 {
        get {
            return m_preamble_text_41;
        }
    }
    public string PREAMBLE_TITLE_42 {
        get {
            return m_preamble_title_42;
        }
    }
    public string PREAMBLE_TEXT_42 {
        get {
            return m_preamble_text_42;
        }
    }
    public string PREAMBLE_TITLE_43 {
        get {
            return m_preamble_title_43;
        }
    }
    public string PREAMBLE_TEXT_43 {
        get {
            return m_preamble_text_43;
        }
    }




    public string SETUP_VISABLE {
        get {
            return m_setup_visable;
        }
    }
    public string TEXT_HEADER {
        get {
            return m_text_header;
        }
    }
    public string TEXT_TITLE {
        get {
            return m_text_title;
        }
    }
    public string TEXT_FOOTER {
        get {
            return m_text_footer;
        }
    }
    public string TIME_START {
        get {
            return m_time_start;
        }
    }
    public string TIME_SPOT {
        get {
            return m_time_spot;
        }
    }
    public string TIME_END {
        get {
            return m_time_end;
        }
    }
    //added fields
    public string MANEUVER_NAME {
        get {
            return m_maneuver_name;
        }
    }
    public string DATE_CREATED {
        get {
            return m_date_created;
        }
    }
    public string DATE_EDITED {
        get {
            return m_date_edited;
        }
    }
    public string SPOT {
        get {
            return m_spot;
        }
    }
    public string ATA_CODE {
        get {
            return m_ata_code;
        }
    }
    public string SOP_PHASE {
        get {
            return m_sop_phase;
        }
    }
    public string MANEUVER {
        get {
            return m_maneuver;
        }
    }
    public int MINUTES {
        get {
            return m_minutes;
        }
    }
    public string OBJECTIVE1 {
        get {
            return m_objective1;
        }
    }
    public string OBJECTIVE2 {
        get {
            return m_objective2;
        }
    }
    public string SCOPE1 {
        get {
            return m_scope1;
        }
    }
    public string SCOPE2 {
        get {
            return m_scope2;
        }
    }
    public string SIM_POSITION {
        get {
            return m_sim_position;
        }
    }
    public string SIM_SETUP1 {
        get {
            return m_sim_setup1;
        }
    }
    public string SIM_SETUP2 {
        get {
            return m_sim_setup2;
        }
    }
    public string SIM_SETUP3 {
        get {
            return m_sim_setup3;
        }
    }
    public string SIM_SETUP4 {
        get {
            return m_sim_setup4;
        }
    }
    public string GTOW {
        get {
            return m_gtow;
        }
    }
    public string TOWCG {
        get {
            return m_towcg;
        }
    }
    public string FLAPS {
        get {
            return m_flaps;
        }
    }
    public string CI {
        get {
            return m_ci;
        }
    }
    public string ZFW {
        get {
            return m_zfw;
        }
    }
    public string ZFWCG {
        get {
            return m_zfwcg;
        }
    }
    public string V1 {
        get {
            return m_v1;
        }
    }
    public string V2 {
        get {
            return m_v2;
        }
    }
    public string VR {
        get {
            return m_vr;
        }
    }
    public string THRUST {
        get {
            return m_thrust;
        }
    }
    public string FUEL {
        get {
            return m_fuel;
        }
    }
    public string RESERVE {
        get {
            return m_reserve;
        }
    }
    public string STAB {
        get {
            return m_stab;
        }
    }
    public string PAX {
        get {
            return m_pax;
        }
    }
    public string CRZALT{
        get {
            return m_crzalt;
        }
    }
    public string THRUST_RED_ALT{
        get {
            return m_thrust_red_alt;
        }
    }
    public string ACCEL_ALT{
        get {
            return m_accel_alt;
        }
    }
    public string EO_ACCEL_ALT{
        get {
            return m_eo_accel_alt;
        }
    }
    public string RUNWAY_COND{
        get {
            return m_runway_cond;
        }
    }
    public string WIND{
        get {
            return m_wind;
        }
    }
    public string CEILING{
        get {
            return m_ceiling;
        }
    }
    public string VISIBILITY{
        get {
            return m_visibility;
        }
    }
    public string TEMP{
        get {
            return m_temp;
        }
    }
    public string QNH{
        get {
            return m_qnh;
        }
    }
    public string ATIS{
        get {
            return m_atis;
        }
    }
    public string CLEARANCE{
        get {
            return m_clearance;
        }
    }
    public string SETUP_2{
        get {
            return m_setup_2;
        }
    }
    public string SETUP_3 {
        get {
            return m_setup_3;
        }
    }
    public string SETUP_4 {
        get {
            return m_setup_4;
        }
    }
    public string NOTES_1 {
        get {
            return m_notes_1;
        }
    }
    public string NOTES_2 {
        get {
            return m_notes_2;
        }
    }
    public string NOTES_3 {
        get {
            return m_notes_3;
        }
    }
    public string NOTES_4 {
        get {
            return m_notes_4;
        }
    }
    public string NOTES_5 {
        get {
            return m_notes_5;
        }
    }

    public string PF1 {
        get {
            return m_pf_1;
        }
    }
    public string ACTIONTITLE1 {
        get {
            return m_actiontitle_1;
        }
    }
    public string ACTIONS1 {
        get {
            return m_actions_1;
        }
    }
    public string COMM1 {
        get {
            return m_comm_1;
        }
    }
    public string PF2 {
        get {
            return m_pf_2;
        }
    }
    public string ACTIONTITLE2 {
        get {
            return m_actiontitle_2;
        }
    }
    public string ACTIONS2 {
        get {
            return m_actions_2;
        }
    }
    public string COMM2 {
        get {
            return m_comm_2;
        }
    }
    public string PF3 {
        get {
            return m_pf_3;
        }
    }
    public string ACTIONTITLE3 {
        get {
            return m_actiontitle_3;
        }
    }
    public string ACTIONS3 {
        get {
            return m_actions_3;
        }
    }
    public string COMM3 {
        get {
            return m_comm_3;
        }
    }
    public string PF4 {
        get {
            return m_pf_4;
        }
    }
    public string ACTIONTITLE4 {
        get {
            return m_actiontitle_4;
        }
    }
    public string ACTIONS4 {
        get {
            return m_actions_4;
        }
    }
    public string COMM4 {
        get {
            return m_comm_4;
        }
    }
    public string PF5 {
        get {
            return m_pf_5;
        }
    }
    public string ACTIONTITLE5 {
        get {
            return m_actiontitle_5;
        }
    }
    public string ACTIONS5 {
        get {
            return m_actions_5;
        }
    }
    public string COMM5 {
        get {
            return m_comm_5;
        }
    }
    public string PF6 {
        get {
            return m_pf_6;
        }
    }
    public string ACTIONTITLE6 {
        get {
            return m_actiontitle_6;
        }
    }
    public string ACTIONS6 {
        get {
            return m_actions_6;
        }
    }
    public string COMM6 {
        get {
            return m_comm_6;
        }
    }
    public string PF7 {
        get {
            return m_pf_7;
        }
    }
    public string ACTIONTITLE7 {
        get {
            return m_actiontitle_7;
        }
    }
    public string ACTIONS7 {
        get {
            return m_actions_7;
        }
    }
    public string COMM7 {
        get {
            return m_comm_7;
        }
    }
    public string PF8 {
        get {
            return m_pf_8;
        }
    }
    public string ACTIONTITLE8 {
        get {
            return m_actiontitle_8;
        }
    }
    public string ACTIONS8 {
        get {
            return m_actions_8;
        }
    }
    public string COMM8 {
        get {
            return m_comm_8;
        }
    }
    public string PF9 {
        get {
            return m_pf_9;
        }
    }
    public string ACTIONTITLE9 {
        get {
            return m_actiontitle_9;
        }
    }
    public string ACTIONS9 {
        get {
            return m_actions_9;
        }
    }
    public string COMM9 {
        get {
            return m_comm_9;
        }
    }
    public string PF10 {
        get {
            return m_pf_10;
        }
    }
    public string ACTIONTITLE10 {
        get {
            return m_actiontitle_10;
        }
    }
    public string ACTIONS10 {
        get {
            return m_actions_10;
        }
    }
    public string COMM10 {
        get {
            return m_comm_10;
        }
    }
}

// Define Business Object "ScriptData" that provides a 
//    GetScriptData method that returns a collection of 
//    ScriptData objects.

public class ScriptData {
    private List<Script> m_Script;
    private OleDbConnection conn;

    #region m_Data_Types
    private int m_id;
    // added performance fields
    private string m_runway;
    private string m_fuel_taxi;
    private string m_fuel_altn;
    // added clearance fields
    private string m_fltnum;
    private string m_dep;
    private string m_dest;
    private string m_altn;
    // added preamble fields
    private bool m_preamble_Before_1;
    private bool m_preamble_After_1;
    private string m_preamble_title_1;
    private string m_preamble_text_1;
    private string m_preamble_title_2;
    private string m_preamble_text_2;
    private string m_preamble_title_3;
    private string m_preamble_text_3;

    private bool m_preamble_Before_21;
    private bool m_preamble_After_21;
    private string m_preamble_title_21;
    private string m_preamble_text_21;
    private string m_preamble_title_22;
    private string m_preamble_text_22;
    private string m_preamble_title_23;
    private string m_preamble_text_23;

    private bool m_preamble_Before_31;
    private bool m_preamble_After_31;
    private string m_preamble_title_31;
    private string m_preamble_text_31;
    private string m_preamble_title_32;
    private string m_preamble_text_32;
    private string m_preamble_title_33;
    private string m_preamble_text_33;

    private bool m_preamble_Before_41;
    private bool m_preamble_After_41;
    private string m_preamble_title_41;
    private string m_preamble_text_41;
    private string m_preamble_title_42;
    private string m_preamble_text_42;
    private string m_preamble_title_43;
    private string m_preamble_text_43;


    //added fields
    private string m_setup_visable;
    private string m_text_header;
    private string m_text_title;
    private string m_text_footer;
    private string m_time_start;
    private string m_time_spot;
    private string m_time_end;
    //added fields
    private string m_maneuver_name;
    private string m_date_created;
    private string m_date_edited;
    private string m_spot;
    private string m_ata_code;
    private string m_sop_phase;
    private string m_maneuver;
    private int m_minutes;
    private string m_objective1;
    private string m_objective2;
    private string m_scope1;
    private string m_scope2;
    private string m_sim_position;
    private string m_sim_setup1;
    private string m_sim_setup2;
    private string m_sim_setup3;
    private string m_sim_setup4;
    private string m_gtow;
    private string m_towcg;
    private string m_flaps;
    private string m_ci;
    private string m_zfw;
    private string m_zfwcg;
    private string m_v1;
    private string m_v2;
    private string m_vr;
    private string m_thrust;
    private string m_fuel;
    private string m_reserve;
    private string m_stab;
    private string m_pax;
    private string m_crzalt;
    private string m_thrust_red_alt;
    private string m_accel_alt;
    private string m_eo_accel_alt;
    private string m_runway_cond;
    private string m_wind;
    private string m_ceiling;
    private string m_visibility;
    private string m_temp;
    private string m_qnh;
    private string m_atis;
    private string m_clearance;
    private string m_setup_2;
    private string m_setup_3;
    private string m_setup_4;
    private string m_notes_1;
    private string m_notes_2;
    private string m_notes_3;
    private string m_notes_4;
    private string m_notes_5;
    private string m_pf_1;
    private string m_actiontitle_1;
    private string m_actions_1;
    private string m_comm_1;
    private string m_pf_2;
    private string m_actiontitle_2;
    private string m_actions_2;
    private string m_comm_2;
    private string m_pf_3;
    private string m_actiontitle_3;
    private string m_actions_3;
    private string m_comm_3;
    private string m_pf_4;
    private string m_actiontitle_4;
    private string m_actions_4;
    private string m_comm_4;
    private string m_pf_5;
    private string m_actiontitle_5;
    private string m_actions_5;
    private string m_comm_5;
    private string m_pf_6;
    private string m_actiontitle_6;
    private string m_actions_6;
    private string m_comm_6;
    private string m_pf_7;
    private string m_actiontitle_7;
    private string m_actions_7;
    private string m_comm_7;
    private string m_pf_8;
    private string m_actiontitle_8;
    private string m_actions_8;
    private string m_comm_8;
    private string m_pf_9;
    private string m_actiontitle_9;
    private string m_actions_9;
    private string m_comm_9;
    private string m_pf_10;
    private string m_actiontitle_10;
    private string m_actions_10;
    private string m_comm_10;

    #endregion
    private void ClearListVariables() {
        m_maneuver_name="";
        // added clearance fields
        m_runway = "";
        m_fuel_taxi = "";
        m_fuel_altn = "";
        // added clearance fields
        m_fltnum = "";
        m_dep="";
        m_dest="";
        m_altn="";

        // added preamble fields
        m_preamble_Before_1 = false;
        m_preamble_After_1 = false;
        m_preamble_title_1 = "";
        m_preamble_text_1 = "";
        m_preamble_title_2 = "";
        m_preamble_text_2 = "";
        m_preamble_title_3 = "";
        m_preamble_text_3 = "";

        m_preamble_Before_21 = false;
        m_preamble_After_21 = false;
        m_preamble_title_21 = "";
        m_preamble_text_21 = "";
        m_preamble_title_22 = "";
        m_preamble_text_22 = "";
        m_preamble_title_23 = "";
        m_preamble_text_23 = "";

        m_preamble_Before_31 = false;
        m_preamble_After_31 = false;
        m_preamble_title_31 = "";
        m_preamble_text_31 = "";
        m_preamble_title_32 = "";
        m_preamble_text_32 = "";
        m_preamble_title_33 = "";
        m_preamble_text_33 = "";

        m_preamble_Before_41 = false;
        m_preamble_After_41 = false;
        m_preamble_title_41 = "";
        m_preamble_text_41 = "";
        m_preamble_title_42 = "";
        m_preamble_text_42 = "";
        m_preamble_title_43 = "";
        m_preamble_text_43 = "";

        //added fields
        m_setup_visable = "no";
        m_text_header = "";
        m_text_title = "";
        m_text_footer = "";
        m_time_start = "";
        m_time_spot = "";
        m_time_end = "";
        //added fields
        m_date_created = "";
        m_date_edited="";
        m_spot="";
        m_ata_code="";
        m_sop_phase="";
        m_maneuver="";
        m_minutes=0;
        m_objective1="";
        m_objective2="";
        m_scope1="";
        m_scope2="";
        m_sim_position="";
        m_sim_setup1="";
        m_sim_setup2="";
        m_sim_setup3="";
        m_sim_setup4="";
        m_gtow="";
        m_towcg="";
        m_flaps="";
        m_ci="";
        m_zfw="";
        m_zfwcg="";
        m_v1="";
        m_v2="";
        m_vr="";
        m_thrust="";
        m_fuel="";
        m_reserve="";
        m_stab="";
        m_pax="";
        m_crzalt="";
        m_thrust_red_alt="";
        m_accel_alt="";
        m_eo_accel_alt="";
        m_runway_cond="";
        m_wind="";
        m_ceiling="";
        m_visibility="";
        m_temp="";
        m_qnh="";
        m_atis="";
        m_clearance="";
        m_setup_2="";
        m_setup_3="";
        m_setup_4="";
        m_notes_1="";
        m_notes_2="";
        m_notes_3="";
        m_notes_4="";
        m_notes_5="";
        m_pf_1="";
        m_actiontitle_1="";
        m_actions_1="";
        m_comm_1="";
        m_pf_2="";
        m_actiontitle_2="";
        m_actions_2="";
        m_comm_2="";
        m_pf_3="";
        m_actiontitle_3="";
        m_actions_3="";
        m_comm_3="";
        m_pf_4="";
        m_actiontitle_4="";
        m_actions_4="";
        m_comm_4="";
        m_pf_5="";
        m_actiontitle_5="";
        m_actions_5="";
        m_comm_5="";
        m_pf_6="";
        m_actiontitle_6="";
        m_actions_6="";
        m_comm_6="";
        m_pf_7="";
        m_actiontitle_7="";
        m_actions_7="";
        m_comm_7="";
        m_pf_8="";
        m_actiontitle_8="";
        m_actions_8="";
        m_comm_8="";
        m_pf_9="";
        m_actiontitle_9="";
        m_actions_9="";
        m_comm_9="";
        m_pf_10="";
        m_actiontitle_10="";
        m_actions_10="";
        m_comm_10="";
    }
    //private DataTable Get_Selected_DataTable(int iID, string sTable) {
    //    DataTable dt = new DataTable();
    //    string sCommand = "SELECT * FROM " + sTable + " WHERE ID = " + iID;
    //    //conn.Open();
    //    OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
    //    dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
    //    dAdapter.Fill(dt);
    //    //conn.Close();
    //    return dt;
    //}
    //private string Get_Action_Atis(int iWX) {
    //    string sATIS = "";
    //    DataTable dt = new DataTable();
    //    dt = Get_Selected_DataTable(iWX, "Conditions_WX");
    //    if (dt != null) {
    //        foreach (DataRow row in dt.Rows) {
    //            sATIS = "\n\n" + ATIS_Builder.CompleteATIS(row);
    //        }
    //    }
    //    return sATIS;
    //}
    public ScriptData() {
        //added fields
        //private bool m_setup_visable;
        //private string m_text_header;
        //private string m_text_title;
        //private string m_text_footer;
        //private string m_time_start;
        //private string m_time_spot;
        //private string m_time_end;
        //added fields

        m_Script = new List<Script>();

        conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
        conn.Open();

        int iSpotCount = 0;
        int[] iLessons = GlobalCode.iLessonList;
        int[] iNumbers = GlobalCode.iSPOTList;
        int iStartTime = 0;
        int iEndTime = 0;

        // get the lesson data
        string s_text_title="";

        bool b_preamble_Before_1 = false;
        bool b_preamble_After_1 = false;
        string s_preamble_title_1 = "";
        string s_preamble_text_1 = "";
        string s_preamble_title_2 = "";
        string s_preamble_text_2 = "";
        string s_preamble_title_3 = "";
        string s_preamble_text_3 = "";

        bool b_preamble_Before_2 = false;
        bool b_preamble_After_2 = false;
        string s_preamble_title_21 = "";
        string s_preamble_text_21 = "";
        string s_preamble_title_22 = "";
        string s_preamble_text_22 = "";
        string s_preamble_title_23 = "";
        string s_preamble_text_23 = "";

        bool b_preamble_Before_3 = false;
        bool b_preamble_After_3 = false;
        string s_preamble_title_31 = "";
        string s_preamble_text_31 = "";
        string s_preamble_title_32 = "";
        string s_preamble_text_32 = "";
        string s_preamble_title_33 = "";
        string s_preamble_text_33 = "";

        bool b_preamble_Before_4 = false;
        bool b_preamble_After_4 = false;
        string s_preamble_title_41 = "";
        string s_preamble_text_41 = "";
        string s_preamble_title_42 = "";
        string s_preamble_text_42 = "";
        string s_preamble_title_43 = "";
        string s_preamble_text_43 = "";

        //foreach (int i in iLessons) {
            OleDbCommand command = new OleDbCommand("SELECT * FROM Lesson WHERE ID=" + GlobalCode.iLesson, conn);
            using (OleDbDataReader reader = command.ExecuteReader()) {
                while (reader.Read()) {
                    s_text_title = reader.GetValue(reader.GetOrdinal("LESSON_NAME")).ToString();

                    // get preamble id
                    if (reader.GetValue(reader.GetOrdinal("P1_BEFORE")).ToString() == "1")
                        b_preamble_Before_1 = true;
                    if (reader.GetValue(reader.GetOrdinal("P1_AFTER")).ToString() == "1")
                        b_preamble_After_1 = true;
                    s_preamble_title_1 = reader.GetValue(reader.GetOrdinal("PREAMBLE1")).ToString();

                    //command = new OleDbCommand("SELECT * FROM Preamble WHERE ID=" + iP1, conn);
                    //using (OleDbDataReader reader1 = command.ExecuteReader()) {
                    //    while (reader1.Read()) {
                    //        s_preamble_title_1 = reader1.GetValue(reader1.GetOrdinal("TITLE1")).ToString();
                    //        s_preamble_text_1 = reader1.GetValue(reader1.GetOrdinal("BODY1")).ToString();
                    //        s_preamble_title_2 = reader1.GetValue(reader1.GetOrdinal("TITLE2")).ToString();
                    //        s_preamble_text_2 = reader1.GetValue(reader1.GetOrdinal("BODY2")).ToString();
                    //        s_preamble_title_3 = reader1.GetValue(reader1.GetOrdinal("TITLE3")).ToString();
                    //        s_preamble_text_3 = reader1.GetValue(reader1.GetOrdinal("BODY3")).ToString();
                    //    }
                    //}

                    if (reader.GetValue(reader.GetOrdinal("P2_BEFORE")).ToString() == "1")
                        b_preamble_Before_2 = true;
                    if (reader.GetValue(reader.GetOrdinal("P2_AFTER")).ToString() == "1")
                        b_preamble_After_2 = true;
                    s_preamble_title_21 = reader.GetValue(reader.GetOrdinal("PREAMBLE2")).ToString();

                    //int iP2 = int.Parse(reader.GetValue(reader.GetOrdinal("PREAMBLE2")).ToString());
                    //command = new OleDbCommand("SELECT * FROM Preamble WHERE ID=" + iP2, conn);
                    //using (OleDbDataReader reader1 = command.ExecuteReader()) {
                    //    while (reader1.Read()) {
                    //        s_preamble_title_21 = reader1.GetValue(reader1.GetOrdinal("TITLE1")).ToString();
                    //        s_preamble_text_21 = reader1.GetValue(reader1.GetOrdinal("BODY1")).ToString();
                    //        s_preamble_title_22 = reader1.GetValue(reader1.GetOrdinal("TITLE2")).ToString();
                    //        s_preamble_text_22 = reader1.GetValue(reader1.GetOrdinal("BODY2")).ToString();
                    //        s_preamble_title_23 = reader1.GetValue(reader1.GetOrdinal("TITLE3")).ToString();
                    //        s_preamble_text_23 = reader1.GetValue(reader1.GetOrdinal("BODY3")).ToString();
                    //    }
                    //}

                    if (reader.GetValue(reader.GetOrdinal("P3_BEFORE")).ToString() == "1")
                        b_preamble_Before_3 = true;
                    if (reader.GetValue(reader.GetOrdinal("P3_AFTER")).ToString() == "1")
                        b_preamble_After_3 = true;
                    s_preamble_title_31 = reader.GetValue(reader.GetOrdinal("PREAMBLE3")).ToString();

                    //int iP3 = int.Parse(reader.GetValue(reader.GetOrdinal("PREAMBLE3")).ToString());
                    //command = new OleDbCommand("SELECT * FROM Preamble WHERE ID=" + iP3, conn);
                    //using (OleDbDataReader reader1 = command.ExecuteReader()) {
                    //    while (reader1.Read()) {
                    //        s_preamble_title_31 = reader1.GetValue(reader1.GetOrdinal("TITLE1")).ToString();
                    //        s_preamble_text_31 = reader1.GetValue(reader1.GetOrdinal("BODY1")).ToString();
                    //        s_preamble_title_32 = reader1.GetValue(reader1.GetOrdinal("TITLE2")).ToString();
                    //        s_preamble_text_32 = reader1.GetValue(reader1.GetOrdinal("BODY2")).ToString();
                    //        s_preamble_title_33 = reader1.GetValue(reader1.GetOrdinal("TITLE3")).ToString();
                    //        s_preamble_text_33 = reader1.GetValue(reader1.GetOrdinal("BODY3")).ToString();
                    //    }
                    //}

                    if (reader.GetValue(reader.GetOrdinal("P4_BEFORE")).ToString() == "1")
                        b_preamble_Before_4 = true;
                    if (reader.GetValue(reader.GetOrdinal("P4_AFTER")).ToString() == "1")
                        b_preamble_After_4 = true;
                    s_preamble_title_41 = reader.GetValue(reader.GetOrdinal("PREAMBLE4")).ToString();

                    //int iP4 = int.Parse(reader.GetValue(reader.GetOrdinal("PREAMBLE4")).ToString());
                    //command = new OleDbCommand("SELECT * FROM Preamble WHERE ID=" + iP4, conn);
                    //using (OleDbDataReader reader1 = command.ExecuteReader()) {
                    //    while (reader1.Read()) {
                    //        s_preamble_title_41 = reader1.GetValue(reader1.GetOrdinal("TITLE1")).ToString();
                    //        s_preamble_text_41 = reader1.GetValue(reader1.GetOrdinal("BODY1")).ToString();
                    //        s_preamble_title_42 = reader1.GetValue(reader1.GetOrdinal("TITLE2")).ToString();
                    //        s_preamble_text_42 = reader1.GetValue(reader1.GetOrdinal("BODY2")).ToString();
                    //        s_preamble_title_43 = reader1.GetValue(reader1.GetOrdinal("TITLE3")).ToString();
                    //        s_preamble_text_43 = reader1.GetValue(reader1.GetOrdinal("BODY3")).ToString();
                    //    }
                    //}

                }
            }
        //}

        // get the spot data
        foreach (int i in iNumbers) {
            command = new OleDbCommand("SELECT * FROM Spots WHERE ID=" + i, conn);
            using (OleDbDataReader reader = command.ExecuteReader()) {
                while (reader.Read()) {
                    ClearListVariables();
                    m_setup_visable = "no";
                    if (i > 4) {
                        // spot
                        if (reader.GetValue(reader.GetOrdinal("SPOT")).ToString() == "SPOT") {
                            iSpotCount++;
                        }

                        // save the lesson data from above to each spot
                        m_text_title = s_text_title;

                        m_preamble_Before_1 = b_preamble_Before_1;
                        m_preamble_After_1 = b_preamble_After_1;
                        m_preamble_title_1 = s_preamble_title_1;
                        m_preamble_text_1 = s_preamble_text_1;
                        m_preamble_title_2 = s_preamble_title_2;
                        m_preamble_text_2 = s_preamble_text_2;
                        m_preamble_title_3 = s_preamble_title_3;
                        m_preamble_text_3 = s_preamble_text_3;

                        m_preamble_Before_21 = b_preamble_Before_2;
                        m_preamble_After_21 = b_preamble_After_2;
                        m_preamble_title_21 = s_preamble_title_21;
                        m_preamble_text_21 = s_preamble_text_21;
                        m_preamble_title_22 = s_preamble_title_22;
                        m_preamble_text_22 = s_preamble_text_22;
                        m_preamble_title_23 = s_preamble_title_23;
                        m_preamble_text_23 = s_preamble_text_23;

                        m_preamble_Before_31 = b_preamble_Before_3;
                        m_preamble_After_31 = b_preamble_After_3;
                        m_preamble_title_31 = s_preamble_title_31;
                        m_preamble_text_31 = s_preamble_text_31;
                        m_preamble_title_32 = s_preamble_title_32;
                        m_preamble_text_32 = s_preamble_text_32;
                        m_preamble_title_33 = s_preamble_title_33;
                        m_preamble_text_33 = s_preamble_text_33;

                        m_preamble_Before_41 = b_preamble_Before_4;
                        m_preamble_After_41 = b_preamble_After_4;
                        m_preamble_title_41 = s_preamble_title_41;
                        m_preamble_text_41 = s_preamble_text_41;
                        m_preamble_title_42 = s_preamble_title_42;
                        m_preamble_text_42 = s_preamble_text_42;
                        m_preamble_title_43 = s_preamble_title_43;
                        m_preamble_text_43 = s_preamble_text_43;

                        // spot specific entries
                        if (reader.GetValue(reader.GetOrdinal("SPOT")).ToString() == "SPOT") {
                            // spot
                            m_spot = "SPOT " + Convert.ToString(iSpotCount);
                        } else {
                            // event set
                            m_spot = "EVENT " + reader.GetValue(reader.GetOrdinal("SPOT")).ToString();
                        }

                        m_minutes = int.Parse(reader.GetValue(reader.GetOrdinal("MINUTES")).ToString());
                        iEndTime = iEndTime + m_minutes;
                        m_time_start = "START: " + GlobalCode.Convert_MinutesToTime(iStartTime);
                        m_time_spot = "" + GlobalCode.Convert_MinutesToTime(m_minutes);
                        m_time_end = "END: " + GlobalCode.Convert_MinutesToTime(iEndTime);
                        m_text_footer = m_spot + " COMPLETE. SESSION TIME " + GlobalCode.Convert_MinutesToTime(iEndTime);
                        iStartTime = iStartTime + m_minutes;

                        m_notes_1 = reader.GetValue(reader.GetOrdinal("SPOT_NOTE_1")).ToString();
                        m_notes_2 = reader.GetValue(reader.GetOrdinal("SPOT_NOTE_2")).ToString();
                        if (m_notes_2 != "") {
                            if (m_notes_1 != "") {
                                m_notes_1 = m_notes_1 + "\n" + m_notes_2;
                            } else {
                                m_notes_1 = m_notes_2;
                            }
                        }
                        m_notes_3 = reader.GetValue(reader.GetOrdinal("SPOT_NOTE_3")).ToString();
                        if (m_notes_3 != "") {
                            if (m_notes_1 != "") {
                                m_notes_1 = m_notes_1 + "\n" + m_notes_3;
                            } else {
                                m_notes_1 = m_notes_3;
                            }
                        }

                        m_maneuver = reader.GetValue(reader.GetOrdinal("MANEUVER")).ToString();
                        command = new OleDbCommand("SELECT * FROM Maneuver WHERE ID=" + m_maneuver, conn);
                        using (OleDbDataReader reader1 = command.ExecuteReader()) {
                            while (reader1.Read()) {
                                m_maneuver = reader1.GetValue(reader1.GetOrdinal("MANEUVER")).ToString();
                                m_ata_code = reader1.GetValue(reader1.GetOrdinal("ATA_CODE")).ToString();
                                m_sop_phase = reader1.GetValue(reader1.GetOrdinal("SOP_PHASE")).ToString();
                                if (m_sop_phase != "" && m_ata_code != "") {
                                    m_ata_code = m_ata_code + "\n" + m_sop_phase;
                                }
                                m_objective1 = reader1.GetValue(reader1.GetOrdinal("OBJECTIVE1")).ToString();
                                m_objective2 = reader1.GetValue(reader1.GetOrdinal("OBJECTIVE2")).ToString();
                                m_scope1 = reader1.GetValue(reader1.GetOrdinal("SCOPE1")).ToString();
                                m_scope2 = reader1.GetValue(reader1.GetOrdinal("SCOPE2")).ToString();
                                m_sim_position = reader1.GetValue(reader1.GetOrdinal("SIM_POSITION")).ToString();
                                m_sim_setup1 = reader1.GetValue(reader1.GetOrdinal("SIM_SETUP1")).ToString();
                                m_sim_setup2 = reader1.GetValue(reader1.GetOrdinal("SIM_SETUP2")).ToString();
                                m_sim_setup3 = reader1.GetValue(reader1.GetOrdinal("SIM_SETUP3")).ToString();
                                m_sim_setup4 = reader1.GetValue(reader1.GetOrdinal("SIM_SETUP4")).ToString();
                                m_notes_2 = reader1.GetValue(reader1.GetOrdinal("NOTES_1")).ToString();
                                m_notes_3 = reader1.GetValue(reader1.GetOrdinal("NOTES_2")).ToString();
                                m_notes_4 = reader1.GetValue(reader1.GetOrdinal("NOTES_3")).ToString();
                            }
                        }

                        int iCLEARANCE = int.Parse(reader.GetValue(reader.GetOrdinal("CLEARANCE")).ToString());
                        if (iCLEARANCE > 0) {
                            DataTable dt = new DataTable();
                            dt = Builder_Clearance.Get_Selected_DataTable_ID(iCLEARANCE, "Clearance");
                            if (dt != null) {
                                foreach (DataRow row in dt.Rows) {
                                    m_fltnum = row["FLTNUM"].ToString();
                                    m_dep = row["DEP"].ToString();
                                    m_dest = row["DEST"].ToString();
                                    m_altn = row["ALTN"].ToString();
                                    // display pdc
                                    int iPDC = int.Parse(reader.GetValue(reader.GetOrdinal("DISPLAY_PDC")).ToString());
                                    if (iPDC > 0) {
                                        m_clearance = Builder_Clearance.Build_PDC(row);
                                    }
                                }
                            }
                        }

                        // get dep airport elevation from db
                        int iDepElev = 0;
                        if (m_dep != "") {
                            DataTable dt = new DataTable();
                            dt = Builder_Clearance.Get_Selected_DataTable_DEP(m_dep);
                            if (dt != null) {
                                foreach (DataRow row in dt.Rows) {
                                    iDepElev = int.Parse(row["ELEVATION"].ToString());
                                }
                            }
                        }
                        // performance
                        int iAC = int.Parse(reader.GetValue(reader.GetOrdinal("CONDITIONS_AC")).ToString());
                        if (iAC > 0) {
                            command = new OleDbCommand("SELECT * FROM CONDITIONS_AC WHERE ID=" + iAC, conn);
                            using (OleDbDataReader reader2 = command.ExecuteReader()) {
                                while (reader2.Read()) {
                                    m_gtow = Format_Decimal_1(reader2.GetValue(reader2.GetOrdinal("GTOW")).ToString());
                                    m_towcg = Format_Decimal_1(reader2.GetValue(reader2.GetOrdinal("TOWCG")).ToString());
                                    m_flaps = reader2.GetValue(reader2.GetOrdinal("FLAPS")).ToString();
                                    m_ci = reader2.GetValue(reader2.GetOrdinal("CI")).ToString();
                                    m_zfw = Format_Decimal_1(reader2.GetValue(reader2.GetOrdinal("ZFW")).ToString());
                                    m_zfwcg = Format_Decimal_1(reader2.GetValue(reader2.GetOrdinal("ZFWCG")).ToString());
                                    m_v1 = reader2.GetValue(reader2.GetOrdinal("V1")).ToString();
                                    m_v2 = reader2.GetValue(reader2.GetOrdinal("V2")).ToString();
                                    m_vr = reader2.GetValue(reader2.GetOrdinal("VR")).ToString();
                                    if (reader2.GetValue(reader2.GetOrdinal("FLEX")).ToString() == "1") {
                                        m_thrust = "FLEX+" + reader2.GetValue(reader2.GetOrdinal("THRUST")).ToString();
                                    } else {
                                        m_thrust = "TOGA";
                                    }
                                    m_fuel = Format_Decimal_1(reader2.GetValue(reader2.GetOrdinal("FUEL")).ToString());
                                    m_fuel_taxi = Format_Decimal_1(reader2.GetValue(reader2.GetOrdinal("FUEL_TAXI")).ToString());
                                    //m_fuel_altn = Format_Decimal_1(reader2.GetValue(reader2.GetOrdinal("FUEL_ALTN")).ToString());
                                    m_reserve = "00:" + reader2.GetValue(reader2.GetOrdinal("RESERVE")).ToString();
                                    m_stab = reader2.GetValue(reader2.GetOrdinal("A1")).ToString() + Format_Decimal_1(reader2.GetValue(reader2.GetOrdinal("STAB")).ToString());
                                    m_pax = reader2.GetValue(reader2.GetOrdinal("PAX")).ToString();
                                    m_crzalt = reader2.GetValue(reader2.GetOrdinal("CRZALT")).ToString();

                                    string sAlt = reader2.GetValue(reader2.GetOrdinal("THRUST_RED_ALT")).ToString();
                                    int iAlt = iDepElev + Int32.Parse(sAlt);
                                    m_thrust_red_alt = iAlt.ToString();
                                    sAlt = reader2.GetValue(reader2.GetOrdinal("ACCEL_ALT")).ToString();
                                    iAlt = iDepElev + Int32.Parse(sAlt);
                                    m_accel_alt = iAlt.ToString();
                                    sAlt = reader2.GetValue(reader2.GetOrdinal("EO_ACCEL_ALT")).ToString();
                                    iAlt = iDepElev + Int32.Parse(sAlt);
                                    m_eo_accel_alt = iAlt.ToString();
                                }
                            }
                        }

                        int iWX = int.Parse(reader.GetValue(reader.GetOrdinal("CONDITIONS_WX")).ToString());
                        if (iWX > 0) {
                            DataTable dt = new DataTable();
                            dt = Builder_ATIS.Get_Selected_DataTable_ID(iWX, "Conditions_WX");
                            if (dt != null) {
                                foreach (DataRow row in dt.Rows) {
                                    m_wind = Builder_ATIS.Wind(row);
                                    m_ceiling = Builder_ATIS.Sky(row);
                                    m_visibility = Builder_ATIS.Visibility(row);
                                    m_temp = Builder_ATIS.TempDp(row);
                                    m_qnh = Builder_ATIS.QNH(row, false);
                                    m_runway_cond = Builder_ATIS.RCAM(row);
                                    m_runway = Builder_ATIS.Runways(row,false,true);

                                    // display atis
                                    int iATIS = int.Parse(reader.GetValue(reader.GetOrdinal("DISPLAY_ATIS")).ToString());
                                    if (iATIS > 0) {
                                        m_atis = Builder_ATIS.CompleteATIS(row);
                                    }
                                }
                            }
                        }
                        if (m_gtow != "" ||
                            m_towcg != "" ||
                            m_flaps != "" ||
                            m_ci != "" ||
                            m_zfw != "" ||
                            m_v1 != "" ||
                            m_v2 != "" ||
                            m_vr != "" ||
                            m_fuel != "" ||
                            m_reserve != "" ||
                            m_stab != "" ||
                            m_pax != "" ||
                            m_crzalt != "" ||
                            m_thrust_red_alt != "" ||
                            m_accel_alt != "" //||
                            //m_wind != "" ||
                            //m_ceiling != "" ||
                            //m_visibility != "" ||
                            //m_temp != "" ||
                            //m_qnh != "" ||
                            //m_runway_cond != ""
                            ) {
                            m_setup_visable = "yes";
                        }



                        int iPF = int.Parse(reader.GetValue(reader.GetOrdinal("PF1")).ToString());
                        if (iPF > 0) {
                            command = new OleDbCommand("SELECT * FROM PF WHERE ID=" + iPF, conn);
                            using (OleDbDataReader reader6 = command.ExecuteReader()) {
                                while (reader6.Read()) {
                                    m_pf_1 = reader6.GetValue(reader6.GetOrdinal("PF")).ToString();
                                }
                            }
                        }
                        int iAction = int.Parse(reader.GetValue(reader.GetOrdinal("ACTION1")).ToString());
                        if (iAction > 0) {
                            command = new OleDbCommand("SELECT * FROM Actions WHERE ID=" + iAction, conn);
                            using (OleDbDataReader reader6 = command.ExecuteReader()) {
                                while (reader6.Read()) {
                                    m_actiontitle_1 = reader6.GetValue(reader6.GetOrdinal("ACTIONTITLE")).ToString();
                                    m_actions_1 = reader6.GetValue(reader6.GetOrdinal("ACTIONS")).ToString();
                                    m_actions_1 = Get_Action_ATIS_PDC(reader6, m_actions_1);
                                    m_comm_1 = reader6.GetValue(reader6.GetOrdinal("COMM")).ToString();
                                }
                            }
                        }
                        iPF = int.Parse(reader.GetValue(reader.GetOrdinal("PF2")).ToString());
                        if (iPF > 0) {
                            command = new OleDbCommand("SELECT * FROM PF WHERE ID=" + iPF, conn);
                            using (OleDbDataReader reader6 = command.ExecuteReader()) {
                                while (reader6.Read()) {
                                    m_pf_2 = reader6.GetValue(reader6.GetOrdinal("PF")).ToString();
                                }
                            }
                        }
                        iAction = int.Parse(reader.GetValue(reader.GetOrdinal("ACTION2")).ToString());
                        if (iAction > 0) {
                            command = new OleDbCommand("SELECT * FROM Actions WHERE ID=" + iAction, conn);
                            using (OleDbDataReader reader6 = command.ExecuteReader()) {
                                while (reader6.Read()) {
                                    m_actiontitle_2 = reader6.GetValue(reader6.GetOrdinal("ACTIONTITLE")).ToString();
                                    m_actions_2 = reader6.GetValue(reader6.GetOrdinal("ACTIONS")).ToString();
                                    m_actions_2 = Get_Action_ATIS_PDC(reader6, m_actions_2);
                                    m_comm_2 = reader6.GetValue(reader6.GetOrdinal("COMM")).ToString();
                                }
                            }
                        }
                        iPF = int.Parse(reader.GetValue(reader.GetOrdinal("PF3")).ToString());
                        if (iPF > 0) {
                            command = new OleDbCommand("SELECT * FROM PF WHERE ID=" + iPF, conn);
                            using (OleDbDataReader reader6 = command.ExecuteReader()) {
                                while (reader6.Read()) {
                                    m_pf_3 = reader6.GetValue(reader6.GetOrdinal("PF")).ToString();
                                }
                            }
                        }
                        iAction = int.Parse(reader.GetValue(reader.GetOrdinal("ACTION3")).ToString());
                        if (iAction > 0) {
                            command = new OleDbCommand("SELECT * FROM Actions WHERE ID=" + iAction, conn);
                            using (OleDbDataReader reader6 = command.ExecuteReader()) {
                                while (reader6.Read()) {
                                    m_actiontitle_3 = reader6.GetValue(reader6.GetOrdinal("ACTIONTITLE")).ToString();
                                    m_actions_3 = reader6.GetValue(reader6.GetOrdinal("ACTIONS")).ToString();
                                    m_actions_3 = Get_Action_ATIS_PDC(reader6, m_actions_3);
                                    m_comm_3 = reader6.GetValue(reader6.GetOrdinal("COMM")).ToString();
                                }
                            }
                        }
                        iPF = int.Parse(reader.GetValue(reader.GetOrdinal("PF4")).ToString());
                        if (iPF > 0) {
                            command = new OleDbCommand("SELECT * FROM PF WHERE ID=" + iPF, conn);
                            using (OleDbDataReader reader6 = command.ExecuteReader()) {
                                while (reader6.Read()) {
                                    m_pf_4 = reader6.GetValue(reader6.GetOrdinal("PF")).ToString();
                                }
                            }
                        }
                        iAction = int.Parse(reader.GetValue(reader.GetOrdinal("ACTION4")).ToString());
                        if (iAction > 0) {
                            command = new OleDbCommand("SELECT * FROM Actions WHERE ID=" + iAction, conn);
                            using (OleDbDataReader reader6 = command.ExecuteReader()) {
                                while (reader6.Read()) {
                                    m_actiontitle_4 = reader6.GetValue(reader6.GetOrdinal("ACTIONTITLE")).ToString();
                                    m_actions_4 = reader6.GetValue(reader6.GetOrdinal("ACTIONS")).ToString();
                                    m_actions_4 = Get_Action_ATIS_PDC(reader6, m_actions_4);
                                    m_comm_4 = reader6.GetValue(reader6.GetOrdinal("COMM")).ToString();
                                }
                            }
                        }
                        iPF = int.Parse(reader.GetValue(reader.GetOrdinal("PF5")).ToString());
                        if (iPF > 0) {
                            command = new OleDbCommand("SELECT * FROM PF WHERE ID=" + iPF, conn);
                            using (OleDbDataReader reader6 = command.ExecuteReader()) {
                                while (reader6.Read()) {
                                    m_pf_5 = reader6.GetValue(reader6.GetOrdinal("PF")).ToString();
                                }
                            }
                        }
                        iAction = int.Parse(reader.GetValue(reader.GetOrdinal("ACTION5")).ToString());
                        if (iAction > 0) {
                            command = new OleDbCommand("SELECT * FROM Actions WHERE ID=" + iAction, conn);
                            using (OleDbDataReader reader6 = command.ExecuteReader()) {
                                while (reader6.Read()) {
                                    m_actiontitle_5 = reader6.GetValue(reader6.GetOrdinal("ACTIONTITLE")).ToString();
                                    m_actions_5 = reader6.GetValue(reader6.GetOrdinal("ACTIONS")).ToString();
                                    m_actions_5 = Get_Action_ATIS_PDC(reader6, m_actions_5);
                                    m_comm_5 = reader6.GetValue(reader6.GetOrdinal("COMM")).ToString();
                                }
                            }
                        }
                        iPF = int.Parse(reader.GetValue(reader.GetOrdinal("PF6")).ToString());
                        if (iPF > 0) {
                            command = new OleDbCommand("SELECT * FROM PF WHERE ID=" + iPF, conn);
                            using (OleDbDataReader reader6 = command.ExecuteReader()) {
                                while (reader6.Read()) {
                                    m_pf_6 = reader6.GetValue(reader6.GetOrdinal("PF")).ToString();
                                }
                            }
                        }
                        iAction = int.Parse(reader.GetValue(reader.GetOrdinal("ACTION6")).ToString());
                        if (iAction > 0) {
                            command = new OleDbCommand("SELECT * FROM Actions WHERE ID=" + iAction, conn);
                            using (OleDbDataReader reader6 = command.ExecuteReader()) {
                                while (reader6.Read()) {
                                    m_actiontitle_6 = reader6.GetValue(reader6.GetOrdinal("ACTIONTITLE")).ToString();
                                    m_actions_6 = reader6.GetValue(reader6.GetOrdinal("ACTIONS")).ToString();
                                    m_actions_6 = Get_Action_ATIS_PDC(reader6, m_actions_6);
                                    m_comm_6 = reader6.GetValue(reader6.GetOrdinal("COMM")).ToString();
                                }
                            }
                        }
                        iPF = int.Parse(reader.GetValue(reader.GetOrdinal("PF7")).ToString());
                        if (iPF > 0) {
                            command = new OleDbCommand("SELECT * FROM PF WHERE ID=" + iPF, conn);
                            using (OleDbDataReader reader6 = command.ExecuteReader()) {
                                while (reader6.Read()) {
                                    m_pf_7 = reader6.GetValue(reader6.GetOrdinal("PF")).ToString();
                                }
                            }
                        }
                        iAction = int.Parse(reader.GetValue(reader.GetOrdinal("ACTION7")).ToString());
                        if (iAction > 0) {
                            command = new OleDbCommand("SELECT * FROM Actions WHERE ID=" + iAction, conn);
                            using (OleDbDataReader reader6 = command.ExecuteReader()) {
                                while (reader6.Read()) {
                                    m_actiontitle_7 = reader6.GetValue(reader6.GetOrdinal("ACTIONTITLE")).ToString();
                                    m_actions_7 = reader6.GetValue(reader6.GetOrdinal("ACTIONS")).ToString();
                                    m_actions_7 = Get_Action_ATIS_PDC(reader6, m_actions_7);
                                    m_comm_7 = reader6.GetValue(reader6.GetOrdinal("COMM")).ToString();
                                }
                            }
                        }
                        iPF = int.Parse(reader.GetValue(reader.GetOrdinal("PF8")).ToString());
                        if (iPF > 0) {
                            command = new OleDbCommand("SELECT * FROM PF WHERE ID=" + iPF, conn);
                            using (OleDbDataReader reader6 = command.ExecuteReader()) {
                                while (reader6.Read()) {
                                    m_pf_8 = reader6.GetValue(reader6.GetOrdinal("PF")).ToString();
                                }
                            }
                        }
                        iAction = int.Parse(reader.GetValue(reader.GetOrdinal("ACTION8")).ToString());
                        if (iAction > 0) {
                            command = new OleDbCommand("SELECT * FROM Actions WHERE ID=" + iAction, conn);
                            using (OleDbDataReader reader6 = command.ExecuteReader()) {
                                while (reader6.Read()) {
                                    m_actiontitle_8 = reader6.GetValue(reader6.GetOrdinal("ACTIONTITLE")).ToString();
                                    m_actions_8 = reader6.GetValue(reader6.GetOrdinal("ACTIONS")).ToString();
                                    m_actions_8 = Get_Action_ATIS_PDC(reader6, m_actions_8);
                                    m_comm_8 = reader6.GetValue(reader6.GetOrdinal("COMM")).ToString();
                                }
                            }
                        }

                    } else {
                        // break
                        m_setup_visable = "no";
                        m_spot = "";
                        m_minutes = int.Parse(reader.GetValue(reader.GetOrdinal("MINUTES")).ToString());
                        iEndTime = iEndTime + m_minutes;
                        m_time_start = "START: " + GlobalCode.Convert_MinutesToTime(iStartTime);
                        m_time_spot = "" + GlobalCode.Convert_MinutesToTime(m_minutes);
                        m_time_end = "END: " + GlobalCode.Convert_MinutesToTime(iEndTime);
                        m_text_footer = "BREAK COMPLETE. SESSION TIME " + GlobalCode.Convert_MinutesToTime(iEndTime);
                        iStartTime = iStartTime + m_minutes;
                        string sMinutes = Convert.ToString(m_minutes);
                        if (sMinutes == "")
                            sMinutes = "0";
                        m_maneuver = "BREAK FOR " + sMinutes + " MINUTES...";
                    }
                }
            }

            m_Script.Add(new Script(
                        m_id,
                        m_runway,
                        m_fuel_taxi,
                        m_fuel_altn,
                        m_fltnum,
                        m_dep,
                        m_dest,
                        m_altn,

                        m_preamble_Before_1,
                        m_preamble_After_1,
                        m_preamble_title_1,
                        m_preamble_text_1,
                        m_preamble_title_2,
                        m_preamble_text_2,
                        m_preamble_title_3,
                        m_preamble_text_3,

                        m_preamble_Before_21,
                        m_preamble_After_21,
                        m_preamble_title_21,
                        m_preamble_text_21,
                        m_preamble_title_22,
                        m_preamble_text_22,
                        m_preamble_title_23,
                        m_preamble_text_23,

                        m_preamble_Before_31,
                        m_preamble_After_31,
                        m_preamble_title_31,
                        m_preamble_text_31,
                        m_preamble_title_32,
                        m_preamble_text_32,
                        m_preamble_title_33,
                        m_preamble_text_33,

                        m_preamble_Before_41,
                        m_preamble_After_41,
                        m_preamble_title_41,
                        m_preamble_text_41,
                        m_preamble_title_42,
                        m_preamble_text_42,
                        m_preamble_title_43,
                        m_preamble_text_43,

                        m_setup_visable,
                        m_text_header,
                        m_text_title,
                        m_text_footer,
                        m_time_start,
                        m_time_spot,
                        m_time_end,
                        m_maneuver_name,
                        m_date_created,
                        m_date_edited,
                        m_spot,
                        m_ata_code,
                        m_sop_phase,
                        m_maneuver,
                        m_minutes,
                        m_objective1,
                        m_objective2,
                        m_scope1,
                        m_scope2,
                        m_sim_position,
                        m_sim_setup1,
                        m_sim_setup2,
                        m_sim_setup3,
                        m_sim_setup4,
                        m_gtow,
                        m_towcg,
                        m_flaps,
                        m_ci,
                        m_zfw,
                        m_zfwcg,
                        m_v1,
                        m_v2,
                        m_vr,
                        m_thrust,
                        m_fuel,
                        m_reserve,
                        m_stab,
                        m_pax,
                        m_crzalt,
                        m_thrust_red_alt,
                        m_accel_alt,
                        m_eo_accel_alt,
                        m_runway_cond,
                        m_wind,
                        m_ceiling,
                        m_visibility,
                        m_temp,
                        m_qnh,
                        m_atis,
                        m_clearance,
                        m_setup_2,
                        m_setup_3,
                        m_setup_4,
                        m_notes_1,
                        m_notes_2,
                        m_notes_3,
                        m_notes_4,
                        m_notes_5,
                        m_pf_1,
                        m_actiontitle_1,
                        m_actions_1,
                        m_comm_1,
                        m_pf_2,
                        m_actiontitle_2,
                        m_actions_2,
                        m_comm_2,
                        m_pf_3,
                        m_actiontitle_3,
                        m_actions_3,
                        m_comm_3,
                        m_pf_4,
                        m_actiontitle_4,
                        m_actions_4,
                        m_comm_4,
                        m_pf_5,
                        m_actiontitle_5,
                        m_actions_5,
                        m_comm_5,
                        m_pf_6,
                        m_actiontitle_6,
                        m_actions_6,
                        m_comm_6,
                        m_pf_7,
                        m_actiontitle_7,
                        m_actions_7,
                        m_comm_7,
                        m_pf_8,
                        m_actiontitle_8,
                        m_actions_8,
                        m_comm_8,
                        m_pf_9,
                        m_actiontitle_9,
                        m_actions_9,
                        m_comm_9,
                        m_pf_10,
                        m_actiontitle_10,
                        m_actions_10,
                        m_comm_10
                ));

        }
    }

    public List<Script> GetScriptData() {
        return m_Script;
    }

    private string Format_Decimal_1(string sInput) {
        if (sInput.IndexOf(".") < 0) {
            // add decimal
            sInput = sInput + ".0";
        }
        return sInput;
    }
    private string Get_Action_ATIS_PDC(OleDbDataReader reader6, string sActionText) {
        if (int.Parse(reader6.GetValue(reader6.GetOrdinal("ATIS1")).ToString()) > 0) {
            // append atis to bottom of action
            int iWX = int.Parse(reader6.GetValue(reader6.GetOrdinal("ATIS1")).ToString());
            sActionText = sActionText + "\n\r" + Builder_ATIS.Get_Action_Atis(iWX);
            iWX = int.Parse(reader6.GetValue(reader6.GetOrdinal("ATIS2")).ToString());
            sActionText = sActionText + "\n\r\n\r" + Builder_ATIS.Get_Action_Atis(iWX);
            iWX = int.Parse(reader6.GetValue(reader6.GetOrdinal("ATIS3")).ToString());
            sActionText = sActionText + "\n\r\n\r" + Builder_ATIS.Get_Action_Atis(iWX);
        }
        if (int.Parse(reader6.GetValue(reader6.GetOrdinal("PDC")).ToString()) > 0) {
            // append pdc to bottom of action
            int iPDC = int.Parse(reader6.GetValue(reader6.GetOrdinal("PDC")).ToString());
            sActionText = sActionText + "\n\r" + Builder_Clearance.Get_Action_PDC(iPDC);
        }
        return sActionText;
    }
    //public IEnumerator<Script> GetEnumerator() {
    //    return m_Script.GetEnumerator();
    //    //throw new NotImplementedException();
    //}
    //System.Collections.IEnumerator IEnumerable.GetEnumerator() {
    //    return this.GetEnumerator();
    //}

}
