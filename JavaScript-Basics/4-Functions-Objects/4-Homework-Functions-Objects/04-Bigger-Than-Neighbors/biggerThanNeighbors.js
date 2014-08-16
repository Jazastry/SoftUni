
var input = [
	[2, [1, 2, 3, 3, 5]],
	[2, [1, 2, 5, 3, 4]],
	[5, [1, 2, 5, 3, 4]],
	[0, [1, 2, 5, 3, 4]],
];

for (var i = 0; i < input.length; i++) {

	biggerThanNeighbors(input[i][0], input[i][1]));
};


function biggerThanNeighbors(index,  arr) {

	var inIndex = index;
	var inArr = arr;
	var result;

	if ((inArr.length <= inIndex) || (inIndex < 0)) {

		console.log('invalid index');
		result = undefined;

	} else if ((inIndex == 0) || (inIndex == (inArr.length - 1))) {

		console.log('only one neighbor');
		result = false;

	} else if ((inArr[inIndex] > (inArr[inIndex - 1])) && (inArr[inIndex] > (inArr[inIndex + 1]))) {

		console.log('bigger');
		result = true;

	} else if ((inArr[inIndex] <= (inArr[inIndex + 1])) || (inArr[inIndex] <= (inArr[inIndex - 1]))) {

		console.log('not bigger');
		result = false;
	}

	return result;
}