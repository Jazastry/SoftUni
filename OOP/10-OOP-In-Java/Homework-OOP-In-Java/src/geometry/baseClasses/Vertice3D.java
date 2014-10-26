package geometry.baseClasses;

public class Vertice3D extends Vertice2D {

	private double x;
	private double y;
	private double z;
	
	public double getX() {
		return x;
	}
	public void setX(double x) {
		this.x = x;
	}
	public double getY() {
		return y;
	}
	public void setY(double y) {
		this.y = y;
	}
	public double getZ() {
		return z;
	}
	public void setZ(double z) {
		this.z = z;
	}
	
	public Vertice3D(double x, double y, double z) {
		super(x, y);
		this.setZ(z);
	}
	
	@Override	
	public String toString(){
		
		String result = "vertex("+ this.x + ", "+ this.y + ", " + this.z + ")"; 
		
		return result;
	}
}
