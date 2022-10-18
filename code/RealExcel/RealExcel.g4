grammar RealExcel;

/* Parser rules: */

compileUnit: expr EOF; // requirement for atomic parsing

decimal: INT | FLOAT;

// Defined in their precedence:

expr: LPAREN expr RPAREN							#Parenthesis
	| expr op=EXP expr								#Exponential
	| op=(ADD|SUB) expr								#Unary
	| expr op=(MUL|DIV) expr						#MulDiv
	| expr op=(ADD|SUB) expr						#AddSub
	| op=(MOD|IDIV) LPAREN expr SEP expr RPAREN		#ModIDiv
	| op=(MAX|MIN) LPAREN expr (SEP expr)+ RPAREN	#MaxMin
	| op=ABS LPAREN expr RPAREN						#Abs
	| op=(SIN|COS|TAN|COT) LPAREN expr RPAREN		#Trigonometrical
	| decimal										#Number
	;


/* Lexer rules: */

fragment DIGIT: [0-9];
INT: DIGIT +;
FLOAT: DIGIT + ('.' | ',') DIGIT +;

LPAREN: '(';
RPAREN: ')';

SEP: ',' | ';';

MUL: '*';
DIV: '/';
ADD: '+';
SUB: '-';

EXP: '^' | '**';

MOD: 'mod';
IDIV: 'div'; // stands for integer division, i.e. div(5,3) = 1

MAX: 'max';
MIN: 'min';

ABS: 'abs';

SIN: 'sin';
COS: 'cos';
TAN: 'tg' | 'tan';
COT: 'ctg' | 'cot';

WS: [ \t\r\n]+ -> skip ; // omit spaces, horisontal tabs, carriage return, newlines
