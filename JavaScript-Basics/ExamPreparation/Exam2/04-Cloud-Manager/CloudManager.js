function solution(input){
	var inArr = [];
	for (var i = 0; i < input.length; i++) {
		inArr[i] = input[i].split(' ');
	}
	// console.log(inArr); 
	function checkIfIsPassingPl(curX, curY){
		for (var j = 0; j < 3; j++) {		
			var starX = parseFloat(inArr[j][1]);
			var starY = parseFloat(inArr[j][2]);
			for (var x = curX - 1; x < curX + 1; x += 1) {
				for (var y = curY - 1; y < curY + 1; y += 1) {
					if ((starX-1 <= curX) && (starX+1 >= curX) 
						&& (starY-1 <= curY) && (starY+1 >= curY)) {
						return inArr[j][0].toLowerCase();
					}
				}
			}
		}
		return 'space';
	}
	var ourX = parseFloat(inArr[3][0]);
	var ourY = parseFloat(inArr[3][1]);
	var path = parseFloat(inArr[4][0]);
	for (var k = ourY; k < path+ourY+1; k++) {
		// console.log('ourX:'+ourX+' '+'ourY'+ourY);
		console.log(checkIfIsPassingPl(ourX, k));
	}
}

solution([ 'Alpha-Centauri 7 5',
  'Sirius 7 8',
  'Gamma-Cygni 10 10',
  '8 1',
  '6' ]);