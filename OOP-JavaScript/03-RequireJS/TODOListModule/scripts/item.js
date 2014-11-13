define(["cont"], function(Container){

	var Item = (function(parent){

		function Item(content) {
			parent.call(this, content);
			this._status = false;
			this._shrift = "h3";
			this._class = "item";
		}

		Item.prototype = Object.create(parent.prototype);
		Item.prototype.constructor = this;

		Item.prototype.changeStatus = function() {
			if (this._status === false) {
				this._status = true;
			} else {
				this._status = false;
			}
		};

		return Item;
	}(Container));

	return Item;
});