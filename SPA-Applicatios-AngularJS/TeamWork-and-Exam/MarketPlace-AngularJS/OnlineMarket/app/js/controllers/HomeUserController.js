app.controller('HomeUserController', ['$scope', '$location', 'authentication', function($scope, $location, authentication){
	$scope.redirectTo = function (newLocation) {
		console.log(newLocation);
	    return $location.path(newLocation);
	};

	$scope.isLoggedIn = authentication.isLogedIn();
	$scope.currentPageName = 'Home';
}]);