package geometry.planeShapes;

import geometry.baseClasses.PlaneShape;
import geometry.baseClasses.Vertice2D;
import geometry.interfaces.AreaMeasurable;
import geometry.interfaces.PerimeterMeasurable;

import java.security.InvalidParameterException;

public class Circle extends PlaneShape implements AreaMeasurable, PerimeterMeasurable {

	private double radius;
	
	public double getRadius() {
		return radius;
	}
	public void setRadius(double radius) {
		if (radius >= 0) {
			this.radius = radius;
		} else {
			throw new InvalidParameterException("Radius Cant Be negative value.");
		}		
	}
	
	public Circle(Vertice2D[] inVerticeArray, double radiusIn) {
		super(inVerticeArray);
		this.radius = radiusIn;
	}
	
	@Override
	public double getPerimeter() {
		double result = 2*(Math.PI*this.radius);
		return result;
	}
	
	@Override
	public double getArea() {
		double result = Math.PI*(Math.pow(this.radius, 2));
		return result;
	}
	
	@Override
	public String toString(){
		String result = "Type: Circle \n" + 
				super.toString() +
				"Perimeter : " + this.getPerimeter() + "\n" +
				"Area : " + this.getArea();		
		return result;
	}
}
