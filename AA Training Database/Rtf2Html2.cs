using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    class Rtf2Html2 {


        //private static string ConvertRtfToXaml(string rtfText) {
        //    var richTextBox = new RichTextBox();
        //    if (string.IsNullOrEmpty(rtfText))
        //        return "";
        //    var textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
        //    using (var rtfMemoryStream = new MemoryStream()) {
        //        using (var rtfStreamWriter = new StreamWriter(rtfMemoryStream)) {
        //            rtfStreamWriter.Write(rtfText);
        //            rtfStreamWriter.Flush();
        //            rtfMemoryStream.Seek(0, SeekOrigin.Begin);
        //            textRange.Load(rtfMemoryStream, DataFormats.Rtf);
        //        }
        //    }
        //    using (var rtfMemoryStream = new MemoryStream()) {
        //        textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
        //        textRange.Save(rtfMemoryStream, DataFormats.Xaml);
        //        rtfMemoryStream.Seek(0, SeekOrigin.Begin);
        //        using (var rtfStreamReader = new StreamReader(rtfMemoryStream)) {
        //            return rtfStreamReader.ReadToEnd();
        //        }
        //    }
        //}


        //private static string ConvertXamlToRtf(string xamlText) {
        //    var richTextBox = new RichTextBox();
        //    if (string.IsNullOrEmpty(xamlText))
        //        return "";
        //    var textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
        //    using (var xamlMemoryStream = new MemoryStream()) {
        //        using (var xamlStreamWriter = new StreamWriter(xamlMemoryStream)) {
        //            xamlStreamWriter.Write(xamlText);
        //            xamlStreamWriter.Flush();
        //            xamlMemoryStream.Seek(0, SeekOrigin.Begin);
        //            textRange.Load(xamlMemoryStream, DataFormats.Xaml);
        //        }
        //    }
        //    using (var rtfMemoryStream = new MemoryStream()) {
        //        textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
        //        textRange.Save(rtfMemoryStream, DataFormats.Rtf);
        //        rtfMemoryStream.Seek(0, SeekOrigin.Begin);
        //        using (var rtfStreamReader = new StreamReader(rtfMemoryStream)) {
        //            return rtfStreamReader.ReadToEnd();
        //        }
        //    }
        //}


        //public interface IMarkupConverter {
        //    string ConvertXamlToHtml(string xamlText);
        //    string ConvertHtmlToXaml(string htmlText);
        //    string ConvertRtfToHtml(string rtfText);
        //    string ConvertHtmlToRtf(string htmlText);
        //}

        //public class MarkupConverter : IMarkupConverter {
        //    public string ConvertXamlToHtml(string xamlText) {
        //        return HtmlFromXamlConverter.ConvertXamlToHtml(xamlText, false);
        //    }

        //    public string ConvertHtmlToXaml(string htmlText) {
        //        return HtmlToXamlConverter.ConvertHtmlToXaml(htmlText, true);
        //    }

        //    public string ConvertRtfToHtml(string rtfText) {
        //        return RtfToHtmlConverter.ConvertRtfToHtml(rtfText);
        //    }

        //    public string ConvertHtmlToRtf(string htmlText) {
        //        return HtmlToRtfConverter.ConvertHtmlToRtf(htmlText);
        //    }
        //}

        ////MarkupConverter markupConverter = new MarkupConverter();

        //private string ConvertRtfToHtml(string rtfText) {
        //    var thread = new Thread(ConvertRtfInSTAThread);
        //    var threadData = new ConvertRtfThreadData { RtfText = rtfText };
        //    thread.SetApartmentState(ApartmentState.STA);
        //    thread.Start(threadData);
        //    thread.Join();
        //    return threadData.HtmlText;
        //}

        //private void ConvertRtfInSTAThread(object rtf) {
        //    var threadData = rtf as ConvertRtfThreadData;
        //    threadData.HtmlText = markupConverter.ConvertRtfToHtml(threadData.RtfText);
        //}


        //private class ConvertRtfThreadData {
        //    public string RtfText {
        //        get; set;
        //    }
        //    public string HtmlText {
        //        get; set;
        //    }
        //}



    }
}
