package geometry.planeShapes;

import geometry.baseClasses.PlaneShape;
import geometry.baseClasses.Vertice2D;
import geometry.interfaces.AreaMeasurable;
import geometry.interfaces.PerimeterMeasurable;

import java.security.InvalidParameterException;

public class Rectangle extends PlaneShape implements AreaMeasurable, PerimeterMeasurable {

	private double width;
	private double heigth;
	
	public double getWidth() {
		return width;
	}
	public void setWidth(double width) {
		if (width >= 0) {
			this.width = width;
		} else {
			throw new InvalidParameterException("Width Cant Be negative value.");
		}
	}
	public double getHeigth() {
		return heigth;
	}
	public void setHeigth(double heigthIn) {
		if (heigthIn >= 0) {
			this.heigth = heigthIn;
		} else {
			throw new InvalidParameterException("Width Cant Be negative value.");
		}
	}
	
	public Rectangle(Vertice2D[] inVerticeArray, double width, double heigth) {
		super(inVerticeArray);	
		this.setWidth(width);
		this.setHeigth(heigth);
	}
	
	@Override
	public double getPerimeter() {
		double result = (this.getWidth() *2) + (this.getHeigth() * 2);
		return result;
	}
	
	@Override
	public double getArea() {
		double result = this.getHeigth() * this.getWidth();
		return result;
	}
	
	@Override
	public String toString(){
		String result = "Type: Rectangle \n" + super.toString() +
				"Perimeter : " + this.getPerimeter() + "\n" +
				"Area : " + this.getArea();		
		return result;
	}
}
