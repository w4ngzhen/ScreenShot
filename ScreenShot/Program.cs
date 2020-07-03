using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ScreenShot
{
    internal static class Program
    {
//        [DllImport("kernel32.dll")]
//        public static extern bool AllocConsole();
//
//        [DllImport("kernel32.dll")]
//        public static extern bool FreeConsole();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}