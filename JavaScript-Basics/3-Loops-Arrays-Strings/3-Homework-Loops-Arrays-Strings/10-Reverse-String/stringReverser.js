
var input = [
	'sample',
	'softUni',
	'java script'

];

for (var i = 0; i < input.length; i++) {
	
	 console.log(reverseString(input[i]));
};

function reverseString(value) {

	var reverseString = '';

	for (var i = value.length; i >= 0; i--) {
		
		reverseString += value.charAt(i);
	};

	return reverseString;
}