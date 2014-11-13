Object.prototype.extends = function (parent) {
	if (!Object.create) {
		Object.prototype.create = function(proto) {
			function F(){}
			F.prototype = proto;
			return new F();
		};
	}
	this.prototype = Object.create(parent.prototype);
	this.prototype.constructor = this;
};

var Container = (function(){
	function Container(title){
		this.setTitle(title);
		this._children = [];		
		this._shrift = "H1";
		this._class = "container";
	}

	Container.prototype.setTitle = function(title) {
		if (textIsValid(title) &&
			!duplicates(title)) {
			this._title = title;
		}		
	};

	Container.prototype.getTitle = function() {
		return this._title;		
	};

	Container.prototype.addItem = function(item) {
		this._children.push(item);
	};

	Container.prototype.addToDom = function(parentId) {	
		if (this._class === "container") {
			this._parent = document.getElementsByTagName("body")[0];
		} else {
			this._parent = document.getElementById(parentId);
		}

		var container = document.createElement("section");
		container = this.containerCreation(container);
		if (this._class !== "item") {
			container = this.containersAdditionsCreation(container);
		}

		this._parent.insertBefore(container, this._parent.lastChild);
		if (this._class === "item") {
			this.itemCreation();
		}		
	};

	Container.prototype.containerCreation = function(container) {
		var containerHead = document.createElement(this._shrift);
		var headText = document.createTextNode(this._title);
		containerHead.appendChild(headText);
		container.setAttribute("id", this._title);
		container.setAttribute("class", this._class);
		container.appendChild(containerHead);

		return container;
	};

	Container.prototype.containersAdditionsCreation = function(container) {
		var inputHolder = document.createElement("section");
		inputHolder.setAttribute("class", "inputSection");
		var input = document.createElement("INPUT");
		input.setAttribute("type", "text");
		input.setAttribute("id", this._title+"Input");
		var button = document.createElement("BUTTON");			
		button.setAttribute("type", "button");	
		button.setAttribute("id", this._title+"Button");

		if (this._class === "section") {
			button.innerHTML = '+';
		} else {
			button.innerHTML = 'NEW SECTION';
		}

		inputHolder.appendChild(input);
		inputHolder.appendChild(button);
		container.appendChild(inputHolder);

		return container;
	};

	Container.prototype.itemCreation = function() {
		var thisNode = document.getElementById(this._title);
		var checkBox = document.createElement("INPUT");
		checkBox.setAttribute("type", "checkbox");
		checkBox.setAttribute("id", this._title+"Checkbox");
		thisNode.insertBefore(checkBox, thisNode.lastChild);
	};

	return Container;
}());

var Section = (function(){
	function Section(title, parent) {
		Container.apply(this, arguments);
		this._parent = document.getElementById(parent);
		this._shrift = "H2";
		this._class = "section";
	}

	Section.extends(Container);

	Section.prototype.setItem = function(item) {
		if (item instanceof Item) {
			this._items.push(item);
		}		
	};

	return Section;
}());

var Item = (function(){
	function Item(content, parent) {
		Section.apply(this, arguments);
		this._parent = document.getElementById(parent);
		this._status = false;
		this._shrift = "h3";
		this._class = "item";
	}

	Item.extends(Container);

	Item.prototype.changeStatus = function() {
		if (this._status === false) {
			this._status = true;
		} else {
			this._status = false;
		}
	};

	return Item;
}());

function textIsValid(title) {
	var isValid  = /[a-z0-9 ]{3,}/i.test(title);
	if (!isValid) {
		alert("Title \'"  +  title +  
			"\' must be three or more symbols words, numbers or spaces !");
		throw new Error("Title \'" + title +   
			"\' must be three or more symbols words, numbers or spaces !");
	}

	return  isValid;
}

function duplicates(title) {
	var existingNode = document.getElementById(title);
	if (existingNode === null) {
		return false;
	} else {	
		alert("Title \'" + title +
			"\' allready exists try another one !");	
		throw new Error("Title \'" + title +
			"\' allready exists try another one !");
	}
}

var module = (function(){
	var itemsList = [];

	function changeItemState(e) {
		var callerId = e.target.id.replace("Checkbox", "");
		for (var i = 0; i < itemsList.length; i++) {
			if (itemsList[i].getTitle() === callerId) {
				itemsList[i].changeStatus();
			}
		}
	}

	function createItem(e) {
		var callerId = e.target.id.replace("Button", "");
		var sectionInput = document.getElementById(callerId + "Input");
		var item = new Item(sectionInput.value); 
		itemsList.push(item);
		item.addToDom(callerId);
		var itemCheckbox = document.getElementById(item.getTitle() + "Checkbox");
		itemCheckbox.addEventListener("click", changeItemState);
	}	

	function createSection(e) {		
		var callerId = e.target.id.replace("Button", "");
		var containerInput = document.getElementById(callerId + "Input");
		var section = new Section(containerInput.value);
		section.addToDom(callerId);
		var sectionButton = document.getElementById(section.getTitle() + "Button");
		sectionButton.addEventListener("click", createItem);
	}

	var createTodoList = (function () {
		var createTodoList = function(name){
			var container = new Container(name);
			container.addToDom();
			var containerButton = document.getElementById(container.getTitle() + "Button");
			containerButton.addEventListener("click", createSection);
		};

		return createTodoList; 
	}());

	return {
		createTodoList: createTodoList
	};
}());

module.createTodoList("TODO List");

