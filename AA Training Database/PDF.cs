using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using itextsharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using iTextSharp.text.pdf.draw;
using iTextSharp.tool.xml;
using System.Drawing.Imaging;
using System.Data.OleDb;

namespace WindowsFormsApplication1 {


    class PDF {


        // document title (this will need to be set in the app prefs)
        public static string sDocTitle = GlobalCode.sFleet + " I/E TRAINING GUIDE";
        public static string sDocSection = "";

        public static string sVersionMajor = "1";
        public static string sVersionMinor = "0";
        public static string sEdition = sVersionMajor + "." + sVersionMinor;

        // create fonts and colors
        public static int iNormalFontSize = 10;
        public static int iATISFontSize = 11;
        public static int iFMCFontSize = 12;

        //static string strPath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);


        public static string sFont_Fixed_Width = "Lucida Fax";

        //static BaseFont f_cb = BaseFont.CreateFont("c:\\windows\\fonts\\arial.ttf", BaseFont.CP1252, BaseFont.EMBEDDED);
        //static BaseFont f_Fixed_Width = BaseFont.CreateFont("c:\\windows\\fonts\\lucon.ttf", BaseFont.CP1252, BaseFont.EMBEDDED);
        public static BaseColor color_White = BaseColor.WHITE;
        public static BaseColor color_Black = BaseColor.BLACK;
        public static BaseColor color_Red = BaseColor.RED;
        public static BaseColor color_Green = BaseColor.GREEN;
        public static BaseColor color_DarkGreen = new BaseColor(48, 128, 20);
        public static BaseColor color_Blue = BaseColor.BLUE;
        public static BaseColor color_DarkBlue = new BaseColor(0, 178, 238);
        public static BaseColor color_Cyan = BaseColor.CYAN;
        public static BaseColor color_Maroon = new BaseColor(128,0,0);
        public static BaseColor color_Yellow = new BaseColor(255, 255, 0);

        public static BaseColor background_grey = new BaseColor(190, 190, 190);
        public static BaseColor background_white = new BaseColor(255, 255, 255);
        public static BaseColor background_gold = new BaseColor(255, 210, 48);
        public static BaseColor background_breakgreen = new BaseColor(144, 238, 144);

        public static BaseColor color_grid_blue = new BaseColor(0, 0, 200);
        public static BaseColor color_grid_violet = new BaseColor(113, 113, 198);
        public static BaseColor color_grid_purple = new BaseColor(138, 43, 226);
        public static BaseColor color_grid_ltblue = new BaseColor(202, 225, 255);
        public static BaseColor color_grid_goldenrod = new BaseColor(255, 193, 37);

        public static BaseColor color_pf_a = new BaseColor(0, 0, 200);
        public static BaseColor color_pf_b = new BaseColor(138, 43, 226);
        public static BaseColor color_pf_both = new BaseColor(202, 225, 255);
        public static BaseColor color_pf_either = new BaseColor(255, 228, 196);

        public static BaseFont customfont = BaseFont.CreateFont("c:\\windows\\fonts\\consola.ttf", BaseFont.CP1252, BaseFont.EMBEDDED);
        public static iTextSharp.text.Font font_Title_Green = new iTextSharp.text.Font(customfont, iFMCFontSize, iTextSharp.text.Font.NORMAL, color_Green);
        public static iTextSharp.text.Font font_Title_Cyan = new iTextSharp.text.Font(customfont, iFMCFontSize, iTextSharp.text.Font.NORMAL, color_Cyan);
        public static iTextSharp.text.Font font_Title_White = new iTextSharp.text.Font(customfont, iFMCFontSize, iTextSharp.text.Font.NORMAL, color_White);
        public static iTextSharp.text.Font font_Title_White_small = new iTextSharp.text.Font(customfont, 9, iTextSharp.text.Font.NORMAL, color_White);
        public static iTextSharp.text.Font font_Units_Blue = new iTextSharp.text.Font(customfont, iNormalFontSize, iTextSharp.text.Font.NORMAL, color_DarkBlue);
        public static iTextSharp.text.Font font_Data_Maroon = new iTextSharp.text.Font(customfont, iATISFontSize, iTextSharp.text.Font.BOLD, color_Maroon);

        public static BaseFont fontNormal = BaseFont.CreateFont("c:\\windows\\fonts\\arial.ttf", BaseFont.CP1252, BaseFont.EMBEDDED);
        public static iTextSharp.text.Font font_Normal_Bold_Black = new iTextSharp.text.Font(fontNormal, iFMCFontSize, iTextSharp.text.Font.BOLD, color_Black);
        public static iTextSharp.text.Font font_Normal_Black = new iTextSharp.text.Font(fontNormal, iFMCFontSize, iTextSharp.text.Font.NORMAL, color_Black);
        public static iTextSharp.text.Font font_Normal_Bold_Maroon = new iTextSharp.text.Font(fontNormal, iFMCFontSize, iTextSharp.text.Font.BOLD, color_Maroon);
        public static iTextSharp.text.Font font_Bold_Maroon_14 = new iTextSharp.text.Font(fontNormal, 14, iTextSharp.text.Font.BOLD, color_Maroon);
        public static iTextSharp.text.Font font_Normal_Maroon = new iTextSharp.text.Font(fontNormal, iFMCFontSize, iTextSharp.text.Font.NORMAL, color_Maroon);

        public static iTextSharp.text.Font font_TOC_Bold_Black = new iTextSharp.text.Font(fontNormal, iNormalFontSize, iTextSharp.text.Font.BOLD, color_Black);
        public static iTextSharp.text.Font font_TOC_Black = new iTextSharp.text.Font(fontNormal, iNormalFontSize, iTextSharp.text.Font.NORMAL, color_Black);

        public static iTextSharp.text.Font font_Spot_Bold_Maroon = new iTextSharp.text.Font(fontNormal, 17, iTextSharp.text.Font.BOLD, color_Maroon);
        public static iTextSharp.text.Font font_SpotNum_Bold_Maroon = new iTextSharp.text.Font(fontNormal, 22, iTextSharp.text.Font.BOLD, color_Maroon);

        public static int iPageNumber = 0;

        public static PdfOutline olRoot = null;
        public static PdfOutline olDocTitle = null;
        public static PdfOutline olLessonSPOTS =null;

        public static bool bHeaderFooter = true;
        public static bool bFooterPgNums = true;   

        private static void Create_Title_Page(iTextSharp.text.Rectangle pdfPage, Document pdfDocument, PdfWriter pdfWriter,string sTitle) {

            // turn off header and footer
            bHeaderFooter = false;

            // change background
            pdfPage.BackgroundColor = background_grey;

            Chunk chunk = new Chunk("");
            Paragraph pgTitle = new Paragraph(chunk);

            chunk = new Chunk("\n"+sTitle);
            pgTitle = new Paragraph(chunk);
            pgTitle.Font.SetFamily("Arial");
            pgTitle.Font.SetStyle("bold");
            pgTitle.Font.Size = 26;
            pgTitle.Font.Color = color_Maroon;
            pgTitle.Alignment = Element.ALIGN_CENTER;
            pdfDocument.Add(pgTitle);

            chunk = new Chunk("\nQUAL / CQ / R1S / REQ");
            pgTitle = new Paragraph(chunk);
            pgTitle.Font.SetFamily("Arial");
            pgTitle.Font.SetStyle("bold");
            pgTitle.Font.Size = 18;
            pgTitle.Font.Color = color_Black;
            pgTitle.Alignment = Element.ALIGN_CENTER;
            pdfDocument.Add(pgTitle);

            iTextSharp.text.Image png = null;
            if (GlobalCode.sPATH_IMAGE_PDF != "" && File.Exists(GlobalCode.sPATH_IMAGE_PDF)) {
                // use selected image on cover
                System.Drawing.Image test = System.Drawing.Image.FromFile(GlobalCode.sPATH_IMAGE_PDF);
                png = iTextSharp.text.Image.GetInstance(test, System.Drawing.Imaging.ImageFormat.Png);
                //png.ScalePercent(10f);
            } else {
                //// use resource
                //System.Drawing.Image test = System.Drawing.Image.FromHbitmap(Properties.Resources.A350.GetHbitmap());
                //png = iTextSharp.text.Image.GetInstance(test, System.Drawing.Imaging.ImageFormat.Png);
                ////png.ScalePercent(5f);

            }
            if (png.Height > png.Width) {
                //Maximum height is 800 pixels.
                float percentage = 0.0f;
                percentage = 800 / png.Height;
                png.ScalePercent(percentage * 100);
            } else {
                //Maximum width is 600 pixels.
                float percentage = 0.0f;
                percentage = 600 / png.Width;
                png.ScalePercent(percentage * 100);
            }
            png.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            png.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
            pdfDocument.Add(png);
            // insert image
            //using (FileStream fs = new FileStream(strPath + "\\a350.png", FileMode.Open)) {
            //    iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromStream(fs), ImageFormat.Png);
            //    png.ScalePercent(30f);
            //    png.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            //    png.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
            //    pdfDocument.Add(png);
            //}

            chunk = new Chunk("\n\nEDITION " + sEdition);
            pgTitle = new Paragraph(chunk);
            pgTitle.Font.SetFamily("Arial");
            pgTitle.Font.SetStyle("bold");
            pgTitle.Font.Size = 16;
            pgTitle.Font.Color = color_Black;
            pgTitle.Alignment = Element.ALIGN_CENTER;
            pdfDocument.Add(pgTitle);
            
            // new pdfPage
            pdfDocument.NewPage();
            pdfPage.BackgroundColor = background_white;


            //// include 2nd page from external
            //PdfReader reader = new PdfReader(Properties.Resources.page2); // GlobalCode.sPDFOutputPath + "\\page2.pdf"
            //int iPages = reader.NumberOfPages;
            //PdfImportedPage imPage;
            //for (int i = 1; i <= iPages; i++) {
            //    imPage = pdfWriter.GetImportedPage(reader, i);
            //    pdfDocument.Add(iTextSharp.text.Image.GetInstance(imPage));
            //}

            //// new pdfPage
            //pdfDocument.NewPage();

            // turn onn header and footer
            bHeaderFooter = true;
        }

