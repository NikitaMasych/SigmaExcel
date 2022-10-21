using NUnit.Framework;
using SigmaExcel;

namespace UnitTests
{
    public class SigmaEvaluatorTests
    {
        [TestCase("max(-3,8.2,123)", 123)]
        [TestCase("max(192,8.2,123,-3.2)", 192)]
        public void TestThatMaxEvaluationIsCorrect(string expression, decimal expected)
        {
            var actual = SigmaEvaluator.EvaluateExpression(expression);

            Assert.AreEqual(expected, actual);
        }
        [TestCase("min(0,-28.2,1, 23)", -28.2)]
        [TestCase("min(-3,8.2,123)", -3)]
        public void TestThatMinEvaluationIsCorrect(string expression, decimal expected)
        {
            var actual = SigmaEvaluator.EvaluateExpression(expression);

            Assert.AreEqual(expected, actual);
        }
        [TestCase("10+2+2.1", 14.1)]
        [TestCase("12+3.2", 15.2)]
        public void TestThatAddEvaluationIsCorrect(string expression, decimal expected)
        {
            var actual = SigmaEvaluator.EvaluateExpression(expression);

            Assert.AreEqual(expected, actual);
        }
        [TestCase("3 - 8.2 - 0.8", -6)]
        [TestCase("9 - 1.3", 7.7)]
        public void TestThatSubEvaluationIsCorrect(string expression, decimal expected)
        {
            var actual = SigmaEvaluator.EvaluateExpression(expression);

            Assert.AreEqual(expected, actual);
        }
        [TestCase("2 * 13", 26)]
        [TestCase("2.1 * 3 * 2", 12.6)]
        public void TestThatMulEvaluationIsCorrect(string expression, decimal expected)
        {
            var actual = SigmaEvaluator.EvaluateExpression(expression);

            Assert.AreEqual(expected, actual);
        }
        [TestCase("40 / 2 / 10", 2)]
        [TestCase("5 / 10 / 2", 0.25)]
        public void TestThatDivEvaluationIsCorrect(string expression, decimal expected)
        {
            var actual = SigmaEvaluator.EvaluateExpression(expression);

            Assert.AreEqual(expected, actual);
        }
        [TestCase("mod(5,2)", 1)]
        [TestCase("mod(7, 13)", 7)]
        public void TestThatModEvaluationIsCorrect(string expression, decimal expected)
        {
            var actual = SigmaEvaluator.EvaluateExpression(expression);

            Assert.AreEqual(expected, actual);
        }
        [TestCase("div(4, 9)", 0)]
        [TestCase("div(47, 3)", 15)]
        public void TestThatIDivEvaluationIsCorrect(string expression, decimal expected)
        {
            var actual = SigmaEvaluator.EvaluateExpression(expression);

            Assert.AreEqual(expected, actual);
        }
        [TestCase("2 ^ 5 ^ 2", 1024)]
        [TestCase("2.1 ^ 3", 9.261)]
        public void TestThatExponentialEvaluationIsCorrect(string expression, decimal expected)
        {
            var actual = SigmaEvaluator.EvaluateExpression(expression);

            Assert.AreEqual(expected, actual);
        }
        [TestCase("abs(-3.8)", 3.8)]
        [TestCase("abs(4)", 4)]
        public void TestThatAbsEvaluationIsCorrect(string expression, decimal expected)
        {
            var actual = SigmaEvaluator.EvaluateExpression(expression);

            Assert.AreEqual(expected, actual);
        }
        [TestCase("-3.8", -3.8)]
        [TestCase("+37", 37)]
        public void TestThatUnaryEvaluationIsCorrect(string expression, decimal expected)
        {
            var actual = SigmaEvaluator.EvaluateExpression(expression);

            Assert.AreEqual(expected, actual);
        }
    }
}
