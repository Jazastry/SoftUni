
var input = [
	'Hello, how are you.',
	'Life is pretty good, isn’t it?'

];

for (var i = 0; i < input.length; i++) {
	
	reverseWordsInString(input[i]);
};

function reverseWordsInString(str) {

	var inString = str;
    var res = inString.split(' ');
    var reverseSentence = '';
    var reverseWord = '';

    for (var i = 0; i < res.length; i++) {
    	
    	reverseWord = '';

    	for (var j = 0; j < res[i].length; j++) {
    		
    		reverseWord += res[i].charAt((res[i].length -1 ) - j);
    	};

    	reverseSentence += reverseWord + ' ';
    };

    console.log(reverseSentence);
}