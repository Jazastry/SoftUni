if ((parseInt(localStorage.allVisitsCounter) !== undefined) && 
	(!isNaN(parseInt(localStorage.allVisitsCounter)))) {

	if ((parseInt(sessionStorage.allVisitsCounter) === undefined) || 
	(isNaN(parseInt(sessionStorage.allVisitsCounter)))) {
	sessionStorage.allVisitsCounter = 0;
	}

	localStorage.allVisitsCounter = parseInt(localStorage.allVisitsCounter) + 1;
	sessionStorage.allVisitsCounter = parseInt(sessionStorage.allVisitsCounter) + 1;
	$('body').text('Hello ' + localStorage.visitorName + '!  All visits : ' + localStorage.allVisitsCounter + '.   ' +
					'This session visits : ' + sessionStorage.allVisitsCounter + '.');

} else {
	$('#save').click(function(){
	localStorage.visitorName = $('#userName').val();	
	localStorage.allVisitsCounter = 1;
	sessionStorage.allVisitsCounter = 1;
	$('#userPrompt').hide();
	});
}
