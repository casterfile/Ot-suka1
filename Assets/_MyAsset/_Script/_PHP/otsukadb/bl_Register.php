<?php
include("bl_Common.php");
    $link=dbConnect();
 
    $name = safe($_POST['name']);
    $password = safe($_POST['password']);
    $kills = safe($_POST['kills']);
    $deaths = safe($_POST['deaths']);
    $score = safe($_POST['score']);
    $hash = safe($_POST['hash']);
 

    $real_hash = md5($name . $password . $secretKey);
    if($real_hash == $hash)
    {
$check = mysql_query("SELECT * FROM MyGameDB WHERE `name`= '$name'");

$numrows = mysql_num_rows($check);
if ($numrows == 0 )
{
	$password = md5($password);
	$ins = mysql_query("INSERT INTO  `MyGameDB` (`name` ,  `password`  ) VALUES ('".mysql_real_escape_string($name)."' ,  '".mysql_real_escape_string($password)."') ");
	if ($ins){
        
                die ("Done");
    }else{
		die ("Error: " . mysql_error());
        }
}
else
{
	die("A user with this name already exists,\n please choose another one!");
}
    }
    mysql_close( $link);
?>