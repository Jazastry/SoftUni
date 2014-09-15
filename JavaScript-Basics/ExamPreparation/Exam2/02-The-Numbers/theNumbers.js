function solution(input) {
	var inputArr = input[0].split(/[^0-9]/);
	inputArr = inputArr.filter(function(n){ return n !== ''; });

	function decimalToHex(d, padding) {
	    var hex = Number(d).toString(16).toUpperCase();
	    padding = typeof (padding) === "undefined" || padding === null ? padding = 2 : padding;

	    while (hex.length < padding) {
	        hex = "0" + hex;
	    }

	    return '0x'+hex;
	}
	var result = '';
	for (var i = 0; i < inputArr.length; i++) {

		result += decimalToHex(parseInt(inputArr[i]), 4);
		if (i !== inputArr.length-1) {
			result += '-';
		}
	}
	console.log(result);
}

// solution([ '5tffwj(//*7837xzc2---34rlxXP%$".' ]);
// solution([ '482vMWo(*&^%$213;k!@41341((()&^>><///]42344p;e312' ]);
solution([ '20' ]);