using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSupergoo.ABCpdf10;
using WebSupergoo.ABCpdf10.Objects;
using WebSupergoo.ABCpdf10.Atoms;
using WebSupergoo.ABCpdf10.Operations;
using System.Data;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;

namespace WindowsFormsApplication1 {
    class AbcPDF {

        static Doc pdfDocument = new Doc();

        // document title (this will need to be set in the app prefs)
        static string sDocTitle = "A350 I/E TRAINING GUIDE ";
        static string strPath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);

        // create fonts and colors
        static int iNormalFontSize = 10;
        static int iATISFontSize = 11;
        static int iFMCFontSize = 12;

        static string color_Black = "00, 00, 00";
        static string color_DarkGreen = "48, 128, 20";
        static string color_DarkBlue = "0, 178, 238";
        //static BaseColor color_Cyan = BaseColor.CYAN;
        static string color_Maroon = "128, 0, 0";
        static string color_Yellow = "255, 255, 0";
        static string background_grey = "190, 190, 190";
        static string background_white = "255, 255, 255";
        static string background_gold = "255, 210, 48";
        static string background_breakgreen = "144, 238, 144";

        static string color_grid_blue = "0, 0, 200";
        static string color_grid_violet = "113, 113, 198";
        static string color_grid_purple = "138, 43, 226";
        static string color_grid_ltblue = "202, 225, 255";
        static string color_grid_goldenrod = "255, 193, 37";

        static int iPageNumber = 0;
        static int iPid;

        static int iTextID;

        // create fonts
        static int fontLucida = pdfDocument.EmbedFont("Lucida", LanguageType.Latin, false, true);
        static int fontArialBold = pdfDocument.EmbedFont("Arial Bold", LanguageType.Latin, false, true);
        static int fontArial = pdfDocument.EmbedFont("Arial", LanguageType.Latin, false, true);

        private static void Create_Title_Page(string sTitle) {

            // set the rect to the page size
            pdfDocument.Rect.String = pdfDocument.MediaBox.String;
            // inset the rect
            pdfDocument.Rect.Inset(5, 5);

            //pdfDocument.FrameRect();

            
            string chunk = "";

            chunk = sTitle;
            pdfDocument.Font = fontArialBold;
            pdfDocument .FontSize = 26;
            pdfDocument.Color.String = color_Maroon;
            pdfDocument.TextStyle.HPos = .5;
            pdfDocument.Pos.Y = pdfDocument.MediaBox.Top - 100;
            iPid = pdfDocument.AddText(chunk);

            chunk = "\n\nQUAL / CQ / R1S / REQ";
            pdfDocument.Font = fontArial;
            pdfDocument.FontSize = 18;
            pdfDocument.Color.String = color_Black;
            pdfDocument.TextStyle.HPos = .5;
            iPid = pdfDocument.AddText(chunk);

            chunk = "\nEDITION 1";
            pdfDocument.Font = fontArial;
            pdfDocument.FontSize = 14;
            pdfDocument.Color.String = color_Black;
            pdfDocument.Pos.Y = pdfDocument.MediaBox.Bottom + 50;
            pdfDocument.TextStyle.HPos = .5;
            iPid = pdfDocument.AddText(chunk);

            using (XImage xi = XImage.FromFile(strPath + "\\a350.png", null)) {
                double iH = pdfDocument.Rect.Width / xi.Width;
                pdfDocument.Rect.Resize(pdfDocument.MediaBox.Width, xi.Height * iH);
                pdfDocument.Rect.Move(0, (pdfDocument.MediaBox.Height / 2) -(pdfDocument.Rect.Height/2));
                pdfDocument.AddImageObject(xi, true);
            }
            //pdfDocument.FrameRect();


            // new pdfPage
            pdfDocument.Page = pdfDocument.AddPage();
        }

        private static Doc AddHeader(Doc theDoc) {
            int theCount = theDoc.PageCount;
            int i = 0;

            //Image header 
            //for (i = 1; i <= theCount; i++) {
            //    theDoc.Rect.Width = 612;
            //    theDoc.Rect.Height = 100;
            //    theDoc.Rect.Position(0, 692);
            //    theDoc.PageNumber = i;
            //}

            //Blue header box
            for (i = 2; i <= theCount; i++) {
                theDoc.Rect.String = "0, 0, 612, 792";
                theDoc.Rect.Position(0, 742);
                System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#468DCB");
                theDoc.Color.Color = c;
                theDoc.PageNumber = i;
                theDoc.FillRect();
            }

            //Blue header text
            for (i = 2; i <= theCount; i++) {
                theDoc.Rect.String = "0, 0, 612, 792";
                theDoc.Rect.Position(0, 742);
                System.Drawing.Color cText = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                theDoc.Color.Color = cText;
                string theFont = "Century Gothic";
                theDoc.Font = theDoc.AddFont(theFont);
                theDoc.FontSize = 14;
                theDoc.PageNumber = i;
                theDoc.AddText("Your Text Here");
            }
            return theDoc;
        }
        //public static void Generate_PDF() {
        //    // default document size is 612 by 792
        //    // "left bottom right top"

        //    // Instantiate the ScriptData class.
        //    ScriptData m_SimScript = new ScriptData();
        //    // get the data and convert to datatable
        //    List<Script> m_Script = new List<Script>(m_SimScript.GetScriptData());
        //    DataTable dt = ToDataTable(m_Script);

        //    // create envirenmemt to save the pdf
        //    string sFile = strPath + "\\AA Training Test.pdf";
        //    //FileStream fs = new FileStream(sFile, FileMode.Create, FileAccess.Write, FileShare.None);


        //    // set pdfPage type (letter)
        //    //iTextSharp.text.Rectangle pdfRectangle = new iTextSharp.text.Rectangle(PageSize.LETTER);
        //    // create document and set margins in points (72pts/inch)
        //    // set the page size
        //    pdfDocument.MediaBox.String = "0, 0, 612, 792";
        //    // set the rect to the page size
        //    pdfDocument.Rect.String = pdfDocument.MediaBox.String;//pdfDocument.MediaBox.String;
        //    // inset the rect
        //    pdfDocument.Rect.Inset(5, 0);


        //    // create the pdf pdfWriter
        //    //PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDocument, fs);

        //    // instantiate the TOC
        //    //TOCEvents pdfEventTOC = new TOCEvents();
        //    //pdfWriter.PageEvent = pdfEventTOC;

        //    // open the document
        //    //pdfDocument.Open();
        //    //pdfWriter.SetLinearPageMode();

        //    // create a pdfPage rectange=le (the entire sheet)
        //    //iTextSharp.text.Rectangle pdfPage = pdfDocument.PageSize;

