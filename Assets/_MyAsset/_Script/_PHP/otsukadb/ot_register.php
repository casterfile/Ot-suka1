<?php
include("bl_Common.php");
    $link=dbConnect();
 
    $tblUser_Device = safe($_POST['tblUser_Device']);
    $tblUser_FName = safe($_POST['tblUser_FName']);
    $tblUser_LName = safe($_POST['tblUser_LName']);
    $tblUser_Age = safe($_POST['tblUser_Age']);
    $tblUser_Gender = safe($_POST['tblUser_Gender']);
    $tblUser_Location = safe($_POST['tblUser_Location']);
    $hash = safe($_POST['hash']);

    // $tblUser_Device = "Data";
    // $tblUser_FName = "Data";
    // $tblUser_LName = "Data";
    // $tblUser_Age = "Data";
    // $tblUser_Gender = "Data";
    // $tblUser_Location = "Data";

    $real_hash = md5($tblUser_Device . $tblUser_FName . $tblUser_LName);
    //$hash = $real_hash;
    if($real_hash == $hash)
    {
        $check = mysql_query("SELECT * FROM tblUser WHERE `tblUser_Device`= '$tblUser_Device'");

        $numrows = mysql_num_rows($check);
        if ($numrows == 0 )
        {
            //$password = md5($password);
            $ins = mysql_query("INSERT INTO  `tblUser` (`tblUser_Device` ,  `tblUser_FName`,  `tblUser_LName`,  `tblUser_Age`,  `tblUser_Gender`,  `tblUser_Location`  ) VALUES ('".mysql_real_escape_string($tblUser_Device)."' ,  '".mysql_real_escape_string($tblUser_FName)."'
             ,  '".mysql_real_escape_string($tblUser_LName)."' ,  '".mysql_real_escape_string($tblUser_Age)."' ,  '".mysql_real_escape_string($tblUser_Gender)."' ,  '".mysql_real_escape_string($tblUser_Location)."') ");
            if ($ins){
                die ("Done");
            }else{
                die ("Error: " . mysql_error());
            }
        }
        else
        {
            die("Done");
        }
    }
    mysql_close( $link);
?>