        private static void Print_Preamble(Document pdfDocument, PdfWriter pdfWriter, int iPID, Chunk chunkTOC) {

            string sLessonPreambleTitle = "";
            string sLessonPreambleTitle1 = "";
            string sLessonPreambleText1 = "";
            string sLessonPreambleTitle2 = "";
            string sLessonPreambleText2 = "";
            string sLessonPreambleTitle3 = "";
            string sLessonPreambleText3 = "";
            string sLessonPreamblePath = "";
            //int iCountx = 0;

            OleDbConnection conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
            conn.Open();
            OleDbCommand command = new OleDbCommand("SELECT * FROM Preamble WHERE ID=" + iPID, conn);
            using (OleDbDataReader reader1 = command.ExecuteReader()) {
                while (reader1.Read()) {
                    sLessonPreambleTitle = reader1.GetValue(reader1.GetOrdinal("P_NAME")).ToString();
                    sLessonPreambleTitle1 = reader1.GetValue(reader1.GetOrdinal("TITLE1")).ToString();
                    sLessonPreambleText1 = reader1.GetValue(reader1.GetOrdinal("BODY1")).ToString();
                    sLessonPreambleTitle2 = reader1.GetValue(reader1.GetOrdinal("TITLE2")).ToString();
                    sLessonPreambleText2 = reader1.GetValue(reader1.GetOrdinal("BODY2")).ToString();
                    sLessonPreambleTitle3 = reader1.GetValue(reader1.GetOrdinal("TITLE3")).ToString();
                    sLessonPreambleText3 = reader1.GetValue(reader1.GetOrdinal("BODY3")).ToString();
                    sLessonPreamblePath = reader1.GetValue(reader1.GetOrdinal("P_PATH")).ToString();
                }
            }
            conn.Close();

            chunkTOC = new Chunk(sLessonPreambleTitle, font_Bold_Maroon_14);
            chunkTOC.SetGenericTag(sLessonPreambleTitle);
            // set lesson section for footer
            sDocSection = sLessonPreambleTitle;

            if (sLessonPreamblePath != "" && sLessonPreamblePath != "0") {
                PdfReader reader = new PdfReader(sLessonPreamblePath);
                int iPages = reader.NumberOfPages;
                PdfImportedPage imPage;
                for (int i = 1; i <= iPages; i++) {

                    Phrase pScope = new Phrase(chunkTOC);
                    pScope.Font.Color = color_Black;
                    pScope.Font.SetFamily("Arial");
                    pScope.Font.SetStyle("bold");
                    pScope.Font.Size = 18;
                    pdfDocument.Add(pScope);

                    imPage = pdfWriter.GetImportedPage(reader, i);
                    iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(imPage);
                    png.ScalePercent(99f);
                    png.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                    png.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
                    pdfDocument.Add(png);

                    pdfDocument.NewPage();
                }
            } else {
                Paragraph pgTitle = new Paragraph(chunkTOC);
                pgTitle.Alignment = Element.ALIGN_CENTER;
                pgTitle.SpacingAfter = 20;
                //pdfDocument.Add(pgTitle);

                if (sLessonPreambleTitle1 != "") {
                    Paragraph pgPreambleTitle1 = new Paragraph(sLessonPreambleTitle1);
                    pgPreambleTitle1.Font.SetFamily("Arial");
                    pgPreambleTitle1.Font.SetStyle("bold,underline");
                    pgPreambleTitle1.Font.Size = 12;
                    pgPreambleTitle1.SpacingAfter = 5;
                    pdfDocument.Add(pgPreambleTitle1);
                }
                if (sLessonPreambleText1 != "") {
                    RTF2String(pdfWriter, pdfDocument, sLessonPreambleText1);
                }
                if (sLessonPreambleTitle2 != "") {
                    Paragraph pgPreambleTitle2 = new Paragraph(sLessonPreambleTitle2);
                    pgPreambleTitle2.SpacingBefore = 10;
                    pgPreambleTitle2.Font.SetFamily("Arial");
                    pgPreambleTitle2.Font.SetStyle("bold,underline");
                    pgPreambleTitle2.Font.Size = 12;
                    pgPreambleTitle2.SpacingAfter = 5;
                    pdfDocument.Add(pgPreambleTitle2);
                }
                if (sLessonPreambleText2 != "") {
                    RTF2String(pdfWriter, pdfDocument, sLessonPreambleText2);
                }
                if (sLessonPreambleTitle3 != "") {
                    Paragraph pgPreambleTitle3 = new Paragraph(sLessonPreambleTitle3);
                    pgPreambleTitle3.SpacingBefore = 10;
                    pgPreambleTitle3.Font.SetFamily("Arial");
                    pgPreambleTitle3.Font.SetStyle("bold,underline");
                    pgPreambleTitle3.Font.Size = 12;
                    pgPreambleTitle3.SpacingAfter = 5;
                    pdfDocument.Add(pgPreambleTitle3);
                }
                if (sLessonPreambleText3 != "") {
                    RTF2String(pdfWriter, pdfDocument, sLessonPreambleText3);
                }
            }
        }


        public static void Generate_Curricula(int iID) {

            if (GlobalCode.sPATH_PDF == "") {
                GlobalCode.sPATH_PDF = GlobalCode.sPATH_APP;
            }
            if (GlobalCode.sFILE_PDF == "") {
                GlobalCode.sFILE_PDF = GlobalCode.sFleet + " Training Guide";
            }


            // create envirenmemt to save the pdf
            string sFile = GlobalCode.sPATH_PDF + "\\" + GlobalCode.sFILE_PDF + ".pdf";
            FileStream fs = new FileStream(sFile, FileMode.Create, FileAccess.Write, FileShare.None);


            // set pdfPage type (letter)
            iTextSharp.text.Rectangle pdfRectangle = new iTextSharp.text.Rectangle(PageSize.LETTER);
            // create document and set margins in points (72pts/inch)
            // adjusted down and up to allow for header and footer
            Document pdfDocument = new Document(pdfRectangle, 5, 5, 50, 50);
            // create the pdf pdfWriter
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDocument, fs);

            // instantiate the TOC
            TOCEvents pdfEventTOC = new TOCEvents();
            pdfWriter.PageEvent = pdfEventTOC;

            // HEADER / FOOTER
            pdfWriter.PageEvent = new ITextEvents();

            // open the document
            pdfDocument.Open();
            pdfWriter.SetLinearPageMode();

            // create a pdfPage rectange=le (the entire sheet)
            iTextSharp.text.Rectangle pdfPage = pdfDocument.PageSize;

            // create document outline
            // start with the root of the tree
            olRoot = pdfWriter.RootOutline;



            // create the title page
            Create_Title_Page(pdfPage, pdfDocument, pdfWriter, sDocTitle);




            string sCommand = "SELECT * FROM Curriculum WHERE ID = " + iID;
            OleDbConnection conn = new OleDbConnection(GlobalCode.sOleDbConnectionString);
            conn.Open();
            OleDbDataAdapter dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
            DataTable dtCuricula = new DataTable();
            dAdapter.Fill(dtCuricula);
            conn.Close();

