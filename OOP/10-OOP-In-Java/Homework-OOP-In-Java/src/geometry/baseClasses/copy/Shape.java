package geometry.baseClasses.copy;

public abstract class Shape<T> {	
	public T[] verticeArray;

	public T[] getVerticeArray() {
		return verticeArray;
	}

	public void setVerticeArray(T[] verticeArray) {
		this.verticeArray = verticeArray;
	}
	@Override
	public String toString(){
		
		String vertices = "Vertices : \n";
		for (int i = 0; i < this.verticeArray.length; i++) {
			vertices += this.verticeArray[i].toString() + " ";
		} 
		
		return vertices + "\n";		
	}
}
