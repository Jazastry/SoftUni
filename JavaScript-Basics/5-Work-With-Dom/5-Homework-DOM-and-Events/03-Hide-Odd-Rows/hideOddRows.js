
document.getElementById("btnHideOddRows").addEventListener("click", deleter);


function deleter() {
alert('hihuhahu');

var tLengh = document.getElementsByTagName('tr');

for (var i = 0; i < tLengh.length; i = i + 2) {

	document.getElementById('myTable').deleteRow(i);
 } 


}
