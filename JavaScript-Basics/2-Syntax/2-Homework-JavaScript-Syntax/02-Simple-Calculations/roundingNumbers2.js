
var input = [22.7, 12.3, 58.7];

for (var i = 0; i < input.length; i++) {

	console.log("\ninput :"+input[i] + "\n");

	console.log("output :"); 
	var floor = roundNumber(input[i])[0];
	var round = roundNumber(input[i])[1];

	console.log(floor +'\n'+ round +'\n');
};

function  roundNumber(input) {

	var floorNumb = Math.floor(input);
	var roundNumb = Math.round(input);

	return [floorNumb, roundNumb];
}