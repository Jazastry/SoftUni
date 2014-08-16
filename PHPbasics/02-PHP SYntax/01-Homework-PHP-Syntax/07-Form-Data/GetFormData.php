<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title>Get Form Data</title>
        <link rel="stylesheet" href="style.css">
    </head>
    <body>
        
        <form action="GetFormData.php" method="get">
		    <input type="text" name="name"><br>
		    <input type="number" name="age"><br>
            <input type="radio" name="sex" value="male">Male<br>
            <input type="radio" name="sex" value="female">Female
		    <input type="submit">
		</form>
		<?php

        if (isset($_GET["name"]) && isset($_GET["age"]) && isset($_GET["sex"])) {

        echo 'My name is ' . htmlentities($_GET["name"]) . '.'.
            ' I`m ' . htmlentities($_GET["age"]) . ' old.' .
            'I`m '  . htmlentities($_GET["sex"]) .'.';
        }
        ?>
    </body>
</html>