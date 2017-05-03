using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1 {
    class FMC_350 {

        public static PdfPTable Init_Page(DataRow row) {

            try {
                PdfPTable tableSetup = new PdfPTable(6);
                tableSetup.WidthPercentage = 100;
                tableSetup.SetWidths(new Single[] { 5, 5, 5, 5, 5, 5 });
                tableSetup.SpacingBefore = 0;

                // title pdfPage
                Phrase pSetup = new Phrase("ACTIVE/INIT");
                pSetup.Font.Color = PDF.color_Black;
                pSetup.Font.SetFamily(PDF.sFont_Fixed_Width);
                pSetup.Font.SetStyle("bold");
                pSetup.Font.Size = PDF.iNormalFontSize;
                PdfPCell cSetup = new PdfPCell(pSetup);
                cSetup.BackgroundColor = PDF.background_grey;
                cSetup.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cSetup.Colspan = 6;
                tableSetup.AddCell(cSetup);

                // row 1/a
                var chuckTitle = new Chunk("FLT NBR", PDF.font_Title_White);
                var chuckData = new Chunk("AAL" + row["FLTNUM"].ToString(), PDF.font_Title_Cyan);
                Phrase pSetup1 = new Phrase(chuckTitle);
                PdfPCell cSetup1 = new PdfPCell(pSetup1);
                cSetup1.BackgroundColor = PDF.color_Black;
                cSetup1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1);
                Phrase pSetup1d = new Phrase(chuckData);
                PdfPCell cSetup1d = new PdfPCell(pSetup1d);
                cSetup1d.BackgroundColor = PDF.color_Black;
                cSetup1d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup1d.BorderColor = PDF.color_White;
                cSetup1d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cSetup1d.Colspan = 2;
                tableSetup.AddCell(cSetup1d);
                // 1/b
                Phrase pSetup2 = new Phrase();
                PdfPCell cSetup2 = new PdfPCell(pSetup2);
                cSetup2.BackgroundColor = PDF.color_Black;
                cSetup2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2);
                Phrase pSetup2d = new Phrase();
                PdfPCell cSetup2d = new PdfPCell(pSetup2d);
                cSetup2d.BackgroundColor = PDF.color_Black;
                cSetup2d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup2d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2d);
                // 1/c
                Phrase pSetup3 = new Phrase();
                PdfPCell cSetup3 = new PdfPCell(pSetup3);
                cSetup3.BackgroundColor = PDF.color_Black;
                cSetup3.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3);
                Phrase pSetup3d = new Phrase();
                PdfPCell cSetup3d = new PdfPCell(pSetup3d);
                cSetup3d.BackgroundColor = PDF.color_Black;
                cSetup3d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup3d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                //tableSetup.AddCell(cSetup3d);

                // row 2/a
                chuckTitle = new Chunk("FROM", PDF.font_Title_White);
                chuckData = new Chunk(row["DEP"].ToString(), PDF.font_Title_Cyan);
                pSetup1 = new Phrase(chuckTitle);
                cSetup1 = new PdfPCell(pSetup1);
                cSetup1.BackgroundColor = PDF.color_Black;
                cSetup1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1);
                pSetup1d = new Phrase(chuckData);
                cSetup1d = new PdfPCell(pSetup1d);
                cSetup1d.BackgroundColor = PDF.color_Black;
                cSetup1d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup1d.BorderColor = PDF.color_White;
                cSetup1d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1d);
                // 2/b
                chuckTitle = new Chunk("TO", PDF.font_Title_White);
                chuckData = new Chunk(row["DEST"].ToString(), PDF.font_Title_Cyan);
                pSetup2 = new Phrase(chuckTitle);
                cSetup2 = new PdfPCell(pSetup2);
                cSetup2.BackgroundColor = PDF.color_Black;
                cSetup2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2);
                pSetup2d = new Phrase(chuckData);
                cSetup2d = new PdfPCell(pSetup2d);
                cSetup2d.BackgroundColor = PDF.color_Black;
                cSetup2d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup2d.BorderColor = PDF.color_White;
                cSetup2d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2d);
                // 2/c
                chuckTitle = new Chunk("ALTN", PDF.font_Title_White);
                chuckData = new Chunk(row["ALTN"].ToString(), PDF.font_Title_Cyan);
                pSetup3 = new Phrase(chuckTitle);
                cSetup3 = new PdfPCell(pSetup3);
                cSetup3.BackgroundColor = PDF.color_Black;
                cSetup3.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3);
                pSetup3d = new Phrase(chuckData);
                cSetup3d = new PdfPCell(pSetup3d);
                cSetup3d.BackgroundColor = PDF.color_Black;
                cSetup3d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup3d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3d);

                // row 3/a
                chuckTitle = new Chunk("CRZ FL", PDF.font_Title_White);
                chuckData = new Chunk(row["CRZALT"].ToString(), PDF.font_Title_Cyan);
                pSetup1 = new Phrase(chuckTitle);
                cSetup1 = new PdfPCell(pSetup1);
                cSetup1.BackgroundColor = PDF.color_Black;
                cSetup1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1);
                pSetup1d = new Phrase(chuckData);
                cSetup1d = new PdfPCell(pSetup1d);
                cSetup1d.BackgroundColor = PDF.color_Black;
                cSetup1d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup1d.BorderColor = PDF.color_White;
                cSetup1d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1d);
                // 3/b
                pSetup2 = new Phrase("");
                cSetup2 = new PdfPCell(pSetup2);
                cSetup2.BackgroundColor = PDF.color_Black;
                cSetup2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2);
                pSetup2d = new Phrase();
                cSetup2d = new PdfPCell(pSetup2d);
                cSetup2d.BackgroundColor = PDF.color_Black;
                cSetup2d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup2d.BorderColor = PDF.color_White;
                cSetup2d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2d);
                // 3/c
                pSetup3 = new Phrase();
                cSetup3 = new PdfPCell(pSetup3);
                cSetup3.BackgroundColor = PDF.color_Black;
                cSetup3.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3);
                pSetup3d = new Phrase();
                cSetup3d = new PdfPCell(pSetup3d);
                cSetup3d.BackgroundColor = PDF.color_Black;
                cSetup3d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup3d.BorderColor = PDF.color_White;
                cSetup3d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3d);

                // row 4/a
                chuckTitle = new Chunk("MODE", PDF.font_Title_White);
                chuckData = new Chunk("ECON", PDF.font_Title_Cyan);
                pSetup1 = new Phrase(chuckTitle);
                cSetup1 = new PdfPCell(pSetup1);
                cSetup1.BackgroundColor = PDF.color_Black;
                cSetup1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1);
                pSetup1d = new Phrase(chuckData);
                cSetup1d = new PdfPCell(pSetup1d);
                cSetup1d.BackgroundColor = PDF.color_Black;
                cSetup1d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup1d.BorderColor = PDF.color_White;
                cSetup1d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1d);
                // 4/b
                pSetup2 = new Phrase("");
                cSetup2 = new PdfPCell(pSetup2);
                cSetup2.BackgroundColor = PDF.color_Black;
                cSetup2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2);
                pSetup2d = new Phrase();
                cSetup2d = new PdfPCell(pSetup2d);
                cSetup2d.BackgroundColor = PDF.color_Black;
                cSetup2d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup2d.BorderColor = PDF.color_White;
                cSetup2d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2d);
                // 4/c
                pSetup3 = new Phrase();
                cSetup3 = new PdfPCell(pSetup3);
                cSetup3.BackgroundColor = PDF.color_Black;
                cSetup3.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3);
                pSetup3d = new Phrase();
                cSetup3d = new PdfPCell(pSetup3d);
                cSetup3d.BackgroundColor = PDF.color_Black;
                cSetup3d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup3d.BorderColor = PDF.color_White;
                cSetup3d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3d);

                // row 5/a
                chuckTitle = new Chunk("CI", PDF.font_Title_White);
                chuckData = new Chunk(row["CI"].ToString(), PDF.font_Title_Cyan);
                pSetup1 = new Phrase(chuckTitle);
                cSetup1 = new PdfPCell(pSetup1);
                cSetup1.BackgroundColor = PDF.color_Black;
                cSetup1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1);
                pSetup1d = new Phrase(chuckData);
                cSetup1d = new PdfPCell(pSetup1d);
                cSetup1d.BackgroundColor = PDF.color_Black;
                cSetup1d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup1d.BorderColor = PDF.color_White;
                cSetup1d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1d);
                // 5/b
                pSetup2 = new Phrase("");
                cSetup2 = new PdfPCell(pSetup2);
                cSetup2.BackgroundColor = PDF.color_Black;
                cSetup2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2);
                pSetup2d = new Phrase();
                cSetup2d = new PdfPCell(pSetup2d);
                cSetup2d.BackgroundColor = PDF.color_Black;
                cSetup2d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup2d.BorderColor = PDF.color_White;
                cSetup2d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2d);
                // 5/c
                pSetup3 = new Phrase();
                cSetup3 = new PdfPCell(pSetup3);
                cSetup3.BackgroundColor = PDF.color_Black;
                cSetup3.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3);
                pSetup3d = new Phrase();
                cSetup3d = new PdfPCell(pSetup3d);
                cSetup3d.BackgroundColor = PDF.color_Black;
                cSetup3d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup3d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3d);

                return tableSetup;

            } catch (Exception) {
                throw;
            }
        }

        public static PdfPTable AC_Performance(DataRow row) {


            try {
                var chunkUnit_KLB = new Chunk("KLB", PDF.font_Units_Blue);
                var chunkUnit_Percent = new Chunk("%", PDF.font_Units_Blue);

                PdfPTable tableSetup = new PdfPTable(6);
                tableSetup.WidthPercentage = 100;
                tableSetup.SetWidths(new Single[] { 5, 5, 5, 5, 5, 5 });
                tableSetup.SpacingBefore = 0;

                // title pdfPage
                Phrase pSetup = new Phrase("ACTIVE/FUEL & LOAD");
                pSetup.Font.Color = PDF.color_Black;
                pSetup.Font.SetFamily(PDF.sFont_Fixed_Width);
                pSetup.Font.SetStyle("bold");
                pSetup.Font.Size = PDF.iNormalFontSize;
                PdfPCell cSetup = new PdfPCell(pSetup);
                cSetup.BackgroundColor = PDF.background_grey;
                cSetup.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cSetup.Colspan = 6;
                tableSetup.AddCell(cSetup);

                // row 1/a
                var chuckTitle = new Chunk("GW", PDF.font_Title_White);
                var chuckData = new Chunk(row["GTOW"].ToString(), PDF.font_Title_Green);

                Phrase pSetup1 = new Phrase(chuckTitle);
                PdfPCell cSetup1 = new PdfPCell(pSetup1);
                cSetup1.BackgroundColor = PDF.color_Black;
                cSetup1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1);
                Phrase pSetup1d = new Phrase(chuckData);
                pSetup1d.Add(chunkUnit_KLB);
                PdfPCell cSetup1d = new PdfPCell(pSetup1d);
                cSetup1d.BackgroundColor = PDF.color_Black;
                cSetup1d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup1d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1d);
                // 1/b
                chuckTitle = new Chunk("CG", PDF.font_Title_White);
                chuckData = new Chunk(row["TOWCG"].ToString(), PDF.font_Title_Green);
                Phrase pSetup2 = new Phrase(chuckTitle);
                PdfPCell cSetup2 = new PdfPCell(pSetup2);
                cSetup2.BackgroundColor = PDF.color_Black;
                cSetup2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2);
                Phrase pSetup2d = new Phrase(chuckData);
                pSetup2d.Add(chunkUnit_Percent);
                PdfPCell cSetup2d = new PdfPCell(pSetup2d);
                cSetup2d.BackgroundColor = PDF.color_Black;
                cSetup2d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup2d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2d);
                // 1/c
                chuckTitle = new Chunk("FOB", PDF.font_Title_White);
                chuckData = new Chunk(PDF.Justify_Fuel(row["FUEL"].ToString()), PDF.font_Title_Green);
                Phrase pSetup3 = new Phrase(chuckTitle);
                PdfPCell cSetup3 = new PdfPCell(pSetup3);
                cSetup3.BackgroundColor = PDF.color_Black;
                cSetup3.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3);
                Phrase pSetup3d = new Phrase(chuckData);
                pSetup3d.Add(chunkUnit_KLB);
                PdfPCell cSetup3d = new PdfPCell(pSetup3d);
                cSetup3d.BackgroundColor = PDF.color_Black;
                cSetup3d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup3d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3d);

                // row 2/a
                chuckTitle = new Chunk("ZFW", PDF.font_Title_White);
                chuckData = new Chunk(row["ZFW"].ToString(), PDF.font_Title_Cyan);
                pSetup1 = new Phrase(chuckTitle);
                cSetup1 = new PdfPCell(pSetup1);
                cSetup1.BackgroundColor = PDF.color_Black;
                cSetup1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1);
                pSetup1d = new Phrase(chuckData);
                pSetup1d.Add(chunkUnit_KLB);
                cSetup1d = new PdfPCell(pSetup1d);
                cSetup1d.BackgroundColor = PDF.color_Black;
                cSetup1d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup1d.BorderColor = PDF.color_White;
                cSetup1d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1d);
                // 2/b
                chuckTitle = new Chunk("ZFWCG", PDF.font_Title_White);
                chuckData = new Chunk(row["ZFWCG"].ToString(), PDF.font_Title_Cyan);
                pSetup2 = new Phrase(chuckTitle);
                cSetup2 = new PdfPCell(pSetup2);
                cSetup2.BackgroundColor = PDF.color_Black;
                cSetup2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2);
                pSetup2d = new Phrase(chuckData);
                pSetup2d.Add(chunkUnit_Percent);
                cSetup2d = new PdfPCell(pSetup2d);
                cSetup2d.BackgroundColor = PDF.color_Black;
                cSetup2d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup2d.BorderColor = PDF.color_White;
                cSetup2d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2d);
                // 2/c
                pSetup3 = new Phrase();
                cSetup3 = new PdfPCell(pSetup3);
                cSetup3.BackgroundColor = PDF.color_Black;
                cSetup3.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3);
                pSetup3d = new Phrase();
                cSetup3d = new PdfPCell(pSetup3d);
                cSetup3d.BackgroundColor = PDF.color_Black;
                cSetup3d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup3d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3d);

                // row 2/a
                chuckTitle = new Chunk("BLOCK", PDF.font_Title_White);
                chuckData = new Chunk(PDF.Justify_Fuel(row["FUEL"].ToString()), PDF.font_Title_Cyan);
                pSetup1 = new Phrase(chuckTitle);
                cSetup1 = new PdfPCell(pSetup1);
                cSetup1.BackgroundColor = PDF.color_Black;
                cSetup1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1);
                pSetup1d = new Phrase(chuckData);
                pSetup1d.Add(chunkUnit_KLB);
                cSetup1d = new PdfPCell(pSetup1d);
                cSetup1d.BackgroundColor = PDF.color_Black;
                cSetup1d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup1d.BorderColor = PDF.color_White;
                cSetup1d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1d);
                // 2/b
                pSetup2 = new Phrase();
                cSetup2 = new PdfPCell(pSetup2);
                cSetup2.BackgroundColor = PDF.color_Black;
                cSetup2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2);
                pSetup2d = new Phrase();
                cSetup2d = new PdfPCell(pSetup2d);
                cSetup2d.BackgroundColor = PDF.color_Black;
                cSetup2d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup2d.BorderColor = PDF.color_White;
                cSetup2d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2d);
                // 2/c
                pSetup3 = new Phrase();
                cSetup3 = new PdfPCell(pSetup3);
                cSetup3.BackgroundColor = PDF.color_Black;
                cSetup3.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3);
                pSetup3d = new Phrase();
                cSetup3d = new PdfPCell(pSetup3d);
                cSetup3d.BackgroundColor = PDF.color_Black;
                cSetup3d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup3d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3d);

                // row 3/a
                chuckTitle = new Chunk("TAXI", PDF.font_Title_White);
                chuckData = new Chunk(PDF.Justify_Fuel(row["FUEL_TAXI"].ToString()), PDF.font_Title_Cyan);
                pSetup1 = new Phrase(chuckTitle);
                cSetup1 = new PdfPCell(pSetup1);
                cSetup1.BackgroundColor = PDF.color_Black;
                cSetup1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1);
                pSetup1d = new Phrase(chuckData);
                pSetup1d.Add(chunkUnit_KLB);
                cSetup1d = new PdfPCell(pSetup1d);
                cSetup1d.BackgroundColor = PDF.color_Black;
                cSetup1d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup1d.BorderColor = PDF.color_White;
                cSetup1d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1d);
                // 3/b
                pSetup2 = new Phrase("");
                cSetup2 = new PdfPCell(pSetup2);
                cSetup2.BackgroundColor = PDF.color_Black;
                cSetup2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2);
                pSetup2d = new Phrase();
                cSetup2d = new PdfPCell(pSetup2d);
                cSetup2d.BackgroundColor = PDF.color_Black;
                cSetup2d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup2d.BorderColor = PDF.color_White;
                cSetup2d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2d);
                // 3/c
                chuckTitle = new Chunk("PAX NBR", PDF.font_Title_White);
                chuckData = new Chunk(row["PAX"].ToString(), PDF.font_Title_Cyan);
                pSetup3 = new Phrase(chuckTitle);
                cSetup3 = new PdfPCell(pSetup3);
                cSetup3.BackgroundColor = PDF.color_Black;
                cSetup3.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3);
                pSetup3d = new Phrase(chuckData);
                cSetup3d = new PdfPCell(pSetup3d);
                cSetup3d.BackgroundColor = PDF.color_Black;
                cSetup3d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup3d.BorderColor = PDF.color_White;
                cSetup3d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3d);

                // row 4/a
                chuckTitle = new Chunk("FINAL", PDF.font_Title_White);
                chuckData = new Chunk(row["RESERVE"].ToString(), PDF.font_Title_Cyan);
                pSetup1 = new Phrase(chuckTitle);
                cSetup1 = new PdfPCell(pSetup1);
                cSetup1.BackgroundColor = PDF.color_Black;
                cSetup1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1);
                pSetup1d = new Phrase(chuckData);
                cSetup1d = new PdfPCell(pSetup1d);
                cSetup1d.BackgroundColor = PDF.color_Black;
                cSetup1d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup1d.BorderColor = PDF.color_White;
                cSetup1d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1d);
                // 4/b
                pSetup2 = new Phrase("");
                cSetup2 = new PdfPCell(pSetup2);
                cSetup2.BackgroundColor = PDF.color_Black;
                cSetup2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2);
                pSetup2d = new Phrase();
                cSetup2d = new PdfPCell(pSetup2d);
                cSetup2d.BackgroundColor = PDF.color_Black;
                cSetup2d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup2d.BorderColor = PDF.color_White;
                cSetup2d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2d);
                // 4/c
                chuckTitle = new Chunk("CI", PDF.font_Title_White);
                chuckData = new Chunk(row["CI"].ToString(), PDF.font_Title_Cyan);
                pSetup3 = new Phrase(chuckTitle);
                cSetup3 = new PdfPCell(pSetup3);
                cSetup3.BackgroundColor = PDF.color_Black;
                cSetup3.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3);
                pSetup3d = new Phrase(chuckData);
                cSetup3d = new PdfPCell(pSetup3d);
                cSetup3d.BackgroundColor = PDF.color_Black;
                cSetup3d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup3d.BorderColor = PDF.color_White;
                cSetup3d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3d);

                return tableSetup;

            } catch (Exception) {
                throw;
            }
        }

        public static PdfPTable Conditions_WX(DataRow row) {

            try {
                PdfPTable tableSetup = new PdfPTable(2);
                tableSetup.WidthPercentage = 100;
                tableSetup.SetWidths(new Single[] { 5, 5 });
                tableSetup.SpacingBefore = 0;

                // title pdfPage
                Phrase pSetup = new Phrase("WEATHER CONDITIONS");
                pSetup.Font.Color = PDF.color_Black;
                pSetup.Font.SetFamily(PDF.sFont_Fixed_Width);
                pSetup.Font.SetStyle("bold");
                pSetup.Font.Size = PDF.iNormalFontSize;
                PdfPCell cSetup = new PdfPCell(pSetup);
                cSetup.BackgroundColor = PDF.background_grey;
                cSetup.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cSetup.Colspan = 2;
                tableSetup.AddCell(cSetup);

                // row 1/a
                var chuckTitle = new Chunk("WIND", PDF.font_Title_White);
                var chuckData = new Chunk(row["WIND"].ToString(), PDF.font_Title_Green);
                Phrase pSetup1 = new Phrase(chuckTitle);
                PdfPCell cSetup1 = new PdfPCell(pSetup1);
                cSetup1.BackgroundColor = PDF.color_Black;
                cSetup1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1);
                Phrase pSetup1d = new Phrase(chuckData);
                PdfPCell cSetup1d = new PdfPCell(pSetup1d);
                cSetup1d.BackgroundColor = PDF.color_Black;
                cSetup1d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup1d.BorderColor = PDF.color_White;
                cSetup1d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cSetup1d.Colspan = 2;
                tableSetup.AddCell(cSetup1d);

                // row 2/a
                chuckTitle = new Chunk("CEILING", PDF.font_Title_White);
                chuckData = new Chunk(row["CEILING"].ToString(), PDF.font_Title_Green);
                pSetup1 = new Phrase(chuckTitle);
                cSetup1 = new PdfPCell(pSetup1);
                cSetup1.BackgroundColor = PDF.color_Black;
                cSetup1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1);
                pSetup1d = new Phrase(chuckData);
                cSetup1d = new PdfPCell(pSetup1d);
                cSetup1d.BackgroundColor = PDF.color_Black;
                cSetup1d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup1d.BorderColor = PDF.color_White;
                cSetup1d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1d);

                // row 3/a
                chuckTitle = new Chunk("VISIBILITY", PDF.font_Title_White);
                chuckData = new Chunk(row["VISIBILITY"].ToString(), PDF.font_Title_Green);
                pSetup1 = new Phrase(chuckTitle);
                cSetup1 = new PdfPCell(pSetup1);
                cSetup1.BackgroundColor = PDF.color_Black;
                cSetup1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1);
                pSetup1d = new Phrase(chuckData);
                cSetup1d = new PdfPCell(pSetup1d);
                cSetup1d.BackgroundColor = PDF.color_Black;
                cSetup1d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup1d.BorderColor = PDF.color_White;
                cSetup1d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1d);

                // row 4/a
                chuckTitle = new Chunk("GND TEMP", PDF.font_Title_White);
                chuckData = new Chunk(row["TEMP"].ToString(), PDF.font_Title_Green);
                pSetup1 = new Phrase(chuckTitle);
                cSetup1 = new PdfPCell(pSetup1);
                cSetup1.BackgroundColor = PDF.color_Black;
                cSetup1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1);
                pSetup1d = new Phrase(chuckData);
                cSetup1d = new PdfPCell(pSetup1d);
                cSetup1d.BackgroundColor = PDF.color_Black;
                cSetup1d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup1d.BorderColor = PDF.color_White;
                cSetup1d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1d);

                // row 5/a
                chuckTitle = new Chunk("QNH", PDF.font_Title_White);
                chuckData = new Chunk(row["QNH"].ToString(), PDF.font_Title_Green);
                pSetup1 = new Phrase(chuckTitle);
                cSetup1 = new PdfPCell(pSetup1);
                cSetup1.BackgroundColor = PDF.color_Black;
                cSetup1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1);
                pSetup1d = new Phrase(chuckData);
                cSetup1d = new PdfPCell(pSetup1d);
                cSetup1d.BackgroundColor = PDF.color_Black;
                cSetup1d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup1d.BorderColor = PDF.color_White;
                cSetup1d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1d);

                // row 6/a
                chuckTitle = new Chunk("RCAM", PDF.font_Title_White);
                chuckData = new Chunk(row["RUNWAY_COND"].ToString(), PDF.font_Title_Green);
                pSetup1 = new Phrase(chuckTitle);
                cSetup1 = new PdfPCell(pSetup1);
                cSetup1.BackgroundColor = PDF.color_Black;
                cSetup1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1);
                pSetup1d = new Phrase(chuckData);
                cSetup1d = new PdfPCell(pSetup1d);
                cSetup1d.BackgroundColor = PDF.color_Black;
                cSetup1d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup1d.BorderColor = PDF.color_White;
                cSetup1d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1d);

                return tableSetup;

            } catch (Exception) {
                throw;
            }
        }

        public static PdfPTable Perf_TO(DataRow row) {
            try {
                var chunkUnit_FT = new Chunk("FT", PDF.font_Units_Blue);
                var chunkUnit_KT = new Chunk("KT", PDF.font_Units_Blue);
                var chunkUnit_Percent = new Chunk("%", PDF.font_Units_Blue);

                PdfPTable tableSetup = new PdfPTable(6);
                tableSetup.WidthPercentage = 100;
                tableSetup.SetWidths(new Single[] { 5, 5, 5, 5, 5, 5 });
                tableSetup.SpacingBefore = 0;

                // title pdfPage
                Phrase pSetup = new Phrase("ACTIVE/PERF");
                pSetup.Font.Color = PDF.color_Black;
                pSetup.Font.SetFamily(PDF.sFont_Fixed_Width);
                pSetup.Font.SetStyle("bold");
                pSetup.Font.Size = PDF.iNormalFontSize;
                PdfPCell cSetup = new PdfPCell(pSetup);
                cSetup.BackgroundColor = PDF.background_grey;
                cSetup.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cSetup.Colspan = 6;
                tableSetup.AddCell(cSetup);

                // row 1/a
                var chuckTitle = new Chunk("V1", PDF.font_Title_White);
                var chuckData = new Chunk(row["V1"].ToString(), PDF.font_Title_Cyan);
                Phrase pSetup1 = new Phrase(chuckTitle);
                PdfPCell cSetup1 = new PdfPCell(pSetup1);
                cSetup1.BackgroundColor = PDF.color_Black;
                cSetup1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1);
                Phrase pSetup1d = new Phrase(chuckData);
                pSetup1d.Add(chunkUnit_KT);
                PdfPCell cSetup1d = new PdfPCell(pSetup1d);
                cSetup1d.BackgroundColor = PDF.color_Black;
                cSetup1d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup1d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1d);
                // 1/b
                chuckTitle = new Chunk("THRUST", PDF.font_Title_White);
                chuckData = new Chunk(row["THRUST"].ToString(), PDF.font_Title_Cyan);
                Phrase pSetup2 = new Phrase(chuckTitle);
                PdfPCell cSetup2 = new PdfPCell(pSetup2);
                cSetup2.BackgroundColor = PDF.color_Black;
                cSetup2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2);
                Phrase pSetup2d = new Phrase(chuckData);
                PdfPCell cSetup2d = new PdfPCell(pSetup2d);
                cSetup2d.BackgroundColor = PDF.color_Black;
                cSetup2d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup2d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2d);
                // 1/c
                chuckTitle = new Chunk("THR RED", PDF.font_Title_White);
                chuckData = new Chunk(row["THRUST_RED_ALT"].ToString(), PDF.font_Title_Cyan);
                Phrase pSetup3 = new Phrase(chuckTitle);
                PdfPCell cSetup3 = new PdfPCell(pSetup3);
                cSetup3.BackgroundColor = PDF.color_Black;
                cSetup3.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3);
                Phrase pSetup3d = new Phrase(chuckData);
                pSetup3d.Add(chunkUnit_FT);
                PdfPCell cSetup3d = new PdfPCell(pSetup3d);
                cSetup3d.BackgroundColor = PDF.color_Black;
                cSetup3d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup3d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3d);

                // row 2/a
                chuckTitle = new Chunk("VR", PDF.font_Title_White);
                chuckData = new Chunk(row["VR"].ToString(), PDF.font_Title_Cyan);
                pSetup1 = new Phrase(chuckTitle);
                cSetup1 = new PdfPCell(pSetup1);
                cSetup1.BackgroundColor = PDF.color_Black;
                cSetup1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1);
                pSetup1d = new Phrase(chuckData);
                pSetup1d.Add(chunkUnit_KT);
                cSetup1d = new PdfPCell(pSetup1d);
                cSetup1d.BackgroundColor = PDF.color_Black;
                cSetup1d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup1d.BorderColor = PDF.color_White;
                cSetup1d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1d);
                // 2/b
                chuckTitle = new Chunk("FLAPS", PDF.font_Title_White);
                chuckData = new Chunk(row["FLAPS"].ToString(), PDF.font_Title_Cyan);
                pSetup2 = new Phrase(chuckTitle);
                cSetup2 = new PdfPCell(pSetup2);
                cSetup2.BackgroundColor = PDF.color_Black;
                cSetup2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2);
                pSetup2d = new Phrase(chuckData);
                cSetup2d = new PdfPCell(pSetup2d);
                cSetup2d.BackgroundColor = PDF.color_Black;
                cSetup2d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup2d.BorderColor = PDF.color_White;
                cSetup2d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2d);
                // 2/c
                chuckTitle = new Chunk("ACCEL", PDF.font_Title_White);
                chuckData = new Chunk(row["ACCEL_ALT"].ToString(), PDF.font_Title_Cyan);
                pSetup3 = new Phrase(chuckTitle);
                cSetup3 = new PdfPCell(pSetup3);
                cSetup3.BackgroundColor = PDF.color_Black;
                cSetup3.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3);
                pSetup3d = new Phrase(chuckData);
                pSetup3d.Add(chunkUnit_FT);
                cSetup3d = new PdfPCell(pSetup3d);
                cSetup3d.BackgroundColor = PDF.color_Black;
                cSetup3d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup3d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3d);

                // row 3/a
                chuckTitle = new Chunk("V2", PDF.font_Title_White);
                chuckData = new Chunk(row["V2"].ToString(), PDF.font_Title_Cyan);
                pSetup1 = new Phrase(chuckTitle);
                cSetup1 = new PdfPCell(pSetup1);
                cSetup1.BackgroundColor = PDF.color_Black;
                cSetup1.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1);
                pSetup1d = new Phrase(chuckData);
                pSetup1d.Add(chunkUnit_KT);
                cSetup1d = new PdfPCell(pSetup1d);
                cSetup1d.BackgroundColor = PDF.color_Black;
                cSetup1d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup1d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup1d.BorderColor = PDF.color_White;
                cSetup1d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup1d);
                // 3/b
                chuckTitle = new Chunk("THS", PDF.font_Title_White);
                chuckData = new Chunk(row["TOWCG"].ToString(), PDF.font_Title_Cyan);
                pSetup2 = new Phrase(chuckTitle);
                cSetup2 = new PdfPCell(pSetup2);
                cSetup2.BackgroundColor = PDF.color_Black;
                cSetup2.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2);
                pSetup2d = new Phrase(chuckData);
                pSetup2d.Add(chunkUnit_Percent);
                cSetup2d = new PdfPCell(pSetup2d);
                cSetup2d.BackgroundColor = PDF.color_Black;
                cSetup2d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup2d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup2d.BorderColor = PDF.color_White;
                cSetup2d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup2d);
                // 3/c
                chuckTitle = new Chunk("EO ACCEL", PDF.font_Title_White);
                chuckData = new Chunk(row["EO_ACCEL_ALT"].ToString(), PDF.font_Title_Cyan);
                pSetup3 = new Phrase(chuckTitle);
                cSetup3 = new PdfPCell(pSetup3);
                cSetup3.BackgroundColor = PDF.color_Black;
                cSetup3.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3.HorizontalAlignment = Element.ALIGN_RIGHT;
                cSetup3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3);
                pSetup3d = new Phrase(chuckData);
                pSetup3d.Add(chunkUnit_FT);
                cSetup3d = new PdfPCell(pSetup3d);
                cSetup3d.BackgroundColor = PDF.color_Black;
                cSetup3d.VerticalAlignment = Element.ALIGN_MIDDLE;
                cSetup3d.HorizontalAlignment = Element.ALIGN_LEFT;
                cSetup3d.BorderColor = PDF.color_White;
                cSetup3d.Border = iTextSharp.text.Rectangle.NO_BORDER;
                tableSetup.AddCell(cSetup3d);


                return tableSetup;

            } catch (Exception) {
                throw;
            }
        }



    }
}
