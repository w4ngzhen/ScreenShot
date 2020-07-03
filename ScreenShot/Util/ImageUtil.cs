using System.Drawing;
using System.Windows.Forms;

namespace ScreenShot.Util
{
    public class ImageUtil
    {
        public static Image GetScreenImage()
        {
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
    }
}