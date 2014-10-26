package geometry.baseClasses.copy;

import geometry.interfaces.AreaMeasurable;
import geometry.interfaces.PerimeterMeasurable;

public abstract class PlaneShape extends Shape<Vertice2D> implements AreaMeasurable, PerimeterMeasurable {

	public PlaneShape(Vertice2D[] inVerticeArray) {
		super();
		this.verticeArray = inVerticeArray;
	}	
}
