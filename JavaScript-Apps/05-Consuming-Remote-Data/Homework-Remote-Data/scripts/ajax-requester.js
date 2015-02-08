var ajax = (function(){
	var PARSE_APP_ID = 'CRoKAdJFWnKc7jY3WEABU5fNoAwtdxMA8cmpFzf4';
	var PARSE_REST_API_KEY = 'CbvYO9Reokd2tQUSwo2AXCLNypzjnzG2li9mkMH3';

	var makeRequest = function(url, method, data, success, error) {
		return $.ajax({
			type: method,
			headers: {
				"X-Parse-Application-Id": PARSE_APP_ID,
				"X-Parse-REST-API-Key": PARSE_REST_API_KEY
			},
			url: url,
			data: JSON.stringify(data),
			contentType: 'application/json',
			success: success,
			error: error
		});
	};	

	function makeGetRequest(url, success, error) {
		return makeRequest(url, 'GET', null, success, error);
	}

	function makePostRequest(url, data, success, error) {
		return makeRequest(url, 'POST', data, success, error);
	}

	function makePutRequest(url, data, success, error) {
		return makeRequest(url, 'PUT', data, success, error);
	}	

	function makeDeleteRequest(url, success, error) {
		return makeRequest(url, 'DELETE', null, success, error);
	}

	return {
		get: makeGetRequest,
		post: makePostRequest,
		put: makePutRequest,
		delete: makeDeleteRequest
	};
}());