var domModule = {
	appendChild: function (element, className) {
        var node = document.querySelector(className);
		node.appendChild(element);
    },

    removeChild: function(parent, child) {    
		var parentIner = document.querySelector(parent);
		var childIner = document.querySelector(child);		
		parentIner.removeChild(childIner);
	},

	addHandler: function(element, eventToAdd, scriptToAdd){
		var elements = document.querySelectorAll(element);
		for (var i = 0; i < elements.length; i++) {
			var item = elements[i];
			item.addEventListener(eventToAdd, scriptToAdd);
		}
	},
	
	retrieveElements: function(className) {
		var elementNodes = document.querySelectorAll(className);
		var elementsOut = [];
		for (var i = 0; i < elementNodes.length; i++) {
			elementsOut[i]  = elementNodes[i];
		}
		return elementsOut;
	}
};


var liElement = document.createElement("li");

domModule.appendChild(liElement,".birds-list"); 

domModule.removeChild("ul.birds-list","li:first-child"); 

domModule.addHandler("li.bird", 'click', function(){ alert("I'm a bird!"); });

var elements = domModule.retrieveElements(".bird");

