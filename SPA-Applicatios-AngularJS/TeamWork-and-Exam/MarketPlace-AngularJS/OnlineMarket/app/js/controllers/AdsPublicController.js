app.controller('AdsPublicController', ['$scope', 'adsRequester', 'filter', function($scope, adsRequester, filter){
	function updateAds() {
		//$scope.ready = false;
		adsRequester.getPublicAds($scope.pageFilter)
			.$promise
			.then(function (data) {
				$scope.ready = true;
				$scope.ads = data;

				console.log(data);
			});
	}
	$scope.ready = false;
	$scope.pageFilter = filter.getFilterParams();
	$scope.$watch('pageFilter', function(){
		updateAds();
	}, true);
}]);