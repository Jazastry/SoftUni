
var input = {r: [2, 5, 12], h: [4, 8, 3]};

for (var i = 0; i < input.r.length; i++) {
	
	console.log(" r = " + input.r[i] + " h = " + input.h[i] + 
					"; cylinder volume = " + calcCylinderVol(input.r[i], input.h[i]).toFixed(3));
};


function calcCylinderVol(rad, heigh) {

	var radius = rad;
	var height = heigh;

	var result = (Math.PI * Math.pow(radius, 2)) * height;

	return result;
}