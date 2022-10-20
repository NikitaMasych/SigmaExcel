using System;
using System.Windows.Forms;
using System.IO;

namespace SigmaExcel
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }
            var root = @"C:\Users\38099\Desktop\Data\Study\2_year\Lab1Excel\code\SigmaExcel";
            var dotenv = Path.Combine(root, ".env");
            EnvironmentalLoader.Load(dotenv);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SigmaExcel());
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
