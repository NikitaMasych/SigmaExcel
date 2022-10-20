using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SigmaExcel
{
    class EnvironmentalLoader
    {
        public static void Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }
            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(
                    new char[] { '=' },
                    StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2)
                {
                    continue;
                }
                Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }
        }
    }
}
