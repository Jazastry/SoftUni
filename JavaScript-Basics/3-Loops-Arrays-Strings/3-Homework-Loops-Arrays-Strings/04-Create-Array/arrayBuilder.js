
var input = 20;

console.log(createArray(input));

function createArray(value) {

	var arrayCreated = [];

	for (var i = 0; i < value; i++) {
		
		arrayCreated[i] = i * 5;
	};

	return arrayCreated;
}