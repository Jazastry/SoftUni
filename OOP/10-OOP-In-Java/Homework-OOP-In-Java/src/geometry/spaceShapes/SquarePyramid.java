package geometry.spaceShapes;

import geometry.baseClasses.SpaceShape;
import geometry.baseClasses.Vertice3D;

public class SquarePyramid extends SpaceShape {

	private double baseWidth;
	private double height;
	
	public double getBaseWidth() {
		return baseWidth;
	}

	public void setBaseWidth(double baseWidth) {
		this.baseWidth = baseWidth;
	}

	public double getHeight() {
		return height;
	}

	public void setHeight(double height) {
		this.height = height;
	}
	
	public SquarePyramid(Vertice3D[] verticesArray, double baseWidthIn, double heigthIn) {
		super(verticesArray);
		this.setBaseWidth(baseWidthIn);
		this.setHeight(heigthIn);		
	}	

	@Override
	public double getArea() {
		double a = this.baseWidth;
		double h = this.height;
		double result = a*(a+Math.sqrt((Math.pow(a, 2) + (4*Math.pow(h, 2)))));
		return result;
	}	

	@Override
	public double getVolume() {
		double a = this.baseWidth;
		double h = this.height;
		double result = ((a*a)*h)/3;
		return result;
	}
	
	@Override
	public String toString(){
		String result = "Type: Square pyramid \n" + 
				super.toString() +
				"Volume : " + this.getVolume() + "\n" +
				"Area : " + this.getArea();		
		return result;
	}
}
