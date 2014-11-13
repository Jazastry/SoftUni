// calling the function from: Global scope
function myFunction() {
	console.log(this.arguments.length);
	for (var i = 0; i < this.arguments.length; i++) {
		console.log(typeof(arguments[i]));
	}
}

myFunction.apply(myFunction,[33, 55, "Pesho", [2,3,5]]);
myFunction.call(myFunction,33,44,[],"sahfdkj");
myFunction.apply(myFunction);
myFunction.call(myFunction);

// calling the function from : Function scope
(function () {
	function myFunction() {
		console.log(this.arguments.length);		
		for (var i = 0; i < this.arguments.length; i++) {
			console.log(typeof(arguments[i]));
		}
	}

	myFunction.apply(myFunction,[33, 55, "Pesho", [2,3,5]]);
	myFunction.call(myFunction,33,44,[],"sahfdkj");
	myFunction.apply(myFunction);
	myFunction.call(myFunction);
})();

// calling the function from : Over the object
function myFunction() {
	console.log(this.arguments.length);	

	for (var i = 0; i < this.arguments.length; i++) {
		console.log(typeof(arguments[i]));
	}
}

var a = myFunction;
a.call(a, 2,"Pesho", [2,4,5], {Pesho: "human"});