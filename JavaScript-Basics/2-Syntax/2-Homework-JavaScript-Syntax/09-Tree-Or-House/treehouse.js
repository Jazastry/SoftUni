
var input = {houseMesures: [3, 3, 4], treeMesures: [2, 3, 5]};

for (var i = 0; i < input.houseMesures.length; i += 1) {

	console.log("\n" + "house-" + input.houseMesures[i] + ",tree-" + input.treeMesures[i] + " -> " 
						+ treeHouseCompare(input.houseMesures[i], input.treeMesures[i])[0] + "/" 
							+ treeHouseCompare(input.houseMesures[i], input.treeMesures[i])[1]);
};

function treeHouseCompare(a, b) {

	var names = ['house', 'tree'];
	var biggerArea = 0;

	if(houseArea(a) > treeArea(b)){

		return [names[0], houseArea(a).toFixed(2)];
	} else {

		return [names[1], treeArea(b).toFixed(2)];
	}

}

function houseArea(a) {

	var bodyArea = a * a;
	var roofArea = (a * ((a / 3) * 2)) / 2;
	var wholeHouseArea = bodyArea + roofArea;

	return wholeHouseArea;
}

function treeArea(b) {

	var columnArea = b * (b / 3);
	var circleArea = Math.pow(((b / 3) * 2), 2) * Math.PI;
	var wholeTreeArea = columnArea + circleArea;

	return wholeTreeArea;
}