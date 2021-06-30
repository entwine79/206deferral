<?php

    $con = mysqli_connect('localhost', 'root', 'root', '206cde');

    //check that connection happened
    if (mysqli_connect_errno())
    {
        echo "0001: Connection Failed"; //0001: Connection failed.
        exit();
    }

    $username = $_POST["name"];
    $password = $_POST["password"];

    //check if name exists
    $namecheckquery = "SELECT username FROM accounts WHERE username = '" . $username . "';";

    $namecheck = mysqli_query($con, $namecheckquery) or die("0002: Name Check Failed"); // 0002: Name check failed

    if (mysqli_num_rows($namecheck) > 0)
    {
        echo "0003: Name already exists"; // 0003: Name exists, cannot register
        exit();
    }

    //add user to the table | \$ means it will write $ as text, nothing special
    //SHA256 encryption, it will and round characters 5000 times andd come with a massive code thing instead of password
    $salt = "\$5\$rounds=5000\$" . "steamedhams" . $username . "\$";
    $hash = crypt($password, $salt);
    $insertuserquery = "INSERT INTO accounts (username, hash, salt) VALUES ('" . $username . "', '" . $hash . "', '" . $salt . "');";
    mysqli_query($con, $insertuserquery) or die ("0004: Insert player query failed"); // 0004: insert query failed

    echo("0");


?>