            // cycle thru curriculum list for all lessons
            int iCurriculaLesson = 0;
            //for (int iCurriculaLesson = 0; iCurriculaLesson <= dtCuricula.Rows.Count - 1; iCurriculaLesson++) {
            for (int x = 4; x <= 33; x++) {
                iCurriculaLesson++;
                int iLesson = (int)dtCuricula.Rows[0].ItemArray[x];
                if (iLesson > -1) {
                    GlobalCode.iLesson = iLesson;

                    // get this lesson
                    sCommand = "SELECT * FROM Lesson WHERE ID = " + iLesson;
                    conn.Open();
                    dAdapter = new OleDbDataAdapter(sCommand, GlobalCode.sOleDbConnectionString);
                    DataTable dtLesson = new DataTable();
                    dAdapter.Fill(dtLesson);
                    conn.Close();

                    // cycle thru lesson list for all spots
                    List<int> iSPOTList1 = new List<int>();
                        
                    //for (int iLessonRow = 0; iLessonRow <= dtLesson.Rows.Count - 1; iLessonRow++) {
                        for (int iColumn = 4; iColumn <= 33; iColumn++) {
                        int ispot = int.Parse(dtLesson.Rows[0].ItemArray[iColumn].ToString());
                        if (ispot > -1) {
                                iSPOTList1.Add(ispot);
                            }
                        }
                        GlobalCode.iSPOTList = iSPOTList1.ToArray();
                    //}

                    // Instantiate the ScriptData class.
                    ScriptData m_SimScript = new ScriptData();
                    // get the data and convert to datatable
                    List<Script> m_Script = new List<Script>(m_SimScript.GetScriptData());
                    DataTable dt = ToDataTable(m_Script);

                    // get the lesson data
                    string sLessonTitle = "";
                    string sLessonSubTitle = "";
                    bool bLessonPreambleBefore1 = false;
                    bool bLessonPreambleAfter1 = false;
                    int iLessonPreamble1 = -1;
                    bool bLessonPreambleBefore2 = false;
                    bool bLessonPreambleAfter2 = false;
                    int iLessonPreamble2 = -1;
                    bool bLessonPreambleBefore3 = false;
                    bool bLessonPreambleAfter3 = false;
                    int iLessonPreamble3 = -1;
                    bool bLessonPreambleBefore4 = false;
                    bool bLessonPreambleAfter4 = false;
                    int iLessonPreamble4 = -1;

                    int iCountx = 0;
                    foreach (DataRow row in dt.Rows) {
                        iCountx++;
                        if (iCountx == 1) {
                            sLessonTitle = iCurriculaLesson + "- " + row["TEXT_TITLE"].ToString();
                            sLessonSubTitle = "AAL" + row["FLTNUM"].ToString() + " (" + row["DEP"].ToString() + "-" + row["DEST"].ToString() + ")";

                            bLessonPreambleBefore1 = bool.Parse(row["PREAMBLE_BEFORE_1"].ToString());
                            bLessonPreambleAfter1 = bool.Parse(row["PREAMBLE_AFTER_1"].ToString());
                            iLessonPreamble1 = int.Parse(row["PREAMBLE_TITLE_1"].ToString());

                            bLessonPreambleBefore2 = bool.Parse(row["PREAMBLE_BEFORE_21"].ToString());
                            bLessonPreambleAfter2 = bool.Parse(row["PREAMBLE_AFTER_21"].ToString());
                            iLessonPreamble2 = int.Parse(row["PREAMBLE_TITLE_21"].ToString());

                            bLessonPreambleBefore3 = bool.Parse(row["PREAMBLE_BEFORE_31"].ToString());
                            bLessonPreambleAfter3 = bool.Parse(row["PREAMBLE_AFTER_31"].ToString());
                            iLessonPreamble3 = int.Parse(row["PREAMBLE_TITLE_31"].ToString());

                            bLessonPreambleBefore4 = bool.Parse(row["PREAMBLE_BEFORE_41"].ToString());
                            bLessonPreambleAfter4 = bool.Parse(row["PREAMBLE_AFTER_41"].ToString());
                            iLessonPreamble4 = int.Parse(row["PREAMBLE_TITLE_41"].ToString());
                        }
                    }

                    string sLessonTitleSummary = sLessonTitle + " SUMMARY \n" + sLessonSubTitle;
                    string sLessonTitlePreamble = sLessonTitle + "\n" + sLessonSubTitle;

                    Chunk chunkTOC = new Chunk(sLessonTitlePreamble, font_Bold_Maroon_14);
                    // LESSON TITLE AND PREAMBLE pdfPage
                    if (bLessonPreambleBefore1 && iLessonPreamble1 > -1) {
                        //pdfDocument.Add(Page_Header(pdfPage, sLessonTitle, olRoot, pdfWriter, sLessonTitleSummary, true));
                        Print_Preamble(pdfDocument, pdfWriter, iLessonPreamble1, chunkTOC);
                        pdfDocument.NewPage();
                    }
                    if (bLessonPreambleBefore2 && iLessonPreamble2 > -1) {
                        //pdfDocument.Add(Page_Header(pdfPage, sLessonTitle, olRoot, pdfWriter, sLessonTitleSummary, true));
                        Print_Preamble(pdfDocument, pdfWriter, iLessonPreamble2, chunkTOC);
                        pdfDocument.NewPage();
                    }
                    if (bLessonPreambleBefore3 && iLessonPreamble3 > -1) {
                        //pdfDocument.Add(Page_Header(pdfPage, sLessonTitle, olRoot, pdfWriter, sLessonTitleSummary, true));
                        Print_Preamble(pdfDocument, pdfWriter, iLessonPreamble3, chunkTOC);
                        pdfDocument.NewPage();
                    }
                    if (bLessonPreambleBefore4 && iLessonPreamble4 > -1) {
                        //pdfDocument.Add(Page_Header(pdfPage, sLessonTitle, olRoot, pdfWriter, sLessonTitleSummary, true));
                        Print_Preamble(pdfDocument, pdfWriter, iLessonPreamble4, chunkTOC);
                        pdfDocument.NewPage();
                    }

                    // set lesson section for footer
                    sDocSection = sLessonTitle;


                    // record pdfPage TOC event
                    //chunkTOC.SetGenericTag(sLessonTitle + "- " + sLessonSubTitle);

                    // insert pdfPage header
                    // sSPOT + ": " + sManeuver


                    // lesson preamble


                    // insert pdfPage header
                    //pdfDocument.Add(Page_Header(pdfPage, sLessonTitle, olRoot, pdfWriter, "",false));


                    // record pdfPage TOC event
                    chunkTOC = new Chunk(sLessonTitleSummary);
                    chunkTOC.SetGenericTag(sLessonTitle + "- SUMMARY");

                    // SUMMARY pdfPage
                    Paragraph pgTitleSummary = new Paragraph(chunkTOC);
                    pgTitleSummary.Font.SetFamily("Arial");
                    pgTitleSummary.Font.SetStyle("bold");
                    pgTitleSummary.Font.Size = 14;
                    pgTitleSummary.Font.Color = color_Maroon;
                    pgTitleSummary.Alignment = Element.ALIGN_CENTER;
                    pgTitleSummary.SpacingAfter = 20;
                    pdfDocument.Add(pgTitleSummary);


                    // summary table
                    string[] col = { "", "PF", "TIME", "MANEUVER" };
                    PdfPTable tableSummary = new PdfPTable(4);
                    tableSummary.WidthPercentage = 100;
                    // then set the column's __relative__ widths
                    tableSummary.SetWidths(new Single[] { 2, 2, 1, 10 });
                    tableSummary.SpacingBefore = 10;
                    // summary table header
                    for (int iSummary = 0; iSummary < col.Length; ++iSummary) {
                        Phrase pPhrase = new Phrase(col[iSummary]);
                        pPhrase.Font.Color = color_Black;
                        pPhrase.Font.SetFamily("Arial");
                        pPhrase.Font.SetStyle("bold");
                        PdfPCell cell = new PdfPCell(new Phrase(pPhrase));
                        cell.BackgroundColor = background_gold;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        cell.VerticalAlignment = Element.ALIGN_TOP;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        tableSummary.AddCell(cell);
                    }
                    // summary data
                    string sEntTime = "";
                    foreach (DataRow row in dt.Rows) {
                        string sPF = row["PF1"].ToString();
                        string sManeuver = row["MANEUVER"].ToString();

                        if (sManeuver.IndexOf("BREAK FOR") > -1) {
                            Phrase pPhrase5 = new Phrase(sManeuver);
                            PdfPCell c5 = new PdfPCell(pPhrase5);
                            c5.Colspan = 4;
                            c5.BackgroundColor = background_breakgreen;
                            c5.VerticalAlignment = Element.ALIGN_MIDDLE;
                            c5.HorizontalAlignment = Element.ALIGN_CENTER;
                            tableSummary.AddCell(c5);
                        } else {
                            Phrase pPhrase1 = new Phrase(row["SPOT"].ToString());
                            pPhrase1.Font.Color = color_Black;
                            pPhrase1.Font.SetFamily("Arial");
                            pPhrase1.Font.SetStyle("normal");
                            PdfPCell c1 = new PdfPCell(pPhrase1);
                            c1.BackgroundColor = background_white;
                            c1.VerticalAlignment = Element.ALIGN_MIDDLE;
                            c1.HorizontalAlignment = Element.ALIGN_CENTER;
                            tableSummary.AddCell(c1);

                            Phrase pPhrase2 = new Phrase(sPF);
                            pPhrase2.Font.Color = color_Black;
                            pPhrase2.Font.SetFamily("Arial");
                            pPhrase2.Font.SetStyle("normal");
                            PdfPCell c2 = new PdfPCell(pPhrase2);
                            if (sPF == "PILOT A" || sPF == "CA") {
                                pPhrase2.Font.Color = color_White;
                                c2.BackgroundColor = color_pf_a;
                            } else if (sPF == "PILOT B" || sPF == "FO") {
                                pPhrase2.Font.Color = color_White;
                                c2.BackgroundColor = color_pf_b;
                            } else if (sPF == "EITHER") {
                                pPhrase2.Font.Color = color_White;
                                c2.BackgroundColor = color_pf_both;// new BaseColor(70, 200, 255);
                            } else if (sPF == "BOTH") {
                                pPhrase2.Font.Color = color_White;
                                c2.BackgroundColor = color_pf_either;//new BaseColor(200, 200, 100);
                            }
                            c2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            c2.HorizontalAlignment = Element.ALIGN_CENTER;
                            tableSummary.AddCell(c2);

                            Phrase pPhrase3 = new Phrase(row["TIME_SPOT"].ToString());
                            pPhrase3.Font.Color = color_Black;
                            pPhrase3.Font.SetFamily("Arial");
                            pPhrase3.Font.SetStyle("normal");
                            PdfPCell c3 = new PdfPCell(pPhrase3);
                            c3.BackgroundColor = background_white;
                            c3.VerticalAlignment = Element.ALIGN_MIDDLE;
                            c3.HorizontalAlignment = Element.ALIGN_CENTER;
                            tableSummary.AddCell(c3);

                            Phrase pPhrase4 = new Phrase(sManeuver);
                            pPhrase4.Font.Color = color_Black;
                            pPhrase4.Font.SetFamily("Arial");
                            pPhrase4.Font.SetStyle("normal");
                            PdfPCell c4 = new PdfPCell(pPhrase4);
                            c4.BackgroundColor = background_white;
                            c4.VerticalAlignment = Element.ALIGN_MIDDLE;
                            c4.HorizontalAlignment = Element.ALIGN_LEFT;
                            tableSummary.AddCell(c4);
                        }
                        sEntTime = row["TIME_END"].ToString();
                    }
                    // summary table footer
                    Phrase pPhrase6 = new Phrase("");
                    PdfPCell c6 = new PdfPCell(pPhrase6);
                    c6.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    c6.BackgroundColor = background_gold;
                    tableSummary.AddCell(c6);
                    Phrase pPhrase8 = new Phrase(sEntTime);
                    PdfPCell c8 = new PdfPCell(pPhrase8);
                    c8.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    c8.BackgroundColor = background_gold;
                    c8.VerticalAlignment = Element.ALIGN_MIDDLE;
                    c8.HorizontalAlignment = Element.ALIGN_RIGHT;
                    c8.Colspan = 2;
                    tableSummary.AddCell(c8);
                    PdfPCell c7 = new PdfPCell(pPhrase6);
                    c7.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    c7.BackgroundColor = background_gold;
                    tableSummary.AddCell(c7);

                    pdfDocument.Add(tableSummary);

                    // SPOTS
                    int iRowCounter = 0;
                    int iRowCount = dt.Rows.Count;
                    foreach (DataRow row in dt.Rows) {
                        string sPF = row["PF1"].ToString();
                        string sManeuver = row["MANEUVER"].ToString();
                        string sSPOT = row["SPOT"].ToString();

                        //                PdfOutline olLessonSPOTS;

                        iRowCounter++;
                        // start new pdfPage
                        pdfDocument.NewPage();

                        if (sManeuver.IndexOf("BREAK FOR") > -1) {
                            // BREAK //

                            // insert pdfPage header
                            //pdfDocument.Add(Page_Header(pdfPage, sLessonTitle, olRoot, pdfWriter, "", false));

                            // header
                            PdfPTable tableSPOTHeader = new PdfPTable(1);
                            tableSPOTHeader.WidthPercentage = 100;
                            tableSPOTHeader.SpacingBefore = 1;
                            Phrase pPhrase1 = new Phrase(sManeuver);
                            pPhrase1.Font.Color = color_Black;
                            pPhrase1.Font.SetFamily("Arial");
                            pPhrase1.Font.SetStyle("bold");
                            pPhrase1.Font.Size = 16;
                            PdfPCell c1 = new PdfPCell(pPhrase1);
                            c1.BackgroundColor = background_breakgreen;
                            c1.VerticalAlignment = Element.ALIGN_TOP;
                            c1.HorizontalAlignment = Element.ALIGN_CENTER;
                            c1.BorderWidthRight = 2;
                            c1.BorderWidthLeft = 1;
                            c1.BorderWidthTop = 1;
                            c1.BorderWidthBottom = 2;
                            tableSPOTHeader.AddCell(c1);
                            pdfDocument.Add(tableSPOTHeader);
                        } else {
                            // SPOTS //

                            // insert pdfPage header
                            //pdfDocument.Add(Page_Header(pdfPage, sLessonTitle, olRoot, pdfWriter, sSPOT + ": " + sManeuver, false));

                            // SPOT header
                            PdfPTable tableSPOTHeader = new PdfPTable(3);
                            tableSPOTHeader.WidthPercentage = 100;
                            // then set the column's __relative__ widths
                            tableSPOTHeader.SetWidths(new Single[] { 2, 8, 2 });
                            tableSPOTHeader.SpacingBefore = 1;

                            // spot / event set number
                            // format either 'spot 1' or 'event set 1'
                            Chunk chLine1 = new Chunk();
                            Chunk chLine2 = new Chunk();
                            Chunk chLine3 = new Chunk("\r\n");
                            string sTocTitle = "";
                            if (sSPOT.Contains("SPOT")) {
                                // spot
                                chLine1 = new Chunk("SPOT", font_Spot_Bold_Maroon);
                                chLine2 = new Chunk(sSPOT.Substring(5), font_SpotNum_Bold_Maroon);
                                sTocTitle = "SPOT " + sSPOT.Substring(5);
                            } else {
                                // event set
                                chLine1 = new Chunk("EVENT SET", font_Spot_Bold_Maroon);
                                chLine2 = new Chunk(sSPOT.Substring(6), font_SpotNum_Bold_Maroon);
                                sTocTitle = "EVENT SET " + sSPOT.Substring(6);
                            }

                            // record pdfPage TOC event
                            chLine1.SetGenericTag(sTocTitle + "- " + row["MANEUVER"].ToString());

                            Phrase pPhrase1 = new Phrase();
                            pPhrase1.Add(chLine1);
                            pPhrase1.Add(chLine3);
                            pPhrase1.Add(chLine2);
                            PdfPCell c1 = new PdfPCell(pPhrase1);
                            c1.BackgroundColor = background_gold;
                            c1.VerticalAlignment = Element.ALIGN_MIDDLE;
                            c1.HorizontalAlignment = Element.ALIGN_CENTER;
                            c1.BorderWidthRight = 0;
                            c1.BorderWidthLeft = 1;
                            c1.BorderWidthTop = 1;
                            c1.BorderWidthBottom = 2;
                            tableSPOTHeader.AddCell(c1);

                            Phrase pPhrase2 = new Phrase(row["MANEUVER"].ToString());
                            pPhrase2.Font.Color = color_Black;
                            pPhrase2.Font.SetFamily("Arial");
                            pPhrase2.Font.SetStyle("bold");
                            pPhrase2.Font.Size = 16;
                            PdfPCell c2 = new PdfPCell(pPhrase2);
                            c2.BackgroundColor = background_gold;
                            c2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            c2.HorizontalAlignment = Element.ALIGN_LEFT;
                            c2.BorderWidthRight = 0;
                            c2.BorderWidthLeft = 0;
                            c2.BorderWidthTop = 1;
                            c2.BorderWidthBottom = 2;
                            tableSPOTHeader.AddCell(c2);

                            PdfPTable tableSPOTHeaderInner = new PdfPTable(1);
                            // start time
                            Phrase pPhraseInner1 = new Phrase(row["TIME_START"].ToString());
                            pPhraseInner1.Font.Color = color_Black;
                            pPhraseInner1.Font.SetFamily("Arial");
                            pPhraseInner1.Font.SetStyle("bold");
                            pPhraseInner1.Font.Size = 9;
                            PdfPCell cInner1 = new PdfPCell(pPhraseInner1);
                            cInner1.BackgroundColor = background_gold;
                            cInner1.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cInner1.HorizontalAlignment = Element.ALIGN_RIGHT;
                            cInner1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            tableSPOTHeaderInner.AddCell(cInner1);
                            // spot time
                            Phrase pPhraseInner2 = new Phrase(row["TIME_SPOT"].ToString());
                            pPhraseInner2.Font.Color = color_Maroon;
                            pPhraseInner2.Font.SetFamily("Arial");
                            pPhraseInner2.Font.SetStyle("bold");
                            pPhraseInner2.Font.Size = 12;
                            PdfPCell cInner2 = new PdfPCell(pPhraseInner2);
                            cInner2.BackgroundColor = background_gold;
                            cInner2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cInner2.HorizontalAlignment = Element.ALIGN_RIGHT;
                            cInner2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            tableSPOTHeaderInner.AddCell(cInner2);
                            // end time
                            Phrase pPhraseInner3 = new Phrase(row["TIME_END"].ToString());
                            pPhraseInner3.Font.Color = color_Black;
                            pPhraseInner3.Font.SetFamily("Arial");
                            pPhraseInner3.Font.SetStyle("bold");
                            pPhraseInner3.Font.Size = 9;
                            PdfPCell cInner3 = new PdfPCell(pPhraseInner3);
                            cInner3.BackgroundColor = background_gold;
                            cInner3.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cInner3.HorizontalAlignment = Element.ALIGN_RIGHT;
                            cInner3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            tableSPOTHeaderInner.AddCell(cInner3);
                            // add inner cell to outer cell
                            PdfPCell c3 = new PdfPCell();
                            c3.BackgroundColor = background_gold;
                            c3.VerticalAlignment = Element.ALIGN_MIDDLE;
                            c3.HorizontalAlignment = Element.ALIGN_RIGHT;
                            c3.BorderWidthRight = 2;
                            c3.BorderWidthLeft = 0;
                            c3.BorderWidthTop = 1;
                            c3.BorderWidthBottom = 2;
                            c3.AddElement(tableSPOTHeaderInner);
                            tableSPOTHeader.AddCell(c3);
                            // add spot header
                            pdfDocument.Add(tableSPOTHeader);

                            // OBJECTIVE & SCOPE
                            PdfPTable tableObjScope = new PdfPTable(2);
                            tableObjScope.WidthPercentage = 100;
                            // then set the column's __relative__ widths
                            tableObjScope.SetWidths(new Single[] { 2, 10 });
                            tableObjScope.SpacingBefore = 1;

                            // get objective text
                            string sObj1 = row["OBJECTIVE1"].ToString();
                            string sObj2 = row["OBJECTIVE2"].ToString();
                            if (sObj1 == "") {
                                if (sObj2 != "") {
                                    sObj1 = sObj2;
                                }
                            } else if (sObj2 != "") {
                                sObj1 = sObj1 + "\n" + sObj2;
                            }
                            if (sObj1 != "") {
                                // display objective
                                Phrase pObjective = new Phrase("OBJECTIVE");
                                pObjective.Font.Color = color_Black;
                                pObjective.Font.SetFamily("Arial");
                                pObjective.Font.SetStyle("bold");
                                pObjective.Font.Size = iNormalFontSize;
                                PdfPCell cO1 = new PdfPCell(pObjective);
                                cO1.BackgroundColor = background_white;
                                cO1.VerticalAlignment = Element.ALIGN_TOP;
                                cO1.HorizontalAlignment = Element.ALIGN_RIGHT;
                                cO1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                                tableObjScope.AddCell(cO1);
                                Phrase pObjective1 = new Phrase(sObj1);
                                pObjective1.Font.Color = color_Black;
                                pObjective1.Font.SetFamily("Arial");
                                pObjective1.Font.SetStyle("normal");
                                pObjective1.Font.Size = iNormalFontSize;
                                PdfPCell cO2 = new PdfPCell(pObjective1);
                                cO2.BackgroundColor = background_white;
                                cO2.VerticalAlignment = Element.ALIGN_TOP;
                                cO2.HorizontalAlignment = Element.ALIGN_LEFT;
                                cO2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                                tableObjScope.AddCell(cO2);
                            }
                            // get scope text
                            string sScp1 = row["SCOPE1"].ToString();
                            string sScp2 = row["SCOPE2"].ToString();
                            if (sScp1 == "") {
                                if (sScp2 != "") {
                                    sScp1 = sScp2;
                                }
                            } else if (sScp2 != "") {
                                sScp1 = sScp1 + "\n" + sScp2;
                            }
                            if (sScp1 != "") {
                                // display scope
                                Phrase pScope = new Phrase("SCOPE");
                                pScope.Font.Color = color_Black;
                                pScope.Font.SetFamily("Arial");
                                pScope.Font.SetStyle("bold");
                                pScope.Font.Size = iNormalFontSize;
                                PdfPCell cO1 = new PdfPCell(pScope);
                                cO1.BackgroundColor = background_white;//white
                                cO1.VerticalAlignment = Element.ALIGN_TOP;
                                cO1.HorizontalAlignment = Element.ALIGN_RIGHT;
                                cO1.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                                tableObjScope.AddCell(cO1);
                                Phrase pScope1 = new Phrase(sScp1);
                                pScope1.Font.Color = color_Black;
                                pScope1.Font.SetFamily("Arial");
                                pScope1.Font.SetStyle("normal");
                                pScope1.Font.Size = iNormalFontSize;
                                PdfPCell cO2 = new PdfPCell(pScope1);
                                cO2.BackgroundColor = background_white;
                                cO2.VerticalAlignment = Element.ALIGN_TOP;
                                cO2.HorizontalAlignment = Element.ALIGN_LEFT;
                                cO2.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                                tableObjScope.AddCell(cO2);
                            }
                            if (sObj1 != "" || sScp1 != "") {
                                tableObjScope.SpacingAfter = 2;
                                pdfDocument.Add(tableObjScope);
                            }

                            //LineSeparator drawLine = new LineSeparator(0.0F, 100.0F, color_Black, Element.ALIGN_LEFT,-10);
                            //pdfDocument.Add(new Chunk(drawLine));

                            // POSITION
                            PdfPTable tablePos = new PdfPTable(2);
                            tablePos.WidthPercentage = 100;
                            tablePos.SetWidths(new Single[] { 2, 10 });
                            tablePos.SpacingBefore = 1;
                            // sim position
                            string sPos = row["SIM_POSITION"].ToString();
                            if (sPos != "") {
                                // display
                                Phrase pScope = new Phrase("SIM POSITION");
                                pScope.Font.Color = color_Black;
                                pScope.Font.SetFamily("Arial");
                                pScope.Font.SetStyle("bold");
                                pScope.Font.Size = iNormalFontSize;
                                PdfPCell cO1 = new PdfPCell(pScope);
                                cO1.BackgroundColor = background_white;
                                cO1.VerticalAlignment = Element.ALIGN_TOP;
                                cO1.HorizontalAlignment = Element.ALIGN_RIGHT;
                                cO1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                                tablePos.AddCell(cO1);
                                Phrase pScope1 = new Phrase(sPos);
                                pScope1.Font.Color = color_Maroon;
                                pScope1.Font.SetFamily("Arial");
                                pScope1.Font.SetStyle("bold");
                                pScope1.Font.Size = iNormalFontSize;
                                PdfPCell cO2 = new PdfPCell(pScope1);
                                cO2.BackgroundColor = background_white;
                                cO2.VerticalAlignment = Element.ALIGN_TOP;
                                cO2.HorizontalAlignment = Element.ALIGN_LEFT;
                                cO2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                                tablePos.AddCell(cO2);
                                pdfDocument.Add(tablePos);
                            }

                            // SETUP
                            PdfPTable tableSimSetup = new PdfPTable(2);
                            tableSimSetup.WidthPercentage = 100;
                            tableSimSetup.SetWidths(new Single[] { 2, 10 });
                            tableSimSetup.SpacingBefore = 1;
                            string sSetup1 = row["SIM_SETUP1"].ToString();
                            string sSetup2 = row["SIM_SETUP2"].ToString();
                            string sSetup3 = row["SIM_SETUP3"].ToString();
                            string sSetup4 = row["SIM_SETUP4"].ToString();
                            if (sSetup1 == "") {
                                if (sSetup2 != "") {
                                    sSetup1 = sSetup2;
                                }
                            } else if (sSetup2 != "") {
                                sSetup1 = sSetup1 + "\n" + sSetup2;
                            }
                            if (sSetup3 != "") {
                                sSetup1 = sSetup1 + "\n" + sSetup3;
                            }
                            if (sSetup4 != "") {
                                sSetup1 = sSetup1 + "\n" + sSetup4;
                            }
                            if (sSetup1 != "") {
                                // display
                                Phrase pScope = new Phrase("SIM SETUP");
                                pScope.Font.Color = color_Black;
                                pScope.Font.SetFamily("Arial");
                                pScope.Font.SetStyle("bold");
                                pScope.Font.Size = iNormalFontSize;
                                PdfPCell cO1 = new PdfPCell(pScope);
                                cO1.BackgroundColor = background_white;
                                cO1.VerticalAlignment = Element.ALIGN_TOP;
                                cO1.HorizontalAlignment = Element.ALIGN_RIGHT;
                                cO1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                                tableSimSetup.AddCell(cO1);
                                Phrase pScope1 = new Phrase(sSetup1);
                                pScope1.Font.Color = color_Maroon;
                                pScope1.Font.SetFamily("Arial");
                                pScope1.Font.SetStyle("bold");
                                pScope1.Font.Size = iNormalFontSize;
                                PdfPCell cO2 = new PdfPCell(pScope1);
                                cO2.BackgroundColor = background_white;
                                cO2.VerticalAlignment = Element.ALIGN_TOP;
                                cO2.HorizontalAlignment = Element.ALIGN_LEFT;
                                cO2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                                tableSimSetup.AddCell(cO2);
                                pdfDocument.Add(tableSimSetup);
                            }

                            // NOTES
                            PdfPTable tableNotes = new PdfPTable(2);
                            tableNotes.WidthPercentage = 100;
                            tableNotes.SetWidths(new Single[] { 2, 10 });
                            tableNotes.SpacingAfter = 1;
                            string sNotes1 = row["NOTES_1"].ToString();
                            string sNotes2 = row["NOTES_2"].ToString();
                            string sNotes3 = row["NOTES_3"].ToString();
                            string sNotes4 = row["NOTES_4"].ToString();
                            string sNotes5 = row["NOTES_5"].ToString();
                            if (sNotes1 == "") {
                                if (sNotes2 != "") {
                                    sNotes1 = sNotes2;
                                }
                            } else if (sNotes2 != "") {
                                sNotes1 = sNotes1 + "\n" + sNotes2;
                            }
                            if (sNotes3 != "") {
                                sNotes1 = sNotes1 + "\n" + sNotes3;
                            }
                            if (sNotes4 != "") {
                                sNotes1 = sNotes1 + "\n" + sNotes4;
                            }
                            if (sNotes5 != "") {
                                sNotes1 = sNotes1 + "\n" + sNotes5;
                            }
                            if (sNotes1 != "") {
                                // display
                                Phrase pScope = new Phrase("SPOT NOTES");
                                pScope.Font.Color = color_Black;
                                pScope.Font.SetFamily("Arial");
                                pScope.Font.SetStyle("bold");
                                pScope.Font.Size = iNormalFontSize;
                                PdfPCell cO1 = new PdfPCell(pScope);
                                cO1.BackgroundColor = background_white;
                                cO1.VerticalAlignment = Element.ALIGN_TOP;
                                cO1.HorizontalAlignment = Element.ALIGN_RIGHT;
                                cO1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                                tableNotes.AddCell(cO1);
                                Phrase pScope1 = new Phrase(sNotes1);
                                pScope1.Font.Color = color_Blue;
                                pScope1.Font.SetFamily("Arial");
                                pScope1.Font.SetStyle("normal");
                                pScope1.Font.Size = iNormalFontSize;
                                PdfPCell cO2 = new PdfPCell(pScope1);
                                cO2.BackgroundColor = background_white;
                                cO2.VerticalAlignment = Element.ALIGN_TOP;
                                cO2.HorizontalAlignment = Element.ALIGN_LEFT;
                                cO2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                                tableNotes.AddCell(cO2);
                                pdfDocument.Add(tableNotes);
                            }

                            // FMGC DISPLAY
                            PdfPTable tableSetup = new PdfPTable(3);
                            tableSetup.WidthPercentage = 100;
                            tableSetup.SetWidths(new Single[] { 5, 5, 5 });
                            tableSetup.SpacingBefore = 10;
                            if (row["SETUP_VISABLE"].ToString() == "yes") {
                                // display setup panel

                                // header
                                Phrase pSetup = new Phrase("AIRCRAFT CONDITIONS");
                                pSetup.Font.Color = color_Black;
                                pSetup.Font.SetFamily("Arial");
                                pSetup.Font.SetStyle("bold");
                                pSetup.Font.Size = iNormalFontSize;
                                PdfPCell cSetup = new PdfPCell(pSetup);
                                cSetup.BackgroundColor = background_grey;
                                cSetup.VerticalAlignment = Element.ALIGN_MIDDLE;
                                cSetup.HorizontalAlignment = Element.ALIGN_LEFT;
                                cSetup.Border = iTextSharp.text.Rectangle.NO_BORDER;
                                cSetup.Colspan = 3;
                                tableSetup.AddCell(cSetup);

                                // init
                                PdfPTable tableInit = null;
                                PdfPTable tableACPerf = null;
                                PdfPTable tableTOPerf = null;
                                if (GlobalCode.sFleet == "A350") {
                                    // get 350 init
                                    tableInit = FMC_350.Init_Page(row);
                                    tableACPerf = FMC_350.AC_Performance(row);
                                    tableTOPerf = FMC_350.Perf_TO(row);
                                } else if (GlobalCode.sFleet == "A320") {
                                    // get 320 init
                                    tableInit = FMC_320.Init_Page(row);
                                    tableACPerf = FMC_320.AC_Performance(row);
                                    tableTOPerf = FMC_320.Perf_TO(row);
                                }

                                // init a
                                cSetup = new PdfPCell();
                                cSetup.BackgroundColor = color_Black;
                                cSetup.VerticalAlignment = Element.ALIGN_TOP;
                                cSetup.HorizontalAlignment = Element.ALIGN_LEFT;
                                cSetup.Border = iTextSharp.text.Rectangle.RIGHT_BORDER;
                                cSetup.BorderColor = background_grey;
                                cSetup.AddElement(tableInit);
                                tableSetup.AddCell(cSetup);

                                // init b
                                cSetup = new PdfPCell();
                                cSetup.BackgroundColor = color_Black;
                                cSetup.VerticalAlignment = Element.ALIGN_TOP;
                                cSetup.HorizontalAlignment = Element.ALIGN_LEFT;
                                cSetup.Border = iTextSharp.text.Rectangle.NO_BORDER;
                                cSetup.AddElement(tableACPerf);
                                tableSetup.AddCell(cSetup);

                                //// perf cell
                                cSetup = new PdfPCell();
                                cSetup.BackgroundColor = color_Black;
                                cSetup.VerticalAlignment = Element.ALIGN_TOP;
                                cSetup.HorizontalAlignment = Element.ALIGN_LEFT;
                                cSetup.Border = iTextSharp.text.Rectangle.LEFT_BORDER;
                                cSetup.BorderColor = background_grey;
                                cSetup.AddElement(tableTOPerf);
                                tableSetup.AddCell(cSetup);



                            }

                            string sATIS = row["ATIS"].ToString();
                            if (sATIS != "") {
                                // print wx table if atis selected
                                PdfPTable tableWX = null;
                                tableWX = FMC_320.Conditions_WX(row);
                                PdfPCell cSetup = new PdfPCell();
                                cSetup.BackgroundColor = color_Black;
                                cSetup.VerticalAlignment = Element.ALIGN_TOP;
                                cSetup.HorizontalAlignment = Element.ALIGN_LEFT;
                                cSetup.Border = iTextSharp.text.Rectangle.NO_BORDER;
                                cSetup.Colspan = 3;
                                cSetup.AddElement(tableWX);
                                tableSetup.AddCell(cSetup);
                            }
                            pdfDocument.Add(tableSetup);

                            // ATIS
                            PdfPTable tableATIS = new PdfPTable(2);
                            tableATIS.WidthPercentage = 100;
                            tableATIS.SetWidths(new Single[] { 2, 10 });
                            tableATIS.SpacingAfter = 1;
                            if (sATIS != "") {
                                // display
                                var chuckData = new Chunk(sATIS, font_Data_Maroon);
                                Phrase pScope = new Phrase("ATIS");
                                pScope.Font.Color = color_Black;
                                pScope.Font.SetFamily("Arial");
                                pScope.Font.SetStyle("bold");
                                pScope.Font.Size = iNormalFontSize;
                                PdfPCell cO1 = new PdfPCell(pScope);
                                cO1.BackgroundColor = background_white;
                                cO1.VerticalAlignment = Element.ALIGN_TOP;
                                cO1.HorizontalAlignment = Element.ALIGN_RIGHT;
                                cO1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                                tableATIS.AddCell(cO1);
                                Phrase pScope1 = new Phrase(chuckData);
                                PdfPCell cO2 = new PdfPCell(pScope1);
                                cO2.BackgroundColor = background_white;
                                cO2.VerticalAlignment = Element.ALIGN_TOP;
                                cO2.HorizontalAlignment = Element.ALIGN_LEFT;
                                cO2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                                tableATIS.AddCell(cO2);
                                pdfDocument.Add(tableATIS);
                            }
                            // CLEARANCE
                            PdfPTable tableClearance = new PdfPTable(2);
                            tableClearance.WidthPercentage = 100;
                            tableClearance.SetWidths(new Single[] { 2, 10 });
                            tableClearance.SpacingAfter = 1;
                            // sim position
                            string sClearance = row["CLEARANCE"].ToString();
                            if (sClearance != "") {
                                // display
                                var chuckData = new Chunk(sClearance, font_Data_Maroon);
                                Phrase pScope = new Phrase("CLEARANCE");
                                pScope.Font.Color = color_Black;
                                pScope.Font.SetFamily("Arial");
                                pScope.Font.SetStyle("bold");
                                pScope.Font.Size = iNormalFontSize;
                                PdfPCell cO1 = new PdfPCell(pScope);
                                cO1.BackgroundColor = background_white;
                                cO1.VerticalAlignment = Element.ALIGN_TOP;
                                cO1.HorizontalAlignment = Element.ALIGN_RIGHT;
                                cO1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                                tableClearance.AddCell(cO1);
                                Phrase pScope1 = new Phrase(chuckData);
                                PdfPCell cO2 = new PdfPCell(pScope1);
                                cO2.BackgroundColor = background_white;
                                cO2.VerticalAlignment = Element.ALIGN_TOP;
                                cO2.HorizontalAlignment = Element.ALIGN_LEFT;
                                cO2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                                tableClearance.AddCell(cO2);
                                pdfDocument.Add(tableClearance);
                            }


                            for (int iAction = 1; iAction < 11; iAction++) {
                                if (row["PF" + iAction].ToString() != "")
                                    pdfDocument.Add(Actions(row, iAction));
                            }

                            // SPOT footer
                            string sFooterText = "";
                            if (iRowCounter < iRowCount) {
                                sFooterText = sSPOT + " COMPLETE";
                            } else {
                                sFooterText = "** " + sSPOT + " AND LESSON COMPLETE **";
                            }
                            tableSPOTHeader = new PdfPTable(1);
                            tableSPOTHeader.WidthPercentage = 100;
                            tableSPOTHeader.SpacingBefore = 0;
                            pPhrase1 = new Phrase(sFooterText);
                            if (iRowCounter < iRowCount) {
                                pPhrase1.Font.Color = color_Black;
                            } else {
                                pPhrase1.Font.Color = color_Yellow;
                            }
                            pPhrase1.Font.SetFamily("Arial");
                            pPhrase1.Font.SetStyle("bold");
                            pPhrase1.Font.Size = iNormalFontSize;
                            c1 = new PdfPCell(pPhrase1);
                            if (iRowCounter < iRowCount) {
                                c1.BackgroundColor = background_gold;
                            } else {
                                c1.BackgroundColor = color_Maroon;
                            }
                            c1.VerticalAlignment = Element.ALIGN_TOP;
                            c1.HorizontalAlignment = Element.ALIGN_CENTER;
                            c1.BorderWidthRight = 1;
                            c1.BorderWidthLeft = 1;
                            c1.BorderWidthTop = 1;
                            c1.BorderWidthBottom = 1;
                            tableSPOTHeader.AddCell(c1);
                            pdfDocument.Add(tableSPOTHeader);

                        }
                    }

                    // LESSON PREAMBLE AFTER
                    if (bLessonPreambleAfter1 && iLessonPreamble1 > -1) {
                        pdfDocument.NewPage();
                        //pdfDocument.Add(Page_Header(pdfPage, sLessonTitle, olRoot, pdfWriter, sLessonTitleSummary, true));
                        Print_Preamble(pdfDocument, pdfWriter, iLessonPreamble1, chunkTOC);
                    }
                    if (bLessonPreambleAfter2 && iLessonPreamble2 > -1) {
                        pdfDocument.NewPage();
                        //pdfDocument.Add(Page_Header(pdfPage, sLessonTitle, olRoot, pdfWriter, sLessonTitleSummary, true));
                        Print_Preamble(pdfDocument, pdfWriter, iLessonPreamble2, chunkTOC);
                    }
                    if (bLessonPreambleAfter3 && iLessonPreamble3 > -1) {
                        pdfDocument.NewPage();
                        //pdfDocument.Add(Page_Header(pdfPage, sLessonTitle, olRoot, pdfWriter, sLessonTitleSummary, true));
                        Print_Preamble(pdfDocument, pdfWriter, iLessonPreamble3, chunkTOC);
                    }
                    if (bLessonPreambleAfter4 && iLessonPreamble4 > -1) {
                        pdfDocument.NewPage();
                        //pdfDocument.Add(Page_Header(pdfPage, sLessonTitle, olRoot, pdfWriter, sLessonTitleSummary, true));
                        Print_Preamble(pdfDocument, pdfWriter, iLessonPreamble4, chunkTOC);
                    }
                }

            }
            //}

