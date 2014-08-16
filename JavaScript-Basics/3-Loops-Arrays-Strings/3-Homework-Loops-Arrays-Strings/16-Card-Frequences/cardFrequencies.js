
var input = [
	'8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦',
	'J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠',
	'10♣ 10♥'
];
findCardFrequency(input[2]);


function findCardFrequency(value) {

	var patt = /\w+/g;	
	var inpOne = value;
	var separated = inpOne.match(patt);
	
	var word = '';
	var obj = {};
	var orderArr = [];
	var matchCheck = 0;
	var count = 0;

	for (var i = 0; i < separated.length; i++) {

		word = separated[i]; 
				
		if (word in obj) {

			obj[word]+= 1;
			
		} else {

			obj[word] = 1;
		}
		if (i == 0) {
			
			orderArr[i] = word; 
		} else {

			for (var j = 0; j < orderArr.length; j++) {
				
				if (word == orderArr[j]) {

					matchCheck += 1;
				};
			};
		}	
		if (matchCheck == 0) {

			orderArr[count] = word;
			count += 1;
		};
	};

	var words = Object.keys(obj);
	var property = '';
	var percent = 0;
	var divider = separated.length;

	for (var i = 0; i < orderArr.length; i++) {
		
		console.log(orderArr[i]  + ' -> ' + ((parseInt(obj[orderArr[i]])/divider)*100).toFixed(2) + '%');
	}; 
}