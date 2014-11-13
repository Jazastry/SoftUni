define(["extensions/extensions"], function(extensions){

	// Object.prototype.extend = function (parent) {
	// 	this.prototype = Object.create(parent.prototype);
	// 	this.prototype.constructor = this;
	// };

	var Cont = (function(){
		function Container(title){
			if (extensions.textIsValid(title) &&
				!extensions.duplicates(title)) {			
				this._title = title;				
			}
			this._children = [];		
			this._shrift = "H1";
			this._class = "container";
		}

		Container.prototype.getTitle = function() {
			return this._title;		
		};

		Container.prototype.setSection = function(section) {
				this._children.push(section);	
		};

		Container.prototype.getParent = function() {
			return this._parent;
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
	
	return Cont;	
});