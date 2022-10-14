grammar Grammar;

compileUnit: expression EOF;

expression:
	LPAREN expression RPAREN #ParenthesisExpr
	| expression operatorToken=(MULTIPLICATION | DIVISION) expression #MultiplicationDivisionExpr
	| expression operatorToken=(ADDITION | SUBSTRACTION) expression #AdditionSubstractionExpr
	| operatorToken=(MOD | DIV) LPAREN expression SEPARATOR expression RPAREN #ModDivExpr
	| operatorToken=(MMAX | MMIN) LPAREN expression SEPARATOR (expression | expression SEPARATOR expression) RPAREN #MmaxMminExpr
	| NUMBER #NumberExpr;

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
