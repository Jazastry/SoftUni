var slider = $('.slider');
for (var i = 0; i < slider.length; i++) {
	if (i !== 1) {
		$(slider[i]).css('display','none');
	}
}

$("button").click(function (e) {
	var direction;
	direction = e.target.value;
	if (direction === 'left') {
		$(slider[1]).hide("slide", { direction: 'left' }, 1000);
		$(slider[2]).show("slide", {direction: 'right'}, 1000);
		$(slider[0]).insertAfter(slider[3]);
		slider = $('.slider');
		console.log(slider);
	} else if (direction === 'right') {
		$(slider[3]).insertBefore(slider[0]);
		$(slider[1]).hide("slide", { direction: 'right' }, 1000);
		$(slider[0]).show("slide", {direction: 'left'}, 1000);
		slider = $('.slider');
	}

	 return false;	
});
