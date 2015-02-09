app.factory('filter', function(){

	var filterParams = {};
	filterParams.pageSize = 2;

	function updateTown(town) {
		town ? filterParams.townId = town : delete filterParams.townId;
	}

	function updateCategory(category) {

		category ? filterParams.categoryId = category : delete filterParams.categoryId;	
	}

	function updatePage(page) {
		page ? filterParams.startPage = page : delete filterParams.startPage;
	}

	function getFilterParams() {
		return filterParams;
	}

	return {
		updateTown: updateTown,
		updateCategory: updateCategory,
		updateStartPage: updatePage,
		getFilterParams: getFilterParams		 
	};
});