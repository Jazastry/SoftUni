app.controller('RegisterController', 
	['$scope', '$location', 'townsRequester', 'userRequester',
			function($scope, $location, townsRequester, userRequester){
	//$scope.alerts.push({type: 'success', msg: 'User Account created. Please Logg In !'});
	$scope.currentPageName = 'Register';
	$scope.towns = townsRequester.getAllTowns();
	$scope.register = function (user) {
		userRequester.register(user)
			.$promise
			.then(function (data) {
				$scope.alerts.push({type: 'success', msg: 'User Account created. Please Logg In !'});
				$location.path('/login');
			}, function(error){

				$scope.alerts.push({type: 'danger', msg: 'Unsuccessfull Register !'});
			});
	};	
}]);