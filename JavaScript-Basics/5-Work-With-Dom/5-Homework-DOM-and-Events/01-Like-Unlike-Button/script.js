var count = 1;

function changeButon() {

	var text = ['Like', 'Unlike'];
	if (count == 1) {

	document.getElementById('button').innerHTML = text[count];
	count = 0;
	} else {

	document.getElementById('button').innerHTML = text[count];
	count = 1;	
	}
}