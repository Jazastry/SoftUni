<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title>Text Filter</title>
        <link rel="stylesheet" href="css/style.css">
    </head>
    <body>
		<form method="post">
			<label for="text">Text:</label>
			<textarea name="text" id="text"></textarea>
			<label for="banList">Ban Words</label>
			<input type="text" name="banList" id="banList">
			<input type="submit" name="submit" value="Filter">
		</form>
<?php 
	if (isset($_POST['submit'])) :

		$text = $_POST['text'];

		$banList = $_POST['banList'];
		$banReplace = array();
		$banArr = explode(', ', $banList);
		for ($i=0; $i < count($banArr); $i++) { 
			$banReplace[$i] = '';
			for ($j=0; $j < strlen($banArr[$i]); $j++) { 
				$banReplace[$i] = $banReplace[$i] . '*';
			}
		}
		$banedStr = str_replace($banArr, $banReplace, $text);

		echo $banedStr; 
	endif;
 ?>
    </body>
</html>