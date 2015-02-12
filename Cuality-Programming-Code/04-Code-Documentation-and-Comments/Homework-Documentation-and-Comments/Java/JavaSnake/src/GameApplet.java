import java.applet.Applet;
import java.awt.Dimension;
import java.awt.Graphics;
/*
 * Used To initialize GameSceen 
 * 
 * */
@SuppressWarnings("serial")
public class GameApplet extends Applet {
	private GameScreen gameScreenObject;
	MyKeyListener IH;
	/*
	 * @see GameScreen.java
	 * */
	public void init(){
		gameScreenObject = new GameScreen();
		gameScreenObject.setPreferredSize(new Dimension(800, 650));
		gameScreenObject.setVisible(true);
		gameScreenObject.setFocusable(true);
		this.add(gameScreenObject);
		this.setVisible(true);
		this.setSize(new Dimension(800, 650));
		IH = new MyKeyListener(gameScreenObject);
	}
	
	public void paint(Graphics gameSceenObject){
		this.setSize(new Dimension(800, 650));
	}
}
