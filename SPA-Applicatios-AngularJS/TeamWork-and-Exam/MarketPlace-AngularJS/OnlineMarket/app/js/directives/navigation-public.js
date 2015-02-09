app.directive('navigationPublic', function(){
	return {
		controller: 'NavPublicController',
		restrict: 'E',
		templateUrl: 'templates/public/navigationPublic.html',
		replace: true
	};
});