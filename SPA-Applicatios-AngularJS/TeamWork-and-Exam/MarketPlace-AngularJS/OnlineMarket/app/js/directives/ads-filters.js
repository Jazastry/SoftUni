app.directive('adsFilters', function () {
	return {
		controller: 'AdsFiltersController',
		restrict: 'E',
		templateUrl: 'templates/public/adsFilters.html',
		replace: true
	};
});