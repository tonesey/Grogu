using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


        public static DateTime GetNistTime()
        {
            var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
            var response = myHttpWebRequest.GetResponse();
            string todaysDates = response.Headers["date"];
            return DateTime.ParseExact(todaysDates,
                                       "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                                       CultureInfo.InvariantCulture.DateTimeFormat,
                                       DateTimeStyles.AssumeUniversal);
        }

        public static Bitmap MergeImages(IEnumerable<Bitmap> images)
        {
            var enumerable = images as IList<Bitmap> ?? images.ToList();

            var width = 0;
            var height = 0;

            foreach (var image in enumerable)
            {
                width += image.Width;
                height = image.Height > height
                    ? image.Height
                    : height;
            }

            var bitmap = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bitmap))
            {
                var localWidth = 0;
                foreach (var image in enumerable)
                {
                    g.DrawImage(image, localWidth, 0);
                    localWidth += image.Width;
                }
            }
            return bitmap;
        }


        /// <summary>
        /// Creates an image containing the given text.
        /// NOTE: the image should be disposed after use.
        /// </summary>
        /// <param name="text">Text to draw</param>
        /// <param name="fontOptional">Font to use, defaults to Control.DefaultFont</param>
        /// <param name="textColorOptional">Text color, defaults to Black</param>
        /// <param name="backColorOptional">Background color, defaults to white</param>
        /// <param name="minSizeOptional">Minimum image size, defaults the size required to display the text</param>
        /// <returns>The image containing the text, which should be disposed after use</returns>
        public static Image DrawText(string text, Font fontOptional = null, Color? textColorOptional = null, Color? backColorOptional = null, Size? minSizeOptional = null)
        {
            Font font = Control.DefaultFont;
            if (fontOptional != null)
                font = fontOptional;

            Color textColor = Color.Black;
            if (textColorOptional != null)
                textColor = (Color)textColorOptional;

            Color backColor = Color.White;
            if (backColorOptional != null)
                backColor = (Color)backColorOptional;

            Size minSize = Size.Empty;
            if (minSizeOptional != null)
                minSize = (Size)minSizeOptional;

            //first, create a dummy bitmap just to get a graphics object
            SizeF textSize;
            using (Image img = new Bitmap(1, 1))
            {
                using (Graphics drawing = Graphics.FromImage(img))
                {
                    //measure the string to see how big the image needs to be
                    textSize = drawing.MeasureString(text, font);
                    if (!minSize.IsEmpty)
                    {
                        textSize.Width = textSize.Width > minSize.Width ? textSize.Width : minSize.Width;
                        textSize.Height = textSize.Height > minSize.Height ? textSize.Height : minSize.Height;
                    }
                }
            }

            //create a new image of the right size
            Image retImg = new Bitmap((int)textSize.Width, (int)textSize.Height);
            using (var drawing = Graphics.FromImage(retImg))
            {
                //paint the background
                drawing.Clear(backColor);

                //create a brush for the text
                using (Brush textBrush = new SolidBrush(textColor))
                {
                    drawing.DrawString(text, font, textBrush, 0, 0);
                    drawing.Save();
                }
            }
            return retImg;
        }
    }
}
