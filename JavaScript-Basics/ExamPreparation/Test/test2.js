function solution (input) {
	var inputArr = [];
	for (var m = 0; m < input.length; m++) {
		inputArr[m] = input[m];
	}
	function strAscnames(a, b){
		return a > b;
	}
	function strAscextension(a, b){
		return a.extension > b.extension;
	}
	var currInPer = [];
	var files = [];
	var counterPers = 0;
    var isPutextension = 0;
    var isPutId = 0; 
	for (var n = 0; n < inputArr.length; n++) {
		currInPer = inputArr[n].split(' ');
		isPutextension = 0;
		isPutId = 0;
		if (n === 0) {
			files[counterPers] = {extension:currInPer[1],
								   megaBytes:parseFloat(currInPer[2]),
								   names:[currInPer[0]]};
			counterPers += 1;
			continue;
		}
		for (var g in files) {
			if(currInPer[1] === files[g].extension){
				isPutextension = 1;						
				files[g].megaBytes += parseFloat(currInPer[2]);
				for (var h in files[g].names) {
					if (currInPer[0] === files[g].names[h]) {
						isPutId = 1;
					}
				}
				if (isPutId !== 1) {
					files[g].names.push(currInPer[0]);
				}	
			} 
		}		
		if (isPutextension === 0) {
			files[counterPers] = {extension:currInPer[1],
								   megaBytes:parseFloat(currInPer[2]),								   
								   names:[currInPer[0]]};
			counterPers += 1;
		} 	
	}
	var outArr = [];
	var out = '{';
	files = files.sort(strAscextension);
	for (var k = 0; k < files.length; k++) {
		files[k].names = files[k].names.sort(strAscnames);
	}
	for (var j = 0; j < files.length; j++) {
		out = '"'+files[j].extension+'":{"files":["';
		for (var i=0 ; i<files[j].names.length; i++) {
			out += files[j].names[i];
			if (i < files[j].names.length - 1) {
				out += '","';
			}
		}
		
		if (j === files.length-1) {
			if(files[j].megaBytes === 0){
				out += '"],"memory":"'+0+'"}}';
			} else {
				out += '"],"memory":"'+files[j].megaBytes.toFixed(2)+'"}}';
			}
		} else {
			if(files[j].megaBytes === 0){
				out += '"],"memory":"'+0+'"},';
			} else {
				out += '"],"memory":"'+files[j].megaBytes.toFixed(2)+'"},';
			}
		}
		outArr[j] = out;
	}
	out = '{';
	for (var l = 0; l < outArr.length; l++) {
		out += outArr[l]; 
	}
	console.log(out);
}