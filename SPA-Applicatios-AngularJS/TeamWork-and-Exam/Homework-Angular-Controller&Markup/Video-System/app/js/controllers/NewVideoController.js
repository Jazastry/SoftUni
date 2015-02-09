app.controller('NewVideoController', function($scope, ){
	$scope.saveVideo = function(newVideo){
		videoObjects.push(newVideo);
	};	
});