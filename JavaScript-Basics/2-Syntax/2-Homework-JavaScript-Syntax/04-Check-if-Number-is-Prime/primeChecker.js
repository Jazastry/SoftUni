
var input = [7, 254, 587];


for (var i = 0; i < input.length; i += 1) {

	var result = isPrime(input[i]);

	console.log("\n Is number : " + input[i] + " prime ? -> " + result)
	
};

function isPrime(value) {

	var result = true;

	for (var j = 0; j < value; j += 1) {
		
		if ((j === 1) || (j === value)) {

		continue;
		}

		if (((value / j) % 1) === 0) {

			result = false;

			break;
		};

	};

	return result;
}