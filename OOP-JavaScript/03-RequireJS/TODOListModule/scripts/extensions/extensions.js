define(function(){
	
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

		return {
			textIsValid: textIsValid,
			duplicates: duplicates
		};
});