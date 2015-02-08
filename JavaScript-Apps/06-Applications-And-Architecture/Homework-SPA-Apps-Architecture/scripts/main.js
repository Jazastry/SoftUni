(function(){

	var sapp = Sammy('#main', function() { 
		this.get('#/books_list', function() {    
			$('#main').load('templates/books_list.html');   
		});
	});

	sapp.run('#/books_list');

	var rootUrl = 'https://api.parse.com/1/classes/';
	var dataPersister = app.dataPersister.get(rootUrl);
	var controller = app.controller.get(dataPersister);
	controller.load();
}());

