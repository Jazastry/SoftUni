var input = [
	[  // [0]
		['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q'], 
		['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q']
	],
	[  // [1]
		['3', '5', 'g', 'd'], 
		['5', '3', 'g', 'd']
	],
	[  // [2]
		['q', 'g', 'q', 'h', 'a', 'k', 'u', '8', '}', 'q', '.', 'h', '|', ';'],
		['6', 'f', 'w', 'q', ':', '”', 'd', '}', ']', 's', 'r']
	]
];

for (var i = 0; i < input.length; i++) {
	

	console.log(compareChars(input[i][0], input[i][1]))
};	

function compareChars(value1, value2) {

	var arrayOne = value1;
	var arrayTwo = value2;
	var result = 'Equal';

	for (var i = 0; i < arrayOne.length; i++) {
		
		if (arrayOne[i] !== arrayTwo[i]) {

			result = 'Not' + result;

			break;
		};

	};

	return result;
}