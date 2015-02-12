import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;
/*
 * Game Point is smallest part printed on the screen
 * 
 * Boath Snake and Apple objects consist of game points
 * 
 * @see Snake.java
 * @see Apple.java
 * 
 * */
public class GamePoint {
	private int GamePointX, GamePointY;
	private final int WIDTH = 20;
	private final int HEIGHT = 20;
	
	public GamePoint(GamePoint p){
		this(p.GamePointX, p.GamePointY);
	}
	
	public GamePoint(int x, int y){
		this.GamePointX = x;
		this.GamePointY = y;
	}	
		
	public int takeGamePointX() {
		return GamePointX;
	}
	public void setGamePointX(int x) {
		this.GamePointX = x;
	}
	public int takeGamePointY() {
		return GamePointY;
	}
	public void setGamePointY(int y) {
		this.GamePointY = y;
	}
	
	public void printGamePoint(Graphics graphicsObject, Color cvqt) {
		graphicsObject.setColor(Color.BLACK);
		graphicsObject.fillRect(GamePointX, GamePointY, WIDTH, HEIGHT);
		graphicsObject.setColor(cvqt);
		graphicsObject.fillRect(GamePointX+1, GamePointY+1, WIDTH-2, HEIGHT-2);		
	}
	
	public String toString() {
		return "[x=" + GamePointX + ",y=" + GamePointY + "]";
	}
	/*
	 * Used to catch Snake - Snake colision
	 * 
	 * */
	public boolean equals(Object gameObject) {
        if (gameObject instanceof GamePoint) {
            GamePoint GamePoint = (GamePoint)gameObject;
            return (GamePointX == GamePoint.GamePointX) && (GamePointY == GamePoint.GamePointY);
        }
        return false;
    }
}
