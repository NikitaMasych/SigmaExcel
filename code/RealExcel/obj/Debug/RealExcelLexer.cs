//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\38099\Desktop\Data\Study\2_year\Lab1Excel\code\RealExcel\RealExcel.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace RealExcel {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class RealExcelLexer : Lexer {
	public const int
		INT=1, FLOAT=2, LPAREN=3, RPAREN=4, SEP=5, MUL=6, DIV=7, ADD=8, SUB=9, 
		MOD=10, IDIV=11, MAX=12, MIN=13, WS=14;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"DIGIT", "INT", "FLOAT", "LPAREN", "RPAREN", "SEP", "MUL", "DIV", "ADD", 
		"SUB", "MOD", "IDIV", "MAX", "MIN", "WS"
	};


	public RealExcelLexer(ICharStream input)
		: base(input)
	{
		_interp = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, null, null, "'('", "')'", null, "'*'", "'/'", "'+'", "'-'", "'mod'", 
		"'div'", "'max'", "'min'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "INT", "FLOAT", "LPAREN", "RPAREN", "SEP", "MUL", "DIV", "ADD", 
		"SUB", "MOD", "IDIV", "MAX", "MIN", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[System.Obsolete("Use Vocabulary instead.")]
	public static readonly string[] tokenNames = GenerateTokenNames(DefaultVocabulary, _SymbolicNames.Length);

	private static string[] GenerateTokenNames(IVocabulary vocabulary, int length) {
		string[] tokenNames = new string[length];
		for (int i = 0; i < tokenNames.Length; i++) {
			tokenNames[i] = vocabulary.GetLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = vocabulary.GetSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}

		return tokenNames;
	}

	[System.Obsolete("Use IRecognizer.Vocabulary instead.")]
	public override string[] TokenNames
	{
		get
		{
			return tokenNames;
		}
	}

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "RealExcel.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x2\x10X\b\x1\x4\x2"+
		"\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b\x4"+
		"\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4\x10"+
		"\t\x10\x3\x2\x3\x2\x3\x3\x6\x3%\n\x3\r\x3\xE\x3&\x3\x4\x6\x4*\n\x4\r\x4"+
		"\xE\x4+\x3\x4\x3\x4\x6\x4\x30\n\x4\r\x4\xE\x4\x31\x3\x5\x3\x5\x3\x6\x3"+
		"\x6\x3\a\x3\a\x3\b\x3\b\x3\t\x3\t\x3\n\x3\n\x3\v\x3\v\x3\f\x3\f\x3\f\x3"+
		"\f\x3\r\x3\r\x3\r\x3\r\x3\xE\x3\xE\x3\xE\x3\xE\x3\xF\x3\xF\x3\xF\x3\xF"+
		"\x3\x10\x6\x10S\n\x10\r\x10\xE\x10T\x3\x10\x3\x10\x2\x2\x2\x11\x3\x2\x2"+
		"\x5\x2\x3\a\x2\x4\t\x2\x5\v\x2\x6\r\x2\a\xF\x2\b\x11\x2\t\x13\x2\n\x15"+
		"\x2\v\x17\x2\f\x19\x2\r\x1B\x2\xE\x1D\x2\xF\x1F\x2\x10\x3\x2\x5\x3\x2"+
		"\x32;\x4\x2..==\x5\x2\v\f\xF\xF\"\"Z\x2\x5\x3\x2\x2\x2\x2\a\x3\x2\x2\x2"+
		"\x2\t\x3\x2\x2\x2\x2\v\x3\x2\x2\x2\x2\r\x3\x2\x2\x2\x2\xF\x3\x2\x2\x2"+
		"\x2\x11\x3\x2\x2\x2\x2\x13\x3\x2\x2\x2\x2\x15\x3\x2\x2\x2\x2\x17\x3\x2"+
		"\x2\x2\x2\x19\x3\x2\x2\x2\x2\x1B\x3\x2\x2\x2\x2\x1D\x3\x2\x2\x2\x2\x1F"+
		"\x3\x2\x2\x2\x3!\x3\x2\x2\x2\x5$\x3\x2\x2\x2\a)\x3\x2\x2\x2\t\x33\x3\x2"+
		"\x2\x2\v\x35\x3\x2\x2\x2\r\x37\x3\x2\x2\x2\xF\x39\x3\x2\x2\x2\x11;\x3"+
		"\x2\x2\x2\x13=\x3\x2\x2\x2\x15?\x3\x2\x2\x2\x17\x41\x3\x2\x2\x2\x19\x45"+
		"\x3\x2\x2\x2\x1BI\x3\x2\x2\x2\x1DM\x3\x2\x2\x2\x1FR\x3\x2\x2\x2!\"\t\x2"+
		"\x2\x2\"\x4\x3\x2\x2\x2#%\x5\x3\x2\x2$#\x3\x2\x2\x2%&\x3\x2\x2\x2&$\x3"+
		"\x2\x2\x2&\'\x3\x2\x2\x2\'\x6\x3\x2\x2\x2(*\x5\x3\x2\x2)(\x3\x2\x2\x2"+
		"*+\x3\x2\x2\x2+)\x3\x2\x2\x2+,\x3\x2\x2\x2,-\x3\x2\x2\x2-/\a\x30\x2\x2"+
		".\x30\x5\x3\x2\x2/.\x3\x2\x2\x2\x30\x31\x3\x2\x2\x2\x31/\x3\x2\x2\x2\x31"+
		"\x32\x3\x2\x2\x2\x32\b\x3\x2\x2\x2\x33\x34\a*\x2\x2\x34\n\x3\x2\x2\x2"+
		"\x35\x36\a+\x2\x2\x36\f\x3\x2\x2\x2\x37\x38\t\x3\x2\x2\x38\xE\x3\x2\x2"+
		"\x2\x39:\a,\x2\x2:\x10\x3\x2\x2\x2;<\a\x31\x2\x2<\x12\x3\x2\x2\x2=>\a"+
		"-\x2\x2>\x14\x3\x2\x2\x2?@\a/\x2\x2@\x16\x3\x2\x2\x2\x41\x42\ao\x2\x2"+
		"\x42\x43\aq\x2\x2\x43\x44\a\x66\x2\x2\x44\x18\x3\x2\x2\x2\x45\x46\a\x66"+
		"\x2\x2\x46G\ak\x2\x2GH\ax\x2\x2H\x1A\x3\x2\x2\x2IJ\ao\x2\x2JK\a\x63\x2"+
		"\x2KL\az\x2\x2L\x1C\x3\x2\x2\x2MN\ao\x2\x2NO\ak\x2\x2OP\ap\x2\x2P\x1E"+
		"\x3\x2\x2\x2QS\t\x4\x2\x2RQ\x3\x2\x2\x2ST\x3\x2\x2\x2TR\x3\x2\x2\x2TU"+
		"\x3\x2\x2\x2UV\x3\x2\x2\x2VW\b\x10\x2\x2W \x3\x2\x2\x2\a\x2&+\x31T\x3"+
		"\b\x2\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace RealExcel