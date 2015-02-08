var app = app || {};

app.dataPersister = (function() {
	function Persister(rootUrl) {
		this.rootUrl = rootUrl;
		this.book = new Books(rootUrl);
	}

	var Books = (function() {
		function Books(rootUrl) {
			this.serviceUrl = rootUrl + 'Books/';
		}

		Books.prototype.getAll = function(success, error) {
			return ajax.get(this.serviceUrl, success, error);
		};
									//   url, data, success, error
		Books.prototype.change = function(id, book, success, error) {
			return ajax.put(this.serviceUrl + id, book, success, error);
		};

		Books.prototype.add = function(book, success, error) {
			return ajax.post(this.serviceUrl, book, success, error);
		};

		Books.prototype.delete = function(id, success, error) {
			return ajax.delete(this.serviceUrl + id, success, error);
		};

		return Books;
	}());

	return{
		get: function(rootUrl) {
			return new Persister(rootUrl);
		}
	};
}());