var arrs = ['st','','sra','st','sra','bg', ''];

// REMOVES DUPLICATES
 arrs = arrs.filter(function(element, position) {
    return arrs.indexOf(element) === position;
});
 console.log(arrs);

// REMOVES EMPTY '' ELEMENTS 
arrs = arrs.filter(function(n){ return n !== ''; }); 
console.log(arrs);

// CREATE OBJECT AND METHOD TO IT
var person = [{
    firstName: "",
    lastName : "",
    id       : 0,
    fullName : function (){return this.firstName + " " + this.lastName;}
}];

person[0] = {
    firstName: "John",
    lastName : "Medow",
    id       : [1,2,3],
    fullName : function (){return this.firstName + " " + this.lastName;}
};
person[1] = {
    firstName: "Bud",
    lastName : "Freely",
    id       : [3,4,5],
    fullName : function (){return this.firstName + " " + this.lastName;}
};
person[2] = {
    firstName: "Aradii",
    lastName : "Freely",
    id       : [5,6,7],
    fullName : function (){return this.firstName + " " + this.lastName;}
};
    function isSet(val, prop, obj){ 
        for (var id in obj) {
            for (var i in obj) {
                if (val === obj[id].prop[i]) {
                    return true;
                }   
            }   
        }  
        return false;
    }
    if(7 in person[2].id) {
        console.log('hi hu ha hu');
    }
// SORT BY STRING PROPERTY

//ASCENDING STR
// console.log(person.sort(function(a, b) {return  a.firstName > b.firstName;}));
//DESCENDING STR
// console.log(person.sort(function(a, b) {return  a.firstName < b.firstName;}));


// SORT BY NUMB PROPERTY
//ASCENDING
// console.log(person.sort(function(a, b) {return a.id - b.id;}));
//DESCENDING
// console.log(person.sort(function(a, b) {return b.id - a.id;}));


function strAsc(a, b){
	return a.firstName > b.firstName;
}
function strDec(a, b){
	return a.firstName < b.firstName;
}
// console.log(person.sort(strAsc));

var out = person.sort(strAsc);
var out = person.sort(strDec);

for(var key in out) {
	console.log(out[key].fullName());
}

// FIND MIN AND MAX VALUE IN ARRAY
var arr = [2,5,3];
var min = Math.min.apply(null, arr);
var max = Math.max.apply(null, arr);
