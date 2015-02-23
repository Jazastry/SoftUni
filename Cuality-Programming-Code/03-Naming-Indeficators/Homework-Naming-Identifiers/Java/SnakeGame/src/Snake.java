import java.awt.Color;
import java.awt.Graphics;
import java.util.LinkedList;

public class Snake{
	LinkedList<GamePoint> snakeBody = new LinkedList<GamePoint>();
	private Color snakeColor;
	private int velocityX, velocityY;
	
	public Snake() {
		snakeColor = Color.GREEN;
		snakeBody.add(new GamePoint(300, 100)); 
		snakeBody.add(new GamePoint(280, 100)); 
		snakeBody.add(new GamePoint(260, 100)); 
		snakeBody.add(new GamePoint(240, 100)); 
		snakeBody.add(new GamePoint(220, 100)); 
		snakeBody.add(new GamePoint(200, 100)); 
		snakeBody.add(new GamePoint(180, 100));
		snakeBody.add(new GamePoint(160, 100));
		snakeBody.add(new GamePoint(140, 100));
		snakeBody.add(new GamePoint(120, 100));

		velocityX = 20;
		velocityY = 0;
	}
	
	public void printTheSnake(Graphics snakeGameObject) {		
		for (GamePoint point : this.snakeBody) {
			point.printGamePoint(snakeGameObject, snakeColor);
		}
	}
	
	public void gameTimeFrame() {
		GamePoint newGamePoint = new GamePoint((snakeBody.get(0).takeGamePointX() + velocityX), (snakeBody.get(0).takeGamePointY() + velocityY));
		
		if (newGamePoint.takeGamePointX() > GameScreen.WIDTH - 20) {
		 	GameScreen.gameRunning = false;
		} else if (newGamePoint.takeGamePointX() < 0) {
			GameScreen.gameRunning = false;
		} else if (newGamePoint.takeGamePointY() < 0) {
			GameScreen.gameRunning = false;
		} else if (newGamePoint.takeGamePointY() > GameScreen.height - 20) {
			GameScreen.gameRunning = false;
		} else if (GameScreen.appleGameObject.takeGamePoint().equals(newGamePoint)) {
			snakeBody.add(GameScreen.appleGameObject.takeGamePoint());
			GameScreen.appleGameObject = new Qbalkata(this);
			GameScreen.to4ki += 50;
		} else if (snakeBody.contains(newGamePoint)) {
			GameScreen.gameRunning = false;
			System.out.println("You ate yourself");
		}	
		
		for (int i = snakeBody.size()-1; i > 0; i--) {
			snakeBody.set(i, new GamePoint(snakeBody.get(i-1)));
		}	
		snakeBody.set(0, newGamePoint);
	}

	public int getVelocityX() {
		return velocityX;
	}

	public void setVelocityX(int velocityX) {
		this.velocityX = velocityX;
	}

	public int gatVelocityY() {
		return velocityY;
	}

	public void setVelocityY(int velocityY) {
		this.velocityY = velocityY;
	}
}