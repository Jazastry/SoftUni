$("button").click(function (e) {
	var direction;
	direction = e.target.value;
	console.log(direction);
	$("#slider1").animate({width:'50'}, 500);
	 return false;
});