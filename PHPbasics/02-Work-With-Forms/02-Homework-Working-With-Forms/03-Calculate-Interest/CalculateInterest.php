<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>Calculate Interest</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
<form method="post">
    <label for="amount">Enter Amount</label>
    <input id="amount" type="number" name="amount" />
    <br>
    <input id="usd" type="radio" name="currency" value="usd"/>
    <label for="usd">USD</label>

    <input id="eur" type="radio" name="currency" value="eur"/>
    <label for="eur">EUR</label>

    <input id="bgn" type="radio" name="currency" value="bgn"/>
    <label for="bgn">BGN</label>
    <br>
    <label for="annual_interest">Compound Interest Amount</label>
    <input id="annual-interest" type="number" name="annual_interest" />
    <br>
    <select name="period">
        <option value="6" selected>6 mont</option>
        <option value="12">1 Year</option>
        <option value="24">2 Years</option>
        <option value="60">5 Years</option>
    </select>

    <input type="submit" />
</form>
<?php

    if (isset($_POST['amount']) && isset($_POST['currency']) && isset($_POST['annual_interest']) && isset($_POST['period'])) {
        $p = (int)$_POST['amount'];
        $currency = currencuSymbol($_POST['currency']);
        $m = 12;
        $j = ((int)$_POST['annual_interest'])/100;
        $t = (double)$_POST['period'];

        $s = $p*pow(1+($j/$m),$t);

        echo $currency . ' ';
        printf("%.2f",$s);
    }
    function currencuSymbol($currWord) {

        switch ($currWord) {
            case 'usd':
                return '$';
                break;
            case 'eur':
                return 'EUR';
                break;
            case 'bgn':
                return 'BGN';
                break;
            default:
                return '';
                break;
        }
    }
?>
</body>
</html>