<?php
include("bl_Common.php");
     
 $name = safe($_POST['name']);
 $kills = safe($_POST['kills']);
 $deaths = safe($_POST['deaths']);
 $score = safe($_POST['score']);
 $hash = safe($_POST['hash']);
 
 $link=dbConnect();
 
$real_hash = md5($name . $secretKey);
    if($real_hash == $hash)
    {
$check = mysql_query("UPDATE MyGameDB SET kills='". mysql_escape_string($kills) ."', deaths='". mysql_escape_string($deaths) ."', score='". mysql_escape_string($score) ."' WHERE name='$name'");
$numrows = mysql_num_rows($check);
echo "success";
    }
mysql_close($link);
?>