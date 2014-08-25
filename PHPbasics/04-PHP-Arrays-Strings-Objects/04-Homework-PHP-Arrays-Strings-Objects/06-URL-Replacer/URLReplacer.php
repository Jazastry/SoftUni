<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title>URL Replacer</title>
        <link rel="stylesheet" href="css/style.css">
    </head>
    <body>
		<form method="post">
			<label for="text">Text:</label>
			<textarea name="text" id="text"></textarea>
			<input type="submit" name="submit" value="Replace">
		</form>
<?php 
	if (isset($_POST['submit'])) :

		$text = $_POST['text'];

		$htmlTag = array('<a href="', '">', '</a>');
		$forumTag = array('[URL=', ']', '[/URL]');

		$output = str_replace($htmlTag, $forumTag, $text);
	 	
	 	echo $output;
	endif;
 ?>
    </body>
</html>