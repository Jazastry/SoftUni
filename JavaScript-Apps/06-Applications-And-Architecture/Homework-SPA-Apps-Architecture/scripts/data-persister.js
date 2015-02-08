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

		Books.prototype.getAll = function() {
			return ajax.get(this.serviceUrl);
		};
									//   url, data, success, error
		Books.prototype.change = function(id, book) {
			return ajax.put(this.serviceUrl + id, book);
		};

		Books.prototype.add = function(book) {
			return ajax.post(this.serviceUrl, book);
		};

		Books.prototype.delete = function(id) {
			return ajax.delete(this.serviceUrl + id);
		};

		return Books;
	}());

	return{
		get: function(rootUrl) {
			return new Persister(rootUrl);
		}
	};
}());