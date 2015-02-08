var app = app || {};

app.controller = (function(){
	function Controller(dataPersister) {
			this.persister = dataPersister;
	}

	Controller.prototype.loadWelcome = function() {
		var _this = this;
		if (localStorage.getItem('userId')) {
			$('#user-home').show().css({'display':'inline-block','margin-left':'20%'});
			$('#menu').show();
			$('#user-home').find('h1').text('Welcome, '+ decodeURIComponent(localStorage.getItem('fullName')) +
					' ('+ decodeURIComponent(localStorage.getItem('userName')) +')');
			_this.attachEvents();
		} else {
			$('body').children('div').hide();
			$('#welcome-screen').show().css({'display':'inline-block','margin-left':'34%'});
			_this.attachEvents();
		}
	};

	Controller.prototype.attachEvents = function() {
		var _this = this;
		$('#loginBtn1').click(function(){
			$(this).parent().hide();
			$('#login-form').show().css({'display':'inline-block','margin-left':'34%'});
		});
		$('#registerBtn1').click(function(){
			$(this).parent().hide();
			$('#register-form').show().css({'display':'inline-block','margin-left':'34%'});
		});
		$('#loginBtn2').click(function(){
			$(this).parent().parent().hide();
			$('#login-form').show().css({'display':'inline-block','margin-left':'34%'});
		});
		$('#registerBtn2').click(function(){
			$(this).parent().parent().hide();
			$('#register-form').show().css({'display':'inline-block','margin-left':'34%'});
		});
		$('#loginFormLogin').click(function(){
			var username = $('#login-form').find('#username').val();
			var password = $('#login-form').find('#password').val();
			var user = { 
	    		username: encodeURIComponent(username),
	    		password: encodeURIComponent(password)
    		};
			_this.loggIn(user);
 		});
		$('#registegFormRegister').click(function(){
			var username = $('#register-form').find('#username').val();
			var password = $('#register-form').find('#password').val();
			var fullname = $('#register-form').find('#fullName').val();
			var user = { 
	    		username: encodeURIComponent(username),
	    		password: encodeURIComponent(password),
	    		fullName: encodeURIComponent(fullname)
    		};
			_this.register(user);
 		});
 		$('#menu').on('click','#nav-home', function(){
 			$('body').children('div').hide();
 			$('#user-home').show().css({'display':'inline-block','margin-left':'20%'});
 		});
		$('#menu').on('click','#nav-phonebook', function(){
 			$('body').children('div').hide();
 			$('#phonesDiv').show().css({'display':'inline-block','margin-left':'20%'});
 			_this.loadPhones();
 		});
		$('#menu').on('click','#nav-add-phone', function(){
 			$('body').children('div').hide();
 			$('#add-phone-form').find('input').val('');
 			$('#add-phone-form').show().css({'display':'inline-block','margin-left':'20%'});
 		});
		$('#menu').on('click','#nav-logout', function(){
			localStorage.clear();
 			document.location.reload(true);
 		});
 		$('#phones').on('click','.link:contains("Edit")', function(){
 			$('body').children('div').hide();
 			_this.loadPhoneData($(this).parent('td').data('phone')); 			
 		});
 		$('#edit-phone-form').on('click','.button:contains("Edit")', function(){
 			var name = $('#edit-phone-form').find('#personName').val();
			var phone = $('#edit-phone-form').find('#phoneNumber').val();
 			var data = $('#edit-phone-form').data('phone');
 			var phoneId = data.objectId;
 			var phoneObject = {'name':name,'phone':phone};
 			_this.submitChanges(phoneId, phoneObject);
 		});
		$('#edit-phone-form').on('click','.button:contains("Cancel")', function(){
			$('body').children('div').hide();
			$('#phonesDiv').show().css({'display':'inline-block','margin-left':'20%'});
 		});
 		$('#phones').on('click','.link:contains("Delete")', function(){
 			$('body').children('div').hide();
 			_this.deletePhone($(this).parent('td').data('phone')); 			
 		});
		$('#phonesDiv').on('click','.button:contains("Add Phone")', function(){
 			$('body').children('div').hide();
 			$('#add-phone-form').find('input').val('');
 			$('#add-phone-form').show().css({'display':'inline-block','margin-left':'20%'});						
 		});
 		$('#add-phone-form').on('click','.button:contains("Add")', function(){
 			var phone = $('#add-phone-form').find('#phoneNumber').val();
 			var name = $('#add-phone-form').find('#personName').val();
 			var uresId = localStorage.getItem('userId');
			var acl = '"ACL":{"'+uresId+'":{"read":true, "write":true}}';
			var phoneData = '{"name":"'+name+'","phone":"'+phone+'",'+acl+'}';
			_this.addNewPhone(JSON.parse(phoneData)); 			
 		});
 		$('#add-phone-form').on('click','.button:contains("Cancel")', function(){
 			$('#add-phone-form').hide();
 			_this.loadPhones();
			$('#phonesDiv').show().css({'display':'inline-block','margin-left':'20%'});
 		});
	};

	Controller.prototype.addNewPhone = function(phoneData) {
		var _this = this; 		
		this.persister.phone.add(
			phoneData,
			function() {
				$('#add-phone-form').hide();
				_this.successMessage('New Phone Added Successfull !');
				_this.cleanPhoneTable();
				_this.loadPhones();
				$('#phonesDiv').show().css({'display':'inline-block','margin-left':'20%'});
			},
			function() {
				_this.errorMessage('New Phone add Error ! Please try later !');
			}
		);
	};

	Controller.prototype.deletePhone = function(data) {
		var _this = this; 
		var id = data.objectId;
		this.persister.phone.delete(
			id,
			function() {
				_this.successMessage('Phone Deleted Successfully !');
				_this.cleanPhoneTable();
				_this.loadPhones();
				$('#phonesDiv').show().css({'display':'inline-block','margin-left':'20%'});
			},
			function() {
				_this.errorMessage('Phone Deletion Error try later !');
			}
		);
	};

	Controller.prototype.submitChanges = function(id, phone) {
		var _this = this;
		this.persister.phone.change(			
			id,
			phone,
			function() {
				_this.successMessage('Phone changed successfull !');
				$('body').children('div').hide();
				_this.cleanPhoneTable();
				_this.loadPhones();
				$('#phonesDiv').show().css({'display':'inline-block','margin-left':'20%'});
			},
			function() {
				_this.errorMessage('Phone change error ! Please try later !');
			});
	};

	Controller.prototype.loadPhoneData = function(data) {
		var phoneId = data.objectId;
		var name = data.name;
		var phone = data.phone;
		$('#edit-phone-form').show().css({'display':'inline-block','margin-left':'20%'})
		.data('phone', data);
		$('#edit-phone-form').find('#personName').val(name);
		$('#edit-phone-form').find('#phoneNumber').val(phone);
	};

	Controller.prototype.loadPhones = function() {
		var _this = this; 
		this.persister.phone.getAll(
			function(data) {
				if (data.results.length > 0) {
					_this.cleanPhoneTable();
					_this.loadAllPhones(data);
				} else {
		 			$('body').children('div').hide();
					$('#user-home').show().css({'display':'inline-block','margin-left':'20%'});
					$('#user-home').find('h1').text('You dont have phones to show !');
				}
			},
			function() {
				_this.errorMessage('Lphones loading Error please try again later!');
			}
		);
	};

	Controller.prototype.loadAllPhones = function(data) {
		var _this = this;
		for (var i = 0; i < data.results.length; i++) {
			var tr = $('#phones tr').last();
			if (i < data.results.length - 1) {
				$(tr).clone().appendTo('#phones');
			}
			$(tr).data('question', data.results[i]);
			var tdArray = $(tr).find('td');
			$(tdArray[0]).text(data.results[i].name);
			$(tdArray[1]).text(data.results[i].phone);
			$(tdArray[2]).data('phone', data.results[i]);			
		}
	};

	Controller.prototype.register = function(user) {
		var _this = this;
		this.persister.user.signIn(
			user,
			function() {
				$('#register-form').hide();				
				$('#login-form').show().css({'display':'inline-block','margin-left':'34%'});
				_this.successMessage(user.username + ' registered successfully !' + 
					' Now Please Logg In With your New account !');
			},
			function() {
				_this.errorMessage('Sign In Error Try again later !');
			}
		);
	};

	Controller.prototype.loggIn = function(user) {
		var _this = this;
		this.persister.user.logIn(
			user,
			function(data) {
				_this.successMessage('Logged In Successfully!');
				localStorage.setItem('sessionToken', data.sessionToken);
				localStorage.setItem('userId', data.objectId);
				localStorage.setItem('userName', data.username);
				localStorage.setItem('fullName', data.fullName);
				$('#login-form').hide();
				$('#menu').show();
				$('#user-home').show().css({'display':'inline-block','margin-left':'20%'});
				$('#user-home').find('h1').text('Welcome, '+ decodeURIComponent(data.fullName) +
					' ('+ decodeURIComponent(data.username) +')');
			},
			function() {
				$('body').children('div').hide();
				_this.errorMessage('User Not Found Please Register!');
				$('#register-form').show().css({'display':'inline-block','margin-left':'34%'});
			}
		);
	};

	Controller.prototype.assignDataToInputs  = function(ev) {
		var bookmark = $(ev.target).data('bookmark');
		$('#bookmarkId').val(bookmark.objectId);
		$('#bookmarkName').val(bookmark.title);
		$('#bookmarkUrl').val(bookmark.url);
	};

	Controller.prototype.cleanPhoneTable = function() {
		$('#phonesDiv').find('tr').each(function(index){
			var i = index;
			if (i !== 0 && i !== 1) {
				$(this).remove();
			}
		});
	};

	Controller.prototype.successMessage = function(message) {
		var _this = this;	
		 $('.notifications').show().text(message)
		.css({'background-color':'#59D92F',
			'position':'absolute',
			'top':'30px',
			'left':'30%',
			'border':'1px solid #000',
			'border-radius':'4px',
			'padding':'10px',
			'color':'#FFF',
			'font-size':'20px'})
		.fadeOut(4000);
	};

	Controller.prototype.errorMessage = function(message) {
		var _this = this;
		$('.notifications').show().text(message)
		.css({'background-color':'#FF0000',
			'position':'absolute',
			'top':'30px',
			'left':'30%',
			'border':'1px solid #000',
			'border-radius':'4px',
			'padding':'10px',
			'color':'#FFF',
			'font-size':'20px'})
		.fadeOut(4000);
	};

	return {
		get: function (dataPersister) {
			return new Controller(dataPersister);
		}

	};
}());