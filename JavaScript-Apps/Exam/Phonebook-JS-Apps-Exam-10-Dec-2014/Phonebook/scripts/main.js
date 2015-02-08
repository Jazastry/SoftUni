(function(){
	var dataPersister = app.dataPersister.get();
	var controller = app.controller.get(dataPersister);
	controller.loadWelcome();
}());

