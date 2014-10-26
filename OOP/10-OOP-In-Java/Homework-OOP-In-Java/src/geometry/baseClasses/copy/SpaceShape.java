package geometry.baseClasses.copy;

import geometry.interfaces.AreaMeasurable;
import geometry.interfaces.VolumeMeasurable;

public abstract class SpaceShape extends Shape<Vertice3D> implements AreaMeasurable, VolumeMeasurable{

	public SpaceShape(Vertice3D[] verticesArray) {
		super();
		this.verticeArray = verticesArray;
	}
}
