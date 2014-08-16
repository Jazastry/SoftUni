
var input = "But you were living in another world tryin' to get your message through";

console.log(replaceSpaces(input));

function replaceSpaces(value) {

	var str = value;
	var res = str.replace(/ /g, ''); 

	return res;
}