(function($){
	$.fn.threeView = function() {
		var $this = $(this);
		$this.on('click', function(e) { 
			var click = e.target;

			if ($(click).find(':last-child').is(':hidden')) {
				$(click).find(':hidden').show();
				return false;
			} else {
				$(click).children().children().hide();
				return false;
			}
		});

		return $this;
	};
}(jQuery));

$('#mainUl').threeView();
