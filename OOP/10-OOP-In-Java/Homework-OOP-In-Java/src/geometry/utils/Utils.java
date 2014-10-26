package geometry.utils;

import geometry.baseClasses.Vertice2D;

public class Utils {

	public static double CalculateDistance2D(Vertice2D verticleA, Vertice2D verticleB) {
		double aX = verticleA.getX();
		double aY = verticleA.getY();
		
		double bX = verticleB.getX();
		double bY = verticleB.getY();
		
		double result = Math.sqrt(Math.pow((aX - bX),2) + Math.pow((aY - bY), 2));
		return result;
	}

}
