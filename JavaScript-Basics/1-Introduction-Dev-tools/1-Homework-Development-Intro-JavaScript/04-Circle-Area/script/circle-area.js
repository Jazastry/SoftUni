// Area = Pi * r * r
var input = [7, 1.5, 20];

for (var i = 0; i < input.length; i++) {
    
    var r = input[i];
    var area = Math.PI * (Math.pow(r,2));
    var currentId = "result" + i;
    document.getElementById(currentId).innerHTML = area;

}
