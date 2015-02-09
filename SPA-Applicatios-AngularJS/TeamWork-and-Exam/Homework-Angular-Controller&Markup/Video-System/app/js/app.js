var app = angular.module('ViseoSystemApp', ['ngRoute']);
	app.config(function($routeProvider) {
		$routeProvider.when('/allVideos', {
			templateUrl: 'templates/allVideos.html',
			controller: 'MainController'
		});	
		$routeProvider.when('/createNewVideo', {
			templateUrl: 'templates/createNewVideo.html',
			controller: 'NewVideoController'
		});	
	});
	// app.factory('sharedObjects', function(){
	// 	return {
	// 		videoObjects: [];
			 
	// 	};
	// });



