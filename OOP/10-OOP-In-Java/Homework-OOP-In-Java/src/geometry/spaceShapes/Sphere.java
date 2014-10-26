package geometry.spaceShapes;

import geometry.baseClasses.SpaceShape;
import geometry.baseClasses.Vertice3D;

public class Sphere extends SpaceShape {

	private double radius;
	
	public double getRadius() {
		return radius;
	}
	public void setRadius(double radius) {
		this.radius = radius;
	}
	
	public Sphere(Vertice3D[] verticesArray, double radiusIn) {
		super(verticesArray);
		setRadius(radiusIn);
	}
	@Override
	public double getArea() {
		double r = getRadius();
		double rPow = (Math.pow(r, 2));
		double pI = Math.PI;
		double result = 4*pI*rPow; 
		return result;
	}
	@Override
	public double getVolume() {
		double r = getRadius();
		double rPow = Math.pow(r, 3);
		double pI = Math.PI;
		double result = ((pI*rPow)/3)*4; 
		return result;
	}
	
	public String toString(){
		String result = "Type: Rectangle \n" + super.toString() +
				"Volume : " + this.getVolume() + "\n" +
				"Area : " + this.getArea();		
		return result;
	}
}
