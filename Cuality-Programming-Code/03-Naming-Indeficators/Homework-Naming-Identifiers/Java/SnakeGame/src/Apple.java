import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;


public class Apple {
	public static Random randomNumberGenerator;
	private GamePoint appleGameObject;
	private Color snakeColor;
	
	public Apple(Snake snakeObject) {
		appleGameObject = createApple(snakeObject);
		snakeColor = Color.RED;		
	}
	
	private GamePoint createApple(Snake snakeObject) {
		randomNumberGenerator = new Random();
		int x = randomNumberGenerator.nextInt(30) * 20; 
		int y = randomNumberGenerator.nextInt(30) * 20;
		for (GamePoint snakePoint : snakeObject.snakeBody) {
			if (x == snakePoint.takeGamePointX() || y == snakePoint.takeGamePointY()) {
				return createApple(snakeObject);				
			}
		}
		return new GamePoint(x, y);
	}
	
	public void drawApple(Graphics graphicsObject){
		appleGameObject.printSnakeBody(graphicsObject, snakeColor);
	}	
	
	public GamePoint takeGamePoint(){
		return appleGameObject;
	}
}
