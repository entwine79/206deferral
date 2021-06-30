<?php

    $con = mysqli_connect('localhost', 'root', 'root', '206cde');

    //check that connection happened
    if (mysqli_connect_errno())
    {
        echo "0001: Connection Failed"; //0001: Connection failed.
        exit();
    }

    $username = $_POST["name"];
    $newscore = $_POST["score"];

    $namecheckquery = "SELECT username FROM accounts WHERE username = '" . $username . "';";

    $namecheck = mysqli_query($con, $namecheckquery) or die("0002: Name check query failed during save.");
    if (mysqli_num_rows($namecheck) != 1)
    {
        echo "0005: Account doesn't exist... or exists more than once.";
        exit();
    }

    $updatequery = "UPDATE accounts SET score = " . $newscore . " WHERE username = '" . $username . "';";
    mysqli_query($con, $updatequery) or die("0007: Save failed.");

    echo "0";





?>