        //    // create document outline
        //    // start with the root of the tree
        //    //olRoot = pdfWriter.RootOutline;

        //    // create the title page
        //    Create_Title_Page(sDocTitle);


        //    // get the preamble data
        //    string sLessonTitle = "";
        //    string sLessonSubTitle = "";
        //    string sLessonPreambleTitle1 = "";
        //    string sLessonPreambleText1 = "";
        //    string sLessonPreambleTitle2 = "";
        //    string sLessonPreambleText2 = "";
        //    string sLessonPreambleTitle3 = "";
        //    string sLessonPreambleText3 = "";
        //    int iCountx = 0;
        //    foreach (DataRow row in dt.Rows) {
        //        iCountx++;
        //        if (iCountx == 1) {
        //            sLessonTitle = row["TEXT_TITLE"].ToString();
        //            sLessonSubTitle = "AAL" + row["FLTNUM"].ToString() + " (" + row["DEP"].ToString() + "-" + row["DEST"].ToString() + ")";
        //            sLessonPreambleTitle1 = row["PREAMBLE_TITLE_1"].ToString();
        //            sLessonPreambleText1 = row["PREAMBLE_TEXT_1"].ToString();
        //            sLessonPreambleTitle2 = row["PREAMBLE_TITLE_2"].ToString();
        //            sLessonPreambleText2 = row["PREAMBLE_TEXT_2"].ToString();
        //            sLessonPreambleTitle3 = row["PREAMBLE_TITLE_3"].ToString();
        //            sLessonPreambleText3 = row["PREAMBLE_TEXT_3"].ToString();
        //        }
        //    }

        //    string sLessonTitleSummary = sLessonTitle + " SUMMARY \n" + sLessonSubTitle;
        //    string sLessonTitlePreamble = sLessonTitle + "\n" + sLessonSubTitle;

        //    // record pdfPage TOC event
        //    pdfDocument.Bookmark.Add(sLessonSubTitle);

        //    // insert pdfPage header
        //    //pdfDocument.Add(Page_Header(pdfPage, sLessonTitle, olRoot, pdfWriter, sLessonTitleSummary, true));
        //    // sSPOT + ": " + sManeuver

        //    if (sLessonPreambleText1 != "" || sLessonPreambleText2 != "" || sLessonPreambleText3 != "") {
        //        // LESSON TITLE AND PREAMBLE pdfPage
                
        //        //pdfDocument.Rect.Inset(5, 5);
                
        //        // lesson title
        //        string chunk = "";

        //        pdfDocument.Rect.String = "0, 0, 612, 742";// "left bottom right top" size = 612w x 792h
        //        double dRectPos = pdfDocument.Rect.Top;

        //        //pdfDocument.Rect.Width = 590;
        //        //pdfDocument.Rect.Position(0, 706);

        //        chunk = sLessonTitlePreamble;
        //        pdfDocument.Font = fontArialBold;
        //        pdfDocument.FontSize = 14;
        //        pdfDocument.Color.String = color_Maroon;
        //        pdfDocument.TextStyle.HPos = .5;
        //        pdfDocument.Pos.Y = dRectPos;// pdfDocument.MediaBox.Top - 50;
        //        iPid = pdfDocument.AddText(chunk);
        //        pdfDocument.FrameRect();

        //        //dRectPos = pdfDocument.Pos pdfDocument.Rect.Bottom;

        //        // lesson preamble
        //        if (sLessonPreambleTitle1 != "") {
        //            chunk = "\n\n" + sLessonPreambleTitle1;
        //            pdfDocument.Pos.Y = dRectPos;
        //            pdfDocument.Font = fontArialBold;
        //            pdfDocument.FontSize = 10;
        //            pdfDocument.TextStyle.HPos = 0;
        //            pdfDocument.Color.String = color_Black;
        //            iTextID = pdfDocument.AddText(chunk);
        //            pdfDocument.FrameRect();
        //            dRectPos = pdfDocument.Rect.Bottom;
        //        }
        //        if (sLessonPreambleText1 != "") {
        //            // convert to html
        //            string sHTML = RtfToHtmlConverter.ConvertRtfToHtml(sLessonPreambleText1);
        //            iTextID = pdfDocument.AddImageHtml(sHTML);
        //            while (true) {
        //                if (!pdfDocument.Chainable(iTextID))
        //                    break;
        //                pdfDocument.Page = pdfDocument.AddPage();
        //                iTextID = pdfDocument.AddImageToChain(iTextID);
        //            }
        //            pdfDocument.Rect.Position(0, dRectPos);
        //            dRectPos = pdfDocument.Rect.Bottom;
        //            pdfDocument.FrameRect();
        //        }
        //        if (sLessonPreambleTitle1 != "") {
        //            chunk = "\n\n" + sLessonPreambleTitle1;
        //            pdfDocument.Font = fontArialBold;
        //            pdfDocument.FontSize = 10;
        //            pdfDocument.TextStyle.HPos = 0;
        //            pdfDocument.Color.String = color_Black;
        //            iTextID = pdfDocument.AddText(chunk);
        //            pdfDocument.Rect.Position(0, dRectPos);
        //            dRectPos = pdfDocument.Rect.Bottom;
        //            pdfDocument.FrameRect();
        //        }
        //        if (sLessonPreambleText2 != "") {
        //            // convert to html
        //            pdfDocument.Rect.Top = pdfDocument.MediaBox.Top - 100;
        //            string sHTML = RtfToHtmlConverter.ConvertRtfToHtml(sLessonPreambleText1);
        //            iTextID = pdfDocument.AddImageHtml(sHTML);
        //            while (true) {
        //                if (!pdfDocument.Chainable(iTextID))
        //                    break;
        //                pdfDocument.Page = pdfDocument.AddPage();
        //                iTextID = pdfDocument.AddImageToChain(iTextID);
        //            }
        //            pdfDocument.Rect.Position(0, dRectPos);
        //            dRectPos = pdfDocument.Rect.Bottom;
        //            pdfDocument.FrameRect();
        //        }
        //        if (sLessonPreambleTitle3 != "") {
        //            chunk = "<br><br>" + sLessonPreambleTitle3;
        //            pdfDocument.Font = fontArialBold;
        //            pdfDocument.FontSize = 12;
        //            pdfDocument.Color.String = color_Maroon;
        //            iPid = pdfDocument.AddHtml(chunk);
        //        }
        //        if (sLessonPreambleText3 != "") {
        //            chunk = "<br>" + sLessonPreambleText3;
        //            pdfDocument.Font = fontArial;
        //            pdfDocument.FontSize = 9;
        //            pdfDocument.Color.String = color_Black;
        //            iPid = pdfDocument.AddHtml(chunk);
        //        }

