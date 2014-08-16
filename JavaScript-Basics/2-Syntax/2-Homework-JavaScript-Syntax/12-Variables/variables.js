
variablesTypes(['Pesho', 22, true, ['fries', 'banana', 'cake']]);

function variablesTypes(value) {

	var name = value[0];
	var age = value[1];
	var isMale = value[2];
	var food = value[3];

	var nameIs = typeof(name);
	var ageIs = typeof(age);
	var isMaleIs = typeof(isMale);
	var foodIs = typeof(food);

	console.log('\n"My name: ' + name + ' //type is ' + nameIs + '\n' +
				'My age: ' + age + ' //type is ' + ageIs + '\n' + 
				 'I am male : '+ isMale + '//type is ' + isMaleIs + '\n' +
				'My favorite foods are: ' + food.toString() + ' //type is ' + foodIs);
} 

