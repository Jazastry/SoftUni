<!DOCTYPE html>
<?php
    session_start();
?>
<html>
    <head>
        <meta charset="utf-8">
        <title>HTML Tags Counter</title>
        <link rel="stylesheet" href="style.css">
    </head>
    <body>
    	<form method="post">
	        <label for="input">Enter HTML Tags :</label>
	        <input type="text" id="input" name="input">	
	        
	        <input type="submit" value="Submit">	        
        </form>
        <?php

	        if (isset($_POST['input'])) {
	                      
				$input = $_POST['input'];
				$allTags = array('!doctype','!DOCTYPE', 'a', 'abbr', 'acronym', 'address', 'applet', 'area', 'article', 'aside', 'audio', 'b', 'base', 'basefont', 'bdi', 'bdo', 'big', 'blockquote', 'body', 'br', 'button', 'canvas', 'caption', 'center', 'cite', 'code', 'col', 'colgroup', 'datalist', 'dd', 'del', 'details', 'dfn', 'dialog', 'dir', 'div', 'dl', 'dt', 'em', 'embed', 'fieldset', 'figcaption', 'figure', 'font', 'footer', 'form', 'frame', 'frameset', 'head', 'header', 'h1', 'h6', 'hr', 'html', 'i', 'iframe', 'img', 'input', 'ins', 'kbd', 'keygen', 'label', 'legend', 'li', 'link', 'main', 'map', 'mark', 'menu', 'menuitem', 'meta', 'meter', 'nav', 'noframes', 'noscript', 'object', 'ol', 'optgroup', 'option', 'output', 'p', 'param', 'pre', 'progress', 'q', 'rp', 'rt', 'ruby', 's', 'samp', 'script', 'section', 'select', 'small', 'source', 'span', 'strike', 'strong', 'style', 'sub', 'summary', 'sup', 'table', 'tbody', 'td', 'textarea', 'tfoot', 'th', 'thead', 'time', 'title', 'tr', 'track', 'tt', 'u', 'ul', 'var', 'video', 'wbr');

				if (in_array($input, $allTags)) {

	                if (isset($_SESSION['score'])) {
	                	
	                	$_SESSION['score'] = $_SESSION['score'] + 1;
	                } else {

	                	$_SESSION['score'] = 1;
	                }
                    ?>
                   <p><?php echo "Valid HTML Tag !";?></p>
                   <p><?php echo "Score: " . $_SESSION['score'];?></p>
                <?php
				} else {

					if (!isset($_SESSION['score'])) {

	                    $_SESSION['score'] = 0;
	                }
	            ?>    
				    <p><?php echo "Invalid HTML Tag !";?></p>
                   <p><?php echo "Score: " . $_SESSION['score'];?></p>
                <?php   
				}
			}
		?>
    </body>
</html>