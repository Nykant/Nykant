using System;
using System.IO;
using System.Reflection;

namespace NykantMVC.Friends
{
    public static class ImageHelper
    {
        public static string[] GetImages(string path)
        {
            //string[] files = Directory.GetFiles(@".\Archive", "*.zip");
            
            string p = Path.Combine(path, "Egetræsmøbler");

            var images = Directory.GetFiles(p, "*.png", SearchOption.AllDirectories);

            return images;
        }
    }
}
