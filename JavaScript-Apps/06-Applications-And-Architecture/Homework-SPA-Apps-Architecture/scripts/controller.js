var app = app || {};

app.controller = (function(){
	function Controller(dataPersister) {
			this.persister = dataPersister;
	}


	Controller.prototype.attachEvents = function() {
		var _this = this;
		$('#addNewBook').click(function(){
			var book = _this.newBook('add');
			_this.addBook({
				'title':book.title,
				'autor':book.autor});
		});
		$('#deleteBook').click(function(){
			_this.deleteBook($('#bookId').val());		
		});
		$('#changeBook').click(function(){
			_this.changeBook($('#bookId').val(),
			 {
				'title':$('#bookName').val(),
				'autor':$('#bookAutor').val()
			});
		});
	};	

	Controller.prototype.newBook = function(action) {
		var _this = this;
		var title = $('#bookName').val();
		var autor = $('#bookAutor').val();
		var id = $('#bookId').val();
		switch(action) {
			case 'add':
				if (!title || !autor) {
					_this.errorMessage('Cant assign empty values to autor or title.');
					throw new Error('Cant assign empty values to autor or title.');
				} else {
					return {'title':title,'autor':autor};
				}
				break;
			case 'change':
				if (!title || !autor|| !id) {
					_this.errorMessage('Empty Field');
					throw new Error('Cant assign empty values to autor or title.');
				} else {
					return {'title':title,'autor':autor, 'objectId':id};
				}
				break;
			case 'delete':
				return {'objectId':id};
				break;
		   	default:
        		_this.errorMessage();
        		throw new Error('While take input value, appear unknown error.');
		}
	};

	Controller.prototype.bookClicked = function() {
		var title = $('#bookName').val();
	    var autor = $('#bookAutor').val();
	    var id = $('#bookId').val();
	    var book = {'title':title, 'autor':autor, 'objectId':id};
	    return book;
	};

	Controller.prototype.refresh = function() {
		var _this = this;
		$('#allBooks').empty();
		_this.load();
	};

	Controller.prototype.load = function() {
		var _this = this; 
		this.attachEvents();
		this.persister.book.getAll()
			.then(function(data) {
					_this.loadAllBooks(data);
					_this.successMessage('Load Books');
			},
			function() {
				_this.errorMessage('Load Books');
			}
		);
	};

	Controller.prototype.addBook = function(book) {
		var _this = this; 
		this.persister.book.add(book)
			.then(function(data) {
				_this.successMessage('Book Add');
				book.objectId = data.objectId;
				_this.loadBook(book);
			},
			function() {
				_this.errorMessage('Book Add');
			}
		);
	};

	Controller.prototype.deleteBook = function(id) {
		var _this = this; 
		this.persister.book.delete(id)
			.then(function() {
				_this.successMessage('Book Delete');
				$('#'+id).remove();
			},
			function() {
				_this.errorMessage('Book Delete');
			}
		);
	};

	Controller.prototype.changeBook = function(id, book) {
		var _this = this;
		this.persister.book.change(id, book)
			.then(function() {
				_this.successMessage('Book Change');
				book.objectId = id;
				$('#'+id).text(book.title).data('book', book);
			},
			function() {
				_this.errorMessage('Book Change');
			});
		
	};

	Controller.prototype.loadAllBooks = function(data) {
		var _this = this;
		for (var i = 0; i < data.results.length; i++) {
			_this.loadBook(data.results[i]);
		}
	};

	Controller.prototype.loadBook = function(data) {
		var _this = this;
		var selector = '#allBooks';	
		var li = $('<li>');	
		var ul = $(selector);			
		$(li).text(data.title)
		.css('cursor', 'pointer')
		.attr('id', data.objectId)
		.click(_this.assignDataToInputs)
		.data('book', data);
		$(ul).append(li);
	};

	Controller.prototype.assignDataToInputs  = function(ev) {
		var book = $(ev.target).data('book');
		$('#bookId').val(book.objectId);
		$('#bookName').val(book.title);
		$('#bookAutor').val(book.autor);
	};

	Controller.prototype.successMessage = function(message) {
		var _this = this;	
		$('.notifications').show().text(message + ' successfull!')
		.css('background-color', '#59D92F')
		.fadeOut(3000);
		$('input').val('');
	};

	Controller.prototype.errorMessage = function(message) {
		var _this = this;
		$('.notifications').text(message + ' Error!')
		.css('background-color', '#FF0000')
		.fadeOut(3000);
		$('input').val('');
	};

	return {
		get: function (dataPersister) {
			return new Controller(dataPersister);
		}

	};
}());