        //        //pdfDocument.FrameRect();

        //        // new pdfPage
        //        pdfDocument.Page = pdfDocument.AddPage();


        //    }


        //    /*
        //     * 
        //    // record pdfPage TOC event
        //    chunkTOC = new Chunk(sLessonTitleSummary);
        //    chunkTOC.SetGenericTag(sLessonTitle + "- SUMMARY");

        //    // SUMMARY pdfPage
        //    Paragraph pgTitleSummary = new Paragraph(chunkTOC);
        //    pgTitleSummary.Font.SetFamily("Arial");
        //    pgTitleSummary.Font.SetStyle("bold");
        //    pgTitleSummary.Font.Size = 14;
        //    pgTitleSummary.Font.Color = color_Maroon;
        //    pgTitleSummary.Alignment = Element.ALIGN_CENTER;
        //    pgTitleSummary.SpacingAfter = 20;
        //    pdfDocument.Add(pgTitleSummary);


        //    // summary table
        //    string[] col = { "", "PF", "TIME", "MANEUVER" };
        //    PdfPTable tableSummary = new PdfPTable(4);
        //    tableSummary.WidthPercentage = 100;
        //    // then set the column's __relative__ widths
        //    tableSummary.SetWidths(new Single[] { 2, 2, 1, 10 });
        //    tableSummary.SpacingBefore = 10;
        //    // summary table header
        //    for (int i = 0; i < col.Length; ++i) {
        //        Phrase pPhrase = new Phrase(col[i]);
        //        pPhrase.Font.Color = color_Black;
        //        pPhrase.Font.SetFamily("Arial");
        //        pPhrase.Font.SetStyle("bold");
        //        PdfPCell cell = new PdfPCell(new Phrase(pPhrase));
        //        cell.BackgroundColor = background_gold;
        //        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //        cell.VerticalAlignment = Element.ALIGN_TOP;
        //        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //        tableSummary.AddCell(cell);
        //    }
        //    // summary data
        //    string sEntTime = "";
        //    foreach (DataRow row in dt.Rows) {
        //        string sPF = row["PF1"].ToString();
        //        string sManeuver = row["MANEUVER"].ToString();

        //        if (sManeuver.IndexOf("BREAK FOR") > -1) {
        //            Phrase pPhrase5 = new Phrase(sManeuver);
        //            PdfPCell c5 = new PdfPCell(pPhrase5);
        //            c5.Colspan = 4;
        //            c5.BackgroundColor = background_breakgreen;
        //            c5.VerticalAlignment = Element.ALIGN_MIDDLE;
        //            c5.HorizontalAlignment = Element.ALIGN_CENTER;
        //            tableSummary.AddCell(c5);
        //        } else {
        //            Phrase pPhrase1 = new Phrase(row["SPOT"].ToString());
        //            pPhrase1.Font.Color = color_Black;
        //            pPhrase1.Font.SetFamily("Arial");
        //            pPhrase1.Font.SetStyle("normal");
        //            PdfPCell c1 = new PdfPCell(pPhrase1);
        //            c1.BackgroundColor = background_white;
        //            c1.VerticalAlignment = Element.ALIGN_MIDDLE;
        //            c1.HorizontalAlignment = Element.ALIGN_CENTER;
        //            tableSummary.AddCell(c1);

        //            Phrase pPhrase2 = new Phrase(sPF);
        //            pPhrase2.Font.Color = color_Black;
        //            pPhrase2.Font.SetFamily("Arial");
        //            pPhrase2.Font.SetStyle("normal");
        //            PdfPCell c2 = new PdfPCell(pPhrase2);
        //            if (sPF == "PILOT A" || sPF == "CA") {
        //                pPhrase2.Font.Color = color_White;
        //                c2.BackgroundColor = new BaseColor(71, 0, 255);
        //            } else if (sPF == "PILOT B" || sPF == "FO") {
        //                pPhrase2.Font.Color = color_White;
        //                c2.BackgroundColor = new BaseColor(101, 0, 185);
        //            } else if (sPF == "EITHER") {
        //                pPhrase2.Font.Color = color_White;
        //                c2.BackgroundColor = new BaseColor(70, 200, 255);
        //            } else if (sPF == "BOTH") {
        //                pPhrase2.Font.Color = color_White;
        //                c2.BackgroundColor = new BaseColor(200, 200, 100);
        //            }
        //            c2.VerticalAlignment = Element.ALIGN_MIDDLE;
        //            c2.HorizontalAlignment = Element.ALIGN_CENTER;
        //            tableSummary.AddCell(c2);

        //            Phrase pPhrase3 = new Phrase(row["TIME_SPOT"].ToString());
        //            pPhrase3.Font.Color = color_Black;
        //            pPhrase3.Font.SetFamily("Arial");
        //            pPhrase3.Font.SetStyle("normal");
        //            PdfPCell c3 = new PdfPCell(pPhrase3);
        //            c3.BackgroundColor = background_white;
        //            c3.VerticalAlignment = Element.ALIGN_MIDDLE;
        //            c3.HorizontalAlignment = Element.ALIGN_CENTER;
        //            tableSummary.AddCell(c3);

        //            Phrase pPhrase4 = new Phrase(sManeuver);
        //            pPhrase4.Font.Color = color_Black;
        //            pPhrase4.Font.SetFamily("Arial");
        //            pPhrase4.Font.SetStyle("normal");
        //            PdfPCell c4 = new PdfPCell(pPhrase4);
        //            c4.BackgroundColor = background_white;
        //            c4.VerticalAlignment = Element.ALIGN_MIDDLE;
        //            c4.HorizontalAlignment = Element.ALIGN_LEFT;
        //            tableSummary.AddCell(c4);
        //        }
        //        sEntTime = row["TIME_END"].ToString();
        //    }
        //    // summary table footer
        //    Phrase pPhrase6 = new Phrase("");
        //    PdfPCell c6 = new PdfPCell(pPhrase6);
        //    c6.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //    c6.BackgroundColor = background_gold;
        //    tableSummary.AddCell(c6);
        //    Phrase pPhrase8 = new Phrase(sEntTime);
        //    PdfPCell c8 = new PdfPCell(pPhrase8);
        //    c8.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //    c8.BackgroundColor = background_gold;
        //    c8.VerticalAlignment = Element.ALIGN_MIDDLE;
        //    c8.HorizontalAlignment = Element.ALIGN_RIGHT;
        //    c8.Colspan = 2;
        //    tableSummary.AddCell(c8);
        //    PdfPCell c7 = new PdfPCell(pPhrase6);
        //    c7.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //    c7.BackgroundColor = background_gold;
        //    tableSummary.AddCell(c7);

