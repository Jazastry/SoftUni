var app = app || {};

app.dataPersister = (function() {
	function Persister() {
		this.rootUrl = 'https://api.parse.com/1/';
		this.answer = new Item(this.rootUrl + 'classes/Answer');
		this.question = new Item(this.rootUrl + 'classes/Question');
		this.user = new User(this.rootUrl);
	}

	var Item = (function() {
		function Item(rootUrl) {
			this.serviceUrl = rootUrl;
		}

		Item.prototype.getSpecific = function(condition , success, error) {
			return ajax.get(this.serviceUrl + condition, success, error);
		};

		Item.prototype.getAll = function(success, error) {
			var _this = this;
			var e = _this.serviceUrl;
			return ajax.get(_this.serviceUrl, success, error);
		};
									//   url, data, success, error
		Item.prototype.change = function(id, answer, success, error) {
			return ajax.put(this.serviceUrl + '/' +id, answer, success, error);
		};

		Item.prototype.add = function(answer, success, error) {
			var b = answer;
			return ajax.post(this.serviceUrl, answer, success, error);
		};

		Item.prototype.delete = function(id, success, error) {
			return ajax.delete(this.serviceUrl + id, success, error);
		};

		return Item;
	}());

	var User = (function(){
		function User(rootUrl){
			this.loginUrl = rootUrl + 'login';
			this.singInUrl = rootUrl + 'users';
		}

		User.prototype.signIn = function(user, success, error) {
			var _this=this;
			var urlRoot = _this.rootUrl;
			var url = _this.singInUrl;
						//  url, data, success, error
			return ajax.post(url, user, success, error);
		};

		User.prototype.logIn = function(user, success, error) {
			var userData = '?username='+user.username+'&password='+user.password;

			return ajax.get(this.loginUrl+userData, success, error);
		};

		User.prototype.logOut = function() {
			
		};

		return User;
	}());

	return{
		get: function() {
			return new Persister();
		}
	};
}());