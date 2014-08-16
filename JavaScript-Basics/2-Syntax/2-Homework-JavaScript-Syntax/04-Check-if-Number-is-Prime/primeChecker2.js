var readline = require('readline');

var rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

rl.question("Write the number to check : ", function(input) {

  var output = isPrime(input);

  console.log('Is the number ' + input + ' prime -> '+ output);

  rl.close();
});

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