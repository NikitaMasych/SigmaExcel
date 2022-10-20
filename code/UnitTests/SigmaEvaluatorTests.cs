using Microsoft.VisualStudio.TestTools.UnitTesting;
using SigmaExcel;

namespace UnitTests
{
    [TestClass]
    public class SigmaEvaluatorTests
    {
        [TestMethod]
        public void TestMaxMethod()
        {
            const string expression = @"max(-3,8.2,123)";
            const decimal exprected = 123;

            var actual = SigmaEvaluator.EvaluateExpression(expression);

            Assert.AreEqual(exprected, actual);
        }
        [TestMethod]
        public void TestAddMethod()
        {
            const string expression = @"7+32+1";
            const decimal exprected = 40;

            var actual = SigmaEvaluator.EvaluateExpression(expression);

            Assert.AreEqual(exprected, actual);
        }
        [TestMethod]
        public void TestSubMethod()
        {
            const string expression = @"2-1-32";
            const decimal exprected = -31;

            var actual = SigmaEvaluator.EvaluateExpression(expression);

            Assert.AreEqual(exprected, actual);
        }
        [TestMethod]
        public void TestMulMethod()
        {
            const string expression = @"3 * 8.2 * 123)";
            const decimal exprected = 3025.8M;

            var actual = SigmaEvaluator.EvaluateExpression(expression);

            Assert.AreEqual(exprected, actual);
        }
        [TestMethod]
        public void TestDivMethod()
        {
            const string expression = @"9/3";
            const decimal exprected = 3;

            var actual = SigmaEvaluator.EvaluateExpression(expression);

            Assert.AreEqual(exprected, actual);
        }
        [TestMethod]
        public void TestModMethod()
        {
            const string expression = @"mod(91, 4)";
            const decimal exprected = 3;

            var actual = SigmaEvaluator.EvaluateExpression(expression);

            Assert.AreEqual(exprected, actual);
        }
        [TestMethod]
        public void TestIDivMethod()
        {
            const string expression = @"div(91, 4)";
            const decimal exprected = 22;

            var actual = SigmaEvaluator.EvaluateExpression(expression);

            Assert.AreEqual(exprected, actual);
        }
        [TestMethod]
        public void TestExponentialMethod()
        {
            const string expression = @"2 ^ 5";
            const decimal exprected = 32;

            var actual = SigmaEvaluator.EvaluateExpression(expression);

            Assert.AreEqual(exprected, actual);
        }
    }
}
