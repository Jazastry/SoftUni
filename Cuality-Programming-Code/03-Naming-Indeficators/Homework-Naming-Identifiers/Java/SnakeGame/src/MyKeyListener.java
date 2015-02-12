import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class MyKeyListener implements KeyListener{
	
	public MyKeyListener(GameScreen game){
		game.addKeyListener(this);
	}
	
	public void keyPressed(KeyEvent keyPressed) {
		int keyCode = keyPressed.getKeyCode();
		
		if (keyCode == KeyEvent.VK_W || keyCode == KeyEvent.VK_UP) {
			if(GameScreen.snakeObject.getVelY() != 20){
				GameScreen.snakeObject.setVelX(0);
				GameScreen.snakeObject.setVelY(-20);
			}
		}
		if (keyCode == KeyEvent.VK_S || keyCode == KeyEvent.VK_DOWN) {
			if(GameScreen.snakeObject.getVelY() != -20){
				GameScreen.snakeObject.setVelX(0);
				GameScreen.snakeObject.setVelY(20);
			}
		}
		if (keyCode == KeyEvent.VK_D || keyCode == KeyEvent.VK_RIGHT) {
			if(GameScreen.snakeObject.getVelX() != -20){
			GameScreen.snakeObject.setVelX(20);
			GameScreen.snakeObject.setVelY(0);
			}
		}
		if (keyCode == KeyEvent.VK_A || keyCode == KeyEvent.VK_LEFT) {
			if(GameScreen.snakeObject.getVelX() != 20){
				GameScreen.snakeObject.setVelX(-20);
				GameScreen.snakeObject.setVelY(0);
			}
		}

		if (keyCode == KeyEvent.VK_ESCAPE) {
			System.exit(0);
		}
	}
	
	public void keyReleased(KeyEvent keyPressed) {
	}
	
	public void keyTyped(KeyEvent keyPressed) {
		
	}

}
