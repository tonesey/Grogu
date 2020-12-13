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
    }
}
