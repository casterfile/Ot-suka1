<?php
 
$dbName = 'immersiv_potatocorner';
$secretKey = "123456";

function dbConnect()
{
    global  $dbName;
    global  $secretKey;
 
    $link = mysql_connect('168.144.155.122', 'immersiv_pcorner', 'pcorner123');
   
    if(!$link)
    {
        fail("Couldn´t connect to database server");
    }
   
    if(!@mysql_select_db($dbName))
    {
        fail("Couldn´t find database $dbName");
    }
   
    return $link;
    }
   
function safe($variable)
{
    $variable = addslashes(trim($variable));
    return $variable;
}
 
function fail($errorMsg)
{
    print $errorMsg;
    exit;
}
 
?>