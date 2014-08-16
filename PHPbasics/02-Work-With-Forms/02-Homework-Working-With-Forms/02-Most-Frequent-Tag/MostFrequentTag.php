<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>Most Frequent Tag</title>
</head>
<body>
    <form method="post">
        <p>Enter Tags: </p>
        <input type="text" name="input" />
        <input type="submit" />
    </form>
    <?php

        if (isset($_POST["input"])) {

        $arr = explode(", ",$_POST['input']);
        $tagsObj = array();
        $currentTag = null;
        $currName = '';

        //::::::: INITIALIZE ASSOCIATIVE ARRAY ::::::::::::::::

        for ($i=0; $i < count($arr); $i++) {

            $currName = $arr[$i];

            if (array_key_exists("$currName",$tagsObj)) {

                continue;
            } else {

                $tagsObj["$currName"] = 1;
            }
        }

        //::::::: ASSING VALUES TO THE PROPERTYES :::::::::::::::::

        for ($i=0; $i < count($arr); $i++) {

            $currentTag = $arr[$i];

            for ($j = $i + 1; $j < count($arr) - 1; $j++) {

                if ($currentTag === $arr[$j]) {

                    //echo $arr[$j];
                    $tagsObj[$arr[$j]] += 1;
                }
            }
        }

        arsort($tagsObj);

        foreach ($tagsObj as $key => $value) {

            ?>

           <p><?php echo "$key" . '->' . "$value"; ?></p>

        <?php
        }

        $maxKey = max(array_keys($tagsObj));

        ?>

        <p><?php echo 'Most Frequent Tag is : ' . $maxKey; ?></p>

        <?php

        }
        ?>
</body>
</html>