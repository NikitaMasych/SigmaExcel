using NUnit.Framework;
using SigmaExcel;

namespace UnitTests
{
    public class ExcelBaseRepresentorTests
    {
        [TestCase(27, "AA")]
        [TestCase(3, "C")]
        public void TestThatConvertToPseudo26BaseIsCorrect(int value, string expected)
        {
            var actual = ExcelBaseRepresentor.ConvertToPseudo26Base(value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase("AB", 28)]
        [TestCase("D", 4)]
        public void TestThatConvertFromPseudo26BaseIsCorrect(string value, int expected)
        {
            var actual = ExcelBaseRepresentor.ConvertFromPseudo26Base(value);

            Assert.AreEqual(expected, actual);
        }
    }
}
