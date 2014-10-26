package geometry.planeShapes;

import geometry.baseClasses.PlaneShape;
import geometry.baseClasses.Vertice2D;
import geometry.interfaces.AreaMeasurable;
import geometry.interfaces.PerimeterMeasurable;
import geometry.utils.Utils;

public class Triangle extends PlaneShape implements AreaMeasurable, PerimeterMeasurable{

	public Triangle(Vertice2D[] inVerticeArray) {
		super(inVerticeArray);
	}

	@Override
	public double getPerimeter() {
		double distanceA = Utils.CalculateDistance2D(this.verticeArray[0], this.verticeArray[1]);
		double distanceB = Utils.CalculateDistance2D(this.verticeArray[1], this.verticeArray[2]);
		double distanceC = Utils.CalculateDistance2D(this.verticeArray[2], this.verticeArray[0]);
		double result = distanceA + distanceB + distanceC;
		
		return result;
	}

	@Override
	public double getArea() {
		double halfDistanceA = Utils.CalculateDistance2D(this.verticeArray[0], this.verticeArray[1])/2;
		double halfDistanceB = Utils.CalculateDistance2D(this.verticeArray[1], this.verticeArray[2])/2;
		double halfDistanceC = Utils.CalculateDistance2D(this.verticeArray[2], this.verticeArray[0])/2;
		double s = this.getPerimeter() / 2;
		double result = Math.sqrt(s*(halfDistanceA*(halfDistanceB*halfDistanceC)));
		return result;
	}
	
	@Override
	public String toString(){
		String result = "Type: Triangle \n" + super.toString() +
				"Perimeter : " + this.getPerimeter() + "\n" +
				"Area : " + this.getArea();
		
		return result;
	}
}
