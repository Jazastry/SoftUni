var readline = require('readline');

var rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

rl.question("Write an numer to round: ", function(input) {

  var floor = roundNumber(input)[0];
  var round = roundNumber(input)[1];

  console.log("The answer is:",'\n'+ floor +'\n'+ round);

  rl.close();
});

function  roundNumber(input) {

	var floorNumb = Math.floor(input);
	var roundNumb = Math.round(input);

	return [floorNumb, roundNumb];
}