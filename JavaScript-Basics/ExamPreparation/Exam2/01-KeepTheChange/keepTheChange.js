function solution(input) {

	var bill = input[0];
	var mood = input[1];
	var result;
	var percent;
	var n;

	if (mood === 'happy') {
		result = (10 / 100) * parseFloat(bill);
		console.log(result.toFixed(2));
	} else if (mood === 'married') {
		result = (0.05 / 100) * parseFloat(bill);
		console.log(result.toFixed(2));
	} else if (mood === 'drunk') {
		percent = (15 / 100) * parseFloat(bill);
		n = percent.toString()[0];
		n = parseInt(n);
		result = Math.pow(percent, n);
		console.log(result.toFixed(2));
	} else if ((mood !== 'drunk') || (mood !== 'married') || (mood !== 'happy')) {
		result = (5 / 100) * parseFloat(bill);
		console.log(result.toFixed(2));
	}
} 

// solution([ '120.44', 'happy' ]);
// solution([ '1230.83', 'drunk' ]);
solution(['716.00','married']);