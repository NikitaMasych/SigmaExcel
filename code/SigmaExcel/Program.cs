using System;
using System.Windows.Forms;

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
            try
            {
                Config.LoadWarningsEnvironmental();
                Config.SetWarningsToEnvironmental();
            }
            catch { }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SigmaExcel());
            Config.SaveCurrentWarningsConfiguration();
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
