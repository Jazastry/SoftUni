<?php    
    function is_palindrome($string)
    {
        $a = strtolower(preg_replace("/[^A-Za-z0-9]/","",$string));
        $a==strrev($a);

        if ($a==strrev($a)){
            
            return $string . ' - Is palindrome !'; 
        } else {
            return $string . ' - Is`t palindrome !';
        }
    }

    function splitStr($str) {
        $str1 = preg_replace("/[' ']/", '', $str);
        $str1 = str_split($str1);
        $str2 = '';

        for ($i=0; $i < count($str1); $i++) { 
            
            $str2 = $str2 . $str1[$i] . ' ';
        }
        return $str2;
    }

    function shuffleStr($str) {

        $str1 = str_split($str);
        $str2 = '';

        shuffle($str1);
        foreach ($str1 as $value) {
            $str2 = $str2 . $value; 
        }

        return $str2;
    }
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title>String Modifyer</title>
        <link rel="stylesheet" href="css/style.css">
    </head>
    <body>
        <form method="post" action="">

        	<input type="text" name="input">

        	<input type="radio" name="conversionType" value="polindrome" id="polindrome">
        	<label for="polindrome">Check Palindrome</label>

        	<input type="radio" name="conversionType" value="reverse" id="reverse">
        	<label for="reverse">Reverse String</label>

        	<input type="radio" name="conversionType" value="split" id="split">
        	<label for="split">Split</label>

        	<input type="radio" name="conversionType" value="hash" id="hash">
        	<label for="hash">Hash String</label>

        	<input type="radio" name="conversionType" value="shuffle" id="shuffle">
        	<label for="shuffle">Shuffle String</label>

        	<input type="submit">
        </form>
<?php 

	if (isset($_POST['input'])) {
	
    $strIn = $_POST['input'];
    $conversion = $_POST['conversionType'];

    switch ($conversion) {
    	case 'polindrome':
    		?><p><?php echo is_palindrome($strIn);?></p><?php
    		break;
		case 'reverse':
            ?><p><?php echo strrev($strIn);?></p><?php
    		break;
		case 'split':
            ?><p><?php echo splitStr($strIn);?></p><?php
    		break;
		case 'hash':
            ?><p><?php echo crypt($strIn);?></p><?php
    		break;
		case 'shuffle':
            ?><p><?php echo shuffleStr($strIn);?></p><?php
    		break;
    	
    	default:    		
    		break;
    }

    // echo crypt($strIn);  // crypts input

    // echo is_palindrome($strIn); // returns 1 if polindrome

    // echo strrev($strIn); // reverse string

    //echo splitStr($strIn); // splits the string
    
   //echo shuffleStr($strIn); //shuffles a string
	}
 ?>
    </body>
</html>