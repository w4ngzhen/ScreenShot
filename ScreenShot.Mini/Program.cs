using System;
using System.Windows.Forms;

namespace ScreenShot.Mini
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MiniCaptor miniCaptor = new MiniCaptor();
            miniCaptor.ImageDataAcquired += (sender, args) =>
            {
                MessageBox.Show(@"Image Acquired! Image byte data length: " + args.ImageData.Length);
            };
            Application.Run(miniCaptor);
        }
    }
}
