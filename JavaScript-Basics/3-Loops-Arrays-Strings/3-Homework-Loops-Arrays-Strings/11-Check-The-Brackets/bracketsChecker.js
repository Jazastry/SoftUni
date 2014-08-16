
var input = [
	'( ( a + b ) / 5 – d )',
	') ( a + b ) )',
	'( b * ( c + d *2 / ( 2 + ( 12 – c / ( a + 3 ) ) ) )'
];

for (var i = 0; i < input.length; i++) {
	
	console.log(checkBrackets(input[i]));
};

function checkBrackets(inp) {

	var leftBrace = 0;
	var rightBrace = 0;	
	var processString = inp;
	var result = '';

	for (var i = 0; i < processString.length; i++) {
		
		if (processString[i] == '(') {

			leftBrace += 1;
		} else if (processString[i] == ')') {

			rightBrace += 1;
		};
	};

	if (leftBrace == rightBrace) {

		result = 'correct';
	} else {

		result = 'incorrect';
	};

	return result;
}
