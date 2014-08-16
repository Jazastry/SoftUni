
var input = [
	[3, 2, 3, 4, 2, 2, 4],	
	[3, 5, 4, 6, 1, 2, 3, 6, 10, 32],
	[3, 2, 1]

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

		if (arreyIn[i] < arreyIn[i + 1]) {

			count += 1;
			resultA[count] = arreyIn[i + 1];				

		} 

		if ((arreyIn[i + 1] < arreyIn[i]) || ((i == (arreyIn.length - 1)))) {

			count = 0;

			if (resultB.length < resultA.length) {

				for (var j = 0; j < resultA.length; j++) {

					resultB[j]  = resultA[j];

				};
				for (var j = 0; j < resultA.length; j++) {

					resultA.splice(0,1);

				};				
			};	
		};
	};

	if (resultB.length == 1) {

		resultB = 'no';
	};

	return resultB;
}