var input = [
	6,
	-55,
	133,
	14567
];	

for (var i = 0; i < input.length; i++) {
	
	lastDigitAsText(input[i]);
};

function lastDigitAsText(number) {

	var inNumb = number.toString();
	var lastNumb = inNumb.charAt(inNumb.length-1);



	var numbName;
    switch (parseInt(lastNumb)) {        

    	case 0:
            numbName = "Zero";
            break;
        case 1:
            numbName = "One";
            break;
        case 2:
            numbName = "Two";
            break;
        case 3:
            numbName = "Three";
            break;
        case 4:
            numbName = "For";
            break;
        case 5:
            numbName = "Five";
            break;
        case 6:
            numbName = "Six";
            break;
        case 7:
            numbName = "Seven";
            break;
        case 8:
            numbName = "Eight";
            break;
        case 9:
            numbName = "Nine";
            break;    
    }

    	console.log(numbName);
}