app.factory('categoriesRequester', ['$resource', 'baseServiceUrl', function($resource, baseServiceUrl){
	// $resource(url, [paramDefaults], [actions], options)
	var categories = $resource(
		baseServiceUrl + ':item',
		{item:'categories'},
		{get: {method: 'GET'},
		 getAllCategories: {method: 'GET', isArray:true}
		} 
	);

	function getAllCategories() {
		return categories.getAllCategories();
	}


	return {
		getAllCategories: getAllCategories,
	};
}]);