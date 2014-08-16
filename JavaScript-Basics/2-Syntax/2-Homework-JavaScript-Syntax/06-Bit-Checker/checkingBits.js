
var input = [333, 425, 2567564754];

for (var i = 0; i < input.length; i += 1) {
	
	var result = bitChecker(input[i])[0];
	var bits = bitChecker(input[i])[1];

	console.log("\n The binary representation of the number " + input[i] + " is " + bits + "\n")
	console.log(" Thre bit 3 of the number " + input[i] + " is 1 - > " + result);
};

function bitChecker(value) {

	var input = value.toString(2);

	var output = (input.charAt((input.length)-4) === '1');

	return [output, input];	
}