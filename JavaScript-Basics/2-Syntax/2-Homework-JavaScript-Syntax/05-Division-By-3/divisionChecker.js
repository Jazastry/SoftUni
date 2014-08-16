
var input = [13, 12, 189, 591];
var i = 0;
var haveOrNot;

for (i = 0; i < input.length; i++) {

	haveOrNot = divisionBy3(input[i]);

	console.log(input[i] + '\n' + 'the number is' + haveOrNot + 'divided by 3 without remainder');
};

function divisionBy3(value) {

	var input = value.toString();

	var sum = 0;

	var haveReminder = ' ';

	for (var i = 0; i < input.length; i++) {
		
		sum += parseInt(input.charAt(i));
		
	};

	if (((sum / 3) % 1) != 0) {

		haveReminder = ' ' + 'not' + ' ';
	};

	return haveReminder;
}