
var readline = require('readline');

var rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

rl.question("Write an numer for kW to calculate Hp: ", function(answer) {

  var processed = convertKWtoHP(answer);

  console.log("The answer is: ", processed);

  rl.close();
});

function convertKWtoHP(answer) {

	var input = answer;

	var calculated = (input*1.3404826).toFixed(2);

	return calculated;

}
