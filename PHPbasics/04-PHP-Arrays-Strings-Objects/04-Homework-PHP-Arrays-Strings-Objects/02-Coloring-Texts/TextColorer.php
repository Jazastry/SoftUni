<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title>Text Colorer</title>
        <link rel="stylesheet" href="css/style.css">
    </head>
    <body>
		<form method="post">
			<textarea name="input"></textarea>
			<input type="submit" name="submit" value="Color Text">
		</form>
<?php 
	if (isset($_POST['submit'])) :

		$input = 'What a wonderful world!';
		$input = preg_replace('/[ ]+/', '', $input);
		$input = str_split($input);

		foreach ($input as $key => $value) :
			
			if (ord($value)%2 == 1) {
				?><span class="blue"><?php echo $value . ' ' ?></span><?php // blue - odd ne4eten
			} else {
				?><span class="red"><?php echo $value . ' ' ?></span><?php // red - even 4eten
			}
		endforeach;
	endif;
 ?>
    </body>
</html>