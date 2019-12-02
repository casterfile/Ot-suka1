<?php
include("bl_Common.php");

 $link=dbConnect();
 
        $query = "SELECT * FROM `MyGameDB` ORDER by `score` DESC ";
    $result = mysql_query($query) or die('Query failed: ' . mysql_error());
 
    $num_results = mysql_num_rows($result);  
 
    for($i = 0; $i < $num_results; $i++)
    {
         $row = mysql_fetch_array($result);
         echo $row['name'] . "-" . $row['kills'] . "-" . $row['deaths'] . "-" . $row['score'] . "-\n";
    }
    mysql_close($link);
?>