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
    public partial class frmBuilderCurriculum : Form {
        public frmBuilderCurriculum() {
            InitializeComponent();
            listManeuvers.MouseDown += listManeuvers_MouseDown;
            listScript.MouseDown += listScript_MouseDown;
            listScript.MouseUp += listScript_MouseUp;
            listScript.DragDrop += listScript_DragDrop;
            listScript.DragEnter += listScript_DragEnter;
            listScript.DragOver += listScript_DragOver;
            listScript.DragLeave += listScript_DragLeave;
            listManeuvers.DrawItem += listBox_DrawItem;
            listScript.DrawItem += listBox_DrawItem;
            lblTrash.DragOver += lblTrash_DragOver;
            lblTrash.DragDrop += lblTrash_DragDrop;
        }
        private OleDbConnection conn;
        DataSet ds = new DataSet();
        private OleDbDataAdapter dataAdapter;
        DataTable dtTable;

        private void frmBuilderCurriculum_Load(object sender, EventArgs e) {
            this.Text = GlobalCode.sCARRIER + " " + GlobalCode.sFleet + this.Text;
            btnGenerateScript.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;

            Initialize_DB();
            Fill_listbox();

            Fill_CBOs(cboScripts, "SELECT ID, CURRICULUM_NAME FROM Curriculum ORDER BY ID");

            Fill_CBOs(cboPreamble1, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble2, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble3, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble4, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble5, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble6, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble7, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble8, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble9, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble10, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");

        }

        private void Initialize_DB() {
            string sQuery = "SELECT * FROM Curriculum";
            conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
            dataAdapter = new OleDbDataAdapter(sQuery, GlobalCode.sOleDbConnectionString);
            dtTable = new DataTable();
            dtTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            conn.Open();
            dataAdapter.Fill(dtTable);
            OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dataAdapter);
            conn.Close();
        }

        private void Fill_listbox() {
            DataTable dtReport = new DataTable();
            OleDbConnection conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
            conn.Open();
            string selectCommand = "SELECT ID,LESSON_NAME FROM Lesson";
            OleDbCommand comm = new OleDbCommand(selectCommand, conn);
            OleDbDataReader reader = comm.ExecuteReader();

            int iCount = 0;
            while (reader.Read()) {
                iCount++;
                this.listManeuvers.Items.Add(reader.GetValue(0).ToString() + "- " + reader.GetValue(1).ToString());
            }
            reader.Close();
            conn.Close();
        }


        bool bMove = false;
        private void listManeuvers_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
            // copy a maneuver to the listScript
            ListBox lb = sender as ListBox;
            bMove = false;
            int indexOfItem = lb.IndexFromPoint(e.X, e.Y);
            if (indexOfItem >= 0 && indexOfItem < lb.Items.Count)
                lb.DoDragDrop(lb.Items[indexOfItem], DragDropEffects.Copy);
        }
        private void listScript_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
            ListBox lb = sender as ListBox;
            // used to re-arrange the maneuvers in the list
            indexOfItemUnderMouseToDrop = lb.SelectedIndex;
            bMove = true;
            if (lb.SelectedItem == null)
                return;
            lb.DoDragDrop(lb.SelectedItem, DragDropEffects.Move);
        }
        private void listScript_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e) {
            ListBox lb = sender as ListBox;
        }
        private void listScript_DragEnter(object sender, System.Windows.Forms.DragEventArgs e) {
            // change the drag cursor to show valid data ready
            if (e.Data.GetDataPresent(DataFormats.StringFormat) && (e.AllowedEffect == DragDropEffects.Copy))
                e.Effect = DragDropEffects.Copy;
        }
        int indexOfItemUnderMouseToDrop;
        private void listScript_DragOver(object sender, System.Windows.Forms.DragEventArgs e) {
            ListBox lb = sender as ListBox;
            if (bMove == true) {
                e.Effect = DragDropEffects.Move;
            } else {
                indexOfItemUnderMouseToDrop = lb.IndexFromPoint(lb.PointToClient(new Point(e.X, e.Y)));
                if (indexOfItemUnderMouseToDrop != ListBox.NoMatches) {
                    lb.SelectedIndex = indexOfItemUnderMouseToDrop;
                } else {
                    lb.SelectedIndex = indexOfItemUnderMouseToDrop;
                }
                if (e.Effect == DragDropEffects.Move)
                    lb.Items.Remove((string)e.Data.GetData(DataFormats.Text));
            }
        }
        private void listScript_DragDrop(object sender, System.Windows.Forms.DragEventArgs e) {
            ListBox lb = sender as ListBox;
            if (bMove == true) {
                // re-arrange the selected string in list
                Point point = lb.PointToClient(new Point(e.X, e.Y));
                int index = lb.IndexFromPoint(point);
                if (index < 0)
                    index = lb.Items.Count - 1;
                object data = lb.SelectedItem;
                lb.Items.Remove(data);
                lb.Items.Insert(index, data);
            } else {
                // add the selected string to position list
                if (e.Data.GetDataPresent(DataFormats.StringFormat)) {
                    // look for duplicates and add * to indicate (keeps re-order method working)
                    string sSearchText = (string)e.Data.GetData(DataFormats.Text);
                    int index = lb.FindString(sSearchText, -1);
                    if (index > -1)
                        sSearchText = sSearchText + "*";
                    index = lb.FindString(sSearchText, -1);
                    if (index > -1)
                        sSearchText = sSearchText + "*";
                    index = lb.FindString(sSearchText, -1);
                    if (index > -1)
                        sSearchText = sSearchText + "*";
                    index = lb.FindString(sSearchText, -1);
                    if (index > -1)
                        sSearchText = sSearchText + "*";
                    if (indexOfItemUnderMouseToDrop >= 0 && indexOfItemUnderMouseToDrop < lb.Items.Count) {
                        lb.Items.Insert(indexOfItemUnderMouseToDrop, sSearchText);
                    } else {
                        lb.Items.Add(sSearchText);
                    }
                }
            }
            if (listScript.Items.Count > 0 && txtScriptName.Text != "") {
                btnSave.Enabled = true;
            } else {
                btnSave.Enabled = false;
            }
        }
        private void listScript_DragLeave(object sender, EventArgs e) {
            //ListBox lb = sender as ListBox;
            //            lb.Items.Remove(lb.SelectedItem);
            //Debug.WriteLine("listScript_DragLeave:");

        }
        private void lblTrash_DragOver(object sender, System.Windows.Forms.DragEventArgs e) {
            Label lb = sender as Label;
            e.Effect = DragDropEffects.All;
            //listScript.Items.Remove(indexOfItemUnderMouseToDrop);
        }
        private void lblTrash_DragDrop(object sender, System.Windows.Forms.DragEventArgs e) {
            Label lb = sender as Label;
            e.Effect = DragDropEffects.All;
            listScript.Items.RemoveAt(indexOfItemUnderMouseToDrop);
            if (listScript.Items.Count > 0 && txtScriptName.Text != "") {
                btnSave.Enabled = true;
            } else {
                btnSave.Enabled = false;
            }
        }
        private void listBox_DrawItem(object sender, DrawItemEventArgs e) {
            ListBox lb = sender as ListBox;
            bool isSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

            if (e.Index > -1) {
                /* If the item is selected set the background color to SystemColors.Highlight 
                 or else set the color to either WhiteSmoke or White depending if the item index is even or odd */
                Color color = isSelected ? SystemColors.Highlight :
                    e.Index % 2 == 0 ? Color.WhiteSmoke : Color.White;

                // Background item brush
                SolidBrush backgroundBrush = new SolidBrush(color);
                // Text color brush
                SolidBrush textBrush = new SolidBrush(e.ForeColor);

                // Draw the background
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
                // Draw the text
                e.Graphics.DrawString(lb.Items[e.Index].ToString(), e.Font, textBrush, e.Bounds, StringFormat.GenericDefault);

                // Clean up
                backgroundBrush.Dispose();
                textBrush.Dispose();
            }
            e.DrawFocusRectangle();
        }


        private void Set_Selected_CBO(ComboBox cbo, int i) {
            foreach (KeyValuePair<int, string> row in cbo.Items) {
                if (row.Key == i) {
                    cbo.SelectedIndex = cbo.Items.IndexOf(row);
                }
            }
        }
        private void FillData() {

            int iSelected = Get_Selected_Key(cboScripts);
            if (cboScripts.SelectedIndex > 0 || iSelected > -1) {
                string sCommand = "SELECT * FROM Curriculum WHERE ID = " + iSelected;
                conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
                DataTable dt = new DataTable();
                dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dAdapter.Fill(dt);
                conn.Close();

                this.listScript.Items.Clear();
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++) {

                    txtScriptName.Text = (string)dt.Rows[i]["CURRICULUM_NAME"];

                    // set the preambles
                    if ((int)dt.Rows[i]["PREAMBLE1"] > 0)
                        Set_Selected_CBO(cboPreamble1, (int)dt.Rows[i]["PREAMBLE1"]);
                    if ((int)dt.Rows[i]["P1_BEFORE"] == 1)
                        chk1PlaceBefore.Checked = true;
                    if ((int)dt.Rows[i]["P1_AFTER"] == 1)
                        chk1PlaceAfter.Checked = true;

                    if ((int)dt.Rows[i]["PREAMBLE2"] > 0)
                        Set_Selected_CBO(cboPreamble2, (int)dt.Rows[i]["PREAMBLE2"]);
                    if ((int)dt.Rows[i]["P2_BEFORE"] == 1)
                        chk2PlaceBefore.Checked = true;
                    if ((int)dt.Rows[i]["P2_AFTER"] == 1)
                        chk2PlaceAfter.Checked = true;

                    if ((int)dt.Rows[i]["PREAMBLE3"] > 0)
                        Set_Selected_CBO(cboPreamble3, (int)dt.Rows[i]["PREAMBLE3"]);
                    if ((int)dt.Rows[i]["P3_BEFORE"] == 1)
                        chk3PlaceBefore.Checked = true;
                    if ((int)dt.Rows[i]["P3_AFTER"] == 1)
                        chk3PlaceAfter.Checked = true;

                    if ((int)dt.Rows[i]["PREAMBLE4"] > 0)
                        Set_Selected_CBO(cboPreamble4, (int)dt.Rows[i]["PREAMBLE4"]);
                    if ((int)dt.Rows[i]["P4_BEFORE"] == 1)
                        chk4PlaceBefore.Checked = true;
                    if ((int)dt.Rows[i]["P4_AFTER"] == 1)
                        chk4PlaceAfter.Checked = true;

                    if ((int)dt.Rows[i]["PREAMBLE5"] > 0)
                        Set_Selected_CBO(cboPreamble5, (int)dt.Rows[i]["PREAMBLE5"]);
                    if ((int)dt.Rows[i]["P5_BEFORE"] == 1)
                        chk5PlaceBefore.Checked = true;
                    if ((int)dt.Rows[i]["P5_AFTER"] == 1)
                        chk5PlaceAfter.Checked = true;

                    if ((int)dt.Rows[i]["PREAMBLE6"] > 0)
                        Set_Selected_CBO(cboPreamble6, (int)dt.Rows[i]["PREAMBLE6"]);
                    if ((int)dt.Rows[i]["P6_BEFORE"] == 1)
                        chk6PlaceBefore.Checked = true;
                    if ((int)dt.Rows[i]["P6_AFTER"] == 1)
                        chk6PlaceAfter.Checked = true;

                    if ((int)dt.Rows[i]["PREAMBLE7"] > 0)
                        Set_Selected_CBO(cboPreamble7, (int)dt.Rows[i]["PREAMBLE7"]);
                    if ((int)dt.Rows[i]["P7_BEFORE"] == 1)
                        chk7PlaceBefore.Checked = true;
                    if ((int)dt.Rows[i]["P7_AFTER"] == 1)
                        chk7PlaceAfter.Checked = true;

                    if ((int)dt.Rows[i]["PREAMBLE8"] > 0)
                        Set_Selected_CBO(cboPreamble8, (int)dt.Rows[i]["PREAMBLE8"]);
                    if ((int)dt.Rows[i]["P8_BEFORE"] == 1)
                        chk8PlaceBefore.Checked = true;
                    if ((int)dt.Rows[i]["P8_AFTER"] == 1)
                        chk8PlaceAfter.Checked = true;

                    if ((int)dt.Rows[i]["PREAMBLE9"] > 0)
                        Set_Selected_CBO(cboPreamble9, (int)dt.Rows[i]["PREAMBLE9"]);
                    if ((int)dt.Rows[i]["P9_BEFORE"] == 1)
                        chk9PlaceBefore.Checked = true;
                    if ((int)dt.Rows[i]["P9_AFTER"] == 1)
                        chk9PlaceAfter.Checked = true;

                    if ((int)dt.Rows[i]["PREAMBLE10"] > 0)
                        Set_Selected_CBO(cboPreamble10, (int)dt.Rows[i]["PREAMBLE10"]);
                    if ((int)dt.Rows[i]["P10_BEFORE"] == 1)
                        chk10PlaceBefore.Checked = true;
                    if ((int)dt.Rows[i]["P10_AFTER"] == 1)
                        chk1PlaceAfter.Checked = true;




                    //for (int x = 4; x <= 33; x++) {
                    //    int ispot = (int)dt.Rows[i].ItemArray[x];
                    //    if (ispot > -1) {
                    //        //DataTable dtReport = new DataTable();
                    //        //OleDbConnection conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
                    //        conn.Open();
                    //        string selectCommand = "SELECT ID,SPOT_NAME,MINUTES FROM Spots WHERE ID = " + ispot;
                    //        OleDbCommand comm = new OleDbCommand(selectCommand, conn);
                    //        OleDbDataReader reader = comm.ExecuteReader();
                    //        while (reader.Read()) {
                    //            string sMinutes = reader.GetValue(2).ToString();
                    //            if (sMinutes == "")
                    //                sMinutes = "0";
                    //            int iMinutes = int.Parse(sMinutes);
                    //            if (iMinutes < 10) {
                    //                sMinutes = ":0" + Convert.ToString(iMinutes);
                    //            } else {
                    //                sMinutes = ":" + Convert.ToString(iMinutes);
                    //            }
                    //            this.listScript.Items.Add(reader.GetValue(0).ToString() + "- (" + sMinutes + ") " + reader.GetValue(1).ToString());
                    //        }
                    //        reader.Close();
                    //        conn.Close();
                    //    }
                    //}
                }
                btnGenerateScript.Enabled = true;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = true;
            } else {
                btnGenerateScript.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        private void GenerateLessonPDF() {

            int iSelected = Get_Selected_Key(cboScripts);
            if (cboScripts.SelectedIndex > 0 || iSelected > -1) {

                // save the Curriculum ID to list
                //iLessonList1.Add(iSelected);


                string sCommand = "SELECT * FROM Curriculum WHERE ID = " + iSelected;
                conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
                DataTable dt = new DataTable();
                dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dAdapter.Fill(dt);
                conn.Close();

                // cycle thru curriculum list for all lessons
                List<int> iLessonList1 = new List<int>();
                //List<int> iSPOTList1 = new List<int>();
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++) {
                    for (int x = 4; x <= 33; x++) {
                        int iLesson = (int)dt.Rows[i].ItemArray[x];
                        if (iLesson > -1) {
                            iLessonList1.Add(iLesson);
                        }
                    }
                    GlobalCode.iLessonList = iLessonList1.ToArray();
                    //GlobalCode.iSPOTList = iSPOTList1.ToArray();
                }

                //AbcPDF.Generate_PDF();
                PDF.Generate_PDF();

                //frmReportViewer frmReport = new frmReportViewer();
                //frmReport.Show();

                //frmPDF frmPDF = new frmPDF();
                //frmPDF.Show();
            }

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

        private void AddDataRow() {
            System.Data.DataRow dr = dtTable.NewRow();

            dr["CURRICULUM_NAME"] = txtScriptName.Text;
            dr["DATE_CREATED"] = GetDateString(DateTime.Now);
            dr["DATE_EDITED"] = GetDateString(DateTime.Now);

            //dr["LESSON_PREAMBLE_TITLE_1"] = "";
            //dr["LESSON_PREAMBLE_TEXT_1"] = "";
            //dr["LESSON_PREAMBLE_TITLE_2"] = "";
            //dr["LESSON_PREAMBLE_TEXT_2"] = "";
            //dr["LESSON_PREAMBLE_TITLE_3"] = "";
            //dr["LESSON_PREAMBLE_TEXT_3"] = "";

            int itemCount = listScript.Items.Count;
            int iItem = -1;
            for (int i = 0; i < 30; i++) {
                if (i < itemCount) {
                    string sItem = (string)listScript.Items[i];
                    sItem = sItem.Substring(0, sItem.IndexOf("-"));
                    iItem = int.Parse(sItem);
                } else {
                    iItem = -1;
                }
                dr["SPOT" + (i + 1)] = iItem;
            }
            dr["PREAMBLE1"] = Get_Selected_Key(cboPreamble1);
            dr["PREAMBLE2"] = Get_Selected_Key(cboPreamble2);
            dr["PREAMBLE3"] = Get_Selected_Key(cboPreamble3);
            dr["PREAMBLE4"] = Get_Selected_Key(cboPreamble4);
            dr["PREAMBLE5"] = Get_Selected_Key(cboPreamble5);
            dr["PREAMBLE6"] = Get_Selected_Key(cboPreamble6);
            dr["PREAMBLE7"] = Get_Selected_Key(cboPreamble7);
            dr["PREAMBLE8"] = Get_Selected_Key(cboPreamble8);
            dr["PREAMBLE9"] = Get_Selected_Key(cboPreamble9);
            dr["PREAMBLE10"] = Get_Selected_Key(cboPreamble10);

            if (chk1PlaceBefore.Checked) {
                dr["P1_BEFORE"] = 1;
            } else {
                dr["P1_BEFORE"] = 0;
            }
            if (chk1PlaceAfter.Checked) {
                dr["P1_AFTER"] = 1;
            } else {
                dr["P1_AFTER"] = 0;
            }

            if (chk2PlaceBefore.Checked) {
                dr["P2_BEFORE"] = 1;
            } else {
                dr["P2_BEFORE"] = 0;
            }
            if (chk2PlaceAfter.Checked) {
                dr["P2_AFTER"] = 1;
            } else {
                dr["P2_AFTER"] = 0;
            }

            if (chk3PlaceBefore.Checked) {
                dr["P3_BEFORE"] = 1;
            } else {
                dr["P3_BEFORE"] = 0;
            }
            if (chk3PlaceAfter.Checked) {
                dr["P3_AFTER"] = 1;
            } else {
                dr["P3_AFTER"] = 0;
            }

            if (chk4PlaceBefore.Checked) {
                dr["P4_BEFORE"] = 1;
            } else {
                dr["P4_BEFORE"] = 0;
            }
            if (chk4PlaceAfter.Checked) {
                dr["P4_AFTER"] = 1;
            } else {
                dr["P4_AFTER"] = 0;
            }

            if (chk5PlaceBefore.Checked) {
                dr["P5_BEFORE"] = 1;
            } else {
                dr["P5_BEFORE"] = 0;
            }
            if (chk5PlaceAfter.Checked) {
                dr["P5_AFTER"] = 1;
            } else {
                dr["P5_AFTER"] = 0;
            }

            if (chk6PlaceBefore.Checked) {
                dr["P6_BEFORE"] = 1;
            } else {
                dr["P6_BEFORE"] = 0;
            }
            if (chk6PlaceAfter.Checked) {
                dr["P6_AFTER"] = 1;
            } else {
                dr["P6_AFTER"] = 0;
            }

            if (chk7PlaceBefore.Checked) {
                dr["P7_BEFORE"] = 1;
            } else {
                dr["P7_BEFORE"] = 0;
            }
            if (chk7PlaceAfter.Checked) {
                dr["P7_AFTER"] = 1;
            } else {
                dr["P7_AFTER"] = 0;
            }

            if (chk8PlaceBefore.Checked) {
                dr["P8_BEFORE"] = 1;
            } else {
                dr["P8_BEFORE"] = 0;
            }
            if (chk8PlaceAfter.Checked) {
                dr["P8_AFTER"] = 1;
            } else {
                dr["P8_AFTER"] = 0;
            }

            if (chk9PlaceBefore.Checked) {
                dr["P9_BEFORE"] = 1;
            } else {
                dr["P9_BEFORE"] = 0;
            }
            if (chk9PlaceAfter.Checked) {
                dr["P9_AFTER"] = 1;
            } else {
                dr["P9_AFTER"] = 0;
            }

            if (chk10PlaceBefore.Checked) {
                dr["P10_BEFORE"] = 1;
            } else {
                dr["P10_BEFORE"] = 0;
            }
            if (chk10PlaceAfter.Checked) {
                dr["P10_AFTER"] = 1;
            } else {
                dr["P10_AFTER"] = 0;
            }

            dtTable.Rows.Add(dr);
            dataAdapter.Update(dtTable);  // write new row back to database

            Clear_Entries();
            Fill_CBOs(cboScripts, "SELECT ID, CURRICULUM_NAME FROM Curriculum ORDER BY ID");
        }
        private void Update() {
            if (Get_Selected_Key(cboScripts) > -1) {
                string strUpdate = "UPDATE Lesson SET " +
                    "CURRICULUM_NAME = @lesson_name," +
                    "DATE_EDITED = @date_edited," +
                    "SPOT1 = @spot1," +
                    "SPOT2 = @spot2," +
                    "SPOT3 = @spot3," +
                    "SPOT4 = @spot4," +
                    "SPOT5 = @spot5," +
                    "SPOT6 = @spot6," +
                    "SPOT7 = @spot7," +
                    "SPOT8 = @spot8," +
                    "SPOT9 = @spot9," +
                    "SPOT10 = @spot10," +
                    "SPOT11 = @spot11," +
                    "SPOT12 = @spot12," +
                    "SPOT13 = @spot13," +
                    "SPOT14 = @spot14," +
                    "SPOT15 = @spot15," +
                    "SPOT16 = @spot16," +
                    "SPOT17 = @spot17," +
                    "SPOT18 = @spot18," +
                    "SPOT19 = @spot19," +
                    "SPOT20 = @spot20," +
                    "SPOT21 = @spot21," +
                    "SPOT22 = @spot22," +
                    "SPOT23 = @spot23," +
                    "SPOT24 = @spot24," +
                    "SPOT25 = @spot25," +
                    "SPOT26 = @spot26," +
                    "SPOT27 = @spot27," +
                    "SPOT28 = @spot28," +
                    "SPOT29 = @spot29," +
                    "SPOT30 = @spot30," +
                    "PREAMBLE1 = @preamble1," +
                    "PREAMBLE2 = @preamble2," +
                    "PREAMBLE3 = @preamble3," +
                    "PREAMBLE4 = @preamble4," +
                    "PREAMBLE5 = @preamble5," +
                    "PREAMBLE6 = @preamble6," +
                    "PREAMBLE7 = @preamble7," +
                    "PREAMBLE8 = @preamble8," +
                    "PREAMBLE9 = @preamble9," +
                    "PREAMBLE10 = @preamble10," +

                    "P1_BEFORE = @p1_before," +
                    "P1_AFTER = @p1_after," +
                    "P2_BEFORE = @p2_before," +
                    "P2_AFTER = @p2_after," +
                    "P3_BEFORE = @p3_before," +
                    "P3_AFTER = @p3_after," +
                    "P4_BEFORE = @p4_before," +
                    "P4_AFTER = @p4_after," +

                    "P5_BEFORE = @p5_before," +
                    "P5_AFTER = @p5_after," +
                    "P6_BEFORE = @p6_before," +
                    "P6_AFTER = @p6_after," +
                    "P7_BEFORE = @p7_before," +
                    "P7_AFTER = @p7_after," +
                    "P8_BEFORE = @p8_before," +
                    "P8_AFTER = @p8_after," +
                    "P9_BEFORE = @p9_before," +
                    "P9_AFTER = @p9_after," +
                    "P10_BEFORE = @p10_before," +
                    "P10_AFTER = @p10_after," +


                    " WHERE [ID] = @id";

                OleDbCommand cmd = new OleDbCommand(strUpdate, conn);

                cmd.Parameters.AddWithValue("@lesson_name", txtScriptName.Text);
                cmd.Parameters.AddWithValue("@date_edited", GetDateString(DateTime.Now));
                int itemCount = listScript.Items.Count;
                int iItem = -1;
                for (int i = 0; i < 30; i++) {
                    if (i < itemCount) {
                        string sItem = (string)listScript.Items[i];
                        sItem = sItem.Substring(0, sItem.IndexOf("-"));
                        iItem = int.Parse(sItem);
                    } else {
                        iItem = -1;
                    }
                    cmd.Parameters.AddWithValue("@spot" + (i + 1), iItem);
                }
                cmd.Parameters.AddWithValue("@preamble1", Get_Selected_Key(cboPreamble1));
                cmd.Parameters.AddWithValue("@preamble2", Get_Selected_Key(cboPreamble2));
                cmd.Parameters.AddWithValue("@preamble3", Get_Selected_Key(cboPreamble3));
                cmd.Parameters.AddWithValue("@preamble4", Get_Selected_Key(cboPreamble4));
                cmd.Parameters.AddWithValue("@preamble5", Get_Selected_Key(cboPreamble5));
                cmd.Parameters.AddWithValue("@preamble6", Get_Selected_Key(cboPreamble6));
                cmd.Parameters.AddWithValue("@preamble7", Get_Selected_Key(cboPreamble7));
                cmd.Parameters.AddWithValue("@preamble8", Get_Selected_Key(cboPreamble8));
                cmd.Parameters.AddWithValue("@preamble9", Get_Selected_Key(cboPreamble9));
                cmd.Parameters.AddWithValue("@preamble10", Get_Selected_Key(cboPreamble10));
                if (chk1PlaceBefore.Checked) {
                    cmd.Parameters.AddWithValue("@p1_before", 1);
                } else {
                    cmd.Parameters.AddWithValue("@p1_before", 0);
                }
                if (chk1PlaceAfter.Checked) {
                    cmd.Parameters.AddWithValue("@p1_after", 1);
                } else {
                    cmd.Parameters.AddWithValue("@p1_after", 0);
                }

                if (chk2PlaceBefore.Checked) {
                    cmd.Parameters.AddWithValue("@p2_before", 1);
                } else {
                    cmd.Parameters.AddWithValue("@p2_before", 0);
                }
                if (chk2PlaceAfter.Checked) {
                    cmd.Parameters.AddWithValue("@p2_after", 1);
                } else {
                    cmd.Parameters.AddWithValue("@p2_after", 0);
                }

                if (chk3PlaceBefore.Checked) {
                    cmd.Parameters.AddWithValue("@p3_before", 1);
                } else {
                    cmd.Parameters.AddWithValue("@p3_before", 0);
                }
                if (chk3PlaceAfter.Checked) {
                    cmd.Parameters.AddWithValue("@p3_after", 1);
                } else {
                    cmd.Parameters.AddWithValue("@p3_after", 0);
                }

                if (chk4PlaceBefore.Checked) {
                    cmd.Parameters.AddWithValue("@p4_before", 1);
                } else {
                    cmd.Parameters.AddWithValue("@p4_before", 0);
                }
                if (chk4PlaceAfter.Checked) {
                    cmd.Parameters.AddWithValue("@p4_after", 1);
                } else {
                    cmd.Parameters.AddWithValue("@p4_after", 0);
                }

                if (chk5PlaceBefore.Checked) {
                    cmd.Parameters.AddWithValue("@p5_before", 1);
                } else {
                    cmd.Parameters.AddWithValue("@p5_before", 0);
                }
                if (chk5PlaceAfter.Checked) {
                    cmd.Parameters.AddWithValue("@p5_after", 1);
                } else {
                    cmd.Parameters.AddWithValue("@p5_after", 0);
                }

                if (chk6PlaceBefore.Checked) {
                    cmd.Parameters.AddWithValue("@p6_before", 1);
                } else {
                    cmd.Parameters.AddWithValue("@p6_before", 0);
                }
                if (chk6PlaceAfter.Checked) {
                    cmd.Parameters.AddWithValue("@p6_after", 1);
                } else {
                    cmd.Parameters.AddWithValue("@p6_after", 0);
                }

                if (chk7PlaceBefore.Checked) {
                    cmd.Parameters.AddWithValue("@p7_before", 1);
                } else {
                    cmd.Parameters.AddWithValue("@p7_before", 0);
                }
                if (chk7PlaceAfter.Checked) {
                    cmd.Parameters.AddWithValue("@p7_after", 1);
                } else {
                    cmd.Parameters.AddWithValue("@p7_after", 0);
                }

                if (chk8PlaceBefore.Checked) {
                    cmd.Parameters.AddWithValue("@p8_before", 1);
                } else {
                    cmd.Parameters.AddWithValue("@p8_before", 0);
                }
                if (chk8PlaceAfter.Checked) {
                    cmd.Parameters.AddWithValue("@p8_after", 1);
                } else {
                    cmd.Parameters.AddWithValue("@p8_after", 0);
                }

                if (chk9PlaceBefore.Checked) {
                    cmd.Parameters.AddWithValue("@p9_before", 1);
                } else {
                    cmd.Parameters.AddWithValue("@p9_before", 0);
                }
                if (chk9PlaceAfter.Checked) {
                    cmd.Parameters.AddWithValue("@p9_after", 1);
                } else {
                    cmd.Parameters.AddWithValue("@p9_after", 0);
                }

                if (chk10PlaceBefore.Checked) {
                    cmd.Parameters.AddWithValue("@p10_before", 1);
                } else {
                    cmd.Parameters.AddWithValue("@p10_before", 0);
                }
                if (chk10PlaceAfter.Checked) {
                    cmd.Parameters.AddWithValue("@p10_after", 1);
                } else {
                    cmd.Parameters.AddWithValue("@p10_after", 0);
                }



                cmd.Parameters.AddWithValue("@id", Get_Selected_Key(cboScripts));

                conn.Open();
                int iRows = cmd.ExecuteNonQuery();
                conn.Close();

                Clear_Entries();
                Fill_CBOs(cboScripts, "SELECT ID, CURRICULUM_NAME FROM Curriculum ORDER BY ID");
            }
        }

        private string GetDateString(DateTime d) {
            object value = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
            DateTime result = (DateTime)value;
            string sResult = result.ToString("M/d/yyyy HHmm");
            return sResult;
        }

        private void Fill_CBOs(ComboBox cbo, string query) {
            try {
                string sCommand = query;
                conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
                DataTable dt = new DataTable();
                dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dAdapter.Fill(dt);
                conn.Close();

                // Create a List to store our KeyValuePairs and add data
                List<KeyValuePair<int, string>> data = new List<KeyValuePair<int, string>>();
                data.Add(new KeyValuePair<int, string>(-1, ""));
                for (int i = 0; i <= dt.Rows.Count - 1; i++) {
                    data.Add(new KeyValuePair<int, string>((int)dt.Rows[i].ItemArray[0], (string)dt.Rows[i].ItemArray[1]));
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

        private void Delete_Entry() {
            try {
                int iSelected = Get_Selected_Key(cboScripts);
                if (iSelected > -1) {
                    DialogResult result = MessageBox.Show(
                        "Deleting the selected entry will permanetly eliminate it from the database.  Are you sure that you would like to DELETE?",
                        "DELETE SELECTED RECORD?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes) {
                        string sQuery = "DELETE FROM Curriculum WHERE ID=" + Get_Selected_Key(cboScripts);
                        conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
                        conn.Open();
                        OleDbCommand commandBuilder = new OleDbCommand(sQuery, conn);
                        commandBuilder.ExecuteNonQuery();
                        conn.Close();

                        Clear_Entries();
                        Fill_CBOs(cboScripts, "SELECT ID, CURRICULUM_NAME FROM Curriculum ORDER BY ID");
                    }
                }
            } catch (Exception) {
                throw;
            }
        }
        private void Clear_Entries() {
            try {
                cboScripts.SelectedIndex = 0;
                txtScriptName.Text = "";
                cboPreamble1.SelectedIndex = 0;
                cboPreamble2.SelectedIndex = 0;
                cboPreamble3.SelectedIndex = 0;
                cboPreamble4.SelectedIndex = 0;
                cboPreamble5.SelectedIndex = 0;
                cboPreamble6.SelectedIndex = 0;
                cboPreamble7.SelectedIndex = 0;
                cboPreamble8.SelectedIndex = 0;
                cboPreamble9.SelectedIndex = 0;
                cboPreamble10.SelectedIndex = 0;

                chk1PlaceBefore.Checked = false;
                chk1PlaceAfter.Checked = false;
                chk2PlaceBefore.Checked = false;
                chk2PlaceAfter.Checked = false;
                chk3PlaceBefore.Checked = false;
                chk3PlaceAfter.Checked = false;
                chk4PlaceBefore.Checked = false;
                chk4PlaceAfter.Checked = false;
                chk5PlaceBefore.Checked = false;
                chk5PlaceAfter.Checked = false;
                chk6PlaceBefore.Checked = false;
                chk6PlaceAfter.Checked = false;
                chk7PlaceBefore.Checked = false;
                chk7PlaceAfter.Checked = false;
                chk8PlaceBefore.Checked = false;
                chk8PlaceAfter.Checked = false;
                chk9PlaceBefore.Checked = false;
                chk9PlaceAfter.Checked = false;
                chk10PlaceBefore.Checked = false;
                chk10PlaceAfter.Checked = false;

                btnGenerateScript.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
            } catch (Exception) {
                throw;
            }
        }

        private void btnGenerateScript_Click(object sender, EventArgs e) {
            GenerateLessonPDF();
        }

        private void cboScripts_SelectedIndexChanged(object sender, EventArgs e) {
            FillData();
        }

        private void btnPreamble_Click(object sender, EventArgs e) {
            frmBuildPreamble frmBuildPreamble = new frmBuildPreamble();
            frmBuildPreamble.ShowDialog();

            // save ID of selected item (NOT the selectedindex)
            Fill_CBOs(cboPreamble1, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble2, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble3, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble4, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble5, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble6, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble7, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble8, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble9, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble10, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");

            FillData();
        }

        private void btnGenerateScript_Click_1(object sender, EventArgs e) {
            GenerateLessonPDF();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            AddDataRow();
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            Update();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            Delete_Entry();
        }

        private void btnClear_Click(object sender, EventArgs e) {
            Clear_Entries();
        }
    }
}
