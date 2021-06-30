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
    $namecheckquery = "SELECT username, salt, hash FROM accounts WHERE username = '" . $username . "';";

    $namecheck = mysqli_query($con, $namecheckquery) or die("0002: Name Check Failed"); // 0002: Name check failed
    if (mysqli_num_rows($namecheck) != 1)
    {
        echo "0005: Account doesn't exist... or exists more than once.";
        exit();
    }

    //get login info from query
    $credentials = mysqli_fetch_assoc($namecheck);
    $salt = $credentials["salt"];
    $hash = $credentials["hash"];

    $loginhash = crypt($password, $salt);
    if ($hash != $loginhash)
    {
        echo "0006: Incorrect Password.";
        exit();
    }

    echo "0";


?>