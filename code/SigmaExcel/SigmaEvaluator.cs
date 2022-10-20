using Antlr4.Runtime;

namespace SigmaExcel
{
    public class SigmaEvaluator
    {   
        public static decimal EvaluateExpression(string expression)
        {   
            var inputStream = new AntlrInputStream(expression);
            var lexer = new SigmaExcelLexer(inputStream);
            // Important to define custom error listener, 
            // so that exceptions are not handled and 
            // invalid expressions are not validated:
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowExceptionErrorListener());

            var tokens = new CommonTokenStream(lexer);
            var parser = new SigmaExcelParser(tokens);
            var expressionTree = parser.expr();
            var visitor = new SigmaVisitor();
            var result = visitor.Visit(expressionTree);
            return result;        }
    }
}