            // write TOC
            pdfDocument.NewPage();

            // turn footer pg numbers
            bFooterPgNums = false;

            // set lesson section for footer
            sDocSection = "Table of Contents";

            Chunk dottedLine = new Chunk(new DottedLineSeparator());
            Chunk chunckTitle = new Chunk("TABLE OF CONTENTS", font_Normal_Bold_Maroon);
            pdfDocument.Add(new Paragraph(chunckTitle));

            Dictionary<string, KeyValuePair<string, int>> entries = pdfEventTOC.GetTOC();
            Paragraph p;

            foreach (var entry in entries) {
                Chunk chunkKey = new Chunk(entry.Key, font_TOC_Black);
                var vDescript = entry.Key;
                var value = entry.Value.Key;
                chunkKey.SetAction(PdfAction.GotoLocalPage(entry.Value.Key, false));
                p = new Paragraph(chunkKey);
                if (vDescript.IndexOf("SPOT") > -1 || vDescript.IndexOf("EVENT") > -1) {
                    p.IndentationLeft = 20;
                } else {
                    p.IndentationLeft = 10;
                }
                p.Add(dottedLine);

                Chunk chunkPage = new Chunk((entry.Value.Value).ToString(), font_TOC_Bold_Black);
                chunkPage.SetAction(PdfAction.GotoLocalPage(entry.Value.Key, false));
                p.Add(chunkPage);
                pdfDocument.Add(p);


                // buttons
                //iTextSharp.text.Rectangle _rect;
                //_rect = new iTextSharp.text.Rectangle(100, 806, 170, 788);
                //PushbuttonField button = new PushbuttonField(pdfWriter, _rect, "Buttons");



                //var button = new PushbuttonField(pdfWriter, new iTextSharp.text.Rectangle(100, 806, 200, 788), "Text") {
                //    Text = vDescript
                //};
                //button.BackgroundColor = new GrayColor(0.75f);
                //button.BorderColor = GrayColor.GRAYBLACK;
                //button.BorderWidth = 1;
                //button.BorderStyle = PdfBorderDictionary.STYLE_BEVELED;
                //button.TextColor = GrayColor.GRAYBLACK;
                //button.FontSize = 12;
                //button.Text = vDescript;
                //button.Layout = PushbuttonField.LAYOUT_ICON_LEFT_LABEL_RIGHT;
                //button.ScaleIcon = PushbuttonField.SCALE_ICON_ALWAYS;
                //button.ProportionalIcon = true;
                //button.IconHorizontalAdjustment = 0;
                //PdfFormField _Field1 = button.Field;
                //_Field1.Action = PdfAction.GotoLocalPage(entry.Value.Key, false);
                //pdfWriter.AddAnnotation(_Field1);




                //pdfWriter.AddAnnotation(AddButton(pdfDocument, pdfWriter, pdfPage, vDescript, entry.Value.Key).Field);//AddButton(pdfDocument, pdfWriter, pdfPage, vDescript)
                //var button = new PushbuttonField(pdfWriter, new iTextSharp.text.Rectangle(300, 300, 330, 330), "Text") {
                //    Text = vDescript
                //};
                //var f = button.Field;
                //PdfAppearance theButton = button.GetAppearance();
                //f.Action = PdfAction.GotoLocalPage(entry.Value.Key, false);
                // turn footer pg numbers


                bFooterPgNums = false;
            }

