Object.prototype.extends = function (parent) {
	if (!Object.create) {
		Object.prototype.create = function(proto) {
			function F(){}
			F.prototype = proto;
			return new F();
		};
	}
	this.prototype = Object.create(parent.prototype);
	this.prototype.constructor = this;
};

function isHexColor(value){
	var isHex  = /^#[0-9A-F]{6}$/i.test(value);
	return  isHex;
}

var Point = (function() {
	function Point(x, y){
		if (x >= 0) {
			this._x = x;
		} else {
			throw new Error("Point x " + x + " can not be negative number !");
		}
		
		if (y >= 0) {
			this._y = y;
		} else {
			throw new Error("Point y " + y + " can not be negative number !");
		}
	}

	Point.prototype.toString = function toString() {
		return " x: " + this._x + " y: " + this._y;
	};

	return Point;
})();

var Shape = (function(){
	function Shape(x, y, color){
		if (!(this instanceof Shape)) {
			return new Shape(x, y, color);
		}
		if (x < 0) {
			throw new Error("Shape "+ x + " can not be negative number!");
		} else {
			this._x = x;
		}

		if (y < 0) {
			throw new Error("Shape "+ y + " can not be negative number!");
		} else {
			this._y = y;
		} 

		if (isHexColor(color)) {
			this._color = color;
		} else {
			throw new Error("Shape color value "+ color + "is not a valid hex color!");
		}		
		this.canvas = document.getElementById("myCanvas");
		this.ctx = this.canvas.getContext("2d");
	}

	Shape.prototype.draw = function draw() {
		this.ctx.beginPath();
	};

	Shape.prototype.toString = function toString() {
		return "{ x: " + this._x + ", y: " + this._y + 
		", color: " + this._color;
	};

	return Shape;
})();

var Circle = (function(){
	function Circle(x, y, color, radius){
		Shape.apply(this, arguments);
		this._radius = radius;
	}

	Circle.extends(Shape);
   
	Circle.prototype.draw = function draw() {
		Shape.prototype.draw.call(this);
		this.ctx.arc(this._x, this._y, this._radius, 0, 2*Math.PI);
		this.ctx.fillStyle = this._color;
		this.ctx.fill();
	};

	Circle.prototype.toString = function() {
		return "Circle-" +
			Shape.prototype.toString.call(this) +
			", radius: " + this._radius + "}";
	};

	return Circle;
})();

var Rectangle = (function() {
	function Rectangle(x, y, color, width, height){
		Shape.apply(this, arguments);
		if (width <= 0) {
			throw new Error("Rectangle width " + width + " cant be negative or zero!");
		} else {
			this._width = width;
		}		

		if (height <= 0) {
			throw new Error("Rectangle width " + height + " cant be negative or zero!");
		} else {
			this._height = height;
		}
	}
		
	Rectangle.extends(Shape);

	Rectangle.prototype.draw = function draw() {
		Shape.prototype.draw.call(this);
		this.ctx.fillStyle = this._color;
		this.ctx.fillRect(this._x, this._y, this._height, this._width); 
	};

	Rectangle.prototype.toString = function() {
		return "Rectangle-" +
			Shape.prototype.toString.call(this) +
			", width: " + this._width + 
			", height: " + this._height + "}";
	};

	return Rectangle;
})();

var Triangle = (function() {
	function Triangle(x, y, color, pointB, pointC){
		Shape.apply(this, arguments);
		this._pointA = new Point(this._x, this._y);
		this._pointB = pointB;
		this._pointC = pointC;
		}

	Triangle.extends(Shape);

	Triangle.prototype.draw = function draw() {
		Shape.prototype.draw.call(this);
		this.ctx.moveTo(this._pointA._x, this._pointA._y);
		this.ctx.lineTo(this._pointB._x, this._pointB._y);
		this.ctx.lineTo(this._pointC._x, this._pointC._y);
		this.ctx.lineTo(this._pointA._x, this._pointA._y);
		this.ctx.fillStyle = this._color;
		this.ctx.fill();
	};

	Triangle.prototype.toString = function() {
		return "Triangle-" +
			Shape.prototype.toString.call(this) +
			", pointA" + this._pointA.toString() + 
			", pointB" + this._pointB.toString() +
			", pointC" + this._pointC.toString() +  "}";
	};

	return Triangle;
})();		

var Segment = (function() {
	function Segment(x, y, color, pointB){
		Shape.apply(this, arguments);
		this._pointA = new Point(this._x, this._y);
		this._pointB = pointB;
		}

	Segment.extends(Shape);

	Segment.prototype.draw = function draw() {
		Shape.prototype.draw.call(this);
		this.ctx.moveTo(this._pointA._x, this._pointA._y);
		this.ctx.lineTo(this._pointB._x, this._pointB._y);
		this.ctx.strokeStyle = this._color;
		this.ctx.stroke();

		return this.ctx;
	};

	Segment.prototype.toString = function() {
		return "Segment-" +
			Shape.prototype.toString.call(this) +
			", pointA:" + this._pointA.toString() + 
			", pointB:" + this._pointB.toString() + "}";
	};

	return Segment;
})();