        //    pdfDocument.Add(tableSummary);

        //    // SPOTS
        //    int iRowCounter = 0;
        //    int iRowCount = dt.Rows.Count;
        //    foreach (DataRow row in dt.Rows) {
        //        string sPF = row["PF1"].ToString();
        //        string sManeuver = row["MANEUVER"].ToString();
        //        string sSPOT = row["SPOT"].ToString();

        //        //                PdfOutline olLessonSPOTS;

        //        iRowCounter++;
        //        // start new pdfPage
        //        pdfDocument.NewPage();

        //        if (sManeuver.IndexOf("BREAK FOR") > -1) {
        //            // BREAK //

        //            // insert pdfPage header
        //            pdfDocument.Add(Page_Header(pdfPage, sLessonTitle, olRoot, pdfWriter, "", false));

        //            // header
        //            PdfPTable tableSPOTHeader = new PdfPTable(1);
        //            tableSPOTHeader.WidthPercentage = 100;
        //            tableSPOTHeader.SpacingBefore = 1;
        //            Phrase pPhrase1 = new Phrase(sManeuver);
        //            pPhrase1.Font.Color = color_Black;
        //            pPhrase1.Font.SetFamily("Arial");
        //            pPhrase1.Font.SetStyle("bold");
        //            pPhrase1.Font.Size = 16;
        //            PdfPCell c1 = new PdfPCell(pPhrase1);
        //            c1.BackgroundColor = background_breakgreen;
        //            c1.VerticalAlignment = Element.ALIGN_TOP;
        //            c1.HorizontalAlignment = Element.ALIGN_CENTER;
        //            c1.BorderWidthRight = 2;
        //            c1.BorderWidthLeft = 1;
        //            c1.BorderWidthTop = 1;
        //            c1.BorderWidthBottom = 2;
        //            tableSPOTHeader.AddCell(c1);
        //            pdfDocument.Add(tableSPOTHeader);
        //        } else {
        //            // SPOTS //

        //            // insert pdfPage header
        //            pdfDocument.Add(Page_Header(pdfPage, sLessonTitle, olRoot, pdfWriter, sSPOT + ": " + sManeuver, false));

        //            // SPOT header
        //            PdfPTable tableSPOTHeader = new PdfPTable(3);
        //            tableSPOTHeader.WidthPercentage = 100;
        //            // then set the column's __relative__ widths
        //            tableSPOTHeader.SetWidths(new Single[] { 2, 8, 2 });
        //            tableSPOTHeader.SpacingBefore = 1;

        //            // record pdfPage TOC event
        //            chunkTOC = new Chunk(sSPOT);
        //            chunkTOC.SetGenericTag(sSPOT + "- " + row["MANEUVER"].ToString());

        //            Phrase pPhrase1 = new Phrase(chunkTOC);
        //            pPhrase1.Font.Color = color_Black;
        //            pPhrase1.Font.SetFamily("Arial");
        //            pPhrase1.Font.SetStyle("bold");
        //            pPhrase1.Font.Size = 22;
        //            PdfPCell c1 = new PdfPCell(pPhrase1);
        //            c1.BackgroundColor = background_gold;
        //            c1.VerticalAlignment = Element.ALIGN_TOP;
        //            c1.HorizontalAlignment = Element.ALIGN_LEFT;
        //            c1.BorderWidthRight = 0;
        //            c1.BorderWidthLeft = 1;
        //            c1.BorderWidthTop = 1;
        //            c1.BorderWidthBottom = 2;
        //            tableSPOTHeader.AddCell(c1);

        //            Phrase pPhrase2 = new Phrase(row["MANEUVER"].ToString());
        //            pPhrase2.Font.Color = color_Black;
        //            pPhrase2.Font.SetFamily("Arial");
        //            pPhrase2.Font.SetStyle("bold");
        //            pPhrase2.Font.Size = 16;
        //            PdfPCell c2 = new PdfPCell(pPhrase2);
        //            c2.BackgroundColor = background_gold;
        //            c2.VerticalAlignment = Element.ALIGN_TOP;
        //            c2.HorizontalAlignment = Element.ALIGN_LEFT;
        //            c2.BorderWidthRight = 0;
        //            c2.BorderWidthLeft = 0;
        //            c2.BorderWidthTop = 1;
        //            c2.BorderWidthBottom = 2;
        //            tableSPOTHeader.AddCell(c2);

        //            PdfPTable tableSPOTHeaderInner = new PdfPTable(1);
        //            // start time
        //            Phrase pPhraseInner1 = new Phrase(row["TIME_START"].ToString());
        //            pPhraseInner1.Font.Color = color_Black;
        //            pPhraseInner1.Font.SetFamily("Arial");
        //            pPhraseInner1.Font.SetStyle("bold");
        //            pPhraseInner1.Font.Size = 9;
        //            PdfPCell cInner1 = new PdfPCell(pPhraseInner1);
        //            cInner1.BackgroundColor = background_gold;
        //            cInner1.VerticalAlignment = Element.ALIGN_MIDDLE;
        //            cInner1.HorizontalAlignment = Element.ALIGN_RIGHT;
        //            cInner1.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //            tableSPOTHeaderInner.AddCell(cInner1);
        //            // spot time
        //            Phrase pPhraseInner2 = new Phrase(row["TIME_SPOT"].ToString());
        //            pPhraseInner2.Font.Color = color_Maroon;
        //            pPhraseInner2.Font.SetFamily("Arial");
        //            pPhraseInner2.Font.SetStyle("bold");
        //            pPhraseInner2.Font.Size = 12;
        //            PdfPCell cInner2 = new PdfPCell(pPhraseInner2);
        //            cInner2.BackgroundColor = background_gold;
        //            cInner2.VerticalAlignment = Element.ALIGN_MIDDLE;
        //            cInner2.HorizontalAlignment = Element.ALIGN_RIGHT;
        //            cInner2.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //            tableSPOTHeaderInner.AddCell(cInner2);
        //            // end time
        //            Phrase pPhraseInner3 = new Phrase(row["TIME_END"].ToString());
        //            pPhraseInner3.Font.Color = color_Black;
        //            pPhraseInner3.Font.SetFamily("Arial");
        //            pPhraseInner3.Font.SetStyle("bold");
        //            pPhraseInner3.Font.Size = 9;
        //            PdfPCell cInner3 = new PdfPCell(pPhraseInner3);
        //            cInner3.BackgroundColor = background_gold;
        //            cInner3.VerticalAlignment = Element.ALIGN_MIDDLE;
        //            cInner3.HorizontalAlignment = Element.ALIGN_RIGHT;
        //            cInner3.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //            tableSPOTHeaderInner.AddCell(cInner3);
        //            // add inner cell to outer cell
        //            PdfPCell c3 = new PdfPCell();
        //            c3.BackgroundColor = background_gold;
        //            c3.VerticalAlignment = Element.ALIGN_MIDDLE;
        //            c3.HorizontalAlignment = Element.ALIGN_RIGHT;
        //            c3.BorderWidthRight = 2;
        //            c3.BorderWidthLeft = 0;
        //            c3.BorderWidthTop = 1;
        //            c3.BorderWidthBottom = 2;
        //            c3.AddElement(tableSPOTHeaderInner);
        //            tableSPOTHeader.AddCell(c3);
        //            // add spot header
        //            pdfDocument.Add(tableSPOTHeader);

