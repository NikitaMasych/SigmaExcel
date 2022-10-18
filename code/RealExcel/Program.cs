using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RealExcel
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var root = @"C:\Users\38099\Desktop\Data\Study\2_year\Lab1Excel\code\RealExcel";
            var dotenv = Path.Combine(root, ".env");
            EnvironmentalLoader.Load(dotenv);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RealExcel());
        }
    }
}
