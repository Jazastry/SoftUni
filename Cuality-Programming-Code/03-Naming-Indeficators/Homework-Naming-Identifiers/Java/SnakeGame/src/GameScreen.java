import java.awt.Canvas;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.image.BufferedImage;

@SuppressWarnings("serial")
public class GameScreen extends Canvas implements Runnable {
	public static Snake snakeObject;
	public static Apple appleObject;
	static int gamePoint;
	
	private Graphics globalGraphics;
	private Thread runThread;
	public static final int WIDTH = 600;
	public static final int HEIGHT = 600;
	private final Dimension SCREEN_SIZE = new Dimension(WIDTH, HEIGHT);
	
	static boolean gameRunning = false;
	
	public void PaintGameScreen(Graphics graphicsObject){
		this.setPreferredSize(SCREEN_SIZE);
		globalGraphics = graphicsObject.create();
		gamePoint = 0;
		
		if(runThread == null){
			runThread = new Thread(this);
			runThread.start();
			gameRunning = true;
		}
	}
	
	public void Run(){
		while(gameRunning){
			snakeObject.tick();
			render(globalGraphics);
			try {
				Thread.sleep(100);
			} catch (Exception e) {
				// TODO: Implement Exception Catcher
			}
		}
	}
	
	public GameScreen(){	
		snakeObject = new Snake();
		appleObject = new Apple(snakeObject);
	}
		
	public void Render(Graphics graphicsObject){
		graphicsObject.clearRect(0, 0, WIDTH, HEIGHT+25);
		
		graphicsObject.drawRect(0, 0, WIDTH, HEIGHT);			
		snakeObject.printTheSnake(graphicsObject);
		appleObject.drawApple(graphicsObject);
		graphicsObject.drawString("score= " + gamePoint, 10, HEIGHT + 25);		
	}
}

