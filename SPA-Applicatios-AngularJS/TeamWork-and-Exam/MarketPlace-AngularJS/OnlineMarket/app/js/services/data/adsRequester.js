app.factory('adsRequester', ['$resource', '$http', 'baseServiceUrl', 'authentication', function($resource, $http, baseServiceUrl, authentication){
	// $resource(url, [paramDefaults], [actions], options)
	var ads = $resource(
		baseServiceUrl + 'ads',
		{},
		{get: {method: 'GET'},
		 getArray: {method: 'GET', isArray:true},
		 createNewAd: {method: 'POST', headers: {Authorization: authentication.getHeaders()}}, 
		 update: {method: 'PUT'}
		} 
	);

	var adsUser = $resource(
		baseServiceUrl+'user/ads',{},
		{post:{
			method: 'POST',
			isArray: false,
     		headers: { Authorization: authentication.getHeaders()}
		}
		});

	function getPublicAds (filter) {
		return ads.get(filter);
	}

	function createNewAd(ad) {
		return $http.post(baseServiceUrl+'user/ads', ad,{headers:authentication.getHeaders()});
	}

	function getAdById(item, id) {
		return ads.get({item:item},{id:id});
	}

	function editAd(id, ad) {
		return ads.update({id: id}, ad);
	}

	function deleteAd(id) {
		return ads.delete({id: id});
	}

	return {
		getPublicAds: getPublicAds,
		create: createNewAd,
		getById: getAdById,
		edit: editAd,
		delete: deleteAd
	};
}]);