grammar RealExcel;

/* Parser rules: */

compileUnit: expr EOF; // requirement for atomic parse

decimal: INT | FLOAT;

// Defined in their precedence:

expr: LPAREN expr RPAREN							#Parenthesis
	| op=(ADD|SUB) expr								#Unary
	| expr op=(MUL|DIV) expr						#MulDiv
	| expr op=(ADD|SUB) expr						#AddSub
	| op=(MOD|IDIV) LPAREN expr SEP expr RPAREN		#ModIDiv
	| op=(MAX|MIN) LPAREN expr (SEP expr)+ RPAREN	#MaxMin
	| decimal										#Number
	;


/* Lexer rules: */

fragment DIGIT: [0-9];
INT: DIGIT +;
FLOAT: DIGIT + '.' DIGIT +;

LPAREN: '(';
RPAREN: ')';

SEP: ',' | ';';

MUL: '*';
DIV: '/';
ADD: '+';
SUB: '-';

MOD: 'mod';
IDIV: 'div'; // stands for integer division, i.e. div(5,3) = 1

MAX: 'max';
MIN: 'min';

WS: [ \t\r\n]+ -> skip ; // omit spaces, horisontal tabs, carriage return, newlines
