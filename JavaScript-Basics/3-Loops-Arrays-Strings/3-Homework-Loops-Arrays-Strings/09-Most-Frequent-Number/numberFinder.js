var input = [
	[4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3],
	[2, 1, 1, 5, 7, 1, 2, 5, 7, 3, 87, 2, 12, 634, 123, 51, 1],
	[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
];

for (var i = 0; i < input.length; i++) {
	
	console.log(findMostFreqNum(input[i])[0] + ' (' + findMostFreqNum(input[i])[1] + ' times)');
};

function findMostFreqNum(value)  {

	var inArray = value;
	var order = inArray.sort(sortNumber);
	var numsArr = [];
	var numsCount = [];
	var countCurr = 1;
	var count = 0;

	for (var i = 0; i < inArray.length; i++) {
		
		if (inArray[i] == inArray[i+1]) {

			countCurr += 1;

		} else {

			numsCount[count] = countCurr;
			numsArr[count] = inArray[i];
			count += 1;
			countCurr = 1;
		};
	};

	var indexBiggest = 0;
	var biggest = numsCount[0];

	for (var i = 1; i < numsCount.length; i++) {
		
		if (numsCount[i] > biggest) {

			biggest = numsCount[i];
			indexBiggest = i;
		};
	};

	return [numsArr[indexBiggest], numsCount[indexBiggest]];
}

function sortNumber(a,b) {
    return a - b;
}
