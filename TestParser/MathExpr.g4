grammar MathExpr;

expr	
	:	LPAREN expr RPAREN			# Parens
	|	op=(PLUS | MINUS) expr		# UnaryAddSub
	|	NUMBER						# Number
	|	VARIABLE					# Variable	
	|	expr POW expr				# Power
	|	expr op=(MUL | DIV) expr	# MulDiv
	//|	expr expr					# ImpliedMul
	|	expr op=(PLUS | MINUS) expr	# AddSub
	;

LPAREN
   : '('
   ;

RPAREN
   : ')'
   ;

PLUS
   : '+'
   ;

MINUS
   : '-'
   ;

MUL
   : '*'
   ;

DIV
   : '/'
   ;

POW
   : '^'
   ;

fragment POINT
   : '.'
   ;

fragment UNDERSCORE
	: '_'
	;

fragment LETTER
   : ('a' .. 'z') | ('A' .. 'Z')
   ;

fragment DIGIT
   : ('0' .. '9')
   ;

NUMBER	
	: DIGIT+ (POINT DIGIT+)?
	;

VARIABLE
	: LETTER+
	;

WS
   : [ \r\n\t] + -> skip
   ;