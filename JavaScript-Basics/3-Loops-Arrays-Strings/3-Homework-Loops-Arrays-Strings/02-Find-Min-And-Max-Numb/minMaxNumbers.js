
var input = [
	[1, 2, 1, 15, 20, 5, 7, 31],
	[2, 2, 2, 2, 2],
	[500, 1, -23, 0, -300, 28, 35, 12]
];

for (var i = 0; i < input.length; i++) {
	
	console.log('\nMin -> ' + findMinAndMax(input[i].sort(sortNumber))[0]);
	console.log('Max -> ' + findMinAndMax(input[i])[1]);
};

function findMinAndMax(value) {

	var inArray = value;
	var miminum = inArray.sort(sortNumber)[0];
	var maxinum = inArray.sort(sortNumber)[inArray.length-1];

	return [miminum, maxinum];
}

function sortNumber(a,b) {
    return a - b;
}
