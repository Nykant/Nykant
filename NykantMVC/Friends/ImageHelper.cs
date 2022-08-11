using System.IO;
using System.Reflection;

namespace NykantMVC.Friends
{
    public static class ImageHelper
    {
        public static string[] GetImages()
        {
            //string[] files = Directory.GetFiles(@".\Archive", "*.zip");
            //string currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            //string imageFolder= Path.Combine(currentDirectory, "Egetræsmøbler");
            var images = Directory.GetFiles(@".\wwwroot\Egetræsmøbler", "*.png", SearchOption.AllDirectories);

            return images;
        }
    }
}
