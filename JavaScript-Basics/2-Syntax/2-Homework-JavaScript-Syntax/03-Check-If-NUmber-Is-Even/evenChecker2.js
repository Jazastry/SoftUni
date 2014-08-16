var readline = require('readline');

var rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

rl.question("Write number to check : ", function(input) {

  var result = evenNumber(input);

  console.log("Is the number "+ input + " even -> " + result);

  rl.close();
});

function evenNumber(input) {

	var isEven = ((input%2) === 0);

	return isEven;
}