<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title>Print Tags</title>
    </head>
    <body>
    	<form method="post">
            <p>Enter Tags: </p>
            <input type="text" name="input" />
            <input type="submit" />
        </form>
        <?php

        if (isset($_POST["input"])) {

            $tagArr = explode(", ",$_POST['input']);

            for ($i = 0; $i < count($tagArr); $i++) {

               echo "<p>" . $i . " : " . $tagArr[$i] . "</p>";

            }
        }
        ?>
    </body>
</html>