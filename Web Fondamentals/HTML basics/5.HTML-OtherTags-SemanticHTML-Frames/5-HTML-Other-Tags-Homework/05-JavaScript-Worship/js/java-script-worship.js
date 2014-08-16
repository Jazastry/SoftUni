var c = document.getElementById("myCanvas");
var ctx = c.getContext("2d");
ctx.fillStyle = "#F1DA4E";
ctx.fillRect(55,99,180,190);

var c1 = document.getElementById('myCanvas'),
	context = c1.getContext('2d');
   
	context.font = '35px "Verdana"';
	context.fillStyle = '#000000';
	// context.strokeStyle = 'blue';

	context.fillText("I love JavaSript", 10, 60);

var c2 = document.getElementById('myCanvas'),
	context = c2.getContext('2d');
   
	context.font = 'bold 110px "Arial"';
	context.fillStyle = '#000000';
	context.strokeStyle = 'blue';

	context.fillText("JS", 100, 280);