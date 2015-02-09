app.controller('MainController', ['$scope', '$location', 'localStorageService', 'authentication', function($scope, $location, localStorageService, authentication){
	
	$scope.alerts = [];

	$scope.$watch('isLoggedIn', function(){
		if (authentication.isLogedIn()) {
			$scope.userNow = authentication.getUser('user').username;
		}		
	}, true);

	$scope.redirectTo = function (newLocation) {
		console.log(newLocation);
	    return $location.path(newLocation);
	};
}]);