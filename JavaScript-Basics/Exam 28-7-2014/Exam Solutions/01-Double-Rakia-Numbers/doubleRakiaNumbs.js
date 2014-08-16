var input = [11210, 11215];

console.log(solution(input));

function solution(numbs) {

	var inNumb1 = Number(numbs[0]);
	var inNumb2 = Number(numbs[1]);
	var checkNumb = '';
	var checkPair = '';
	var isRakiya = 0;
	var rar = '';
	var result = '<ul>\n';
	
	for (var i = inNumb1; i <= inNumb2; i++) {

		checkNumb = i.toString();
		isRakiya = 0;
		
		//console.log(checkNumb);
	
		for (var j = 0; j < checkNumb.length-3; j++) {
		
			 checkPair = checkNumb.charAt(j) + checkNumb.charAt(j + 1);
			// console.log(checkPair);
			 
			 for (var k = j + 2; k < checkNumb.length - 1; k++) {
			 
				rar = checkNumb.charAt(k) + checkNumb.charAt(k + 1);
				
					//console.log(rar);
				if(checkPair ==  rar) {
					
					isRakiya = 1;
				}
			 }
		}

		 if (isRakiya == 1) {

		 	result = result +'<li><span class=\'rakiya\'>' + checkNumb + '</span><a href="view.php?id=' + checkNumb + '>View</a></li>\n';
		} else {
			result = result + '<li><span class=\'num\'>' + checkNumb + '</span></li>\n';
		}
	}
		result = result + '</ul>';
		
		return result;
}

		//var res = str.slice(2);
		 // var str = "11210";
	  //   var check = "11"
	  //   var n = str.search(check)
		
		//var res = str.match(/ain/g);