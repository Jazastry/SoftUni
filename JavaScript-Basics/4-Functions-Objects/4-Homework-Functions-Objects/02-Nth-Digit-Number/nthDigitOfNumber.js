
var input = [
	[1, 6],
	[2, -55],
	[6, 923456],
	[3, 1451.78],
	[6, 888.88]
];

for (var i = 0; i < input.length; i++) {
	
	findNthDigit(input[i]);
};

function findNthDigit(arr) {

	var n = arr[0];

	var inMumbString = arr[1].toString();

	var finalNum = inMumbString.split('.').join("");

	var result = finalNum.charAt(finalNum.length - n); 

	if (result == '') {

		console.log('The number doesn’t have ' + n + ' digits');
	} else {

		console.log(result);
	}
}