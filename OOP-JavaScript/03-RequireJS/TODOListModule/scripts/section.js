define(["cont"], function(Container){

	var Section = (function(parent){
		function Section(title) {	
			var c = parent;	
			parent.call(this, title);
			this._shrift = "H2";
			this._class = "section";	
		}	

		Section.prototype = Object.create(parent.prototype);
		Section.prototype.constructor = this;	

		Section.prototype.setItem = function(item) {
			this._children.push(item);	
		};

		return Section;
	}(Container));

	return Section;
});	