        //            // OBJECTIVE & SCOPE
        //            PdfPTable tableObjScope = new PdfPTable(2);
        //            tableObjScope.WidthPercentage = 100;
        //            // then set the column's __relative__ widths
        //            tableObjScope.SetWidths(new Single[] { 2, 10 });
        //            tableObjScope.SpacingBefore = 1;

        //            // get objective text
        //            string sObj1 = row["OBJECTIVE1"].ToString();
        //            string sObj2 = row["OBJECTIVE2"].ToString();
        //            if (sObj1 == "") {
        //                if (sObj2 != "") {
        //                    sObj1 = sObj2;
        //                }
        //            } else if (sObj2 != "") {
        //                sObj1 = sObj1 + "\n" + sObj2;
        //            }
        //            if (sObj1 != "") {
        //                // display objective
        //                Phrase pObjective = new Phrase("OBJECTIVE");
        //                pObjective.Font.Color = color_Black;
        //                pObjective.Font.SetFamily("Arial");
        //                pObjective.Font.SetStyle("bold");
        //                pObjective.Font.Size = iNormalFontSize;
        //                PdfPCell cO1 = new PdfPCell(pObjective);
        //                cO1.BackgroundColor = background_white;
        //                cO1.VerticalAlignment = Element.ALIGN_TOP;
        //                cO1.HorizontalAlignment = Element.ALIGN_RIGHT;
        //                cO1.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //                tableObjScope.AddCell(cO1);
        //                Phrase pObjective1 = new Phrase(sObj1);
        //                pObjective1.Font.Color = color_Black;
        //                pObjective1.Font.SetFamily("Arial");
        //                pObjective1.Font.SetStyle("normal");
        //                pObjective1.Font.Size = iNormalFontSize;
        //                PdfPCell cO2 = new PdfPCell(pObjective1);
        //                cO2.BackgroundColor = background_white;
        //                cO2.VerticalAlignment = Element.ALIGN_TOP;
        //                cO2.HorizontalAlignment = Element.ALIGN_LEFT;
        //                cO2.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //                tableObjScope.AddCell(cO2);
        //            }
        //            // get scope text
        //            string sScp1 = row["SCOPE1"].ToString();
        //            string sScp2 = row["SCOPE2"].ToString();
        //            if (sScp1 == "") {
        //                if (sScp2 != "") {
        //                    sScp1 = sScp2;
        //                }
        //            } else if (sScp2 != "") {
        //                sScp1 = sScp1 + "\n" + sScp2;
        //            }
        //            if (sScp1 != "") {
        //                // display scope
        //                Phrase pScope = new Phrase("SCOPE");
        //                pScope.Font.Color = color_Black;
        //                pScope.Font.SetFamily("Arial");
        //                pScope.Font.SetStyle("bold");
        //                pScope.Font.Size = iNormalFontSize;
        //                PdfPCell cO1 = new PdfPCell(pScope);
        //                cO1.BackgroundColor = background_white;//white
        //                cO1.VerticalAlignment = Element.ALIGN_TOP;
        //                cO1.HorizontalAlignment = Element.ALIGN_RIGHT;
        //                cO1.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
        //                tableObjScope.AddCell(cO1);
        //                Phrase pScope1 = new Phrase(sScp1);
        //                pScope1.Font.Color = color_Black;
        //                pScope1.Font.SetFamily("Arial");
        //                pScope1.Font.SetStyle("normal");
        //                pScope1.Font.Size = iNormalFontSize;
        //                PdfPCell cO2 = new PdfPCell(pScope1);
        //                cO2.BackgroundColor = background_white;
        //                cO2.VerticalAlignment = Element.ALIGN_TOP;
        //                cO2.HorizontalAlignment = Element.ALIGN_LEFT;
        //                cO2.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
        //                tableObjScope.AddCell(cO2);
        //            }
        //            if (sObj1 != "" || sScp1 != "") {
        //                tableObjScope.SpacingAfter = 2;
        //                pdfDocument.Add(tableObjScope);
        //            }

        //            //LineSeparator drawLine = new LineSeparator(0.0F, 100.0F, color_Black, Element.ALIGN_LEFT,-10);
        //            //pdfDocument.Add(new Chunk(drawLine));

        //            // POSITION
        //            PdfPTable tablePos = new PdfPTable(2);
        //            tablePos.WidthPercentage = 100;
        //            tablePos.SetWidths(new Single[] { 2, 10 });
        //            tablePos.SpacingBefore = 1;
        //            // sim position
        //            string sPos = row["SIM_POSITION"].ToString();
        //            if (sPos != "") {
        //                // display
        //                Phrase pScope = new Phrase("SIM POSITION");
        //                pScope.Font.Color = color_Black;
        //                pScope.Font.SetFamily("Arial");
        //                pScope.Font.SetStyle("bold");
        //                pScope.Font.Size = iNormalFontSize;
        //                PdfPCell cO1 = new PdfPCell(pScope);
        //                cO1.BackgroundColor = background_white;
        //                cO1.VerticalAlignment = Element.ALIGN_TOP;
        //                cO1.HorizontalAlignment = Element.ALIGN_RIGHT;
        //                cO1.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //                tablePos.AddCell(cO1);
        //                Phrase pScope1 = new Phrase(sPos);
        //                pScope1.Font.Color = color_Maroon;
        //                pScope1.Font.SetFamily("Arial");
        //                pScope1.Font.SetStyle("bold");
        //                pScope1.Font.Size = iNormalFontSize;
        //                PdfPCell cO2 = new PdfPCell(pScope1);
        //                cO2.BackgroundColor = background_white;
        //                cO2.VerticalAlignment = Element.ALIGN_TOP;
        //                cO2.HorizontalAlignment = Element.ALIGN_LEFT;
        //                cO2.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //                tablePos.AddCell(cO2);
        //                pdfDocument.Add(tablePos);
        //            }

