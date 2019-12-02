<?php
include("bl_Common.php");

$name = $_POST['name'];
$pass = $_POST['password'];

    $link=dbConnect();
 
$check = mysql_query("SELECT * FROM MyGameDB WHERE `name` ='$name' ") or die(mysql_error());
$numrows = mysql_num_rows($check);

if ($numrows == 0)
{
	die ("A user with this name does not exist! \n");
}
else
{
	$pass = md5($pass);
	while($row = mysql_fetch_assoc($check))
	{
		if ($pass == $row['password']){
			$userid = $row['id'];
   
                        echo "Login Done";
                        echo ",";
                        echo $row['name'];
                        echo ",";
                        echo $row['kills'];
                        echo ",";
                        echo $row['deaths'];
                        echo ",";
                        echo $row['score'];
                        echo ",";
						echo $row['id'];
                        echo ",";
       
                } else {
			die("Password is incorrect \n");
	}
                }
}
mysql_close($link);
?>