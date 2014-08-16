
var input = [20, -5, 13];
var output = '';
var counter;

for (var i = 0; i < input.length; i++) {

	var output = '';
	
	for (var j = 0; j < printNumbers(input[i]).length; j++) {

		if (counter == 0) {

			output = 'no';

			break;
		}

		output += printNumbers(input[i])[j] + ',';
	};


	console.log(output);
}

function printNumbers(n) {

	var result = [];
    counter = 0;

	for (var i = 0; i <= n; i++) {

		if (((i % 4) !== 0) && ((i % 5) !== 0)) {

			result[counter] = i;
			counter += 1;	

		}
	}
  
  if (counter == 0) {
    
    var result = 'no';
  }

	return result;
}