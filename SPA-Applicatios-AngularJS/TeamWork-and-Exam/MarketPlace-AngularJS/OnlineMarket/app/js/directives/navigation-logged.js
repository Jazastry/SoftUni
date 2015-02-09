app.directive('navigationLogged', function(){
	return {
		controller: 'LoggedInNavController',
		restrict: 'E',
		templateUrl: 'templates/public/navigationLogged.html',
		replace: true
	};
});