package geometry;

import geometry.baseClasses.PlaneShape;
import geometry.baseClasses.Shape;
import geometry.baseClasses.SpaceShape;
import geometry.baseClasses.Vertice2D;
import geometry.baseClasses.Vertice3D;
import geometry.interfaces.PerimeterMeasurable;
import geometry.interfaces.VolumeMeasurable;
import geometry.planeShapes.Circle;
import geometry.planeShapes.Rectangle;
import geometry.planeShapes.Triangle;
import geometry.spaceShapes.Cuboid;
import geometry.spaceShapes.Sphere;
import geometry.spaceShapes.SquarePyramid;

import java.lang.reflect.Array;
import java.util.*;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import com.sun.xml.internal.ws.policy.privateutil.PolicyUtils.Collections;

public class GeometryExamplesSolution {

	public static void main(String[] args) {
		
		/*
		 * Simple Shapes
		 * */ 
		Triangle myTriangle = new Triangle(new Vertice2D[] {
				new Vertice2D(3, 5),
				new Vertice2D(5, 7),
				new Vertice2D(8, 10)
		});
		
		Rectangle myRectangle = new Rectangle(new Vertice2D[] {
				new Vertice2D(5, 10)
		}, 10, 13);
		
		Circle myCircle = new Circle(new Vertice2D[] {
				new Vertice2D(6, -3)
		}, 33);
		
		/*
		 * Space Shapes
		 * */
		
		Cuboid myCuboid = new Cuboid(new Vertice3D[]{
				new Vertice3D(5, 13.5, 60)
		}, 11, 0.3, 8);
		
		Sphere mySphere = new Sphere(new Vertice3D[]{
				new Vertice3D(3, 5, 8)
		}, 55.3);
		
		SquarePyramid myPyramid = new SquarePyramid(new Vertice3D[] {
				new Vertice3D(5, 8, 10)
		}, 13, 44);
		
		Shape[] shapes = new Shape[]{myCircle, myCuboid, myPyramid, myRectangle,
				mySphere, myTriangle};
		

		/*
		 * Print Info 
		 * */ 
//		for (Shape shape : shapes) {
//			System.out.println(shape + "\n");
//		}
		
		
		
		List<Object> spaceShapes = Arrays.stream(shapes)
				.filter(st -> st instanceof SpaceShape)
				.collect(Collectors.toList());
		
		spaceShapes = spaceShapes.stream()
				.filter(sh -> ((VolumeMeasurable) sh).getVolume() > 40)
				.collect(Collectors.toList());
		
//		for (Object shape : spaceShapes) {
//			System.out.println(shape);
//		}

        Object[] plainShapes = (Object[]) Arrays.stream(shapes)
				.filter(st -> st instanceof PlaneShape)				
				.toArray();
		     
        Arrays.sort(plainShapes, new Comparator<Object>() {
			public int compare(Object s1, Object s2) {
				return Double.compare(((PerimeterMeasurable) s2).getPerimeter(), ((PerimeterMeasurable) s1).getPerimeter());
			}
		});
        
        for (Object plainShape : plainShapes) {
			System.out.println(plainShape + "\n");
		}

	}

}
