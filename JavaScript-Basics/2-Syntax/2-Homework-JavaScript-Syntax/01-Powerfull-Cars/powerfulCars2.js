
var input = [75, 150, 1000];

for (var i = 0; i < input.length; i += 1) {

	var output = convertKWtoHP(input[i]);

	console.log("input - " + input[i] + "; output - " + output +"\n");

};
	
function convertKWtoHP(answer) {

		var input = answer;

		var calculated = (input*1.3404826).toFixed(2);

		return calculated;

	}