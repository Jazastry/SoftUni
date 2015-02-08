var app = app || {};

app.controller = (function(){
	function Controller(dataPersister) {
			this.persister = dataPersister;
	}

	Controller.prototype.loadEvents = function() {
		var _this = this;
		$('#backButton').click(function(){
			$('#results').hide();
			$('#questions').show();
		});
		$('main').on('click', '#voteButton', function(ev){
			$('#results').show();
			$('#questions').hide();
			// :::::::::::::::::::: QUESTIONS ::::::::::

			var questData = $(this).parent().data('question');
			var localQuestions = JSON.parse(sessionStorage.getItem('questions'));
			var peopleCount;
			for (var i = 0; i < localQuestions.length; i++) {
				if (localQuestions[i].objectId === questData.objectId) {
					localQuestions[i].peopleVoted = localQuestions[i].peopleVoted + 1;
					peopleCount = localQuestions[i].peopleVoted;
				}
			}
			sessionStorage.setItem('questions', JSON.stringify(localQuestions));
			_this.persister.question.change(questData.objectId, {"peopleVoted":peopleCount},
			function(data){
				_this.successMessage('Voted Successfull !');
			},
			function(){
				_this.errorMessage('Voting Error try again !')
			});

			// :::::::::::::::::::::  Ansewrs :::::::::::::::::

			var checkedAnsId = $(this).prev().find('input:checked').val();
			var localAnswers = JSON.parse(sessionStorage.getItem('answers'));
			var voteToChange;
			for (var i = 0; i < localAnswers.length; i++) {
				if (localAnswers[i].objectId === checkedAnsId) {
					localAnswers[i].votes = localAnswers[i].votes + 1;
					voteToChange = {"votes":localAnswers[i].votes};
				}
			}
			sessionStorage.setItem('answers', JSON.stringify(localAnswers));

			_this.persister.answer.change(checkedAnsId, voteToChange,
				function(data){
					_this.successMessage('Voted Successfull !');
				},
				function(){
					_this.errorMessage('Voting Error try again !')
				});
			var answersToShow = _.filter(localAnswers, function(answer){
				return answer.questionPointer.objectId === questData.objectId;
			});
			_this.loadGraphs(answersToShow, questData.title, peopleCount);
		});
	};

	Controller.prototype.loadGraphs = function(answers, questionTitle, peopleCount) {
		$('#results').children('div').text(questionTitle);
		var lis = $('#results').find('ul').find('li').each(function(index){
			var i = parseInt(index);
			var percent = (parseInt(answers[i].votes) / parseInt(peopleCount))*100;
			$(this).children('.answer').text(answers[i].answerText);
			$(this).children('.percents').css('width', percent+'%').text(percent.toPrecision(2));
		});
	};

	Controller.prototype.loadQuestions = function() {
		var _this = this;
		var answers = JSON.parse(sessionStorage.getItem('answers'));
		this.persister.question.getAll(
			function(data){
				sessionStorage.setItem('questions', JSON.stringify(data.results));
				for (var i = 0; i < data.results.length; i++) {
					var thisQuestId = data.results[i].objectId;
					var liAnswers = _.filter(answers, function(answer){
						return answer.questionPointer.objectId === thisQuestId;
					});
					var li = $('#questions li').last();
					$(li).clone().appendTo('#questions');
					$(li).data('question', data.results[i]);
					$(li).find('div').text(data.results[i].title);
					$(li).find('input').each(function(index){
						var i = parseInt(index);
						var ans = liAnswers[i].answerText;
						var inpu = $(this);
						var lab = $(this).find('label');
						$(this).next('label').text(liAnswers[i].answerText);
						$(this).val(liAnswers[i].objectId);
					});
				}
				 $('#questions li').last().remove();
				 _this.loadEvents();
			},
			function(){
					_this.errorMessage('Load Questions Error!');
			});
	};

	Controller.prototype.loadAnswers = function() {
		var _this = this;
		this.persister.answer.getAll(
			function(data) {
				sessionStorage.setItem('answers', JSON.stringify(data.results));
				var answers = JSON.parse(sessionStorage.getItem('answers'));
				console.log();
				_this.loadQuestions();
			},
			function() {
				_this.errorMessage('Load Answers Error!');
			}	
		);
	};


	Controller.prototype.successMessage = function(message) {
		var _this = this;	
		$('.notifications').show().text(message)
		.css('background-color', '#59D92F')
		.fadeOut(3000);
	};

	Controller.prototype.errorMessage = function(message) {
		var _this = this;
		$('.notifications').show().text(message)
		.css('background-color', '#FF0000')
		.fadeOut(3000);
	};

	return {
		get: function (dataPersister) {
			return new Controller(dataPersister);
		}

	};
}());