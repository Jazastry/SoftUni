
var input = 'There is a man, his name was Bob.';

findPalindromes(input);

function findPalindromes(value) {

	var inPu = value.toLowerCase();
	
	var patt = /\w+/g;

	var trans = inPu.match(patt);

	for (var i = 0; i < trans.length; i++) {		

		if ( trans[i] == trans[i].split("").reverse().join("")) {

			console.log(trans[i]);
		};
	}
}