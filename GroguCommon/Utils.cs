using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroguCommon
{
    public class Utils
    {

        public static string ImageToBase64(Image img)
        {
            using (var ms = new MemoryStream())
            {
                using (var bitmap = new Bitmap(img))
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    var imgBase64 = Convert.ToBase64String(ms.GetBuffer()); //Get Base64
                    return imgBase64;
                }
            }
        }

        public static Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }
    }
}
