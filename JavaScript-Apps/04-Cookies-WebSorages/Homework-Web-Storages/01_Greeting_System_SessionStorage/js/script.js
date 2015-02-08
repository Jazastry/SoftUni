if ((parseInt(sessionStorage.allVisitsCounter) !== undefined) && 
	(!isNaN(parseInt(sessionStorage.allVisitsCounter)))) {

	sessionStorage.allVisitsCounter = parseInt(sessionStorage.allVisitsCounter) + 1;
	$('body').text('Hello ' + sessionStorage.visitorName + 'This session visits : ' + sessionStorage.allVisitsCounter + '.');

} else {
	$('#save').click(function(){
	sessionStorage.visitorName = $('#userName').val();	
	sessionStorage.allVisitsCounter = 1;
	$('#userPrompt').hide();
	});
}