            // re-order the pages to place the TOC behind the title page
            //When you add your table of contents, get its pdfPage number for the reordering:
            int iPageTOC = pdfWriter.PageNumber;
            // always add to a new pdfPage before reordering pages.
            pdfDocument.NewPage();
            // get the total number of pages that needs to be reordered
            int total = pdfWriter.ReorderPages(null);
            // change the order
            int[] order = new int[total];
            // we start at page 2 to skip the title pages
            for (int i = 0; i < total; i++) {
                if (i == 0) {
                    order[i] = 1;
                } else if (i == 1) {
                    order[i] = 2;
                } else if (i == 2) {
                    order[i] = iPageTOC;
                } else {
                    order[i] = (i - 1) + iPageTOC;
                    if (order[i] > total) {
                        order[i] -= total;
                        order[i] += 1;
                    }
                }
            }
            // apply the new order
            pdfWriter.ReorderPages(order);

            //float zoomNumber = 100;
            //int pageNumberToOpenTo = 1;
            //PdfDestination magnify = new PdfDestination(PdfDestination.XYZ, -1, -1, zoomNumber / 100);
            //PdfAction zoom = PdfAction.GotoLocalPage(pageNumberToOpenTo, magnify, pdfWriter);


            pdfDocument.CloseDocument();
            pdfDocument = null;
            pdfWriter.Close();
            pdfWriter = null;
            //olLessonSPOTS.Clear();
            //olLessonSPOTS = null;
            olRoot.Clear();
            olRoot = null;
            //olDocTitle.Clear();
            //olDocTitle = null;

