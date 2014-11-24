$(function($){
	var PARSE_APP_ID = "QFDHAYIxgeNrofyDI6kABUANT5QLOU0czweGbM0E";
	var PARSE_REST_API_KEY = "yZ9U8A0vlHViGVwmlL85cPrADPtBy3DTnuYj2VfP";

	loadClass('Question');

	function loadClass(className, relatedTo, id, pointer) {
				// loadClass('Answer', 'Question', question.objectId);
		var filter = id ? '?where={"'+pointer+'":{"__type":"Pointer","className":"'+relatedTo+'","objectId":"'+id+'"}}': '';
// '?"$relatedTo":{"'+relatedTo+'":{"__type":"Pointer","className":"'+relatedTo+'","objectId":"'+id+'"'
//  '?where={"question":{"__type":"Pointer","className":"Question","objectId":"'+id+'"'
		$.ajax({
			method: "GET",
			headers: {
				"X-Parse-Application-Id": PARSE_APP_ID,
				"X-Parse-REST-API-Key": PARSE_REST_API_KEY
			},
			url: " https://api.parse.com/1/classes/" + className + filter,
			success: function(data) {
				var resultClass = data.results[0].classType;
				switch(resultClass){
					case 'question':
						questionsLoaded(data);
						break;
					case 'answer':
						answersLoaded(data);
						break;
				}
			},
			//error: ajaxError 
		});
	}

	function questionsLoaded(data) {
		for (var i = 0; i < data.results.length; i++) {
			var question = data.results[i];
			var liElement = $('<li>');
			var linkElement = $('<a href="#"/>').text(question.title);
			$(linkElement).data('question', question);
			liElement.append(linkElement);
			$('#questionsUl').append(liElement);
			$(linkElement).click(showSelectedQuestion);
		}		
	}

	function showSelectedQuestion() {
		var question = $(this).data('question');
		$('#fullQuestionDiv h2').text(question.title + ' by ' + question.user);
		$('#fullQuestionDiv p').text(question.questionText);
		$('#answersUl').empty();
		$('#answersUl').data('question', question);
		loadClass('Answer', 'Question', question.objectId, 'question');
	}

	function answersLoaded(data) {
		for (var i = 0; i < data.results.length; i++) {
			var answer = data.results[i];
			var liElement = $('<li>');
			var pElement = $('<p>');
			$(pElement).text(data.results[i].text);
			$(pElement).data('answer', answer);
			liElement.append(pElement);
			$('#answersUl').append(liElement);			
		}
		$('#answersUl').append('<button id="addAnswer">Add Answer</button>');
		$('#addAnswer').click();
	}

	function clickedAddAnswer() {
		$.ajax({
			method: "POST",
			headers: {
				"X-Parse-Application-Id": PARSE_APP_ID,
				"X-Parse-REST-API-Key": PARSE_REST_API_KEY
			},
			url: " https://api.parse.com/1/classes/Answer{}",
			success: function(data) {
				var resultClass = data.results[0].classType;
				switch(resultClass){
					case 'question':
						questionsLoaded(data);
						break;
					case 'answer':
						answersLoaded(data);
						break;
				}
			},
			//error: ajaxError 
		});
	}

}(jQuery));