var shapesList = [];

(function() {
	var selectedShape;
	var currentShape;

	var select = document.getElementById("selectShape");
	select.addEventListener("change", loadShapeUI);
	var addButton = document.getElementById("add");
	addButton.addEventListener("click", addShape);
	var upButton = document.getElementById("up");
	upButton.addEventListener("click", moveUp);
	var downButton = document.getElementById("down");
	downButton.addEventListener("click", moveDown);
	var deleteButton = document.getElementById("delete");
	deleteButton.addEventListener("click", removeShape);

	function addShape() {
		var x = document.getElementById("shapeX").value;
		var y = document.getElementById("shapeY").value;		
		var color = document.getElementById("colorBox").value;
		var pointB;
	
		switch(selectedShape) {
		    case "circle":
		    	var radius = document.getElementById("Radius").value;
		        currentShape = new Circle(x, y, color, radius);	
		        break;
		    case "rectangle":
		        var width = document.getElementById("Width").value;
		        var height = document.getElementById("Height").value;
		        currentShape = new Rectangle(x, y, color, width, height);		        
		        break;
	        case "triangle":  
	        	pointB = assignPointB();
		        var pointC = new Point(
		        	document.getElementById("pointC_x").value,
		        	document.getElementById("pointC_y").value);
		        currentShape = new Triangle(x, y, color, pointB, pointC);
		        break;
	        case "segment":
	        	pointB = assignPointB();
		        currentShape = new Segment(x, y, color, pointB);
		        break;
		    default:
		        throw new Error("addShape - function no such a case !");
		}
		shapesList.push(currentShape);
		initializeFields();
	}

	function moveUp() {
		var tempShape = shapesList[0];
		shapesList.splice(0, 1);
		shapesList[shapesList.length] = tempShape;
		initializeFields();
	}

	function moveDown() {
		var tempShape = shapesList[shapesList.length - 1];
		console.log(shapesList);
		for (var i = shapesList.length-1; i > 0; i--) {
			shapesList[i] = shapesList[i - 1]; 
		}
		shapesList[0] = tempShape;
		initializeFields();
	}

	function removeShape() {
		shapesList.splice(0, 1);
		initializeFields();
	}

	function initializeFields() {
		clearCanvas();
		drawShapesList();
		displayShapesInfo();
	}

	function assignPointB(){
		var poi = new Point(document.getElementById("pointB_x").value,
		        				document.getElementById("pointB_y").value);
		return poi;
	}

	function displayShapesInfo(){
		var infoBox = document.getElementById("shapesInfo");
		var displayString = "";
		for (var i = 0; i < shapesList.length; i++) {
			displayString += shapesList[i].toString() + "\n";
		}
		infoBox.innerHTML = displayString;
	}

	function drawShapesList(){
		clearCanvas();
		for (var i = 0; i < shapesList.length; i++) {
			shapesList[i].draw();
		}
	}

	function clearCanvas(){
		var canvas = document.getElementById("myCanvas");
		var ctx = canvas.getContext("2d");
		var width = canvas.offsetWidth;
		var height= canvas.offsetHeight;
		ctx.clearRect(0, 0, width, height);
	}

	function loadShapeUI() {
	clearShapeProps();
	selectedShape = document.getElementById("selectShape").value;
		switch(selectedShape) {
		    case "circle":
		        loadCircleUI();
		        break;
		    case "rectangle":
		        loadRectangleUI();
		        break;
	        case "triangle":
		        loadTriangleUI();
		        break;
	        case "segment":
		        loadSegmentUI();
		        break;
		    default:
		        throw new Error("Load UI function no such a case !");
		}
	}

	function loadCircleUI() {
		createInputAndLabel("Radius");
	}

	function loadRectangleUI() {
		createInputAndLabel("Width");
		createInputAndLabel("Height");
	}

	var sectionShapeProp = document.getElementById("shapeProp");

	function loadTriangleUI() {
		createInputAndLabel("pointB_x");
		createInputAndLabel("pointB_y");
		var linebreak = document.createElement("br");
		sectionShapeProp.appendChild(linebreak);
		createInputAndLabel("pointC_x");
		createInputAndLabel("pointC_y");
	}

	function loadSegmentUI() {
		createInputAndLabel("pointB_x");
		createInputAndLabel("pointB_y");
	}

	function clearShapeProps(){
		while (sectionShapeProp.firstChild) {
		    sectionShapeProp.removeChild(sectionShapeProp.firstChild);
		}
	}

	function createInputAndLabel(inputName){
		var label = document.createElement("LABEL");
	    label.setAttribute("for", newInput);
	    label.innerHTML = inputName + ": ";
	    sectionShapeProp.appendChild(label);

		var newInput = document.createElement("INPUT");
		newInput.setAttribute("type", "number"); 
		newInput.setAttribute("id", inputName); 
		newInput.setAttribute("name", inputName);
		sectionShapeProp.appendChild(newInput);
	}
}());