            // display the pdf in a viewer
            //GlobalCode.sPDFFile = sFile;
            //frmPDF frmPDF = new frmPDF();
            //frmPDF.Show();


            //Process process = new Process();
            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //process.StartInfo = startInfo;
            //startInfo.FileName = sFile;
            //process.Start();

            frmPDF frmPDF = new frmPDF(sFile);
            frmPDF.Show();


            fs.Close();
            fs = null;

            //m_Script = null;

            iPageNumber = 0;

            //webBrowser1.Navigate(sFile);



        }


        private static PdfPTable Actions(DataRow row, int iAction) {
            PdfPTable tableSetup = new PdfPTable(3);
            tableSetup.WidthPercentage = 100;
            tableSetup.SetWidths(new Single[] { 1, 5, 3});
            tableSetup.SpacingBefore = 0;
            tableSetup.KeepTogether = true;
            tableSetup.SplitRows = false;

            // Headers
            Phrase pSetup1 = new Phrase("PF");
            pSetup1.Font.Color = color_Black;
            pSetup1.Font.SetFamily("Arial");
            pSetup1.Font.SetStyle("bold");
            pSetup1.Font.Size = iNormalFontSize;
            PdfPCell cSetup1 = new PdfPCell(pSetup1);
            cSetup1.BackgroundColor = background_grey;
            cSetup1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cSetup1.HorizontalAlignment = Element.ALIGN_CENTER;
            cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tableSetup.AddCell(cSetup1);
            // 1/b
            Phrase pSetup2 = new Phrase("ACTION");
            pSetup2.Font.Color = color_Black;
            pSetup2.Font.SetFamily("Arial");
            pSetup2.Font.SetStyle("bold");
            pSetup2.Font.Size = iNormalFontSize;
            PdfPCell cSetup2 = new PdfPCell(pSetup2);
            cSetup2.BackgroundColor = background_grey;
            cSetup2.VerticalAlignment = Element.ALIGN_MIDDLE;
            cSetup2.HorizontalAlignment = Element.ALIGN_LEFT;
            cSetup2.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tableSetup.AddCell(cSetup2);
            // 1/c
            Phrase pSetup3 = new Phrase("COMMUNICATIONS");
            pSetup3.Font.Color = color_Black;
            pSetup3.Font.SetFamily("Arial");
            pSetup3.Font.SetStyle("bold");
            pSetup3.Font.Size = iNormalFontSize;
            PdfPCell cSetup3 = new PdfPCell(pSetup3);
            cSetup3.BackgroundColor = background_grey;
            cSetup3.VerticalAlignment = Element.ALIGN_MIDDLE;
            cSetup3.HorizontalAlignment = Element.ALIGN_LEFT;
            cSetup3.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tableSetup.AddCell(cSetup3);

            // data row
            string sPF = row["PF" + iAction].ToString();
            pSetup1 = new Phrase(sPF);
            if (sPF == "PILOT A" || sPF == "CA" || sPF == "CAPTAIN")
                pSetup1.Font.Color = color_White;
            if (sPF == "PILOT B" || sPF == "FO" || sPF == "FIRST OFFICER")
                pSetup1.Font.Color = color_White;
            if (sPF == "BOTH")
                pSetup1.Font.Color = color_Black;
            if (sPF == "EITHER")
                pSetup1.Font.Color = color_Black;
            pSetup1.Font.SetFamily("Arial");
            pSetup1.Font.SetStyle("bold");
            pSetup1.Font.Size = iNormalFontSize;
            cSetup1 = new PdfPCell(pSetup1);
            if (sPF == "PILOT A" || sPF == "CA" || sPF == "CAPTAIN")
                cSetup1.BackgroundColor = color_pf_a;
            if (sPF == "PILOT B" || sPF == "FO" || sPF == "FIRST OFFICER")
                cSetup1.BackgroundColor = color_pf_b;
            if (sPF == "BOTH")
                cSetup1.BackgroundColor = color_pf_both;
            if (sPF == "EITHER")
                cSetup1.BackgroundColor = color_pf_either;
            cSetup1.VerticalAlignment = Element.ALIGN_TOP;
            cSetup1.HorizontalAlignment = Element.ALIGN_CENTER;
            cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tableSetup.AddCell(cSetup1);

            // action
            PdfPTable tableAction1 = new PdfPTable(1);
            tableAction1.WidthPercentage = 100;
            tableAction1.SetWidths(new Single[] { 1 });
            tableAction1.SpacingBefore = 0;
            Phrase pSetup2a = new Phrase(row["ACTIONTITLE" + iAction].ToString());
            pSetup2a.Font.Color = color_Maroon;
            pSetup2a.Font.SetFamily("Arial");
            pSetup2a.Font.SetStyle("bold,underline");
            pSetup2a.Font.Size = iNormalFontSize;
            PdfPCell cSetup2a = new PdfPCell(pSetup2a);
            cSetup2a.BackgroundColor = color_White;
            cSetup2a.VerticalAlignment = Element.ALIGN_TOP;
            cSetup2a.HorizontalAlignment = Element.ALIGN_LEFT;
            cSetup2a.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tableAction1.AddCell(cSetup2a);
            pSetup2a = new Phrase(row["ACTIONS" + iAction].ToString());
            pSetup2a.Font.Color = color_Black;
            pSetup2a.Font.SetFamily("Arial");
            pSetup2a.Font.SetStyle("normal");
            pSetup2a.Font.Size = iNormalFontSize;
            cSetup2a = new PdfPCell(pSetup2a);
            cSetup2a.BackgroundColor = color_White;
            cSetup2a.VerticalAlignment = Element.ALIGN_TOP;
            cSetup2a.HorizontalAlignment = Element.ALIGN_LEFT;
            cSetup2a.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tableAction1.AddCell(cSetup2a);
            PdfPCell cSetup2b = new PdfPCell();
            cSetup2b.BackgroundColor = color_White;
            cSetup2b.VerticalAlignment = Element.ALIGN_TOP;
            cSetup2b.HorizontalAlignment = Element.ALIGN_LEFT;
            cSetup2b.Border = iTextSharp.text.Rectangle.NO_BORDER;
            cSetup2b.AddElement(tableAction1);
            tableSetup.AddCell(cSetup2b);

            tableAction1 = new PdfPTable(1);
            tableAction1.WidthPercentage = 100;
            tableAction1.SetWidths(new Single[] { 1 });
            tableAction1.SpacingBefore = 0;
            pSetup2a = new Phrase("         ");
            pSetup2a.Font.Color = color_Maroon;
            pSetup2a.Font.SetFamily("Arial");
            //pSetup2a.Font.SetStyle("bold,underline");
            pSetup2a.Font.Size = iNormalFontSize;
            cSetup2a = new PdfPCell(pSetup2a);
            cSetup2a.BackgroundColor = color_White;
            cSetup2a.VerticalAlignment = Element.ALIGN_TOP;
            cSetup2a.HorizontalAlignment = Element.ALIGN_LEFT;
            cSetup2a.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tableAction1.AddCell(cSetup2a);
            pSetup2a = new Phrase(row["COMM" + iAction].ToString());
            pSetup2a.Font.Color = color_DarkGreen;
            pSetup2a.Font.SetFamily("Arial");
            pSetup2a.Font.SetStyle("italic");
            pSetup2a.Font.Size = iNormalFontSize;
            cSetup2a = new PdfPCell(pSetup2a);
            cSetup2a.BackgroundColor = color_White;
            cSetup2a.VerticalAlignment = Element.ALIGN_TOP;
            cSetup2a.HorizontalAlignment = Element.ALIGN_LEFT;
            cSetup2a.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tableAction1.AddCell(cSetup2a);
            cSetup2b = new PdfPCell();
            cSetup2b.BackgroundColor = color_White;
            cSetup2b.VerticalAlignment = Element.ALIGN_TOP;
            cSetup2b.HorizontalAlignment = Element.ALIGN_LEFT;
            cSetup2b.Border = iTextSharp.text.Rectangle.NO_BORDER;
            cSetup2b.AddElement(tableAction1);
            tableSetup.AddCell(cSetup2b);
            //pSetup3 = new Phrase(row["COMM" + iAction].ToString());
            //pSetup3.Font.Color = color_DarkGreen;
            //pSetup3.Font.SetFamily("Arial");
            //pSetup3.Font.SetStyle("italic");
            //pSetup3.Font.Size = iNormalFontSize;
            //cSetup3 = new PdfPCell(pSetup3);
            //cSetup3.BackgroundColor = color_White;
            //cSetup3.VerticalAlignment = Element.ALIGN_TOP;
            //cSetup3.HorizontalAlignment = Element.ALIGN_LEFT;
            //cSetup3.Border = iTextSharp.text.Rectangle.NO_BORDER;
            //tableSetup.AddCell(cSetup3);

            return tableSetup;

        }


