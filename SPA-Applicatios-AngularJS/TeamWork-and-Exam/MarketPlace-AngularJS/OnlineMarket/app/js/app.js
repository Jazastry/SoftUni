var app = angular.module('app', ['ngResource', 'ngRoute', 'LocalStorageModule', 'ui.bootstrap']);

app.constant('baseServiceUrl', 'http://localhost:1337/api/');

app.config(['$routeProvider', 'localStorageServiceProvider', 
				function($routeProvider, localStorageServiceProvider) {	

	$routeProvider.when('/', {
		templateUrl: 'templates/publicHome.html',
		controller: 'HomePublicController'
	});
	$routeProvider.when('/login', {
		templateUrl: 'templates/login.html',
		controller: 'LoginController'
	});
	$routeProvider.when('/register', {
		templateUrl: 'templates/register.html',
		controller: 'RegisterController'
	});
	$routeProvider.when('/user/home', {
		templateUrl: 'templates/userHome.html',
		controller: 'HomeUserController'
	});
	$routeProvider.when('/user/ads/publish', {
		templateUrl: 'templates/user/newAd.html',
		controller: 'NewAdController'
	});
	$routeProvider.when('/user/ads', {
		templateUrl: 'templates/user/userAds.html',
		controller: 'LoggedUserAdsController'
	});
	$routeProvider.otherwise({  
		redirectTo: '/'
	});	
	localStorageServiceProvider.setStorageType('localStorage');
}]);



