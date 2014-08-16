
var input = [8, 3, 5];

for (var i = 0; i < input.length; i++) {
	convertDigitToWord(input[i]);
};

function convertDigitToWord(a) {

	var output;

	switch(a){
		case 0:
			output = "zero";
			break;
		case 1:
			output = "one";
			break;
		case 2:
			output = "two";
			break;
		case 3:
			output = "three";
			break;
		case 4:
			output = "for";
			break;
		case 5:
			output = "five";
			break;
		case 6:
			output = "six";
			break;
		case 7:
			output = "seven";
			break;
		case 8:
			output = "eight";
			break;
		case 9:
			output = "nine";
			break;
		case 10:
			output = "ten";
			break;						
	}	

	console.log(output);
} 