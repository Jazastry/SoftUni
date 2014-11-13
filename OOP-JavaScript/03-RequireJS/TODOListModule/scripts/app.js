(function () {
	// 'use strict';
	
	require(["cont", "section", "item"], function (Cont, Sect, Item){

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
				item.addToDom(callerId);
				var parent = item.getParent();
				parent.setItem(item);
				var itemCheckbox = document.getElementById(item.getTitle() + "Checkbox");
				itemCheckbox.addEventListener("click", changeItemState);
			}	

			function createSection(e) {		
				var callerId = e.target.id.replace("Button", "");
				var containerInput = document.getElementById(callerId + "Input");
				var section = new Sect(containerInput.value);
				section.addToDom(callerId);
				var sectionButton = document.getElementById(section.getTitle() + "Button");
				sectionButton.addEventListener("click", createItem);
			}

			var createTodoList = (function () {
				var createTodoList = function(name){
					var container = new Cont(name);
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

		module.createTodoList('TODO List');
	});
}());
