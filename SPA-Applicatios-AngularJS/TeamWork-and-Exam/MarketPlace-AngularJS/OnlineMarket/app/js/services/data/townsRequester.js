app.factory('townsRequester', ['$resource', 'baseServiceUrl', function($resource, baseServiceUrl){
	// $resource(url, [paramDefaults], [actions], options)
	var towns = $resource(
		baseServiceUrl + ':item',
		{item:'towns'},
		{get: {method: 'GET'},
		 getAllTowns: {method: 'GET', isArray:true}
		} 
	);

	function getAllTowns() {
		return towns.getAllTowns();
	}


	return {
		getAllTowns: getAllTowns,
	};
}]);