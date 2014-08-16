
function calculateExpression() {

	var str = document.getElementById('inputField').value;
    var patt1 = /[\d+(-\/*+)]+/; 
	var result = eval(str.match(patt1).toString());
    document.getElementById('outputField').innerHTML = result;
}