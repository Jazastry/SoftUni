app.controller('NavPublicController', ['$scope', function($scope){

	$scope.closeAlert = function(index) {
		$scope.alerts.splice(index, 1);
	};
}]);