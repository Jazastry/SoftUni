app.controller('LoginController', ['$scope', '$location','userRequester', 'authentication', function($scope, $location,userRequester,authentication){
	$scope.currentPageName = 'Login';
	$scope.redirectTo = function (newLocation) {
		console.log(newLocation);
	    return $location.path(newLocation);
	};

	$scope.login = function(user){
		userRequester.login(user)
			.$promise
			.then(function (data) {
				$location.path('/user/home');
				$scope.alerts.push({type: 'success', msg: 'Logged In Successfully.'});
			}, function(error){
				console.log(error.data.error_description);
				$scope.alerts.push({type: 'danger', msg:  error.data.error_description});
			});
	};
}]);