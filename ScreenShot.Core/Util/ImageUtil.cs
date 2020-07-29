using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ScreenShot.Core.Util
{
    public class ImageUtil
    {
        public static Image GetScreenImage(out Rectangle virtualScreen)
        {
            virtualScreen = SystemInformation.VirtualScreen;
            Image img = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(img);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
            return img;
        }

        public static Image GetTargetImage(Image baseImage, Rectangle rectangle)
        {
            Image image = new Bitmap(rectangle.Width, rectangle.Height);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.DrawImage(baseImage,
                    0, 0,
                    rectangle,
                    GraphicsUnit.Pixel);
            }
            return image;
        }

        public static byte[] GetTargetImageToBytes(Image baseImage, Rectangle rectangle)
        {
            Image targetImage = GetTargetImage(baseImage, rectangle);
            using (MemoryStream ms = new MemoryStream())
            {
                targetImage.Save(ms, ImageFormat.Jpeg);
                byte[] data = new byte[ms.Length];
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(data, 0, data.Length);
                return data;
            }
        }
    }
}