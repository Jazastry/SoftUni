app.controller('PaginationCtrl', ['$scope', '$log', 'filter', function($scope, $log, filter){
 	$scope.maxSize = 3;
 	$scope.totalItems = 11;
 	$scope.currentPage = 1;

	$scope.pageChanged = function(page){		
		filter.updateStartPage(parseInt(page));
		$scope.pageFilter = filter.getFilterParams();	
	};
}]);