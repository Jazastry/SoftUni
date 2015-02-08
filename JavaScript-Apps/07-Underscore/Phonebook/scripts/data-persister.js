var app = app || {};

app.dataPersister = (function() {
	function Persister() {
		this.rootUrl = 'https://api.parse.com/1/';
		this.phone = new Phones(this.rootUrl);
		this.user = new User(this.rootUrl);
	}

	var Phones = (function() {
		function Phones(rootUrl) {
			this.serviceUrl = rootUrl + 'classes/Phones/';
		}

		Phones.prototype.getAll = function(success, error) {
			var _this = this;
			ajax.get(_this.serviceUrl, success, error);
		};

		Phones.prototype.change = function(id, phone, success, error) {
			ajax.put(this.serviceUrl + id, phone, success, error);
		};

		Phones.prototype.add = function(phone, success, error) {
			ajax.post(this.serviceUrl, phone, success, error);
		};

		Phones.prototype.delete = function(id, success, error) {
			ajax.delete(this.serviceUrl + id, success, error);
		};

		return Phones;
	}());

	var User = (function(){
		function User(rootUrl){
			this.loginUrl = rootUrl + 'login';
			this.singInUrl = rootUrl + 'users';
		}

		User.prototype.signIn = function(user, success, error) {
			var _this = this;
			return ajax.post(this.singInUrl , user, success, error);
		};

		User.prototype.logIn = function(user, success, error) {
			var userData = '?username='+user.username+'&password='+user.password;

			return ajax.get(this.loginUrl+userData, success, error);
		};

		return User;
	}());

	return{
		get: function() {
			return new Persister();
		}
	};
}());