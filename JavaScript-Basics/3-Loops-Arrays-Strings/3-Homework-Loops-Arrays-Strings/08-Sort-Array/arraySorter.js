
var input = [
	[5, 4, 3, 2, 1],
	[12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3]
];	

var inputSorted = [];

for (var i = 0; i < input.length; i++) {

	inputSorted = sortArray1(input[i]);

	console.log(inputSorted);
};

function sortArray1(value) {

    var temp1;
    var temp2;
    var arrayIn = value;

    for (var i = 0; i < arrayIn.length; i++) {
    	
    	temp1 = i;

    	for (var j = i + 1; j < arrayIn.length; j++) {
    		
    		if (arrayIn[j] < arrayIn[temp1]) {

    			temp2 = arrayIn[j];
    			arrayIn[j] = arrayIn[temp1];
    			arrayIn[temp1] = temp2;

    		};
    	};
    };

    return arrayIn;
}