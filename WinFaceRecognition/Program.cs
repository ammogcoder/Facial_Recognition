using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinFaceRecognition
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetProcessDpiAwareness((int)(DpiAwareness.PerMonitorAware));
            Application.Run(new frmMain());
        }

        [DllImport("Shcore.dll")]
        public static extern int SetProcessDpiAwareness(int PROCESS_DPI_AWARENESS);

        public enum DpiAwareness
        {
            None = 0,
            SystemAware = 1,
            PerMonitorAware = 2
        }
    }
}
