grammar RealExcel;

compileUnit: expression EOF;

/*
 * Parser rules:
 */

expression:
	LPAREN expression RPAREN #ParenthesisExpr
	| expression operatorToken=(MULTIPLICATION | DIVISION) expression #MultiplicationDivisionExpr
	| expression operatorToken=(ADDITION | SUBSTRACTION) expression #AdditionSubstractionExpr
	| operatorToken=(MOD | DIV) LPAREN expression SEPARATOR expression RPAREN #ModDivExpr
	| operatorToken=(NMAX | NMIN) LPAREN expression SEPARATOR (expression | expression SEPARATOR expression) RPAREN #MmaxMminExpr
	| NUMBER #NumberExpr;

/*
 * Lexer rules:
 */

NUMBER: INT (.INT)?;
INT: ('0'..'9')+;

LPAREN: '(';
RPAREN: ')';

SEPARATOR: ',' | ';';

ADDITION: '+';
SUBSTRACTION: '-';
MULTIPLICATION: '*';
DIVISION: '/';

MOD: 'mod';
DIV: 'div';

MMAX: 'mmax';
MMIN: 'mmin';

WS: [ \t\r\n] -> channel(HIDDEN);