        //            // SETUP
        //            PdfPTable tableSimSetup = new PdfPTable(2);
        //            tableSimSetup.WidthPercentage = 100;
        //            tableSimSetup.SetWidths(new Single[] { 2, 10 });
        //            tableSimSetup.SpacingBefore = 1;
        //            string sSetup1 = row["SIM_SETUP1"].ToString();
        //            string sSetup2 = row["SIM_SETUP2"].ToString();
        //            string sSetup3 = row["SIM_SETUP3"].ToString();
        //            string sSetup4 = row["SIM_SETUP4"].ToString();
        //            if (sSetup1 == "") {
        //                if (sSetup2 != "") {
        //                    sSetup1 = sSetup2;
        //                }
        //            } else if (sSetup2 != "") {
        //                sSetup1 = sSetup1 + "\n" + sSetup2;
        //            }
        //            if (sSetup3 != "") {
        //                sSetup1 = sSetup1 + "\n" + sSetup3;
        //            }
        //            if (sSetup4 != "") {
        //                sSetup1 = sSetup1 + "\n" + sSetup4;
        //            }
        //            if (sSetup1 != "") {
        //                // display
        //                Phrase pScope = new Phrase("SIM SETUP");
        //                pScope.Font.Color = color_Black;
        //                pScope.Font.SetFamily("Arial");
        //                pScope.Font.SetStyle("bold");
        //                pScope.Font.Size = iNormalFontSize;
        //                PdfPCell cO1 = new PdfPCell(pScope);
        //                cO1.BackgroundColor = background_white;
        //                cO1.VerticalAlignment = Element.ALIGN_TOP;
        //                cO1.HorizontalAlignment = Element.ALIGN_RIGHT;
        //                cO1.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //                tableSimSetup.AddCell(cO1);
        //                Phrase pScope1 = new Phrase(sSetup1);
        //                pScope1.Font.Color = color_Maroon;
        //                pScope1.Font.SetFamily("Arial");
        //                pScope1.Font.SetStyle("bold");
        //                pScope1.Font.Size = iNormalFontSize;
        //                PdfPCell cO2 = new PdfPCell(pScope1);
        //                cO2.BackgroundColor = background_white;
        //                cO2.VerticalAlignment = Element.ALIGN_TOP;
        //                cO2.HorizontalAlignment = Element.ALIGN_LEFT;
        //                cO2.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //                tableSimSetup.AddCell(cO2);
        //                pdfDocument.Add(tableSimSetup);
        //            }

        //            // SETUP GUIDE
        //            if (row["SETUP_VISABLE"].ToString() == "yes") {
        //                // display setup panel
        //                PdfPTable tableSetup = new PdfPTable(6);
        //                tableSetup.WidthPercentage = 100;
        //                tableSetup.SetWidths(new Single[] { 5, 5, 5, 5, 5, 5 });
        //                tableSetup.SpacingBefore = 10;

        //                // NOT IN USE //
        //                // header
        //                Phrase pSetup = new Phrase("AIRCRAFT CONDITIONS");
        //                pSetup.Font.Color = color_Black;
        //                pSetup.Font.SetFamily("Arial");
        //                pSetup.Font.SetStyle("bold");
        //                pSetup.Font.Size = iNormalFontSize;
        //                PdfPCell cSetup = new PdfPCell(pSetup);
        //                cSetup.BackgroundColor = background_grey;
        //                cSetup.VerticalAlignment = Element.ALIGN_MIDDLE;
        //                cSetup.HorizontalAlignment = Element.ALIGN_LEFT;
        //                cSetup.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //                cSetup.Colspan = 4;
        //                //pSetup = new Phrase("WEATHER CONDITIONS");
        //                pSetup.Font.Color = color_Black;
        //                pSetup.Font.SetFamily("Arial");
        //                pSetup.Font.SetStyle("bold");
        //                pSetup.Font.Size = iNormalFontSize;
        //                cSetup = new PdfPCell(pSetup);
        //                cSetup.BackgroundColor = background_grey;
        //                cSetup.VerticalAlignment = Element.ALIGN_MIDDLE;
        //                cSetup.HorizontalAlignment = Element.ALIGN_LEFT;
        //                cSetup.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //                cSetup.Colspan = 2;
        //                //tableSetup.AddCell(cSetup);
        //                // NOT IN USE //

        //                // init
        //                cSetup = new PdfPCell();
        //                cSetup.BackgroundColor = color_Black;
        //                cSetup.VerticalAlignment = Element.ALIGN_MIDDLE;
        //                cSetup.HorizontalAlignment = Element.ALIGN_LEFT;
        //                cSetup.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //                cSetup.Colspan = 4;
        //                cSetup.AddElement(Init_Page(row));
        //                tableSetup.AddCell(cSetup);

        //                // wx cell- 3 rows
        //                cSetup = new PdfPCell();
        //                cSetup.BackgroundColor = color_Black;
        //                cSetup.VerticalAlignment = Element.ALIGN_TOP;
        //                cSetup.HorizontalAlignment = Element.ALIGN_LEFT;
        //                cSetup.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //                cSetup.Colspan = 2;
        //                cSetup.Rowspan = 3;
        //                cSetup.AddElement(Conditions_WX(row));
        //                tableSetup.AddCell(cSetup);

        //                // ac cell
        //                cSetup = new PdfPCell();
        //                cSetup.BackgroundColor = color_Black;
        //                cSetup.VerticalAlignment = Element.ALIGN_MIDDLE;
        //                cSetup.HorizontalAlignment = Element.ALIGN_LEFT;
        //                cSetup.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //                cSetup.Colspan = 4;
        //                cSetup.AddElement(AC_Performance_350(row));
        //                tableSetup.AddCell(cSetup);

        //                //// perf cell
        //                cSetup = new PdfPCell();
        //                cSetup.BackgroundColor = color_Black;
        //                cSetup.VerticalAlignment = Element.ALIGN_MIDDLE;
        //                cSetup.HorizontalAlignment = Element.ALIGN_LEFT;
        //                cSetup.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //                cSetup.Colspan = 4;
        //                cSetup.AddElement(Perf_TO(row));
        //                tableSetup.AddCell(cSetup);

