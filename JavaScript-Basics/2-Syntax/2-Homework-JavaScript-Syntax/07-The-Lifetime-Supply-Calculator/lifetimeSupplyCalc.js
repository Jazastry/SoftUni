
var input = {age: [38, 20, 16], maxAge: [118, 87, 102], amount: [0.5, 2, 1.1]};
var food = ["chocolate", "fruits", "nuts"]

for (var i = 0; i < input.age.length; i += 1) {

	var finalResult = calcSupply(input.age[i], input.maxAge[i], input.amount[i]);
	
	console.log("\n" + finalResult + "kg. of " + food[i] + " would be enough until I am " + input.maxAge[i] + " years old.");	 
};

function calcSupply(ageIn, maxAgeIn, amountIn) {

	var age = ageIn;
	var maxAge = maxAgeIn;
	var amount = amountIn;
	var daysInYear = 365;
	
	var result = ((maxAge-age)*daysInYear)*amountIn;	

	return result;
}