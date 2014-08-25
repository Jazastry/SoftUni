<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title>Word Mapper</title>
        <link rel="stylesheet" href="css/style.css">
    </head>
    <body>
        <form method="post">
        	<textarea name="input" class="textArea"></textarea>
        	<input type="submit" name="submit" value="Submit">
        </form>
        <table>
<?php 
	if (isset($_POST['submit'])) :

		$input = $_POST['input'];
		$input = preg_replace('/\W+/', ' ', $input);
		$input = strtolower($input);
		$input = explode(' ', $input);
		$input = array_filter($input);
		$input = array_count_values($input);
		foreach ($input as $key => $value) :

		?><tr><?php 
			?><td><?php echo $key;?></td><td><?php echo $value;?></td><?php
		?></tr><?php

		endforeach;
	endif;
 ?>		</table>
    </body>
</html>