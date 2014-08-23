<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title>Primes In Range</title>
        <link rel="stylesheet" href="style.css">
    </head>
    <body>
        <form method="post">
            <input type="number" name="start">
            <input type="number" name="end">
            <input type="submit" name="submit" value="submit">
        </form>
        <p>
<?php

    function getPrimes($finish) {
    $number = 2;
    $range = range($number,$finish);
    $primes = array_combine($range,$range);
        while($number*$number < $finish){
            for($i=$number; $i<=$finish; $i+=$number){
                if($i==$number){
                    continue;
                }
                unset($primes[$i]);
            }
            $number = next($primes);
        }
    return $primes;
    }

    if (isset($_POST['submit'])) {

        $startNumb = $_POST['start'];
        $endNumb = $_POST['end'];
        $primArray = getPrimes($endNumb);

        for ($i = $startNumb; $i <= $endNumb; $i++) { 
            

            if (in_array($i, $primArray, true)) {
                
                ?><span><?php echo " " . $i . ",";?></span><?php
            } else {

                echo " " . $i . ",";
            }
        }        
    }
   
?>      </p>
    </body>
</html>