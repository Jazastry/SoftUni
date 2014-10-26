package geometry.baseClasses;

public class Vertice2D {

	private double x;
	private double y;
	
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
	
	public Vertice2D(double x, double y) {
		super();
		this.setX(x);
		this.setY(y);
	}
	
	@Override	
	public String toString(){
		
		String result = "vertex("+ this.x + ", "+ this.y + ")"; 
		
		return result;
	}
}