        //                pdfDocument.Add(tableSetup);
        //            }
        //            // ATIS
        //            PdfPTable tableATIS = new PdfPTable(2);
        //            tableATIS.WidthPercentage = 100;
        //            tableATIS.SetWidths(new Single[] { 2, 10 });
        //            tableATIS.SpacingAfter = 1;
        //            string sATIS = row["ATIS"].ToString();
        //            if (sATIS != "") {
        //                // display
        //                var chuckData = new Chunk(sATIS, font_Data_Maroon);
        //                Phrase pScope = new Phrase("ATIS");
        //                pScope.Font.Color = color_Black;
        //                pScope.Font.SetFamily("Arial");
        //                pScope.Font.SetStyle("bold");
        //                pScope.Font.Size = iNormalFontSize;
        //                PdfPCell cO1 = new PdfPCell(pScope);
        //                cO1.BackgroundColor = background_white;
        //                cO1.VerticalAlignment = Element.ALIGN_TOP;
        //                cO1.HorizontalAlignment = Element.ALIGN_RIGHT;
        //                cO1.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //                tableATIS.AddCell(cO1);
        //                Phrase pScope1 = new Phrase(chuckData);
        //                PdfPCell cO2 = new PdfPCell(pScope1);
        //                cO2.BackgroundColor = background_white;
        //                cO2.VerticalAlignment = Element.ALIGN_TOP;
        //                cO2.HorizontalAlignment = Element.ALIGN_LEFT;
        //                cO2.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //                tableATIS.AddCell(cO2);
        //                pdfDocument.Add(tableATIS);
        //            }
        //            // CLEARANCE
        //            PdfPTable tableClearance = new PdfPTable(2);
        //            tableClearance.WidthPercentage = 100;
        //            tableClearance.SetWidths(new Single[] { 2, 10 });
        //            tableClearance.SpacingAfter = 1;
        //            // sim position
        //            string sClearance = row["CLEARANCE"].ToString();
        //            if (sClearance != "") {
        //                // display
        //                var chuckData = new Chunk(sClearance, font_Data_Maroon);
        //                Phrase pScope = new Phrase("CLEARANCE");
        //                pScope.Font.Color = color_Black;
        //                pScope.Font.SetFamily("Arial");
        //                pScope.Font.SetStyle("bold");
        //                pScope.Font.Size = iNormalFontSize;
        //                PdfPCell cO1 = new PdfPCell(pScope);
        //                cO1.BackgroundColor = background_white;
        //                cO1.VerticalAlignment = Element.ALIGN_TOP;
        //                cO1.HorizontalAlignment = Element.ALIGN_RIGHT;
        //                cO1.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //                tableClearance.AddCell(cO1);
        //                Phrase pScope1 = new Phrase(chuckData);
        //                PdfPCell cO2 = new PdfPCell(pScope1);
        //                cO2.BackgroundColor = background_white;
        //                cO2.VerticalAlignment = Element.ALIGN_TOP;
        //                cO2.HorizontalAlignment = Element.ALIGN_LEFT;
        //                cO2.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //                tableClearance.AddCell(cO2);
        //                pdfDocument.Add(tableClearance);
        //            }

        //            // NOTES
        //            PdfPTable tableNotes = new PdfPTable(2);
        //            tableNotes.WidthPercentage = 100;
        //            tableNotes.SetWidths(new Single[] { 2, 10 });
        //            tableNotes.SpacingAfter = 1;
        //            string sNotes1 = row["NOTES_1"].ToString();
        //            string sNotes2 = row["NOTES_2"].ToString();
        //            string sNotes3 = row["NOTES_3"].ToString();
        //            string sNotes4 = row["NOTES_4"].ToString();
        //            string sNotes5 = row["NOTES_5"].ToString();
        //            if (sNotes1 == "") {
        //                if (sNotes2 != "") {
        //                    sNotes1 = sNotes2;
        //                }
        //            } else if (sNotes2 != "") {
        //                sNotes1 = sNotes1 + "\n" + sNotes2;
        //            }
        //            if (sNotes3 != "") {
        //                sNotes1 = sNotes1 + "\n" + sNotes3;
        //            }
        //            if (sNotes4 != "") {
        //                sNotes1 = sNotes1 + "\n" + sNotes4;
        //            }
        //            if (sNotes5 != "") {
        //                sNotes1 = sNotes1 + "\n" + sNotes5;
        //            }
        //            if (sNotes1 != "") {
        //                // display
        //                Phrase pScope = new Phrase("SPOT NOTES");
        //                pScope.Font.Color = color_Black;
        //                pScope.Font.SetFamily("Arial");
        //                pScope.Font.SetStyle("bold");
        //                pScope.Font.Size = iNormalFontSize;
        //                PdfPCell cO1 = new PdfPCell(pScope);
        //                cO1.BackgroundColor = background_white;
        //                cO1.VerticalAlignment = Element.ALIGN_TOP;
        //                cO1.HorizontalAlignment = Element.ALIGN_RIGHT;
        //                cO1.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //                tableNotes.AddCell(cO1);
        //                Phrase pScope1 = new Phrase(sNotes1);
        //                pScope1.Font.Color = color_Blue;
        //                pScope1.Font.SetFamily("Arial");
        //                pScope1.Font.SetStyle("normal");
        //                pScope1.Font.Size = iNormalFontSize;
        //                PdfPCell cO2 = new PdfPCell(pScope1);
        //                cO2.BackgroundColor = background_white;
        //                cO2.VerticalAlignment = Element.ALIGN_TOP;
        //                cO2.HorizontalAlignment = Element.ALIGN_LEFT;
        //                cO2.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //                tableNotes.AddCell(cO2);
        //                pdfDocument.Add(tableNotes);
        //            }

        //            for (int iAction = 1; iAction < 11; iAction++) {
        //                if (row["PF" + iAction].ToString() != "")
        //                    pdfDocument.Add(Actions(row, iAction));
        //            }

        //            // SPOT footer
        //            string sFooterText = "";
        //            if (iRowCounter < iRowCount) {
        //                sFooterText = sSPOT + " COMPLETE";
        //            } else {
        //                sFooterText = "** " + sSPOT + " AND LESSON COMPLETE **";
        //            }
        //            tableSPOTHeader = new PdfPTable(1);
        //            tableSPOTHeader.WidthPercentage = 100;
        //            tableSPOTHeader.SpacingBefore = 0;
        //            pPhrase1 = new Phrase(sFooterText);
        //            if (iRowCounter < iRowCount) {
        //                pPhrase1.Font.Color = color_Black;
        //            } else {
        //                pPhrase1.Font.Color = color_Yellow;
        //            }
        //            pPhrase1.Font.SetFamily("Arial");
        //            pPhrase1.Font.SetStyle("bold");
        //            pPhrase1.Font.Size = iNormalFontSize;
        //            c1 = new PdfPCell(pPhrase1);
        //            if (iRowCounter < iRowCount) {
        //                c1.BackgroundColor = background_gold;
        //            } else {
        //                c1.BackgroundColor = color_Maroon;
        //            }
        //            c1.VerticalAlignment = Element.ALIGN_TOP;
        //            c1.HorizontalAlignment = Element.ALIGN_CENTER;
        //            c1.BorderWidthRight = 1;
        //            c1.BorderWidthLeft = 1;
        //            c1.BorderWidthTop = 1;
        //            c1.BorderWidthBottom = 1;
        //            tableSPOTHeader.AddCell(c1);
        //            pdfDocument.Add(tableSPOTHeader);

