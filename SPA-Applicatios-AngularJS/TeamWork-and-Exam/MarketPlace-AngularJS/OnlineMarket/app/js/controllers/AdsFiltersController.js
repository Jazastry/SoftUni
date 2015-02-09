app.controller('AdsFiltersController',
	 ['$scope', '$rootScope', 'townsRequester', 'categoriesRequester', 'filter',
	 	 function($scope, $rootScope, townsRequester, categoriesRequester, filter){

	$scope.categoryChanged = function(category){
		filter.updateCategory(parseInt(category));
		$scope.pageFilter = filter.getFilterParams();
	};

	$scope.townChanged = function(town){
		filter.updateTown(parseInt(town));
		$scope.pageFilter = filter.getFilterParams();
	};

	$scope.towns = townsRequester.getAllTowns();
	$scope.categories = categoriesRequester.getAllCategories();
}]);