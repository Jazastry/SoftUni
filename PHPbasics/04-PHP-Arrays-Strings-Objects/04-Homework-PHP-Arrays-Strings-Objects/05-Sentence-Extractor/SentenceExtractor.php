<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title>Sentence Extractor</title>
        <link rel="stylesheet" href="css/style.css">
    </head>
    <body>
		<form method="post">
			<label for="text">Text:</label>
			<textarea name="text" id="text"></textarea>
			<label for="word">Word</label>
			<input type="text" name="word" id="word">
			<input type="submit" name="submit" value="Extract">
		</form>
<?php 
	if (isset($_POST['submit'])) :
	$text = $_POST['text'];

	$word = ' ' . $_POST['word'] . ' ';
	$currChar = '';
	$currSentence = '';
	
	for ($i=0; $i < strlen($text); $i++) { 
		$currChar = $text[$i];
		$currSentence .= $currChar; 
		if (($currChar === ',') || ($currChar === '.') || ($currChar === '?') || ($currChar === '!')) {
			
			if (strpos($currSentence, $word )) {
			    
			    ?><p><?php echo $currSentence ;?></p><?php
			}			
			$currSentence = '';
		}
	}
	endif;
 ?>
    </body>
</html>