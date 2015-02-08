var ajax = (function(){
	var PARSE_APP_ID = 'CRoKAdJFWnKc7jY3WEABU5fNoAwtdxMA8cmpFzf4';
	var PARSE_REST_API_KEY = 'CbvYO9Reokd2tQUSwo2AXCLNypzjnzG2li9mkMH3';

	var makeRequest = function(url, method, data) {
		var defer = Q.defer();
		$.ajax({
			type: method,
			headers: {
				"X-Parse-Application-Id": PARSE_APP_ID,
				"X-Parse-REST-API-Key": PARSE_REST_API_KEY
			},
			url: url,
			data: JSON.stringify(data),
			contentType: 'application/json',
			success: function(data) {
				defer.resolve(data);
			},
			error: function(error) {
				defer.reject(error);
			}
		});

		return defer.promise;
	};	

	function makeGetRequest(url) {
		return makeRequest(url, 'GET', null);
	}

	function makePostRequest(url, data) {
		return makeRequest(url, 'POST', data);
	}

	function makePutRequest(url, data) {
		return makeRequest(url, 'PUT', data);
	}	

	function makeDeleteRequest(url) {
		return makeRequest(url, 'DELETE', null);
	}

	return {
		get: makeGetRequest,
		post: makePostRequest,
		put: makePutRequest,
		delete: makeDeleteRequest
	};
}());