var Question = (function(){
	function Question(questionText, answerText) {
		this.setQuestion(questionText);
		this.setAnswer(answerText);
	}

	Question.prototype.setQuestion = function(question) {
		this._questionText = question;
	};

	Question.prototype.getQuestion = function() {
		return this._questionText;
	};

	Question.prototype.setAnswer = function(answer) {
		this._answerText = answer;
	};

	Question.prototype.getAnswer = function() {
		return this._answerText;
	};

	Question.prototype.setLastGivenAnswer = function(answer) {
		this._lastGivenAnswer = answer;
	};

	return Question;
}());

var questOne = new Question($('#questionOne').text(), 'No');
var questTwo = new Question($('#questionTwo').text(), 'No');
var questThree = new Question($('#questionThree').text(), 'Only Apple Computers have souls !');

var timeInterval = 300;

var extensions = (function(){
	function setResults() {
		localStorage.timeRemained = timeInterval;
		localStorage.lastResults = JSON.stringify([questOne, questTwo, questThree]);
	}

	function getResults() {
		var result = [];
		result = JSON.parse(localStorage.lastResults);
		return result;
	}

	function updateStorage() {
		questOne.setLastGivenAnswer($('input[name=questionOne]:checked').val());
		questTwo.setLastGivenAnswer($('input[name=questionTwo]:checked').val());
		questThree.setLastGivenAnswer($('input[name=questionThree]:checked').val());
		extensions.setResults();
	}

	function showResults() {
		var results = extensions.getResults();
		var question, answer, isCorrect, el, correctAnswer;
		for (var i = 0; i < results.length; i++) {
			el = $('#answerHolder').last();
			$(el).parent().append($(el).clone(true));
			answer = results[i]._lastGivenAnswer;
			question = results[i]._questionText;
			correctAnswer = results[i]._answerText;
			isCorrect = (answer === results[i]._answerText) ? ' - correct ! ' : ' - incorrect. ' + "   The answer is -> " + correctAnswer;
			$(el).text(question + '   Your answer : ' + answer + isCorrect);
			$('#result').add(el);
			$('#submitBtn').hide();
		}
	}

	function stopTimer() {
	    clearInterval(myTimer);
	}

	function endOfGame() {
		extensions.updateStorage();
		extensions.showResults();
		extensions.stopTimer();
		$('#submitBtn').hide();
	}

	return {
		setResults: setResults,
		getResults: getResults,
		showResults: showResults,
		updateStorage: updateStorage,
		stopTimer: stopTimer,
		endOfGame: endOfGame
	};
}());

var myTimer= setInterval(function(){
	timeInterval -= 1;
	(function() {
		if (timeInterval > 0) {
			$('h1').text('Time Remaining : ' + timeInterval + 'sec.');	
			extensions.updateStorage();
		} else {
			$('h1').text('Time Finished ! Try again !');
			extensions.stopTimer();
			$('#submitBtn').hide();
		}
	})();
},1000);

$('#submitBtn').click(function(){
	extensions.endOfGame();
});

if (localStorage.timeRemained !== undefined) {
	extensions.endOfGame();
}
