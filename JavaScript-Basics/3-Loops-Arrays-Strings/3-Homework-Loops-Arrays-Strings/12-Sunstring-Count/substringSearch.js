
var input = [
	['in', "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days."],
	['your', 'No one heard a single word you said. They should have seen it in your eyes. What was going around your head.'],
	['but', "But you were living in another world tryin' to get your message through."]
];

for (var id in input) {
	
	console.log(countSubstringOccur(input[id]));
}


function countSubstringOccur(inp) {

	var regExp = new RegExp(inp[0], "gi");
	var text = inp[1];

    var result = text.match(regExp) ? text.match(regExp).length : 0;
    
    return result;
}
