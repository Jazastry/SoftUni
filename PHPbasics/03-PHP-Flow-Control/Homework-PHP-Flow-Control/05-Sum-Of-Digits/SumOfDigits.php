<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title>Sum Of Digits</title>
        <link rel="stylesheet" href="css/style.css">
    </head>
    <body>
		<form method="post">
			<label for="input">Input string:</label>
			<input type="text" name="input" id="input">
			<input type="submit" name="submit">
		</form>
		<table>
<?php 
	if (isset($_POST['submit'])) {

	    $inStr = $_POST['input'];
	    $inArr = explode(", ",$inStr);
	    $sum = 0;
	    $isChar = true;

	    for ($i = 0; $i < count($inArr); $i++) { 
	        $isChar = true; 
	        $sum = 0; 
	        ?><tr><?php        
	        for ($j = 0; $j < strlen($inArr[0]); $j++) { 

	            if (preg_replace('/[0-9]/', "OK", $inArr[$i][$j]) != 'OK') {

	                $isChar = false;
	            }
	            $sum = $sum + $inArr[$i][$j];
	        }
	        if ($isChar) {
	             ?><td><?php echo $inArr[$i];?></td><td><?php echo $sum;?></td><?php
	        } else {
	        	?><td><?php echo $inArr[$i];?></td><td><?php echo "I can`t sum that";?></td><?php
	        }
	        ?></tr><?php
	    } 
    }
 ?>		</table>
    </body>
</html>