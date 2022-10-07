using PdfSharp.Pdf;
using PdfSharp;
using System;
using System.IO;
using System.Text;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using WebOptimizer;

namespace NykantMVC.Friends
{
    public static class PdfHelper
    {
        //public static Byte[] PdfSharpConvert(string html, string fileName)
        //{
        //    Byte[] res = null;
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        PdfDocument pdf = PdfGenerator.GeneratePdf("<p><h1>Hello World</h1>This is html rendered text</p>", PageSize.A4);
        //        pdf.Save("document.pdf");
        //        var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
        //        pdf.Save(ms);
        //        res = ms.ToArray();
        //        var path = Path.Combine("Invoices", $"{fileName}.pdf");
        //        File.WriteAllBytes(path, res);
        //    }
        //    return res;
        //}
//        public static void SaveStringToPdf(string s, string fileName)
//        {
//            byte[] byteArray = Encoding.UTF8.GetBytes(s);
//            using (Stream stream = new MemoryStream(byteArray))
//{
//                byte[] buffer = new byte[stream.Length];
//                stream.Read(buffer, 0, buffer.Length);

//            }
//        }
    }
}