        //        }
        //    }


        //    // write TOC
        //    pdfDocument.NewPage();
        //    Chunk dottedLine = new Chunk(new DottedLineSeparator());
        //    Chunk chunckTitle = new Chunk("TABLE OF CONTENTS", font_Normal_Bold_Maroon);
        //    pdfDocument.Add(new Paragraph(chunckTitle));

        //    Dictionary<string, KeyValuePair<string, int>> entries = pdfEventTOC.GetTOC();
        //    Paragraph p;

        //    foreach (var entry in entries) {
        //        Chunk chunkKey = new Chunk(entry.Key, font_TOC_Black);
        //        var vDescript = entry.Key;
        //        var value = entry.Value.Key;
        //        chunkKey.SetAction(PdfAction.GotoLocalPage(entry.Value.Key, false));
        //        p = new Paragraph(chunkKey);
        //        if (vDescript.IndexOf("SPOT") > -1) {
        //            p.IndentationLeft = 20;
        //        } else if (vDescript.IndexOf("SUMMARY") > -1) {
        //            p.IndentationLeft = 10;
        //        }
        //        p.Add(dottedLine);

        //        Chunk chunkPage = new Chunk((entry.Value.Value).ToString(), font_TOC_Bold_Black);
        //        chunkPage.SetAction(PdfAction.GotoLocalPage(entry.Value.Key, false));
        //        p.Add(chunkPage);
        //        pdfDocument.Add(p);


        //        // buttons
        //        //iTextSharp.text.Rectangle _rect;
        //        //_rect = new iTextSharp.text.Rectangle(100, 806, 170, 788);
        //        //PushbuttonField button = new PushbuttonField(pdfWriter, _rect, "Buttons");



        //        //var button = new PushbuttonField(pdfWriter, new iTextSharp.text.Rectangle(100, 806, 200, 788), "Text") {
        //        //    Text = vDescript
        //        //};
        //        //button.BackgroundColor = new GrayColor(0.75f);
        //        //button.BorderColor = GrayColor.GRAYBLACK;
        //        //button.BorderWidth = 1;
        //        //button.BorderStyle = PdfBorderDictionary.STYLE_BEVELED;
        //        //button.TextColor = GrayColor.GRAYBLACK;
        //        //button.FontSize = 12;
        //        //button.Text = vDescript;
        //        //button.Layout = PushbuttonField.LAYOUT_ICON_LEFT_LABEL_RIGHT;
        //        //button.ScaleIcon = PushbuttonField.SCALE_ICON_ALWAYS;
        //        //button.ProportionalIcon = true;
        //        //button.IconHorizontalAdjustment = 0;
        //        //PdfFormField _Field1 = button.Field;
        //        //_Field1.Action = PdfAction.GotoLocalPage(entry.Value.Key, false);
        //        //pdfWriter.AddAnnotation(_Field1);




        //        //pdfWriter.AddAnnotation(AddButton(pdfDocument, pdfWriter, pdfPage, vDescript, entry.Value.Key).Field);//AddButton(pdfDocument, pdfWriter, pdfPage, vDescript)
        //        //var button = new PushbuttonField(pdfWriter, new iTextSharp.text.Rectangle(300, 300, 330, 330), "Text") {
        //        //    Text = vDescript
        //        //};
        //        //var f = button.Field;
        //        //PdfAppearance theButton = button.GetAppearance();
        //        //f.Action = PdfAction.GotoLocalPage(entry.Value.Key, false);
        //    }

        //    // re-order the pages to place the TOC behind the title page
        //    //When you add your table of contents, get its pdfPage number for the reordering:
        //    int iPageTOC = pdfWriter.PageNumber;
        //    // always add to a new pdfPage before reordering pages.
        //    pdfDocument.NewPage();
        //    // get the total number of pages that needs to be reordered
        //    int total = pdfWriter.ReorderPages(null);
        //    // change the order
        //    int[] order = new int[total];
        //    // we start at page 1 to skip the title page
        //    for (int i = 0; i < total; i++) {
        //        if (i == 0) {
        //            order[i] = 1;
        //        } else if (i == 1) {
        //            order[i] = iPageTOC;
        //        } else {
        //            order[i] = (i - 1) + iPageTOC;
        //            if (order[i] > total) {
        //                order[i] -= total;
        //                order[i] += 1;
        //            }
        //        }
        //    }
        //    // apply the new order
        //    pdfWriter.ReorderPages(order);

        //    //float zoomNumber = 100;
        //    //int pageNumberToOpenTo = 1;
        //    //PdfDestination magnify = new PdfDestination(PdfDestination.XYZ, -1, -1, zoomNumber / 100);
        //    //PdfAction zoom = PdfAction.GotoLocalPage(pageNumberToOpenTo, magnify, pdfWriter);


        //    pdfDocument.CloseDocument();
        //    pdfDocument = null;
        //    pdfWriter.Close();
        //    pdfWriter = null;
        //    olLessonSPOTS.Clear();
        //    olLessonSPOTS = null;
        //    olRoot.Clear();
        //    olRoot = null;
        //    //olDocTitle.Clear();
        //    //olDocTitle = null;

        //    // display the pdf in a viewer
        //    Process process = new Process();
        //    ProcessStartInfo startInfo = new ProcessStartInfo();
        //    process.StartInfo = startInfo;
        //    startInfo.FileName = sFile;
        //    process.Start();

        //    fs.Close();
        //    fs = null;

        //    m_Script = null;

        //    iPageNumber = 0;
        //    */

        //    // headers
        //    pdfDocument = AddHeader(pdfDocument);

        //    pdfDocument.Save(sFile);
        //    pdfDocument.Clear();

        //    // display the pdf in a viewer
        //    Process process = new Process();
        //    ProcessStartInfo startInfo = new ProcessStartInfo();
        //    process.StartInfo = startInfo;
        //    startInfo.FileName = sFile;
        //    process.Start();

        //}


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

    }
}
