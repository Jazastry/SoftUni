app.controller('NewAdController', 
		['$scope', '$location', 'adsRequester', 'authentication', 'townsRequester', 'categoriesRequester',
			 function($scope, $location, adsRequester, authentication, townsRequester, categoriesRequester){
	$scope.userNow = authentication.getUser().username;
	$scope.currentPageName = 'Publish New Ad';
	$scope.isLoggedIn = authentication.isLogedIn();
	$scope.towns = townsRequester.getAllTowns();
	$scope.categories = categoriesRequester.getAllCategories();
	$scope.publish = function(ad){
		adsRequester.create(ad)
			.success(function(data){
				$scope.alerts.push({type: 'success',
					 msg:'Advertisment submitted for approval. Once approved, it will be published'});			
			})
			.error(function(response){
				$scope.alerts.push({type: 'danger', msg:  response.data.error_description});
			});
	};
}]);