
var numbers = [3, 5, 2, 7, 9];
var languages = ['Java', 'Python', 'C#', 'JavaScript', 'Ruby'];
var cities = ['Silicon Valley', 'London', 'Las Vegas', 'Paris', 'Sofia'];
var cars = ['BMW', 'Audi', 'Lada', 'Skoda', 'Opel'];

var result = soothsayer([numbers, languages, cities, cars]);

console.log('You will work ' + result[0] + ' years on ' + result[1] + '. You will live in ' + result[2] + ' and drive ' + result[3] + '.');

 function soothsayer(input) {

 	var randomNum;

 	var numbsIn = input[0];
 	var languagesIn = input[1];
 	var citiesIn = input[2];
 	var carsIn = input[3];

 	var dataInputs = [input[0],
 					  input[1],
 					  input[2],
 					  input[3]];
 	var result = [];

 	for (var i = 0; i < dataInputs.length; i++) {

 		randomNumb = Math.floor(Math.random() * 5);

 		console.log(randomNumb);

 		result[i] = dataInputs[i][randomNumb];
 	};
 
 	return result;
 }
