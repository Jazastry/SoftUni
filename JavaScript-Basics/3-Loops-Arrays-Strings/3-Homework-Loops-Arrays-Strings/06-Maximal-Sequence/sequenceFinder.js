
var input = [
	[2, 1, 1, 2, 3, 3, 2, 2, 2, 1], // 0
	['happy'],						// 1
	[2, 'qwe', 'qwe', 3, 3, '3']    // 2
];


for (var i = 0; i < input.length; i++) {

	console.log(findMaxSequence(input[i]));	
};

function findMaxSequence(value) {

	var arreyIn = value;
	var resultA = [];
	var resultB = [];
	var count = 0;

	for (var i = 0; i < arreyIn.length; i++) {
		
		if (count == 0) {

			resultA[count] = arreyIn[i];
		};

		if (i < arreyIn.length) {

			if (arreyIn[i] === arreyIn[i + 1]) {

				count += 1;

				resultA[count] = arreyIn[i + 1];

			} else {

				count = 0;

				if (resultA.length > resultB.length) {

					for (var i = 0; i < resultA.length; i++) {
						resultB[i]  = resultA[i];
					};
				};	
			};
		};
	};

	return resultB;

}