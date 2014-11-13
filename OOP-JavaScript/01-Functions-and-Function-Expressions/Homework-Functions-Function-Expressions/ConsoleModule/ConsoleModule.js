var specialConsole = {
	writeLine: function(){
		var input = arguments;
		var result = specialConsole.assignPlaceholders(input);
		specialConsole.writeToConsole(result);
	},

	assignPlaceholders: function(){
		var input = arguments[0];
		for (var i = 0; i < input.length; i++) {
			if (input.length > 1) {				
				var placeholder = '{'+i+'}';
				input[0] = input[0].replace(placeholder, input[i + 1]);
			}
		}
		return input[0];
	},

	writeToConsole: function(input){
		var output = input.toString();
		console.log(output);
	},

	writeError: function(){
		var input = arguments;
		var result = specialConsole.assignPlaceholders(input);
		throw new Error(result);
	},

	writeWarning: function(){
		var input = arguments;
		var result = specialConsole.assignPlaceholders(input);
		console.warn(result);
	}
};


specialConsole.writeLine("Message: hello!");
specialConsole.writeLine("Message: {0} {1}", "hello,", "Bobby!");
//specialConsole.writeError("Error: {0}", "A fatal error has occurred.");
specialConsole.writeWarning("Warning: {0}", "You are not allowed to do that!");