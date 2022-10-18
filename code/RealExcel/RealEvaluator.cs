using Antlr4.Runtime;

namespace RealExcel
{
    public class RealEvaluator
    {   
        public static decimal EvaluateExpression(string expression)
        {
            var inputStream = new AntlrInputStream(expression);
            var lexer = new RealExcelLexer(inputStream);
            // Important to define custom error listener, 
            // so that exceptions are not handled and 
            // invalid expressions are not validated:
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowExceptionErrorListener());

            var tokens = new CommonTokenStream(lexer);
            var parser = new RealExcelParser(tokens);
            var expressionTree = parser.expr();
            var visitor = new RealVisitor();
            var result = visitor.Visit(expressionTree);
            return result;
        }
    }
}