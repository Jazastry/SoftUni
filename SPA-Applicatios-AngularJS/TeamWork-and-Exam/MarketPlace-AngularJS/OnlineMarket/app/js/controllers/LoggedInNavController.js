app.controller('LoggedInNavController', ['$scope', 'authentication', function($scope, authentication){

	$scope.logoutUser = function() {
		authentication.removeUser();
		console.log(authentication.getUser());
	};

	$scope.closeAlert = function(index) {
		$scope.alerts.splice(index, 1);
	};

	if (authentication.isLogedIn()) {
		$scope.userNow = authentication.getUser('user').username;
	}
}]);