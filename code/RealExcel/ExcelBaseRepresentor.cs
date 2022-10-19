using System;
using System.Text;

namespace RealExcel
{
    public class ExcelBaseRepresentor
    {
        public static string ConvertToPseudo26Base(int value)
        {
            const int BASE = 26; 
            StringBuilder result = new StringBuilder();
            int remainder;
            while (value > 0)
            {
                remainder = (value - 1) % BASE;
                result.Insert(0, (char)('A' + remainder));
                value = (value - remainder) / BASE;
            }
            return result.ToString();
        }
        public static int ConvertFromPseudo26Base(string value)
        {
            const int BASE = 26;
            value = value.ToUpper();
            int result = 0;

            foreach(var digit in value)
            {
                if (digit < 'A' || digit > 'Z')
                {
                    throw new ArgumentException($"Not excel base value: {value}\n");
                }
                result *= BASE;
                result += (digit - 'A' + 1);
            }
            return result;
        }
    }
}
