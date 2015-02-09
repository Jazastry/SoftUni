app.directive('adsPublic', function(){
	return {
		controller: 'AdsPublicController',
		restrict: 'E',
		templateUrl: 'templates/public/adsPublic.html',
		replace: true	
	};
});