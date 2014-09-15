function solution(input){
	var inputArr = input[0].split(/[^0-9]/);
	inputArr = inputArr.filter(function(n){ return n !== '';});
	var outputArr = [];
	var arrCount = 0;
	var counter = 1;
	for (var id in inputArr) {
		inputArr[id] = parseInt(inputArr[id]);
	}
	for (var i = 1; i < inputArr.length; i++) {
		var cur = Math.abs(inputArr[i]);
		var prev = Math.abs(inputArr[i-1]);
		var curNum = cur%2;
		var prevNum = prev%2;
		if (((curNum === 0) && (prevNum !== 0)) || ((curNum !== 0) && (prevNum === 0)) ||
			((cur === 0) && (prevNum !== 0)) || ((cur === 0) && (prevNum === 0)) ||
			((curNum === 0) && (prev === 0)) || ((curNum !== 0) && (prev === 0)) ||
			((cur === 0) && (prev === 0))) {
			counter += 1;
		} else {			
			outputArr[arrCount] = counter;
			arrCount += 1;
			counter = 1;
		}
	}
	outputArr[arrCount] = counter;
	// var max = Math.max.apply(null, arr);
	var output = Math.max.apply(null, outputArr);
	console.log(output);
}
// arrs = arrs.filter(function(n){ return n !== ''; });

solution(['()()()()()']);