        public static string Justify_Fuel(string sIn) {
            string sReturn = "";
            // check or make = 000.0
            if (sIn.Length < 5) {
                if (sIn.Length == 4) {
                    // add space
                    sReturn = " " + sIn;
                } else if (sIn.Length == 3) {
                    // add space
                    sReturn = "  " + sIn;
                } else if (sIn.Length == 2) {
                    // add space
                    sReturn = "  0" + sIn;
                }
            }
            return sReturn;
        }

        public static DataTable ToDataTable(List<Script> iList) {
            DataTable dataTable = new DataTable();
            PropertyDescriptorCollection propertyDescriptorCollection = TypeDescriptor.GetProperties(typeof(Script));
            for (int i = 0; i < propertyDescriptorCollection.Count; i++) {
                PropertyDescriptor propertyDescriptor = propertyDescriptorCollection[i];
                Type type = propertyDescriptor.PropertyType;

                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    type = Nullable.GetUnderlyingType(type);

                dataTable.Columns.Add(propertyDescriptor.Name, type);
            }
            object[] values = new object[propertyDescriptorCollection.Count];
            foreach (Script iListItem in iList) {
                for (int i = 0; i < values.Length; i++) {
                    values[i] = propertyDescriptorCollection[i].GetValue(iListItem);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        private static void RTF2String(PdfWriter pdfWriter, Document pdfDocument, string sRTF) {
            string sHTML = RtfToHtmlConverter.ConvertRtfToHtml(sRTF);
            using (var ms = new MemoryStream()) {
                //XMLWorker also reads from a TextReader and not directly from a string
                using (var srHtml = new StringReader(sHTML)) {
                    //Parse the HTML to the document
                    XMLWorkerHelper.GetInstance().ParseXHtml(pdfWriter, pdfDocument, srHtml);
                }
            }
        }
        static string BytesToStringConverted(byte[] bytes) {
            using (var stream = new MemoryStream(bytes)) {
                using (var streamReader = new StreamReader(stream)) {
                    return streamReader.ReadToEnd();
                }
            }
        }

        // HEADER AND FOOTER
        public class ITextEvents : PdfPageEventHelper {

            // This is the contentbyte object of the writer
            PdfContentByte cb;
            // we will put the final number of pages in a template
            PdfTemplate headerTemplate, footerTemplate;
            // this is the BaseFont we are going to use for the header / footer
            BaseFont bf = null;
            // This keeps track of the creation time
            DateTime PrintTime = DateTime.Now;

            #region Fields
            private string _header;
            #endregion
            #region Properties
            public string Header {
                get {
                    return _header;
                }
                set {
                    _header = value;
                }
            }
            #endregion

            public override void OnOpenDocument(PdfWriter writer, Document document) {
                try {
                    PrintTime = DateTime.Now;
                    bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    cb = writer.DirectContent;
                    headerTemplate = cb.CreateTemplate(100, 100);
                    footerTemplate = cb.CreateTemplate(30, 30);
                } catch (DocumentException de) {
                    throw;
                } catch (System.IO.IOException ioe) {
                    throw;
                }
            }

            public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document) {
                base.OnEndPage(writer, document);

                // do not print if title page
                if (!bHeaderFooter)
                    return;

                iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

                Phrase p1Header = new Phrase(GlobalCode.sCARRIER + " - Flight Training", baseFontBig);

                iTextSharp.text.Image png = null;
                if (GlobalCode.sPATH_LOGO!= "" && File.Exists(GlobalCode.sPATH_LOGO)) {
                    // use selected image on cover
                    System.Drawing.Image test1 = System.Drawing.Image.FromFile(GlobalCode.sPATH_LOGO);
                    png = iTextSharp.text.Image.GetInstance(test1, System.Drawing.Imaging.ImageFormat.Png);
                } else {
                    // use resource
                    System.Drawing.Image test1 = System.Drawing.Image.FromHbitmap(Properties.Resources.aa_logo_only.GetHbitmap());
                    png = iTextSharp.text.Image.GetInstance(test1, System.Drawing.Imaging.ImageFormat.Png);

                }

                if (png.Height > png.Width) {
                    //Maximum height is 800 pixels.
                    float percentage = 0.0f;
                    percentage = 35 / png.Height;
                    png.ScalePercent(percentage * 100);
                } else {
                    //Maximum width is 600 pixels.
                    float percentage = 0.0f;
                    percentage = 25 / png.Width;
                    png.ScalePercent(percentage * 100);
                }

                //png.ScalePercent(5f);
                png.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
                png.Alignment = iTextSharp.text.Image.ALIGN_CENTER;

                //Create PdfTable object (3 columns)
                PdfPTable pdfTab = new PdfPTable(3);

                //Row 1
                PdfPCell pdfCell1 = new PdfPCell();
                PdfPCell pdfCell2 = new PdfPCell(p1Header);
                PdfPCell pdfCell3 = new PdfPCell(png);

                //Row 2
                PdfPCell pdfCell4 = new PdfPCell();
                PdfPCell pdfCell5 = new PdfPCell(new Phrase(sDocTitle, baseFontBig));
                //PdfPCell pdfCell6 = new PdfPCell();

                //Row 3
                PdfPCell pdfCell7 = new PdfPCell();
                PdfPCell pdfCell8 = new PdfPCell();
                //PdfPCell pdfCell9 = new PdfPCell();

                pdfCell3.Rowspan = 3;

                //set the alignment of all three cells and set border to 0
                pdfCell1.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT;
                pdfCell4.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell5.HorizontalAlignment = Element.ALIGN_CENTER;
                //pdfCell6.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell7.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell8.HorizontalAlignment = Element.ALIGN_CENTER;
                //pdfCell9.HorizontalAlignment = Element.ALIGN_CENTER;

                pdfCell2.VerticalAlignment = Element.ALIGN_BOTTOM;
                pdfCell3.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell4.VerticalAlignment = Element.ALIGN_TOP;
                pdfCell5.VerticalAlignment = Element.ALIGN_MIDDLE;
                //pdfCell6.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell7.VerticalAlignment = Element.ALIGN_MIDDLE;

                //pdfCell4.Colspan = 3;

                pdfCell1.Border = 0;
                pdfCell2.Border = 0;
                pdfCell3.Border = 0;
                pdfCell4.Border = 0;
                pdfCell5.Border = 0;
                //pdfCell6.Border = 0;
                pdfCell7.Border = 0;
                pdfCell8.Border = 0;
                //pdfCell9.Border = 0;

                //add all three rows into PdfTable
                pdfTab.AddCell(pdfCell1);
                pdfTab.AddCell(pdfCell2);
                pdfTab.AddCell(pdfCell3);
                pdfTab.AddCell(pdfCell4);
                pdfTab.AddCell(pdfCell5);
                //pdfTab.AddCell(pdfCell6);
                pdfTab.AddCell(pdfCell7);
                pdfTab.AddCell(pdfCell8);
                //pdfTab.AddCell(pdfCell9);

                pdfTab.TotalWidth = document.PageSize.Width;
                pdfTab.WidthPercentage = 100;
                
                //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
                //first param is start row. -1 indicates there is no end row and all the rows to be included to write
                //Third and fourth param is x and y position to start writing
                //pdfTab.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, writer.DirectContent);
                pdfTab.WriteSelectedRows(0, -1, 0, document.PageSize.Height, writer.DirectContent);

                // FOOTER
                String sPageNum = "";
                // print page number
                if (bFooterPgNums)
                    sPageNum = "" + writer.PageNumber;

                String sCreated = "VERSION " + sEdition + "   " + GetDateString(DateTime.Now);

                //Create PdfTable object (3 columns)
                PdfPTable pdfTabF = new PdfPTable(3);

                //Row 1
                PdfPCell pdfCellF1 = new PdfPCell(new Phrase(sCreated, baseFontNormal));
                PdfPCell pdfCellF2 = new PdfPCell(new Phrase(sPageNum, baseFontNormal));
                PdfPCell pdfCellF3 = new PdfPCell(new Phrase(sDocSection, baseFontNormal));
                //Row 2
                PdfPCell pdfCellF4 = new PdfPCell();
                PdfPCell pdfCellF5 = new PdfPCell();
                PdfPCell pdfCellF6 = new PdfPCell();
                //Row 3
                PdfPCell pdfCellF7 = new PdfPCell();
                PdfPCell pdfCellF8 = new PdfPCell();
                PdfPCell pdfCellF9 = new PdfPCell();

                //set the alignment of all three cells and set border to 0
                pdfCellF1.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCellF2.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCellF3.HorizontalAlignment = Element.ALIGN_RIGHT;
                pdfCellF4.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCellF5.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCellF6.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCellF7.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCellF8.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCellF9.HorizontalAlignment = Element.ALIGN_CENTER;

                pdfCellF1.VerticalAlignment = Element.ALIGN_TOP;
                pdfCellF2.VerticalAlignment = Element.ALIGN_TOP;
                pdfCellF3.VerticalAlignment = Element.ALIGN_TOP;
                pdfCellF4.VerticalAlignment = Element.ALIGN_TOP;
                pdfCellF5.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCellF6.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCellF7.VerticalAlignment = Element.ALIGN_MIDDLE;

                //pdfCell4.Colspan = 3;

                pdfCellF1.Border = 0;
                pdfCellF2.Border = 0;
                pdfCellF3.Border = 0;
                pdfCellF4.Border = 0;
                pdfCellF5.Border = 0;
                pdfCellF6.Border = 0;
                pdfCellF7.Border = 0;
                pdfCellF8.Border = 0;
                pdfCellF9.Border = 0;

                //add all three rows into PdfTable
                pdfTabF.AddCell(pdfCellF1);
                pdfTabF.AddCell(pdfCellF2);
                pdfTabF.AddCell(pdfCellF3);
                pdfTabF.AddCell(pdfCellF4);
                pdfTabF.AddCell(pdfCellF5);
                pdfTabF.AddCell(pdfCellF6);
                pdfTabF.AddCell(pdfCellF7);
                pdfTabF.AddCell(pdfCellF8);
                pdfTabF.AddCell(pdfCellF9);

                pdfTabF.TotalWidth = document.PageSize.Width-40;
                pdfTabF.WidthPercentage = 100;

                //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
                //first param is start row. -1 indicates there is no end row and all the rows to be included to write
                //Third and fourth param is x and y position to start writing
                //pdfTab.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, writer.DirectContent);
                pdfTabF.WriteSelectedRows(0, -1, 0, 20, writer.DirectContent);

                ////Add paging to footer
                //{
                //    cb.BeginText();
                //    cb.SetFontAndSize(bf, 10);
                //    cb.SetTextMatrix(document.PageSize.GetRight(50), document.PageSize.GetBottom(5));
                //    cb.ShowText(text);
                //    cb.EndText();
                //    cb.BeginText();
                //    cb.SetFontAndSize(bf, 10);
                //    cb.SetTextMatrix(document.PageSize.GetLeft(30), document.PageSize.GetBottom(5));
                //    cb.ShowText(sCreated);
                //    cb.EndText();
                //    float len = bf.GetWidthPoint(text, 12);
                //    cb.AddTemplate(footerTemplate, document.PageSize.GetRight(60) + len, document.PageSize.GetBottom(5));
                //}


                //Move the pointer and draw line to separate header section from rest of page
                cb.MoveTo(20, document.PageSize.Height - 40);
                cb.LineTo(document.PageSize.Width - 20, document.PageSize.Height - 40);
                cb.Stroke();

                //Move the pointer and draw line to separate footer section from rest of page
                cb.MoveTo(20, document.PageSize.GetBottom(30));
                cb.LineTo(document.PageSize.Width - 20, document.PageSize.GetBottom(30));
                cb.Stroke();
            }

            public override void OnCloseDocument(PdfWriter writer, Document document) {
                base.OnCloseDocument(writer, document);

                headerTemplate.BeginText();
                headerTemplate.SetFontAndSize(bf, 10);
                headerTemplate.SetTextMatrix(0, 0);
                headerTemplate.ShowText((writer.PageNumber - 1).ToString());
                headerTemplate.EndText();

                //footerTemplate.BeginText();
                //footerTemplate.SetFontAndSize(bf, 10);
                //footerTemplate.SetTextMatrix(0, 0);
                //footerTemplate.ShowText((writer.PageNumber - 1).ToString());
                //footerTemplate.EndText();


            }
        }
        private static string GetDateString(DateTime d) {
            try {
                object value = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
                DateTime result = (DateTime)value;
                string sResult = result.ToString("ddMMMyyyy");
                return sResult;
            } catch (Exception) {
                throw;
            }
        }

        public class TOCEvents : PdfPageEventHelper {

            private Dictionary<string, KeyValuePair<string, int>> toc = new Dictionary<string, KeyValuePair<string, int>>();
            private int counter = 0;

            public override void OnGenericTag(PdfWriter pdfWriter, Document document, iTextSharp.text.Rectangle rect, string text) {
                base.OnGenericTag(pdfWriter, document, rect, text);
                KeyValuePair<string, int> iActualValue;
                if (!toc.TryGetValue(text, out iActualValue)) {
                    // key not set yet
                    string name = "dest" + (counter++);
                    int pdfPage = pdfWriter.PageNumber;
                    toc.Add(text, new KeyValuePair<string, int>(name, pdfPage));
                    pdfWriter.AddNamedDestination(name, pdfPage, new PdfDestination(PdfDestination.FITH, rect.GetTop(0)));
                }
            }
            public Dictionary<string, KeyValuePair<string, int>> GetTOC() {
                return toc;
            }
        }

        public static PushbuttonField AddButton(Document pdfDocument, PdfWriter PdfWriter, iTextSharp.text.Rectangle pdfPage, string sText, string entry) {
            using (pdfDocument) {
                using (PdfWriter) {
                    //PdfContentByte cb = PdfWriter.DirectContent;
                    iTextSharp.text.Rectangle _rect;
                    //PdfFormField _Field1;

                    _rect = new iTextSharp.text.Rectangle(100, 806, 170, 788);
                    PushbuttonField button = new PushbuttonField(PdfWriter, _rect, "Buttons");
                    button.BackgroundColor = new GrayColor(0.75f);
                    button.BorderColor = GrayColor.GRAYBLACK;
                    button.BorderWidth = 1;
                    button.BorderStyle = PdfBorderDictionary.STYLE_BEVELED;
                    button.TextColor = GrayColor.GRAYBLACK;
                    button.FontSize = 12;
                    button.Text = sText;
                    button.Layout = PushbuttonField.LAYOUT_ICON_LEFT_LABEL_RIGHT;
                    button.ScaleIcon = PushbuttonField.SCALE_ICON_ALWAYS;
                    button.ProportionalIcon = true;
                    button.IconHorizontalAdjustment = 0;
                    //_Field1 = button.Field;
                    //PdfWriter.AddAnnotation(_Field1);
                    //cb = PdfWriter.DirectContent;
                    var f = button.Field;
                    PdfAppearance theButton = button.GetAppearance();
                    f.Action = PdfAction.GotoLocalPage(entry, false);
                    return button;
                }
            }
        }
    }

}
