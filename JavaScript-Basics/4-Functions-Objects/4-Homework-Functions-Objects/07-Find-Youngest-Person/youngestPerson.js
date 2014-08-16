
var persons = [
  { firstname : 'George', lastname: 'Kolev', age: 32}, 
  { firstname : 'Bay', lastname: 'Ivan', age: 81},
  { firstname : 'Baba', lastname: 'Ginka', age: 40}];

  findYoungestPerson(persons);

  function findYoungestPerson(persons) {

  	var personsIn = persons.sort(function(obj1, obj2) {return obj1.age - obj2.age;});

  	console.log('The youngest person is ' + personsIn[0].firstname + ' ' + personsIn[0].lastname);

  }
