$('button').click(false, function(){
	$('.' + $('#class').val())
	.css({'background-color': $('#color').val()});
	return false;
});

