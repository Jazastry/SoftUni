package geometry.spaceShapes;

import geometry.baseClasses.SpaceShape;
import geometry.baseClasses.Vertice3D;

public class Cuboid extends SpaceShape {	

	private double width;
	private double height;
	private double depth;
	
	public double getWidth() {
		return width;
	}

	public void setWidth(double width) {
		this.width = width;
	}

	public double getHeight() {
		return height;
	}

	public void setHeight(double height) {
		this.height = height;
	}

	public double getDepth() {
		return depth;
	}

	public void setDepth(double depth) {
		this.depth = depth;
	}
	
	public Cuboid(Vertice3D[] verticesArray, double widthIn, double heightIn, double depthIn) {
		super(verticesArray);
		this.setWidth(widthIn);
		this.setHeight(heightIn);
		this.setDepth(depthIn);
	}

	@Override
	public double getArea() {
		double h = this.getHeight();
		double d = this.getDepth();
		double w = this.getWidth();
		double result = ((h*d)*2)+((h*w)*2)+((d*w)*2);
		return result;
	}

	@Override
	public double getVolume() {
		double h = this.getHeight();
		double d = this.getDepth();
		double w = this.getWidth();
		double result = h*d*w;
		return result;
	}
	
	@Override
	public String toString(){
		String result = "Type: Rectangle \n" + super.toString() +
				"Volume : " + this.getVolume() + "\n" +
				"Area : " + this.getArea();		
		return result;
	}
}
