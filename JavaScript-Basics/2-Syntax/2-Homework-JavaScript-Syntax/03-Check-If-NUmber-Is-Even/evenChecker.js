var input = [3, 127, 588];

var result = false;

for (var i = 0; i < input.length; i++) {

	result = ((input[i]%2) === 0);
	console.log("input : " + input[i] + " is it even ? -> " + result);
};