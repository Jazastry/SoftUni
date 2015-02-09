app.controller('LoggedUserAdsController',
	['$scope', '$location', 'adsRequester', 'authentication', 'townsRequester', 'categoriesRequester',
		 function($scope, $location, adsRequester, authentication, townsRequester, categoriesRequester){
		 	
	$scope.userNow = authentication.getUser().username;
	$scope.currentPageName = 'Publish New Ad';
	$scope.isLoggedIn = authentication.isLogedIn();
	$scope.towns = townsRequester.getAllTowns();
	$scope.categories = categoriesRequester.getAllCategories();
}]);