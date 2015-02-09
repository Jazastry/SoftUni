app.directive('adsUser', function(){
	return {
		controller: 'UserAdsController',
		restrict: 'E',
		templateUrl: 'templates/public/adsUser.html',
		replace: true	
	};
});