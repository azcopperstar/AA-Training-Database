using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    public partial class frmBuilderLesson : Form {
        public frmBuilderLesson() {
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

        private void frmDeveloper_Load(object sender, EventArgs e) {
            this.Text = GlobalCode.sCARRIER + " " + GlobalCode.sFleet + this.Text;
            //btnGenerateScript.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            Initialize_DB();
            Fill_listbox();
            Fill_CBOs(cboScripts, "SELECT ID, LESSON_NAME FROM Lesson ORDER BY LESSON_NAME");
            Fill_CBOs(cboPreamble1, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble2, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble3, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble4, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
        }
        private void Initialize_DB() {
            string sQuery = "SELECT * FROM Lesson";
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
            string selectCommand = "SELECT ID,SPOT_NAME,MINUTES FROM Spots";
            OleDbCommand comm = new OleDbCommand(selectCommand, conn);
            OleDbDataReader reader = comm.ExecuteReader();

            int iCount = 0;
            while (reader.Read()) {
                iCount++;
                string sMinutes = reader.GetValue(2).ToString();
                if (sMinutes == "")
                    sMinutes = "0";
                int iMinutes = int.Parse(sMinutes);
                if (iMinutes < 10) {
                    sMinutes = ":0" + Convert.ToString(iMinutes);
                } else {
                    sMinutes = ":" + Convert.ToString(iMinutes);
                }
                this.listManeuvers.Items.Add(reader.GetValue(0).ToString() + "- (" + sMinutes + ") " + reader.GetValue(1).ToString());
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
            TotalTime();
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
            TotalTime();
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

        private void TotalTime() {
            // get minutes for grid
            int iMinutes = 0;
            int itemCount = listScript.Items.Count;
            for (int i = 0; i < itemCount; i++) {
                string sItem = (string)listScript.Items[i];
                sItem = sItem.Substring(sItem.IndexOf(":")+1, 2);
                int iItem = int.Parse(sItem);
                iMinutes = iMinutes + iItem;
            }
            TimeSpan span = TimeSpan.FromMinutes(iMinutes);
            string sTime = span.ToString(@"hh\:mm");
            lblTime.Text = "TOTAL TIME: " + sTime;
            //string sTime = Format(Floor(iMinutes) / 60), "00") + ":" + Format(iMinutes) Mod 60, "00")
        }

        private void btnGenerateScript_Click(object sender, EventArgs e) {
            GenerateLessonPDF();
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
                string sCommand = "SELECT * FROM Lesson WHERE ID = " + iSelected;
                conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
                DataTable dt = new DataTable();
                dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dAdapter.Fill(dt);
                conn.Close();

                this.listScript.Items.Clear();
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++) {

                    txtScriptName.Text = (string)dt.Rows[i].ItemArray[1];

                    // set the preambles
                    if ((int)dt.Rows[i]["PREAMBLE1"] > 0)
                        Set_Selected_CBO(cboPreamble1, (int)dt.Rows[i]["PREAMBLE1"]);
                    if ((int)dt.Rows[i]["P1_BEFORE"] == 1)
                        chk1PlaceBefore.Checked=true;
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




                    for (int x = 4; x <= 33; x++) {
                        int ispot = (int)dt.Rows[i].ItemArray[x];
                        if (ispot > -1) {
                            //DataTable dtReport = new DataTable();
                            //OleDbConnection conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
                            conn.Open();
                            string selectCommand = "SELECT ID,SPOT_NAME,MINUTES FROM Spots WHERE ID = " + ispot;
                            OleDbCommand comm = new OleDbCommand(selectCommand, conn);
                            OleDbDataReader reader = comm.ExecuteReader();
                            while (reader.Read()) {
                                string sMinutes = reader.GetValue(2).ToString();
                                if (sMinutes == "")
                                    sMinutes = "0";
                                int iMinutes = int.Parse(sMinutes);
                                if (iMinutes < 10) {
                                    sMinutes = ":0" + Convert.ToString(iMinutes);
                                } else {
                                    sMinutes = ":" + Convert.ToString(iMinutes);
                                }
                                this.listScript.Items.Add(reader.GetValue(0).ToString() + "- (" + sMinutes + ") " + reader.GetValue(1).ToString());
                            }
                            reader.Close();
                            conn.Close();
                        }
                        TotalTime();
                    }
                }
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = true;
            } else {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        private void cboScripts_SelectedIndexChanged(object sender, EventArgs e) {
            FillData();
        }

        private void txtScriptName_TextChanged(object sender, EventArgs e) {
            if (listScript.Items.Count > 0 && txtScriptName.Text != "") {
                btnSave.Enabled = true;
            } else {
                btnSave.Enabled = false;
            }
        }



        private void GenerateLessonPDF() {

            int iSelected = Get_Selected_Key(cboScripts);
            if (cboScripts.SelectedIndex > 0 || iSelected > -1) {

                // save the lesson ID to list
                List<int> iLessonList1 = new List<int>();
                iLessonList1.Add(iSelected);
                GlobalCode.iLessonList = iLessonList1.ToArray();


                string sCommand = "SELECT * FROM Lesson WHERE ID = " + iSelected;
                conn.Open();
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
                DataTable dt = new DataTable();
                dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dAdapter.Fill(dt);
                conn.Close();

                // cycle thru lesson list for all spots
                List<int> iSPOTList1 = new List<int>();
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++) {
                    for (int x = 4; x <= 33; x++) {
                        int ispot = (int)dt.Rows[i].ItemArray[x];
                        if (ispot > -1) {
                            iSPOTList1.Add(ispot);
                        }
                    }
                    GlobalCode.iSPOTList = iSPOTList1.ToArray();
                }

                //AbcPDF.Generate_PDF();
                //PDF.Generate_PDF();

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

        private void btnUpdate_Click(object sender, EventArgs e) {
            //int iLessonID = (cboScripts.SelectedItem as dynamic).Value;
            if (Get_Selected_Key(cboScripts) > -1) {
                string strUpdate = "UPDATE Lesson SET " +
                    "LESSON_NAME = @lesson_name," +
                    "DATE_EDITED = @date_edited," +
                    "LESSON_PREAMBLE_TITLE_1 = @lpt1," +
                    "LESSON_PREAMBLE_TEXT_1 = @lpt1a," +
                    "LESSON_PREAMBLE_TITLE_2 = @lpt2," +
                    "LESSON_PREAMBLE_TEXT_2 = @lpt2a," +
                    "LESSON_PREAMBLE_TITLE_3 = @lpt3," +
                    "LESSON_PREAMBLE_TEXT_3 = @lpt3a," +
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
                    "P1_BEFORE = @p1_before," +
                    "P1_AFTER = @p1_after," +
                    "P2_BEFORE = @p2_before," +
                    "P2_AFTER = @p2_after," +
                    "P3_BEFORE = @p3_before," +
                    "P3_AFTER = @p3_after," +
                    "P4_BEFORE = @p4_before," +
                    "P4_AFTER = @p4_after," +

                    "A1 = @a1," +
                    "A2 = @a2," +
                    "A3 = @a3," +
                    "A4 = @a4," +
                    "A5 = @a5," +
                    "A6 = @a6," +
                    "A7 = @a7," +
                    "A8 = @a8," +
                    "A9 = @a9," +
                    "A10 = @a10" +

                    " WHERE [ID] = @id";

                OleDbCommand cmd = new OleDbCommand(strUpdate, conn);

                cmd.Parameters.AddWithValue("@lesson_name", txtScriptName.Text);
                cmd.Parameters.AddWithValue("@date_edited", GetDateString(DateTime.Now));
                cmd.Parameters.AddWithValue("@lpt1", "");
                cmd.Parameters.AddWithValue("@lpt1a", "");
                cmd.Parameters.AddWithValue("@lpt2", "");
                cmd.Parameters.AddWithValue("@lpt2a", "");
                cmd.Parameters.AddWithValue("@lpt3", "");
                cmd.Parameters.AddWithValue("@lpt3a", "");
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

                // additional fields
                for (int x = 1; x < 11; x++) {
                    cmd.Parameters.AddWithValue("@a" + x, "");
                }

                cmd.Parameters.AddWithValue("@id", Get_Selected_Key(cboScripts));

                conn.Open();
                int iRows = cmd.ExecuteNonQuery();
                conn.Close();

                Clear_Entries();
                Fill_CBOs(cboScripts, "SELECT ID, LESSON_NAME FROM Lesson ORDER BY LESSON_NAME");
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            AddDataRow();
        }

        private void AddDataRow() {
            System.Data.DataRow dr = dtTable.NewRow();

            dr["LESSON_NAME"] = txtScriptName.Text;
            dr["DATE_CREATED"] = GetDateString(DateTime.Now);
            dr["DATE_EDITED"] = GetDateString(DateTime.Now);

            dr["LESSON_PREAMBLE_TITLE_1"] = "";
            dr["LESSON_PREAMBLE_TEXT_1"] = "";
            dr["LESSON_PREAMBLE_TITLE_2"] = "";
            dr["LESSON_PREAMBLE_TEXT_2"] = "";
            dr["LESSON_PREAMBLE_TITLE_3"] = "";
            dr["LESSON_PREAMBLE_TEXT_3"] = "";

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

            // additional fields
            for (int x = 1; x < 11; x++) {
                dr["A" + x] = "";
            }


            dtTable.Rows.Add(dr);
            dataAdapter.Update(dtTable);  // write new row back to database

            Clear_Entries();
            Fill_CBOs(cboScripts, "SELECT ID, LESSON_NAME FROM Lesson ORDER BY LESSON_NAME");
        }

        private string GetDateString(DateTime d) {
            object value = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
            DateTime result = (DateTime)value;
            string sResult = result.ToString("M/d/yyyy HHmm");
            return sResult;
        }

        //private void Fill_Scripts() {
        //    string sCommand = "SELECT * FROM Lesson";
        //    conn.Open();
        //    OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
        //    DataTable dt = new DataTable();
        //    dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
        //    dAdapter.Fill(dt);
        //    conn.Close();

        //    cboScripts.Items.Clear();
        //    cboScripts.DisplayMember = "Text";
        //    cboScripts.ValueMember = "Value";
        //    int i;
        //    cboScripts.Items.Add(new {
        //        Value = -1, Text = ""
        //    });
        //    for (i = 0; i <= dt.Rows.Count - 1; i++) {
        //        cboScripts.Items.Add(new {
        //            Value = dt.Rows[i].ItemArray[0], Text = dt.Rows[i].ItemArray[1]
        //        });
        //    }
        //}
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

        private void btnDelete_Click(object sender, EventArgs e) {
            Delete_Entry();
        }
        private void Delete_Entry() {
            try {
                int iSelected = Get_Selected_Key(cboScripts);
                if (iSelected > -1) {
                    // search for use of this item in any existing spot
                    string sCommand = "SELECT * FROM Curriculum " +
                        "WHERE LESSON1 = " + iSelected +
                        " OR LESSON2 = " + iSelected +
                        " OR LESSON3 = " + iSelected +
                        " OR LESSON4 = " + iSelected +
                        " OR LESSON5 = " + iSelected +
                        " OR LESSON6 = " + iSelected +
                        " OR LESSON7 = " + iSelected +
                        " OR LESSON8 = " + iSelected +
                        " OR LESSON9 = " + iSelected +
                        " OR LESSON10 = " + iSelected +
                        " OR LESSON11 = " + iSelected +
                        " OR LESSON12 = " + iSelected +
                        " OR LESSON13 = " + iSelected +
                        " OR LESSON14 = " + iSelected +
                        " OR LESSON15 = " + iSelected +
                        " OR LESSON16 = " + iSelected +
                        " OR LESSON17 = " + iSelected +
                        " OR LESSON18 = " + iSelected +
                        " OR LESSON19 = " + iSelected +
                        " OR LESSON20 = " + iSelected +
                        " OR LESSON21 = " + iSelected +
                        " OR LESSON22 = " + iSelected +
                        " OR LESSON23 = " + iSelected +
                        " OR LESSON24 = " + iSelected +
                        " OR LESSON25 = " + iSelected +
                        " OR LESSON26 = " + iSelected +
                        " OR LESSON27 = " + iSelected +
                        " OR LESSON28 = " + iSelected +
                        " OR LESSON29 = " + iSelected +
                        " OR LESSON30 = " + iSelected;
                    OleDbConnection conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
                    conn.Open();
                    OleDbCommand comm = new OleDbCommand(sCommand, conn);
                    OleDbDataReader reader = comm.ExecuteReader();
                    int iCount = 0;
                    string sSpots = "";
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            iCount++;
                            if (sSpots != "") {
                                sSpots = sSpots + ", " + reader.GetValue(0).ToString();
                            } else {
                                sSpots = reader.GetValue(0).ToString();
                            }
                        }
                        MessageBox.Show(
                            "The LESSON selected can not be deleted. It is used in the following " + iCount + " CURRICULUMS: " + sSpots,
                            "UNABLE TO DELETE LESSON",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                    reader.Close();
                    conn.Close();

                    DialogResult result = MessageBox.Show(
                        "Deleting the selected entry will permanetly eliminate it from the database.  Are you sure that you would like to DELETE?",
                        "DELETE SELECTED RECORD?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes) {
                        string sQuery = "DELETE FROM Lesson WHERE ID=" + Get_Selected_Key(cboScripts);
                        conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
                        conn.Open();
                        OleDbCommand commandBuilder = new OleDbCommand(sQuery, conn);
                        commandBuilder.ExecuteNonQuery();
                        conn.Close();
                        Clear_Entries();
                        Fill_CBOs(cboScripts, "SELECT ID, LESSON_NAME FROM Lesson ORDER BY LESSON_NAME");
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
                chk1PlaceBefore.Checked = false;
                chk1PlaceAfter.Checked = false;
                chk2PlaceBefore.Checked = false;
                chk2PlaceAfter.Checked = false;
                chk3PlaceBefore.Checked = false;
                chk3PlaceAfter.Checked = false;
                chk4PlaceBefore.Checked = false;
                chk4PlaceAfter.Checked = false;
                listScript.Items.Clear();
                
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
            } catch (Exception) {
                throw;
            }
        }

        private void cboPreamble1_SelectedIndexChanged(object sender, EventArgs e) {
            chk1PlaceBefore.Checked = false;
            chk1PlaceAfter.Checked = false;
            if (cboPreamble1.SelectedIndex > 0)
                chk1PlaceBefore.Checked = true;
        }
        private void cboPreamble2_SelectedIndexChanged(object sender, EventArgs e) {
            chk2PlaceBefore.Checked = false;
            chk2PlaceAfter.Checked = false;
            if (cboPreamble2.SelectedIndex > 0)
                chk2PlaceBefore.Checked = true;
        }
        private void cboPreamble3_SelectedIndexChanged(object sender, EventArgs e) {
            chk3PlaceBefore.Checked = false;
            chk3PlaceAfter.Checked = false;
            if (cboPreamble3.SelectedIndex > 0)
                chk3PlaceBefore.Checked = true;
        }
        private void cboPreamble4_SelectedIndexChanged(object sender, EventArgs e) {
            chk4PlaceBefore.Checked = false;
            chk4PlaceAfter.Checked = false;
            if (cboPreamble4.SelectedIndex > 0)
                chk4PlaceBefore.Checked = true;
        }

        private void btnPreamble_Click(object sender, EventArgs e) {
            frmBuildPreamble frmBuildPreamble = new frmBuildPreamble();
            frmBuildPreamble.ShowDialog();

            // save ID of selected item (NOT the selectedindex)
            Fill_CBOs(cboPreamble1, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble2, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble3, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            Fill_CBOs(cboPreamble4, "SELECT ID, P_NAME FROM Preamble ORDER BY P_NAME");
            FillData();

        }


        //private DataTable Data(int[] numbers, DataTable dtReport) {
        //    //DataTable dtReport = new DataTable();
        //    dtReport = CreateColumns(dtReport);

        //    conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
        //    conn.Open();
        //    int iCount = 0;
        //    foreach (int i in numbers) {
        //        iCount++;
        //        DataTable dtLoop = new DataTable();
        //        if (iCount == 1) {
        //            //                    dataAdapter.Fill(dtReport);
        //        } else {
        //            //dataAdapter.Fill(dtLoop);
        //            dtReport.Rows.Add(FillRow(dtReport, i));

        //            //foreach (DataRow drtableOld in dtLoop.Rows) {
        //            //    dtReport.ImportRow(drtableOld);
        //            //}
        //        }
        //    }
        //    conn.Close();
        //    return dtReport;
        //}
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
