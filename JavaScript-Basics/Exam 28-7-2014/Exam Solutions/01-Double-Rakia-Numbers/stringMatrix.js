
var input = [
	'Rotate(270)',
	'hello',
	'softuni',
	'exam',
];

rotation(input);

function rotation(arr) {
	
	var inArr = arr;
	var degree = (parseInt(inArr[0].match(/[0-9]+/g))) / 90;
	
	var position = 0;
	
	for(var j = 0; j < degree; j++) {
		
		position += 1;
		
			
		if (position === 4) {
		
			position = 0;
		}
	}
	
	console.log(position);
	var maxLength = 0;
	
	for(var i = 1 ; i < inArr.length - 1; i++) {
	
		maxLength = inArr[i].length;
		
		if ( inArr[i + 1].length  > maxLength) {
		
			maxLength = inArr[i + 1].length;
		}
	}
	
	var curentWordLenght = 0;
	
	for(var k = 1 ; k < inArr.length; k++) {
	
		curentWordLenght = inArr[k].length;
		
		for (var l = maxLength - inArr[k].length ; l > 0; l--) {
		
			inArr[k] += '. ';
		}
	}
	 
	 var wordsArr = [];
	 
	 for(var o = 1 ; o < inArr.length; o++) {
	 
		if (o !== 0) {
		
			 wordsArr[o-1] = inArr[o];
		}
	 }
	 
	  var resultStr = '';
	  var res = '';
	 
	 if (position === 0) {
		
		for(var k = 0 ; k < wordsArr.length; k++) {
		
			 console.log(wordsArr[k]);
		}	 
			 
	 }	 else if (position == 1) {
	  
			for (var m = 0 ; m < maxLength; m++) {
			 
				resultStr = '';
				
				 for (var n = wordsArr.length - 1; n  >= 0; n--) {
				
					 resultStr = resultStr + wordsArr[n].charAt(m);
				 }
				 
				 res = res + result + '\n';
			}
			
	}	else if (position == 2) {
	
		for (var o = wordsArr.length - 1; o  >= 0; o--) {
				
				resultStr = '';
				
				 for (var p = maxLength - 1 ; p >= 0; p--) {
				
					 resultStr = resultStr + wordsArr[p].charAt(o);
				 }
				 
				 res = res + result + '\n';
			}
	}	//else if (position == 3)  {
	    //
		//for (var m = maxLength - 1 ; m > 0; m++) {
		//	 
		//		resultStr = '';
		//		
		//		 for (var n = 0; n  < wordsArr.length; n++) {
		//		
		//			 resultStr = resultStr + wordsArr[n].charAt(m);
		//		 }
		//		 
		//		 console.log(resultStr)   ;
		//	}
	//}
	return res;
}

