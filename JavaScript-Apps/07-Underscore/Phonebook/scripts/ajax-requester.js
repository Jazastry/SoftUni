var ajax = (function(){
	var PARSE_APP_ID = 'tQmLbgAJxhh5IBfS8SEfyaXqtFiCuiHN4Tohr7ew';
	var PARSE_REST_API_KEY = '59tPasy1hhIw4WYnrF4t2hed3Msdre3ih5EMMQGe';

	var makeRequest = function(url, method, data, success, error) {
		return $.ajax({
			type: method,
			headers: {
				"X-Parse-Application-Id": PARSE_APP_ID,
				"X-Parse-REST-API-Key": PARSE_REST_API_KEY,
				"X-Parse-Session-Token": localStorage.sessionToken
			},
			url: url,
			data: JSON.stringify(data),
			contentType: 'application/json; charset=utf-8',
			dataType: "json",
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