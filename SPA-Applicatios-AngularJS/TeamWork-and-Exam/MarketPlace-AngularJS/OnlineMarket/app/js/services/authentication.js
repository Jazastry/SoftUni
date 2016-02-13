app.factory('authentication', ['localStorageService', function(localStorageService){

	var key = 'user';

	function saveUserData (val) {
		var data = val;
		localStorageService.set(key,data);
	}

	function getUserData() {
		var user = localStorageService.get(key);
		return user;
	}

	function getHeaders () {
		var headers = {};
		var userData = getUserData();
		if (userData) {
			headers.Authorization = 'Bearer ' + userData.access_token;
		}

		return headers;
	}

	function removeUserData() {
		// returns true if succeed
		return localStorageService.remove(key); 
	}

	function isUserAdmin() {		
		var isAdmin = getUserData().isAdmin;

		return isAdmin;
	}

	function isLogedIn () {
		return !!getUserData();
	}

	return {
		saveUser: saveUserData,
		getUser: getUserData,
		removeUser: removeUserData,
		getHeaders: getHeaders,
		isAdmin: isUserAdmin,
		isLogedIn: isLogedIn
	};
}]);