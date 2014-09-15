function solve (input) {
	var inStr = input[0].split(/[^a-zA-Z]+/);
	var strOne = '';
	var strTwo = '';
	var strToCheck = '';
	var result = [];
	var counter = 0;
	inStr = inStr.filter(function(n){ return n !== ''; });
	for (var i = 0; i < inStr.length; i++) {
		strToCheck = inStr[i];
		for (var j = 0; j < inStr.length; j++) {
			strOne = inStr[j];
			for (var k = 0; k < inStr.length; k++) {
				strTwo = inStr[k];
				if ((j !== i) && (k !== i) && (k !== j)) {
					if (strToCheck === (strOne + strTwo)) {
						if (result[counter-1] === (strOne+'|'+strTwo+'='+strToCheck)) {
							continue;
						} else {
							result[counter] = strOne+'|'+strTwo+'='+strToCheck;
							
							counter += 1;
						}						
					}
				}
			}
		}
	}
	result = result.filter(function(element, position) {
    return result.indexOf(element) === position;
});
	if (counter === 0) {
		return 'No';
	} else {		
		return result.join('\n');		
	}	
}

console.log(solve(['Lo rem ips um dol or si t am et, consectetur adipiscing elit. Fusce et ultricies ipsum. Phasellus vitae justo rutrum, tempor mauris in, posuere lectus. Nunc accumsan, neque et ultricies faucibus, metus est commodo turpis, eget mattis lorem leo quis ante. Sed tincidunt ornare tincidunt. Mauris aliquam posuere sapien et blandit. Aenean sit amet nunc vel felis feugiat rutrum. Quisque aliquet arcu sed velit fringilla, vitae pharetra diam fringilla.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce et ultricies ipsum. Phasellus vitae justo rutrum, tempor mauris in, posuere lectus. Nunc accumsan, neque et ultricies faucibus, metus est commodo turpis, eget mattis lorem leo quis ante. Sed tincidunt ornare tincidunt. Mauris aliquam posuere sapien et blandit. Aenean sit amet nunc vel felis feugiat rutrum. Quisque aliquet arcu sed velit fringilla, vitae pharetra diam fringilla.']));
