
var input = [
	'in the middle of the night',
	'Welcome to SoftUni. Welcome to Java. Welcome everyone.',
	'Hello my friend, hello my darling. Come on, come here. Welcome, welcome darling.'
];

for (var i = 0; i < input.length; i++) {

	findMostFreqWord(input[i]);
	console.log('\n');
};


function findMostFreqWord(value) {

	var patt = /\w+/g;	
	var inpOne = value.toLowerCase();
	var separated = inpOne.match(patt).sort();
	
	var word = '';
	var obj = {};

	for (var i = 0; i < separated.length; i++) {

		word = separated[i]; 
				
		if (word in obj) {

			obj[word] += 1;
		} else {

			obj[word] = 1;
		}		
	};

	var words = Object.keys(obj);
	var indexSingle = 0;
	var indexMultiple = [];
	var count = 0;

	for (var i = 0; i < words.length - 1; i++) {

		if (obj[words[i + 1]] > obj[words[indexSingle]] ) {

			indexSingle = i + 1;
			indexMultiple = [];
			count = 0;
		} else if (obj[words[i + 1]] ==  obj[words[indexSingle]]) {

			if (count == 0) {
				indexMultiple[count] = i;
			};
			count += 1;
			indexMultiple[count] = i+1;
		} 
	};

	if (count == 0) {

		console.log(words[indexSingle] + ' -> ' + obj[words[indexSingle]] + ' times');
	} else {

		for (var i = 0; i < indexMultiple.length; i++) {

			indexMultiple[i]
			console.log(words[indexMultiple[i]] + ' -> ' + obj[words[indexMultiple[i]]] + ' times');
		};
	}
}