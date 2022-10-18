using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace RealExcel
{
    class ThrowExceptionErrorListener : BaseErrorListener, IAntlrErrorListener<int>
    {
        // BaseErrorListener:
        public override void SyntaxError([NotNull] IRecognizer recognizer, [Nullable] IToken offendingSymbol, 
            int line, int charPositionInLine, [NotNull] string msg, [Nullable] RecognitionException e)
        {
            throw new ArgumentException($"Invalid expression: {msg}", e);
        }
        // IAntlrErrorListener<int>:
        public void SyntaxError([NotNull] IRecognizer recognizer, [Nullable] int offendingSymbol, 
            int line, int charPositionInLine, [NotNull] string msg, [Nullable] RecognitionException e)
        {
            throw new ArgumentException($"Invalid expression: {msg}", e);
        }
    }
}
