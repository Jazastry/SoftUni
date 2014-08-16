
var input = [
	[5, 10, 15, 111],
	[33, 44, -99, 0, 20],
	['hello'],
	[5, 3.3]
];

for (var i = 0; i < input.length; i++) {
	
	findLargestBySumOfDigits(input[i]);
};


function findLargestBySumOfDigits(nums) {

	var inArr = nums;
	var stringValue = 0;
	var max = 0;
	var indexOfMax = 0;
	var currentNumb = '';
	var isInt = true;


	for (var i = 0; i < inArr.length; i++) {
		
		stringValue = 0;

		currentNumb =  inArr[i].toString().replace('-', '');

		for (var j = 0; j < currentNumb.length; j++) {

			if (currentNumb % 1 !== 0) {

				isInt = undefined;
				break;
			}
			stringValue += parseInt(currentNumb.charAt(j));

		};

		if (max < stringValue) {

			max = stringValue;
			indexOfMax = i;
		};


		
	}; 

	if (isInt == true) {

		console.log(inArr[indexOfMax]);

	} else {

		console.log(isInt);
	}
}