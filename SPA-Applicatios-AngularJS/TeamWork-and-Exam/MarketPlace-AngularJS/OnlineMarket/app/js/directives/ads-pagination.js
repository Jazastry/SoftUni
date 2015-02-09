app.directive('adsPagination', function () {
	return {
		controller: 'PaginationCtrl',
		restrict: 'E',
		templateUrl: 'templates/public/adsPagination.html',
		replace: true
	};
});