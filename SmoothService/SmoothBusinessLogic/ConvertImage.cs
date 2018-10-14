using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace SmoothBusinessLogic
{
    public static class ConvertImage
    {
        public static string ImageToString(Image img)
        {
            using (Image image = img)
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, ImageFormat.Jpeg);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }

        public static Image StringToImage(string img)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(img);

                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    return Image.FromStream(ms);// Image.FromStream(ms);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
