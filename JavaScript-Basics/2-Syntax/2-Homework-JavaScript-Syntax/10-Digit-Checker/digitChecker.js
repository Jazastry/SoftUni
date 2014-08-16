
var input = [1235, 25368, 123456];

for (var i = 0; i < input.length; i++) {
	
	console.log("input - " + input[i] + 
					". Is 3 digit at pos.-3 -> " +
						checkDigit(input[i].toString()));
};

function checkDigit(a) {

	var numbAtThree = (a.charAt(a.length - 3) == '3');

	return numbAtThree;
}